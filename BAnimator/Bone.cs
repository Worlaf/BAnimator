using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace BAnimator
{
    public class Bone : IEditable
    {
        protected bool _updated = false;
        protected double angle;
        protected double length;
        protected PointF shift;
        protected List<Bone> children = new List<Bone>();

        protected PointF startPoint, endPoint;

        /// <summary>
        /// Является ли кость главной
        /// </summary>
        [DisplayName("Главная кость")]
        [Description("Показывает, является ли кость главной (root)")]
        [Browsable(true)]
        public bool IsRoot { get; protected set; }

        /// <summary>
        /// Возвращает родительскую кость. Если она не задана, возвращает null
        /// </summary>
        public Bone Parent { get; protected set; }

        /// <summary>
        /// Угол наклона кости относительно родительской
        /// </summary>
        [DisplayName("Угол")]
        [Description("Угол наклона кости относительно родительской")]
        [Browsable(true)]
        public double Angle { get { return angle; } set { _updated = false; angle = value; if (angle > Math.PI)angle -= 2 * Math.PI; if (angle < -Math.PI)angle += 2 * Math.PI; } }

        /// <summary>
        /// Угол наклона кости относительно родительской в градусах
        /// </summary>
        [DisplayName("Угол в градусах")]
        [Description("Угол наклона кости относительно родительской в градусах")]
        [Browsable(true)]
        public double AngleDegree { get { return angle * Utilities.VMath.RadiansToDegreeK; } set { _updated = false; angle = value / Utilities.VMath.RadiansToDegreeK; } }

        /// <summary>
        /// Возвращает абсолютный угол поворота кости
        /// </summary>
        [DisplayName("Абсолютный угол")]
        [Description("Угол наклона кости относительно начала координат")]
        [Browsable(true)]
        public double AbsoluteAngle
        {
            get
            {
                if (Parent == null)
                    return Angle;
                else
                    return Angle + Parent.AbsoluteAngle;
            }
        }

        /// <summary>
        /// Длина кости
        /// </summary>
        [DisplayName("Длина кости")]
        [Description("Длина кости")]
        [Browsable(true)]
        public double Length { get { return length; } set { _updated = false; length = value; } }

        /// <summary>
        /// Сдвиг кости относительно конца родительской
        /// </summary>
        [DisplayName("Сдвиг кости")]
        [Description("Сдвиг кости относительно родительской")]
        [Browsable(true)]
        [TypeConverter(typeof(TypeConverters.PointFTypeConverter))]
        public PointF Shift { get { return shift; } set { _updated = false; shift = value; } }

        /// <summary>
        /// Возвращает начальную точку кости
        /// </summary>
        public PointF StartPoint { get { Update(); return startPoint; } }

        [Browsable(false)]
        public PointF Location { get { return startPoint; } }
        [Browsable(false)]
        public PointF ParentPoint { get { return Parent.EndPoint; } }

        /// <summary>
        /// Возвращает конечную точку кости
        /// </summary>
        public PointF EndPoint { get { Update(); return endPoint; } }

        /// <summary>
        /// Имя кости
        /// </summary>
        [DisplayName("Имя кости")]
        [Description("Имя кости")]
        [Browsable(true)]
        public string Name { get; set; }

        /// <summary>
        /// Идентификатор кости
        /// </summary>
        public uint ID { get; protected set; }

        public List<Bone> Children { get { return children; } }

        /// <summary>
        /// Отрисовывается ли изображение для данной кости
        /// </summary>
        public bool Visible { get; set; }

        /// <summary>
        /// Отрисовывается ли изображение для дочерних костей
        /// </summary>
        public bool ChildrenVisible { get{return childrenVisible;} set { SetChildrenVisible(childrenVisible = value); } }
        protected bool childrenVisible;


        /// <summary>
        /// Инициализирует главную кость
        /// </summary>
        public Bone()
        {
            this.IsRoot = true;
            this.Parent = null;
            this.Angle = 0;
            this.Length = 0;
            this.Shift = PointF.Empty;
            this.Visible = true;
            startPoint = PointF.Empty;
            endPoint = PointF.Empty;
            Name = "Новая кость";
        }

        public Bone(Bone parent, double angle, double length, PointF shift)
        {
            if (parent == null)
            {
                throw new Exception("Родительская кость не может быть null");
            }

            Bone root = parent.FindRoot();
            uint id = (uint)root.GetAllChildrenCount();
            while (root.IdentificatorExists(id))
            {
                id++;
            }

            this.ID = id;

            this.IsRoot = false;
            this.Parent = parent;
            parent.children.Add(this);
            this.Angle = angle;
            this.Length = length;
            this.Shift = shift;
            this.Visible = true;
            Name = "Новая кость";
        }

        internal Bone(Bone parent, double angle, double length, PointF shift, string name, uint id)
        {
            if (parent == null)
            {
                throw new Exception("Родительская кость не может быть null");
            }

           
            this.ID = id;

            this.IsRoot = false;
            this.Parent = parent;
            parent.children.Add(this);
            this.Angle = angle;
            this.Length = length;
            this.Shift = shift;
            this.Visible = true;
            Name = name;
        }

        /// <summary>
        /// Удаляет кость из набора родительской кости и удаляет все дочерние кости
        /// </summary>
        public void Remove()
        {
            this.Parent.children.Remove(this);
            this.Parent = null;
            //Достаточно ли такой очистки?
            //check
            this.children.Clear();
            
        }

        /// <summary>
        /// Добавляет дочернюю кость с нулевым углом и длиной 100
        /// </summary>
        /// <returns>Добавленная кость</returns>
        public Bone AddChild()
        {
            return new Bone(this, 0, 100, PointF.Empty);
        }

        /// <summary>
        /// Добавляет дочернюю кость с указанной длиной и углом
        /// </summary>
        /// <param name="length"></param>
        /// <param name="angle"></param>
        /// <returns></returns>
        public Bone AddChild(double length, double angle = 0)
        {
            return new Bone(this, length, angle, PointF.Empty);
        }

        public virtual void Update()
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
            sx = Math.Cos(sa) * sl + Parent.endPoint.X;
            sy = Math.Sin(sa) * sl + Parent.endPoint.Y;
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


        public int GetAllChildrenCount()
        {
            int cnt = 0;
            for (int i = 0; i < children.Count; i++)
            {
                cnt++;
                cnt += children[i].GetAllChildrenCount();
            }
            return cnt;
        }

        public Bone FindRoot()
        {
            if (this.IsRoot)
                return this;

            return Parent.FindRoot();
        }


        public Bone FindBone(uint id)
        {
            if (ID == id)
                return this;

            Bone b;

            for (int i = 0; i < children.Count; i++)
            {
                b = children[i].FindBone(id);
                if (b != null)
                    return b;
            }

            return null;
        }

        public bool IdentificatorExists(uint id)
        {
           
            if (id == ID)
                return true;

            for (int i = 0; i < children.Count; i++)
            {
                if (children[i].IdentificatorExists(id))
                    return true;
            }

            return false;
        }

        protected void SetChildrenVisible(bool visible, bool sub = true)
        {
            for (int i = 0; i < children.Count; i++)
            {
                children[i].Visible = visible;
                if (sub)
                    children[i].SetChildrenVisible(visible);
            }
        }

        
    }
}
