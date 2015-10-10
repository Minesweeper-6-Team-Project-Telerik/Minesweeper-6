// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConsoleMenus.cs" company="Telerik Academy">
//   Teamwork Project "Minesweeper-6"
// </copyright>
// <summary>
//   The console menus.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ConsoleMinesweeper
{
    using System;
    using System.Collections.Generic;
    using System.IO;
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
        ///     The game controller.
        /// </summary>
        private static MinesweeperGameController gameController;

        /// <summary>
        /// The start game menu.
        /// </summary>
        /// <param name="output">
        /// The output.
        /// </param>
        /// <param name="view">
        /// The console view.
        /// </param>
        /// <param name="timer">
        /// The console timer.
        /// </param>
        public static void StartGameMenu(
            IConsoleWrapper<ConsoleColor, ConsoleKeyInfo> output, 
            IConsoleView view, 
            ConsoleTimer timer)
        {
            EventHandler ev1 =
                (sender, args) =>
                    {
                        gameController =
                            new MinesweeperGameController(
                                MinesweeperGridFactory.CreateNewTable(MinesweeperDifficultyType.Easy), 
                                view, 
                                timer, 
                                LoadPlayers(), 
                                MinesweeperDifficultyType.Easy);
                    };

            EventHandler ev2 =
                (sender, args) =>
                    {
                        gameController =
                            new MinesweeperGameController(
                                MinesweeperGridFactory.CreateNewTable(MinesweeperDifficultyType.Medium), 
                                view, 
                                timer, 
                                LoadPlayers(), 
                                MinesweeperDifficultyType.Medium);
                    };

            EventHandler ev3 =
                (sender, args) =>
                    {
                        gameController =
                            new MinesweeperGameController(
                                MinesweeperGridFactory.CreateNewTable(MinesweeperDifficultyType.Hard), 
                                view, 
                                timer, 
                                LoadPlayers(), 
                                MinesweeperDifficultyType.Hard);
                    };

            EventHandler ev4 = (sender, args) => { StartMainMenu(output); };

            DisplayFourItemsMenu("Easy", "Medium", "Hard", "Back", ev1, ev2, ev3, ev4, output);
        }

        /// <summary>
        /// The start scores menu.
        /// </summary>
        /// <param name="output">
        /// The output.
        /// </param>
        /// <param name="view">
        /// The console view.
        /// </param>
        /// <param name="timer">
        /// The console timer.
        /// </param>
        public static void StartScoresMenu(
            IConsoleWrapper<ConsoleColor, ConsoleKeyInfo> output, 
            IConsoleView view, 
            ConsoleTimer timer)
        {
            gameController =
                new MinesweeperGameController(
                    MinesweeperGridFactory.CreateNewTable(MinesweeperDifficultyType.Hard), 
                    view, 
                    timer, 
                    LoadPlayers(), 
                    MinesweeperDifficultyType.Hard);

            EventHandler ev1 = (sender, args) => { view.RequestScoreList(MinesweeperDifficultyType.Easy); };

            EventHandler ev2 = (sender, args) => { view.RequestScoreList(MinesweeperDifficultyType.Medium); };

            EventHandler ev3 = (sender, args) => { view.RequestScoreList(MinesweeperDifficultyType.Hard); };

            EventHandler ev4 = (sender, args) => { StartMainMenu(output); };

            DisplayFourItemsMenu("Easy", "Medium", "Hard", "Back", ev1, ev2, ev3, ev4, output);
        }

        /// <summary>
        /// The start main menu.
        /// </summary>
        /// <param name="output">
        /// The output.
        /// </param>
        public static void StartMainMenu(IConsoleWrapper<ConsoleColor, ConsoleKeyInfo> output)
        {
            EventHandler ev1 =
                (sender, args) => { StartGameMenu(output, new ConsoleView(true, output), new ConsoleTimer()); };

            EventHandler ev2 =
                (sender, args) => { StartScoresMenu(output, new ConsoleView(false, output), new ConsoleTimer()); };

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

                    ConsolePrinter.Print(output, scoreBoxList);
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
        /// The string 1.
        /// </param>
        /// <param name="str2">
        /// The string 2.
        /// </param>
        /// <param name="str3">
        /// The string 3.
        /// </param>
        /// <param name="str4">
        /// The string 4.
        /// </param>
        /// <param name="ev1">
        /// The event 1.
        /// </param>
        /// <param name="ev2">
        /// The event 2.
        /// </param>
        /// <param name="ev3">
        /// The event 3.
        /// </param>
        /// <param name="ev4">
        /// The event 4.
        /// </param>
        /// <param name="output">
        /// The output.
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
            var menu = new ConsoleMenu(25, 10, 1, 1, ConsoleColor.DarkBlue, ConsoleColor.Gray, buttons, output);
            menu.Start();
        }

        /// <summary>
        /// The load players.
        /// </summary>
        /// <returns>
        /// The players list <see cref="List"/>.
        /// </returns>
        private static List<MinesweeperPlayer> LoadPlayers()
        {
            List<MinesweeperPlayer> players;

            if (File.Exists(MinesweeperGameController.PlayersFilename))
            {
                players = MinesweeperGameData.Load<List<MinesweeperPlayer>>(MinesweeperGameController.PlayersFilename);
            }
            else
            {
                players = new List<MinesweeperPlayer>();
            }

            return players;
        }
    }
}
