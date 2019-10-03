using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Deo.DataStructureBenchmarks
{
    public class StringlyVsStronglyTyped
    {
        [Params(128, 256, 512)]
        public int Reads;

        QueriedObject Subject;

        [GlobalSetup]
        public void Setup()
        {
            Subject = new QueriedObject();
        }

        [Benchmark]
        public void StringlyTyped()
        {
            for (int i = 0; i < Reads; i++)
            {
                var got1 = Subject.TryGetValue(nameof(Subject.Value1), out var v1);
                var got2 = Subject.TryGetValue(nameof(Subject.Value2), out var v2);
                var got3 = Subject.TryGetValue(nameof(Subject.Value3), out var v3);
                var got4 = Subject.TryGetValue(nameof(Subject.Value4), out var v4);
            }
        }

        [Benchmark]
        public void StringlyTypedWithCast()
        {
            for (int i = 0; i < Reads; i++)
            {
                var got1 = Subject.TryGetValue(nameof(Subject.Value1), out var v1);
                var got2 = Subject.TryGetValue(nameof(Subject.Value2), out var v2);
                var got3 = Subject.TryGetValue(nameof(Subject.Value3), out var v3);
                var got4 = Subject.TryGetValue(nameof(Subject.Value4), out var v4);

                string s1 = (string)v1;
                int s2 = (int)v2;
                DateTime s3 = (DateTime)v3;
                object s4 = v4;
            }
        }

        [Benchmark]
        public void StronglyTyped()
        {
            for (int i = 0; i < Reads; i++)
            {
                var v1 = Subject.Value1;
                var v2 = Subject.Value2;
                var v3 = Subject.Value3;
                var v4 = Subject.Value4;
            }
        }

        private class QueriedObject
        {
            internal string Value1 = "sample";
            internal int Value2 = 32;
            internal DateTime Value3 = DateTime.Now;
            internal object Value4 = null;

            internal bool TryGetValue(string key, out object value)
            {
                switch (key)
                {
                    case nameof(Value1):
                        value = Value1;
                        return true;
                    case nameof(Value2):
                        value = Value2;
                        return true;
                    case nameof(Value3):
                        value = Value3;
                        return true;
                    case nameof(Value4):
                        value = Value4;
                        return true;
                    default:
                        value = null;
                        return false;
                }
            }
        }
    }
}