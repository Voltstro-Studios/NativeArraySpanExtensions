# Native Array Span Extensions

[![License](https://img.shields.io/github/license/Voltstro-Studios/NativeArraySpanExtensions.svg)](/LICENSE.md)
[![Discord](https://img.shields.io/badge/Discord-Voltstro-7289da.svg?logo=discord)](https://discord.voltstro.dev)
[![YouTube](https://img.shields.io/badge/Youtube-Voltstro-red.svg?logo=youtube)](https://www.youtube.com/Voltstro)

Provides extensions to Unity's `NativeArray<T>` that make using .NET's Span<T> with them easier.

## Features

- Provides theses extensions to `NativeArray<T>`:
    - `CopyTo` for copying to a `Span<T>`
    - `CopyFrom` for copying from a `ReadOnlySpan<T>`
    - Same extensions are also available for `NativeSlice<T>`
- Provides theses extensions to `Span<T>` and `ReadOnlySpan<T>`:
    - `CopyTo` for copying a span to a `NativeArray<T>`
    - `ToNativeArray` for creating a new `NativeArray<T>` and copying the span's buffer to it

## Getting Started

### Package Installation

#### Prerequisites

```
Unity 2020.3.x
(Unity 2021.3.x is the recommended version however)
```

(Newer Unity versions should be fine as well)

#### Unity 2020.3.x Prerequisites

**IF YOU ARE USING UNITY 2020.3.x WITH THIS PACKAGE, READ THIS**. (Newer versions do not need this step!)

`System.Memory` dll is required (this is where `Span<T>` use to come from). This package it self has no direct dependent installation method for `System.Memory`. You can either install it directly into your Unity project from [NuGet](https://www.nuget.org/packages/System.Memory) (by extracting it from the `.nupkg` file), or via an automatic seamless UPM integration, such as [Voltstro UPM](https://github.com/Voltstro/VoltstroUPM#using-unitynuget-packages), [OpenUPM](https://openupm.com/nuget/), or [UnityNuGet](https://github.com/xoofx/UnityNuGet).

### Installation Methods

There are three main sources on how you can install this package. Pick which ever one suites you the best!

#### Voltstro UPM Registry

You can install this package from our custom UPM registry. To setup our registry,
see [here](https://github.com/Voltstro/VoltstroUPM#setup).

Once you have the registry added to your project, you can install it like any other package via the package manager.

#### OpenUPM

You can install this package via [OpenUPM](https://openupm.com/).

To install it, use their CLI:

```bash
openupm add dev.voltstro.nativearrayspanextensions
```

#### Git

To install it via the package manager with git you will need to:

1. Open up the package manager via Windows **->** Package Manager
2. Click on the little + sign **->** Add package from git URL...
3. Type `https://github.com/Voltstro-Studios/NativeArraySpanExtensions.git` and add it
4. Unity will now download and install the package

## Authors

**Voltstro** - *Initial Work* - [Voltstro](https://github.com/Voltstro)

## License

This project is licensed under the MIT License - see the [LICENSE.md](/LICENSE.md) file for details.
