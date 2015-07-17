using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using BAnimator;
using BAnimator.Utilities;

namespace BAnimator_WinForms.UserInterface
{
    public class BoneEditor
    {
        //Тут лучше даже не пытаться разобраться
        //Самый страшный класс во всем проекте
        public enum EditModes { None, BONE_ROTATE, BONE_SHIFT, BONE_STRETCH, BONE_STRETCH_ROTATE }
        public enum SelectModes { None = 0x0, Bones = 0x1 }


        PictureBox pic;
        Graphics graph;

        public bool DrawGrid { get; set; }
        public int GreedStep { get; set; }
        public bool SnapGrid { get; set; }

        public List<Bone> bones = new List<Bone>();

        public Character Character { get; protected set; }
        
        public Bone root = new Bone();
        public PointF rootPos;
        public PointF screenCenter;

        public SelectModes SelectMode { get; set; }

        protected EditModes editMode;

        protected Bone selectedBone = null;
        protected Object selectedObject = null;


        #region Bones TreeView
        TreeView bonesTree;
        public void SetBonesTree(TreeView bonesTree)
        {
            if (this.bonesTree != null)
            {
                bonesTree.AfterCheck -= bonesTree_AfterCheck;
                bonesTree.AfterLabelEdit -= bonesTree_AfterLabelEdit;
                bonesTree.AfterSelect -= bonesTree_AfterSelect;
            }
            this.bonesTree = bonesTree;
            bonesTree.AfterCheck += bonesTree_AfterCheck;
            bonesTree.AfterLabelEdit += bonesTree_AfterLabelEdit;
            bonesTree.AfterSelect += bonesTree_AfterSelect;

            RefreshBonesTree();
        }

        public void RefreshBonesTree()
        {
            if (bonesTree == null)
                return;

            bonesTree.Nodes.Clear();
            TreeNode node = bonesTree.Nodes.Add("bone0", "root");
            node.Tag = root;
            FillBoneNode(root, node);
            bonesTree.ExpandAll();

        }

       

        public void FillBoneNode(Bone bone, TreeNode node)
        {
            TreeNode n;
            foreach (Bone b in bone.Children)
            {
                n = node.Nodes.Add("bone" + bones.IndexOf(b,0), b.Name);
                n.ImageKey = "bone";
                n.SelectedImageKey = "bone";
                n.Tag = b;
               
                FillBoneNode(b, n);
            }
        }

        void bonesTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            selectedBone = null;
            if (e.Node.Tag as Bone == null)
                return;
            selectedBone = (Bone)e.Node.Tag;
            Redraw();
        }

