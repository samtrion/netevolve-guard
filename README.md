# NetEvolve.Guard

This project is available on NuGet

[![NuGet package](https://img.shields.io/nuget/v/NetEvolve.Guard?label=NetEvolve.Guard)][1]
[![NuGet package](https://img.shields.io/nuget/v/NetEvolve.Guard.Experimental?label=NetEvolve.Guard.Experimental)][2]

Basic input validation via the `Requires` class throws an `ArgumentException`, `ArgumentNullException` or other Exception types. The last parameter `parameterName` is optional and is automatically populated by the .NET Framework, based on the `CallerArgumentExpressionAttribute` functionality.
```csharp
Requires.NotNull(arg1); // Or Requires.NotNull(arg1, nameof(arg1));
Requires.InBetween(arg1, 1, 5); // Or Requires.InBetween(arg1, 1, 5, nameof(arg1));
```

## Experimental Package
This package [`NetEvolve.Guard.Experimental`][2] is based on the new .NET 6 Preview features, such as [`IComparisonOperators`][3] or [`IFloatingPoint`][4]. This replaces the single implementations for numeric type method, this significantly reduced the packet size without loss of functionality.

## Pipeline & Coverage Status

[![Build and Release](https://github.com/samtrion/netevolve-guard/actions/workflows/dotnet.yml/badge.svg?branch=main)](https://github.com/samtrion/netevolve-guard/actions/workflows/dotnet.yml)
[![codecov](https://codecov.io/gh/samtrion/netevolve-guard/branch/main/graph/badge.svg?token=PNI4F6GXL8)](https://codecov.io/gh/samtrion/netevolve-guard)

[1]: https://www.nuget.org/packages/NetEvolve.Guard/ "NetEvolve.Guard NuGet package"
[2]: https://www.nuget.org/packages/NetEvolve.Guard.Experimental/ "NetEvolve.Guard.Experimental NuGet package"
[3]: https://github.com/dotnet/runtime/blob/main/src/libraries/System.Private.CoreLib/src/System/IComparisonOperators.cs "IComparisonOperators Interface"
[4]: https://github.com/dotnet/runtime/blob/main/src/libraries/System.Private.CoreLib/src/System/IFloatingPoint.cs "IFloatingPoint Interface"
