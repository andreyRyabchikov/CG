using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CGLab1
{
    public partial class MainForm : Form
    {
        public MainForm ( )
        {
            InitializeComponent ();
        }

        private void btOpen_Click(object sender, EventArgs e)
        {
            if (dOpen.ShowDialog() == DialogResult.OK) {
                pbMain.Image = new Bitmap(dOpen.OpenFile());
            }
        }

        private delegate void PrepPrb(int i);
        private delegate void PrepImg(Image img);
        private delegate void DonePrb();

        private void SetUpPrB(int i)
        {
            prBTask.Visible = true;
            prBTask.Maximum = i;
        }

        private void ChangeValuePrB(int i)
        {
            prBTask.Value = i;
        }

        private void SetUpPb(Image img)
        {
            pbRes.Image = img;
        }

        private void SetDonePrB()
        {
            prBTask.Visible = false;
        }

        private void PreparePrBar(int i)
        {
            prBTask.Invoke(new PrepPrb(SetUpPrB), i);
        }

        private void ChangeProgressPrBar(int i)
        {
            prBTask.Invoke(new PrepPrb(ChangeValuePrB), i);
        }

        private void IfDone(Image img)
        {
            prBTask.Invoke(new DonePrb(SetDonePrB));
            pbRes.Invoke(new PrepImg(SetUpPb), img);
        }

        private void btPerform_Click(object sender, EventArgs e)
        {
            Method m = new Method();
            m.OnAmount += PreparePrBar;
            m.OnProgress += ChangeProgressPrBar;
            m.OnDone += IfDone;
            Thread th = new Thread(() => m.Sobel(pbMain.Image));
            th.Start();
        }
    }
}
