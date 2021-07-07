using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;

namespace Deo.DataStructureBenchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = ManualConfig.Create(DefaultConfig.Instance);
            config.Set(new SummaryStyle()
            {
                PrintUnitsInContent = false,
                PrintUnitsInHeader = true,
            });

            var summary = BenchmarkRunner.Run<WordTokenizer>(config);
            /*
            var x = new WordTokenizer();
            x.Setup();
            x.StringTokenizer();
            x.Setup();
            x.RegexTokenizer();
            x.Setup();
            x.CompiledRegexTokenizer();
            */
        }
    }
}
