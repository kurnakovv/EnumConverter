using EnumConverterLibrary.UnitTests.TestEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace EnumConverterLibrary.UnitTests
{
    public class EnumConverterTest
    {
        [Theory]
        [InlineData (InputEnum.First, AnotherEnum.First)]
        [InlineData (InputEnum.Second, AnotherEnum.Second)]
        [InlineData (InputEnum.Third, AnotherEnum.Third)]
        public void ToAnother_CanConvertInputEnumToAnotherEnum_AnotherEnum(
            InputEnum inputEnum, 
            AnotherEnum expectedEnum)
        {
            // Act.
            AnotherEnum anotherEnum = inputEnum.ToAnother<AnotherEnum>();

            // Assert.
            Assert.IsType<AnotherEnum>(anotherEnum);
            Assert.Equal (expectedEnum, anotherEnum);
        }

        [Theory]
        [InlineData (InputEnumLowerCase.first, InputEnumUpperCase.FIRST, AnotherEnum.First)]
        [InlineData (InputEnumLowerCase.second, InputEnumUpperCase.SECOND, AnotherEnum.Second)]
        [InlineData (InputEnumLowerCase.third, InputEnumUpperCase.THIRD, AnotherEnum.Third)]
        public void ToAnother_CanConvertInputEnumToAnotherEnumWithIgnoreCase_AnotherEnum(
            InputEnumLowerCase inputEnumLowerCase, 
            InputEnumUpperCase inputEnumUpperCase, 
            AnotherEnum expectedEnum)
        {
            // Act.
            AnotherEnum anotherEnumLowerCase = inputEnumLowerCase.ToAnother<AnotherEnum>();
            AnotherEnum anotherEnumUpperCase = inputEnumUpperCase.ToAnother<AnotherEnum>();

            // Assert.
            Assert.Equal(expectedEnum, anotherEnumLowerCase);
            Assert.Equal(expectedEnum, anotherEnumUpperCase);
        }

        [Theory]
        [InlineData (InputEnum.First, AnotherEnum.First)]
        [InlineData (InputEnum.Second, AnotherEnum.Second)]
        [InlineData (InputEnum.Third, AnotherEnum.Third)]
        public void ToAnother_CanConvertInputEnumToAnotherEnumWithIgnoreCaseEqualsFalse_AnotherEnum(
            InputEnum inputEnum, 
            AnotherEnum expectedEnum)
        {
            // Act.
            AnotherEnum anotherEnum = inputEnum.ToAnother<AnotherEnum>(false);

            // Assert.
            Assert.IsType<AnotherEnum>(anotherEnum);
            Assert.Equal(expectedEnum, anotherEnum);
        }

        [Theory]
        [InlineData (InputEnumUpperCase.FIRST)]
        [InlineData (InputEnumUpperCase.SECOND)]
        [InlineData (InputEnumUpperCase.THIRD)]
        public void ToAnother_CannotConvertInputEnumToAnotherEnumWithIgnoreCaseEqualsFalse_ArgumentException(
            InputEnumUpperCase inputEnum)
        {
            // Assert.
            Assert.Throws<ArgumentException>(() => { inputEnum.ToAnother<AnotherEnum>(false); });
        }

        [Theory]
        [InlineData (InputEnum.First, AnotherEnum.First)]
        [InlineData (InputEnum.Second, AnotherEnum.Second)]
        [InlineData (InputEnum.Third, AnotherEnum.Third)]
        public void TryToAnother_CanConvertInputEnumToAnotherEnum_TrueAndAnotherEnum(
            InputEnum inputEnum, 
            AnotherEnum expectedEnum)
        {
            // Act.
            bool isConverted = inputEnum.TryToAnother(out AnotherEnum anotherEnum);

            // Assert.
            Assert.True(isConverted);
            Assert.IsType<AnotherEnum>(anotherEnum);
            Assert.Equal(expectedEnum, anotherEnum);
        }

        [Theory]
        [InlineData (InputEnumLowerCase.first, InputEnumUpperCase.FIRST, AnotherEnum.First)]
        [InlineData (InputEnumLowerCase.second, InputEnumUpperCase.SECOND, AnotherEnum.Second)]
        [InlineData (InputEnumLowerCase.third, InputEnumUpperCase.THIRD, AnotherEnum.Third)]
        public void TryToAnother_CanConvertInputEnumToAnotherEnumWithIgnoreCase_TrueAndAnotherEnum(
            InputEnumLowerCase inputEnumLowerCase,
            InputEnumUpperCase inputEnumUpperCase,
            AnotherEnum expectedEnum)
        {
            // Act.
            bool isConvertedLowerCase = inputEnumLowerCase.TryToAnother(true, out AnotherEnum anotherEnumLowerCase);
            bool isConvertedUpperCase = inputEnumUpperCase.TryToAnother(true, out AnotherEnum anotherEnumUpperCase);

            // Assert.
            Assert.True(isConvertedLowerCase);
            Assert.Equal(expectedEnum, anotherEnumLowerCase);

            Assert.True(isConvertedUpperCase);
            Assert.Equal(expectedEnum, anotherEnumUpperCase);
        }

        [Theory]
        [InlineData (InputEnum.First, AnotherEnum.First)]
        [InlineData (InputEnum.Second, AnotherEnum.Second)]
        [InlineData (InputEnum.Third, AnotherEnum.Third)]
        public void TryToAnother_CanConvertInputEnumToAnotherEnumWithIgnoreCaseEqualsFalse_TrueAndAnotherEnum(
            InputEnum inputEnum,
            AnotherEnum expectedEnum)
        {
            // Act.
            bool isConverted = inputEnum.TryToAnother(false, out AnotherEnum anotherEnum);

            // Assert.
            Assert.True(isConverted);
            Assert.IsType<AnotherEnum>(anotherEnum);
            Assert.Equal(expectedEnum, anotherEnum);
        }

        [Fact]
        public void TryToAnother_CannotConvertInvalidEnum_FalseAndDefaultEnumValue()
        {
            // Arrange.
            InvalidEnum invalidSecondValue = InvalidEnum.SecondInvalidValue;

            // Act.
            bool isConverted = invalidSecondValue.TryToAnother(out AnotherEnum anotherEnum);

            // Assert.
            Assert.False(isConverted);
            Assert.IsType<AnotherEnum>(anotherEnum);
            Assert.Equal(default(AnotherEnum), anotherEnum);
        }

        [Theory]
        [InlineData (InputEnum.First, AnotherEnum.First)]
        [InlineData (InputEnum.Second, AnotherEnum.Second)]
        [InlineData (InputEnum.Third, AnotherEnum.Third)]
        public void ToAnotherOrDefault_CanConvertInputEnumToAnother_AnotherEnum(
            InputEnum inputEnum, 
            AnotherEnum expectedEnum)
        {
            // Act.
            AnotherEnum anotherEnum = inputEnum.ToAnotherOrDefault<AnotherEnum>();

            // Assert.
            Assert.IsType<AnotherEnum>(anotherEnum);
            Assert.Equal(expectedEnum, anotherEnum);
        }

        [Fact]
        public void ToAnotherOrDefault_CannotConvertInvalidEnum_DefaultEnumValue()
        {
            // Arrange.
            InvalidEnum invalidSecondValue = InvalidEnum.SecondInvalidValue;
            AnotherEnum customDefaultValue = AnotherEnum.Third;

            // Act.
            AnotherEnum anotherEnum = invalidSecondValue.ToAnotherOrDefault<AnotherEnum>();
            AnotherEnum anotherEnumWithDefaultValue = invalidSecondValue.ToAnotherOrDefault<AnotherEnum>(customDefaultValue);

            // Assert.
            Assert.IsType<AnotherEnum>(anotherEnum);
            Assert.IsType<AnotherEnum>(anotherEnumWithDefaultValue);
            Assert.Equal(default(AnotherEnum), anotherEnum);
            Assert.Equal(customDefaultValue, anotherEnumWithDefaultValue);
        }

        [Theory]
        [InlineData (InputEnum.First, AnotherEnum.First)]
        [InlineData (InputEnum.Second, AnotherEnum.Second)]
        [InlineData (InputEnum.Third, AnotherEnum.Third)]
        public void ToAnotherOrDefault_CanConvertInputEnumToAnotherEnumWithIgnoreCaseEqualsFalse_AnotherEnum(
            InputEnum inputEnum,
            AnotherEnum expectedEnum)
        {
            // Act.
            AnotherEnum anotherEnum = inputEnum.ToAnotherOrDefault<AnotherEnum>(false);

            // Assert.
            Assert.IsType<AnotherEnum>(anotherEnum);
            Assert.Equal(expectedEnum, anotherEnum);
        }

        [Fact]
        public void ToOther_CanConvertInputEnumsToOtherEnums_OtherEnums()
        {
            // Arrange.
            IEnumerable<InputEnum> inputEnums = new List<InputEnum>()
            {
                InputEnum.First, InputEnum.Second, InputEnum.Third,
            };

            // Act.
            List<AnotherEnum> result = inputEnums.ToOther<InputEnum, AnotherEnum>().ToList();

            // Assert.
            Assert.Equal(AnotherEnum.First, result[0]);
            Assert.Equal(AnotherEnum.Second, result[1]);
            Assert.Equal(AnotherEnum.Third, result[2]);
        }

        [Fact]
        public void ToOther_CanConvertInputEnumsToOtherEnumsWithIgnoreCaseEqualsFalse_OtherEnums()
        {
            // Arrange.
            IEnumerable<InputEnum> inputEnums = new List<InputEnum>()
            {
                InputEnum.First, InputEnum.Second, InputEnum.Third,
            };

            // Act.
            List<AnotherEnum> result = inputEnums.ToOther<InputEnum, AnotherEnum>(false).ToList();

            // Assert.
            Assert.Equal(AnotherEnum.First, result[0]);
            Assert.Equal(AnotherEnum.Second, result[1]);
            Assert.Equal(AnotherEnum.Third, result[2]);
        }

        [Theory]
        [InlineData ("First", "FIRST", MyEnum.First)]
        [InlineData ("Second", "second", MyEnum.Second)]
        [InlineData ("Third", "ThIrD", MyEnum.Third)]
        public void ToEnum_CanConvertStringToEnum_MyEnum(
            string inputValue, 
            string inputValueWithIgnoreCase, 
            MyEnum expectedEnum)
        {
            // Act.
            MyEnum myEnum = inputValue.ToEnum<MyEnum>();
            MyEnum myEnumWithIgnoreCase = inputValueWithIgnoreCase.ToEnum<MyEnum>();

            // Assert.
            Assert.IsType<MyEnum>(myEnum);
            Assert.Equal(expectedEnum, myEnum);

            Assert.IsType<MyEnum>(myEnumWithIgnoreCase);
            Assert.Equal(expectedEnum, myEnumWithIgnoreCase);
        }

        [Theory]
        [InlineData ("FIRST")]
        [InlineData ("second")]
        [InlineData ("ThIrD")]
        public void ToEnum_CannotConvertValidStringWithIgnoreCaseIfIgnoreCaseEqualsFalse_ArgumentException(string ValueWithIgnoreCase)
        {
            // Assert.
            Assert.Throws<ArgumentException>(() => ValueWithIgnoreCase.ToEnum<MyEnum>(false));
        }

        [Fact]
        public void ToEnum_CannotConvertInvalidString_ArgumentException()
        {
            // Arrange.
            string invalidValue = "InvalidValue";

            // Assert.
            Assert.Throws<ArgumentException>(() => invalidValue.ToEnum<MyEnum>());
            Assert.Throws<ArgumentException>(() => invalidValue.ToEnum<MyEnum>(false));
        }

        [Theory]
        [InlineData ("First", MyEnum.First)]
        [InlineData ("Second", MyEnum.Second)]
        [InlineData ("Third", MyEnum.Third)]
        public void TryToEnum_CanConvertStringValueToEnum_TrueAndEnum(string stringValue, MyEnum expectedEnum)
        {

            // Act.
            bool isConverted = stringValue.TryToEnum(out MyEnum myEnum);

            // Assert.
            Assert.True(isConverted);
            Assert.IsType<MyEnum>(myEnum);
            Assert.Equal(expectedEnum, myEnum);
        }

        [Theory]
        [InlineData ("first", "FIRST", MyEnum.First)]
        [InlineData ("second", "SECOND", MyEnum.Second)]
        [InlineData ("third", "THIRD", MyEnum.Third)]
        public void TryToEnum_CanConvertStringValueToEnumWithIgnoreCase_TrueAndEnum(
            string stringValueLowerCase,
            string stringValueUpperCase,
            MyEnum expectedEnum)
        {
            // Act.
            bool isConvertedLowerCase = stringValueLowerCase.TryToEnum(true, out MyEnum enumLowerCase);
            bool isConvertedUpperCase = stringValueUpperCase.TryToEnum(true, out MyEnum enumUpperCase);

            // Assert.
            Assert.True(isConvertedLowerCase);
            Assert.Equal(expectedEnum, enumLowerCase);

            Assert.True(isConvertedUpperCase);
            Assert.Equal(expectedEnum, enumUpperCase);

        }

        [Theory]
        [InlineData ("First", MyEnum.First)]
        [InlineData ("Second", MyEnum.Second)]
        [InlineData ("Third", MyEnum.Third)]
        public void TryToEnum_CanConvertStringValueToEnumWithIgnoreCaseEqualsFalse_TrueAndEnum(
            string stringValue,
            MyEnum expectedEnum
        )
        {
            // Act.
            bool isConverted = stringValue.TryToEnum(false, out MyEnum myEnum);

            // Assert.
            Assert.True(isConverted);
            Assert.IsType<MyEnum>(myEnum);
            Assert.Equal(expectedEnum, myEnum);
        }

        [Fact]
        public void TryToEnum_CannotConvertInvalidStringValue_FalseAndDefaultEnumValue()
        {
            // Arrange.
            string invalidValue = "BlaBlaBla";

            // Act.
            bool isConverted = invalidValue.TryToEnum(out MyEnum anotherEnum);

            // Assert.
            Assert.False(isConverted);
            Assert.IsType<MyEnum>(anotherEnum);
            Assert.Equal(default(MyEnum), anotherEnum);
        }

        [Theory]
        [InlineData ("First", MyEnum.First)]
        [InlineData ("Second", MyEnum.Second)]
        [InlineData ("Third", MyEnum.Third)]
        public void ToEnumOrDefault_CanConvertStringValueToEnum_MyEnum(
            string stringValue, 
            MyEnum expectedEnum)
        {
            // Act.
            MyEnum myEnum = stringValue.ToEnumOrDefault<MyEnum>();

            // Assert.
            Assert.IsType<MyEnum>(myEnum);
            Assert.Equal(expectedEnum, myEnum);
        }

        [Theory]
        [InlineData ("First", MyEnum.First)]
        [InlineData ("Second", MyEnum.Second)]
        [InlineData ("Third", MyEnum.Third)]
        public void ToEnumOrDefault_CanConvertStringToEnumWithIgnoreCaseEqualsFalse_MyEnum(
            string stringValue, 
            MyEnum expectedEnum)
        {
            // Act.
            MyEnum myEnum = stringValue.ToEnumOrDefault<MyEnum>(false);

            // Assert.
            Assert.IsType<MyEnum>(myEnum);

            Assert.Equal(expectedEnum, myEnum);
        }

        [Fact]
        public void ToEnumOrDefault_CannotConvertInvalidEnum_DefaultEnumValue()
        {
            // Arrange.
            string stringValueInvalid = "Blablabla";
            MyEnum customDefaultValue = MyEnum.Third;

            // Act.
            MyEnum myEnum = stringValueInvalid.ToEnumOrDefault<MyEnum>();
            MyEnum myEnumWithDefaultValue = stringValueInvalid.ToEnumOrDefault<MyEnum>(customDefaultValue);

            // Assert.
            Assert.IsType<MyEnum>(myEnum);
            Assert.IsType<MyEnum>(myEnumWithDefaultValue);
            Assert.Equal(default(MyEnum), myEnum);
            Assert.Equal(customDefaultValue, myEnumWithDefaultValue);
        }

        [Fact]
        public void ToEnums_CanConvertStringsToEnums_MyEnums()
        {
            IEnumerable<string> values = new List<string>()
            {
                "First", "Second", "Third"
            };

            List<MyEnum> result = values.ToEnums<MyEnum>().ToList();

            Assert.Equal(MyEnum.First, result[0]);
            Assert.Equal(MyEnum.Second, result[1]);
            Assert.Equal(MyEnum.Third, result[2]);
        }

        [Fact]
        public void ToEnums_CanConvertStringsToEnumsWithIgnoreCaseEqualsFalse_MyEnums()
        {
            IEnumerable<string> values = new List<string>()
            {
                "First", "Second", "Third"
            };

            List<MyEnum> result = values.ToEnums<MyEnum>(false).ToList();

            Assert.Equal(MyEnum.First, result[0]);
            Assert.Equal(MyEnum.Second, result[1]);
            Assert.Equal(MyEnum.Third, result[2]);
        }
    }
}
