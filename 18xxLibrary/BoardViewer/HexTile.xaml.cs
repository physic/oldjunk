using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BoardViewer
{
    /// <summary>
    /// Interaction logic for HexTile.xaml
    /// </summary>
    public partial class HexTile : UserControl
    {
        protected const int Z_WHITE_CIRCLE =     0;
        protected const int Z_WHITE =            1;
        protected const int Z_CROSSING_BLACK =   2;
        protected const int Z_CROSSING_WHITE =   3;
        protected const int Z_BLACK =            4;
        protected const int Z_BLACK_CIRCLE =     5;

        public class Constants : StaticResourceHolder<Constants>
        {
            public const double HEX_TILE_RADIUS_X = 2 * 100;
            public const double HEX_EDGE_LENGTH = 200;
            public const int HEX_SIDES = 6;
            public static readonly PointCollection HEX_POINTS = new PointCollection(Util.GetPolygonCoordinates(HEX_SIDES, HEX_EDGE_LENGTH));
            
        }

        public HexTile()
        {
            this.Resources = Constants.Instance;
            InitializeComponent();
        }

        #region Paths
        private String _paths;

        public String Paths
        {
            get
            {
                return _paths;
            }

            set
            {
                String[] pairs = value.Split(' ');
                List<UIElement> whites = new List<UIElement>();
                List<UIElement> blacks = new List<UIElement>();
                foreach (String pairString in pairs)
                {
                    if (pairString == "") continue;
                    String[] pair = pairString.Split(',');
                    Tuple<Path,Path> both = GetPathFromEndPoints(pair[0].ToCharArray()[0], pair[1].ToCharArray()[0]);
                    whites.Add(both.Item1);
                    blacks.Add(both.Item2);
                }

                Tuple<int,int> crossed = FindIntersectingPaths(pairs);
                if (crossed != null)
                {
                    Grid.SetZIndex(whites[crossed.Item1], Z_CROSSING_WHITE);
                    Grid.SetZIndex(blacks[crossed.Item2], Z_CROSSING_BLACK);
                }

                PathGrid.Children.Clear();

                if (value.Contains('c'))
                {
                    Ellipse ew = new Ellipse();
                    ew.Fill = new SolidColorBrush(Colors.White);
                    ew.Width = ew.Height = 126;
                    ew.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                    ew.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                    ew.Margin = new Thickness(ew.Width / -2, ew.Height / -2, 0, 0);
                    Grid.SetZIndex(ew, 0);
                    whites.Insert(0, ew);

                    Ellipse ew2 = new Ellipse();
                    ew2.Fill = new SolidColorBrush(Colors.White);
                    ew2.Width = ew2.Height = ew.Width - 16;
                    ew2.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                    ew2.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                    ew2.Margin = new Thickness(ew2.Width / -2, ew2.Height / -2, 0, 0);
                    Grid.SetZIndex(ew2, 20);
                    whites.Insert(0, ew2);
                    Ellipse eb = new Ellipse();
                    eb.Fill = new SolidColorBrush(Colors.Black);
                    eb.Width = eb.Height = ew.Width - 10;
                    eb.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                    eb.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                    eb.Margin = new Thickness(eb.Width / -2, eb.Height / -2, 0, 0);
                    Grid.SetZIndex(eb, 16);
                    blacks.Add(eb);
                }

                foreach (UIElement e in whites)
                {
                    PathGrid.Children.Add(e);
                }
                foreach (UIElement e in blacks)
                {
                    PathGrid.Children.Add(e);
                }
                _paths = value;
            }
        }
        #endregion

        public String Id
        {
            get { return IdBlock.Text; }
            set { IdBlock.Text = value; }
        }

        public Color Color
        {
            get { return ((SolidColorBrush)TileBackground.Fill).Color; }
            set { TileBackground.Fill = new SolidColorBrush(value); }
        }

        public Int64 Rotation
        {
            get { return (((Int64)((RotateTransform)RenderTransform).Angle)-30)/60; }
            set { RenderTransform = new RotateTransform(value*60+30); }
        }

        private Tuple<Path,Path> GetPathFromEndPoints(char c1, char c2)
        {
            char start = c1 < c2 ? c1 : c2;
            char finish = c1 < c2 ? c2 : c1;
            String data;
            if (finish <= '5') // both edges
            {
                data = String.Format(sPath[finish - start], sPts[start - '0'], sPts[finish - '0']);
            }
            else if (finish == 'c') // center of the map
            {
                data = String.Format(sPath[3], sPts[start - '0'], "0,0");
            }
            else
            {
                throw new NotImplementedException();
            }
            
            Path bg = new Path();
            Path fg = new Path();
            bg.SetValue(Path.DataProperty, Geometry.Parse(data));
            fg.SetValue(Path.DataProperty, Geometry.Parse(data));
            bg.SetValue(Path.StrokeProperty, new BrushConverter().ConvertFromString("White"));
            fg.SetValue(Path.StrokeProperty, new BrushConverter().ConvertFromString("Black"));
            bg.SetValue(Path.StrokeThicknessProperty, 30.0);
            fg.SetValue(Path.StrokeThicknessProperty, 20.0);
            Grid.SetZIndex(bg, Z_WHITE);
            Grid.SetZIndex(fg, Z_BLACK);
            return new Tuple<Path, Path>(bg, fg);
        }

        private Tuple<int, int> FindIntersectingPaths(String[] pairs)
        {
            List<Tuple<int, int, int>> segments = new List<Tuple<int, int, int>>();
            for (int i = 0; i < pairs.Length; i++)
            {
                String pairString = pairs[i];
                String[] pair = pairString.Split(',');
                char a = pair[0].ToCharArray()[0];
                char b = pair[1].ToCharArray()[0];
                if (a > '5' || b > '5') segments.Add(new Tuple<int, int, int>('5', '5', i));
                else segments.Add(a < b ? new Tuple<int, int, int>(a, b, i) : new Tuple<int, int, int>(b, a, i));
            }
            segments.Sort((x, y) =>
                { if (x.Item1 > y.Item1) return 1;
                  if (x.Item1 < y.Item1) return -1;
                  if (x.Item2 > y.Item2) return 1;
                  if (x.Item2 < y.Item2) return -1;
                  return 0;
                });
            for (int i = 0; i < segments.Count; i++)
            {
                for (int j = i + 1; j < segments.Count; j++)
                {
                    if (segments[i].Item1 < segments[j].Item1
                                         && segments[j].Item1 < segments[i].Item2
                                                             && segments[i].Item2 < segments[j].Item2)
                        return new Tuple<int, int>(segments[i].Item3, segments[j].Item3);
                }
            }
            return null;
        }

        private String[] sPath =
            // M startPoint A size rotationAngle 0 0 endPoint
            { "",
              "M {0} A 100,100 0 0 0 {1}",
              "M {0} A 300,300 0 0 0 {1}",
              "M {0} L {1}",
              "M {1} A 300,300 0 0 0 {0}",
              "M {1} A 100,100 0 0 0 {0}"
            };

        private String[] sPts =
            { "0,175",
              "-150,87.5",
              "-150,-87.5",
              "0,-175",
              "150,-87.5",
              "150,87.5"
            };
    }
}
