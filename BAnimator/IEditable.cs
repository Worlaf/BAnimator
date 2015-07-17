using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BAnimator
{
    public interface IEditable
    {
        double Angle { get; set; }
        PointF Shift { get; set; }
        PointF Location { get; }
        double AbsoluteAngle { get; }
        PointF ParentPoint { get; }

    }
}
