# 说明

* 测试dotnet下带有单元测试的解决方案

## 项目搭建过程

``` bash
dotnet new sln -o UnitTestSolution
cd UnitTestSolution
dotnet new classlib -o MyCalculator
dotnet sln add MyCalculator/MyCalculator.csproj
dotnet new xunit -o MyCalculator.Tests
dotnet sln add MyCalculator.Tests/MyCalculator.Tests.csproj
cd MyCalculator.Tests
dotnet add reference ../MyCalculator/MyCalculator.csproj
cd ..
dotnet test
```

## 相关指令

* `dotnet watch test` 监控文件变化并自动执行测试
