using System.Drawing;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Benchmarking.Helpers;

namespace Benchmarking
{
    public class Benchmarks
    {
        readonly Bitmap _testImage;

        public Benchmarks()
            => _testImage = new Bitmap(@"..\..\Images\test1.png");

        [Benchmark]
        public void Safe()
            => BitmapHelper.ProcessSafe(_testImage);

        [Benchmark]
        public void Unsafe()
            => BitmapHelper.ProcessUnsafe(_testImage);
    }

    public class Program
    {
        public static void Main()
            => BenchmarkRunner.Run<Benchmarks>();
    }
}
