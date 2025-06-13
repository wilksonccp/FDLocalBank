using IngoProject.AsyncProgramming.Models;

namespace IngoProject.AsyncProgramming.Services;


public class WithdrawalService
{
    private readonly LoggerService _logger;

    public WithdrawalService(LoggerService logger)
    {
        _logger = logger;
    }

    public async Task ProcessWithdrawalAsync(BankAccount account, decimal amount, CancellationToken token)
    {
        try
        {

            _logger.Log($"Iniciando saque de R$ {amount} do cliente {account?.AccountId}.");
            await Task.Delay(1000, token); // Simula um atraso de processamento

            if (account != null && account.TryDebit(amount))
            {
                _logger.Log($"Saque de R$ {amount} realizado com sucesso. Saldo atual: R$ {account.GetBalance()}.");
            }
            else
            {
                _logger.Log($"Falha no saque de R$ {amount}. Verifique se o valor é válido e se há saldo suficiente.");
            }
        }
        catch (OperationCanceledException)
        {
            _logger.Log($"Saque cancelado para conta {account?.AccountId}.");
        }
        catch (Exception ex)
        {
            _logger.Log($"Erro ao processar saque: {ex.Message}");
        }
        finally
        {
            _logger.Log("Processamento de saque concluído.");
        }
    }
}
