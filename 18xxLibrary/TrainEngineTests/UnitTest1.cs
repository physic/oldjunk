using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainEngineLibrary;
using System.Collections.Generic;

namespace TrainEngineTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestTicTacToeTransaction()
        {
            String[,] board = new String[3, 3];
            List<Transaction> transactions = new List<Transaction>();
            transactions.Add(new TicTacToeTransaction(board, 1, 1, true));
            transactions.Add(new TicTacToeTransaction(board, 1, 2, false));
            foreach(Transaction transaction in transactions) {
                transaction.execute();
            }
            Assert.AreEqual("X", board[1, 1]);
            Assert.AreEqual("O", board[1, 2]);
            transactions[1].undo();
            Assert.AreEqual(null, null);

        }
    }
}
