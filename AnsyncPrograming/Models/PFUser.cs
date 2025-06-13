namespace IngoProject.AsyncProgramming.Models;

public class PFUser : User
{
    public string CPF { get; set; }
    public PFUser(int id, string name, string email, string cpf) : base(id, name, email)
    {
        CPF = cpf;
    }
    public override string GetIdentifier()
    {
        return CPF;
    }
    public override void DisplayInfo()
    {
        Console.WriteLine($"ID: {Id}, Name: {Name}, Email: {Email}, CPF: {CPF}");
    }
}
