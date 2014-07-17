using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainEngineLibrary
{
    class SimpleTile : Tile
    {
        private readonly HashSet<int> exits;

        public SimpleTile(params int[] edges)
        {
            if (edges.Count() > 6) throw new ArgumentException("Only six or fewer edges may be provided");
            exits = new HashSet<int>();
            foreach (int edge in edges)
            {
                if (edge > 5 || edge < 0) throw new ArgumentException("Valid arguments must be in the range 0-5", "edges");
                exits.Add(edge);
            }
        }

        public override bool UpgradesTo(Tile tile)
        {
            if ((Id != null && tile.Id != null) || !(tile is SimpleTile)) return base.UpgradesTo(tile);

            SimpleTile other = (SimpleTile)tile;
            return (this.exits.IsSubsetOf(other.exits)) && other.Phase == this.Phase + 1;
        }

        public override bool RouteExists(int edgeA, int edgeB)
        {
            return exits.Contains(edgeA) && exits.Contains(edgeB);
        }

        public override bool TrackExists(int edge)
        {
            return exits.Contains(edge);
        }

        public override HashSet<int> GetRouteConnections(int edge)
        {

            if(!exits.Contains(edge)) return new HashSet<int>();
            HashSet<int> result = new HashSet<int>(exits);
            result.Remove(edge);
            return result;
        }
    }
}
