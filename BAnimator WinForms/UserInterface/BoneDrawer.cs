using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAnimator;
using BAnimator.Utilities;
using System.Drawing;

namespace BAnimator_WinForms.UserInterface
{
    public static class BoneDrawer
    {
        public enum DrawParametres { None = 0x0, DrawAngleCtl=0x1, DrawShiftCtl=0x2, DrawStretchCtl=0x4, DrawFreeEditCtl=0x8 }

        public static void DrawBone(Bone b, Graphics graph, PointF rootPos, bool selected = false)
        {
            if (b.IsRoot)
            {
                if (selected)
                {
                    graph.DrawEllipse(Pens.Orange, rootPos.X - 30, rootPos.Y - 30, 60, 60);
                }
                else
                {
                    graph.DrawEllipse(Pens.Black, rootPos.X - 30, rootPos.Y - 30, 60, 60);
                }
            }
            else
            {
                PointV p0 = new PointV(b.StartPoint);
                PointV p3 = new PointV(b.EndPoint);
                PointV p1 = p3 - p0;
                PointV p2 = p1.Rotate(-0.2745);
                p1 = p1.Rotate(0.2745);
                p2.Length = p2.Length * 0.2;
                p1.Length = p1.Length * 0.2;
                p2 = p2 + p0;
                p1 = p1 + p0;
                Pen pen0 = new Pen(Color.Black);
                Brush brush0 = new SolidBrush(Color.FromArgb(180, Color.DarkGray));                
                Pen pen1 = new Pen(Color.Black);
                pen1.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                PointF[] pts = new PointF[] { p0.Add(rootPos).Point, p1.Add(rootPos).Point,
                        p3.Add(rootPos).Point, p2.Add(rootPos).Point };
                if (selected)
                {
                    brush0 = new SolidBrush(Color.FromArgb(180, Color.Orange));  
                    pen1.Color = Color.Orange;
                    pen0.Color = Color.Orange;
                    graph.DrawPolygon(pen0, pts);
                    graph.FillPolygon(brush0, pts);
                    graph.DrawLine(pen1, PointV.Add(rootPos, b.StartPoint), PointV.Add(rootPos, b.Parent.EndPoint));
                    
                    


                }
                else
                {
                    graph.DrawPolygon(pen0, pts);
                    graph.FillPolygon(brush0, pts);
                    graph.DrawLine(pen1, PointV.Add(rootPos, b.StartPoint), PointV.Add(rootPos, b.Parent.EndPoint));
                }              

            }
        }

        public static void DrawControls(Graphics graph, PointF rootPos, Bone b, DrawParametres p)
        {
            PointV p0 = new PointV(b.StartPoint);
            PointV p3 = new PointV(b.EndPoint);
            PointV p1;
            PointV p2;
            if ((p & DrawParametres.DrawAngleCtl) == DrawParametres.DrawAngleCtl ||
                        (p & DrawParametres.DrawFreeEditCtl) == DrawParametres.DrawFreeEditCtl)
            {
                Pen pen = new Pen(Color.Green);
                int r = 20;
                pen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                pen.Width = 5f;
                p2 = p3 - p0;
                p2.Length = p2.Length - r;
                p2 = p2.Add(rootPos).Add(p0);
                float k = (float)(180 / Math.PI);
                graph.DrawArc(pen, new RectangleF((float)p2.X - r, (float)p2.Y - r, r * 2, r * 2),
                  (float)b.AbsoluteAngle * k, 90);
                graph.DrawArc(pen, new RectangleF((float)p2.X - r, (float)p2.Y - r, r * 2, r * 2),
                  (float)b.AbsoluteAngle * k, -90);
            }
            if ((p & DrawParametres.DrawShiftCtl) == DrawParametres.DrawShiftCtl)
            {
                int padding = 4;
                int length = 16;
                Pen pen = new Pen(Color.Blue);
                pen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                pen.Width = 5f;
                p2 = p0.Add(rootPos);
                graph.DrawLine(pen, (float)p2.X, (float)p2.Y + padding, (float)p2.X, (float)p2.Y + padding + length);
                graph.DrawLine(pen, (float)p2.X, (float)p2.Y - padding, (float)p2.X, (float)p2.Y - padding - length);
                graph.DrawLine(pen, (float)p2.X + padding, (float)p2.Y, (float)p2.X + padding + length, (float)p2.Y);
                graph.DrawLine(pen, (float)p2.X - padding, (float)p2.Y, (float)p2.X - padding - length, (float)p2.Y);
            }
            if ((p & DrawParametres.DrawStretchCtl) == DrawParametres.DrawStretchCtl ||
                (p & DrawParametres.DrawFreeEditCtl) == DrawParametres.DrawFreeEditCtl)
            {
                int padding = 4;
                int length = 20;
                Pen pen = new Pen(Color.Blue);
                pen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                pen.Width = 5f;
                p2 = p3 - p0;
                p1 = p3 - p0;
                p2.Length = length;
                p1.Length = padding;

                graph.DrawLine(pen, p1.Add(rootPos).Add(p3).Point, p2.Add(rootPos).Add(p3).Point);
                p1 = p1.Rotate(Math.PI);
                p2 = p2.Rotate(Math.PI);
                graph.DrawLine(pen, p1.Add(rootPos).Add(p3).Point, p2.Add(rootPos).Add(p3).Point);
            }
                    
        }
    }
}
