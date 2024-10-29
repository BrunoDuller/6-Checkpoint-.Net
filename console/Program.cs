using System;
using System.Collections.Generic;

namespace LegacySystem
{
    class MainSystem
    {
        private const string CompanyName = "Empresa Teste";
        private const string TransactionDescription = "Compra de Insumo";
        private const int LoopCount = 5;
        private const int SummationLimit = 10;

        static void Main(string[] args)
        {
            var clientSystem = new ClientSystem();
            clientSystem.AddClient(1, "Joao", "joao@email.com");
            clientSystem.AddClient(2, "Maria", "maria@email.com");

            var transactionSystem = new TransactionSystem();
            transactionSystem.AddTransaction(1, 100.50m, "Compra de Produto");
            transactionSystem.AddTransaction(2, 200.00m, "Compra de Serviço");
            transactionSystem.AddTransaction(3, 300.75m, "Compra de Software");

            clientSystem.DisplayAllClients();
            transactionSystem.DisplayTransactions();

            clientSystem.RemoveClient(1);
            clientSystem.DisplayAllClients();

            clientSystem.UpdateClientName(2, "Maria Silva");

            DisplayCompanyInfo();

            var report = new Report();
            report.GenerateClientReport(clientSystem.Clients);
            report.GenerateDuplicateClientReport(clientSystem.Clients);

            int sumResult = CalculateSummation();
            Console.WriteLine("Total Sum: " + sumResult);

            int duplicatedSumResult = CalculateSummation();
            Console.WriteLine("Duplicated Sum: " + duplicatedSumResult);
        }

        #region Helper Methods
        private static void DisplayCompanyInfo()
        {
            for (int i = 0; i < LoopCount; i++)
            {
                Console.WriteLine($"Company Name: {CompanyName} Description: {TransactionDescription}");
            }
        }

        private static int CalculateSummation()
        {
            int sum = 0;
            for (int i = 0; i < SummationLimit; i++)
            {
                sum += i;
            }
            return sum;
        }
        #endregion
    }
}
