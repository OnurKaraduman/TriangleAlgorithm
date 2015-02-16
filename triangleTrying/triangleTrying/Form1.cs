using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;

namespace triangleTrying
{
    public partial class Form1 : Form
    {
        #region global variables
        triangle trianMin = new triangle();
        double circleMin = 0;
        List<Point> myPoint = new List<System.Drawing.Point>();
        Graphics graphicObj;
        Pen myPen = new System.Drawing.Pen(Color.WhiteSmoke, 5);
        Pen myPen2 = new System.Drawing.Pen(Color.Yellow, 2);
        SolidBrush myBrush = new System.Drawing.SolidBrush(Color.Gold);
        SolidBrush myBrush2 = new System.Drawing.SolidBrush(Color.Wheat);
        triangle[] trian;// = new triangle[10];
        //List<triangle> trian = new List<triangle>();
        int triangleCount = 0;
        Point lastPoint;
        #endregion

        #region Triangle Structre

        public struct triangle
        {
            //A
            public int vertex1;
            //B
            public int vertex2;
            //C
            public int vertex3;
        }
        #endregion

        public Form1()
        {
            InitializeComponent();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized; //maximum size
            textBox1.Select();

        }

        //for painting
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            graphicObj = this.CreateGraphics();
            myPen.Width = 3;
        }

