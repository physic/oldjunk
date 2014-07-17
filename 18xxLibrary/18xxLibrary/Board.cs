using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainEngineLibrary
{
    class Board
    {
        public Dictionary<Tuple<int, int>, Tile> map;

        public Tile getTileFromMap(int x, int y)
        {
            return map[Tuple.Create(x, y)];
        }

        public bool isLegalBorder(int x, int y, int direction)
        {
            return true;
        }
    }
}
