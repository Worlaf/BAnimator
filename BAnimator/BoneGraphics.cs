using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BAnimator
{
    public class BoneGraphics
    {
        /// <summary>
        /// Набор возможных изображений
        /// </summary>
        protected List<BoneImage> images = new List<BoneImage>();

        public BoneImage this[int i]
        {
            get { return images[i]; }
            set { images[i] = value; }
        }

        public int Count { get { return images.Count; } }

        /// <summary>
        /// Связанная кость
        /// </summary>
        public Bone Bone { get; set; }

        /// <summary>
        /// Угол между костью и изображением
        /// </summary>
        public double Angle { get; set; }

        /// <summary>
        /// Свдиг изображения
        /// </summary>
        public PointF Shift { get; set; }

         protected int order = 0;
        /// <summary>
        /// Порядок отображения
        /// </summary>
         public int Order
         {
             get { return order; }
             set
             {
                 if (value != order)
                 {
                     order = value;
                     Parent.GraphicsManager.Resort(this);
                 }
             }
         }
       

        public Character Parent { get; protected set; }

        public Group Group { get; set; }

        public BoneGraphics(Character parent)
        {
            Parent = parent;
            Group = null;
            Order = 0;
        }

        public BoneImage AddImage(Bitmap bmp)
        {
            BoneImage bi = new BoneImage(this);

            bi.SetUsingAsDefault(images.Count == 0);
            bi.Image = bmp;            
            images.Add(bi);
            return bi;
        }

        public void RemoveImage(BoneImage bi)
        {
            images.Remove(bi);
        }

        /// <summary>
        /// Добавляет новое изображение по умолчанию
        /// </summary>
        /// <param name="bmp"></param>
        /// <returns></returns>
        public BoneImage AddDefaultImage(Bitmap bmp)
        {
            for (int i = 0; i < images.Count; i++)
            {
                images[i].UseAsDefault = false;
            }
            BoneImage bi = AddImage(bmp);
            bi.UseAsDefault = true;
            return bi;
        }

        public void SetDefaultImage(BoneImage bi)
        {
            if (images.IndexOf(bi) < 0)
                return;
            else if (bi.UseAsDefault)
                return;
            for (int i = 0; i < images.Count; i++)
            {
                images[i].SetUsingAsDefault(images[i] == bi);
            }
        }

        public void Draw(Graphics graph, PointF rootPos)
        {
            if (!Bone.Visible)
                return;
            if (Group != null && !Group.Visible)
                return;

            //???????????????????????
            //Одни параметры угла и сдвига для всех изображений?
            //Либо для каждого свое?
            BoneImage bi = null;
            Bitmap bmp;
            double angle = Angle;
            PointF shift = Shift;

            for (int i = 0; i < images.Count; i++)
            {
                if (images[i].UseAsDefault)
                    bi = images[i];
                if (Parent.StateManager.CheckCharacterStateValues(images[i].States))
                {
                    bi = images[i];
                    break;
                }
            }
            if (bi == null)
            {
                //throw new Exception("Some exception");
                return;
            }
            bmp = bi.Image;
            angle += bi.Angle + Bone.AbsoluteAngle;
            shift = Utilities.PointV.Add(shift, bi.Shift);
            shift = Utilities.PointV.Add(shift, rootPos);
            shift = Utilities.PointV.Add(shift, Bone.StartPoint);

            Utilities.PointV pt1 = new Utilities.PointV(0, bmp.Height);
            Utilities.PointV pt2 = new Utilities.PointV(bmp.Width, 0);
            pt1 = pt1.Rotate(angle).Add(shift);
            pt2 = pt2.Rotate(angle).Add(shift);

            PointF p1 = pt1.Point;
            PointF p2 = pt2.Point;

            graph.DrawImage(bmp, new PointF[] { shift, p2, p1 }, new Rectangle(0, 0, bmp.Width, bmp.Height), GraphicsUnit.Pixel);

            graph.DrawLine(Pens.Blue, shift, p1);
            graph.DrawLine(Pens.Blue, shift, p2);


        }
    }
}
