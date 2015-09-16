using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Models
{
    using Minesweeper.Models.Interfaces;

    [Serializable]
    public class PlayerBoard : IPlayerBoard
    {
        public PlayerBoard()
        {
            this.Players = new List<Player>();
        }
        public List<Player> Players { get; set; }

        public void AddPlayer(Player player)
        {
            this.Players.Add(player);
        }
    }
}
