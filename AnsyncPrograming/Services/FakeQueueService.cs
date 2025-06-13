namespace IngoProject.AsyncProgramming.Services
{
    public class FakeQueueService
    {
        private int _nextTransactionId = 1;
        private readonly Random _random = new();
        public (int id, decimal amount) GetNextTransaction()
        {
            // Simula a obtenção de um próximo usuário e valor de transação
            int id = _nextTransactionId++;
            decimal amount = _random.Next(50, 500); // Valor aleatório entre 50 e 500
            return (id, amount);
        }

        // Simulate getting the next withdrawal request
        public (int id, decimal amount) GetNextWithdrawal()
        {
            // For demonstration, return random values
            var random = new Random();
            int id = random.Next(1, 4); // Example user IDs: 1, 2, or 3
            decimal amount = random.Next(10, 500);
            return (id, amount);
        }
    }
}
