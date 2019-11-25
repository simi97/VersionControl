﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserMaintenance.Entities;

namespace UserMaintenance
{
    public partial class Form1 : Form
    {
        BindingList<User> users = new BindingList<User>();
        public Form1()
        {
            InitializeComponent();
            label1.Text = Resource1.FullName;            
            button1.Text = Resource1.Add; 
            listBox1.DataSource = users;
            listBox1.ValueMember = "ID";
            listBox1.DisplayMember = "FullName";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var u = new User() {FullName=textBox1.Text};
            users.Add(u);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text File | *.txt";
            sfd.FileName = "próba1.txt";
            if (sfd.ShowDialog()==DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(sfd.OpenFile()))
                {
                    foreach (var u in users)
                    {
                        sw.Write(u.FullName);
                        sw.Write(u.ID);
                    }
                    sw.Dispose();
                    sw.Close();
                }                
            }
        }
    }
}
