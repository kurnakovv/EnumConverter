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
IEnumerable<OutputEnum> output = inputEnums.ToOther<InputEnum, OutputEnum>(); // or false if case is important.

// output
// 1 - OutputEnum.First
// 2 - OutputEnum.Second
// 3 - OutputEnum.Third
```

# TryToEnum

**Description**

Try convert string value to enum.

**Signature**

bool TryToEnum<TEnum>(this string, bool [default = true] out TEnum) where TEnum : struct, Enum

**Type Parameters**

`TEnum` - Enum that we want try to get after convert.

**Parameters**

- `string stringValue` - Input string we want to convert to `TEnum`.
- `bool ignoreCase` - Ignore or regard case.
- `out TEnum outputEnum` - `TEnum` or default of `TEnum`.

**Returns**

true if the `stringValue` parameter was converted successfully; otherwise, false.

**Code examples**

```csharp
public enum MyEnum { First, Second, Third }
```

```csharp
string stringValueFirst = "First";
string stringValueSecond = "Second";
string stringValueInvalid = "Blablabla";

bool isConvertedFirst = stringValueFirst.TryToEnum(out MyEnum enumFirst);
bool isConvertedSecond = stringValueSecond.TryToEnum(false, out MyEnum enumSecond);
bool isConvertedThird = stringValueInvalid.TryToEnum(out MyEnum enumThird);

// output
// [isConvertedFirst, enumFirst] - [true, MyEnum.First]
// [isConvertedSecond, enumSecond] - [true, MyEnum.Second]
// [isConvertedThird, enumThird] - [false, MyEnum.First]
```

# ToEnums

**Description**

Convert input string to enums.

**Signature**

IEnumerable<TEnum> ToEnums<TEnum>(this IEnumerable<string>, bool [default = true]) where TEnum : Enum

**Type Parameters**

`TEnum` - Enum type that we want to get after convert.

**Parameters**

- `IEnumerable<string> stringValues` - The input string that we want to convert to enumerable of `TEnum`.
- `bool ignoreCase` - Ignore or regard case.

**Returns**

`IEnumerable<TEnum>`

**Code examples**
```csharp
// Enums
public enum MyEnum { First, Second, Third }
```

```csharp
IEnumerable<string> inputEnums = new List<string>()
{
    "First", "Second", "Third",
};
IEnumerable<MyEnum> output = inputEnums.ToEnums<MyEnum>(); // or false if case is important.

// output
// 1 - MyEnum.First
// 2 - MyEnum.Second
// 3 - MyEnum.Third
```

# ToAnotherOrDefault

**Description**

Convert input enum to another enum or default value if not possible.

**Signature**

TAnotherEnum ToAnotherOrDefault<TAnotherEnum>(this Enum, TAnotherEnum = default(TAnotherEnum)) where TAnotherEnum : struct

**Type Parameters**

`TAnotherEnum`  - Enum that we want to get after convert.

**Parameters**

- `Enum enumValue` - Input enum we want to convert to `TAnotherEnum` if possible.
- `TAnotherEnum defaultValue` - default value that will convert to `TAnotherEnum` otherwise.

**Returns**

`TAnotherEnum`

**Code examples**
```csharp
// Enums.
public enum AnotherEnum { First, Second, Third }

public enum InputEnum { First, Second, Third }
public enum InvalidEnum { FirstInvalidValue = 0, SecondInvalidValue = 1, }


// Input enums
InputEnum inputEnumFirst = InputEnum.First;
InvalidEnum invalidSecondValue = InvalidEnum.SecondInvalidValue;
AnotherEnum defaultValue = AnotherEnum.Third;
InputEnum inputEnumThird = InputEnum.Third;
```

```csharp
AnotherEnum anotherEnumFirst = inputEnumFirst.ToAnotherOrDefault<AnotherEnum>();
AnotherEnum anotherEnumSecond = invalidSecondValue.ToAnotherOrDefault<AnotherEnum>();
AnotherEnum anotherEnumWithDefaultValue = invalidSecondValue.ToAnotherOrDefault<AnotherEnum>(defaultValue);
AnotherEnum anotherEnumThird = inputEnumThird.ToAnotherOrDefault<AnotherEnum>(false);

// Output:
// anotherEnumFirst - First
// anotherEnumSecond - default(AnotherEnum)
// anotherEnumWithDefaultValue - defaultValue
// anotherEnumThird - Third
```
