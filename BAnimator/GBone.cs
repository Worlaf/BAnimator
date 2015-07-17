using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BAnimator
{
    public class GBone : Bone
    {
        public void SetParent(Bone bone)
        {
            this.Parent = bone;
            
        }

        public override void Update()
        {
            if (_updated)
                return;
            if (IsRoot)
                return;
            if (Parent == null)
            {
                throw new Exception("Parent cannot be null");
            }
            double sx, sy;
            sx = shift.X;
            sy = shift.Y;
            double sa, sl;
            double pa = Parent.AbsoluteAngle;
            sa = Math.Atan2(sy, sx) + pa;
            sl = Math.Sqrt(sx * sx + sy * sy);
            sx = Math.Cos(sa) * sl + Parent.StartPoint.X;
            sy = Math.Sin(sa) * sl + Parent.StartPoint.Y;
            startPoint = new PointF((float)sx, (float)sy);

            double ex, ey;
            ex = Math.Cos(angle + pa) * length + sx;
            ey = Math.Sin(angle + pa) * length + sy;
            endPoint = new PointF((float)ex, (float)ey);

            for (int i = 0; i < children.Count; i++)
            {
                children[i].Update();
            }
        }
    }
}