        #region clickFunction
        private void button2_Click(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            int n = Convert.ToInt32(textBox1.Text);
            double size = calculatingFac(n) / ((calculatingFac(n - 3) * calculatingFac(3)));
            trian = new triangle[Convert.ToInt32(calculatingFac(n) / (calculatingFac(3) * calculatingFac(n - 3)))];
            //  MessageBox.Show(trian.Length.ToString());

            Font drawFont = new System.Drawing.Font("Arial", 15);
            SolidBrush drawBrush = new System.Drawing.SolidBrush(Color.Wheat);
            StringFormat drawFormat = new System.Drawing.StringFormat();
            drawFormat.FormatFlags = System.Drawing.StringFormatFlags.DirectionVertical;
            Random rnd = new Random();
            int i = 0;
            Form frm = new Form1();
            int a, b;

            //defined for x, y coordinate.
            while (i < Convert.ToInt32(textBox1.Text))
            {

                //create for x
                a = rnd.Next(210, frm.Width - 10);

                //create for y
                b = rnd.Next(20, frm.Height - 10);

                //add the coordinate to array of myPoint 
                myPoint.Add(new System.Drawing.Point(a, b));

                //draw for point like a full Ellipse
                graphicObj.FillEllipse(myBrush2, myPoint[i].X, myPoint[i].Y, 10, 10);

                //write point number above point
                graphicObj.DrawString(i.ToString(), drawFont, drawBrush, a, b - 20);
                i++;
            }
            watch.Stop();
            listBox2.Items.Add("Max count of triangle: " + size);
            listBox2.Items.Add("time of point: " + watch.Elapsed.Milliseconds.ToString() + " msec");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            calculatingArea();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            calculatingU();
        }
        //max area
        private void button5_Click(object sender, EventArgs e)
        {
            double min1 = 0;
            double min2 = 0;
            int minI = 0;
            double u = 0;
            double a, b, c;
            int i;
            for (i = 0; i < triangleCount; i++)
            {
                a = Math.Pow(Math.Abs(myPoint[trian[i].vertex1].X - myPoint[trian[i].vertex2].X), 2) + Math.Pow(Math.Abs(myPoint[trian[i].vertex1].Y - myPoint[trian[i].vertex2].Y), 2);
                b = Math.Pow(Math.Abs(myPoint[trian[i].vertex2].X - myPoint[trian[i].vertex3].X), 2) + Math.Pow(Math.Abs(myPoint[trian[i].vertex2].Y - myPoint[trian[i].vertex3].Y), 2);
                c = Math.Pow(Math.Abs(myPoint[trian[i].vertex1].X - myPoint[trian[i].vertex3].X), 2) + Math.Pow(Math.Abs(myPoint[trian[i].vertex1].Y - myPoint[trian[i].vertex3].Y), 2);
                a = Math.Sqrt(a);
                b = Math.Sqrt(b);
                c = Math.Sqrt(c);
                u = (a + b + c) / 2;
                min2 = Math.Sqrt(u * (u - a) * (u - b) * (u - c));
                if (min1 == 0)
                {
                    min1 = min2;
                    minI = i;
                }
                else
                {
                    if (min2 > min1)
                    {
                        min1 = min2;
                        minI = i;
                    }
                }
            }
            graphicObj.DrawLine(myPen2, myPoint[trian[minI].vertex1].X, myPoint[trian[minI].vertex1].Y, myPoint[trian[minI].vertex2].X, myPoint[trian[minI].vertex2].Y);


            graphicObj.DrawLine(myPen2, myPoint[trian[minI].vertex2].X, myPoint[trian[minI].vertex2].Y, myPoint[trian[minI].vertex3].X, myPoint[trian[minI].vertex3].Y);
            graphicObj.DrawLine(myPen2, myPoint[trian[minI].vertex1].X, myPoint[trian[minI].vertex1].Y, myPoint[trian[minI].vertex3].X, myPoint[trian[minI].vertex3].Y);
            label2.Text = trian[minI].vertex1 + " " + trian[minI].vertex2 + " " + trian[minI].vertex3;
        }
        //max u
        private void button6_Click(object sender, EventArgs e)
        {
            double min1 = 0;
            double min2 = 0;
            int minI = 0;
            double u = 0;
            double a, b, c;
            int i;
            for (i = 0; i < triangleCount; i++)
            {
                a = Math.Pow(Math.Abs(myPoint[trian[i].vertex1].X - myPoint[trian[i].vertex2].X), 2) + Math.Pow(Math.Abs(myPoint[trian[i].vertex1].Y - myPoint[trian[i].vertex2].Y), 2);
                b = Math.Pow(Math.Abs(myPoint[trian[i].vertex2].X - myPoint[trian[i].vertex3].X), 2) + Math.Pow(Math.Abs(myPoint[trian[i].vertex2].Y - myPoint[trian[i].vertex3].Y), 2);
                c = Math.Pow(Math.Abs(myPoint[trian[i].vertex1].X - myPoint[trian[i].vertex3].X), 2) + Math.Pow(Math.Abs(myPoint[trian[i].vertex1].Y - myPoint[trian[i].vertex3].Y), 2);
                a = Math.Sqrt(a);
                b = Math.Sqrt(b);
                c = Math.Sqrt(c);
                u = (a + b + c);
                min2 = u;
                if (min1 == 0)
                {
                    min1 = min2;
                    minI = i;
                }
                else
                {
                    if (min2 > min1)
                    {
                        min1 = min2;
                        minI = i;
                    }
                }
            }
            graphicObj.DrawLine(myPen2, myPoint[trian[minI].vertex1].X, myPoint[trian[minI].vertex1].Y, myPoint[trian[minI].vertex2].X, myPoint[trian[minI].vertex2].Y);


            graphicObj.DrawLine(myPen2, myPoint[trian[minI].vertex2].X, myPoint[trian[minI].vertex2].Y, myPoint[trian[minI].vertex3].X, myPoint[trian[minI].vertex3].Y);
            graphicObj.DrawLine(myPen2, myPoint[trian[minI].vertex1].X, myPoint[trian[minI].vertex1].Y, myPoint[trian[minI].vertex3].X, myPoint[trian[minI].vertex3].Y);
            label2.Text = trian[minI].vertex1 + " " + trian[minI].vertex2 + " " + trian[minI].vertex3;

        }
        //find the last point
        private void button8_Click(object sender, EventArgs e)
        {
            circleMin = 0;
            Stopwatch watch = new Stopwatch();
            watch.Start();
            Point A = new System.Drawing.Point();
            Point B = new System.Drawing.Point();
            Point C = new System.Drawing.Point();
            int vertex = 0;
            listBox1.Items.Clear();
            for (int i = 0; i < trian.Length; i++)
            {


                //trying to find A point of triangle
                // A is defined as the point wıth the smallest Y value
                if (myPoint[trian[i].vertex1].Y < myPoint[trian[i].vertex2].Y)
                {
                    if (myPoint[trian[i].vertex1].Y < myPoint[trian[i].vertex3].Y)
                    {
                        A = myPoint[trian[i].vertex1];
                        vertex = 1;
                    }
                    else
                    {
                        A = myPoint[trian[i].vertex3];
                        vertex = 3;
                    }
                }
                else if (myPoint[trian[i].vertex2].Y < myPoint[trian[i].vertex3].Y)
                {
                    A = myPoint[trian[i].vertex2];
                    vertex = 2;
                }
                else if (myPoint[trian[i].vertex2].Y > myPoint[trian[i].vertex3].Y)
                {
                    A = myPoint[trian[i].vertex3];
                    vertex = 3;
                }
                //

                //trying to find B and C point of triangle.
                switch (vertex)
                {
                    case 1:
                        //double s1 =  (double) Math.Abs((myPoint[trian[i].vertex2].Y)-A.Y) / Math.Abs((myPoint[trian[i].vertex2].X) - A.X);
                        //double s2 = (double) Math.Abs((myPoint[trian[i].vertex3].Y)-A.Y)  / Math.Abs ((myPoint[trian[i].vertex3].X) - A.X );

                        //slopes s1 and s2
                        double s1 = (double)((myPoint[trian[i].vertex2].Y) - A.Y) / ((myPoint[trian[i].vertex2].X) - A.X);
                        double s2 = (double)((myPoint[trian[i].vertex3].Y) - A.Y) / ((myPoint[trian[i].vertex3].X) - A.X);


                        // double s1 =  (Math.Abs((myPoint[trian[i].vertex2].Y)-A.Y)) / (Math.Abs ((myPoint[trian[i].vertex2].X) - A.X));
                        //double s2 = (Math.Abs((myPoint[trian[i].vertex3].Y)-A.Y)) / (Math.Abs ((myPoint[trian[i].vertex3].X) - A.X ));


                        //determined if vertex2 or vertex3 is point B (via slope)
                        // other vertex is then C
                        if (s1 < 0)
                        {
                            if (s2 >= 0)
                            {
                                B = myPoint[trian[i].vertex3];
                                C = myPoint[trian[i].vertex2];

                            }
                            //´´´´´´´´´´´´´´´´´´´´´´´´´´´´´´´´´´´´´´´´´´´´´´´´´´´´´´´´´´´´´´´´
                            else
                            {
                                if (Math.Abs(s1) < Math.Abs(s2))
                                {
                                    B = myPoint[trian[i].vertex3];
                                    C = myPoint[trian[i].vertex2];
                                }
                                else if (Math.Abs(s1) > Math.Abs(s2))
                                {
                                    B = myPoint[trian[i].vertex2];
                                    C = myPoint[trian[i].vertex3];
                                }
                            }
                        }
                        else if (s1 > 0)
                        {
                            if (s2 > 0)
                            {
                                if (s1 > s2)
                                {
                                    C = myPoint[trian[i].vertex2];
                                    B = myPoint[trian[i].vertex3];
                                }
                                else if (s1 < s2)
                                {
                                    C = myPoint[trian[i].vertex3];
                                    B = myPoint[trian[i].vertex2];
                                }
                            }
                            else if (s2 < 0)
                            {
                                B = myPoint[trian[i].vertex2];
                                C = myPoint[trian[i].vertex3];
                            }
                        }
                        break;
                    case 2:
                        //double s3 = (double) Math.Abs((myPoint[trian[i].vertex1].Y)-A.Y) / Math.Abs ( (myPoint[trian[i].vertex1].X) - A.X);
                        //double s4 =(double) Math.Abs ((myPoint[trian[i].vertex3].Y)-A.Y) / Math.Abs( (myPoint[trian[i].vertex3].X) - A.X );

                        double s3 = (double)((myPoint[trian[i].vertex1].Y) - A.Y) / ((myPoint[trian[i].vertex1].X) - A.X);
                        double s4 = (double)((myPoint[trian[i].vertex3].Y) - A.Y) / ((myPoint[trian[i].vertex3].X) - A.X);

                        // double s3 =  (Math.Abs((myPoint[trian[i].vertex1].Y)-A.Y)) / (Math.Abs ( (myPoint[trian[i].vertex1].X) - A.X));
                        //double s4 = (Math.Abs((myPoint[trian[i].vertex3].Y)-A.Y)) / (Math.Abs( (myPoint[trian[i].vertex3].X) - A.X ));

                        if (s3 < 0)
                        {
                            if (s4 >= 0)
                            {
                                B = myPoint[trian[i].vertex3];
                                C = myPoint[trian[i].vertex1];
                            }
                            else
                            {
                                if (Math.Abs(s3) < Math.Abs(s4))
                                {
                                    B = myPoint[trian[i].vertex3];
                                    C = myPoint[trian[i].vertex1];
                                }
                                else if (Math.Abs(s3) > Math.Abs(s4))
                                {
                                    B = myPoint[trian[i].vertex1];
                                    C = myPoint[trian[i].vertex3];
                                }
                            }
                        }
                        else if (s3 > 0)
                        {
                            if (s4 > 0)
                            {
                                if (s3 > s4)
                                {
                                    C = myPoint[trian[i].vertex1];
                                    B = myPoint[trian[i].vertex3];
                                }
                                else if (s3 < s4)
                                {
                                    C = myPoint[trian[i].vertex3];
                                    B = myPoint[trian[i].vertex1];
                                }
                            }
                            else if (s4 < 0)
                            {
                                B = myPoint[trian[i].vertex1];
                                C = myPoint[trian[i].vertex3];
                            }
                        }


                        break;
                    case 3:
                        //double s5 = (double) Math.Abs((myPoint[trian[i].vertex2].Y)-A.Y) / Math.Abs( (myPoint[trian[i].vertex2].X) - A.X);
                        //double s6 =  (double) Math.Abs((myPoint[trian[i].vertex1].Y)-A.Y) / Math.Abs( (myPoint[trian[i].vertex1].X) - A.X );

                        double s5 = (double)((myPoint[trian[i].vertex2].Y) - A.Y) / ((myPoint[trian[i].vertex2].X) - A.X);
                        double s6 = (double)((myPoint[trian[i].vertex1].Y) - A.Y) / ((myPoint[trian[i].vertex1].X) - A.X);

                        // double s5 =  (Math.Abs((myPoint[trian[i].vertex2].Y)-A.Y)) / (Math.Abs ( (myPoint[trian[i].vertex2].X) - A.X));
                        //double s6 = (Math.Abs((myPoint[trian[i].vertex1].Y)-A.Y)) / (Math.Abs( (myPoint[trian[i].vertex1].X) - A.X ));


                        if (s5 < 0)
                        {
                            if (s6 >= 0)
                            {
                                B = myPoint[trian[i].vertex1];
                                C = myPoint[trian[i].vertex2];

                            }
                            else
                            {
                                if (Math.Abs(s5) < Math.Abs(s6))
                                {
                                    B = myPoint[trian[i].vertex1];
                                    C = myPoint[trian[i].vertex2];
                                }
                                else if (Math.Abs(s5) > Math.Abs(s6))
                                {
                                    B = myPoint[trian[i].vertex2];
                                    C = myPoint[trian[i].vertex1];
                                }
                            }
                        }
                        else if (s5 > 0)
                        {
                            if (s6 > 0)
                            {
                                if (s5 > s6)
                                {
                                    C = myPoint[trian[i].vertex2];
                                    B = myPoint[trian[i].vertex1];
                                }
                                else if (s5 < s6)
                                {
                                    C = myPoint[trian[i].vertex1];
                                    B = myPoint[trian[i].vertex2];
                                }
                            }
                            else if (s6 < 0)
                            {
                                B = myPoint[trian[i].vertex2];
                                C = myPoint[trian[i].vertex1];
                            }
                        }

                        break;
                    default:
                        break;
                }


                //if (blendCalculate(myPoint[trian[i].vertex1].X,myPoint[trian[i].vertex1].Y,myPoint[trian[i].vertex2].X,myPoint[trian[i].vertex2].Y,myPoint[trian[i].vertex3].X,myPoint[trian[i].vertex3].Y,lastPoint.X,lastPoint.Y) == 1)
                //{
                //    listBox1.Items.Add(trian[i].vertex1.ToString()+" : "+trian[i].vertex2.ToString()+" : "+trian[i].vertex3.ToString());
                //}

                //calculate blend values and also check if point is inside the triangle
                if (blendCalculate(A.X, A.Y, B.X, B.Y, C.X, C.Y, lastPoint.X, lastPoint.Y) == 1)
                {

                    //distances calulation
                    double a = Math.Pow((Math.Abs(myPoint[trian[i].vertex1].X - myPoint[trian[i].vertex2].X)), 2) + Math.Pow((Math.Abs(myPoint[trian[i].vertex1].Y - myPoint[trian[i].vertex2].Y)), 2);
                    double b = Math.Pow((Math.Abs(myPoint[trian[i].vertex1].X - myPoint[trian[i].vertex3].X)), 2) + Math.Pow((Math.Abs(myPoint[trian[i].vertex1].Y - myPoint[trian[i].vertex3].Y)), 2);
                    double c = Math.Pow((Math.Abs(myPoint[trian[i].vertex2].X - myPoint[trian[i].vertex3].X)), 2) + Math.Pow((Math.Abs(myPoint[trian[i].vertex2].Y - myPoint[trian[i].vertex3].Y)), 2);
                    a = Math.Sqrt(a); // |A-B|
                    b = Math.Sqrt(b); // |A-C|
                    c = Math.Sqrt(c); // |B-C|

                    //find minimum sum of the sides (min (a+b+c))
                    //circleMin is the minimum of (a+b+c)
                    if (circleMin == 0)
                    {
                        circleMin = a + b + c;
                        trianMin.vertex1 = trian[i].vertex1;
                        trianMin.vertex2 = trian[i].vertex2;
                        trianMin.vertex3 = trian[i].vertex3;
                    }
                    else
                    {
                        if (a == 0 && b == 0 && c == 0)
                        {
                            //TODO: investigate why it is similar
                            MessageBox.Show("hata");
                        }
                        else
                        {
                            if (circleMin > (a + b + c))
                            {
                                circleMin = a + b + c;
                                trianMin.vertex1 = trian[i].vertex1;
                                trianMin.vertex2 = trian[i].vertex2;
                                trianMin.vertex3 = trian[i].vertex3;
                            }
                        }

                    }
                    if (a == 0 && b == 0 && c == 0)
                    {

                    }
                    else
                    {

                        //for adding to listbox all triangle consisting of lastpoint
                        listBox1.Items.Add(trian[i].vertex1.ToString() + " : " + trian[i].vertex2.ToString() + " : " + trian[i].vertex3.ToString() + " : " + (a + b + c).ToString() + " cm");
                    }

                }
            }
            //MessageBox.Show("circle "+circleMin.ToString());
            listBox1.Items.Add(trianMin.vertex1.ToString() + " : " + trianMin.vertex2.ToString() + " : " + trianMin.vertex3.ToString());

            watch.Stop();
            //MessageBox.Show(watch.Elapsed.Milliseconds.ToString());
            listBox2.Items.Add("time of finding: " + watch.Elapsed.Milliseconds.ToString() + " msec");





        }

