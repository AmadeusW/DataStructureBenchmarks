using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;

namespace Deo.DataStructureBenchmarks
{
    public class CostOfTypeName
    {
        [Params(64, 128, 256)]
        public int Ops;

        private const string ConstString = nameof(CostOfTypeName);

        [GlobalSetup]
        public void Setup()
        {
        }

        [Benchmark]
        public void Baseline()
        {
            var list = new List<object>(Ops);
            for (int i = 0; i < Ops; i++)
            {
                var typeName = ConstString;
                list.Add(typeName);
            }
        }

        [Benchmark]
        public void Type()
        {
            var list = new List<object>(Ops);
            for (int i = 0; i < Ops; i++)
            {
                list.Add(this.GetType());
            }
        }

        [Benchmark]
        public void GetTypeToString()
        {
            var list = new List<object>(Ops);
            for (int i = 0; i < Ops; i++)
            {
                list.Add(this.GetType().ToString());
            }
        }
    }
}