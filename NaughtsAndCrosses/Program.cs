
using NaughtsAndCrosses;

class Program
{
    static void Main(string[] args)
    {
        string[,] initialState = { {"", "", "" }, { "", "", "" }, { "", "", "" } };
        bool winState = false;
        
        GameBoard board = new GameBoard(3, 3, initialState);
        

        while (winState != true)
        {
            Console.Write(board.RenderBoard());

            Console.WriteLine("Player: 1 ");

            Console.WriteLine("Enter number from 1-9: ");
           
            int x = 0;
            var userMoveOk = Int32.TryParse(Console.ReadLine(), out x);

            if (userMoveOk)
            {
                if (x < 10 && x > 0)
                    winState = board.MapMove(x, "X");
            }
            
            if(winState == true)
            {
                Console.WriteLine("Player 1 Wins :) !!!");
                break;
            }

            x = 0;

            Console.Write(board.RenderBoard());

            Console.WriteLine("Player: 2 ");

            Console.WriteLine("Enter number from 1-9: ");

            userMoveOk = Int32.TryParse(Console.ReadLine(), out x);

            if (userMoveOk)
            {
                if (x < 10 && x > 0)
                    winState = board.MapMove(x, "O");
            }

            if (winState == true)
            {
                Console.WriteLine("Player 2 Wins :) !!!");
                break;
            }

            continue;
        }  
    }
}