using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Rejestrator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public List<Zlecenie> zlecenia = new List<Zlecenie>();

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(this);
            f2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var r = MessageBox.Show("Czy usunąć projekt - " + listView1.SelectedItems[0].Text + "?", "Usuń projekt", MessageBoxButtons.OKCancel);
            if ( r == DialogResult.OK)
            {
                int i = listView1.FocusedItem.Index;
                listView1.Items.RemoveAt(i);
                zlecenia.RemoveAt(i);
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            if (listView1.SelectedItems.Count > 0)
            {
                Zlecenie tmp = null;
                foreach (Zlecenie item in zlecenia)
                {
                    if (item.Nazwa == listView1.SelectedItems[0].Text)
                    {
                        tmp = item;
                    }
                }
                Form3 f3 = new Form3(this, tmp);
                f3.Text += tmp.Nazwa;
                f3.Show();
            }                
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("lista.dat"))
            {
                FileStream fs = new FileStream("lista.dat", FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                zlecenia = (List<Zlecenie>)bf.Deserialize(fs);
                fs.Close();
                listView1.BeginUpdate();
                foreach (Zlecenie item in zlecenia)
                {
                    ListViewItem li = new ListViewItem();
                    li.Text = item.Nazwa;
                    li.SubItems.Add(item.Data.ToShortDateString());
                    li.SubItems.Add(item.Czas.ToString());
                    listView1.Items.Add(li);
                }
                listView1.EndUpdate();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            FileStream fs = new FileStream("lista.dat", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, zlecenia);
            fs.Close();
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems[0].Text != string.Empty)
            {
                button2.Enabled = true;
            }
        }
    }
}