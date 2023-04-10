using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bug_Tracker
{
    public partial class Form1 : Form
    {
        int isDark = 0;
        Color whitesh = Color.FromArgb(240, 240, 240);
        Color blackesh = Color.FromArgb(51, 51, 51);
        public Form1()
        {
            InitializeComponent();
            loadFile();
            // Set the format to custom
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            // Set the custom format string
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            //get the date to make a unique key
            DateTime now = DateTime.Now;
            string key = now.ToString("yyyyddHss");
            //get text from form
            string title = titletb.Text;
            string desc = desctb.Text;
            string dev;
            string date = dateTimePicker1.Text;
            string status;
            //if null set it to empty string
            object devCb = devcb.SelectedItem;
            if (devCb != null) dev = devCb.ToString();
            else dev = "";
            object statusLb = statuslb.SelectedItem;
            if (statusLb != null) status = statusLb.ToString();
            else status = "";


            //if not found show message
            if (title != "" && desc != "" && status != "" && dev!="")
            {
                //add to list
                string[] s = { title, desc, date, dev, status };
                ListViewItem itm = new ListViewItem(key);
                itm.SubItems.Add(title);
                itm.SubItems.Add(desc);
                itm.SubItems.Add(date);
                itm.SubItems.Add(dev);
                itm.SubItems.Add(status);
                listView1.Items.Add(itm);
                //set to empty
                titletb.Text = "";
                desctb.Text = "";
            }
            else
            {
                MessageBox.Show("Enter The Required Info");
            }
            save();
        }

        private void removebtn_Click(object sender, EventArgs e)
        {
            int n=listView1.SelectedItems.Count;
            if(n>0)
               listView1.SelectedItems[0].Remove();

            save();
        }
        public void save()
        {
            //Create a new instance of the StreamWriter class and create the list view items string
            StreamWriter writer = new StreamWriter("listViewItems.txt");
            string listViewItems = "";
            foreach (ListViewItem item in listView1.Items)
            {
                foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                {
                    listViewItems += subItem.Text + ",";
                }
                listViewItems += "\r\n";
            }

            //Write the list view items to the file and close the StreamWriter
            writer.Write(listViewItems);
            writer.Close();
        }
        public void loadFile()
        {
            string fileName = "listViewItems.txt";
            if (!File.Exists(fileName))
            {
                using (FileStream fs = File.Create(fileName));
            }
            StreamReader sr = new StreamReader(fileName);
            while (!sr.EndOfStream)
            {
                string[] row = sr.ReadLine().Split(',');         
                ListViewItem item = new ListViewItem(row);
                listView1.Items.Add(item);
            }
            sr.Close();
        }

        private void dark_Click_1(object sender, EventArgs e)
        {
            dark.Text = (isDark == 1 ? "Dark" : "Light");
            this.BackColor = (isDark == 1 ? whitesh : blackesh);
            label1.ForeColor = (isDark==0 ? whitesh : blackesh);
            label2.ForeColor = (isDark == 0 ? whitesh : blackesh);
            label3.ForeColor = (isDark == 0 ? whitesh : blackesh);
            label4.ForeColor = (isDark == 0 ? whitesh : blackesh);
            label5.ForeColor = (isDark == 0 ? whitesh : blackesh);
            listView1.ForeColor = (isDark == 0 ? whitesh : blackesh);
            listView1.BackColor = (isDark == 1 ? whitesh : blackesh);
            addbtn.BackColor = (isDark == 1 ? whitesh : blackesh);
            addbtn.ForeColor= (isDark == 0 ? whitesh : blackesh);
            dark.ForeColor= (isDark == 0 ? whitesh : blackesh);
            removebtn.ForeColor= (isDark == 0 ? whitesh : blackesh);
            int g = (isDark == 0 ? 222 : 0);
            linkLabel1.LinkColor= Color.FromArgb(0, g, 255);
            isDark ^= 1;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://linkedin.com/in/abanob-raffet/");
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
          
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
