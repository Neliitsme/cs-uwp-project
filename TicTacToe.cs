namespace my_awesome_uwp_project
{
    

    // 0 is X, 1 is O
    public class TicTacToe
    {
        private static int _availableNodes = 9;
        private static readonly int[,] GameField = new int[3, 3];

        private enum ButtonStates
        {
            X,
            O,
            Empty
        }

        public static void GameStart()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    GameField[i, j] = (int)ButtonStates.Empty;
                }
            }

            _availableNodes = 9;
        }

        private static int FieldAssignPlayer(int x, int y)
        {
            if (GameField[x,y] != (int)ButtonStates.Empty)
            {
                return -1;
            }

            if (_availableNodes % 2 == 1)
            {
                GameField[x, y] = (int)ButtonStates.X;
            }
            else if (_availableNodes % 2 == 0)
            {
                GameField[x, y] = (int)ButtonStates.O;
            }

            _availableNodes--;

            return GameField[x, y];

        }

        public static string GameTurn(int frontX, int frontY)
        {
            switch (FieldAssignPlayer(frontX,frontY))
            {
                case 0: return "X";
                case 1: return "O";
                default: return "Err";
            }
        }

        public static (int, string) GameStateChecker()
        {

            for (int i = 0; i < 3; i++) // Horizontal check
            {
                if ((GameField[i, 0] == GameField[i, 1]) && (GameField[i, 1] == GameField[i, 2]) && GameField[i, 0] != (int)ButtonStates.Empty)
                {
                    return (GameField[i, 0], "Winner is " + (ButtonStates)GameField[i, 0]);

                }
            }

            for (int i = 0; i < 3; i++) // Vertical check
            {
                if ((GameField[0, i] == GameField[1, i]) && (GameField[1, i] == GameField[2, i]) && GameField[0, i] != (int)ButtonStates.Empty)
                {
                    return (GameField[0, i], "Winner is " + (ButtonStates)GameField[0, i]);
                }
            }

            if ((GameField[0, 0] == GameField[1, 1]) && (GameField[1, 1] == GameField[2, 2]) && GameField[1, 1] != (int)ButtonStates.Empty) // TopL to BotR check
            {
                return (GameField[0, 0], "Winner is " + (ButtonStates)GameField[0, 0]);
            }

            if ((GameField[0, 2] == GameField[1, 1]) && (GameField[1, 1] == GameField[2, 0]) && GameField[1, 1] != (int)ButtonStates.Empty) // TopR to BotL check
            {
                return (GameField[0, 2], "Winner is " + (ButtonStates)GameField[0, 2]);
            }

            if (_availableNodes <= 0) // Tie if no moves left
            {
                return (-1, "Tie");
            }

            return (-2, "");
        }

    }
}