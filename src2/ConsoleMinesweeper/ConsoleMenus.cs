// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConsoleMenus.cs" company="">
//   
// </copyright>
// <summary>
//   The console menus.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ConsoleMinesweeper
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using ConsoleMinesweeper.Interfaces;
    using ConsoleMinesweeper.Models;
    using ConsoleMinesweeper.View;

    using Minesweeper.Controller;
    using Minesweeper.Models;

    /// <summary>
    ///     The console menus.
    /// </summary>
    public static class ConsoleMenus
    {
        /// <summary>
        ///     The view.
        /// </summary>
        private static ConsoleView view;

        /// <summary>
        ///     The game controller.
        /// </summary>
        private static MinesweeperGameController gameController;

        /// <summary>
        ///     The start game menu.
        /// </summary>
        public static void StartGameMenu(IConsoleWrapper<ConsoleColor, ConsoleKeyInfo> output)
        {
            EventHandler ev1 = (sender, args) =>
            {
                view = new ConsoleView(true, output);
                gameController = new MinesweeperGameController(
                    MinesweeperDifficultyType.Easy,
                    view,
                    new ConsoleTimer());
            };

            EventHandler ev2 = (sender, args) =>
            {
                view = new ConsoleView(true, output);
                gameController = new MinesweeperGameController(
                    MinesweeperDifficultyType.Medium,
                    view,
                    new ConsoleTimer());
            };

            EventHandler ev3 = (sender, args) =>
            {
                view = new ConsoleView(true, output);
                gameController = new MinesweeperGameController(
                    MinesweeperDifficultyType.Hard,
                    view,
                    new ConsoleTimer());
            };

            EventHandler ev4 = (sender, args) => { StartMainMenu(output); };

            DisplayFourItemsMenu("Easy", "Medium", "Hard", "Back", ev1, ev2, ev3, ev4, output);
        }

        /// <summary>
        /// The start scores menu.
        /// </summary>
        public static void StartScoresMenu(IConsoleWrapper<ConsoleColor, ConsoleKeyInfo> output)
        {
            view = new ConsoleView(false, output);
            gameController = new MinesweeperGameController(MinesweeperDifficultyType.Hard, view, new ConsoleTimer());

            EventHandler ev1 = (sender, args) => { view.RequestScoreList(MinesweeperDifficultyType.Easy); };

            EventHandler ev2 = (sender, args) => { view.RequestScoreList(MinesweeperDifficultyType.Medium); };

            EventHandler ev3 = (sender, args) => { view.RequestScoreList(MinesweeperDifficultyType.Hard); };

            EventHandler ev4 = (sender, args) => { StartMainMenu(output); };

            DisplayFourItemsMenu("Easy", "Medium", "Hard", "Back", ev1, ev2, ev3, ev4, output);
        }

        /// <summary>
        ///     The start main menu.
        /// </summary>
        public static void StartMainMenu(IConsoleWrapper<ConsoleColor, ConsoleKeyInfo> output)
        {
            EventHandler ev1 = (sender, args) => { StartGameMenu(output); };

            EventHandler ev2 = (sender, args) => { StartScoresMenu(output); };

            EventHandler ev3 = (sender, args) =>
            {
                var help = new StringBuilder();

                help.Append("-----------------------------------------------------------");
                help.Append("--------------------  MINESWEEPER GAME  -------------------");
                help.Append("-----------------------------------------------------------");
                help.Append(" Version 1.0                                               ");
                help.Append("Telerik Course High Quality Code 2015/2016                 ");

                var scoreBoxList = new ConsoleBox<ConsoleColor>(
                    10,
                    10,
                    60,
                    10,
                    ConsoleColor.Cyan,
                    ConsoleColor.DarkRed,
                    help.ToString());

                ConsolePrinter.Print(new ConsoleWrapper(), scoreBoxList);
                output.ReadKey(true);
                StartMainMenu(output);
            };

            EventHandler ev4 = (sender, args) => { Environment.Exit(0); };

            DisplayFourItemsMenu("New Game", "High Scores", "Help", "Exit", ev1, ev2, ev3, ev4, output);
        }

        /// <summary>
        /// The display four items menu.
        /// </summary>
        /// <param name="str1">
        /// The str 1.
        /// </param>
        /// <param name="str2">
        /// The str 2.
        /// </param>
        /// <param name="str3">
        /// The str 3.
        /// </param>
        /// <param name="str4">
        /// The str 4.
        /// </param>
        /// <param name="ev1">
        /// The ev 1.
        /// </param>
        /// <param name="ev2">
        /// The ev 2.
        /// </param>
        /// <param name="ev3">
        /// The ev 3.
        /// </param>
        /// <param name="ev4">
        /// The ev 4.
        /// </param>
        private static void DisplayFourItemsMenu(
            string str1, 
            string str2, 
            string str3, 
            string str4, 
            EventHandler ev1, 
            EventHandler ev2, 
            EventHandler ev3, 
            EventHandler ev4,
            IConsoleWrapper<ConsoleColor, ConsoleKeyInfo> output)
        {
            var buttons = new List<ConsoleButton<ConsoleColor>>
                              {
                                  new ConsoleButton<ConsoleColor>(
                                      20, 
                                      3, 
                                      ConsoleColor.Blue, 
                                      ConsoleColor.Yellow, 
                                      ConsoleColor.Yellow, 
                                      ConsoleColor.Blue, 
                                      str1), 
                                  new ConsoleButton<ConsoleColor>(
                                      20, 
                                      3, 
                                      ConsoleColor.Blue, 
                                      ConsoleColor.Yellow, 
                                      ConsoleColor.Yellow, 
                                      ConsoleColor.Blue, 
                                      str2), 
                                  new ConsoleButton<ConsoleColor>(
                                      20, 
                                      3, 
                                      ConsoleColor.Blue, 
                                      ConsoleColor.Yellow, 
                                      ConsoleColor.Yellow, 
                                      ConsoleColor.Blue, 
                                      str3), 
                                  new ConsoleButton<ConsoleColor>(
                                      20, 
                                      3, 
                                      ConsoleColor.Blue, 
                                      ConsoleColor.Yellow, 
                                      ConsoleColor.Yellow, 
                                      ConsoleColor.Blue, 
                                      str4)
                              };

            buttons[0].ClickEvent += ev1;
            buttons[1].ClickEvent += ev2;
            buttons[2].ClickEvent += ev3;
            buttons[3].ClickEvent += ev4;

            output.Clear();
            var menu = new Menu(25, 10, 1, 1, ConsoleColor.DarkBlue, ConsoleColor.Gray, buttons, output);
            menu.Start();
        }        
    }
}