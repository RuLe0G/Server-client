using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace WpfApp7._1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Windows.Threading.DispatcherTimer Timer;
        int currentFrame = 0;
        int frameCount = 7;
        int frameW = 100;
        int frameH = 100;
        int currentRow = 0;
        Rectangle viky = new Rectangle();
        Rectangle myRect1 = new Rectangle();
        Point pos = new Point();
        Rectangle myRect = new Rectangle();
        Ellipse myEllipse = new Ellipse();
        public MainWindow()
        {

            //Timer = new System.Windows.Threading.DispatcherTimer();
            //Timer.Tick += new EventHandler(dispatcherTimer_Tick);
            //Timer.Interval = new TimeSpan(0, 0, 0, 0, 30);
            //Timer.Start();


            InitializeComponent();
            Line myLine = new Line();
            myLine.Stroke = System.Windows.Media.Brushes.Black;
            myLine.X1 = 1;
            myLine.Y1 = 1;
            myLine.X2 = 50;
            myLine.Y2 = 50;
            myLine.HorizontalAlignment = HorizontalAlignment.Left;
            myLine.VerticalAlignment = VerticalAlignment.Center;
            myLine.StrokeThickness = 2;
            scene.Children.Add(myLine);
            myLine.Margin = new Thickness(75, 100, 0, 0);


            SolidColorBrush mySolidColorBrush = new SolidColorBrush();
            mySolidColorBrush.Color = Color.FromArgb(255, 255, 255, 0);
            myEllipse.Fill = mySolidColorBrush;
            myEllipse.StrokeThickness = 2;
            myEllipse.Stroke = Brushes.Black;
            myEllipse.Width = 100;
            myEllipse.Height = 100;
            // myEllipse.Margin = new Thickness(200, 200, 0, 0);
            scene.Children.Add(myEllipse);


            myRect.Stroke = Brushes.Black;
            myRect.Fill = Brushes.SkyBlue;
            myRect.HorizontalAlignment = HorizontalAlignment.Left;
            myRect.VerticalAlignment = VerticalAlignment.Center;
            myRect.Height = 50;
            myRect.Width = 50;
            scene.Children.Add(myRect);
           // myRect.Margin = new Thickness(50, 200, 0, 0);

            Polygon myPolygon = new Polygon();
            myPolygon.Stroke = Brushes.Black;
            myPolygon.Fill = Brushes.LightSeaGreen;
            myPolygon.StrokeThickness = 2;
            myPolygon.HorizontalAlignment = HorizontalAlignment.Left;
            myPolygon.VerticalAlignment = VerticalAlignment.Center;
            Point Point1 = new Point(0, 0);
            Point Point2 = new Point(100, 0);
            Point Point3 = new Point(100, 50);
            Point Point4 = new Point(50, 100);
            Point Point5 = new Point(0, 50);
            PointCollection myPointCollection = new PointCollection();
            myPointCollection.Add(Point1);
            myPointCollection.Add(Point2);
            myPointCollection.Add(Point3);
            myPointCollection.Add(Point4);
            myPointCollection.Add(Point5);
            myPolygon.Points = myPointCollection;
            scene.Children.Add(myPolygon);

            Path path = new Path();
            path.Stroke = Brushes.Black;
            path.StrokeThickness = 1;
            BezierSegment bezierCurve1 = new BezierSegment(new Point(0, 0), new Point(0, 50), new Point(50, 90),
            true);
            BezierSegment bezierCurve2 = new BezierSegment(new Point(100, 50), new Point(100, 0), new Point(50,
            30), true);
            PathSegmentCollection psc = new PathSegmentCollection();
            psc.Add(bezierCurve1);
            psc.Add(bezierCurve2);
            PathFigure pf = new PathFigure();
            pf.Segments = psc;
            pf.StartPoint = new Point(50, 30);
            PathFigureCollection pfc = new PathFigureCollection();
            pfc.Add(pf);
            PathGeometry pg = new PathGeometry();
            pg.Figures = pfc;
            GeometryGroup pathGeometryGroup = new GeometryGroup();
            pathGeometryGroup.Children.Add(pg);
            path.Data = pathGeometryGroup;
            scene.Children.Add(path);

            Ellipse myEllipse1 = new Ellipse();
            ImageBrush ib = new ImageBrush();
            ib.AlignmentX = AlignmentX.Left;
            ib.AlignmentY = AlignmentY.Top;
            ib.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/pic/trump.jpg", UriKind.Absolute));
            myEllipse1.Fill = ib;
            myEllipse1.StrokeThickness = 2;
            myEllipse1.Stroke = Brushes.Black;
            myEllipse1.Width = 300;
            myEllipse1.Height = 300;
            myEllipse1.Margin = new Thickness(300, 0, 0, 0);
            scene.Children.Add(myEllipse1);


            viky.Height = 100;
            viky.Width = 100;
            ImageBrush ib1 = new ImageBrush();
            ib1.AlignmentX = AlignmentX.Left;
            ib1.AlignmentY = AlignmentY.Top;
            ib1.Stretch = Stretch.None;
            ib1.Viewbox = new Rect(100, 0, 200, 100);
            ib1.ViewboxUnits = BrushMappingMode.Absolute;
            ib1.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/pic/VictoriaSprites.gif", UriKind.Absolute));
            viky.Fill = ib1;
            viky.Margin = new Thickness(0, 0, 0, 0);
            scene.Children.Add(viky);

            ib.Transform = new ScaleTransform(2, 0.5);
            myEllipse1.RenderTransform = new ScaleTransform(2, 0.5);




            //myRect1.Stroke = Brushes.Black;
            //myRect1.Fill = Brushes.SkyBlue;
            //myRect1.HorizontalAlignment = HorizontalAlignment.Left;
            //myRect1.VerticalAlignment = VerticalAlignment.Center;
            //myRect1.Height = 100;
            //myRect1.Width = 100;
            //scene.Children.Add(myRect1);
            //myRect1.Margin = new Thickness(100, 250, 0, 0);
            //ImageBrush ib2 = new ImageBrush();
            //ib2.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/pic/orig1.jpg", UriKind.Absolute));
            //myRect1.MouseEnter += MyRect1_MouseEnter;
            //myRect1.Fill = ib2;

            //Rect rect = myRect.RenderedGeometry.Bounds;
            //rect.Intersect(myEllipse.RenderedGeometry.Bounds);

            //Point pos = new Point(10, 10);

        //    TransformGroup tg = new TransformGroup();
        //    TranslateTransform tt = new TranslateTransform(100, 150);
        //    RotateTransform rt = new RotateTransform(50, 50, 50);
        //    tg.Children.Add(rt);
        //    tg.Children.Add(tt);
        //    myRect.RenderTransform = tg;

        //    TransformGroup tg1 = new TransformGroup();

        //    TranslateTransform tt1 = new TranslateTransform(300, 0);
        //    RotateTransform rt1 = new RotateTransform(10, 10, 10);
        //    tg.Children.Add(rt1);
        //    tg.Children.Add(tt1);

        //    myEllipse.RenderTransform = tt1;
           
        //}

        //private void dispatcherTimer_Tick(object sender, EventArgs e)
        //{
        //    currentFrame = (currentFrame + 1 + frameCount) % frameCount;
        //    var frameLeft = currentFrame * frameW;
        //    var frameTop = currentRow * frameH;
        //    (viky.Fill as ImageBrush).Viewbox = new Rect(frameLeft, frameTop, frameLeft + frameW, frameTop + frameH);
        //}

        //private void MyRect1_MouseEnter(object sender, MouseEventArgs e)
        //{
        //    ImageBrush ib = new ImageBrush();
        //    ib.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/pic/orig2.jpg",UriKind.Absolute));
        //    myRect1.Fill = ib;
        //}

        
        private void Window_MouseMove_1(object sender, MouseEventArgs e)
        {
            Point pos = Mouse.GetPosition(scene);
            lb1.Content = pos.X;
            lb2.Content = pos.Y;

            //myRect.RenderedGeometry.Bounds.Transform(myRect.RenderTransform.Value);

            GeneralTransform generalTransform1 = scene.TransformToVisual(myRect);
            Rect rt = myRect.RenderTransform.TransformBounds(myRect.RenderedGeometry.Bounds);
            //Point pt = generalTransform1.Transform(pos);

            //if (myRect.RenderedGeometry.Bounds.Contains(pos) == true)
            if (rt.Contains(pos) == true)
            {
                MessageBox.Show("Точка входит в прямоугольник!");
            }
            //if (myRect.RenderedGeometry.Bounds.IntersectsWith(myEllipse.RenderedGeometry.Bounds) == true)
            //{
            //    MessageBox.Show("Точка входит в прямоугольник!");
            //}
        }
    }
}
