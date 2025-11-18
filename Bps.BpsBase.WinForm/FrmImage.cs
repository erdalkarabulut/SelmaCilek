using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BPS.Windows.Forms
{
    public partial class FrmImage : Form
    {
        
        public FrmImage(Image image)
        {
            InitializeComponent();
            this.BackgroundImage = image;
            this.BackgroundImageLayout = ImageLayout.Zoom; // Resmi ekran boyutuna göre ölçekle

            
            this.ClientSize = image.Size;

           
            this.DoubleClick += (s, e) => this.Close();
        }
    }
}
