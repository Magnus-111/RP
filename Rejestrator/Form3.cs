using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rejestrator
{
    public partial class Form3 : Form
    {
        Form1 f1;
        public Zlecenie oz;
        TimeSpan t;
        public List<Zlecenie> ztmp = new List<Zlecenie>();

        public Form3(Form1 F1, Zlecenie z)
        {
            InitializeComponent();
            f1 = F1;
            ztmp = F1.zlecenia;
            oz = z;
        }
                
        private void Form3_Load(object sender, EventArgs e)
        {
            label1.Text = oz.Nazwa;
            label2.Text = oz.Czas.ToString();
            label3.Text = t.ToString();
            label1.Location = new Point((Width - label1.Size.Width) / 2, label1.Location.Y);
            label2.Location = new Point((Width - label2.Size.Width - 12) / 2, label2.Location.Y);
            label3.Location = new Point((Width - label3.Size.Width - 12) / 2, label3.Location.Y);
            t.Add(oz.Czas);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Start")
            {
                timer1.Enabled = true;
                timer1.Start();
                button1.Text = "Stop";
            }
            else if(button1.Text == "Stop")
            {
                button1.Text = "Start";
                timer1.Enabled = false;
                timer1.Stop();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            t += TimeSpan.FromSeconds(1);
            label3.Text = t.ToString();
            oz.Czas += TimeSpan.FromSeconds(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                button1.PerformClick();
            }
            int idx = 0;
            for (int i = 0; i < f1.zlecenia.Count; i++)
            {
                if (f1.zlecenia[i].Nazwa == oz.Nazwa)
                {
                    idx = i;
                    break;
                }
            }
            f1.zlecenia.RemoveAt(idx);
            f1.zlecenia.Add(oz);
            f1.listView1.Items.Clear();
            foreach (Zlecenie item in f1.zlecenia)
            {
                f1.listView1.BeginUpdate();
                ListViewItem li = new ListViewItem();
                li.Text = item.Nazwa;
                li.SubItems.Add(item.Data.ToString());
                li.SubItems.Add(item.Czas.ToString());
                f1.listView1.Items.Add(li);
                f1.listView1.EndUpdate();
            }
            f1.Show();
            Close();

        }

        private void label3_TextChanged(object sender, EventArgs e)
        {
            label3.Location = new Point((Size.Width - label3.Size.Width - 12) / 2, label3.Location.Y);
        }
    }
}
