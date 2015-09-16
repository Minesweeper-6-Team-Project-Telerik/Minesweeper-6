﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Models
{
    using Minesweeper.Models.Interfaces;

    [Serializable]
    public class Player : IPlayer
    {
        public string Name { get; set; }

        public int Score { get; set; }
    }
}
