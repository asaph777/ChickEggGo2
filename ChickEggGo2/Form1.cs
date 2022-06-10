using System;
using System.Windows.Forms;

namespace ChickEggGo2
{
   
    public partial class Form1 : Form
    {
        Server empSer = new Server();
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var countChickens = int.Parse(textBox1.Text);
            var countEggs = int.Parse(textBox2.Text);
            var drinks = comboBox1.SelectedItem.ToString();

            if (Server.countRequests >= 8)
            {
                button1.Enabled = false;
                MessageBox.Show("test");
                return;
            }

            empSer.ReciveRequest(countChickens, countEggs, drinks);
            button2.Enabled = true;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            empSer.Send();
            button2.Enabled = false;
            button1.Enabled = false;
            button3.Enabled = true;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            string[] results = empSer.Serve();
            foreach (var item in results)
            {
                listBox1.Items.Add(item);
            }
            button1.Enabled = true;
            button3.Enabled = false;
        }
    }
}
