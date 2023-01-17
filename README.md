# Cheerful

[![Codacy Badge](https://app.codacy.com/project/badge/Grade/cb4c3666ba334586b9b6345e99fe0587)](https://www.codacy.com/gh/wuxinheng/Cheerful/dashboard?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=wuxinheng/Cheerful&amp;utm_campaign=Badge_Grade) [![Codacy Badge](https://app.codacy.com/project/badge/Coverage/f9b399fc416a406280836c87ded11b49)](https://www.codacy.com/gh/wuxinheng/Cheerful/dashboard?utm_source=github.com&utm_medium=referral&utm_content=wuxinheng/Cheerful&utm_campaign=Badge_Coverage) [![build](https://github.com/wuxinheng/Cheerful/actions/workflows/build.yml/badge.svg)](https://github.com/wuxinheng/Cheerful/actions/workflows/build.yml) [![release](https://img.shields.io/github/v/release/wuxinheng/Cheerful?include_prereleases)](https://github.com/wuxinheng/Cheerful/releases) [![CodeQL](https://github.com/wuxinheng/Cheerful/actions/workflows/codeql.yml/badge.svg?branch=master)](https://github.com/wuxinheng/Cheerful/actions/workflows/codeql.yml)



## 📦 安装

- 从 Nuget 直接安装
```bash
dotnet add package Cheerful --version xxx
```

## 🌈用法

```C#
public class TestContext
{
    public TestContext(int a, int r)
    {
        A = a;
        R = r;
    }

    public int A { get; set; }
    public int R { get; set; }
}
public class TestPipeLineService1 : PipeLineService<TestContext>
{
    public override void Invoke(TestContext t)
    {
        t.A++;
        NextService?.Invoke(t);
        t.R--;
    }
}
internal class Program
{
    static void Main(string[] args)
    {
        var context = new TestContext(0, 10);
        var pipeLine = new PipeLine<TestContext>();
        pipeLine.Add<TestPipeLineService1>();
        pipeLine.Add<TestPipeLineService1>();
        pipeLine.Add<TestPipeLineService1>();
        pipeLine.Add<TestPipeLineService1>();
        pipeLine.Add<TestPipeLineService1>();
        pipeLine.Add<TestPipeLineService1>();
        pipeLine.Invoke(context);
        Console.WriteLine(context.A); // 6
        Console.WriteLine(context.R); //4
    }
}

```



## :newspaper: 许可证（License）
[![License](https://img.shields.io/github/license/wuxinheng/Cheerful)](https://github.com/wuxinheng/Cheerful/blob/master/LICENSE.txt)
