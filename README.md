# Minesweeper-6 TeamProject
Course High Quality Code -Telerik Academy 2015/2016 

## Description
Minesweeper-6 is a classical Minesweeper game. It has two views:
* Console
* Windows Forms (implemented with WPF)

Game supports three levels - easy, medium and hard. Best times are recorded.

## Refactorings
* Architecture changed to MVC
* Classes MinesweeperCell, MinesweeperGrid and Exceptions partly reused in new game models
* Class ScoreBoard renamed as Player
* New game controller created. All game logic implemented in this class.
* New abstract IMinesweeperView.cs view created. 
* All model-view controller logic implemented in separate assembly (dll)
* New ConsoleMinesweeper game implemented (with separate console view)
* New WpfMinesweeper game implemented (with separate wpf view)

####Minesweeper models
* MinesweeperCell – implement reveal, protect and bomb logic
* MinesweeperGrid – keep cell collection, random bombs generation, boom event
* MinesweeperGridFactory – initialize easy, medium, hard grids
* MinesweeperDifficultyType – enum for different game levels
* MinesweeperPlayer – game player data
* MinesweeperGameData – logic for store/load players, easy to change input/output. Currently uses XML serialization of players
* Player and click event arguments
* Grid/cell/player exceptions

####Controls all game logic
* Works with abstract grid, view, timer, players and game level types
* Handle all view events and reacts on their change
* Stores game data using data model

#### No implementation, only interface definition
* Any view should be able to display:
	* DisplayGrid
	* DisplayScoreBoard
	* DisplayMoves
	* DisplayTime
* And handle use inputs:
	* OpenCellEvent
	* ProtectCellEvent
	* ShowScoreBoardEvent
	* AddPlayerEvent
* Two views implemented – console and WPF

####Console view and game
* Uses minesweeper.dll
* Implements own ConsoleView : IMinesweeperView
* ConsoleBox – console box with grid and text
* ConsoleButton : ConsoleBox – implements console button with click event
* ConsoleMenu : ConsoleBox – implements complete menu with buttons
* ConsolePrinter – print console boxes
* ConsoleWrapper – wraps CLR console class (for testing)
* ConsoleTimer – timer functionality

####WPF view and game
* Uses minesweeper.dll
* Implements own WpfView : IMinesweeperView
* XAML based implementation
* WpfMinesweeperButton : Button – extenstion of WPF button, containing rows and cols for the grid
* MainWindow : Window – main window in the game
* ScoresWindow : Window – scoreboard window
* InputBox : Window – add player box

##Used SOLID principles
* SRP – Separate class for each object in minesweeper models, separate controller and views. Console and WPF classes implement only what they need. All class components that are not needed are private or protected. Easy reusing of classes.
* OCP – mainly implemented in minesweeper.dll. New game view (ex. Mobile or Web) can be easily created without changing anything in the library.
* LSP – used in console view. ConsolePrinter prints any console box using IConsoleBox interface. Inherited buttons and menus do not change the print behavior.
* ISP – small interfaces created in the librarty. Cell/Grid/Player. All of them can be reused.
* DIP – all needed data for classes are used as input parameters. The only constructed new objects are StringBuilder and EventArgs. Objects are created only in controllers. Easy to test implementation.
* DRY – no code clones in the project. Checked by Visual Studio.
* YAGNI – all code clones that cannot be tested are removed.

##Used Design Patterns
* Simple factory – Minesweeper grid creation (easy, medium, hard)
* Composite – for console user interface
* Adaptor – used for CLR console for easy interface testing
* Strategy – used for different views
* Iterator – used for cells iteration in the grid
* Observer – CLR events for different views
* Memento – use to save/load user data

##UnitTests & StyleCop 
* 69 Unit test written using Visual Studio Team Test (90.65% coverage of the complete code)
* Used moq framework (for interfaces IMinesweeperView, IMinesweeperGrid, IMinesweeperTimer, IConsoleWrapper)
* No StyleCop warnings (including documentation)

##Documentation
* All code objects documented with XML format documentation (classes, methods, properties, events, fields)
* CHM documentation created (MinesweeperDocumentation.chm)
* Refactoring documentation provided (README.md)

##Participants
* **Atanas Georgiev (ageorgiev)** – project architecture, minesweeper and console implementation, unit tests
* **Stefan Yovchev (stefan.yovchev)** – Wpf implementation and unit testing
* **Tatyana Rangelova (TanyaRan)** – code documentation, stylecop fixing, CHM documentation creation

##Git repository
https://github.com/Minesweeper-6-Team-Project-Telerik/Minesweeper-6.git

