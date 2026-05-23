namespace project_1
{
    partial class Form1
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
            pictureBox1 = new PictureBox();
            openFileDialog1 = new OpenFileDialog();
            menuStrip1 = new MenuStrip();
            convertToToolStripMenuItem = new ToolStripMenuItem();
            rGBToolStripMenuItem = new ToolStripMenuItem();
            cMYToolStripMenuItem = new ToolStripMenuItem();
            hSVToolStripMenuItem = new ToolStripMenuItem();
            yUVToolStripMenuItem = new ToolStripMenuItem();
            lABToolStripMenuItem = new ToolStripMenuItem();
            yCBCRToolStripMenuItem = new ToolStripMenuItem();
            Editpicture = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            viewSystemColorToolStripMenuItem = new ToolStripMenuItem();
            dViewToolStripMenuItem = new ToolStripMenuItem();
            dViewToolStripMenuItem1 = new ToolStripMenuItem();
            viewPixelColorToolStripMenuItem = new ToolStripMenuItem();
            resetColorToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            trackBar1 = new TrackBar();
            comboChannels = new ComboBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Cursor = Cursors.Hand;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(0, 24);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(407, 229);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { convertToToolStripMenuItem, Editpicture, resetColorToolStripMenuItem, aboutToolStripMenuItem, saveToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(407, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // convertToToolStripMenuItem
            // 
            convertToToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { rGBToolStripMenuItem, cMYToolStripMenuItem, hSVToolStripMenuItem, yUVToolStripMenuItem, lABToolStripMenuItem, yCBCRToolStripMenuItem });
            convertToToolStripMenuItem.Name = "convertToToolStripMenuItem";
            convertToToolStripMenuItem.Size = new Size(73, 20);
            convertToToolStripMenuItem.Text = "convert to";
            convertToToolStripMenuItem.Click += convertToToolStripMenuItem_Click;
            // 
            // rGBToolStripMenuItem
            // 
            rGBToolStripMenuItem.Name = "rGBToolStripMenuItem";
            rGBToolStripMenuItem.Size = new Size(180, 22);
            rGBToolStripMenuItem.Text = "RGB";
            rGBToolStripMenuItem.Click += rGBToolStripMenuItem_Click;
            // 
            // cMYToolStripMenuItem
            // 
            cMYToolStripMenuItem.Name = "cMYToolStripMenuItem";
            cMYToolStripMenuItem.Size = new Size(180, 22);
            cMYToolStripMenuItem.Text = "CMYk";
            cMYToolStripMenuItem.Click += cMYToolStripMenuItem_Click;
            // 
            // hSVToolStripMenuItem
            // 
            hSVToolStripMenuItem.Name = "hSVToolStripMenuItem";
            hSVToolStripMenuItem.Size = new Size(180, 22);
            hSVToolStripMenuItem.Text = "HSV";
            hSVToolStripMenuItem.Click += hSVToolStripMenuItem_Click;
            // 
            // yUVToolStripMenuItem
            // 
            yUVToolStripMenuItem.Name = "yUVToolStripMenuItem";
            yUVToolStripMenuItem.Size = new Size(180, 22);
            yUVToolStripMenuItem.Text = "YUV";
            yUVToolStripMenuItem.Click += yUVToolStripMenuItem_Click;
            // 
            // lABToolStripMenuItem
            // 
            lABToolStripMenuItem.Name = "lABToolStripMenuItem";
            lABToolStripMenuItem.Size = new Size(180, 22);
            lABToolStripMenuItem.Text = "LAB";
            lABToolStripMenuItem.Click += lABToolStripMenuItem_Click;
            // 
            // yCBCRToolStripMenuItem
            // 
            yCBCRToolStripMenuItem.Name = "yCBCRToolStripMenuItem";
            yCBCRToolStripMenuItem.Size = new Size(180, 22);
            yCBCRToolStripMenuItem.Text = "YCBCR";
            yCBCRToolStripMenuItem.Click += yCBCRToolStripMenuItem_Click;
            // 
            // Editpicture
            // 
            Editpicture.DropDownItems.AddRange(new ToolStripItem[] { editToolStripMenuItem, viewSystemColorToolStripMenuItem, viewPixelColorToolStripMenuItem });
            Editpicture.Name = "Editpicture";
            Editpicture.Size = new Size(79, 20);
            Editpicture.Text = "Edit picture";
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(180, 22);
            editToolStripMenuItem.Text = "Edit";
            editToolStripMenuItem.Click += editToolStripMenuItem_Click;
            // 
            // viewSystemColorToolStripMenuItem
            // 
            viewSystemColorToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { dViewToolStripMenuItem, dViewToolStripMenuItem1 });
            viewSystemColorToolStripMenuItem.Name = "viewSystemColorToolStripMenuItem";
            viewSystemColorToolStripMenuItem.Size = new Size(180, 22);
            viewSystemColorToolStripMenuItem.Text = "View System Color";
            viewSystemColorToolStripMenuItem.Click += viewSystemColorToolStripMenuItem_Click;
            // 
            // dViewToolStripMenuItem
            // 
            dViewToolStripMenuItem.Name = "dViewToolStripMenuItem";
            dViewToolStripMenuItem.Size = new Size(180, 22);
            dViewToolStripMenuItem.Text = "2D View";
            dViewToolStripMenuItem.Click += twodViewToolStripMenuItem_Click;
            // 
            // dViewToolStripMenuItem1
            // 
            dViewToolStripMenuItem1.Name = "dViewToolStripMenuItem1";
            dViewToolStripMenuItem1.Size = new Size(180, 22);
            dViewToolStripMenuItem1.Text = "3D View";
            dViewToolStripMenuItem1.Click += threedViewToolStripMenuItem1_Click;
            // 
            // viewPixelColorToolStripMenuItem
            // 
            viewPixelColorToolStripMenuItem.Name = "viewPixelColorToolStripMenuItem";
            viewPixelColorToolStripMenuItem.Size = new Size(180, 22);
            viewPixelColorToolStripMenuItem.Text = "view pixel color";
            viewPixelColorToolStripMenuItem.Click += viewPixelColorToolStripMenuItem_Click;
            // 
            // resetColorToolStripMenuItem
            // 
            resetColorToolStripMenuItem.Name = "resetColorToolStripMenuItem";
            resetColorToolStripMenuItem.Size = new Size(74, 20);
            resetColorToolStripMenuItem.Text = "reset color";
            resetColorToolStripMenuItem.Click += resetColorToolStripMenuItem_Click;
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(50, 20);
            aboutToolStripMenuItem.Text = "about";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(42, 20);
            saveToolStripMenuItem.Text = "save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // trackBar1
            // 
            trackBar1.LargeChange = 10;
            trackBar1.Location = new Point(12, 196);
            trackBar1.Maximum = 255;
            trackBar1.Minimum = -255;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(383, 45);
            trackBar1.TabIndex = 2;
            trackBar1.Scroll += trackBar1_Scroll;
            // 
            // comboChannels
            // 
            comboChannels.FormattingEnabled = true;
            comboChannels.Location = new Point(274, 24);
            comboChannels.Name = "comboChannels";
            comboChannels.Size = new Size(121, 23);
            comboChannels.TabIndex = 3;
            comboChannels.SelectedIndexChanged += comboChannels_SelectedIndexChanged;
            // 
            // pictureBox2
            // 
            pictureBox2.Dock = DockStyle.Fill;
            pictureBox2.Location = new Point(0, 24);
            pictureBox2.Margin = new Padding(0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(407, 229);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            pictureBox2.MouseClick += pictureBox2_MouseClick;
            // 
            // pictureBox3
            // 
            pictureBox3.Location = new Point(0, 24);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(407, 229);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 5;
            pictureBox3.TabStop = false;
            pictureBox3.Click += pictureBoxSystem;
            pictureBox3.MouseDown += pictureBox3_MouseDown;
            pictureBox3.MouseMove += pictureBox3_MouseMove;
            pictureBox3.MouseUp += pictureBox3_MouseUp;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(407, 253);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(comboChannels);
            Controls.Add(trackBar1);
            Controls.Add(pictureBox1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Show Image";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private OpenFileDialog openFileDialog1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem convertToToolStripMenuItem;
        private ToolStripMenuItem rGBToolStripMenuItem;
        private ToolStripMenuItem cMYToolStripMenuItem;
        private ToolStripMenuItem hSVToolStripMenuItem;
        private ToolStripMenuItem yUVToolStripMenuItem;
        private ToolStripMenuItem lABToolStripMenuItem;
        private ToolStripMenuItem yCBCRToolStripMenuItem;
        private TrackBar trackBar1;
        private ComboBox comboChannels;
        private ToolStripMenuItem Editpicture;
        private ToolStripMenuItem resetColorToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem viewSystemColorToolStripMenuItem;
        private PictureBox pictureBox2;
        private ToolStripMenuItem viewPixelColorToolStripMenuItem;
        private ToolStripMenuItem dViewToolStripMenuItem;
        private ToolStripMenuItem dViewToolStripMenuItem1;
        private PictureBox pictureBox3;
    }
}