        private void Form1_Click(object sender, EventArgs e)
        {
            lastPoint = new System.Drawing.Point();

            lastPoint.X = Cursor.Position.X - 5;
            lastPoint.Y = Cursor.Position.Y - 20;
            graphicObj.FillEllipse(myBrush, lastPoint.X, lastPoint.Y, 10, 10);

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
        #endregion

        #region changeFunction
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tri = listBox1.SelectedItem.ToString();
            //MessageBox.Show(tri);

            string[] splitting = tri.Split(':');
            graphicObj.DrawLine(myPen2, myPoint[Convert.ToInt32(splitting[0])].X, myPoint[Convert.ToInt32(splitting[0])].Y, myPoint[Convert.ToInt32(splitting[1])].X, myPoint[Convert.ToInt32(splitting[1])].Y);
            graphicObj.DrawLine(myPen2, myPoint[Convert.ToInt32(splitting[0])].X, myPoint[Convert.ToInt32(splitting[0])].Y, myPoint[Convert.ToInt32(splitting[2])].X, myPoint[Convert.ToInt32(splitting[2])].Y);
            graphicObj.DrawLine(myPen2, myPoint[Convert.ToInt32(splitting[1])].X, myPoint[Convert.ToInt32(splitting[1])].Y, myPoint[Convert.ToInt32(splitting[2])].X, myPoint[Convert.ToInt32(splitting[2])].Y);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            findTriangle();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            findTriangleWithoutLine();
        }
        #endregion

