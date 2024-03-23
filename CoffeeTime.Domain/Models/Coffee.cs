namespace Domain.Models;

public class Coffee
{
    public Coffee (string name, string code)
    {
        Name = name;
        Code = code;
    }
    public string Name { get; set; }
    public string Code { get; set; }
}