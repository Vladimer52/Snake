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

namespace snake
{
    
    class Snake
    {
        private int scale = 30;
        public Snake()
        {
           
        }
        public UIElement CreateSnake(Point point)
        {
                Ellipse elipse = new Ellipse();
                elipse.Width = scale;
                elipse.Height = scale;
                elipse.Fill = Brushes.Red;
                Canvas.SetLeft(elipse, point.X);
            Canvas.SetTop(elipse, point.Y);

            return elipse;
        }

    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        void GenerateMap(int scaleCells)
        {
            for (int i = 0; i <= 800-scaleCells; i+=scaleCells)
            {
                Line line = new Line();
                line.X1 = line.X2 = i;
                line.Y1 = 0;
                line.Y2 = 800;
                line.Stroke = Brushes.Black;
                CanvasMain.Children.Add(line);
            }
            for (int i = 0; i <= 800 - scaleCells; i += scaleCells)
            {
                Line line = new Line();
                line.Y1 = line.Y2 = i;
                line.X1 = 0;
                line.X2 = 800;
                line.Stroke = Brushes.Black;
                CanvasMain.Children.Add(line);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Snake snake = new Snake();
            Random rnd = new Random();
            int min = 0;
            int max = 800;
            int scale = 30;
            CanvasMain.Children.Add(snake.CreateSnake(new Point(rnd.Next((max - min) / scale) * scale + min, rnd.Next((max - min) / scale) * scale + min)));

            GenerateMap(30);
        }
    }
}
