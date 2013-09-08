using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainEngineLibrary
{
    class SimpleTile : Tile
    {
        private readonly int exits;

        public SimpleTile(params int[] edges)
        {
            if (edges.Count() > 6) throw new ArgumentException("Only six or fewer edges may be provided");
            int exits = 0;
            foreach (int edge in edges)
            {
                if (edge > 5 || edge < 0) throw new ArgumentException("Valid arguments must be in the range 0-5", "edges");
                exits |= 1 << edge;
            }
            this.exits = exits;
        }

        public override bool UpgradesTo(Tile tile)
        {
            if ((Id != null && tile.Id != null) || !(tile is SimpleTile)) return base.UpgradesTo(tile);

            SimpleTile other = (SimpleTile)tile;
            return (this.exits & other.exits) == this.exits && other.Phase == this.Phase + 1;
        }

        public override bool RouteExists(int edgeA, int edgeB)
        {
            return (exits << edgeA & exits << edgeB & 1) == 1;
        }

        public override bool TrackExists(int edge)
        {
            return (exits << edge & 1) == 1;
        }
    }
}
