namespace CalculatorLibrary;
public sealed class ValueSamples
{
    public string FullName = "Serhan Kunt";
    public int Age = 27;
    public User user = new()
    {
        FullName = "Serhan Kunt",
        Age = 27,
        DateOfBirth = new(1996, 09, 11)
    };
}

public sealed class User
{
    public string FullName { get; set; } = string.Empty;
    public int Age { get; set; }
    public DateOnly DateOfBirth { get; set; }
}
