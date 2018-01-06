# BenchmarkDotNet Results

``` ini

BenchmarkDotNet=v0.10.11, OS=Windows 10 Redstone 3 [1709, Fall Creators Update] (10.0.16299.125)
Processor=Intel Core i5-4690K CPU 3.50GHz (Haswell), ProcessorCount=4
Frequency=3417974 Hz, Resolution=292.5710 ns, Timer=TSC
  [Host]     : .NET Framework 4.6.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.2600.0
  DefaultJob : .NET Framework 4.6.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.2600.0


```
| Method |         Mean |      Error |     StdDev |
|------- |-------------:|-----------:|-----------:|
|   Safe | 3,081.663 ms | 35.3624 ms | 33.0780 ms |
| Unsafe |     3.586 ms |  0.0112 ms |  0.0105 ms |
