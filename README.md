Benchmarks
==

A collection of benchmarks, and a easy starting point to create more

Results so far
===

Strongly typed vs stringly typed access [ns]

| Reads                        | 128          | 256          | 512          | 1024         |
|------------------------------|--------------|--------------|--------------|--------------|
| StringlyTypedWithoutConstKey | 8,829\.86    | 17,188\.90   | 34,674\.17   | 69,441\.99   |
| StringlyTyped                | 9,631\.91    | 17,199\.83   | 35,244\.92   | 69,205\.98   |
| StringlyTypedWithCast        | 9,642\.20    | 18,289\.29   | 35,682\.09   | 72,628\.49   |
| StronglyTyped                | 55\.72       | 100\.9       | 194\.24      | 378\.97      |
| Stringly 1 read              | 75\.3296875  | 71\.44253906 | 69\.69158203 | 70\.92625977 |
| Strongly 1 read              | 0\.4353125   | 0\.394140625 | 0\.379375    | 0\.370087891 |
| Stringly\\Strongly (ratio)   | 173\.0473798 | 181\.2615461 | 183\.70104   | 191\.6470697 |


Diagnostics, time per operation

| Operation    | Time \[ns\] |
|--------------|-------------|
| Baseline     |  0\.21      |
| GetGcCount   |  0\.21      |
| Exception    |  43\.53     |
| StackTrace   |  149\.60    |
| ConsoleWrite |  377\.91    |

Mapping type to a key, time per operation

| Operation       | Time \[ns\] |
|-----------------|-------------|
| Baseline        |  5\.89      |
| GetType         |  6\.01      |
| GetTypeToString | 16\.21     |
