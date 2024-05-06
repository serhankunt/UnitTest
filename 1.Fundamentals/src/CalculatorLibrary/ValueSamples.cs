namespace CalculatorLibrary;
public class ValueSamples
{
    public string FullName = "Serhan Kunt";
    public int Age = 27;
    public User user = new()
    {
        FullName = "Serhan Kunt",
        Age = 27,
        DateOfBirth = new(1996, 09, 11)
    };
    public IEnumerable<User> Users = new[]
    {
        new User()
        {
            FullName = "Serhan Kunt",
            Age = 27,
            DateOfBirth = new(1996,09,11)
        },
        new User()
        {
            FullName = "Özge Toksöz",
            Age = 27,
            DateOfBirth = new(1996,06,30)
        }
    };

    public IEnumerable<int> Numbers = new[] { 5, 10, 15, 25, 50 };

    public float Divide(int a,int b)
    {
        if(b == 0)
        {
            throw new DivideByZeroException();
        }
        return a / b;
    }

    public event EventHandler ExampleEvent;
    public virtual void RaiseExampleEvent()
    {
        ExampleEvent(this,EventArgs.Empty);
    }

    internal int InternalSecretNumber = 42;

}

public sealed class User
{
    public string FullName { get; set; } = string.Empty;
    public int Age { get; set; }
    public DateOnly DateOfBirth { get; set; }
}
