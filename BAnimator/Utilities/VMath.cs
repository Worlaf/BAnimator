using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BAnimator.Utilities
{
    public static class VMath
    {
        public const double RadiansToDegreeK = 57.295779513082320876798154814105;

        public static double ScalarProduct(PointV vec1, PointV vec2)
        {
            return vec1.X * vec2.X + vec1.Y * vec2.Y;
        }

        public static double Distance(PointV p1, PointV p2)
        {
            double dx, dy;
            dx = p1.X - p2.X;
            dy = p1.Y - p2.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }
        public static float Distance(ref PointF p1, ref PointF p2)
        {
            float dx, dy;
            dx = p1.X - p2.X;
            dy = p1.Y - p2.Y;
            return (float)Math.Sqrt(dx * dx + dy * dy);
        }
        /// <summary>
        /// Квадрат расстояния
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static double SqrDistance(PointV p1, PointV p2)
        {
            double dx, dy;
            dx = p1.X - p2.X;
            dy = p1.Y - p2.Y;
            return dx * dx + dy * dy;
        }
        /// <summary>
        /// Квадрат расстояния
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static float SqrDistance(ref PointF p1, ref PointF p2)
        {
            float dx, dy;
            dx = p1.X - p2.X;
            dy = p1.Y - p2.Y;
            return dx * dx + dy * dy;
        }

        public static bool CheckDistance(PointV p1, PointV p2, double dist)
        {
            dist *= dist;
            double dx = p1.X - p2.X, dy = p1.Y - p2.Y;
            return dx * dx + dy * dy <= dist;
        }
        public static bool CheckDistance(ref PointF p1, ref PointF p2, float dist)
        {
            dist *= dist;
            float dx = p1.X - p2.X, dy = p1.Y - p2.Y;
            return dx * dx + dy * dy <= dist;
        }
        /// <summary>
        /// Проверяет дистанцию от точки p до отрезка p0 p1
        /// </summary>
        /// <param name="p0"></param>
        /// <param name="p1"></param>
        /// <param name="p"></param>
        /// <param name="dist"></param>
        /// <returns></returns>
        public static bool CheckDistance(PointV p0, PointV p1, PointV p, double dist)
        {
            //Взято тут:
            //http://algolist.manual.ru/maths/geom/distance/pointline.php
            if (p0.Equals(p1))
            {
                return CheckDistance(p0, p, dist);
            }
            PointV p0v = p - p0;
            PointV p1v = p - p1;
            PointV sv = p1 - p0;
            double dx, dy;
            //Проверяем знак скалярного произведения векторов
            //Если меньше 0, значит основание перпендикуляра от точки лежит за пределами отрезка
            if (p0v.X * sv.X + p0v.Y * sv.Y < 0)
            {
                dx = p.X - p0.X;
                dy = p.Y - p0.Y;
                return dist >= dx * dx + dy * dy;
            }
            //Аналогично, для конца отрезка
            sv = p0 - p1;
            if (p1v.X * sv.X + p1v.Y * sv.Y < 0)
            {
                dx = p.X - p1.X;
                dy = p.Y - p1.Y;
                return dist >= dx * dx + dy * dy;
            }
            //Если до сих пор функция еще выполняется, значит основание перпендикуляра лежит 
            //в пределах отрезка. Проверяем расстояние от точки до прямой
            sv.Length = 1;  //Нормализуем вектор p1-p0

            //Находим векторное произведение для двумерного случая
            return dist >= Math.Abs( sv.X * p1v.Y - sv.Y * p1v.X);

        }

        /// <summary>
        /// Проверяет дистанцию от точки p до отрезка p0 p1
        /// </summary>
        /// <param name="p0"></param>
        /// <param name="p1"></param>
        /// <param name="p"></param>
        /// <param name="dist"></param>
        /// <returns></returns>
        public static bool CheckDistance(PointF p0, PointF p1, PointF p, float dist, bool OnlySegment = false)
        {
            //Взято тут:
            //http://algolist.manual.ru/maths/geom/distance/pointline.php
            if (p0 == p1)
            {
                return CheckDistance(ref p0, ref p, dist);
            }


            PointV p0v = new PointV(PointV.Sub(ref p, ref p0));
            PointV p1v = new PointV(PointV.Sub(ref p, ref p1));
            PointV sv = new PointV(PointV.Sub(ref p1, ref p0));
            double dx, dy;
            //Проверяем знак скалярного произведения векторов
            //Если меньше 0, значит основание перпендикуляра от точки лежит за пределами отрезка
            if (p0v.X * sv.X + p0v.Y * sv.Y < 0)
            {
                if (OnlySegment)
                    return false;
                dx = p.X - p0.X;
                dy = p.Y - p0.Y;
                return dist >= dx * dx + dy * dy;
            }
            //Аналогично, для конца отрезка
            sv = new PointV(PointV.Sub(ref p0, ref p1));
            if (p1v.X * sv.X + p1v.Y * sv.Y < 0)
            {
                if (OnlySegment)
                    return false;
                dx = p.X - p1.X;
                dy = p.Y - p1.Y;
                return dist >= dx * dx + dy * dy;
            }
            //Если до сих пор функция еще выполняется, значит основание перпендикуляра лежит 
            //в пределах отрезка. Проверяем расстояние от точки до прямой
            sv.Length = 1;  //Нормализуем вектор p1-p0

            //Находим векторное произведение для двумерного случая
            return dist >= Math.Abs( sv.Y * p1v.X - sv.X * p1v.Y);

        }
        public static double GetDistance(PointF p0, PointF p1, PointF p)
        {
            //Взято тут:
            //http://algolist.manual.ru/maths/geom/distance/pointline.php
            if (p0 == p1)
            {
                return Distance(ref p0, ref p);
            }


            PointV p0v = new PointV(PointV.Sub(ref p, ref p0));
            PointV p1v = new PointV(PointV.Sub(ref p, ref p1));
            PointV sv = new PointV(PointV.Sub(ref p1, ref p0));
            double dx, dy;
            //Проверяем знак скалярного произведения векторов
            //Если меньше 0, значит основание перпендикуляра от точки лежит за пределами отрезка
            if (p0v.X * sv.X + p0v.Y * sv.Y < 0)
            {
                return 100;
                dx = p.X - p0.X;
                dy = p.Y - p0.Y;
                return dx * dx + dy * dy;
            }
            //Аналогично, для конца отрезка
            sv = new PointV(PointV.Sub(ref p0, ref p1));
            if (p1v.X * sv.X + p1v.Y * sv.Y < 0)
            {
                return 100;
               
                dx = p.X - p1.X;
                dy = p.Y - p1.Y;
                return dx * dx + dy * dy;
            }
            //Если до сих пор функция еще выполняется, значит основание перпендикуляра лежит 
            //в пределах отрезка. Проверяем расстояние от точки до прямой
            

            //Находим векторное произведение для двумерного случая
            return (sv.Y * p1v.X - sv.X * p1v.Y)/sv.Length;

        }
    }
}
