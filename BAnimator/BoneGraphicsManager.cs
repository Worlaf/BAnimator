using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace BAnimator
{
    public class BoneGraphicsManager
    {
        protected List<BoneGraphics> list = new List<BoneGraphics>();
        protected List<BoneGraphics> sortedList = new List<BoneGraphics>();

        protected Character parent;

        public BoneGraphics this[int i]
        {
            get { return list[i]; }
        }

        public int Count { get { return list.Count; } }

        public void Add(BoneGraphics graphics)
        {
            list.Add(graphics);
            if (sortedList.Count == 0)
            {
                sortedList.Add(graphics);
            }
            else if (sortedList.Count == 1)
            {
                if (sortedList[0].Order > graphics.Order)
                    sortedList.Add(graphics);
                else
                    sortedList.Insert(0, graphics);
            }
            else
            {
                if (sortedList[0].Order < graphics.Order)
                {
                    sortedList.Insert(0, graphics);
                }
                else if (sortedList[sortedList.Count - 1].Order >= graphics.Order)
                {
                    sortedList.Add(graphics);
                }
                else
                {
                    for (int i = 0; i < sortedList.Count - 1; i++)
                    {
                        if (sortedList[i].Order >= graphics.Order && sortedList[i + 1].Order <= graphics.Order)
                        {
                            sortedList.Insert(i + 1, graphics);
                            break;
                        }
                    }
                }
            }
        }

        public void Sort()
        {
            sortedList.Sort(delegate(BoneGraphics x, BoneGraphics y)
            {
                return x.Order - y.Order;
            });
            return;
        }

        public void Resort(BoneGraphics g)
        {
            if (sortedList.IndexOf(g) < 0)
                return;
            sortedList.Remove(g);
            Add(g);
        }

        public int FindGraphics(BoneGraphics g)
        {
            return list.IndexOf(g);
        }

        public BoneGraphicsManager(Character ch)
        {
            parent = ch;
        }

        public void Remove(BoneGraphics graphics)
        {
            list.Remove(graphics);
            sortedList.Remove(graphics);
        }

        public void Draw(Graphics graph, PointF rootPos)
        {
            BoneGraphics item;
            for (int i = 0; i < sortedList.Count; i++)
            {
                item = sortedList[i];

                if (!item.Parent.Visible || item.Group != null && !item.Group.Visible)
                    continue;
                item.Update();
                item.Draw(graph, rootPos);
            }
        }

    }
}
