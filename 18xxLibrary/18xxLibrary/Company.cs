using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TrainEngineLibrary
{
    class Company : CompanyInterface
    {
        //many of these need to not be public, many need getters/setters, many need to be adjusted frequently, some
        //won't be changed at all or very often (par value, loan capacity)
        public String Name;
        //public Player President; //   (commented because player not yet created)
        public int Cash;
        public List<String> Trains;
        public HashSet<City> Tokens;
        public int LoanCapacity;
        public int NumLoans;
        public int NumShares; //somewhere need to keep track of shares in ipo vs shareholders vs bankpool
        public int ParValue;
        public int StockChartValue;

        public HashSet<Tile> getPotentialUpgrades()
        {

            return null;
        }

        /*okay, trying to get a set of all the tiles that are reachable/legally upgradeable by a company based on where
         that company has tokens. need to do a depth first search from every token. every tile that we can reach on the search
         * path, including the tile with the token, is "reachable" (summary of algorithm follows). if tile is upgradeable 
         * (phase correct, not a town tile or coal mine, etc), add to set of tiles the company can upgrade. this set will be
         * called up. note: need to understand representation of the map/routes in order to code this */

    }
}
