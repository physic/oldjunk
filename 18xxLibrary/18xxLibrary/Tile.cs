using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TrainEngineLibrary
{
    class Tile
    {
        public String Id
        {
            get;
            private set;
        }
        public int Rotation
        {
            get;
            private set;
        }

        public int Phase
        {
            get;
            private set;
        }
//        public readonly String specialCityType;
//        public readonly String tileType;

        protected Tile()
        {
            // Default Constructor;
            Id = null;
            Rotation = 0;
            Phase = 0;
        }

        public static Tile CreateTileFromSerializationString(String description)
        {
            throw new NotImplementedException();
        }

        public static Tile CreateTileFromId(String id)
        {
            throw new NotImplementedException();
        }

        public virtual bool UpgradesTo(Tile tile)
        {
            throw new NotImplementedException();
        }

        public virtual bool RouteExistsToCity(int edge, int city)
        {
            return false;
        }

        public virtual bool RouteExists(int edgeA, int edgeB)
        {
            throw new NotImplementedException();
        }

        public virtual bool TrackExists(int edge)
        {
            throw new NotImplementedException();
        }

        public virtual List<City> GetCities()
        {
            return new List<City>();
        }

        public virtual HashSet<int> GetRouteConnections(int edge)
        {
            throw new NotImplementedException();
        }
    }
}
