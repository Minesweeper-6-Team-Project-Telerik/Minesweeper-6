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
        public static void StartGameMenu()
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
                                      "Easy"), 
                                  new ConsoleButton<ConsoleColor>(
                                      20, 
                                      3, 
                                      ConsoleColor.Blue, 
                                      ConsoleColor.Yellow, 
                                      ConsoleColor.Yellow, 
                                      ConsoleColor.Blue, 
                                      "Medium"), 
                                  new ConsoleButton<ConsoleColor>(
                                      20, 
                                      3, 
                                      ConsoleColor.Blue, 
                                      ConsoleColor.Yellow, 
                                      ConsoleColor.Yellow, 
                                      ConsoleColor.Blue, 
                                      "Hard"), 
                                  new ConsoleButton<ConsoleColor>(
                                      20, 
                                      3, 
                                      ConsoleColor.Blue, 
                                      ConsoleColor.Yellow, 
                                      ConsoleColor.Yellow, 
                                      ConsoleColor.Blue, 
                                      "Exit")
                              };

            buttons[0].ClickEvent += (sender, args) =>
                {
                    view = new ConsoleView();
                    gameController = new MinesweeperGameController(
                        MinesweeperDifficultyType.Easy, 
                        view, 
                        new ConsoleTimer());
                };

            buttons[1].ClickEvent += (sender, args) =>
                {
                    view = new ConsoleView();
                    gameController = new MinesweeperGameController(
                        MinesweeperDifficultyType.Medium, 
                        view, 
                        new ConsoleTimer());
                };

            buttons[2].ClickEvent += (sender, args) =>
                {
                    view = new ConsoleView();
                    gameController = new MinesweeperGameController(
                        MinesweeperDifficultyType.Hard, 
                        view, 
                        new ConsoleTimer());
                };

            buttons[3].ClickEvent += (sender, args) => { StartMainMenu(); };

            Console.Clear();
            var menu = new Menu(25, 2, 1, 1, ConsoleColor.DarkBlue, ConsoleColor.Gray, buttons);
            menu.Start();
        }

        /// <summary>
        ///     The start main menu.
        /// </summary>
        public static void StartMainMenu()
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
                                      "New Game"), 
                                  new ConsoleButton<ConsoleColor>(
                                      20, 
                                      3, 
                                      ConsoleColor.Blue, 
                                      ConsoleColor.Yellow, 
                                      ConsoleColor.Yellow, 
                                      ConsoleColor.Blue, 
                                      "High Scores"), 
                                  new ConsoleButton<ConsoleColor>(
                                      20, 
                                      3, 
                                      ConsoleColor.Blue, 
                                      ConsoleColor.Yellow, 
                                      ConsoleColor.Yellow, 
                                      ConsoleColor.Blue, 
                                      "Help"), 
                                  new ConsoleButton<ConsoleColor>(
                                      20, 
                                      3, 
                                      ConsoleColor.Blue, 
                                      ConsoleColor.Yellow, 
                                      ConsoleColor.Yellow, 
                                      ConsoleColor.Blue, 
                                      "Exit")
                              };

            Console.Clear();

            // New game
            buttons[0].ClickEvent += (sender, args) => { StartGameMenu(); };

            buttons[3].ClickEvent += (sender, args) => { Environment.Exit(0); };

            var menu = new Menu(25, 2, 1, 1, ConsoleColor.DarkBlue, ConsoleColor.Gray, buttons);
            menu.Start();
        }
    }
}