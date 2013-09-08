using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainEngineLibrary
{
    class City
    {
        // The numeric value that is added to a route containing this city.
        public int Value
        {
            get;
            private set;
        }
        
        // The number of token spots in the city.
        public int Size
        {
            get;
            private set;
        }

        private HashSet<String> stations;

        public HashSet<String> GetStations()
        {
            return new HashSet<String>(stations);
        }

        public void AddStation(String company)
        {
            if (stations.Count >= Size || stations.Contains(company))
            {
                throw new Exception("Whatchyu thinkin'?");
            }
            stations.Add(company);
        }

        public void removeStation(String company)
        {
            if (!stations.Contains(company))
            {
                throw new Exception("Whatchyu thinkin'?");
            }
            stations.Remove(company);
        }

        public bool CanPass(String company)
        {
            if (Size == 0) return true; // A city of size 0 is a dit town, so anyone may pass through.
            if (stations.Count < Size) return true; // There are empty stations
            else return stations.Contains(company); // There are no empty stations, so check whether the company has a station.
        }
    }
}
