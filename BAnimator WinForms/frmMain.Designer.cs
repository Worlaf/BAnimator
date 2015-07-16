namespace BAnimator_WinForms
{
    partial class frmMain
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Кости", 42, 42);
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Изображения", 22, 22);
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Анимации", 41, 41);
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("События", 26, 26);
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Состояния", 44, 44);
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Эффекты", 43, 43);
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Персонаж", 38, 38, new System.Windows.Forms.TreeNode[] {
            treeNode11,
            treeNode12,
            treeNode13,
            treeNode14,
            treeNode15,
            treeNode16});
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Проект");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Настройки");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Рабочее место", new System.Windows.Forms.TreeNode[] {
            treeNode18,
            treeNode19});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.tsFile = new System.Windows.Forms.ToolStrip();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnOpen = new System.Windows.Forms.ToolStripButton();
            this.btnNew = new System.Windows.Forms.ToolStripButton();
            this.tsSelectMode = new System.Windows.Forms.ToolStrip();
            this.chSelectBones = new System.Windows.Forms.ToolStripButton();
            this.tsAnimation = new System.Windows.Forms.ToolStrip();
            this.btnSkipToStart = new System.Windows.Forms.ToolStripButton();
            this.btnPlayPause = new System.Windows.Forms.ToolStripButton();
            this.btnSkipToEnd = new System.Windows.Forms.ToolStripButton();
            this.btnRepeat = new System.Windows.Forms.ToolStripButton();
            this.tsBoneEditor = new System.Windows.Forms.ToolStrip();
            this.chBEM_Rotate = new System.Windows.Forms.ToolStripButton();
            this.btnBEM_Shift = new System.Windows.Forms.ToolStripButton();
            this.btnBEM_STRETCH = new System.Windows.Forms.ToolStripButton();
            this.btnBEM_FreeEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnBEM_Grid = new System.Windows.Forms.ToolStripButton();
            this.btnBEM_GridSnap = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.tvwProject = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.propertyGrid2 = new System.Windows.Forms.PropertyGrid();
            this.ctxBoneMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmAddBone = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRemoveBone = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmExtractBone = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCreateBoneGraphics = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxImageMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmDownloadImage = new System.Windows.Forms.ToolStripMenuItem();
            this.picMain = new SelectablePictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.tsFile.SuspendLayout();
            this.tsSelectMode.SuspendLayout();
            this.tsAnimation.SuspendLayout();
            this.tsBoneEditor.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.ctxBoneMenu.SuspendLayout();
            this.ctxImageMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.toolStripContainer1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(802, 429);
            this.splitContainer1.SplitterDistance = 581;
            this.splitContainer1.TabIndex = 0;
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.picMain);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(581, 404);
            this.toolStripContainer1.ContentPanel.Load += new System.EventHandler(this.toolStripContainer1_ContentPanel_Load);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(581, 429);
            this.toolStripContainer1.TabIndex = 2;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.tsBoneEditor);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.tsFile);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.tsAnimation);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.tsSelectMode);
            // 
            // tsFile
            // 
            this.tsFile.Dock = System.Windows.Forms.DockStyle.None;
            this.tsFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave,
            this.btnOpen,
            this.btnNew});
            this.tsFile.Location = new System.Drawing.Point(165, 0);
            this.tsFile.Name = "tsFile";
            this.tsFile.Size = new System.Drawing.Size(81, 25);
            this.tsFile.TabIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Image = global::BAnimator_WinForms.Properties.Resources.disk;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(23, 22);
            this.btnSave.Text = "Сохранить персонажа";
            // 
            // btnOpen
            // 
            this.btnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOpen.Image = global::BAnimator_WinForms.Properties.Resources.folder_horizontal_open;
            this.btnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(23, 22);
            this.btnOpen.Text = "Открыть";
            // 
            // btnNew
            // 
            this.btnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNew.Image = global::BAnimator_WinForms.Properties.Resources.document;
            this.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(23, 22);
            this.btnNew.Text = "Новый персонаж";
            // 
            // tsSelectMode
            // 
            this.tsSelectMode.Dock = System.Windows.Forms.DockStyle.None;
            this.tsSelectMode.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chSelectBones});
            this.tsSelectMode.Location = new System.Drawing.Point(353, 0);
            this.tsSelectMode.Name = "tsSelectMode";
            this.tsSelectMode.Size = new System.Drawing.Size(35, 25);
            this.tsSelectMode.TabIndex = 4;
            // 
            // chSelectBones
            // 
            this.chSelectBones.CheckOnClick = true;
            this.chSelectBones.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.chSelectBones.Image = global::BAnimator_WinForms.Properties.Resources.Animals_Dog_Bone_icon;
            this.chSelectBones.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.chSelectBones.Name = "chSelectBones";
            this.chSelectBones.Size = new System.Drawing.Size(23, 22);
            this.chSelectBones.Text = "Выбирать кости";
            // 
            // tsAnimation
            // 
            this.tsAnimation.Dock = System.Windows.Forms.DockStyle.None;
            this.tsAnimation.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSkipToStart,
            this.btnPlayPause,
            this.btnSkipToEnd,
            this.btnRepeat});
            this.tsAnimation.Location = new System.Drawing.Point(247, 0);
            this.tsAnimation.Name = "tsAnimation";
            this.tsAnimation.Size = new System.Drawing.Size(104, 25);
            this.tsAnimation.TabIndex = 3;
            // 
            // btnSkipToStart
            // 
            this.btnSkipToStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSkipToStart.Image = global::BAnimator_WinForms.Properties.Resources.control_skip_180_8636;
            this.btnSkipToStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSkipToStart.Name = "btnSkipToStart";
            this.btnSkipToStart.Size = new System.Drawing.Size(23, 22);
            this.btnSkipToStart.Text = "В начало";
            // 
            // btnPlayPause
            // 
            this.btnPlayPause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPlayPause.Image = global::BAnimator_WinForms.Properties.Resources.control_8113;
            this.btnPlayPause.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPlayPause.Name = "btnPlayPause";
            this.btnPlayPause.Size = new System.Drawing.Size(23, 22);
            this.btnPlayPause.Text = "Воспроизвести";
            // 
            // btnSkipToEnd
            // 
            this.btnSkipToEnd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSkipToEnd.Image = global::BAnimator_WinForms.Properties.Resources.control_skip_3345;
            this.btnSkipToEnd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSkipToEnd.Name = "btnSkipToEnd";
            this.btnSkipToEnd.Size = new System.Drawing.Size(23, 22);
            this.btnSkipToEnd.Text = "В конец";
            // 
            // btnRepeat
            // 
            this.btnRepeat.CheckOnClick = true;
            this.btnRepeat.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRepeat.Image = global::BAnimator_WinForms.Properties.Resources.arrow_repeat;
            this.btnRepeat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRepeat.Name = "btnRepeat";
            this.btnRepeat.Size = new System.Drawing.Size(23, 22);
            this.btnRepeat.Text = "Повтор";
            // 
            // tsBoneEditor
            // 
            this.tsBoneEditor.Dock = System.Windows.Forms.DockStyle.None;
            this.tsBoneEditor.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chBEM_Rotate,
            this.btnBEM_Shift,
            this.btnBEM_STRETCH,
            this.btnBEM_FreeEdit,
            this.toolStripSeparator1,
            this.btnBEM_Grid,
            this.btnBEM_GridSnap});
            this.tsBoneEditor.Location = new System.Drawing.Point(9, 0);
            this.tsBoneEditor.Name = "tsBoneEditor";
            this.tsBoneEditor.Size = new System.Drawing.Size(156, 25);
            this.tsBoneEditor.TabIndex = 1;
            this.tsBoneEditor.Text = "toolStrip2";
            // 
            // chBEM_Rotate
            // 
            this.chBEM_Rotate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.chBEM_Rotate.Image = global::BAnimator_WinForms.Properties.Resources.arrow_circle_135_left;
            this.chBEM_Rotate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.chBEM_Rotate.Name = "chBEM_Rotate";
            this.chBEM_Rotate.Size = new System.Drawing.Size(23, 22);
            this.chBEM_Rotate.Text = "Поворот";
            this.chBEM_Rotate.ToolTipText = "Режим вращения кости";
            // 
            // btnBEM_Shift
            // 
            this.btnBEM_Shift.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnBEM_Shift.Image = global::BAnimator_WinForms.Properties.Resources.arrow_move;
            this.btnBEM_Shift.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBEM_Shift.Name = "btnBEM_Shift";
            this.btnBEM_Shift.Size = new System.Drawing.Size(23, 22);
            this.btnBEM_Shift.Text = "Перемещение кости";
            this.btnBEM_Shift.ToolTipText = "Перемещение кости (относительно предка)";
            // 
            // btnBEM_STRETCH
            // 
            this.btnBEM_STRETCH.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnBEM_STRETCH.Image = global::BAnimator_WinForms.Properties.Resources.arrow_resize;
            this.btnBEM_STRETCH.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBEM_STRETCH.Name = "btnBEM_STRETCH";
            this.btnBEM_STRETCH.Size = new System.Drawing.Size(23, 22);
            this.btnBEM_STRETCH.Text = "Изменение длины";
            // 
            // btnBEM_FreeEdit
            // 
            this.btnBEM_FreeEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnBEM_FreeEdit.Image = global::BAnimator_WinForms.Properties.Resources.layer_select_point;
            this.btnBEM_FreeEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBEM_FreeEdit.Name = "btnBEM_FreeEdit";
            this.btnBEM_FreeEdit.Size = new System.Drawing.Size(23, 22);
            this.btnBEM_FreeEdit.Text = "Свободное редактирование";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnBEM_Grid
            // 
            this.btnBEM_Grid.CheckOnClick = true;
            this.btnBEM_Grid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnBEM_Grid.Image = global::BAnimator_WinForms.Properties.Resources.grid_dot;
            this.btnBEM_Grid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBEM_Grid.Name = "btnBEM_Grid";
            this.btnBEM_Grid.Size = new System.Drawing.Size(23, 22);
            this.btnBEM_Grid.Text = "Сетка";
            this.btnBEM_Grid.Click += new System.EventHandler(this.btnBEM_Grid_Click);
            // 
            // btnBEM_GridSnap
            // 
            this.btnBEM_GridSnap.CheckOnClick = true;
            this.btnBEM_GridSnap.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnBEM_GridSnap.Image = global::BAnimator_WinForms.Properties.Resources.grid_snap_dot;
            this.btnBEM_GridSnap.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBEM_GridSnap.Name = "btnBEM_GridSnap";
            this.btnBEM_GridSnap.Size = new System.Drawing.Size(23, 22);
            this.btnBEM_GridSnap.Text = "Привязка к сетке";
            this.btnBEM_GridSnap.Click += new System.EventHandler(this.btnBEM_GridSnap_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(217, 429);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(209, 403);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Проект";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(3, 3);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.tvwProject);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.propertyGrid2);
            this.splitContainer3.Size = new System.Drawing.Size(203, 397);
            this.splitContainer3.SplitterDistance = 197;
            this.splitContainer3.TabIndex = 1;
            // 
            // tvwProject
            // 
            this.tvwProject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwProject.ImageIndex = 0;
            this.tvwProject.ImageList = this.imageList1;
            this.tvwProject.LabelEdit = true;
            this.tvwProject.Location = new System.Drawing.Point(0, 0);
            this.tvwProject.Name = "tvwProject";
            treeNode11.ImageIndex = 42;
            treeNode11.Name = "BonesNode";
            treeNode11.SelectedImageIndex = 42;
            treeNode11.Text = "Кости";
            treeNode12.ImageIndex = 22;
            treeNode12.Name = "ImagesNode";
            treeNode12.SelectedImageIndex = 22;
            treeNode12.Text = "Изображения";
            treeNode13.ImageIndex = 41;
            treeNode13.Name = "AnimationsNode";
            treeNode13.SelectedImageIndex = 41;
            treeNode13.Text = "Анимации";
            treeNode14.ImageIndex = 26;
            treeNode14.Name = "EventsNode";
            treeNode14.SelectedImageIndex = 26;
            treeNode14.Text = "События";
            treeNode15.ImageIndex = 44;
            treeNode15.Name = "StatesNode";
            treeNode15.SelectedImageIndex = 44;
            treeNode15.Text = "Состояния";
            treeNode16.ImageIndex = 43;
            treeNode16.Name = "EffectsNode";
            treeNode16.SelectedImageIndex = 43;
            treeNode16.Text = "Эффекты";
            treeNode17.ImageIndex = 38;
            treeNode17.Name = "ProjectRoot";
            treeNode17.SelectedImageIndex = 38;
            treeNode17.Text = "Персонаж";
            treeNode18.ImageKey = "blueprint.png";
            treeNode18.Name = "ProjectNode";
            treeNode18.SelectedImageKey = "blueprint.png";
            treeNode18.Text = "Проект";
            treeNode19.ImageKey = "wrench_screwdriver.png";
            treeNode19.Name = "SettingsNode";
            treeNode19.SelectedImageKey = "wrench_screwdriver.png";
            treeNode19.Text = "Настройки";
            treeNode20.ImageKey = "projects_folder_badged.png";
            treeNode20.Name = "WorkspaceNode";
            treeNode20.SelectedImageKey = "projects_folder_badged.png";
            treeNode20.Text = "Рабочее место";
            this.tvwProject.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode17,
            treeNode20});
            this.tvwProject.SelectedImageIndex = 0;
            this.tvwProject.Size = new System.Drawing.Size(203, 197);
            this.tvwProject.TabIndex = 0;
            this.tvwProject.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwProject_AfterSelect);
            this.tvwProject.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvwProject_NodeMouseClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "accept.png");
            this.imageList1.Images.SetKeyName(1, "arrow_circle_double.png");
            this.imageList1.Images.SetKeyName(2, "arrow_in.png");
            this.imageList1.Images.SetKeyName(3, "arrow_move.png");
            this.imageList1.Images.SetKeyName(4, "arrow_out.png");
            this.imageList1.Images.SetKeyName(5, "cancel.png");
            this.imageList1.Images.SetKeyName(6, "control_8113.png");
            this.imageList1.Images.SetKeyName(7, "control_double_180_2329.png");
            this.imageList1.Images.SetKeyName(8, "control_double_4466.png");
            this.imageList1.Images.SetKeyName(9, "control_pause_1096.png");
            this.imageList1.Images.SetKeyName(10, "control_skip_180_8636.png");
            this.imageList1.Images.SetKeyName(11, "control_skip_3345.png");
            this.imageList1.Images.SetKeyName(12, "control_stop_square_7000.png");
            this.imageList1.Images.SetKeyName(13, "cross.png");
            this.imageList1.Images.SetKeyName(14, "cross_script.png");
            this.imageList1.Images.SetKeyName(15, "cutlery_knife.png");
            this.imageList1.Images.SetKeyName(16, "disk.png");
            this.imageList1.Images.SetKeyName(17, "document.png");
            this.imageList1.Images.SetKeyName(18, "exclamation.png");
            this.imageList1.Images.SetKeyName(19, "folder_horizontal.png");
            this.imageList1.Images.SetKeyName(20, "guide.png");
            this.imageList1.Images.SetKeyName(21, "hourglass.png");
            this.imageList1.Images.SetKeyName(22, "images_stack.png");
            this.imageList1.Images.SetKeyName(23, "layer_transparent.png");
            this.imageList1.Images.SetKeyName(24, "layers.png");
            this.imageList1.Images.SetKeyName(25, "light_bulb_off.png");
            this.imageList1.Images.SetKeyName(26, "lightning.png");
            this.imageList1.Images.SetKeyName(27, "lock_open.png");
            this.imageList1.Images.SetKeyName(28, "magnifier_zoom.png");
            this.imageList1.Images.SetKeyName(29, "magnifier_zoom_actual_equal.png");
            this.imageList1.Images.SetKeyName(30, "magnifier_zoom_fit.png");
            this.imageList1.Images.SetKeyName(31, "magnifier_zoom_in.png");
            this.imageList1.Images.SetKeyName(32, "magnifier_zoom_out.png");
            this.imageList1.Images.SetKeyName(33, "memory.png");
            this.imageList1.Images.SetKeyName(34, "page_paste.png");
            this.imageList1.Images.SetKeyName(35, "picture_empty.png");
            this.imageList1.Images.SetKeyName(36, "selection_input.png");
            this.imageList1.Images.SetKeyName(37, "wrench_screwdriver.png");
            this.imageList1.Images.SetKeyName(38, "blackpower_creature.png");
            this.imageList1.Images.SetKeyName(39, "folder_open_film.png");
            this.imageList1.Images.SetKeyName(40, "folder_open_image.png");
            this.imageList1.Images.SetKeyName(41, "film.png");
            this.imageList1.Images.SetKeyName(42, "bone");
            this.imageList1.Images.SetKeyName(43, "weather_cloudy.png");
            this.imageList1.Images.SetKeyName(44, "gear.png");
            this.imageList1.Images.SetKeyName(45, "projects_folder_badged.png");
            this.imageList1.Images.SetKeyName(46, "blueprint.png");
            this.imageList1.Images.SetKeyName(47, "graphics");
            this.imageList1.Images.SetKeyName(48, "image");
            // 
            // propertyGrid2
            // 
            this.propertyGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid2.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid2.Name = "propertyGrid2";
            this.propertyGrid2.Size = new System.Drawing.Size(203, 196);
            this.propertyGrid2.TabIndex = 0;
            this.propertyGrid2.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid2_PropertyValueChanged);
            this.propertyGrid2.Click += new System.EventHandler(this.propertyGrid2_Click);
            // 
            // ctxBoneMenu
            // 
            this.ctxBoneMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAddBone,
            this.tsmRemoveBone,
            this.tsmExtractBone,
            this.tsmCreateBoneGraphics});
            this.ctxBoneMenu.Name = "ctxBoneMenu";
            this.ctxBoneMenu.Size = new System.Drawing.Size(167, 92);
            // 
            // tsmAddBone
            // 
            this.tsmAddBone.Image = global::BAnimator_WinForms.Properties.Resources.add;
            this.tsmAddBone.Name = "tsmAddBone";
            this.tsmAddBone.Size = new System.Drawing.Size(166, 22);
            this.tsmAddBone.Text = "Добавить кость";
            this.tsmAddBone.Click += new System.EventHandler(this.tsmAddBone_Click);
            // 
            // tsmRemoveBone
            // 
            this.tsmRemoveBone.Image = global::BAnimator_WinForms.Properties.Resources.cross;
            this.tsmRemoveBone.Name = "tsmRemoveBone";
            this.tsmRemoveBone.Size = new System.Drawing.Size(166, 22);
            this.tsmRemoveBone.Text = "Удалить кость";
            this.tsmRemoveBone.Click += new System.EventHandler(this.tsmRemoveBone_Click);
            // 
            // tsmExtractBone
            // 
            this.tsmExtractBone.Name = "tsmExtractBone";
            this.tsmExtractBone.Size = new System.Drawing.Size(166, 22);
            this.tsmExtractBone.Text = "Извлечь кость";
            // 
            // tsmCreateBoneGraphics
            // 
            this.tsmCreateBoneGraphics.Name = "tsmCreateBoneGraphics";
            this.tsmCreateBoneGraphics.Size = new System.Drawing.Size(166, 22);
            this.tsmCreateBoneGraphics.Text = "Создать графику";
            this.tsmCreateBoneGraphics.Click += new System.EventHandler(this.tsmCreateBoneGraphics_Click);
            // 
            // ctxImageMenu
            // 
            this.ctxImageMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmDownloadImage});
            this.ctxImageMenu.Name = "ctxImageMenu";
            this.ctxImageMenu.Size = new System.Drawing.Size(206, 48);
            // 
            // tsmDownloadImage
            // 
            this.tsmDownloadImage.Image = global::BAnimator_WinForms.Properties.Resources.folder_open_image;
            this.tsmDownloadImage.Name = "tsmDownloadImage";
            this.tsmDownloadImage.Size = new System.Drawing.Size(205, 22);
            this.tsmDownloadImage.Text = "Загрузить изображение";
            this.tsmDownloadImage.Click += new System.EventHandler(this.tsmDownloadImage_Click);
            // 
            // picMain
            // 
            this.picMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picMain.Location = new System.Drawing.Point(0, 0);
            this.picMain.Name = "picMain";
            this.picMain.Size = new System.Drawing.Size(581, 404);
            this.picMain.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 429);
            this.Controls.Add(this.splitContainer1);
            this.KeyPreview = true;
            this.Name = "frmMain";
            this.Text = "BAnimator";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.tsFile.ResumeLayout(false);
            this.tsFile.PerformLayout();
            this.tsSelectMode.ResumeLayout(false);
            this.tsSelectMode.PerformLayout();
            this.tsAnimation.ResumeLayout(false);
            this.tsAnimation.PerformLayout();
            this.tsBoneEditor.ResumeLayout(false);
            this.tsBoneEditor.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ctxBoneMenu.ResumeLayout(false);
            this.ctxImageMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TreeView tvwProject;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStrip tsBoneEditor;
        private System.Windows.Forms.ToolStripButton chBEM_Rotate;
        private System.Windows.Forms.ToolStripButton btnBEM_Shift;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnBEM_Grid;
        private System.Windows.Forms.ToolStripButton btnBEM_GridSnap;
        private System.Windows.Forms.ToolStripButton btnBEM_FreeEdit;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip tsAnimation;
        private System.Windows.Forms.ToolStripButton btnSkipToStart;
        private System.Windows.Forms.ToolStripButton btnPlayPause;
        private System.Windows.Forms.ToolStripButton btnSkipToEnd;
        private System.Windows.Forms.ToolStripButton btnRepeat;
        private System.Windows.Forms.ToolStrip tsSelectMode;
        private System.Windows.Forms.ToolStripButton chSelectBones;
        private System.Windows.Forms.ContextMenuStrip ctxBoneMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmAddBone;
        private System.Windows.Forms.ToolStripMenuItem tsmRemoveBone;
        private System.Windows.Forms.ToolStripMenuItem tsmExtractBone;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.PropertyGrid propertyGrid2;
        private System.Windows.Forms.ToolStripButton btnBEM_STRETCH;
        private SelectablePictureBox picMain;
        private System.Windows.Forms.ContextMenuStrip ctxImageMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmDownloadImage;
        private System.Windows.Forms.ToolStrip tsFile;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnOpen;
        private System.Windows.Forms.ToolStripButton btnNew;
        private System.Windows.Forms.ToolStripMenuItem tsmCreateBoneGraphics;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

