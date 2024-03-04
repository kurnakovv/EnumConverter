# ToAnother

**Description**

Convert input enum to another enum.

**Signature**

TAnotherEnum ToAnother<TAnotherEnum>(this Enum, bool [default = true]) where TAnotherEnum : Enum

**Type Parameters**

`TAnotherEnum`  - Enum that we want to get after convert.

**Parameters**

- `Enum enumValue` - Input enum we want to convert to `TAnotherEnum`.
- `bool ignoreCase` - Ignore or regard case.

**Returns**

`TAnotherEnum`

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

# ToOther

**Description**

Convert input enums to other enums.

**Signature**

IEnumerable<TOutputEnum> ToOther<TInputEnum, TOutputEnum>(this IEnumerable<InputEnum>, bool [default = true]) where TInputEnum, TOutputEnum : Enum

**Type Parameters**

`TInputEnum` - Type of `enumValues`
`TOutputEnum` - Enum type that we want to get after convert.

**Parameters**

- `IEnumerable<TInputEnum> enumValues` - The input enums that we want to convert to enumerable of `TOutputEnum`.
- `bool ignoreCase` - Ignore or regard case.

**Returns**

`IEnumerable<TOutputEnum>`

**Code examples**
```csharp
// Enums
public enum InputEnum { First, Second, Third }
public enum OutputEnum { First, Second, Third }
```

```csharp
IEnumerable<InputEnum> inputEnums = new List<InputEnum>()
{
    InputEnum.First, InputEnum.Second, InputEnum.Third,
};
IEnumerable<OutputEnum> output = inputEnums.ToOther<InputEnum, OutputEnum>(true);

// output
// 1 - OutputEnum.First
// 2 - OutputEnum.Second
// 3 - OutputEnum.Third
```

# TryToAnother

**Description**

Try convert input enum to another enum.

**Signature**

bool TryToAnother(this Enum, bool [default = true], out TAnotherEnum) where TAnotherEnum : struct

**Type Parameters**

`TAnotherEnum` - Enum that we want try to get after convert.

**Parameters**

- `Enum enumValue` - Input enum we want try to convert to `TAnotherEnum`.
- `bool ignoreCase` - Ignore or regard case.
- `out TAnotherEnum anotherEnum` - `TAnotherEnum` or default of `TAnotherEnum`.

**Returns**

true if the `enumValue` parameter was converted successfully; otherwise, false.

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
