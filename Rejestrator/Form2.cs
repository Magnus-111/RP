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
    public partial class Form2 : Form
    {
        Form1 f1; 

        public Form2(Form1 F1)
        {
            InitializeComponent();
            f1 = F1;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty && dateTimePicker1.Text != string.Empty)
            {
                Zlecenie z = new Zlecenie(textBox1.Text, dateTimePicker1.Value, new TimeSpan(0, 0, 0));
                f1.zlecenia.Add(z);
                ListViewItem li = new ListViewItem();
                f1.listView1.BeginUpdate();
                li.Text = z.Nazwa;
                li.SubItems.Add(z.Data.ToShortDateString());
                li.SubItems.Add(z.Czas.ToString());
                f1.listView1.Items.Add(li);

                f1.listView1.EndUpdate();
                this.Close();
            }
            else
            {
                MessageBox.Show("Nie podano daty lub nazwy projektu.", "Błędne wypełnienie!!!", MessageBoxButtons.OK);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
