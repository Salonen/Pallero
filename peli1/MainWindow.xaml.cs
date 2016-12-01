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
        int re = 0, l = 0;
        int taso = 30;
        int speed = 20;
        //Line myLine = new Line();
        Line[] line = new Line[20*20*100];
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

        int[,] C2 = new int[400, 400];
        //int[,] pali = new int[10, 10];
        Random r = new Random();
        int px = 20, py = 20;
        int pisteet = 0,lask=0;

        Rectangle[] rec = new Rectangle[20*20*100];

        public MainWindow()
        {
            /*try
            {*/

            InitializeComponent(); 
           
            for (int x = 0; x < 400; x++)
            {
                for (int y = 0; y < 400; y++)
                {
                    C2[x, y] = 0;
                }
            }

        /*    for(int i=0;i<20*20;i++) {
                C.Children.Add(line[i]);
            for (int i = 0; i < 20 * 20; i++) */

                TeeP(px, py);
            AlustaK(20, 20, taso);
            TeeK(20,20);
            TeeR();
           
            myEl.Stroke = System.Windows.Media.Brushes.Red;
            myEl.Width = 40;
            myEl.Height = 50;
            
            Canvas.SetTop(myEl, myPa.Ypal - (myEl.ActualHeight) / 2); //
            Canvas.SetLeft(myEl, myPa.Xpal - (myEl.ActualWidth) / 2); //
            
            C.Children.Add(myEl);
            Point myP = new Point();
            myP.X = 200; 
            myP.Y = 200;

            Time = TimeSpan.Zero;
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(speed); // Muuttele tätä
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();

            /*}
            catch (Exception)
            {

                throw;
            }*/
        }

        private void AlustaK(int xkoko,int ykoko,int maara)
        {
            try
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
                }
            }
            ke.Lt[xkoko / 2][ykoko / 2] = 0;
            ke.Lt[xkoko / 2+1][ykoko / 2] = 0;
            ke.Lt[xkoko / 2][ykoko / 2+1] = 0;
            ke.Lt[xkoko / 2+1][ykoko / 2+1] = 0;
            ke.Lt[xkoko / 2 - 1][ykoko / 2] = 0;
            ke.Lt[xkoko / 2][ykoko / 2 - 1] = 0;
            ke.Lt[xkoko / 2 - 1][ykoko / 2 - 1] = 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void UusiK(int xkoko,int ykoko,int maara)
        {
            try
            {

                int[] taul = new int[maara];

                /*for (int i = 1; i <= xkoko; i++)
                {
                    List<int> list1 = new List<int>();
                    ke.Lt.Add(list1);
                }*/

                for (int i = 0; i < maara; i++)
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
                for (int i = 0; i < xkoko; i++)
                {
                    for (int j = 0; j < ykoko; j++)
                    {
                        if (l >= maara - 1)
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
                        ke.Lt[i][j]=taul[l++];
                    }
                }
                ke.Lt[xkoko / 2][ykoko / 2] = 0;
                ke.Lt[xkoko / 2 + 1][ykoko / 2] = 0;
                ke.Lt[xkoko / 2][ykoko / 2 + 1] = 0;
                ke.Lt[xkoko / 2 + 1][ykoko / 2 + 1] = 0;
                ke.Lt[xkoko / 2 - 1][ykoko / 2] = 0;
                ke.Lt[xkoko / 2][ykoko / 2 - 1] = 0;
                ke.Lt[xkoko / 2 - 1][ykoko / 2 - 1] = 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void TeeK(int xkoko,int ykoko) 
        {
            /* try
             {*/


            re = 0;
            l =0;
            for (int i = 0; i < xkoko; i++)
            {
                for (int j = 0; j < ykoko; j++)
                {
                    if (ke.Lt[i][j] == 1 || ke.Lt[i][j] == 2)
                            {
                        rec[re] = new Rectangle();
                                //Rectangle rec = new Rectangle();
                                Canvas.SetTop(rec[re], j * py); // VÄÄRINPÄIN OLIVAT
                                Canvas.SetLeft(rec[re], i * px);
                            rec[re].Width = px;
                            rec[re].Height = py;
                                if(ke.Lt[i][j] == 1) rec[re].Fill = new SolidColorBrush(Colors.Blue);
                                if (ke.Lt[i][j] == 2) rec[re].Fill = new SolidColorBrush(Colors.Green);
                            C.Children.Add(rec[re++]);
                            //C.Children.Remove(rec);
                            //C2[i *10, j *10] = 1;
                            LaitaP(i * px, j * py, ke.Lt[i][j]); 
                       
                    }
                    if (ke.Lt[i][j] == 3 || ke.Lt[i][j] == 5)
                    {
                        //Line myLine = new Line();
                        line[l] = new Line();
                        if (ke.Lt[i][j] == 3) line[l].Stroke = System.Windows.Media.Brushes.Blue;
                        if (ke.Lt[i][j] == 5) line[l].Stroke = System.Windows.Media.Brushes.Green;
                        line[l].X1 = i * px;
                        line[l].X2 = i * px + px;
                            line[l].Y1 = j * py + py / 2;
                            line[l].Y2 = j * py + py / 2;
                            line[l].HorizontalAlignment = HorizontalAlignment.Left;
                            line[l].VerticalAlignment = VerticalAlignment.Center;
                            line[l].StrokeThickness = 2;

                            C.Children.Add(line[l]);
                            LaitaL(line[l].X1, line[l].X2, line[l].Y1, line[l++].Y2, ke.Lt[i][j]);
                    }
                    if (ke.Lt[i][j] == 4 || ke.Lt[i][j] == 6)
                    {

                        line[l] = new Line();
                        if (ke.Lt[i][j] == 4) line[l].Stroke = System.Windows.Media.Brushes.Blue;
                        if (ke.Lt[i][j] == 6) line[l].Stroke = System.Windows.Media.Brushes.Green;
                            line[l].X1 = i * px + px / 2;
                            line[l].X2 = i * px + px / 2;
                            line[l].Y1 = j * py;
                            line[l].Y2 = j * py + py;
                            line[l].HorizontalAlignment = HorizontalAlignment.Left;
                            line[l].VerticalAlignment = VerticalAlignment.Center;
                            line[l].StrokeThickness = 2;
                            C.Children.Add(line[l]);

                            LaitaL(line[l].X1, line[l].X2, line[l].Y1, line[l++].Y2, ke.Lt[i][j]);

                    }
                }
            }
           /* }
            catch (Exception)
            {

                throw;
            }*/
        }

       /* private void TeeUusi(int xkoko, int ykoko)
        {
            /* try
             {*/


          /*  r = 0, l = 0;
            for (int i = 0; i < xkoko; i++)
            {
                for (int j = 0; j < ykoko; j++)
                {
                    if (ke.Lt[i][j] == 1 || ke.Lt[i][j] == 2)
                    {
                        //rec[r] = new Rectangle();
                        //Rectangle rec = new Rectangle();
                        Canvas.SetTop(rec[r], j * py); // VÄÄRINPÄIN OLIVAT
                        Canvas.SetLeft(rec[r], i * px);
                        rec[r].Width = px;
                        rec[r].Height = py;
                        if (ke.Lt[i][j] == 1) rec[r].Fill = new SolidColorBrush(Colors.Blue);
                        if (ke.Lt[i][j] == 2) rec[r].Fill = new SolidColorBrush(Colors.Green);
                        //C.Children.Add(rec[r++]);
                        //C.Children.Remove(rec);
                        //C2[i *10, j *10] = 1;
                        LaitaP(i * px, j * py, ke.Lt[i][j]);

                    }
                    if (ke.Lt[i][j] == 3 || ke.Lt[i][j] == 5)
                    {
                        //Line myLine = new Line();
                        //line[l] = new Line();
                        if (ke.Lt[i][j] == 3) line[l].Stroke = System.Windows.Media.Brushes.Blue;
                        if (ke.Lt[i][j] == 5) line[l].Stroke = System.Windows.Media.Brushes.Green;
                        line[l].X1 = i * px;
                        line[l].X2 = i * px + px;
                        line[l].Y1 = j * py + py / 2;
                        line[l].Y2 = j * py + py / 2;
                        line[l].HorizontalAlignment = HorizontalAlignment.Left;
                        line[l].VerticalAlignment = VerticalAlignment.Center;
                        line[l].StrokeThickness = 2;

                        //C.Children.Add(line[l]);
                        LaitaL(line[l].X1, line[l].X2, line[l].Y1, line[l++].Y2, ke.Lt[i][j]);
                    }
                    if (ke.Lt[i][j] == 4 || ke.Lt[i][j] == 6)
                    {

                        //line[l] = new Line();
                        if (ke.Lt[i][j] == 4) line[l].Stroke = System.Windows.Media.Brushes.Blue;
                        if (ke.Lt[i][j] == 6) line[l].Stroke = System.Windows.Media.Brushes.Green;
                        line[l].X1 = i * px + px / 2;
                        line[l].X2 = i * px + px / 2;
                        line[l].Y1 = j * py;
                        line[l].Y2 = j * py + py;
                        line[l].HorizontalAlignment = HorizontalAlignment.Left;
                        line[l].VerticalAlignment = VerticalAlignment.Center;
                        line[l].StrokeThickness = 2;
                        //C.Children.Add(line[l]);

                        LaitaL(line[l].X1, line[l].X2, line[l].Y1, line[l++].Y2, ke.Lt[i][j]);

                    }
                }
            }*/
            /* }
             catch (Exception)
             {

                 throw;
             }*/
        //}

        private void AddPixel(double x, double y, Color c) // tätä ei käytetä hitauden vuoksi
        {
            try
            {

            
            Rectangle rec = new Rectangle();
            Canvas.SetTop(rec, y);
            Canvas.SetLeft(rec, x);
            rec.Width = 1;
            rec.Height = 1;
            rec.Fill = new SolidColorBrush(c);
            C.Children.Add(rec);
            }
            catch (Exception)
            {

                throw;
            }
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
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {

           /* try
            {*/

            
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
                    if (pisteet > 10)
                    {
                    //speed -= speed > 5 ? 1 : 0;
                    timer.Interval = TimeSpan.FromMilliseconds(speed);
                    taso -= taso > 5 ? 1 : 0;
                    //tyhjennä canvas kopio
                    for(int i = 0; i < 400; i++)
                    {
                        for (int j = 0; j < 400; j++)
                        {
                            C2[i,j] = 0;
                        }
                    }

                    UusiK(20, 20, taso);
                    for (int i = 0; i < re; i++) C.Children.Remove(rec[i]);
                    for (int i = 0; i < l; i++) C.Children.Remove(line[i]);
                    TeeK(20, 20);
                        myPa.Xpal = 200;
                        myPa.Ypal = 200;
                        myPa.Xspeed = 0;
                        myPa.Yspeed = 0;
                    pisteet = 0;
                    
                }
            }
                       
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
            
            if (Keyboard.IsKeyDown(Key.Up))
            {
                if (myPa.Yspeed > -5) myPa.Yspeed--;
            }
            if (Keyboard.IsKeyDown(Key.Down))
            {
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
            /*}
            catch (Exception)
            {

                throw;
            }*/

        }

        private void TeeR()
        {
            try
            {

            
            myLine2.Stroke = System.Windows.Media.Brushes.LightSteelBlue;
            myLine2.X1 = 1;
            myLine2.X2 = 400;
            myLine2.Y1 = 1;
            myLine2.Y2 = 1;
            myLine2.HorizontalAlignment = HorizontalAlignment.Left;
            myLine2.VerticalAlignment = VerticalAlignment.Center;
            myLine2.StrokeThickness = 2;
            C.Children.Add(myLine2);

            myLine3.Stroke = System.Windows.Media.Brushes.LightSteelBlue;
            myLine3.X1 = 1;
            myLine3.X2 = 400;
            myLine3.Y1 = 400;
            myLine3.Y2 = 400;
            myLine3.HorizontalAlignment = HorizontalAlignment.Left;
            myLine3.VerticalAlignment = VerticalAlignment.Center;
            myLine3.StrokeThickness = 2;
            C.Children.Add(myLine3);

            myLine4.Stroke = System.Windows.Media.Brushes.LightSteelBlue;
            myLine4.X1 = 1;
            myLine4.X2 = 1;
            myLine4.Y1 = 1;
            myLine4.Y2 = 400;
            myLine4.HorizontalAlignment = HorizontalAlignment.Left;
            myLine4.VerticalAlignment = VerticalAlignment.Center;
            myLine4.StrokeThickness = 2;
            C.Children.Add(myLine4);

            myLine5.Stroke = System.Windows.Media.Brushes.LightSteelBlue;
            myLine5.X1 = 400;
            myLine5.X2 = 400;
            myLine5.Y1 = 1;
            myLine5.Y2 = 400;
            myLine5.HorizontalAlignment = HorizontalAlignment.Left;
            myLine5.VerticalAlignment = VerticalAlignment.Center;
            myLine5.StrokeThickness = 2;
            C.Children.Add(myLine5);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void TeeP(int xkoko,int ykoko)
        {

            try
            {

            
            for (int i = 0; i < xkoko; i++)
            {
                List<int> list1 = new List<int>();
                myPal.Pal.Add(list1);
            }

            for (int i = 0; i < xkoko; i++)
            {
                for (int j = 0; j < ykoko; j++)
                {
                    myPal.Pal[i].Add(1);
                }
            }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void LaitaP(double x2, double y2, int laatu)
        {
            try
            {

            
            for (double y = 0; y < myPal.Pal[0].Count; y++)
            {
                for (double x = 0; x < myPal.Pal.Count; x++)
                {
                    C2[(int)(x2 + x),(int)( y2 + y)] = laatu;
                }
            }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void LaitaL(double x2, double x3, double y2, double y3, int laatu)
        {

            try
            {

            
            int lisa = 0;
            if (x3 - x2 == 0) lisa = 1;
            int lisa2 = 0;
            if (y3 - y2 == 0) lisa2 = 1;
            for (int y = 0; y < y3-y2+lisa2; y++)
            {
                for (int x = 0; x < x3-x2+lisa; x++)
                {
                    C2[(int)(x2 + x),(int) (y2 + y)] = laatu;
                }
            }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

}

