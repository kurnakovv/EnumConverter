using EnumConverter.UnitTests.TestEnums;
using System;
using Xunit;

namespace EnumConverter.UnitTests
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
    }
}
