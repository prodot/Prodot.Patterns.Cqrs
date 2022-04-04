# Prodot.Patterns.Cqrs

![Nuget](https://img.shields.io/nuget/v/Prodot.Patterns.Cqrs)
[![Build](https://github.com/prodot/Prodot.Patterns.Cqrs/actions/workflows/build-and-release.yml/badge.svg?branch=main)](https://github.com/prodot/Prodot.Patterns.Cqrs/actions/workflows/build-and-release.yml)

## Introduction

Prodot.Patterns.Cqrs is a set of libraries that aim to ease the implementation of a CQRS data access and logic pattern.
In it's implementation details, it is similar to a Mediator pattern or the request processing pipeline of ASP.Net Core.

## Getting Started

1. Install the packages
    - For Query-only projects, install the [Prodot.Patterns.Cqrs.Abstractions]() NuGet package. For your application project, use [Prodot.Patterns.Cqrs]()
2. Define your queries
    - Define your queries and commands using the `IQuery<TResult, TSelf>` and `Command<TSelf>` types.
3. Implement your query handlers
    - Implement your query handlers using the `IQueryHandler<TQuery, TResult>` and (if required) `IConfigurableQueryHandler<TConfiguration>` interfaces.
      - If you want to enable CRUD-style queries using EF Core, you can use the base classes from Prodot.Patterns.Cqrs.EfCore (and the query base classes from Prodot.Patterns.Cqrs.EfCore.Abstractions)
4. Register the pipelines
    - Register your pipelines using `IPipelineProfile` and `PipelineBuilder`.
5. Use the query processor
    - Implement `IQueryHandlerFactory` specific to your DI container. Use that and `QueryHandlerRegistry` to create a `QueryProcessor`.
      - If you are using `Microsoft.Extensions.DependencyInjection.ServiceCollection`, there is a ready-to-use implementation in Prodot.patterns.Cqrs.MicrosoftExtensionsDependencyInjection
    - Use the `IQueryProcessor` to run your queries

## Build and Test

The solution contained within this repository can be built and tested from within Visual Studio 2022 or later.

## Contribute

If you want to contribute, feel free to reach out to [Tim Vinkemeier](mailto:timvinkemeier@prodot.de) :)
