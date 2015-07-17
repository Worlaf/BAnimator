using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace BAnimator
{
    public class BoneGraphics : GBone
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

       
        public Character Character { get; protected set; }

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
                    Character.GraphicsManager.Resort(this);
                }
            }
        }
         

        public Group Group { get; set; }

        public BoneGraphics(Character parent)
        {
            IsRoot = false;
            Character = parent;
            Group = null;
            Order = 0;
            Length = 100;
            Angle = 0;
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
            if (!Parent.Visible)
                return;
            if (Group != null && !Group.Visible)
                return;

            //???????????????????????
            //Одни параметры угла и сдвига для всех изображений?
            //Либо для каждого свое?
            BoneImage bi = null;
            Bitmap bmp;
            double angle = Angle;
            

            for (int i = 0; i < images.Count; i++)
            {
                if (images[i].UseAsDefault)
                    bi = images[i];
                if (Character.StateManager.CheckCharacterStateValues(images[i].States))
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

            //Переделать все нахрен мы все поменяли!
            //И при редактировании все переделать!
            bi.Update();
            Utilities.PointV shift = bi.StartPoint;
            Utilities.PointV p1 = Utilities.PointV.Sub(bi.EndPoint, bi.StartPoint);
            p1.Length = bi.Image.Width;
            Utilities.PointV p2 = p1;
            p1 = p1.Rotate(Math.PI / 2);
            p2.Length = bi.Image.Height;
            shift = shift.Add(rootPos);
            p1 = p1.Add(rootPos).Add(bi.StartPoint);
            p2 = p2.Add(rootPos).Add(bi.StartPoint);

            int x0 = 0, y0 = bmp.Height, w = bmp.Width, h = -bmp.Height;
            if (bi.FlipX)
            {
                x0 = bmp.Width;
                w = -bmp.Width;
            }
            if (bi.FlipY)
            {
                y0 = 0;
                h = bmp.Height;
            }
            graph.DrawImage(bmp, new PointF[] { shift, p1, p2 }, new Rectangle(x0, y0, w, h), GraphicsUnit.Pixel);
            /*
            graph.DrawLine(Pens.Blue, shift, p1);
            graph.DrawLine(Pens.Green, shift, p2);
            */

        }
    }
}
