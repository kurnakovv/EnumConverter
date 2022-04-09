<div align="center">
 <img src="icon.png" weight="100px" height="100" />
 <h2>EnumConverter</h2>

 ![Build .NET 6](https://github.com/KurnakovMaksim/EnumConverter/actions/workflows/build_dotnet_6.yml/badge.svg)

</div>

# Description
<b>EnumConverter</b> is a little open source library for convert enum to another

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