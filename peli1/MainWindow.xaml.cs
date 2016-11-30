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
using System.Threading;
using System.Timers;
using System.Windows.Threading;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Media;
using NUnit.Framework;

namespace peli1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 


    //[TestFixture] using
    

    public partial class MainWindow : Window
    {
         
        int n = 0;
        //Line myLine = new Line();
        Line[] lines = new Line[1000];
        public DispatcherTimer timer;
        TimeSpan time;

        Random rnd = new Random();
        //Line myLine = new Line();
        Line myLine2 = new Line();
        Line myLine3 = new Line();
        Line myLine4 = new Line();
        Line myLine5 = new Line();
        Ellipse myEl = new Ellipse();
        Pallero myPa = new Pallero(0, 0, 100, 100);
        Pali myPal = new Pali();
        Kentta ke = new Kentta();

        int[,] C2 = new int[200, 200];
        //int[,] pali = new int[10, 10];
        Random r = new Random();
        int px = 20, py = 20;
        int pisteet = 0,lask=0;
                
        public MainWindow()
        { 
            InitializeComponent(); 
            /*myLine.Stroke = System.Windows.Media.Brushes.LightSteelBlue;
            myLine.X1 = n;
            myLine.X2 = 50;
            myLine.Y1 = n++;
            myLine.Y2 = 50;*/
            //C.SetValue.ActualHeight(100);

            //double[][] C2;
            //double a = C.ActualWidth()int[,] arr = new int[100, 100]; ;
            

            for (int x = 0; x < 200; x++)
            {
                for (int y = 0; y < 200; y++)
                {
                    //AddPixel(x, y, Colors.Blue);
                    C2[x, y] = 0;
                }
            }

            

            //    Linja(0, 0, C.ActualWidth, C, 0);
            /*myLine.Stroke = System.Windows.Media.Brushes.LightSteelBlue;
            myLine.X1 = rnd.Next(100);
            myLine.X2 = rnd.Next(100);
            myLine.Y1 = rnd.Next(100);
            myLine.Y2 = rnd.Next(100);
            myLine.HorizontalAlignment = HorizontalAlignment.Left;
            myLine.VerticalAlignment = VerticalAlignment.Center;
            myLine.StrokeThickness = 2;
            C.Children.Add(myLine);*/

            TeeP(px, py);
            AlustaK(10, 10, 10);
            TeeK(10,10);
            TeeR();
            
            //TeeK2();
            //aseP();
            //LaitaP(100, 100, myPal);

            myEl.Stroke = System.Windows.Media.Brushes.Red;
            myEl.Width = 40;
            myEl.Height = 50;
            /*Canvas.SetTop(myEl, 100);
            Canvas.SetLeft(myEl, 100);*/
            Canvas.SetTop(myEl, myPa.Ypal - (myEl.ActualHeight) / 2); //
            Canvas.SetLeft(myEl, myPa.Xpal - (myEl.ActualWidth) / 2); //
            //myEl.Canvas=10;
            C.Children.Add(myEl);
            Point myP = new Point();
            myP.X = 100; 
            myP.Y = 100;

            Time = TimeSpan.Zero;
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(20); // Muuttele tätä
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
            /*Color  t = Colors.Yellow;

            AddPixel(150, 150, Colors.Red);
            t = GetPixelColor(myP);*/
/*            for (int i = 0; i < 40; i++)
            {
                //C.SetPixel(C, 140 + 1, 140, RGB(10, 10,10)); 
                AddPixel(170 + i, 170, Colors.Red);

            }*/


        }

        private int AlustaK(int xkoko,int ykoko,int maara)
        {
            int[] taul = new int[maara];
            
            for (int i = 1; i <= xkoko; i++)
            {
                List<int> list1 = new List<int>();
                ke.Lt.Add(list1);
            }

            for(int i = 0; i < maara; i++)
            {
                taul[i] = 0;
            }
            taul[r.Next(maara)] = 1;
            taul[r.Next(maara)] = 2;
            taul[r.Next(maara)] = 3;
            taul[r.Next(maara)] = 4;
            taul[r.Next(maara)] = 5;
            taul[r.Next(maara)] = 6;
            int l = 0;
            // Populating the lists
            for (int i = 0; i < xkoko; i++)
            {
                for (int j = 0; j < ykoko; j++)
                {
                    if (l >= maara-1)
                    {
                        l = 0;
                        for (int k = 0; k < maara; k++)
                        {
                            taul[k] = 0;
                        }
                        taul[r.Next(maara)] = 1;
                        taul[r.Next(maara)] = 2;
                        taul[r.Next(maara)] = 3;
                        taul[r.Next(maara)] = 4;
                        taul[r.Next(maara)] = 5;
                        taul[r.Next(maara)] = 6;
                        lask++;
                    }
                    ke.Lt[i].Add(taul[l++]);
                    //ke.Lt[i].Add(taul[l++]);
                }
            }
            ke.Lt[xkoko / 2][ykoko / 2] = 0;
            ke.Lt[xkoko / 2+1][ykoko / 2] = 0;
            ke.Lt[xkoko / 2][ykoko / 2+1] = 0;
            ke.Lt[xkoko / 2+1][ykoko / 2+1] = 0;
            //ke.Lt[xkoko / 2][ykoko / 2] = 0;
            ke.Lt[xkoko / 2 - 1][ykoko / 2] = 0;
            ke.Lt[xkoko / 2][ykoko / 2 - 1] = 0;
            ke.Lt[xkoko / 2 - 1][ykoko / 2 - 1] = 0;
            return maara;
        }

        private int TeeK(int xkoko,int ykoko) 
        {
            /*Rectangle rec = new Rectangle();
            Canvas.SetTop(rec, y);
            Canvas.SetLeft(rec, x);
            rec.Width = 1;
            rec.Height = 1;
            rec.Fill = new SolidColorBrush(c);
            C.Children.Add(rec);*/
            for (int i = 0; i < xkoko; i++)
            {
                for (int j = 0; j < ykoko; j++)
                {
                    if (ke.Lt[i][j] == 1 || ke.Lt[i][j] == 2)
                            {

                                Rectangle rec = new Rectangle();
                                Canvas.SetTop(rec, j * py); // VÄÄRINPÄIN OLIVAT
                                Canvas.SetLeft(rec, i * px); 
                                rec.Width = px;
                                rec.Height = py;
                                if(ke.Lt[i][j] == 1) rec.Fill = new SolidColorBrush(Colors.Blue);
                                if (ke.Lt[i][j] == 2) rec.Fill = new SolidColorBrush(Colors.Green);
                        C.Children.Add(rec);
                        //C2[i *10, j *10] = 1;
                        LaitaP(i * px, j * py, ke.Lt[i][j]); 
                       
                    }
                    if (ke.Lt[i][j] == 3 || ke.Lt[i][j] == 5)
                    {
                        Line myLine = new Line();
                        if (ke.Lt[i][j] == 3) myLine.Stroke = System.Windows.Media.Brushes.Blue;
                        if (ke.Lt[i][j] == 5) myLine.Stroke = System.Windows.Media.Brushes.Green;
                        myLine.X1 = i * px;
                        myLine.X2 = i * px + px;
                        myLine.Y1 = j * py + py / 2;
                        myLine.Y2 = j * py + py / 2;
                        myLine.HorizontalAlignment = HorizontalAlignment.Left;
                        myLine.VerticalAlignment = VerticalAlignment.Center;
                        myLine.StrokeThickness = 2;
                        C.Children.Add(myLine);

                        LaitaL(myLine.X1, myLine.X2, myLine.Y1, myLine.Y2, ke.Lt[i][j]);
                    }
                    if (ke.Lt[i][j] == 4 || ke.Lt[i][j] == 6)
                    {

                        Line myLine = new Line();
                        if (ke.Lt[i][j] == 4) myLine.Stroke = System.Windows.Media.Brushes.Blue;
                        if (ke.Lt[i][j] == 6) myLine.Stroke = System.Windows.Media.Brushes.Green;
                        myLine.X1 = i * px + px / 2;
                        myLine.X2 = i * px + px / 2;
                        myLine.Y1 = j * py;
                        myLine.Y2 = j * py + py;
                        myLine.HorizontalAlignment = HorizontalAlignment.Left;
                        myLine.VerticalAlignment = VerticalAlignment.Center;
                        myLine.StrokeThickness = 2;
                        C.Children.Add(myLine);

                        LaitaL(myLine.X1, myLine.X2, myLine.Y1, myLine.Y2, ke.Lt[i][j]);

                    }
                }
            }
            return xkoko*ykoko;

        }

        private double AddPixel(double x, double y, Color c)
        {
            Rectangle rec = new Rectangle();
            Canvas.SetTop(rec, y);
            Canvas.SetLeft(rec, x);
            rec.Width = 1;
            rec.Height = 1;
            rec.Fill = new SolidColorBrush(c);
            C.Children.Add(rec);
            return x * y;
        }

        private TimeSpan Time
        {
            get
            {
                return time;
            }
            set
            {
                time = value;
                //OnPropertyChanged("Time");
                //infoPanel.Time = time;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {

            Time += TimeSpan.FromMilliseconds(100);

            textBox.Text = "";
            if (C2[myPa.Xpal, myPa.Ypal] == 1 || C2[myPa.Xpal, myPa.Ypal] == 3 || C2[myPa.Xpal, myPa.Ypal] == 4)
            {
                textBox.Text = "Game over";
                pisteet = 0;
                textBox1.Text = "Pisteet" + (pisteet).ToString();
            }
            if ((C2[myPa.Xpal, myPa.Ypal] == 2 || C2[myPa.Xpal, myPa.Ypal] == 5 || C2[myPa.Xpal, myPa.Ypal] == 6) && (myPa.Xspeed != 0 || myPa.Yspeed != 0))
            {
                textBox1.Text = "Pisteet" + (pisteet++).ToString();
                //ke.Lt[myPa.Xpal / px][myPa.Ypal / py] = 0; lask--
            }

            /*myLine.Stroke = System.Windows.Media.Brushes.LightSteelBlue;
            myLine.X1 = rnd.Next(100);
            myLine.X2 = rnd.Next(100);
            myLine.Y1 = rnd.Next(100);
            myLine.Y2 = rnd.Next(100);*/
            if (myPa.Xspeed > 0)
            {
                if (myPa.Xpal < C.ActualWidth - myPa.Xspeed) myPa.Xpal += myPa.Xspeed;
                else myPa.Xspeed = -myPa.Xspeed;
            }
            else if (myPa.Xspeed < 0)
            {
                if (myPa.Xpal > 0 - myPa.Xspeed) myPa.Xpal += myPa.Xspeed;
                else myPa.Xspeed = -myPa.Xspeed;
            }
            if (myPa.Yspeed > 0)
            {
                if (myPa.Ypal < C.ActualHeight - myPa.Yspeed) myPa.Ypal += myPa.Yspeed;
                else myPa.Yspeed = -myPa.Yspeed;
            }
            else if (myPa.Yspeed < 0)
            {
                if (myPa.Ypal > 0 - myPa.Yspeed) myPa.Ypal += myPa.Yspeed;
                else myPa.Yspeed = -myPa.Yspeed;
            }


            Canvas.SetTop(myEl, myPa.Ypal - (myEl.ActualHeight)/2); //
            Canvas.SetLeft(myEl, myPa.Xpal - (myEl.ActualWidth)/2); //

             
            /*myLine.HorizontalAlignment = HorizontalAlignment.Left;
            myLine.VerticalAlignment = VerticalAlignment.Center;
            myLine.StrokeThickness = 2;*/
            // Uses the Keyboard.IsKeyDown to determine if a key is down.
            // e is an instance of KeyEventArgs.
            if (Keyboard.IsKeyDown(Key.Up))
            {
                /*if (myPa.Yspeed > 0) myPa.Yspeed--;
                else if (myPa.Yspeed < 0) myPa.Yspeed--;
                else if (myPa.Yspeed == 0) myPa.Yspeed--;*/
                if (myPa.Yspeed > -5) myPa.Yspeed--;
            }
            if (Keyboard.IsKeyDown(Key.Down))
            {
                /*if (myPa.Yspeed > 0) myPa.Yspeed++;
                else if (myPa.Yspeed < 0) myPa.Yspeed--;
                else if (myPa.Yspeed == 0) myPa.Yspeed--;*/
                if (myPa.Yspeed < 5) myPa.Yspeed++;
            }
            if (Keyboard.IsKeyDown(Key.Right))
            {
                if (myPa.Xspeed < 5) myPa.Xspeed++;
            }
            if (Keyboard.IsKeyDown(Key.Left))
            {
                if (myPa.Xspeed > -5) myPa.Xspeed--;
            }
            //C.Children.Add(myLine);


            /*ball.MoveBall();
            CheckWallCollisions();
            CheckPaddleCollisions();
            CheckBrickCollisions();*/
        }

        private int TeeR()
        {
            myLine2.Stroke = System.Windows.Media.Brushes.LightSteelBlue;
            myLine2.X1 = 1;
            myLine2.X2 = 200;
            myLine2.Y1 = 1;
            myLine2.Y2 = 1;
            myLine2.HorizontalAlignment = HorizontalAlignment.Left;
            myLine2.VerticalAlignment = VerticalAlignment.Center;
            myLine2.StrokeThickness = 2;
            C.Children.Add(myLine2);

            myLine3.Stroke = System.Windows.Media.Brushes.LightSteelBlue;
            myLine3.X1 = 1;
            myLine3.X2 = 200;
            myLine3.Y1 = 200;
            myLine3.Y2 = 200;
            myLine3.HorizontalAlignment = HorizontalAlignment.Left;
            myLine3.VerticalAlignment = VerticalAlignment.Center;
            myLine3.StrokeThickness = 2;
            C.Children.Add(myLine3);

            myLine4.Stroke = System.Windows.Media.Brushes.LightSteelBlue;
            myLine4.X1 = 1;
            myLine4.X2 = 1;
            myLine4.Y1 = 1;
            myLine4.Y2 = 200;
            myLine4.HorizontalAlignment = HorizontalAlignment.Left;
            myLine4.VerticalAlignment = VerticalAlignment.Center;
            myLine4.StrokeThickness = 2;
            C.Children.Add(myLine4);

            myLine5.Stroke = System.Windows.Media.Brushes.LightSteelBlue;
            myLine5.X1 = 200;
            myLine5.X2 = 200;
            myLine5.Y1 = 1;
            myLine5.Y2 = 200;
            myLine5.HorizontalAlignment = HorizontalAlignment.Left;
            myLine5.VerticalAlignment = VerticalAlignment.Center;
            myLine5.StrokeThickness = 2;
            C.Children.Add(myLine5);
            return 200;
        }

        private int TeeP(int xkoko,int ykoko)
        {
            /*for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    //AddPixel(x, y, Colors.Blue);


                    /*List<List<int>> myPal.Pali = new List<List<int>>(); //Creates new nested List
                    matrix.Add(new List<int>()); //Adds new sub List
                    myPal.Pal[x].Add(1);*/
            /*        }
                }*/
            for (int i = 0; i < xkoko; i++)
            {
                List<int> list1 = new List<int>();
                myPal.Pal.Add(list1);
            }

            // Populating the lists
            for (int i = 0; i < xkoko; i++)
            {
                for (int j = 0; j < ykoko; j++)
                {
                    myPal.Pal[i].Add(1);
                }
            }
            //return myPal.Pal; TEE TÄMÄ
            return xkoko + ykoko;
        }

        private double LaitaP(double x2, double y2, int laatu)
        {
            /*Rectangle rec = new Rectangle();
            Canvas.SetTop(rec, y);
            Canvas.SetLeft(rec, x);
            rec.Width = 1;
            rec.Height = 1;
            rec.Fill = new SolidColorBrush(c);
            C.Children.Add(rec);*/
            for (double y = 0; y < myPal.Pal[0].Count; y++)
            {
                for (double x = 0; x < myPal.Pal.Count; x++)
                {
                    //AddPixel(x2+x, y2+y, Colors.Blue);
                    C2[(int)(x2 + x),(int)( y2 + y)] = laatu;//myPal.Pal[x][y];
                }
            }
            return x2 * x2 + y2 * y2;
        }

        private double LaitaL(double x2, double x3, double y2, double y3, int laatu)
        {
            /*Rectangle rec = new Rectangle();
            Canvas.SetTop(rec, y);
            Canvas.SetLeft(rec, x);
            rec.Width = 1;
            rec.Height = 1;
            rec.Fill = new SolidColorBrush(c);
            C.Children.Add(rec);*/
            /*if (y3 - y2 == 0)
            {
                while(x2<x3) C2[(int)(x2++), (int)(y2)] = laatu;
            }
            if (x3 - x2 == 0)
            {
                while (y2 < y3) C2[(int)(x2), (int)(y2++)] = laatu;
            }*/

            int lisa = 0;
            if (x3 - x2 == 0) lisa = 1;
            int lisa2 = 0;
            if (y3 - y2 == 0) lisa2 = 1;
            for (int y = 0; y < y3-y2+lisa2; y++)
            {
                for (int x = 0; x < x3-x2+lisa; x++)
                {
                    //AddPixel(x2+x, y2+y, Colors.Blue);
                    C2[(int)(x2 + x),(int) (y2 + y)] = laatu;//myPal.Pal[x][y];
                }
            }
            return x2 * x2 + y2 * y2;
        }
    }

}

