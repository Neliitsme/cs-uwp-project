using Windows.UI.Notifications;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace my_awesome_uwp_project
{
    

    public static class TicTacToe
    {
        private static int _availableNodes = 9;
        public static readonly int[,] GameField = new int[3, 3];
        private static readonly int[] Players = { 0, 1 }; // 0 is X, 1 is O
        public static int FieldX;
        public static int FieldY;

        public static void GameStart()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    GameField[i, j] = -1;
                }
            }

            _availableNodes = 9;
        }

        private static int AssignPlayer(int x, int y)
        {
            if (GameField[x,y] != -1)
            {
                return 0;
            }

            if (_availableNodes % 2 == 1)
            {
                GameField[x, y] = Players[0];
            }
            else if (_availableNodes % 2 == 0)
            {
                GameField[x, y] = Players[1];
            }

            _availableNodes--;
            return 1;

        }

        public static void Turn(string buttonName)
        {
            FieldX = -1;
            FieldY = -1;

            if (buttonName == "Button_topleft")
            {
                FieldX = 0;
                FieldY = 0;

                if (_availableNodes <= 0)
                {
                    return;
                }

                switch (AssignPlayer(FieldX,FieldY))
                {
                    case 0:
                        return;
                }

                
            }
            else if (buttonName == "Button_midleft")
            {
                FieldX = 1;
                FieldY = 0;

                if (_availableNodes <= 0)
                {
                    return;
                }

                switch (AssignPlayer(FieldX, FieldY))
                {
                    case 0:
                        return;
                }
                
            } 
            else if (buttonName == "Button_botleft")
            {
                FieldX = 2;
                FieldY = 0;

                if (_availableNodes <= 0)
                {
                    return;
                }

                switch (AssignPlayer(FieldX, FieldY))
                {
                    case 0:
                        return;
                }
                
            }
            else if (buttonName == "Button_topcenter")
            {
                FieldX = 0;
                FieldY = 1;

                if (_availableNodes <= 0)
                {
                    return;
                }

                switch (AssignPlayer(FieldX, FieldY))
                {
                    case 0:
                        return;
                }
               
            }
            else if (buttonName == "Button_midcenter")
            {

                FieldX = 1;
                FieldY = 1;

                if (_availableNodes <= 0)
                {
                    return;
                }

                switch (AssignPlayer(FieldX, FieldY))
                {
                    case 0:
                        return;
                }
               
            }
            else if (buttonName == "Button_botcenter")
            {
                FieldX = 2;
                FieldY = 1;

                if (_availableNodes <= 0)
                {
                    return;
                }

                switch (AssignPlayer(FieldX, FieldY))
                {
                    case 0:
                        return;
                }
                
            }
            else if (buttonName == "Button_topright")
            {
                FieldX = 0;
                FieldY = 2;

                if (_availableNodes <= 0)
                {
                    return;
                }

                switch (AssignPlayer(FieldX, FieldY))
                {
                    case 0:
                        return;
                }
                
            }
            else if (buttonName == "Button_midright")
            {
                FieldX = 1;
                FieldY = 2;

                if (_availableNodes <= 0)
                {
                    return;
                }

                switch (AssignPlayer(FieldX, FieldY))
                {
                    case 0:
                        return;
                }
                
            }
            else if (buttonName == "Button_botright")
            {
                FieldX = 2;
                FieldY = 2;

                if (_availableNodes <= 0)
                {
                    return;
                }

                switch (AssignPlayer(FieldX, FieldY))
                {
                    case 0:
                        return;
                }
                
            }
        }

        public static int Checker()
        {

            for (int i = 0; i < 3; i++) // Horizontal check
            {
                if ((GameField[i, 0] == GameField[i, 1]) && (GameField[i, 1] == GameField[i, 2]) && GameField[i, 0] != -1)
                {
                    return GameField[i, 0];
                    
                }
            }

            for (int i = 0; i < 3; i++) // Vertical check
            {
                if ((GameField[0, i] == GameField[1, i]) && (GameField[1, i] == GameField[2, i]) && GameField[0, i] != -1)
                {
                    return GameField[0, i];
                }
            }

            if ((GameField[0, 0] == GameField[1, 1]) && (GameField[1, 1] == GameField[2, 2]) && GameField[1, 1] != -1) // TopL to BotR check
            {
                return GameField[0, 0];
            }

            if ((GameField[0, 2] == GameField[1, 1]) && (GameField[1, 1] == GameField[2, 0]) && GameField[1, 1] != -1) // TopR to BotL check
            {
                return GameField[0, 2];
            }

            if (_availableNodes <= 0) // Tie if no moves left
            {
                return -1;
            }

            return -2;
        }

    }
}