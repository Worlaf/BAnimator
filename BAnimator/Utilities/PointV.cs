using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BAnimator.Utilities
{
    public class PointV
    {

        protected double x, y, angle, length;


        public double X { 
            get { return x; }
            set
            {
                if (x != value)
                {
                    x = value;
                    angle = Math.Atan2(y, x);
                    length = Math.Sqrt(x * x + y * y);
                }                
            }
        }
        public double Y
        {
            get { return y; }
            set
            {
                if (y != value)
                {
                    y = value;
                    angle = Math.Atan2(y, x);
                    length = Math.Sqrt(x * x + y * y);
                }  
            }
        }
        public double Angle
        {
            get { return angle; }
            set
            {
                if (angle != value)
                {
                    angle = value;
                    x = Math.Cos(angle) * length;
                    y = Math.Sin(angle) * length;
                }
            }
        }
        public double Length
        {
            get { return length; }
            set
            {
                if (length != value)
                {
                    if (length == 0)
                    {
                        length = value;
                        x = Math.Cos(angle) * length;
                        y = Math.Sin(angle) * length;
                    }
                    else
                    {
                        length = value / length;
                        x *= length;
                        y *= length;
                        length = value;
                    }
                }
            }
        }

        public PointF Point
        {
            get { return new PointF((float)x, (float)y); }
        }

        /// <summary>
        /// Создает точку с указанными координатами
        /// </summary>
        /// <param name="x">Координата X</param>
        /// <param name="y">Координата Y</param>
        /// <param name="asVector">Если true, то X - принимается за угол, Y - за длину</param>
        public PointV(double x, double y, bool Polar = false)
        {
            if (!Polar)
            {
                X = x;
                Y = y;
            }
            else
            {
                angle = x;
                length = y;
                this.x = Math.Cos(x) * y;
                this.y = Math.Sin(x) * y;
            }
        }


        public PointV(PointF point)
        {
            X = point.X;
            Y = point.Y;
        }


        public PointV Rotate(double angle)
        {
            return new PointV(this.angle + angle, length, true);
        }

        public PointV Add(PointF point)
        {
            return new PointV(x + point.X, y + point.Y);
        }
        public PointV Add(PointV point)
        {
            return new PointV(x + point.x, y + point.y);
        }

        public bool Equals(PointV pt)
        {
            return pt.x == x && pt.y == y;
        }
        
        

        #region Static functions
        //------------------------STATIC
        public static PointF Add(ref PointF p1, ref PointF p2)
        {
            return new PointF(p1.X + p2.X, p1.Y + p2.Y);
        }
        public static PointF Add(PointF p1, PointF p2)
        {
            return new PointF(p1.X + p2.X, p1.Y + p2.Y);
        }

        public static PointF Sub(ref PointF p1, ref PointF p2)
        {
            return new PointF(p1.X - p2.X, p1.Y - p2.Y);
        }
        public static PointF Sub(PointF p1, PointF p2)
        {
            return new PointF(p1.X - p2.X, p1.Y - p2.Y);
        }
        
        #endregion
        #region Static operators
        public static PointV operator +(PointV l, PointV r)
        {
            return new PointV(l.x + r.x, l.y + r.y);
        }
        public static PointV operator +(PointF l, PointV r)
        {
            return new PointV(l.X + r.x, l.Y + r.y);
        }
        public static PointV operator +(PointV l, PointF r)
        {
            return new PointV(l.x + r.X, l.y + r.Y);
        }
        
        public static PointV operator -(PointV l, PointV r)
        {
            return new PointV(l.x - r.x, l.y - r.y);
        }
        public static PointV operator -(PointV l, PointF r)
        {
            return new PointV(l.x - r.X, l.y - r.Y);
        }
        public static PointV operator -(PointF l, PointV r)
        {
            return new PointV(l.X - r.x, l.Y - r.y);
        }

        public static double operator *(PointV l, PointV r)
        {
            return l.x * r.x + l.y * r.y;
        }



        #endregion
    }
}
