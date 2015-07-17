using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace BAnimator
{

    //Унаследовать все от кости нахрен
    //И не париться
    public class BoneImage : GBone
    {
        protected bool useAsDefault = false;
        public bool UseAsDefault { get { return useAsDefault; } set { ((BoneGraphics)Parent).SetDefaultImage(this); useAsDefault = value;  } }

        public bool FlipX { get; set; }
        public bool FlipY { get; set; }

        public Bitmap Image { get; set; }

        public List<CharacterStateValue> States { get; set; }

        public BoneImage(BoneGraphics parent)
        {
            IsRoot = false;
            this.Parent = parent;
            Length = 100;
            Angle = 0;
        }

        public void SetUsingAsDefault(bool u)
        {
            useAsDefault = u;
        }
    }
}
