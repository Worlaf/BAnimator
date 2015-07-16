using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BAnimator
{
    public class BoneImage
    {
        protected bool useAsDefault = false;
        public bool UseAsDefault { get { return useAsDefault; } set { parent.SetDefaultImage(this); useAsDefault = value;  } }

        public Bitmap Image { get; set; }

        public double Angle { get; set; }

        public PointF Shift { get; set; }

        public List<CharacterStateValue> States { get; set; }

        protected BoneGraphics parent;

        public BoneImage(BoneGraphics parent)
        {
            this.parent = parent;
        }

        public void SetUsingAsDefault(bool u)
        {
            useAsDefault = u;
        }
    }
}
