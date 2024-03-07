using CalculatorLibrary.UnitTest.Helepers;
using Moq;

namespace CalculatorLibrary.UnitTest
{
    public class MathematicsTest : IClassFixture<Mathematics>
    {
        // MethodName_StateUnderTest_ExpectedBehavior
        // MethodName_ExpectedBehavior_StateUnderTest
        // FeatureToBeTested
        // Should_ExpectedBehavior_When_StateUnderTest
        // When_StateUnderTest_Expect_ExpectedBehavior
        // Given_Preconditions_When_StateUnderTest_Then_ExpectedBehavior — Behavior-Driven Development (BDD)

        Mathematics _mathematics;
        public MathematicsTest()
        {
            _mathematics = new Mathematics();
        }

        [Fact]
        public void DivideTest_WithGivenHardCodeNumbers_ShouldThrowsDivideByZeroException()
        {
            // 1 test finished, 1 passed

            #region Arrange
            Mathematics mathematics = new Mathematics();
            var mathematicsMock = new Mock<IMathematics>();
            mathematicsMock.Setup(m => m.Divide(1, 0)).Throws<DivideByZeroException>();
            #endregion 
            #region Assert
            var exception = Assert.Throws<DivideByZeroException>(() => mathematics.Divide(1, 0));
            #endregion
        }

        [Theory]
        [InlineData(3, 5)]
        public void MultiplyTest_WithGivenHardCodeNumbers_UsingConstuctor_ShouldPass(int number1, int number2)
        {
            // 1 test finished, 1 passed

            #region Act
            int result = _mathematics.Multiply(number1, number2);
            #endregion
            #region Assert
            Assert.Equal(15, result);
            #endregion
        }

        [Theory]
        [InlineData(30, 5, 6)]
        public void DivideTest_WithGivenHardCodeNumbers_UsingConstructor_ShouldPass(int number1, int number2, int expected)
        {
            // 1 test finished, 1 passed

            #region Act
            int result = _mathematics.Divide(number1, number2);
            #endregion
            #region Assert
            Assert.Equal(expected, result);
            #endregion
        }

        [Fact]
        public void SubtractTest_WithGivenHardCodeNumbers_ShouldPass()
        {
            // 1 test finished, 1 passed

            #region Arrange
            int number1 = 10;
            int number2 = 20;
            int expected = -10;
            Mathematics mathematics = new Mathematics();
            #endregion
            #region Act
            int result = mathematics.Subtract(number1, number2);
            #endregion
            #region Assert
            Assert.Equal(expected, result);
            #endregion
        }

        [Theory]
        [InlineData(3, 5, 8)]
        public void SumTest_WithOneInlineHardCodeNumbers_ShouldPass(int number1, int number2, int expected)
        {
            // 1 test finished, 1 passed

            #region Arrange
            Mathematics mathematics = new Mathematics();
            #endregion
            #region Act
            int result = mathematics.Sum(number1, number2);
            #endregion
            #region Assert
            Assert.Equal(expected, result);
            #endregion
        }

        [Theory]
        [InlineData(3, 5, 8)]
        [InlineData(11, 5, 16)]
        [InlineData(23, 2, 25)]
        [InlineData(33, 44, 77)]
        public void SumTest_WithMoreInlineHardCodeNumbers_ShouldPass(int number1, int number2, int expected)
        {
            // 4 tests finished, 4 passed

            #region Arrange
            Mathematics mathematics = new Mathematics();
            #endregion
            #region Act
            int result = mathematics.Sum(number1, number2);
            #endregion
            #region Assert
            Assert.Equal(expected, result);
            #endregion
        }

        public static IEnumerable<object[]> sumDatas => new List<object[]> {
            new object[]{ 3, 5, 8 },
            new object[]{ 11, 5, 16 },
            new object[]{ 23, 2, 25 },
            new object[]{ 33, 44, 77 }
        };

        [Theory]
        [MemberData(nameof(sumDatas))]
        public void SumTest_WithMoreMemberDataObjects_OnSameClass_ShouldPass(int number1, int number2, int expected)
        {
            // 4 tests finished, 4 passed

            #region Arrange
            Mathematics mathematics = new Mathematics();
            #endregion
            #region Act
            int result = mathematics.Sum(number1, number2);
            #endregion
            #region Assert
            Assert.Equal(expected, result);
            #endregion
        }

        [Theory]
        [MemberData(nameof(Datas.sumDatas), MemberType = typeof(Datas))]
        public void SumTest_WithMoreMemberDataOnDataObjects_OnDifferentClass_SholudPass(int number1, int number2, int expected)
        {
            // 4 tests finished, 4 passed

            #region Arrange
            Mathematics mathematics = new Mathematics();
            #endregion
            #region Act
            int result = mathematics.Sum(number1, number2);
            #endregion
            #region Assert
            Assert.Equal(expected, result);
            #endregion
        }

        [Theory]
        [MemberData(nameof(Datas.sumDatas), MemberType = typeof(Datas), DisableDiscoveryEnumeration = true)]
        public void SumTest_WithMoreMemberDataOnDataObjects_OnDifferentClassAndDDEProperty_SholudPass(int number1, int number2, int expected)
        {
            // 4 tests finshed, 4 passed; DDE => DisableDiscoveryEnumeration, for getting all tests one result on SE!

            #region Arrange
            Mathematics mathematics = new Mathematics();
            #endregion
            #region Act
            int result = mathematics.Sum(number1, number2);
            #endregion
            #region Assert
            Assert.Equal(expected, result);
            #endregion
        }

        [Fact]
        public void SumTest_WithGivenHardCodeNUmbers_MockSetupUsage_ShouldPass()
        {
            // 1 test finished, 1 passed

            #region Arrange
            var mathematics = new Mock<IMathematics>();
            mathematics.Setup(m => m.Sum(1, 2)).Returns(3);
            #endregion                     
            #region Act
            int result = mathematics.Object.Sum(1, 2);
            #endregion
            #region Assert
            Assert.Equal(3, result);
            #endregion
        }

        [Fact]
        public void SumTest_WithGivenHardCodeNUmbers_MockVerifyUsage_ShouldPass()
        {
            // 1 test finished, 1 passed

            #region Arrange
            var mathematics = new Mock<IMathematics>();
            mathematics.Setup(m => m.Sum(1, 2)).Returns(3);
            #endregion         
            #region Act
            int result = mathematics.Object.Sum(1, 2);
            #endregion
            #region Assert
            Assert.Equal(3, result);
            mathematics.Verify(x => x.Sum(1, 2), Times.AtLeast(1));
            #endregion
        }
    }
}