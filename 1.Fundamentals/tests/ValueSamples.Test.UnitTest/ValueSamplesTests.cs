namespace ValueSamples.Test.UnitTest;

using CalculatorLibrary;
using FluentAssertions;
using ValueSamples = CalculatorLibrary.ValueSamples;
public class ValueSamplesTests
{
    //Arrange
    private readonly ValueSamples _sut = new();
    [Fact]
    public void StringAssertionExample()
    {
        //Act
        var fullName = _sut.FullName;

        //Assert
        fullName.Should().Be("Taner Saydam");
        fullName.Should().NotBeEmpty();
        fullName.Should().StartWith("Serhan");
        fullName.Should().EndWith("Kunt");
    }
    [Fact]
    public void NumberAssertionExample()
    {
        //Act
        var age = _sut.Age;

        //Assert
        age.Should().Be(27);
        age.Should().BePositive();
        age.Should().BeGreaterThan(20);
        age.Should().BeLessThanOrEqualTo(30);
        age.Should().BeInRange(20, 50);

    }

    [Fact]  
    public void ObjectAssertionExample()
    {
        //Act
        var expectedUser = new User()
        {
            FullName = "Serhan Kunt",
            Age = 27,
            DateOfBirth = new(1996, 09, 11)
        };

        var user = _sut.user;

        user.Should().BeEquivalentTo(expectedUser);



    }


}
