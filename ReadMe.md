<div align="center">
 <img src="icon.png" weight="100px" height="100" />
 <h2>EnumConverter</h2>
 

 [![NuGet](https://img.shields.io/nuget/v/Kurnakov.EnumConverter.svg)](https://www.nuget.org/packages/Kurnakov.EnumConverter)
 [![NuGet download](https://img.shields.io/nuget/dt/Kurnakov.EnumConverter.svg)](https://www.nuget.org/packages/Kurnakov.EnumConverter) 
 ![Visitors](https://api.visitorbadge.io/api/visitors?path=https%3A%2F%2Fgithub.com%kurnakovv%EnumConverter&countColor=%23263759&style=flat)
 [![Build/Test](https://github.com/KurnakovMaksim/EnumConverter/actions/workflows/build-test.yml/badge.svg)](https://github.com/KurnakovMaksim/EnumConverter/actions/workflows/build-test.yml)
[![MIT License](https://img.shields.io/github/license/KurnakovMaksim/EnumConverter?color=%230b0&style=flat)](https://github.com/KurnakovMaksim/EnumConverter/blob/main/LICENSE)
 [![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=kurnakovv_EnumConverter&metric=code_smells)](https://sonarcloud.io/summary/new_code?id=kurnakovv_EnumConverter) [![Coverage](https://sonarcloud.io/api/project_badges/measure?project=kurnakovv_EnumConverter&metric=coverage)](https://sonarcloud.io/summary/new_code?id=kurnakovv_EnumConverter)

</div>

# Description
<b>EnumConverter</b> is a little open source library for converting enums.

# How it works

Enums
``` cs
public enum AnotherEnum { First, Second, Third }

public enum InputEnum { First, Second, Third }
public enum InputEnumLowerCase { first, second, third }
public enum InputEnumUpperCase { FIRST, SECOND, THIRD }
```

Convert enum with ignore case
``` cs
InputEnum first = InputEnum.First;
InputEnumLowerCase second = InputEnumLowerCase.second;
InputEnumUpperCase third = InputEnumUpperCase.THIRD;
           
AnotherEnum anotherEnumFirst = first.ToAnother<AnotherEnum>();
AnotherEnum anotherEnumSecond = second.ToAnother<AnotherEnum>();
AnotherEnum anotherEnumThird = third.ToAnother<AnotherEnum>();

// Output:
// anotherEnumFirst - First
// anotherEnumSecond - Second
// anotherEnumThird - Third
```

Convert enum without ignore case
``` cs
InputEnum first = InputEnum.First;
InputEnumLowerCase second = InputEnumLowerCase.second;
InputEnumUpperCase third = InputEnumUpperCase.THIRD;
           
AnotherEnum anotherEnumFirst = first.ToAnother<AnotherEnum>(false);
AnotherEnum anotherEnumSecond = second.ToAnother<AnotherEnum>(false);
AnotherEnum anotherEnumThird = third.ToAnother<AnotherEnum>(false);

// Output:
// anotherEnumFirst - First
// anotherEnumSecond - Throws ArgumentException
// anotherEnumThird - Throws ArgumentException
```

Convert string -> enum
``` cs
string validFirstValue = "First";
string validSecondWithIgnoreCase = "second";
string invalidValue = "InvalidValue";

MyEnum validFirstEnum = validFirstValue.ToEnum<MyEnum>();
MyEnum validSecondEnum = validSecondWithIgnoreCase.ToEnum<MyEnum>();
MyEnum invalidSecondEnum = validSecondWithIgnoreCase.ToEnum<MyEnum>(false);
MyEnum invalidEnum = invalidValue.ToEnum<MyEnum>();

// Output:
// validFirstEnum - MyEnum.First
// validSecondEnum - MyEnum.Second
// invalidSecondEnum - Throws ArgumentException
// invalidEnum - Throws ArgumentException
```

Full docs [here](https://github.com/kurnakovv/EnumConverter/blob/main/DocsReadMe.md)

# Reason
I always forget how to convert enum, so I created this library for convenience

# Give a star ⭐
I hope this library is useful for you, if so, please give this repository a star, thank you :)
