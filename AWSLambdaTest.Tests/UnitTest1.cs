using Amazon.Lambda.TestUtilities;

namespace AWSLambdaTest.Tests
{
    public class FunctionTests
    {
        [Fact]
        public void TestFunctionHandler_MultiplyByThree()
        {
            // Arrange
            var function = new Function();
            var input = new Function.Input
            {
                Number = 5
            };
            var context = new TestLambdaContext(); // Mock context provided by Lambda TestUtilities

            // Act
            var result = function.FunctionHandler(input, context);

            // Assert
            Assert.Equal(30, result.Result);
        }

        [Theory]
        [InlineData(1, 6)]
        [InlineData(0, 0)]
        [InlineData(-4, -24)]
        [InlineData(-5, -30)]
        public void TestFunctionHandler_MultipleCases(int inputNumber, int expectedResult)
        {
            // Arrange
            var function = new Function();
            var input = new Function.Input
            {
                Number = inputNumber
            };
            var context = new TestLambdaContext(); // Mock context provided by Lambda TestUtilities

            // Act
            var result = function.FunctionHandler(input, context);

            // Assert
            Assert.Equal(expectedResult, result.Result);
        }
    }
}