        void bonesTree_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Node.Tag as Bone == null)
                return;
            if (e.Label == "")
            {
                e.CancelEdit = true;
                return;
            }
            ((Bone)e.Node.Tag).Name = e.Label;
        }

        void bonesTree_AfterCheck(object sender, TreeViewEventArgs e)
        {
            //throw new NotImplementedException();
        }

        #endregion
        
        #region Bones Node
        TreeNode parentBoneNode;
        public void SetBoneNode(TreeNode node)
        {
            if (parentBoneNode != null)
            {
                node.TreeView.AfterLabelEdit -= bonesTree_AfterLabelEdit;
                node.TreeView.AfterSelect -= bonesTree_AfterSelect;
            }
            parentBoneNode = node;
            node.TreeView.AfterLabelEdit += bonesTree_AfterLabelEdit;
            node.TreeView.AfterSelect += bonesTree_AfterSelect;
            RefreshBonesNode();
        }

        public void RefreshBonesNode()
        {
            parentBoneNode.Nodes.Clear();
            TreeNode node = parentBoneNode.Nodes.Add("bone0","root");
            node.Tag = root;
            node.SelectedImageKey = node.ImageKey = "bone";
            
            FillBoneNode(root, node);
        }
        #endregion

        #region Images Node
        TreeNode parentImageNode;
        public void SetImageNode(TreeNode node)
        {
            parentImageNode = node;
        }

        public void FillImagesNode()
        {
            if (parentImageNode == null)
                return;

            parentImageNode.Nodes.Clear();

            int i, j;
            TreeNode node, node2;
            for (i = 0; i < Character.GraphicsManager.Count; i++)
            {
                node = parentImageNode.Nodes.Add("boneGraphics" + i, Character.GraphicsManager[i].Parent.Name + " graphics " + i, "graphics");
                node.Tag = Character.GraphicsManager[i];
                node.SelectedImageKey = "graphics";
                for (j = 0; j < Character.GraphicsManager[i].Count; j++)
                {
                    node2 = node.Nodes.Add("image" + j, "image" + j, "image");
                    node2.Tag = Character.GraphicsManager[i][j];
                }
            }
        }

        


        #endregion

        #region Main TreeView
        protected TreeView mainTree;
        public void SetMainTree(TreeView tvw)
        {
            if (mainTree != null)
            {
                mainTree.AfterSelect -= mainTree_AfterSelect;
            }
            mainTree = tvw;
            mainTree.AfterSelect += mainTree_AfterSelect;
        }

        void mainTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag as Bone != null)
            {
                selectedBone = (Bone)e.Node.Tag;
            }
            Redraw();
        }

        #endregion

        #region Work with bones

        public Bone AddBone(Bone b)
        {
            b = b.AddChild();
            bones.Add(b);
            if (bonesTree != null)
            {
                TreeNode[] pnodes = bonesTree.Nodes.Find("bone" + bones.IndexOf(b.Parent), true);
                if (pnodes != null)
                {
                    TreeNode n = pnodes[0].Nodes.Add("bone" + bones.IndexOf(b), b.Name);
                    n.ImageKey = "bone";
                    n.SelectedImageKey = "bone";
                    n.Tag = b;
                    bonesTree.SelectedNode = n;
                }                    
            }
            if (parentBoneNode != null)
            {
                TreeNode[] pnodes = parentBoneNode.Nodes.Find("bone" + bones.IndexOf(b.Parent), true);
                if (pnodes != null)
                {
                    TreeNode n = pnodes[0].Nodes.Add("bone" + bones.IndexOf(b), b.Name);
                    n.ImageKey = "bone";
                    n.SelectedImageKey = "bone";
                    n.Tag = b;
                    parentBoneNode.TreeView.SelectedNode = n;
                }  
            }
            return b;
        }

        public void RemoveBone(Bone b)
        {
            if (parentBoneNode != null)
            {
                TreeNode[] nodes = parentBoneNode.Nodes.Find("bone" + bones.IndexOf(b), true);
                if (nodes.Length > 0)
                {
                    nodes[0].Remove();
                }
            }
            if (bonesTree != null)
            {
                TreeNode[] nodes = bonesTree.Nodes.Find("bone" + bones.IndexOf(b), true);
                if (nodes.Length > 0)
                {
                    nodes[0].Remove();
                }
            }
            RemoveSubBones(b);
            bones.Remove(b);
            b.Remove();
            Redraw();
        }

        protected void RemoveSubBones(Bone b)
        {
            foreach (Bone bone in b.Children)
            {
                bones.Remove(bone);
                RemoveSubBones(bone);
            }
        }

        public void ExtractBone(Bone b)
        {
            throw new Exception("Not implemented exception");
        }

        #endregion

        #region Work with images
        public void AddGraphics(Bone bone)
        {

            BoneGraphics bg;
            Character.GraphicsManager.Add(bg = new BoneGraphics(Character));
            bg.SetParent(bone);
            if (parentImageNode == null)
                return;
            TreeNode node = parentImageNode.Nodes.Add("boneGraphics" + (Character.GraphicsManager.Count - 1),
                bone.Name + " graphics " + (Character.GraphicsManager.Count - 1), "graphics");
            node.SelectedImageKey = "graphics";
            node.Tag = bg;
            node.EnsureVisible();
            
        }

        public void AddImage(BoneGraphics bg, Bitmap bmp, bool asDefault)
        {
            BoneImage bi;
            if (asDefault)
                bi = bg.AddDefaultImage(bmp);
            else
                bi = bg.AddImage(bmp);
            if (parentImageNode == null)
                return;
            int idx = Character.GraphicsManager.FindGraphics(bg);
            TreeNode node = parentImageNode.Nodes.Find("boneGraphics" + idx, false)[0];
            TreeNode node2 = node.Nodes.Add("boneImage" + (bg.Count - 1), "image " + (bg.Count - 1), "image", "image");
            node2.Tag = bi;
            bi.Shift = new PointF(0, -bi.Image.Width / 2);
            node2.EnsureVisible();

            Redraw();
        }

        public void RemoveGraphics(BoneGraphics bg)
        {
            //РЕАЛИЗОВАТЬ
        }

        public void RemoveImage(BoneImage img, BoneGraphics bg)
        {
            //РЕАЛИЗОВАТЬ
        }
        #endregion

        public BoneEditor(PictureBox picBox)
        {
            setViewport(picBox);
            picBox.MouseClick += picBox_MouseClick;
            picBox.MouseDown += picBox_MouseDown;
            picBox.MouseUp += picBox_MouseUp;
            picBox.MouseMove += picBox_MouseMove;
            picBox.KeyDown += BoneEditor_KeyDown;
            picBox.KeyUp += BoneEditor_KeyUp;
            picBox.LostFocus += picBox_LostFocus;
            SelectMode = SelectModes.Bones;

            rootPos = new PointF(0,0);

            bones.Add(root);
            Bone b = root;
            b = AddBone(b);
            b = AddBone(b);
            b = AddBone(b);
            b = AddBone(b);

            GreedStep = 20;
            SnapGrid = false;
            DrawGrid = false;

            Character = new BAnimator.Character();
            Character.RootBone = root;

        }

        public void LoadCharacter(Character ch)
        {
            Character = ch;
            root = ch.RootBone;
            bones.Clear();
            bones.Add(root);
            AddSubBones(root);
            RefreshBonesNode();
            RefreshBonesTree();
            Redraw();

        }

        public void AddSubBones(Bone b)
        {
            for (int i = 0; i < b.Children.Count; i++)
            {
                bones.Add(b.Children[i]);
                AddSubBones(b.Children[i]);
            }
        }

        bool picLostFocus = false;

        void picBox_LostFocus(object sender, EventArgs e)
        {
            picLostFocus = true;
        }

        PointF lastPt;

        void picBox_MouseMove(object sender, MouseEventArgs e)
        {
            //Тут жесть полнейшая

            //Проверка, теряло ли изображение фокус
            //чтобы при получении фокуса сразу же не происходило редактирование
            if (picLostFocus)
                return;
            
            if (e.Button == MouseButtons.Left)
            {

                if (selectedBone == null)
                    return;
               

                PointF loc = e.Location;

                //Если нужно, приводим координаты к сетке
                if (SnapGrid)
                {
                    loc.X = (((int)loc.X) / GreedStep) * GreedStep;
                    loc.Y = (((int)loc.Y) / GreedStep) * GreedStep;
                }

                
                ToRootBoneCoordinates(ref loc);

                PointV p = null, p0 = null, p1 = null , sv = null , pv = null;
                p = new PointV(loc);
                                   
                    p0 = new PointV(selectedBone.StartPoint);
                    p1 = new PointV(selectedBone.EndPoint);
                    pv = p - p0;
                    sv = p1 - p0;
               

                switch (editMode)
                {
                    case EditModes.BONE_ROTATE:
                        #region Вращение
                        double da;

                        da = pv.Angle - sv.Angle;
                        selectedBone.Angle = selectedBone.Angle + da;

                        break;
                        #endregion
                    case EditModes.BONE_SHIFT:
                        #region Сдвиг

                        if (!selectedBone.IsRoot)
                        {
                            PointV shift = new PointV(PointV.Sub(loc, selectedBone.Parent.EndPoint));
                            shift.Angle -= selectedBone.Parent.AbsoluteAngle;
                            selectedBone.Shift = shift.Point;
                        }
                        else
                        {
                            screenCenter = e.Location;
                        }

                        break;
                        #endregion
                    case EditModes.BONE_STRETCH:
                        #region Растяжение

                        double proj = (pv.X * sv.X + pv.Y * sv.Y) / sv.Length;
                        selectedBone.Length = proj;

                        break;
                        #endregion
                    case EditModes.BONE_STRETCH_ROTATE:
                        #region Растяжение и вращение

                       
                        da = pv.Angle - sv.Angle;
                        selectedBone.Angle = selectedBone.Angle + da;
                        proj = (pv.X * sv.X + pv.Y * sv.Y) / sv.Length;
                        selectedBone.Length = proj;

                        break;
                        #endregion

                }
                Redraw();
            }
        }

        void picBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (picLostFocus)
                return;
        }

        void picBox_MouseDown(object sender, MouseEventArgs e)
        {
            lastPt = e.Location;
            ToRootBoneCoordinates(ref lastPt);
        }

        void BoneEditor_KeyUp(object sender, KeyEventArgs e)
        {
            //editMode = EditModes.None;
        }

        void BoneEditor_KeyDown(object sender, KeyEventArgs e)
        {
            if (picLostFocus)
                return;
            uint key = (uint)e.KeyCode;
            if (key == Properties.Settings.Default.HotKeys_Bone_Rotate)
            {
                editMode = EditModes.BONE_ROTATE;
            }
            if (key == Properties.Settings.Default.HotKeys_Bone_Shift)
            {
                editMode = EditModes.BONE_SHIFT;
            }
            if (key == Properties.Settings.Default.HotKeys_Bone_Stretch)
            {
                editMode = EditModes.BONE_STRETCH;
            }
            if (key == Properties.Settings.Default.HotKeys_Bone_FreeEdit)
            {
                editMode = EditModes.BONE_STRETCH_ROTATE;
            }
            if (key == Properties.Settings.Default.HotKeys_Cancel)
            {
                editMode = EditModes.None;
            }

            if (e.KeyCode == Keys.T)
            {
                drawDistanceTestPoints = true;
                
            }
            Redraw();
        }

        void picBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (picLostFocus)
            {
                picLostFocus = false;
                return;
            }


            if (SelectMode == SelectModes.None)
                return;
            
            PointF loc = e.Location;
            if (editMode == EditModes.None &&  (SelectMode & SelectModes.Bones) > 0)
            {
                selectedBone = null;
                ToRootBoneCoordinates(ref loc);
                double min = 100;
                int mini = -1;
                double dst = 0;
                for (int i = 0; i < bones.Count; i++)
                {
                    if ((dst = Math.Abs(VMath.GetDistance(bones[i].StartPoint, bones[i].EndPoint, loc))) < min)
                    {
                        min = dst;
                        mini = i;
                    }
                    /*if (VMath.CheckDistance(bones[i].StartPoint, bones[i].EndPoint, loc, 20, true))
                    {
                        selectedBone = bones[i];

                        break;
                    }*/
                }
                if (mini >= 0)
                {
                    selectedBone = bones[mini];
                    if (parentBoneNode != null)
                    {
                        TreeNode[] snodes = parentBoneNode.Nodes.Find("bone" + mini, true);
                        if (snodes != null && snodes.Length>0)
                        {
                            snodes[0].TreeView.SelectedNode = snodes[0];
                            snodes[0].EnsureVisible();
                            
                        }
                    }
                    if (bonesTree != null)
                    {
                        TreeNode[] snodes = bonesTree.Nodes.Find("bone" + mini, true);
                        if (snodes != null && snodes.Length > 0)
                        {
                            snodes[0].TreeView.SelectedNode = snodes[0];
                        }
                    }
                    
                }
            }
            Redraw();
        }

        public void ToRootBoneCoordinates(ref PointF pt)
        {
            pt = PointV.Sub(ref pt, ref screenCenter);
            pt = PointV.Sub(ref pt, ref rootPos);
        }

        protected void setViewport(PictureBox pic)
        {
            if (this.pic != null && this.pic.Size != null)
            {
                this.pic.SizeChanged -= pic_SizeChanged;
            }
            this.pic = pic;
            this.pic.SizeChanged += pic_SizeChanged;
            ResetGraphics();
        }

        protected void pic_SizeChanged(object sender, EventArgs e)
        {
            ResetGraphics();
            Redraw();
        }

        public void ResetGraphics()
        {
            pic.Image = new Bitmap(pic.Width, pic.Height);
            graph = Graphics.FromImage(pic.Image);
            graph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            graph.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            screenCenter.X = pic.Width / 2;
            screenCenter.Y = pic.Height / 2;
        }

        bool drawDistanceTestPoints = false;
        

        public void Redraw()
        {
            PointV p0, p1;

            graph.Clear(Color.White);

            Character.GraphicsManager.Draw(graph, PointV.Add(ref rootPos, ref screenCenter));

            BoneDrawer.DrawParametres p = BoneDrawer.DrawParametres.None;
            if (editMode == EditModes.BONE_ROTATE)
                p = BoneDrawer.DrawParametres.DrawAngleCtl;
            if (editMode == EditModes.BONE_SHIFT)
                p = BoneDrawer.DrawParametres.DrawShiftCtl;
            if (editMode == EditModes.BONE_STRETCH)
                p = BoneDrawer.DrawParametres.DrawStretchCtl;
            if (editMode == EditModes.BONE_STRETCH_ROTATE)
                p = BoneDrawer.DrawParametres.DrawFreeEditCtl;

            int i, j;
            if (DrawGrid)
            {
                for (i = GreedStep; i <= pic.Width - GreedStep; i += GreedStep)
                {
                    for (j = GreedStep; j <= pic.Height - GreedStep; j += GreedStep)
                    {
                        graph.DrawLine(Pens.Gray, i, j, i + 0.1f, j + 0.1f);
                    }
                }
            }

            DrawBone(root);           

            if (selectedBone != null)
            {
                BoneDrawer.DrawControls(graph, PointV.Add(ref rootPos, ref screenCenter), selectedBone, p);
            }
            

          

            pic.Refresh();
        }

        public void DrawBone(Bone b)
        {
            BoneDrawer.DrawBone(b, graph, PointV.Add(ref rootPos, ref screenCenter), b == selectedBone);
            for (int i = 0; i < b.Children.Count; i++)
            {
                DrawBone(b.Children[i]);
            }

        }
    }
}
