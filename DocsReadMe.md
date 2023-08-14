# ToAnother

**Description**

Convert input enum to another enum.

**Signature**

TAnotherEnum ToAnother<TAnotherEnum>(this Enum, bool [default = true]) where TAnotherEnum : Enum

**Code examples**
```csharp
// Enums
public enum AnotherEnum { First, Second, Third }

public enum InputEnum { First, Second, Third }
public enum InputEnumLowerCase { first, second, third }
public enum InputEnumUpperCase { FIRST, SECOND, THIRD }

// Input enums
InputEnum first = InputEnum.First;
InputEnumLowerCase second = InputEnumLowerCase.second;
InputEnumUpperCase third = InputEnumUpperCase.THIRD;
```

```csharp
AnotherEnum anotherEnumFirst = first.ToAnother<AnotherEnum>();
AnotherEnum anotherEnumSecond = second.ToAnother<AnotherEnum>();
AnotherEnum anotherEnumThird = third.ToAnother<AnotherEnum>(true); // true by default

// Output:
// anotherEnumFirst - First
// anotherEnumSecond - Second
// anotherEnumThird - Third
```

```csharp
AnotherEnum anotherEnumFirst = first.ToAnother<AnotherEnum>(false);
AnotherEnum anotherEnumSecond = second.ToAnother<AnotherEnum>(false);
AnotherEnum anotherEnumThird = third.ToAnother<AnotherEnum>(false);

// Output:
// anotherEnumFirst - First
// anotherEnumSecond - Throws ArgumentException
// anotherEnumThird - Throws ArgumentException
```

# TryToAnother

**Description**

Try convert input enum to another enum.

**Signature**

bool TryToAnother(this Enum, bool [default = true], out TAnotherEnum) where TAnotherEnum : struct

**Code examples**

```csharp
// Enums
public enum AnotherEnum { First, Second, Third }

public enum InputEnum { First, Second, Third }
public enum InputEnumLowerCase { first, second, third }
public enum InputEnumUpperCase { FIRST, SECOND, THIRD }

public enum InvalidEnum { FirstInvalidValue, SecondInvalidValue }

// Input enums
InputEnum first = InputEnum.First;
InputEnumLowerCase second = InputEnumLowerCase.second;
InputEnumUpperCase third = InputEnumUpperCase.THIRD;
InvalidEnum invalidSecondValue = InvalidEnum.SecondInvalidValue;
```

```csharp
bool isConvertedFirst = first.TryToAnother(out AnotherEnum anotherEnumFirst);
bool isConvertedSecond = second.TryToAnother(out AnotherEnum anotherEnumSecond);
bool isConvertedThird = third.TryToAnother(true, out AnotherEnum anotherEnumThird); // true by default

// Output:
// [isConvertedFirst, anotherEnumFirst] - [true, First]
// [isConvertedSecond, anotherEnumSecond] - [true, Second]
// [isConvertedThird, anotherEnumThird] - [true, Third]
```

```csharp
bool isConvertedFirst = first.TryToAnother(false, out AnotherEnum anotherEnumFirst);
bool isConvertedSecond = second.TryToAnother(false, out AnotherEnum anotherEnumSecond);
bool isConvertedThird = third.TryToAnother(false, out AnotherEnum anotherEnumThird);

// Output:
// [isConvertedFirst, anotherEnumFirst] - [true, First]
// [isConvertedSecond, anotherEnumSecond] - [false, First]
// [isConvertedThird, anotherEnumThird] - [false, First]
```

```csharp
bool isConverted = invalidSecondValue.TryToAnother(out AnotherEnum anotherEnum);

// Output:
// [isConverted, anotherEnum] - [false, First]
```
