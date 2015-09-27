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

    using ConsoleMinesweeper.View;

    using Minesweeper.Controller;
    using Minesweeper.Models;

    /// <summary>
    ///     The console menus.
    /// </summary>
    internal static class ConsoleMenus
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
            var buttons = new List<Button>
                              {
                                  new Button(
                                      20, 
                                      3, 
                                      ConsoleColor.Blue, 
                                      ConsoleColor.Yellow, 
                                      ConsoleColor.Yellow, 
                                      ConsoleColor.Blue, 
                                      "Easy"), 
                                  new Button(
                                      20, 
                                      3, 
                                      ConsoleColor.Blue, 
                                      ConsoleColor.Yellow, 
                                      ConsoleColor.Yellow, 
                                      ConsoleColor.Blue, 
                                      "Medium"), 
                                  new Button(
                                      20, 
                                      3, 
                                      ConsoleColor.Blue, 
                                      ConsoleColor.Yellow, 
                                      ConsoleColor.Yellow, 
                                      ConsoleColor.Blue, 
                                      "Hard"), 
                                  new Button(
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
                    gameController = new MinesweeperGameController(MinesweeperDifficultyType.Easy, view);
                };

            buttons[1].ClickEvent += (sender, args) =>
                {
                    view = new ConsoleView();
                    gameController = new MinesweeperGameController(MinesweeperDifficultyType.Medium, view);
                };

            buttons[2].ClickEvent += (sender, args) =>
                {
                    view = new ConsoleView();
                    gameController = new MinesweeperGameController(MinesweeperDifficultyType.Hard, view);
                };

            buttons[3].ClickEvent += (sender, args) => { StartMainMenu(); };

            Console.Clear();
            var menu = new Menu(25, 2, 0, 0, ConsoleColor.DarkBlue, ConsoleColor.Gray, buttons);
            menu.Start();
        }

        /// <summary>
        ///     The start main menu.
        /// </summary>
        public static void StartMainMenu()
        {
            var buttons = new List<Button>
                              {
                                  new Button(
                                      20, 
                                      3, 
                                      ConsoleColor.Blue, 
                                      ConsoleColor.Yellow, 
                                      ConsoleColor.Yellow, 
                                      ConsoleColor.Blue, 
                                      "New Game"), 
                                  new Button(
                                      20, 
                                      3, 
                                      ConsoleColor.Blue, 
                                      ConsoleColor.Yellow, 
                                      ConsoleColor.Yellow, 
                                      ConsoleColor.Blue, 
                                      "High Scores"), 
                                  new Button(
                                      20, 
                                      3, 
                                      ConsoleColor.Blue, 
                                      ConsoleColor.Yellow, 
                                      ConsoleColor.Yellow, 
                                      ConsoleColor.Blue, 
                                      "Help"), 
                                  new Button(
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

            var menu = new Menu(25, 2, 0, 0, ConsoleColor.DarkBlue, ConsoleColor.Gray, buttons);
            menu.Start();
        }
    }
}