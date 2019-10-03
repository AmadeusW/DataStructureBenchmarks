using BenchmarkDotNet.Running;
using System;

namespace Deo.DataStructureBenchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<StringlyVsStronglyTyped>();
        }
    }
}
