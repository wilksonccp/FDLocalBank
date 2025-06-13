using IngoProject.AsyncProgramming.Services;
using IngoProject.AsyncProgramming.Models;
using System.Threading;

var logger = new LoggerService();
var account = new BankAccount(50, 500);
var withdrawalService = new WithdrawalService(logger);
var queue = new FakeQueueService();
var cts = new CancellationTokenSource();

Console.CancelKeyPress += (s, e) =>
{
    logger.Log("Cancelamento solicitado. Encerrando o processamento...");
    e.Cancel = true; // Impede o encerramento imediato
    cts.Cancel(); // Solicita o cancelamento do token
};

while (!cts.IsCancellationRequested)
{
    try
    {
        (int userId, decimal amount) = queue.GetNextWithdrawal();
        decimal balance = account.GetBalance();
        if (balance <= 0 || amount > balance)
        {
            logger.Log($"Saldo insuficiente para o usuário {userId}. Saldo atual: R$ {balance}, Tentativa de saque: R$ {amount}.");
            break; // Sai do loop se o saldo for insuficiente
        }
        logger.Log($"Processando saque para o usuário {userId} no valor de R$ {amount}.");

        // Simula o processamento do saque
        await withdrawalService.ProcessWithdrawalAsync(account, amount, cts.Token);
    }
    catch (OperationCanceledException)
    {
        logger.Log("Processamento cancelado.");
        break; // Sai do loop se o processamento for cancelado
    }
    catch (Exception ex)
    {
        logger.Log($"Erro ao processar saque: {ex.Message}");
    }

    // Aguarda um curto período antes de processar a próxima transação
    await Task.Delay(500);
}