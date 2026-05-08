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
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            menuStrip1.SuspendLayout();
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
            menuStrip1.Items.AddRange(new ToolStripItem[] { convertToToolStripMenuItem });
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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(407, 253);
            Controls.Add(pictureBox1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Show Image";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
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
    }
}
