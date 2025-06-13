namespace IngoProject.AsyncProgramming.Models;

public class PJUser : User
{
    public string CNPJ { get; set; }
    public PJUser(int id, string name, string email, string cnpj) : base(id, name, email)
    {
        CNPJ = cnpj;
    }
    public override string GetIdentifier()
    {
        return CNPJ;
    }
    public override void DisplayInfo()
    {
        Console.WriteLine($"ID: {Id}, Name: {Name}, Email: {Email}, CNPJ: {CNPJ}");
    }
}