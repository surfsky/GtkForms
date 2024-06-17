﻿
using System.Runtime.InteropServices;
using System;
using System.Windows.Forms;
using System.IO;

namespace GTKWinFormsApp
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            TreeNode treeNode1 = new TreeNode("Node21");
            TreeNode treeNode2 = new TreeNode("Node22");
            TreeNode treeNode3 = new TreeNode("Node2", new TreeNode[] { treeNode1, treeNode2 });
            TreeNode treeNode4 = new TreeNode("Node3");
            TreeNode treeNode5 = new TreeNode("Node0", new TreeNode[] { treeNode3, treeNode4 });
            TreeNode treeNode6 = new TreeNode("Node1");
            button1 = new Button();
            comboBox1 = new ComboBox();
            textBox1 = new TextBox();
            dataGridView1 = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            State = new DataGridViewCheckBoxColumn();
            Title = new DataGridViewTextBoxColumn();
            CreateDate = new DataGridViewComboBoxColumn();
            Operate = new DataGridViewButtonColumn();
            PIC = new DataGridViewImageColumn();
            groupBox1 = new GroupBox();
            checkBox2 = new CheckBox();
            maskedTextBox2 = new MaskedTextBox();
            radioButton3 = new RadioButton();
            dateTimePicker1 = new DateTimePicker();
            radioButton2 = new RadioButton();
            label2 = new Label();
            numericUpDown1 = new NumericUpDown();
            radioButton1 = new RadioButton();
            linkLabel1 = new LinkLabel();
            button2 = new Button();
            label1 = new Label();
            maskedTextBox1 = new MaskedTextBox();
            button7 = new Button();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            tableLayoutPanel1 = new TableLayoutPanel();
            label6 = new Label();
            label5 = new Label();
            button6 = new Button();
            richTextBox1 = new RichTextBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            button4 = new Button();
            button5 = new Button();
            checkBox3 = new CheckBox();
            label4 = new Label();
            listBox1 = new ListBox();
            label3 = new Label();
            checkBox1 = new CheckBox();
            button3 = new Button();
            tabPage3 = new TabPage();
            treeView1 = new TreeView();
            pictureBox1 = new PictureBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            toolStripMenuItem1 = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            菜单三ToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1 = new MenuStrip();
            toolStripMenuItem3 = new ToolStripMenuItem();
            test1ToolStripMenuItem = new ToolStripMenuItem();
            三级菜单1ToolStripMenuItem = new ToolStripMenuItem();
            test2ToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem4 = new ToolStripMenuItem();
            二级菜单1ToolStripMenuItem = new ToolStripMenuItem();
            checkedListBox1 = new CheckedListBox();
            splitContainer1 = new SplitContainer();
            pictureBox2 = new PictureBox();
            button8 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            contextMenuStrip1.SuspendLayout();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = System.Drawing.Color.Gold;
            button1.BackgroundImage = Properties.Resources.timg;
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.Font = new System.Drawing.Font("Microsoft YaHei UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            button1.ForeColor = System.Drawing.Color.FromArgb(192, 255, 255);
            button1.Image = Properties.Resources.timg;
            button1.Location = new System.Drawing.Point(212, 98);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(136, 42);
            button1.TabIndex = 0;
            button1.Text = "加载数据表数据";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            button1.Paint += button1_Paint;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "test1", "test2", "test3333333333333333333", "这是下拉列表控件数据测试" });
            comboBox1.Location = new System.Drawing.Point(276, 26);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new System.Drawing.Size(121, 25);
            comboBox1.TabIndex = 1;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            comboBox1.SelectedValueChanged += comboBox1_SelectedValueChanged;
            // 
            // textBox1
            // 
            textBox1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            textBox1.Location = new System.Drawing.Point(520, 91);
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(73, 23);
            textBox1.TabIndex = 2;
            textBox1.Text = "text";
            textBox1.TextChanged += textBox1_TextChanged;
            textBox1.Enter += textBox1_Enter;
            textBox1.KeyDown += textBox1_KeyDown;
            textBox1.KeyPress += textBox1_KeyPress;
            textBox1.KeyUp += textBox1_KeyUp;
            textBox1.Validating += textBox1_Validating;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeight = 29;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ID, State, Title, CreateDate, Operate, PIC });
            dataGridView1.DataMember = "ID,State,Title";
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new System.Drawing.Point(3, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 36;
            dataGridView1.Size = new System.Drawing.Size(1027, 262);
            dataGridView1.TabIndex = 2;
            dataGridView1.MultiSelectChanged += dataGridView1_MultiSelectChanged;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.CellEnter += dataGridView1_CellEnter;
            dataGridView1.CellLeave += dataGridView1_CellLeave;
            dataGridView1.CellValidated += dataGridView1_CellValidated;
            dataGridView1.CellValidating += dataGridView1_CellValidating;
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
            dataGridView1.RowEnter += dataGridView1_RowEnter;
            dataGridView1.RowLeave += dataGridView1_RowLeave;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            // 
            // ID
            // 
            ID.HeaderText = "ID";
            ID.MinimumWidth = 6;
            ID.Name = "ID";
            ID.ReadOnly = true;
            ID.SortMode = DataGridViewColumnSortMode.NotSortable;
            ID.Width = 125;
            // 
            // State
            // 
            State.HeaderText = "State";
            State.MinimumWidth = 6;
            State.Name = "State";
            State.Resizable = DataGridViewTriState.False;
            State.Width = 125;
            // 
            // Title
            // 
            Title.HeaderText = "Title";
            Title.MinimumWidth = 6;
            Title.Name = "Title";
            Title.Resizable = DataGridViewTriState.True;
            Title.Width = 125;
            // 
            // CreateDate
            // 
            CreateDate.HeaderText = "CreateDate";
            CreateDate.Items.AddRange(new object[] { "2012-09-12 12:32:11", "2012-09-13 12:32:22", "2012-09-14 12:32:33" });
            CreateDate.MinimumWidth = 6;
            CreateDate.Name = "CreateDate";
            CreateDate.Resizable = DataGridViewTriState.True;
            CreateDate.SortMode = DataGridViewColumnSortMode.Automatic;
            CreateDate.Width = 125;
            // 
            // Operate
            // 
            Operate.HeaderText = "Operate";
            Operate.MinimumWidth = 6;
            Operate.Name = "Operate";
            Operate.ReadOnly = true;
            Operate.Width = 125;
            // 
            // PIC
            // 
            PIC.HeaderText = "PIC";
            PIC.MinimumWidth = 6;
            PIC.Name = "PIC";
            PIC.ReadOnly = true;
            PIC.Width = 125;
            // 
            // groupBox1
            // 
            groupBox1.AutoSize = true;
            groupBox1.Controls.Add(button8);
            groupBox1.Controls.Add(checkBox2);
            groupBox1.Controls.Add(maskedTextBox2);
            groupBox1.Controls.Add(radioButton3);
            groupBox1.Controls.Add(dateTimePicker1);
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(numericUpDown1);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Controls.Add(linkLabel1);
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(maskedTextBox1);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new System.Drawing.Point(0, 25);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(1041, 151);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "分组框标题";
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Checked = true;
            checkBox2.CheckState = CheckState.Indeterminate;
            checkBox2.Location = new System.Drawing.Point(471, 26);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new System.Drawing.Size(89, 21);
            checkBox2.TabIndex = 6;
            checkBox2.Text = "checkBox2";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            checkBox2.CheckStateChanged += checkBox2_CheckStateChanged;
            // 
            // maskedTextBox2
            // 
            maskedTextBox2.Location = new System.Drawing.Point(79, 64);
            maskedTextBox2.Name = "maskedTextBox2";
            maskedTextBox2.PasswordChar = '*';
            maskedTextBox2.Size = new System.Drawing.Size(174, 23);
            maskedTextBox2.TabIndex = 5;
            maskedTextBox2.Text = "sdfdf43";
            maskedTextBox2.Validated += maskedTextBox2_Validated;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new System.Drawing.Point(800, 75);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new System.Drawing.Size(102, 21);
            radioButton3.TabIndex = 12;
            radioButton3.Text = "radioButton3";
            radioButton3.UseVisualStyleBackColor = true;
            radioButton3.CheckedChanged += radioButton3_CheckedChanged;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "yyyy年MM年dd HH时mm分ss秒";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new System.Drawing.Point(53, 104);
            dateTimePicker1.MaxDate = new DateTime(2029, 5, 17, 15, 58, 47, 534);
            dateTimePicker1.MinDate = new DateTime(2024, 3, 17, 15, 58, 47, 535);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new System.Drawing.Size(200, 23);
            dateTimePicker1.TabIndex = 8;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Checked = true;
            radioButton2.Location = new System.Drawing.Point(800, 48);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new System.Drawing.Size(102, 21);
            radioButton2.TabIndex = 11;
            radioButton2.TabStop = true;
            radioButton2.Text = "radioButton2";
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(27, 29);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(48, 17);
            label2.TabIndex = 3;
            label2.Text = "掩 码：";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new System.Drawing.Point(276, 65);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new System.Drawing.Size(120, 23);
            numericUpDown1.TabIndex = 9;
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new System.Drawing.Point(800, 19);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new System.Drawing.Size(102, 21);
            radioButton1.TabIndex = 10;
            radioButton1.Text = "radioButton1";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // linkLabel1
            // 
            linkLabel1.ActiveLinkColor = System.Drawing.Color.Blue;
            linkLabel1.AutoSize = true;
            linkLabel1.LinkColor = System.Drawing.Color.Red;
            linkLabel1.Location = new System.Drawing.Point(625, 25);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new System.Drawing.Size(66, 17);
            linkLabel1.TabIndex = 6;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "linkLabel1";
            // 
            // button2
            // 
            button2.BackColor = System.Drawing.Color.FromArgb(255, 128, 255);
            button2.BackgroundImage = (System.Drawing.Image)resources.GetObject("button2.BackgroundImage");
            button2.BackgroundImageLayout = ImageLayout.Center;
            button2.Font = new System.Drawing.Font("Microsoft YaHei UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            button2.ForeColor = System.Drawing.Color.Blue;
            button2.Location = new System.Drawing.Point(619, 75);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(144, 48);
            button2.TabIndex = 0;
            button2.Text = "选择颜色按钮";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(449, 94);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(68, 17);
            label1.TabIndex = 1;
            label1.Text = "选择颜色：";
            // 
            // maskedTextBox1
            // 
            maskedTextBox1.Location = new System.Drawing.Point(79, 26);
            maskedTextBox1.Mask = "0000年90月90日 90时00分";
            maskedTextBox1.Name = "maskedTextBox1";
            maskedTextBox1.Size = new System.Drawing.Size(174, 23);
            maskedTextBox1.TabIndex = 4;
            maskedTextBox1.ValidatingType = typeof(DateTime);
            // 
            // button7
            // 
            button7.BackColor = System.Drawing.Color.LightCoral;
            button7.Location = new System.Drawing.Point(212, 18);
            button7.Margin = new Padding(2, 3, 2, 3);
            button7.Name = "button7";
            button7.Size = new System.Drawing.Size(120, 43);
            button7.TabIndex = 14;
            button7.Text = "listview演示";
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.ItemSize = new System.Drawing.Size(181, 25);
            tabControl1.Location = new System.Drawing.Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(1041, 301);
            tabControl1.TabIndex = 4;
            tabControl1.DrawItem += tabControl1_DrawItem;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dataGridView1);
            tabPage1.Location = new System.Drawing.Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3, 3, 3, 3);
            tabPage1.Size = new System.Drawing.Size(1033, 268);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "数据表格";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(tableLayoutPanel1);
            tabPage2.Controls.Add(richTextBox1);
            tabPage2.Controls.Add(flowLayoutPanel1);
            tabPage2.Controls.Add(listBox1);
            tabPage2.Controls.Add(label3);
            tabPage2.Controls.Add(checkBox1);
            tabPage2.Controls.Add(button3);
            tabPage2.Location = new System.Drawing.Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3, 3, 3, 3);
            tabPage2.Size = new System.Drawing.Size(1033, 268);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "容器类表格";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(label6, 0, 1);
            tableLayoutPanel1.Controls.Add(label5, 0, 0);
            tableLayoutPanel1.Controls.Add(button6, 1, 1);
            tableLayoutPanel1.Location = new System.Drawing.Point(640, 22);
            tableLayoutPanel1.Margin = new Padding(2, 3, 2, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 66.29214F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.7078667F));
            tableLayoutPanel1.Size = new System.Drawing.Size(226, 154);
            tableLayoutPanel1.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(3, 102);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(104, 51);
            label6.TabIndex = 0;
            label6.Text = "\r\nddddddddddddddddddddddddddddddddddddd";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(3, 1);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(104, 17);
            label5.TabIndex = 0;
            label5.Text = "tablelayoutpanel";
            // 
            // button6
            // 
            button6.Location = new System.Drawing.Point(115, 105);
            button6.Margin = new Padding(2, 3, 2, 3);
            button6.Name = "button6";
            button6.Size = new System.Drawing.Size(73, 25);
            button6.TabIndex = 1;
            button6.Text = "button6";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new System.Drawing.Point(495, 131);
            richTextBox1.Margin = new Padding(2, 3, 2, 3);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new System.Drawing.Size(98, 103);
            richTextBox1.TabIndex = 6;
            richTextBox1.Text = "";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(button4);
            flowLayoutPanel1.Controls.Add(button5);
            flowLayoutPanel1.Controls.Add(checkBox3);
            flowLayoutPanel1.Controls.Add(label4);
            flowLayoutPanel1.Location = new System.Drawing.Point(154, 47);
            flowLayoutPanel1.Margin = new Padding(2, 3, 2, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(305, 156);
            flowLayoutPanel1.TabIndex = 5;
            // 
            // button4
            // 
            button4.Location = new System.Drawing.Point(2, 3);
            button4.Margin = new Padding(2, 3, 2, 3);
            button4.Name = "button4";
            button4.Size = new System.Drawing.Size(73, 25);
            button4.TabIndex = 0;
            button4.Text = "button4";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new System.Drawing.Point(79, 3);
            button5.Margin = new Padding(2, 3, 2, 3);
            button5.Name = "button5";
            button5.Size = new System.Drawing.Size(194, 25);
            button5.TabIndex = 1;
            button5.Text = "button5";
            button5.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new System.Drawing.Point(2, 34);
            checkBox3.Margin = new Padding(2, 3, 2, 3);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new System.Drawing.Size(89, 21);
            checkBox3.TabIndex = 2;
            checkBox3.Text = "checkBox3";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(95, 31);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(99, 17);
            label4.TabIndex = 3;
            label4.Text = "flowlayoutpanel";
            // 
            // listBox1
            // 
            listBox1.ColumnWidth = 100;
            listBox1.DisplayMember = "Title";
            listBox1.FormattingEnabled = true;
            listBox1.HorizontalScrollbar = true;
            listBox1.ItemHeight = 17;
            listBox1.Items.AddRange(new object[] { "test1 ddd", "test2 sssss" });
            listBox1.Location = new System.Drawing.Point(495, 22);
            listBox1.Margin = new Padding(2, 3, 2, 3);
            listBox1.MultiColumn = true;
            listBox1.Name = "listBox1";
            listBox1.ScrollAlwaysVisible = true;
            listBox1.SelectionMode = SelectionMode.MultiSimple;
            listBox1.Size = new System.Drawing.Size(118, 89);
            listBox1.Sorted = true;
            listBox1.TabIndex = 4;
            listBox1.ValueMember = "Title";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(24, 76);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(43, 17);
            label3.TabIndex = 2;
            label3.Text = "label3";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new System.Drawing.Point(1006, 270);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new System.Drawing.Size(89, 21);
            checkBox1.TabIndex = 1;
            checkBox1.Text = "checkBox1";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new System.Drawing.Point(24, 32);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(75, 23);
            button3.TabIndex = 0;
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Location = new System.Drawing.Point(4, 29);
            tabPage3.Margin = new Padding(2, 3, 2, 3);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(2, 3, 2, 3);
            tabPage3.Size = new System.Drawing.Size(1033, 268);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "tabPage3";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // treeView1
            // 
            treeView1.Location = new System.Drawing.Point(27, 18);
            treeView1.Name = "treeView1";
            treeNode1.Name = "";
            treeNode1.Text = "Node21";
            treeNode2.Name = "";
            treeNode2.Text = "Node22";
            treeNode3.Name = "Node2";
            treeNode3.Text = "Node2";
            treeNode4.Name = "Node3";
            treeNode4.Text = "Node3";
            treeNode5.Name = "Node0";
            treeNode5.Text = "Node0";
            treeNode6.Name = "Node1";
            treeNode6.Text = "Node1";
            treeView1.Nodes.AddRange(new TreeNode[] { treeNode5, treeNode6 });
            treeView1.Size = new System.Drawing.Size(121, 113);
            treeView1.TabIndex = 4;
            treeView1.AfterCollapse += treeView1_AfterCollapse;
            treeView1.AfterExpand += treeView1_AfterExpand;
            treeView1.BeforeSelect += treeView1_BeforeSelect;
            treeView1.AfterSelect += treeView1_AfterSelect;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.timg;
            pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new System.Drawing.Point(790, 30);
            pictureBox1.MaximumSize = new System.Drawing.Size(156, 110);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(156, 110);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, toolStripMenuItem2 });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new System.Drawing.Size(113, 48);
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new System.Drawing.Size(112, 22);
            toolStripMenuItem1.Text = "菜单一";
            toolStripMenuItem1.Click += toolStripMenuItem1_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.DropDownItems.AddRange(new ToolStripItem[] { 菜单三ToolStripMenuItem });
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new System.Drawing.Size(112, 22);
            toolStripMenuItem2.Text = "菜单二";
            // 
            // 菜单三ToolStripMenuItem
            // 
            菜单三ToolStripMenuItem.Name = "菜单三ToolStripMenuItem";
            菜单三ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            菜单三ToolStripMenuItem.Text = "菜单三";
            // 
            // menuStrip1
            // 
            menuStrip1.AutoSize = false;
            menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem3, toolStripMenuItem4 });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new System.Drawing.Size(1041, 25);
            menuStrip1.TabIndex = 7;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.DropDownItems.AddRange(new ToolStripItem[] { test1ToolStripMenuItem, test2ToolStripMenuItem });
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new System.Drawing.Size(75, 21);
            toolStripMenuItem3.Text = "一级菜单1";
            toolStripMenuItem3.DropDownItemClicked += toolStripMenuItem3_DropDownItemClicked;
            toolStripMenuItem3.Click += toolStripMenuItem3_Click;
            // 
            // test1ToolStripMenuItem
            // 
            test1ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 三级菜单1ToolStripMenuItem });
            test1ToolStripMenuItem.Name = "test1ToolStripMenuItem";
            test1ToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            test1ToolStripMenuItem.Text = "二级菜单1";
            // 
            // 三级菜单1ToolStripMenuItem
            // 
            三级菜单1ToolStripMenuItem.Name = "三级菜单1ToolStripMenuItem";
            三级菜单1ToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            三级菜单1ToolStripMenuItem.Text = "三级菜单1";
            // 
            // test2ToolStripMenuItem
            // 
            test2ToolStripMenuItem.Checked = true;
            test2ToolStripMenuItem.CheckState = CheckState.Checked;
            test2ToolStripMenuItem.Name = "test2ToolStripMenuItem";
            test2ToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            test2ToolStripMenuItem.Text = "二级菜单2";
            test2ToolStripMenuItem.CheckedChanged += test2ToolStripMenuItem_CheckedChanged;
            test2ToolStripMenuItem.CheckStateChanged += test2ToolStripMenuItem_CheckStateChanged;
            test2ToolStripMenuItem.DropDownItemClicked += test2ToolStripMenuItem_DropDownItemClicked;
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.DropDownItems.AddRange(new ToolStripItem[] { 二级菜单1ToolStripMenuItem });
            toolStripMenuItem4.Image = Properties.Resources.timg;
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new System.Drawing.Size(95, 21);
            toolStripMenuItem4.Text = "一级菜单2";
            // 
            // 二级菜单1ToolStripMenuItem
            // 
            二级菜单1ToolStripMenuItem.Name = "二级菜单1ToolStripMenuItem";
            二级菜单1ToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            二级菜单1ToolStripMenuItem.Text = "二级菜单1";
            // 
            // checkedListBox1
            // 
            checkedListBox1.CheckOnClick = true;
            checkedListBox1.ColumnWidth = 100;
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Items.AddRange(new object[] { "3232", "dfdf", "ssss", "ssssssdddddddddddddd", "ffffff", "gggggggg", "gf333", "sssddd" });
            checkedListBox1.Location = new System.Drawing.Point(383, 25);
            checkedListBox1.MultiColumn = true;
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new System.Drawing.Size(188, 112);
            checkedListBox1.TabIndex = 13;
            checkedListBox1.ItemCheck += checkedListBox1_ItemCheck;
            checkedListBox1.SelectedValueChanged += checkedListBox1_SelectedValueChanged;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Bottom;
            splitContainer1.Location = new System.Drawing.Point(0, 176);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.AutoScroll = true;
            splitContainer1.Panel1.Controls.Add(button7);
            splitContainer1.Panel1.Controls.Add(pictureBox2);
            splitContainer1.Panel1.Controls.Add(treeView1);
            splitContainer1.Panel1.Controls.Add(checkedListBox1);
            splitContainer1.Panel1.Controls.Add(pictureBox1);
            splitContainer1.Panel1.Controls.Add(button1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.AutoScroll = true;
            splitContainer1.Panel2.Controls.Add(tabControl1);
            splitContainer1.Size = new System.Drawing.Size(1041, 480);
            splitContainer1.SplitterDistance = 175;
            splitContainer1.TabIndex = 14;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new System.Drawing.Point(586, 25);
            pictureBox2.Margin = new Padding(2, 3, 2, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new System.Drawing.Size(177, 119);
            pictureBox2.TabIndex = 14;
            pictureBox2.TabStop = false;
            pictureBox2.Paint += pictureBox2_Paint;
            // 
            // button8
            // 
            button8.Location = new System.Drawing.Point(801, 106);
            button8.Name = "button8";
            button8.Size = new System.Drawing.Size(75, 23);
            button8.TabIndex = 13;
            button8.Text = "button8";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new System.Drawing.Size(1058, 632);
            ContextMenuStrip = contextMenuStrip1;
            Controls.Add(groupBox1);
            Controls.Add(splitContainer1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MinimizeBox = false;
            Name = "FormMain";
            Text = "默认风格界面";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;

        private System.Windows.Forms.DataGridView dataGridView1;

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private CheckBox checkBox1;
        private MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MaskedTextBox maskedTextBox2;
        private LinkLabel linkLabel1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem2;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem test1ToolStripMenuItem;
        private ToolStripMenuItem test2ToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripMenuItem 菜单三ToolStripMenuItem;
        private CheckBox checkBox2;
        private DateTimePicker dateTimePicker1;
        private NumericUpDown numericUpDown1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private CheckedListBox checkedListBox1;
        private System.Windows.Forms.TreeView treeView1;
        private ToolStripMenuItem 三级菜单1ToolStripMenuItem;
        private ToolStripMenuItem 二级菜单1ToolStripMenuItem;
        private SplitContainer splitContainer1;
        private PictureBox pictureBox2;
        private ListBox listBox1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button button4;
        private Button button5;
        private CheckBox checkBox3;
        private Label label4;
        private RichTextBox richTextBox1;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label5;
        private Button button6;
        private Label label6;
        private Button button7;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewCheckBoxColumn State;
        private DataGridViewTextBoxColumn Title;
        private DataGridViewComboBoxColumn CreateDate;
        private DataGridViewButtonColumn Operate;
        private DataGridViewImageColumn PIC;
        private TabPage tabPage3;
        private Button button8;
    }
}

