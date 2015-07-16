using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BAnimator
{
    public class BoneDrawer
    {
        public static void DrawBone(Bone bone, Graphics graph, PointF p0)
        {
            if (bone.IsRoot)
            {
                graph.DrawEllipse(Pens.Orange, p0.X - 6, p0.Y - 6, 12, 12);
                return;
            }
            PointF ps = bone.StartPoint, pe = bone.EndPoint;

            ps = new PointF(ps.X + p0.X, ps.Y + p0.Y);
            pe = new PointF(pe.X + p0.X, pe.Y + p0.Y);
            Pen pen = Pens.Black;
            pen.Width = 3;
            graph.DrawLine(pen, ps, pe);            
            graph.DrawEllipse(pen, ps.X - 4, ps.Y - 4, 8, 8);
            graph.DrawEllipse(pen, ps.X - 2, ps.Y - 2, 4, 4);            
        }

        public static void DrawBones(Bone start, Graphics graph, PointF p0)
        {
            DrawBone(start, graph, p0);
            for (int i = 0; i < start.Children.Count; i++)
            {
                DrawBones(start.Children[i], graph, p0);
            }
        }
    }
}
