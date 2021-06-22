namespace QLNhanSu.Helper
{
    partial class HelpPictureBox
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelButton = new System.Windows.Forms.Panel();
            this.panelPic = new System.Windows.Forms.Panel();
            this.imageProgressBar = new System.Windows.Forms.ProgressBar();
            this.previousBTN = new System.Windows.Forms.Button();
            this.nextBTN = new System.Windows.Forms.Button();
            this.panelShadow = new System.Windows.Forms.Panel();
            this.panelHelp = new System.Windows.Forms.Panel();
            this.helpLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.helperPic = new System.Windows.Forms.PictureBox();
            this.panelButton.SuspendLayout();
            this.panelPic.SuspendLayout();
            this.panelShadow.SuspendLayout();
            this.panelHelp.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.helperPic)).BeginInit();
            this.SuspendLayout();
            // 
            // panelButton
            // 
            this.panelButton.Controls.Add(this.nextBTN);
            this.panelButton.Controls.Add(this.previousBTN);
            this.panelButton.Controls.Add(this.imageProgressBar);
            this.panelButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButton.Location = new System.Drawing.Point(0, 397);
            this.panelButton.Name = "panelButton";
            this.panelButton.Size = new System.Drawing.Size(689, 30);
            this.panelButton.TabIndex = 0;
            // 
            // panelPic
            // 
            this.panelPic.Controls.Add(this.panel1);
            this.panelPic.Controls.Add(this.panelShadow);
            this.panelPic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPic.Location = new System.Drawing.Point(0, 0);
            this.panelPic.Name = "panelPic";
            this.panelPic.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.panelPic.Size = new System.Drawing.Size(689, 397);
            this.panelPic.TabIndex = 1;
            // 
            // imageProgressBar
            // 
            this.imageProgressBar.BackColor = System.Drawing.SystemColors.Highlight;
            this.imageProgressBar.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.imageProgressBar.Location = new System.Drawing.Point(269, 3);
            this.imageProgressBar.MarqueeAnimationSpeed = 1000;
            this.imageProgressBar.Name = "imageProgressBar";
            this.imageProgressBar.Size = new System.Drawing.Size(100, 23);
            this.imageProgressBar.TabIndex = 0;
            // 
            // previousBTN
            // 
            this.previousBTN.Location = new System.Drawing.Point(240, 4);
            this.previousBTN.Name = "previousBTN";
            this.previousBTN.Size = new System.Drawing.Size(23, 23);
            this.previousBTN.TabIndex = 1;
            this.previousBTN.Text = "<";
            this.previousBTN.UseVisualStyleBackColor = true;
            this.previousBTN.Click += new System.EventHandler(this.previousBTN_Click);
            // 
            // nextBTN
            // 
            this.nextBTN.Location = new System.Drawing.Point(375, 4);
            this.nextBTN.Name = "nextBTN";
            this.nextBTN.Size = new System.Drawing.Size(23, 23);
            this.nextBTN.TabIndex = 2;
            this.nextBTN.Text = ">";
            this.nextBTN.UseVisualStyleBackColor = true;
            this.nextBTN.Click += new System.EventHandler(this.nextBTN_Click);
            // 
            // panelShadow
            // 
            this.panelShadow.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelShadow.Controls.Add(this.panelHelp);
            this.panelShadow.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelShadow.Location = new System.Drawing.Point(3, 3);
            this.panelShadow.Name = "panelShadow";
            this.panelShadow.Padding = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.panelShadow.Size = new System.Drawing.Size(683, 42);
            this.panelShadow.TabIndex = 1;
            // 
            // panelHelp
            // 
            this.panelHelp.BackColor = System.Drawing.SystemColors.Control;
            this.panelHelp.Controls.Add(this.helpLabel);
            this.panelHelp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelHelp.Location = new System.Drawing.Point(3, 3);
            this.panelHelp.Name = "panelHelp";
            this.panelHelp.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.panelHelp.Size = new System.Drawing.Size(677, 38);
            this.panelHelp.TabIndex = 0;
            // 
            // helpLabel
            // 
            this.helpLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.helpLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel.Location = new System.Drawing.Point(5, 5);
            this.helpLabel.Name = "helpLabel";
            this.helpLabel.Size = new System.Drawing.Size(647, 33);
            this.helpLabel.TabIndex = 1;
            this.helpLabel.Text = "B2: Nhấp chuột trái vào nút tìm kiếm để in ra thông tin của các nhân vi" +
    "ên tương đồng với thông tin đã nhập";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel1.Controls.Add(this.helperPic);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 45);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(2);
            this.panel1.Size = new System.Drawing.Size(683, 352);
            this.panel1.TabIndex = 2;
            // 
            // helperPic
            // 
            this.helperPic.BackColor = System.Drawing.SystemColors.Control;
            this.helperPic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.helperPic.Location = new System.Drawing.Point(2, 2);
            this.helperPic.Name = "helperPic";
            this.helperPic.Size = new System.Drawing.Size(679, 348);
            this.helperPic.TabIndex = 4;
            this.helperPic.TabStop = false;
            // 
            // HelpPictureBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelPic);
            this.Controls.Add(this.panelButton);
            this.Name = "HelpPictureBox";
            this.Size = new System.Drawing.Size(689, 427);
            this.panelButton.ResumeLayout(false);
            this.panelPic.ResumeLayout(false);
            this.panelShadow.ResumeLayout(false);
            this.panelHelp.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.helperPic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelButton;
        private System.Windows.Forms.Panel panelPic;
        private System.Windows.Forms.Button nextBTN;
        private System.Windows.Forms.Button previousBTN;
        private System.Windows.Forms.ProgressBar imageProgressBar;
        private System.Windows.Forms.Panel panelShadow;
        private System.Windows.Forms.Panel panelHelp;
        private System.Windows.Forms.Label helpLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox helperPic;
    }
}
