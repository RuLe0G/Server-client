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
using System.Windows.Threading;

namespace _2D_WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// pack://application:,,,/pic/cover2.jpg
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        int currentFrame = 0;

        //кадров в анимациях
        int[] animations = new int[] { 7, 7, 7, 7, 8, 8, 8, 8, 9, 9, 9, 9, 6, 6, 6, 6, 13, 13, 13, 13, 6};
        //номер текущей анимации
        int animationIndex = 0;

        int frameCount = 7; 
        int currentRow = 20;
        double frameW = 64;//85.5;
        double frameH = 64;//85.5;

        double kW = 1.0;
        double kH = 1.0;

        Rectangle skeleton = new Rectangle();
        int Ticks = 0;

        public MainWindow()
        {
            InitializeComponent();

            frameCount = animations[animationIndex];

            timer.Tick += new EventHandler(dispatcherTimer_Tick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 120);
            timer.Start();


            //создание объекта многоугольник
            Polygon myPolygon = new Polygon();
            ImageBrush ib = new ImageBrush();
            ib.AlignmentX = AlignmentX.Left;
            ib.AlignmentY = AlignmentY.Top;
            //установка цвета обводки, цвета заливки и толщины обводки
            ib.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/pic/cover2.jpg", UriKind.Absolute));
            myPolygon.Stroke = Brushes.Black;
            myPolygon.Fill = ib;
            myPolygon.StrokeThickness = 2;
            //позиционирование объекта
            myPolygon.HorizontalAlignment = HorizontalAlignment.Left;
            myPolygon.VerticalAlignment = VerticalAlignment.Center;
            //создание точек многоугольника
            Point Point1 = new Point(0, 0);
            Point Point2 = new Point(100, 0);
            Point Point3 = new Point(100, 50);
            Point Point4 = new Point(50, 100);
            Point Point5 = new Point(0, 50);
            //создание и заполнение коллекции точек
            PointCollection myPointCollection = new PointCollection();
            myPointCollection.Add(Point1);
            myPointCollection.Add(Point2);
            myPointCollection.Add(Point3);
            myPointCollection.Add(Point4);
            myPointCollection.Add(Point5);
            //установка коллекции точек в объект многоугольник
            myPolygon.Points = myPointCollection;
            //добавление многоугольника в сцену
            scene.Children.Add(myPolygon);

            // кисть для заполнения прямоугольника фрагментом изображения
            ImageBrush ib1 = new ImageBrush();


            // настройки, позиция изображения будет указана как координаты левого верхнего угла
            // загрузка изображения и назначение кисти
            ib1.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/pic/skeleton.png", UriKind.Absolute));
            //ib1.ImageSource.dpi
            // изображение будет выведено без растяжения/ сжатия
            ib1.AlignmentX = AlignmentX.Left;
            ib1.AlignmentY = AlignmentY.Top;
            ib1.Stretch = Stretch.None;
            ib1.ViewboxUnits = BrushMappingMode.Absolute;

            //DPI картинки должно быть равно 96
            //получить реальное Dpi можно при помощи(ib1.ImageSource as BitmapSource).DpiX
            //поделив 96 на(ib1.ImageSource as BitmapSource).DpiX можно получить коэффициент масштабирования ширины

             //альтернативный вариант
            // вычисления коэффициента масштабирования фрейма
            kW = ib1.ImageSource.Width / (ib1.ImageSource as BitmapSource).PixelWidth;
            kH = ib1.ImageSource.Height / (ib1.ImageSource as BitmapSource).PixelHeight;
           // масштабирование высоты и ширины
            frameW = frameW * kW;
            frameH = frameH * kH;


           // участок изображения который будет нарисован
           // в данном случае, второй кадр первой строки
            ib1.Viewbox = new Rect(0, 0, frameW, frameH);

            //ширина и высота прямоугольника, совпадает с размерами кадра
            skeleton.Height = frameH;
            skeleton.Width = frameW;
            skeleton.Stroke = Brushes.LightSteelBlue;
            skeleton.StrokeThickness = 2;

            skeleton.Fill = ib1;
           // изначальная позиция прямоугольника

            skeleton.Margin = new Thickness(0, 0, 0, 0);
            //добавление прямоугольника в сцену
            scene.Children.Add(skeleton);
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            //if (currentFrame == 7) currentFrame = 0;
            currentFrame = (currentFrame + 1 + frameCount) % frameCount;
            var frameLeft = currentFrame * frameW;
            var frameTop = animationIndex * frameH;// currentRow * frameH;
            (skeleton.Fill as ImageBrush).Viewbox = new Rect(frameLeft, frameTop, frameLeft + frameW, frameTop + frameH);

            if (currentFrame == animations[animationIndex]-1)
            {
                //currentRow++;
                animationIndex++;
                if (currentRow > 20) currentRow = 0;
                if (animationIndex == animations.Length) animationIndex = 0;
                frameCount = animations[animationIndex];
                currentFrame = 0;
            }
             l1.Content = frameLeft + " " + (frameLeft + frameW);
             l2.Content = frameTop + " " + (frameTop + frameH);

        }

    }

}
