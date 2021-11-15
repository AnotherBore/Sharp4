using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace L4_L4
{
    public partial class Form : System.Windows.Forms.Form
    {
        ToolTip toolTip = new ToolTip();
        List<Weather> list = new List<Weather>();
        
        Random rndm = new Random();
        public Form()
        {
            InitializeComponent();
            if(list.Count == 0)
            {
                btnGet.Enabled = false;
                btnBuy.Enabled = false;
            }         
        }

        private void btnFill_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; ++i)
            {
                switch (rndm.Next() % 3)
                {
                    case 0:
                        list.Add(Rainy.Random());
                        break;
                    case 1:
                        list.Add(Sunny.Random());
                        break;
                    case 2:
                        list.Add(Snowy.Random());
                        break;
                }
            }
            NewQueue();
            btnBuy.Enabled = true;
        }

        private void NewQueue()
        {
            List<PictureBox> images = new List<PictureBox> {pb3, pb2, pb1};
            for (int i = 0; i < 3; ++i)
            {
                if (list.Count <=  i)
                {
                    images[i].Image = null;
                }
                else
                {
                    images[i].Image = list[i].GetImage();
                    toolTip.SetToolTip(images[i], list[i].GetInfo());
                }
            }
            lblInfo.Text = $"В списке {list.Count} значений";
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            pbFinal.Image = list[0].GetImage();
            toolTip.SetToolTip(pbFinal, list[0].GetInfo());
            list.RemoveAt(0);
            NewQueue();
            btnBuy.Enabled = false;
            btnGet.Enabled = true;
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            if (list.Count > 0) btnBuy.Enabled = true;
            btnGet.Enabled = false;
            pbFinal.Image = null;
            toolTip.SetToolTip(pbFinal, null);
        }
    }
}
