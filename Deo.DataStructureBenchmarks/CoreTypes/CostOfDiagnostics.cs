using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;

namespace Deo.DataStructureBenchmarks
{
    public class CostOfDiagnostics
    {
        [Params(64, 128, 256, 512)]
        public int Ops;

        [GlobalSetup]
        public void Setup()
        {
        }

        [Benchmark]
        public void Baseline()
        {
            for (int i = 0; i < Ops; i++)
            {
                var list = new List<string>();
                list.Add($"value {i}");
            }
        }

        [Benchmark]
        public void GetGcCount()
        {
            for (int i = 0; i < Ops; i++)
            {
                var list = new List<string>();
                list.Add($"value {i}");
                var gcCount = GC.CollectionCount(0);
            }
        }

        [Benchmark]
        public void Exception()
        {
            for (int i = 0; i < Ops; i++)
            {
                try
                {
                    var list = new List<string>();
                    list.Add($"value {i}");
                    throw new InvalidOperationException();
                }
                catch { }
            }
        }

        [Benchmark]
        public void StackTrace()
        {
            for (int i = 0; i < Ops; i++)
            {
                var list = new List<string>();
                list.Add($"value {i}");
                var stackTrace = Environment.StackTrace;
            }
        }

        [Benchmark]
        public void ConsoleWrite()
        {
            for (int i = 0; i < Ops; i++)
            {
                var list = new List<string>();
                list.Add($"value {i}");
                Console.WriteLine(i);
            }
        }
    }
}