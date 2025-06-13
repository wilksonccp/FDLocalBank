namespace IngoProject.AsyncProgramming.Models;
public abstract class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public BankAccount? account { get; set; }
    public User(int id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
    }
    public virtual string GetIdentifier()
    {
        return Id.ToString();
    }
    public abstract void DisplayInfo();
}