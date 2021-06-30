using System;
using System.Drawing;
using System.Linq;

namespace WoodSawCut {
    class Plank
    {
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Angle { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public Color Color { get; set; }
        public Size Size { 
            get {
                return new Size((int)this.Width, (int)this.Height);
            } 
        }
        public double Top {
            get {
                return this.Y - (double)this.Height / 2.0 - 1.2;
            }
            set {
                this.Y = value + (double)this.Height / 2.0 + 1.2;
            }
        }
        public double Bottom
        {
            get
            {
                return this.Y + (double)this.Height / 2.0 + 1.2;
            }
            set
            {
                this.Y = value - (double)this.Height / 2.0 -1.2;
            }
        }
        public double Left
        {
            get
            {
                return this.X - (double)this.Width / 2.0 - 1.2;
            }
            set
            {
                this.X = value + (double)this.Width / 2.0 + 1.2;
            }
        }
        public double Right
        {
            get
            {
                return this.X + (double)this.Width / 2.0 + 1.2;
            }
            set
            {
                this.X = value - (double)this.Width / 2.0 - 1.2;
            }
        }
        public double Area {
            get {
                return this.Width * this.Height;
            }
        }
        /// <summary>
        /// 1 - горизонтальная планка, 0 - квадрат, -1 - вертикальная планка
        /// </summary>
        public int Orientation { 
            get {
                if (this.Width > this.Height) return 1;
                else if (this.Height > this.Width) return -1;
                else return 0;
            } 
        }

        public Plank(int height, int width, double l, double a, Color c) {
            this.Angle = a;
            this.Length = l;
            this.Height = height;
            this.Width = width;
            this.X = Height/2.0+10;
            this.Y = width/2.0+10;
            this.Color = c;
        }

        public override string ToString() {
            return String.Format("{0} x {1} x {2}",this.Height, this.Width, this.Length/1000.0);
        }

        public System.Drawing.Point[] GetPoints() {
            System.Drawing.Point[] p = new System.Drawing.Point[2];
            if (this.Angle == 0.0 || this.Angle == 180.0) {
                p[0].X = (int)(this.X - this.Height / 2);
                p[0].Y = (int)(this.Y - this.Width / 2);
                p[1].X = (int)(this.X + this.Height / 2);
                p[1].Y = (int)(this.Y + this.Width / 2);
            }
            else if (this.Angle == 90.0 || this.Angle == 270.0) {
                p[0].X = (int)(this.Y - this.Width / 2);
                p[0].Y = (int)(this.X - this.Height / 2);
                p[1].X = (int)(this.Y + this.Width / 2);
                p[1].Y = (int)(this.X + this.Height / 2);
            }
            return p;
        }

        public Rectangle GetRectangle() {
            Rectangle rect = new Rectangle();
            if (this.Angle == 0.0 || this.Angle == 180.0) {
                rect.X = (int)(this.X - this.Height / 2);
                rect.Y = (int)(this.Y - this.Width / 2);
                rect.Height = (int)this.Height;
                rect.Width = (int)this.Width;
            }
            else if (this.Angle == 90.0 || this.Angle == 270.0) {
                rect.X = (int)(this.Y - this.Width / 2);
                rect.Y = (int)(this.X - this.Height / 2);
                rect.Height = (int)this.Width;
                rect.Width = (int)this.Height;
            }
            return rect;
        }

        public PointF GetPointToText() {
            PointF p = new PointF();
            p.X = (float)(this.X - this.Left) / 2.0f;
            p.X = (float)(this.Y - this.Top) / 2.0f;
            return p;
        }

        public void Rotate() {
            double t = this.Width;
            this.Width = this.Height;
            this.Height = t;
        }

        public double Distance(double x = 0.0, double y=0.0) {
            double[] dd = new double[4];
            double l = x - this.Left;
            double t = y - this.Top; 
            double r = x - this.Right;
            double b = y-this.Bottom;
            dd[0] = Math.Sqrt(t * t + l * l);
            dd[1] = Math.Sqrt(t * t + r * r);
            dd[2] = Math.Sqrt(b * b + r * r);
            dd[3] = Math.Sqrt(b * b + l * l);
            return dd.Max();
        }

        //public int Compare(Plank a, Plank b) {
        //    if (a.Area > b.Area) return 1;
        //    else if (a.Area == b.Area) return 0;
        //    else return -1;
        //}
    }
}
