﻿using System;
using TaskEFConsoleApp.Data;
using System.Threading.Tasks;
using TaskEFConsoleApp.Data.Model;
using System.Collections.Generic;
using TaskEFConsoleApp.Data.Model.Base;

namespace TaskEFConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var dbContext = new ApplicationDbContext();
            var dbInitializer = new DbInitializer(dbContext);

            await dbInitializer.InitializeAsync();

            var locationHandler = new LocationQueryHandler(dbContext);
            var displayaHandler = new DisplayQueryHandler(dbContext, new DisplayConsole());

            displayaHandler.ShowData();
            displayaHandler.ShowBalanceByCity();
            displayaHandler.ShowDataViaView();
            displayaHandler.ShowBalanceByCityViaView();

            var displayConsole = new DisplayConsole();
            ICollection<Account> test = new List<Account>();
            displayConsole.Print(test);

            var transfer = new AccountTransaction
            {
                SenderAccountId = 1,
                SenderClientId = 1,
                RecipientAccountId = 2,
                RecipientClientId = 2,
                Sum = 100,
                Operation = Operation.Transfer,
            };

            var put = new AccountTransaction
            {
                SenderAccountId = 1,
                SenderClientId = 1,
                Sum = 100,
                Operation = Operation.Put,
            };

            var withdraw = new AccountTransaction
            {
                SenderAccountId = 3,
                SenderClientId = 3,
                Sum = 150,
                Operation = Operation.Withdraw,
            };

            var transactionHandler = new TransactionQueryHandler(dbContext);

            transactionHandler.Transfer(transfer);
            transactionHandler.Put(put);
            transactionHandler.Withdraw(withdraw);

            Console.ReadLine();
        }
    }
}
