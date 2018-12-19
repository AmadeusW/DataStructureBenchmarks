using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Deo.DataStructureBenchmarks
{
    public class HashSetVsArrayBuilder
    {
        private ImmutableArray<string>.Builder arrayBuilder = ImmutableArray.CreateBuilder<string>();
        private HashSet<string> hashSet = new HashSet<string>();
        private string[] writeData;
        private string[] readData;
        public bool check;

        [Params(0, 1, 10, 50, 100)]
        public int Writes;

        [Params(0, 1, 10, 50, 100)]
        public int Reads;

        [GlobalSetup]
        public void Setup()
        {
            var bytes = new byte[Writes];
            new Random(42).NextBytes(bytes);
            writeData = bytes.Select(n => n.ToString()).ToArray();
            new Random(42).NextBytes(bytes);
            readData = bytes.Select(n => n.ToString()).ToArray();
        }

        [Benchmark]
        public void ArrayBuilder()
        {
            for (int i = 0; i < Writes; i++)
            {
                arrayBuilder.Add(writeData[i]);
            }

            for (int i = 0; i < Reads; i++)
            {
                check = arrayBuilder.Contains(readData[i]);
            }
        }

        [Benchmark]
        public void HashSet()
        {
            for (int i = 0; i < Writes; i++)
            {
                hashSet.Add(writeData[i]);
            }

            for (int i = 0; i < Reads; i++)
            {
                check = hashSet.Contains(readData[i]);
            }
        }
    }
}