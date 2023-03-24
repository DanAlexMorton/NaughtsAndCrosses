using NaughtsAndCrosses;

namespace TestNaughtsAndCrosses
{
    public class UnitTest1
    {
        [Fact]
        public void TestGameBoard()
        {
            string[,] initialState = { { "", "", "" }, { "", "", "" }, { "", "", "" } };
            string[,] initialStateWrong = { { "", "" }, { "", "" }, { "", "" } };
            GameBoard board = new GameBoard(3, 3, initialState);

            Assert.Equal(board.GetState(), initialState);
            Assert.NotEqual(board.GetState(), initialStateWrong);
        }
        [Fact]
        public void TestXHorizontalWin()
        {
            string[,] initialState = { { "", "", "" }, { "", "", "" }, { "", "", "" } };
            string[,] expectedState = { { "X", "X", "X" }, { "", "", "" }, { "", "", "" } };
            GameBoard board = new GameBoard(3, 3, initialState);
            var winState = false;

            winState = board.MapMove(1, "X");
            winState = board.MapMove(2, "X");
            winState =  board.MapMove(3, "X");

            Assert.Equal(board.GetState(), expectedState);
        }
        [Fact]
        public void TestXVerticalWin()
        {
            string[,] initialState = { { "", "", "" }, { "", "", "" }, { "", "", "" } };
            string[,] expectedState = { { "X", "", "" }, { "X", "", "" }, { "X", "", "" } };
            GameBoard board = new GameBoard(3, 3, initialState);
            var winState = false;

            winState = board.MapMove(1, "X");
            winState = board.MapMove(4, "X");
            winState = board.MapMove(7, "X");

            Assert.Equal(board.GetState(), expectedState);
        }
        [Fact]
        public void TestXDiagonalWin()
        {
            string[,] initialState = { { "", "", "" }, { "", "", "" }, { "", "", "" } };
            string[,] expectedState = { { "X", "", "" }, { "", "X", "" }, { "", "", "X" } };
            GameBoard board = new GameBoard(3, 3, initialState);
            var winState = false;

            winState = board.MapMove(1, "X");
            winState = board.MapMove(5, "X");
            winState = board.MapMove(9, "X");

            Assert.Equal(board.GetState(), expectedState);
        }
        [Fact]
        public void TestXReverseDiagonalWin()
        {
            string[,] initialState = { { "", "", "" }, { "", "", "" }, { "", "", "" } };
            string[,] expectedState = { { "", "", "X" }, { "", "X", "" }, { "X", "", "" } };
            GameBoard board = new GameBoard(3, 3, initialState);
            var winState = false;

            winState = board.MapMove(3, "X");
            winState = board.MapMove(5, "X");
            winState = board.MapMove(7, "X");

            Assert.Equal(board.GetState(), expectedState);
        }
        [Fact]
        public void TestOHorizontalWin()
        {
            string[,] initialState = { { "", "", "" }, { "", "", "" }, { "", "", "" } };
            string[,] expectedState = { { "O", "O", "O" }, { "", "", "" }, { "", "", "" } };
            GameBoard board = new GameBoard(3, 3, initialState);
            var winState = false;

            winState = board.MapMove(1, "O");
            winState = board.MapMove(2, "O");
            winState = board.MapMove(3, "O");

            Assert.Equal(board.GetState(), expectedState);
        }
        [Fact]
        public void TestOVerticalWin()
        {
            string[,] initialState = { { "", "", "" }, { "", "", "" }, { "", "", "" } };
            string[,] expectedState = { { "O", "", "" }, { "O", "", "" }, { "O", "", "" } };
            GameBoard board = new GameBoard(3, 3, initialState);
            var winState = false;

            winState = board.MapMove(1, "O");
            winState = board.MapMove(4, "O");
            winState = board.MapMove(7, "O");

            Assert.Equal(board.GetState(), expectedState);
        }
        [Fact]
        public void TestODiagonalWin()
        {
            string[,] initialState = { { "", "", "" }, { "", "", "" }, { "", "", "" } };
            string[,] expectedState = { { "O", "", "" }, { "", "O", "" }, { "", "", "O" } };
            GameBoard board = new GameBoard(3, 3, initialState);
            var winState = false;

            winState = board.MapMove(1, "O");
            winState = board.MapMove(5, "O");
            winState = board.MapMove(9, "O");

            Assert.Equal(board.GetState(), expectedState);
        }
        [Fact]
        public void TestOReverseDiagonalWin()
        {
            string[,] initialState = { { "", "", "" }, { "", "", "" }, { "", "", "" } };
            string[,] expectedState = { { "", "", "O" }, { "", "O", "" }, { "O", "", "" } };
            GameBoard board = new GameBoard(3, 3, initialState);
            var winState = false;

            winState = board.MapMove(3, "O");
            winState = board.MapMove(5, "O");
            winState = board.MapMove(7, "O");

            Assert.Equal(board.GetState(), expectedState);
        }
    }
}