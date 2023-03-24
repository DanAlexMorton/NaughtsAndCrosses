using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NaughtsAndCrosses
{
    public class GameBoard
    {
        private  int rows;
        private  int columns;
        private  string[,] state;

        public GameBoard(int columns, int rows, string[,] state) {

            this.columns = columns;
            this.rows = rows;
            this.state = state;
        }

        private bool SetState(string[,] state, int columnPosition, int rowPosisition, string playerMark)
        {
            try
            {
                var allowedMove = CheckPosition(columnPosition, rowPosisition);

                if (allowedMove == "X" || allowedMove == "O")
                    return false;

                state[columnPosition, rowPosisition] = playerMark;
                this.state = state;

                if(CheckWinInRow(columnPosition, rowPosisition, playerMark))
                    return true;
                if(CheckWinInColumn(columnPosition, rowPosisition, playerMark))
                    return true;
               if(CheckWinInDiag(columnPosition, rowPosisition, playerMark))
                    return true; 

                return false;
            }
            catch(Exception ex)
            {
                Console.WriteLine("An Error occured: ", ex.Message);
                return false;
            }
        }
        public string[,] GetState()
        {
            return this.state;
        }
        public bool MapMove(int move, string playerMark)
        {
            try
            {
                var currentState = GetState();
                switch (move)
                {
                    case 1:
                        return SetState(currentState, 0, 0, playerMark);
                    case 2:
                        return SetState(currentState, 0, 1, playerMark);
                    case 3:
                        return SetState(currentState, 0, 2, playerMark);
                    case 4:
                        return SetState(currentState, 1, 0, playerMark);
                    case 5:
                        return SetState(currentState, 1, 1, playerMark);
                    case 6:
                        return SetState(currentState, 1, 2, playerMark);
                    case 7:
                        return SetState(currentState, 2, 0, playerMark);
                    case 8:
                        return SetState(currentState, 2, 1, playerMark);
                    case 9:
                        return SetState(currentState, 2, 2, playerMark);
                    default:
                        return false;

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("An Error occured: ", ex.Message);
                return false;
            }
        }
        private string CheckPosition(int columnPosition, int rowPosition)
        {
            return this.state[columnPosition, rowPosition];
        }

        private bool CheckWinInRow(int columnPosition, int rowPosition, string playerMark)
        {
            var posLeft = "";
            var posMiddle = "";
            var posRight = "";
            
            switch (rowPosition)
            {
                case 0:
                    posMiddle = CheckPosition(columnPosition, 1);
                    posRight = CheckPosition(columnPosition, 2);
                    
                    if (posMiddle == playerMark && posRight == playerMark)
                        return true;
                    return false;

                case 1:
                    posLeft = CheckPosition(columnPosition, 0);
                    posRight = CheckPosition(columnPosition, 2);

                    if (posLeft == playerMark && posRight == playerMark)
                        return true;
                    return false;

                case 2:
                    posMiddle = CheckPosition(columnPosition, 1);
                    posLeft = CheckPosition(columnPosition, 0);
                    

                    if (posLeft == playerMark && posMiddle == playerMark)
                        return true;
                    return false;

                default:
                    return false;
            }

        }
        private bool CheckWinInColumn(int columnPosition, int rowPosition, string playerMark)
        {
            var posTop = "";
            var posMiddle = "";
            var posBottom = "";

            switch (rowPosition)
            {
                case 1:
                    posMiddle = CheckPosition(1, rowPosition);
                    posBottom = CheckPosition(2, rowPosition);

                    if (posMiddle == playerMark && posBottom == playerMark)
                        return true;
                    return false;

                case 2:
                    posTop = CheckPosition(0, rowPosition);
                    posBottom = CheckPosition(2, rowPosition);

                    if (posTop == playerMark && posBottom == playerMark)
                        return true;
                    return false;

                case 3:
                    posTop = CheckPosition(0, rowPosition);
                    posMiddle = CheckPosition(1, rowPosition);
               
                    if (posTop == playerMark && posMiddle == playerMark)
                        return true;
                    return false;

                default:
                    return false;
            }

        }
        private bool CheckWinInDiag(int columnPosition, int rowPosition, string playerMark)
        {
            var posMiddle = "";
            var posBottom = "";
           
            if( CheckPosition(0,0) == playerMark)
            {
                posMiddle = CheckPosition(1,1);
                posBottom = CheckPosition(2,2);

                if (posMiddle == playerMark && posBottom == playerMark)
                    return true;
                return false;
            }

            if (CheckPosition(0, 2) == playerMark)
            {
                posMiddle = CheckPosition(1, 1);
                posBottom = CheckPosition(2, 0);

                if (posMiddle == playerMark && posBottom == playerMark)
                    return true;
                return false;
            }
            return false;
        }
        public bool RenderBoard()
        {
            var currentState = this.GetState();

            Console.Clear();
            Console.WriteLine("  -------------------------");
            Console.WriteLine("  |       |       |       |");
            Console.WriteLine("  |   {0}   |   {1}   |   {2}   |", currentState[0,0], currentState[0, 1], currentState[0, 2]);
            Console.WriteLine("  |       |       |       |");
            Console.WriteLine("  -------------------------");
            Console.WriteLine("  |       |       |       |");
            Console.WriteLine("  |   {0}   |   {1}   |   {2}   |", currentState[1, 0], currentState[1, 1], currentState[1, 2]);
            Console.WriteLine("  |       |       |       |");
            Console.WriteLine("  -------------------------");
            Console.WriteLine("  |       |       |       |");
            Console.WriteLine("  |   {0}   |   {1}   |   {2}   |", currentState[2, 0], currentState[2, 1], currentState[2, 2]);
            Console.WriteLine("  |       |       |       |");
            Console.WriteLine("  -------------------------");
            return true;
        }
    }
}
