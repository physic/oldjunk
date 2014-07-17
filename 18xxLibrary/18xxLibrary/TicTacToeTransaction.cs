using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainEngineLibrary
{
    public class TicTacToeTransaction : Transaction
    {
        String[,] board;
        Boolean playerXTurn;
        int x;
        int y;

        public TicTacToeTransaction(String[,] board, int x, int y, Boolean playerXTurn)
        {
            this.board = board;
            this.x = x;
            this.y = y;
            this.playerXTurn = playerXTurn;
        }


        public void execute()
        {
            if (board[x, y] != null) throw new InvalidTransactionException();
            if (x < 0 || x > 2 || y < 0 || y > 2) throw new InvalidTransactionException();
            if (playerXTurn)
            {
                board[x, y] = "X";
            }
            else
            {
                board[x, y] = "O";
            }
        }

        public void undo()
        {
            if (x < 0 || x > 2 || y < 0 || y > 2) throw new InvalidTransactionException();
            String expected = playerXTurn ? "X" : "O";
            if (board[x, y] != expected) throw new InvalidTransactionException();
            board[x, y] = null;
        }
    }

}
