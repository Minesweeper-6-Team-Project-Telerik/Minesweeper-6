// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConsoleMinesweeperGame.cs" company="">
//   
// </copyright>
// <summary>
//   The console minesweeper game.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace MineSweeper.ConsoleGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using MineSweeper.GameModel;
    using MineSweeper.GameModel.Exceptions;
    using MineSweeper.GameModel.Interfaces;

    /// <summary>
    ///     The console minesweeper game.
    /// </summary>
    internal class ConsoleMinesweeperGame : IMinesweeperGame<char>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleMinesweeperGame"/> class.
        /// </summary>
        /// <param name="rows">
        /// The Rows.
        /// </param>
        /// <param name="columns">
        /// The columns.
        /// </param>
        /// <param name="minesCount">
        /// The mines count.
        /// </param>
        public ConsoleMinesweeperGame(int rows, int columns, int minesCount)
        {
            this.Grid = new ConsoleMinesweeperGrid(rows, columns, minesCount);
            this.ScoreBoard = new List<IScoreRecord>();
        }

        /// <summary>
        ///     Gets the Grid.
        /// </summary>
        public ConsoleMinesweeperGrid Grid { get; }

        /// <summary>
        ///     Gets or sets the score.
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        ///     Gets or sets the score board.
        /// </summary>
        public List<IScoreRecord> ScoreBoard { get; set; }

        /// <summary>
        ///     The start.
        /// </summary>
        public void Start()
        {
            var startMessage =
                "Welcome to the game “Minesweeper”. Try to reveal all cells without mines. Use 'top' to view the scoreboard, 'restart' to start a new game and 'exit' to quit the game.";
            Console.WriteLine(startMessage);
            Console.WriteLine(this.Grid.ToString());
            this.NextCommand();
        }

        /// <summary>
        ///     The next command.
        /// </summary>
        public void NextCommand()
        {
            // console -  output Grid and message to request command
            Console.Write("Enter row and column:");

            var commandLine = Console.ReadLine().ToUpper().Trim();

            var commandList = commandLine.Split(' ').ToList();

            if (commandList.Count == 0)
            {
                // if command list is empty
                this.NextCommand();
            }

            try
            {
                var firstCommand = commandList.ElementAt(0);
                switch (firstCommand)
                {
                    case "RESTART":
                        this.Start();
                        break;
                    case "TOP":
                        {
                            this.PrintScoreBoard();
                            this.NextCommand();
                        }

                        break;
                    case "EXIT":
                        this.Exit();
                        break;

                    // case "EXPLOREMINES":
                    // {
                    // Grid.RevealMines();
                    // Console.WriteLine(Grid.ToString());
                    // NextCommand();
                    // }; break;
                    default:
                        {
                            int row;
                            var column = 0;
                            var tryParse = false;

                            if (commandList.Count < 2)
                            {
                                throw new CommandUnknownException();
                            }

                            tryParse = int.TryParse(commandList.ElementAt(0), out row) || tryParse;
                            tryParse = int.TryParse(commandList.ElementAt(1), out column) || tryParse;

                            if (!tryParse)
                            {
                                throw new CommandUnknownException();
                            }

                            if (this.Grid.RevealCell(row, column) == '*')
                            {
                                // this.Grid.mark('-');
                                this.Grid.RevealMines();
                                Console.WriteLine(this.Grid.ToString());
                                Console.WriteLine(
                                    "Booooom! You were killed by a mine. You revealed {0} cells without mines.", 
                                    this.Score);
                                Console.Write("Please enter your name for the top scoreboard: ");
                                var playerName = Console.ReadLine();

                                this.ScoreBoard.Add(new ScoreRecord(playerName, this.Score));
                                Console.WriteLine();
                                this.PrintScoreBoard();
                                this.Start();
                            }
                            else
                            {
                                Console.WriteLine(this.Grid.ToString());
                                this.Score++;
                                this.NextCommand();
                            }
                        }

                        break;
                }
            }
            catch (InvalidCellException)
            {
                Console.WriteLine("Illegal move!");
                this.NextCommand();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                this.NextCommand();
            }
        }

        /// <summary>
        ///     The exit.
        /// </summary>
        public void Exit()
        {
            Console.WriteLine("Good bye!");
        }

        /// <summary>
        ///     The print score board.
        /// </summary>
        public void PrintScoreBoard()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Scoreboard:");
            this.ScoreBoard.Sort();
            var i = 0;
            foreach (ScoreRecord sr in this.ScoreBoard)
            {
                i++;
                sb.AppendFormat("{0}. {1} --> {2} cells \n", i, sr.PlayerName, sr.Score);
            }

            Console.WriteLine(sb.ToString());
        }
    }
}