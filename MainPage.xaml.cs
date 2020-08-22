using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace my_awesome_uwp_project
{
   
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            TicTacToe.GameStart();
        }

        private void SplitViewButton_OnClick(object sender, RoutedEventArgs e)
        {
            SplitView.IsPaneOpen = !SplitView.IsPaneOpen;
        }

        private void DisableGameButtons()
        {
            foreach (var uiElement in GameFieldGrid.Children)
            {
                var btn = (Button) uiElement;
                btn.IsEnabled = false;
            }

        }

        private void EnableGameButtons()
        {
            foreach (var uiElement in GameFieldGrid.Children)
            {
                var btn = (Button) uiElement;
                btn.IsEnabled = true;
            }
        }

        private void RemoveGameButtonsContent()
        {
            foreach (var uiElement in GameFieldGrid.Children)
            {
                var btn = (Button) uiElement;
                btn.Content = "";
            }
            WinnerBlock.Text = "";
        }

        private void StartButton_OnClick(object sender, RoutedEventArgs e)
        {
            TicTacToe.GameStart();
            EnableGameButtons();
            RemoveGameButtonsContent();
        }

        private void GameButton_OnClick(object sender, RoutedEventArgs e)
        {
            int frontX = Grid.GetColumn((Button)sender);
            int frontY = Grid.GetRow((Button)sender);
            ((Button)sender).Content = TicTacToe.GameTurn(frontX, frontY);

            (int stateInt, string stateString) = TicTacToe.GameStateChecker();

            switch (stateInt)
            {
                case -2:
                    break;
                default:
                    WinnerBlock.Text = stateString;
                    DisableGameButtons();
                    break;
            }
        
        }
    }


}
