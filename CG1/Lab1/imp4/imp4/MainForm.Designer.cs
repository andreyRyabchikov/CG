namespace CGLab1
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose ();
            }
            base.Dispose (disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ( )
        {
            this.pbMain = new System.Windows.Forms.PictureBox();
            this.pbRes = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btPerform = new System.Windows.Forms.Button();
            this.dOpen = new System.Windows.Forms.OpenFileDialog();
            this.prBTask = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRes)).BeginInit();
            this.SuspendLayout();
            // 
            // pbMain
            // 
            this.pbMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbMain.Location = new System.Drawing.Point(12, 49);
            this.pbMain.Name = "pbMain";
            this.pbMain.Size = new System.Drawing.Size(330, 300);
            this.pbMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbMain.TabIndex = 0;
            this.pbMain.TabStop = false;
            // 
            // pbRes
            // 
            this.pbRes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbRes.Location = new System.Drawing.Point(542, 49);
            this.pbRes.Name = "pbRes";
            this.pbRes.Size = new System.Drawing.Size(330, 300);
            this.pbRes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbRes.TabIndex = 1;
            this.pbRes.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Open";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btOpen_Click);
            // 
            // btPerform
            // 
            this.btPerform.Location = new System.Drawing.Point(406, 110);
            this.btPerform.Name = "btPerform";
            this.btPerform.Size = new System.Drawing.Size(75, 23);
            this.btPerform.TabIndex = 3;
            this.btPerform.Text = "Perform";
            this.btPerform.UseVisualStyleBackColor = true;
            this.btPerform.Click += new System.EventHandler(this.btPerform_Click);
            // 
            // dOpen
            // 
            this.dOpen.FileName = "openFileDialog1";
            // 
            // prBTask
            // 
            this.prBTask.Location = new System.Drawing.Point(348, 140);
            this.prBTask.Name = "prBTask";
            this.prBTask.Size = new System.Drawing.Size(188, 23);
            this.prBTask.TabIndex = 4;
            this.prBTask.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 362);
            this.Controls.Add(this.prBTask);
            this.Controls.Add(this.btPerform);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pbRes);
            this.Controls.Add(this.pbMain);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sobel";
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbMain;
        private System.Windows.Forms.PictureBox pbRes;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btPerform;
        private System.Windows.Forms.OpenFileDialog dOpen;
        private System.Windows.Forms.ProgressBar prBTask;
    }
}

