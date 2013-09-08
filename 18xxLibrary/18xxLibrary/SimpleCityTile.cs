using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainEngineLibrary
{
    class SimpleCityTile : Tile
    {
        private readonly int exits;

        private readonly City city;

        public SimpleCityTile(City city, params int[] edges)
        {
            if (edges.Count() > 6) throw new ArgumentException("Only six or fewer edges may be provided");
            int exits = 0;
            foreach(int edge in edges){
                if (edge > 5 || edge < 0) throw new ArgumentException("Valid arguments must be in the range 0-5", "edges");
                exits |= 1 << edge;
            }
            this.exits = exits;
            this.city = city;
        }

        public override bool UpgradesTo(Tile tile)
        {
            throw new NotImplementedException();
        }

        public override bool RouteExistsToCity(int edge, int city)
        {
            return city == 0 && TrackExists(edge);
        }

        public override bool RouteExists(int edgeA, int edgeB)
        {
            return false;
        }

        public override bool TrackExists(int edge)
        {
            return (exits << edge & 1) == 1;
        }

        public City GetCity()
        {
            return city;
        }
    }
}
