using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS
{
    public partial class frmTest : Form
    {
        int listone;
        int listtwo;
        public frmTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //frmAddUpdatePersonInfo frmAdd = new frmAddUpdatePersonInfo(2);
            //frmAdd.ShowDialog();
            listone=listBox1.Items.Count;
            listtwo=listBox2.Items.Count;
            listBox2.Items.Add(listBox1.SelectedItem);
            listBox1.Items.Remove(listBox1.SelectedItem);
            textBox1.Text=listBox1.Items.Count.ToString();
            textBox2.Text=listBox2.Items.Count.ToString();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.RemoveAt(int.Parse(textBox1.Text));
        }

        private void frmTest_Load(object sender, EventArgs e)
        {
            
        }
    }
}
