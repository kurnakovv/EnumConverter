using EnumConverterLibrary.UnitTests.TestEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace EnumConverterLibrary.UnitTests
{
    public class EnumConverterTest
    {
        [Fact]
        public void ToAnother_CanConvertInputEnumToAnotherEnum_AnotherEnum()
        {
            // Arrange.
            InputEnum inputEnumFirst = InputEnum.First;
            InputEnum inputEnumSecond = InputEnum.Second;
            InputEnum inputEnumThird = InputEnum.Third;

            // Act.
            AnotherEnum anotherEnumFirst = inputEnumFirst.ToAnother<AnotherEnum>();
            AnotherEnum anotherEnumSecond = inputEnumSecond.ToAnother<AnotherEnum>();
            AnotherEnum anotherEnumThird = inputEnumThird.ToAnother<AnotherEnum>();

            // Assert.
            Assert.IsType<AnotherEnum>(anotherEnumFirst);
            Assert.IsType<AnotherEnum>(anotherEnumSecond);
            Assert.IsType<AnotherEnum>(anotherEnumThird);

            Assert.Equal(AnotherEnum.First, anotherEnumFirst);
            Assert.Equal(AnotherEnum.Second, anotherEnumSecond);
            Assert.Equal(AnotherEnum.Third, anotherEnumThird);
        }

        [Fact]
        public void ToAnother_CanConvertInputEnumToAnotherEnumWithIgnoreCase_AnotherEnum()
        {
            // Arrange.
            InputEnumLowerCase inputEnum_first = InputEnumLowerCase.first;
            InputEnumLowerCase inputEnum_second = InputEnumLowerCase.second;
            InputEnumLowerCase inputEnum_third = InputEnumLowerCase.third;

            InputEnumUpperCase inputEnumFIRST = InputEnumUpperCase.FIRST;
            InputEnumUpperCase inputEnumSECOND = InputEnumUpperCase.SECOND;
            InputEnumUpperCase inputEnumTHIRD = InputEnumUpperCase.THIRD;

            // Act.
            AnotherEnum anotherEnumFirstLowerCase = inputEnum_first.ToAnother<AnotherEnum>();
            AnotherEnum anotherEnumSecondLowerCase = inputEnum_second.ToAnother<AnotherEnum>();
            AnotherEnum anotherEnumThirdLowerCase = inputEnum_third.ToAnother<AnotherEnum>();
            
            AnotherEnum anotherEnumFirstUpperCase = inputEnumFIRST.ToAnother<AnotherEnum>();
            AnotherEnum anotherEnumSecondUpperCase = inputEnumSECOND.ToAnother<AnotherEnum>();
            AnotherEnum anotherEnumThirdUpperCase = inputEnumTHIRD.ToAnother<AnotherEnum>();

            // Assert.
            Assert.Equal(AnotherEnum.First, anotherEnumFirstLowerCase);
            Assert.Equal(AnotherEnum.Second, anotherEnumSecondLowerCase);
            Assert.Equal(AnotherEnum.Third, anotherEnumThirdLowerCase);
            
            Assert.Equal(AnotherEnum.First, anotherEnumFirstUpperCase);
            Assert.Equal(AnotherEnum.Second, anotherEnumSecondUpperCase);
            Assert.Equal(AnotherEnum.Third, anotherEnumThirdUpperCase);
        }

        [Fact]
        public void ToAnother_CanConvertInputEnumToAnotherEnumWithIgnoreCaseEqualsFalse_AnotherEnum()
        {
            // Arrange.
            InputEnum inputEnumFirst = InputEnum.First;
            InputEnum inputEnumSecond = InputEnum.Second;
            InputEnum inputEnumThird = InputEnum.Third;

            // Act.
            AnotherEnum anotherEnumFirst = inputEnumFirst.ToAnother<AnotherEnum>(false);
            AnotherEnum anotherEnumSecond = inputEnumSecond.ToAnother<AnotherEnum>(false);
            AnotherEnum anotherEnumThird = inputEnumThird.ToAnother<AnotherEnum>(false);

            // Assert.
            Assert.IsType<AnotherEnum>(anotherEnumFirst);
            Assert.IsType<AnotherEnum>(anotherEnumSecond);
            Assert.IsType<AnotherEnum>(anotherEnumThird);

            Assert.Equal(AnotherEnum.First, anotherEnumFirst);
            Assert.Equal(AnotherEnum.Second, anotherEnumSecond);
            Assert.Equal(AnotherEnum.Third, anotherEnumThird);
        }

        [Fact]
        public void ToAnother_CannotConvertInputEnumToAnotherEnumWithIgnoreCaseEqualsFalse_ArgumentException()
        {
            // Arrange.
            InputEnumUpperCase inputEnumFirst = InputEnumUpperCase.FIRST;
            InputEnumUpperCase inputEnumSecond = InputEnumUpperCase.SECOND;
            InputEnumUpperCase inputEnumThird = InputEnumUpperCase.THIRD;

            // Assert.
            Assert.Throws<ArgumentException>(() => { inputEnumFirst.ToAnother<AnotherEnum>(false); });
            Assert.Throws<ArgumentException>(() => { inputEnumSecond.ToAnother<AnotherEnum>(false); });
            Assert.Throws<ArgumentException>(() => { inputEnumThird.ToAnother<AnotherEnum>(false); });
        }

        [Fact]
        public void TryToAnother_CanConvertInputEnumToAnotherEnum_TrueAndAnotherEnum()
        {
            // Arrange.
            InputEnum inputEnumFirst = InputEnum.First;
            InputEnum inputEnumSecond = InputEnum.Second;
            InputEnum inputEnumThird = InputEnum.Third;

            // Act.
            bool isConvertedFirst = inputEnumFirst.TryToAnother(out AnotherEnum anotherEnumFirst);
            bool isConvertedSecond = inputEnumSecond.TryToAnother(out AnotherEnum anotherEnumSecond);
            bool isConvertedThird = inputEnumThird.TryToAnother(out AnotherEnum anotherEnumThird);

            // Assert.
            Assert.True(isConvertedFirst);
            Assert.True(isConvertedSecond);
            Assert.True(isConvertedThird);

            Assert.IsType<AnotherEnum>(anotherEnumFirst);
            Assert.IsType<AnotherEnum>(anotherEnumSecond);
            Assert.IsType<AnotherEnum>(anotherEnumThird);

            Assert.Equal(AnotherEnum.First, anotherEnumFirst);
            Assert.Equal(AnotherEnum.Second, anotherEnumSecond);
            Assert.Equal(AnotherEnum.Third, anotherEnumThird);
        }

        [Fact]
        public void TryToAnother_CanConvertInputEnumToAnotherEnumWithIgnoreCase_TrueAndAnotherEnum()
        {
            // Arrange.
            InputEnumLowerCase inputEnum_first = InputEnumLowerCase.first;
            InputEnumLowerCase inputEnum_second = InputEnumLowerCase.second;
            InputEnumLowerCase inputEnum_third = InputEnumLowerCase.third;

            InputEnumUpperCase inputEnumFIRST = InputEnumUpperCase.FIRST;
            InputEnumUpperCase inputEnumSECOND = InputEnumUpperCase.SECOND;
            InputEnumUpperCase inputEnumTHIRD = InputEnumUpperCase.THIRD;

            // Act.
            bool isConvertedFirstLowerCase = inputEnum_first.TryToAnother(true, out AnotherEnum anotherEnumFirstLowerCase);
            bool isConvertedSecondLowerCase = inputEnum_second.TryToAnother(true, out AnotherEnum anotherEnumSecondLowerCase);
            bool isConvertedThirdLowerCase = inputEnum_third.TryToAnother(true, out AnotherEnum anotherEnumThirdLowerCase);

            bool isConvertedFirstUpperCase = inputEnumFIRST.TryToAnother(true, out AnotherEnum anotherEnumFirstUpperCase);
            bool isConvertedSecondUpperCase = inputEnumSECOND.TryToAnother(true, out AnotherEnum anotherEnumSecondUpperCase);
            bool isConvertedThirdUpperCase = inputEnumTHIRD.TryToAnother(true, out AnotherEnum anotherEnumThirdUpperCase);

            // Assert.
            Assert.True(isConvertedFirstLowerCase);
            Assert.True(isConvertedSecondLowerCase);
            Assert.True(isConvertedThirdLowerCase);
            Assert.Equal(AnotherEnum.First, anotherEnumFirstLowerCase);
            Assert.Equal(AnotherEnum.Second, anotherEnumSecondLowerCase);
            Assert.Equal(AnotherEnum.Third, anotherEnumThirdLowerCase);

            Assert.True(isConvertedFirstUpperCase);
            Assert.True(isConvertedSecondUpperCase);
            Assert.True(isConvertedThirdUpperCase);
            Assert.Equal(AnotherEnum.First, anotherEnumFirstUpperCase);
            Assert.Equal(AnotherEnum.Second, anotherEnumSecondUpperCase);
            Assert.Equal(AnotherEnum.Third, anotherEnumThirdUpperCase);
        }

        [Fact]
        public void TryToAnother_CanConvertInputEnumToAnotherEnumWithIgnoreCaseEqualsFalse_TrueAndAnotherEnum()
        {
            // Arrange.
            InputEnum inputEnumFirst = InputEnum.First;
            InputEnum inputEnumSecond = InputEnum.Second;
            InputEnum inputEnumThird = InputEnum.Third;

            // Act.
            bool isConvertedFirst = inputEnumFirst.TryToAnother(false, out AnotherEnum anotherEnumFirst);
            bool isConvertedSecond = inputEnumSecond.TryToAnother(false, out AnotherEnum anotherEnumSecond);
            bool isConvertedThird = inputEnumThird.TryToAnother(false, out AnotherEnum anotherEnumThird);

            // Assert.
            Assert.True(isConvertedFirst);
            Assert.True(isConvertedSecond);
            Assert.True(isConvertedThird);

            Assert.IsType<AnotherEnum>(anotherEnumFirst);
            Assert.IsType<AnotherEnum>(anotherEnumSecond);
            Assert.IsType<AnotherEnum>(anotherEnumThird);

            Assert.Equal(AnotherEnum.First, anotherEnumFirst);
            Assert.Equal(AnotherEnum.Second, anotherEnumSecond);
            Assert.Equal(AnotherEnum.Third, anotherEnumThird);
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

        [Fact]
        public void ToAnotherOrDefault_CanConvertInputEnumToAnother_AnotherEnum()
        {
            // Arrange.
            InputEnum inputEnumFirst = InputEnum.First;
            InputEnum inputEnumSecond = InputEnum.Second;
            InputEnum inputEnumThird = InputEnum.Third;

            // Act.
            AnotherEnum anotherEnumFirst = inputEnumFirst.ToAnotherOrDefault<AnotherEnum>();
            AnotherEnum anotherEnumSecond = inputEnumSecond.ToAnotherOrDefault<AnotherEnum>();
            AnotherEnum anotherEnumThird = inputEnumThird.ToAnotherOrDefault<AnotherEnum>();

            // Assert.
            Assert.IsType<AnotherEnum>(anotherEnumFirst);
            Assert.IsType<AnotherEnum>(anotherEnumSecond);
            Assert.IsType<AnotherEnum>(anotherEnumThird);

            Assert.Equal(AnotherEnum.First, anotherEnumFirst);
            Assert.Equal(AnotherEnum.Second, anotherEnumSecond);
            Assert.Equal(AnotherEnum.Third, anotherEnumThird);
        }

        [Fact]
        public void ToAnotherOrDefault_CannotConvertInvalidEnum_DefaultEnumValue()
        {
            // Arrange.
            InvalidEnum invalidSecondValue = InvalidEnum.SecondInvalidValue;

            // Act.
            AnotherEnum anotherEnum = invalidSecondValue.ToAnotherOrDefault<AnotherEnum>();

            // Assert.
            Assert.IsType<AnotherEnum>(anotherEnum);
            Assert.Equal(default(AnotherEnum), anotherEnum);
        }

        [Fact]
        public void ToAnotherOrDefault_CanConvertInputEnumToAnotherEnumWithIgnoreCaseEqualsFalse_AnotherEnum()
        {
            // Arrange.
            InputEnum inputEnumFirst = InputEnum.First;
            InputEnum inputEnumSecond = InputEnum.Second;
            InputEnum inputEnumThird = InputEnum.Third;

            // Act.
            AnotherEnum anotherEnumFirst = inputEnumFirst.ToAnotherOrDefault<AnotherEnum>(false);
            AnotherEnum anotherEnumSecond = inputEnumSecond.ToAnotherOrDefault<AnotherEnum>(false);
            AnotherEnum anotherEnumThird = inputEnumThird.ToAnotherOrDefault<AnotherEnum>(false);

            // Assert.
            Assert.IsType<AnotherEnum>(anotherEnumFirst);
            Assert.IsType<AnotherEnum>(anotherEnumSecond);
            Assert.IsType<AnotherEnum>(anotherEnumThird);

            Assert.Equal(AnotherEnum.First, anotherEnumFirst);
            Assert.Equal(AnotherEnum.Second, anotherEnumSecond);
            Assert.Equal(AnotherEnum.Third, anotherEnumThird);
        }

        [Fact]
        public void ToOther_CanConvertInputEnumsToOtherEnums_OtherEnums()
        {
            IEnumerable<InputEnum> inputEnums = new List<InputEnum>()
            {
                InputEnum.First, InputEnum.Second, InputEnum.Third,
            };

            List<AnotherEnum> result = inputEnums.ToOther<InputEnum, AnotherEnum>().ToList();

            Assert.Equal(AnotherEnum.First, result[0]);
            Assert.Equal(AnotherEnum.Second, result[1]);
            Assert.Equal(AnotherEnum.Third, result[2]);
        }

        [Fact]
        public void ToOther_CanConvertInputEnumsToOtherEnumsWithIgnoreCaseEqualsFalse_OtherEnums()
        {
            IEnumerable<InputEnum> inputEnums = new List<InputEnum>()
            {
                InputEnum.First, InputEnum.Second, InputEnum.Third,
            };

            List<AnotherEnum> result = inputEnums.ToOther<InputEnum, AnotherEnum>(false).ToList();

            Assert.Equal(AnotherEnum.First, result[0]);
            Assert.Equal(AnotherEnum.Second, result[1]);
            Assert.Equal(AnotherEnum.Third, result[2]);
        }

        [Fact]
        public void ToEnum_CanConvertStringToEnum_MyEnum()
        {
            // Arrange.
            string firstValue = "First";
            string secondValue = "Second";
            string thirdValue = "Third";

            string firstValueWithIgnoreCase = "FIRST";
            string secondValueWithIgnoreCase = "second";
            string thirdValueWithIgnoreCase = "ThIrD";

            // Act.
            MyEnum myEnumFirstValue = firstValue.ToEnum<MyEnum>();
            MyEnum myEnumSecondValue = secondValue.ToEnum<MyEnum>();
            MyEnum myEnumThirdValue = thirdValue.ToEnum<MyEnum>();

            MyEnum myEnumFirstValueWithIgnoreCase = firstValueWithIgnoreCase.ToEnum<MyEnum>();
            MyEnum myEnumSecondValueWithIgnoreCase = secondValueWithIgnoreCase.ToEnum<MyEnum>();
            MyEnum myEnumThirdValueWithIgnoreCase = thirdValueWithIgnoreCase.ToEnum<MyEnum>();

            // Assert.
            Assert.IsType<MyEnum>(myEnumFirstValue);
            Assert.IsType<MyEnum>(myEnumSecondValue);
            Assert.IsType<MyEnum>(myEnumThirdValue);
            Assert.Equal(MyEnum.First, myEnumFirstValue);
            Assert.Equal(MyEnum.Second, myEnumSecondValue);
            Assert.Equal(MyEnum.Third, myEnumThirdValue);

            Assert.IsType<MyEnum>(myEnumFirstValueWithIgnoreCase);
            Assert.IsType<MyEnum>(myEnumSecondValueWithIgnoreCase);
            Assert.IsType<MyEnum>(myEnumThirdValueWithIgnoreCase);
            Assert.Equal(MyEnum.First, myEnumFirstValueWithIgnoreCase);
            Assert.Equal(MyEnum.Second, myEnumSecondValueWithIgnoreCase);
            Assert.Equal(MyEnum.Third, myEnumThirdValueWithIgnoreCase);
        }

        [Fact]
        public void ToEnum_CannotConvertValidStringWithIgnoreCaseIfIgnoreCaseEqualsFalse_ArgumentException()
        {
            // Arrange.
            string firstValueWithIgnoreCase = "FIRST";
            string secondValueWithIgnoreCase = "second";
            string thirdValueWithIgnoreCase = "ThIrD";

            // Assert.
            Assert.Throws<ArgumentException>(() => firstValueWithIgnoreCase.ToEnum<MyEnum>(false));
            Assert.Throws<ArgumentException>(() => secondValueWithIgnoreCase.ToEnum<MyEnum>(false));
            Assert.Throws<ArgumentException>(() => thirdValueWithIgnoreCase.ToEnum<MyEnum>(false));
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
    }
}
