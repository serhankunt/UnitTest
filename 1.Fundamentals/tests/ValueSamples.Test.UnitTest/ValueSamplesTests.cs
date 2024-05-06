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
        fullName.Should().Be("Serhan Kunt");
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
    
    [Fact]
    public void EnumerableObjectAssertionExample()
    {
        //Arrange
        var expected = new User
        {
            FullName = "Serhan Kunt",
            Age = 27,
            DateOfBirth = new(1996, 09, 11)
        };
        //Act
        var users = _sut.Users.As<User[]>();
        //Assert
        users.Should().ContainEquivalentOf(expected);
        users.Should().HaveCount(2);
        users.Should().Contain(x => x.FullName.StartsWith("Serhan") && x.Age > 10);
    }
    [Fact]
    public void EnumerableNumberAssertionExample()
    {
        //Act
        var numbers = _sut.Numbers.As<int[]>();
        //Assert
        numbers.Should().Contain(5);
        //numbers.Should().HaveCount(5);
    }

    [Fact]
    public void ExceptionThrowAssertionExample()
    {
        //act
        Action result = ()=> _sut.Divide(1, 0);

        //Assert
        result.Should().Throw<DivideByZeroException>();
            //.WithMessage("Attempted to divide by zero.");
    }

    [Fact]
    public void EventRaisedAssertionExample()
    {
        //Arrange
        var monitorSubject = _sut.Monitor();// Eventimizi monitörize edip gösterebilmemizi sağlıyor.

        //Act
        _sut.RaiseExampleEvent();

        //Assert
        monitorSubject.Should().Raise("ExampleEvent");
    }

    [Fact]
    public void TestingInternalMembersExample()
    {
        //Act
        var number = _sut.InternalSecretNumber;
        //Assert
        number.Should().Be(42);
    }
}
