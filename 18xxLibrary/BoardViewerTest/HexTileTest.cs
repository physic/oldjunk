using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoardViewer;
using System.Collections.Generic;
using System.Windows;

namespace BoardViewerTest
{
    [TestClass]
    public class HexTileTest
    {
        [TestMethod]
        public void VerifyResourcesTest()
        {
            HexTile tile = new HexTile();
            ResourceDictionary resources = HexTile.Constants.Instance;
            Assert.AreEqual(HexTile.Constants.HEX_EDGE_LENGTH, resources["HEX_EDGE_LENGTH"]);
            Assert.AreEqual(HexTile.Constants.HEX_SIDES, resources["HEX_SIDES"]);
            Assert.AreEqual(HexTile.Constants.HEX_TILE_RADIUS_X, resources["HEX_TILE_RADIUS_X"]);
            Assert.AreEqual(HexTile.Constants.HEX_POINTS, resources["HEX_POINTS"]);

        }
    }
}