        #region triangle Functions
        //create Triangle function
        public void findTriangle()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            int x = 0;
            myPen.Width = 3;
            for (int a = 0; a < myPoint.Count; a++)
            {

                for (int i = a + 1; i <= myPoint.Count; i++)
                {
                    for (int j = i + 1; j <= myPoint.Count - 1; j++)
                    {
                        if (myPoint[a].X == myPoint[i].X && myPoint[i].X == myPoint[j].X)
                        {

                        }
                        else if (myPoint[a].Y == myPoint[i].Y && myPoint[i].Y == myPoint[j].Y)
                        {

                        }
                        else if (myPoint[a].Y / myPoint[a].X == myPoint[i].Y / myPoint[i].X && myPoint[i].Y / myPoint[i].Y == myPoint[j].Y / myPoint[j].X)
                        {

                        }
                        else
                        {
                            graphicObj.DrawLine(myPen, myPoint[a].X, myPoint[a].Y, myPoint[i].X, myPoint[i].Y);
                            graphicObj.DrawLine(myPen, myPoint[i].X, myPoint[i].Y, myPoint[j].X, myPoint[j].Y);
                            graphicObj.DrawLine(myPen, myPoint[a].X, myPoint[a].Y, myPoint[j].X, myPoint[j].Y);
                            System.Threading.Thread.Sleep(2000);
                            triangleCount++;
                            trian[x].vertex1 = a;
                            trian[x].vertex2 = i;
                            trian[x].vertex3 = j;
                            x++;
                            //System.Threading.Thread.Sleep(1000);
                        }
                    }
                }

            }
            watch.Stop();
            listBox2.Items.Add("Count of triangle: " + triangleCount.ToString());
            label1.Text = triangleCount.ToString() + " " + trian.Count();
            listBox2.Items.Add("time of line all triangle: " + watch.Elapsed.Milliseconds.ToString() + " msec");


        }

        public void findTriangleWithoutLine()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            myPen.Width = 3;


            int x = 0;
            //
            for (int a = 0; a < myPoint.Count; a++)
            {

                for (int i = a + 1; i <= myPoint.Count; i++)
                {
                    for (int j = i + 1; j <= myPoint.Count - 1; j++)
                    {
                        //controlling if 3 point is on same line. Line equation
                        if (((myPoint[i].Y - myPoint[a].Y) * (myPoint[j].X - myPoint[i].X) - (myPoint[j].Y - myPoint[i].Y) * (myPoint[i].X - myPoint[a].X)) == 0)
                        {

                        }

                        else
                        {
                            triangleCount++;
                            trian[x].vertex1 = a;
                            trian[x].vertex2 = i;
                            trian[x].vertex3 = j;
                            x++;
                            //System.Threading.Thread.Sleep(1000);
                        }
                    }
                }

            }
            watch.Stop();
            listBox2.Items.Add("time of finding all triangle: " + watch.Elapsed.Milliseconds.ToString() + " msec");
            listBox2.Items.Add("Finding all triangle: " + triangleCount.ToString());
        }

        public void calculatingArea()
        {
            double min1 = 0;
            double min2 = 0;
            int minI = 0;
            double u = 0;
            double a, b, c;
            int i;
            for (i = 0; i < triangleCount; i++)
            {
                a = Math.Pow(Math.Abs(myPoint[trian[i].vertex1].X - myPoint[trian[i].vertex2].X), 2) + Math.Pow(Math.Abs(myPoint[trian[i].vertex1].Y - myPoint[trian[i].vertex2].Y), 2);
                b = Math.Pow(Math.Abs(myPoint[trian[i].vertex2].X - myPoint[trian[i].vertex3].X), 2) + Math.Pow(Math.Abs(myPoint[trian[i].vertex2].Y - myPoint[trian[i].vertex3].Y), 2);
                c = Math.Pow(Math.Abs(myPoint[trian[i].vertex1].X - myPoint[trian[i].vertex3].X), 2) + Math.Pow(Math.Abs(myPoint[trian[i].vertex1].Y - myPoint[trian[i].vertex3].Y), 2);
                a = Math.Sqrt(a);
                b = Math.Sqrt(b);
                c = Math.Sqrt(c);
                u = (a + b + c) / 2;
                min2 = Math.Sqrt(u * (u - a) * (u - b) * (u - c));
                if (min1 == 0)
                {
                    min1 = min2;
                    minI = i;
                }
                else
                {
                    if (min2 < min1)
                    {
                        min1 = min2;
                        minI = i;
                    }
                }
            }
            graphicObj.DrawLine(myPen2, myPoint[trian[minI].vertex1].X, myPoint[trian[minI].vertex1].Y, myPoint[trian[minI].vertex2].X, myPoint[trian[minI].vertex2].Y);


            graphicObj.DrawLine(myPen2, myPoint[trian[minI].vertex2].X, myPoint[trian[minI].vertex2].Y, myPoint[trian[minI].vertex3].X, myPoint[trian[minI].vertex3].Y);
            graphicObj.DrawLine(myPen2, myPoint[trian[minI].vertex1].X, myPoint[trian[minI].vertex1].Y, myPoint[trian[minI].vertex3].X, myPoint[trian[minI].vertex3].Y);
            label2.Text = trian[minI].vertex1 + " " + trian[minI].vertex2 + " " + trian[minI].vertex3;
        }

        public void calculatingU()
        {
            double min1 = 0;
            double min2 = 0;
            int minI = 0;
            double u = 0;
            double a, b, c;
            int i;
            for (i = 0; i < triangleCount; i++)
            {
                a = Math.Pow(Math.Abs(myPoint[trian[i].vertex1].X - myPoint[trian[i].vertex2].X), 2) + Math.Pow(Math.Abs(myPoint[trian[i].vertex1].Y - myPoint[trian[i].vertex2].Y), 2);
                b = Math.Pow(Math.Abs(myPoint[trian[i].vertex2].X - myPoint[trian[i].vertex3].X), 2) + Math.Pow(Math.Abs(myPoint[trian[i].vertex2].Y - myPoint[trian[i].vertex3].Y), 2);
                c = Math.Pow(Math.Abs(myPoint[trian[i].vertex1].X - myPoint[trian[i].vertex3].X), 2) + Math.Pow(Math.Abs(myPoint[trian[i].vertex1].Y - myPoint[trian[i].vertex3].Y), 2);
                a = Math.Sqrt(a);
                b = Math.Sqrt(b);
                c = Math.Sqrt(c);
                u = (a + b + c);
                min2 = u;
                if (min1 == 0)
                {
                    min1 = min2;
                    minI = i;
                }
                else
                {
                    if (min2 < min1)
                    {
                        min1 = min2;
                        minI = i;
                    }
                }
            }
            graphicObj.DrawLine(myPen2, myPoint[trian[minI].vertex1].X, myPoint[trian[minI].vertex1].Y, myPoint[trian[minI].vertex2].X, myPoint[trian[minI].vertex2].Y);


            graphicObj.DrawLine(myPen2, myPoint[trian[minI].vertex2].X, myPoint[trian[minI].vertex2].Y, myPoint[trian[minI].vertex3].X, myPoint[trian[minI].vertex3].Y);
            graphicObj.DrawLine(myPen2, myPoint[trian[minI].vertex1].X, myPoint[trian[minI].vertex1].Y, myPoint[trian[minI].vertex3].X, myPoint[trian[minI].vertex3].Y);
            label2.Text = trian[minI].vertex1 + " " + trian[minI].vertex2 + " " + trian[minI].vertex3;


        }

        int blendCalculate(float ax, float ay, float bx, float bY, float cx, float cy, float px, float py)
        {
            float s, t, u;
            float det = (ax * bY + ay * cx + bx * cy) - (bY * cx + ax * cy + ay * bx);  // Det(A) is found.

            if (det <= 0)
            {
                //Debug.Log ("Det(A) is not positiv " + det);
                return 0;
            }

            else
            {
                s = (1 / det) * ((bY - cy) * px + (cx - bx) * py + (bx * cy - cx * bY));
                t = (1 / det) * ((cy - ay) * px + (ax - cx) * py + (cx * ay - ax * cy));
                u = (1 / det) * ((ay - bY) * px + (bx - ax) * py + (ax * bY - bx * ay));
                if (s >= 0 && t >= 0 && u >= 0)
                {
                    return 1;
                }
                //Debug.Log ("This point is outside of triangle");
                return 0;
            }

        }

        public double calculatingFac(int a)
        {
            double fac = 1;
            for (int i = 1; i <= a; i++)
            {
                fac = fac * i;
            }
            return fac;
        }
        #endregion
    }
}
