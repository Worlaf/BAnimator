using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BAnimator_WinForms
{
    public partial class frmMain : Form
    {
        UserInterface.BoneEditor bEditor;
        
        public frmMain()
        {
            InitializeComponent();
        }

        private void tvwProject_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag != null)
            {
                propertyGrid2.SelectedObject = e.Node.Tag;
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            bEditor = new UserInterface.BoneEditor(picMain);
            bEditor.Redraw();
            bEditor.SetBoneNode(tvwProject.Nodes.Find("BonesNode", true)[0]);
            bEditor.SetImageNode(tvwProject.Nodes.Find("ImagesNode", true)[0]);
            bEditor.SetMainTree(tvwProject);
            tvwProject.ExpandAll();

            BAnimator.Character ch = BAnimator.Character.Load("character.bc");
            bEditor.LoadCharacter(ch);

            uint esc = (uint)Keys.D;

            tvwProject.Nodes[0].Tag = bEditor.Character;
            tvwProject.Nodes[1].Nodes[0].Tag = bEditor;
            tvwProject.Nodes[1].Nodes[1].Tag = Properties.Settings.Default;
            
        }

       

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            bEditor.Redraw();
        }

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {

        }

        private void propertyGrid2_Click(object sender, EventArgs e)
        {

        }

        private void propertyGrid2_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            bEditor.Redraw();
            propertyGrid2.Refresh();
        }

        private void picMain_Click(object sender, EventArgs e)
        {
            this.Focus();
        }

        private void tvwProject_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                
                if (e.Node.Tag is BAnimator.BoneGraphics)
                {
                    tvwProject.SelectedNode = e.Node;
                    ctxGraphicsMenu.Show(tvwProject.PointToScreen(e.Location));
                }
                else if (e.Node.Tag is BAnimator.BoneImage)
                {
                }
                else if (e.Node.Tag is BAnimator.Bone)
                {
                    tvwProject.SelectedNode = e.Node;
                    ctxBoneMenu.Show(tvwProject.PointToScreen(e.Location));
                }
            }
        }

        private void tsmAddBone_Click(object sender, EventArgs e)
        {
            bEditor.AddBone(tvwProject.SelectedNode.Tag as BAnimator.Bone);
        }

        private void tsmRemoveBone_Click(object sender, EventArgs e)
        {
            bEditor.RemoveBone(tvwProject.SelectedNode.Tag as BAnimator.Bone);
        }

        

        private void btnBEM_GridSnap_Click(object sender, EventArgs e)
        {
            if (btnBEM_GridSnap.Checked)
            {
                btnBEM_GridSnap.Checked = btnBEM_Grid.Checked;
            }
            bEditor.SnapGrid = btnBEM_GridSnap.Checked && btnBEM_Grid.Checked;
            
        }

        private void btnBEM_Grid_Click(object sender, EventArgs e)
        {
            bEditor.DrawGrid = btnBEM_Grid.Checked;
            bEditor.Redraw();
        }

        private void tsZoom_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            bEditor.Character.Save("character.bc");
            Properties.Settings.Default.Save();
        }

        private void tsmCreateBoneGraphics_Click(object sender, EventArgs e)
        {
            if (!(tvwProject.SelectedNode.Tag is BAnimator.Bone))
            {
                return;
            }
            bEditor.AddGraphics((BAnimator.Bone)tvwProject.SelectedNode.Tag);
        }

        private void tsmDownloadImage_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
            DialogResult res = openFileDialog1.ShowDialog();
            if (res == System.Windows.Forms.DialogResult.OK)
            {
                if (tvwProject.SelectedNode.Tag is BAnimator.BoneGraphics && openFileDialog1.FileName != "")
                {
                    bEditor.AddImage(tvwProject.SelectedNode.Tag as BAnimator.BoneGraphics, new Bitmap(openFileDialog1.FileName), false);
                }
            }
        }

        private void tsmRemoveGraphics_Click(object sender, EventArgs e)
        {
            TreeNode tn = tvwProject.SelectedNode;
            if (tn.Tag is BAnimator.BoneGraphics)
            {
                bEditor.RemoveGraphics(tn.Tag as BAnimator.BoneGraphics);
            }
        }
    }
}
