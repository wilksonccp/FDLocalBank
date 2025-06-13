namespace IngoProject.AsyncProgramming.Services
{
    public class LoggerService
    {
        public void Log(string message)
        {
            Console.WriteLine($"[{DateTime.Now:T}] {message}");
        }
    }
}