 [![NuGet](https://img.shields.io/nuget/v/Kurnakov.EnumConverter.svg)](https://www.nuget.org/packages/Kurnakov.EnumConverter)
 [![NuGet download](https://img.shields.io/nuget/dt/Kurnakov.EnumConverter.svg)](https://www.nuget.org/packages/Kurnakov.EnumConverter) 
 [![Build/Test](https://github.com/KurnakovMaksim/EnumConverter/actions/workflows/build-test.yml/badge.svg)](https://github.com/KurnakovMaksim/EnumConverter/actions/workflows/build-test.yml)
[![MIT License](https://img.shields.io/github/license/KurnakovMaksim/EnumConverter?color=%230b0&style=flat)](https://github.com/KurnakovMaksim/EnumConverter/blob/main/LICENSE)

# Description
EnumConverter is a little open source library for convert enum to another

# How is it work

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

# Reason
I always forget how to convert enum to another and I create this library for convenience

# Give a star ⭐
I hope this library is useful for you, if so please give a star for this repository, thank you :)
