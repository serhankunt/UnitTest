using CalculatorLibrary;
using FluentAssertions;
using Xunit.Abstractions;

namespace TestProject;

public class CalculatorTest : IDisposable , IAsyncLifetime
{
    #region Arrange
    //Arrange
    private readonly Calculator _sut = new();//system under test
    private readonly Guid _guid = Guid.NewGuid();

    private readonly ITestOutputHelper _outputHelper;

    public async Task InitializeAsync()
    {
        _outputHelper.WriteLine("InitializeAsync is working");
        await Task.Delay(1);
    }

    public CalculatorTest(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
        _outputHelper.WriteLine("Constructor is working");
        //Constructor asenkron �al��t�rmaz. Ba�lang��ta asenkron yap� kullanmak istiyorsan InitializeAsync kullanacaks�n.
    }
    [Fact]
    public void Add_ShouldAddTwoNumbers_WhenTwoNumbersAreInteger()
    {
        //Act  
        var result = _sut.Add(2, 7);

        //Assert
        //Assert.Equal(9, result);
        result.Should().Be(9);
        result.Should().NotBe(7);
    }

    [Fact]
    public void Subtract_ShouldSubtractTwoNumbers_WhenTwoNumbersAreInteger()
    {
        //Act
        var result = _sut.Subtract(10, 2);

        //Assert
        //Assert.Equal(8, result);
        //FluentAssertion k�t�phanesi ile bu i�lemler yap�l�yor.
        result.Should().Be(8);
        result.Should().NotBe(7);
    }

    [Fact]
    public void Multiply_ShouldMultiplyTwoNumbers_WhenTwoNumbersAreInteger()
    {
        //Act
        var result = _sut.Multiply(1, 3);

        //Assert
        result.Should().Be(3);
    }

    [Theory]
    [InlineData(6,2,3)]
    [InlineData(18,2,9)]
    [InlineData(0,0,0,Skip ="0/0 i�lemi yap�lamaz")]

    public void Divide_ShouldDivideTwoNumbers_WhenTwoNumbersAreInteger(int a , int b, int expected)
    {
        //Act
        var result = _sut.Divide(a, b);
        //Assert
        result.Should().Be(expected);
    }
    #endregion

    #region Dispose
    public void Dispose()
    {
        _outputHelper.WriteLine("Dispose is working...");
    }

    public async Task DisposeAsync()
    {
        _outputHelper.WriteLine("DisposeAsync is working...");
        await Task.Delay(1);
    }

    #endregion

    #region Test
   
    [Fact(Skip = "Bu metot art�k kullan�lm�yor")]
    public void Test1()
    {
        _outputHelper.WriteLine(_guid.ToString());
    }
    [Fact(Skip = "Bu metot art�k kullan�lm�yor")]
    public void Test2()
    {
        _outputHelper.WriteLine(_guid.ToString());
    }
    #endregion


}