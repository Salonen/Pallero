/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls;

namespace peli1.Test
{
    [TestFixture]

    public partial class MainWindow
    {
            
        [Test]
        private void TeeK()
        {
             for (int x = 0; x < 50; x++)
            {
                for (int y = 0; y < 50; y++)
                {
                    AddPixel(x, y, Colors.Blue);
                    C2[x, y] = 1;
                }
            }

        }
        [Test]
        private void AddPixel(double x, double y, Color c)
        {
            Rectangle rec = new Rectangle();
            Canvas.SetTop(rec, y);
            Canvas.SetLeft(rec, x);
            rec.Width = 1;
            rec.Height = 1;
            rec.Fill = new SolidColorBrush(c);
            C.Children.Add(rec);

        }

        public TimeSpan Time
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
        [Test]
        void timer_Tick(object sender, EventArgs e)
        {

            Time += TimeSpan.FromMilliseconds(100);

            textBox.Text = "";
            if (C2[myPa.Xpal, myPa.Ypal] == 1) textBox.Text = "Game over";

            myLine.Stroke = System.Windows.Media.Brushes.LightSteelBlue;
            myLine.X1 = rnd.Next(100);
            myLine.X2 = rnd.Next(100);
            myLine.Y1 = rnd.Next(100);
            myLine.Y2 = rnd.Next(100);
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


            Canvas.SetTop(myEl, myPa.Ypal - (myEl.ActualHeight) / 2); //
            Canvas.SetLeft(myEl, myPa.Xpal - (myEl.ActualWidth) / 2); //


            myLine.HorizontalAlignment = HorizontalAlignment.Left;
            myLine.VerticalAlignment = VerticalAlignment.Center;
            myLine.StrokeThickness = 2;
            // Uses the Keyboard.IsKeyDown to determine if a key is down.
            // e is an instance of KeyEventArgs.
            if (Keyboard.IsKeyDown(Key.Up))
            {
                /*if (myPa.Yspeed > 0) myPa.Yspeed--;
                else if (myPa.Yspeed < 0) myPa.Yspeed--;
                else if (myPa.Yspeed == 0) myPa.Yspeed--;*/
/*                if (myPa.Yspeed > -5) myPa.Yspeed--;
            }
            if (Keyboard.IsKeyDown(Key.Down))
            {
                /*if (myPa.Yspeed > 0) myPa.Yspeed++;
                else if (myPa.Yspeed < 0) myPa.Yspeed--;
                else if (myPa.Yspeed == 0) myPa.Yspeed--;*/
/*                if (myPa.Yspeed < 5) myPa.Yspeed++;
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
/*        }
        [Test]
        private void TeeR()
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
        }
        [Test]
        private void TeeP()
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
/*            for (int i = 1; i <= 10; i++)
            {
                List<int> list1 = new List<int>();
                myPal.Pal.Add(list1);
            }

            // Populating the lists
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    myPal.Pal[i].Add(1);
                }
            }

        }

        /*private void aseP()
        {
            /*Rectangle rec = new Rectangle();
            Canvas.SetTop(rec, y);
            Canvas.SetLeft(rec, x);
            rec.Width = 1;
            rec.Height = 1;
            rec.Fill = new SolidColorBrush(c);
            C.Children.Add(rec);*/
        /* for (int y = 0; y < myPal.Pal[0].Count; y++)
         {
             for (int x = 0; x < myPal.Pal.Count; x++)
             {
                 myPal.Pal[x][y] = 1;
                 /*AddPixel(x, y, Colors.Blue);
                 C2[x, y] = 1;*/
        /*   }
       }

   }*/
/*        [Test]
        private void LaitaP(int x2, int y2)
        {
            /*Rectangle rec = new Rectangle();
            Canvas.SetTop(rec, y);
            Canvas.SetLeft(rec, x);
            rec.Width = 1;
            rec.Height = 1;
            rec.Fill = new SolidColorBrush(c);
            C.Children.Add(rec);*/
/*            for (int y = 0; y < myPal.Pal[0].Count; y++)
            {
                for (int x = 0; x < myPal.Pal.Count; x++)
                {
                    AddPixel(x2 + x, y2 + y, Colors.Blue);
                    C2[x2 + x, y2 + y] = 1;
                }
            }

        }
    }
}*/
