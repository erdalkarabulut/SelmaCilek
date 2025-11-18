using System;
using System.Threading;
using System.Windows.Forms;

namespace BPS.Windows.Forms
{
    public partial class FrmWait : Form
    {
        int anim = 1;
        public bool close = false;
        public object parameter;
        public Thread thread;

        public FrmWait()
        {
            InitializeComponent();
            timer1.Enabled = true;
        }

        private void FrmWait_Activated(object sender, EventArgs e)
        {
            timer1.Start();
            if (!thread.IsAlive)
                thread.Start(parameter);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (anim == 216) anim = 0;
            picWait.Image = imageCollection1.Images[anim];
            this.Refresh();
            float percent = (float)anim / 216f * 100f;
            progressBarControl1.Position = (int) percent;
            anim++;
            if (close) this.Close();
        }

        private void FrmWait_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            e.Cancel = true;
            this.Hide();
        }
    }
}
