using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class GameStatus
    {
        public int status { get; set; }
        public int running { get; set; }
        public string Errors { get; set; }
        public int force_end { get; set; }
    }

}
