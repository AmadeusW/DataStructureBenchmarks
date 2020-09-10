using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;

namespace Deo.DataStructureBenchmarks
{
    public class CostOfTypeName
    {
        [Params(64, 128, 256, 512)]
        public int Ops;

        private const string ConstString = nameof(CostOfTypeName);

        [GlobalSetup]
        public void Setup()
        {
        }

        [Benchmark]
        public void Baseline()
        {
            var list = new List<string>(Ops);
            for (int i = 0; i < Ops; i++)
            {
                var typeName = ConstString;
                list.Add($"value {typeName}");
            }
        }

        [Benchmark]
        public void GetTypeToString()
        {
            var list = new List<string>(Ops);
            for (int i = 0; i < Ops; i++)
            {
                var typeName = this.GetType() .ToString();
                list.Add($"value {typeName}");
            }
        }

        [Benchmark]
        public void TypeOfToString()
        {
            var list = new List<string>(Ops);
            for (int i = 0; i < Ops; i++)
            {
                var typeName = typeof(CostOfTypeName).ToString();
                list.Add($"value {typeName}");
            }
        }

        [Benchmark]
        public void TypeOfName()
        {
            var list = new List<string>(Ops);
            for (int i = 0; i < Ops; i++)
            {
                var typeName = typeof(CostOfTypeName).Name;
                list.Add($"value {typeName}");
            }
        }
    }
}