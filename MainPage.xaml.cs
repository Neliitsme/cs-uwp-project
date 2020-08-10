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

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            SplitView.IsPaneOpen = !SplitView.IsPaneOpen;
        }

        private void DisableGameButtons()
        {
            Button_topleft.IsEnabled = false;
            Button_midleft.IsEnabled = false;
            Button_botleft.IsEnabled = false;
            Button_topcenter.IsEnabled = false;
            Button_midcenter.IsEnabled = false;
            Button_botcenter.IsEnabled = false;
            Button_topright.IsEnabled = false;
            Button_midright.IsEnabled = false;
            Button_botright.IsEnabled = false;
        }

        private void EnableGameButtons()
        {
            Button_topleft.IsEnabled = true;
            Button_midleft.IsEnabled = true;
            Button_botleft.IsEnabled = true;
            Button_topcenter.IsEnabled = true;
            Button_midcenter.IsEnabled = true;
            Button_botcenter.IsEnabled = true;
            Button_topright.IsEnabled = true;
            Button_midright.IsEnabled = true;
            Button_botright.IsEnabled = true;
        }

        private void RemoveGameButtonsContent()
        {
            Button_topleft.Content = "";
            Button_midleft.Content = "";
            Button_botleft.Content = "";
            Button_topcenter.Content = "";
            Button_midcenter.Content = "";
            Button_botcenter.Content = "";
            Button_topright.Content = "";
            Button_midright.Content = "";
            Button_botright.Content = "";
            WinnerBlock.Text = "";
        }

        private void Start_button_OnClick(object sender, RoutedEventArgs e)
        {
            TicTacToe.GameStart();
            EnableGameButtons();
            RemoveGameButtonsContent();
        }

        private void Game_button_OnClick(object sender, RoutedEventArgs e)
        {
            TicTacToe.Turn(((Button) sender).Name);

            switch (TicTacToe.GameField[TicTacToe.FieldX, TicTacToe.FieldY])
            {
                case 0: 
                    ((Button)sender).Content = "X";
                    break;
                case 1: 
                    ((Button)sender).Content = "O";
                    break;
                default: 
                    ((Button)sender).Content = "Err";
                    break;
            }

            switch (TicTacToe.Checker())
            {
                case 0: 
                    WinnerBlock.Text = "Winner is X";
                    DisableGameButtons();
                    break;

                case 1: 
                    WinnerBlock.Text = "Winner is O"; 
                    DisableGameButtons();
                    break;
                case -1:
                    WinnerBlock.Text = "Tie";
                    DisableGameButtons();
                    break;
            }

        }
    }


}
