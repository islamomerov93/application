using Newtonsoft.Json;
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

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        User User = new User();
        private void textBox1_Enter(object sender, EventArgs e)
        {
            (sender as TextBox).Text = string.Empty;
            (sender as TextBox).ForeColor = Color.Black;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            User.Name = (sender as TextBox).Text;
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            User.Surname = (sender as TextBox).Text;
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            User.FatherName = (sender as TextBox).Text;
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            User.Country = (sender as TextBox).Text;
        }

        private void textBox11_Leave(object sender, EventArgs e)
        {
            User.City = (sender as TextBox).Text;
        }

        private void textBox13_Leave(object sender, EventArgs e)
        {
            User.PhoneNumber = (sender as TextBox).Text;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            User.Sex = (sender as RadioButton).Text;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            User.BirthDate = (sender as DateTimePicker).Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var obj = JsonConvert.SerializeObject(User);
            File.WriteAllText($"{User.Name}.json", obj);
            nameTbx.Text = "Name"; 
            surnameTbx.Text = "Surame";
            FnameTbx.Text = "Father name";
            countryTbx.Text = "Country";
            cityTbx.Text = "City";
            phoneTbx.Text = "Phone number";
            nameTbx.ForeColor = surnameTbx.ForeColor = FnameTbx.ForeColor = countryTbx.ForeColor = cityTbx.ForeColor = phoneTbx.ForeColor = Color.LightGray;
            dateTimePicker1.Text = DateTime.Now.ToShortDateString();
            radioButton1.Checked = radioButton1.Checked = false; 
        }

        private void button2_Click(object sender, EventArgs e)
        { 
            if (File.Exists(textBox2.Text))
            {
                var des = File.ReadAllText(textBox2.Text);
                User =  JsonConvert.DeserializeObject<User>(des);
                nameTbx.Text = User.Name;
                surnameTbx.Text = User.Surname;
                FnameTbx.Text = User.FatherName;
                countryTbx.Text = User.Country;
                cityTbx.Text = User.City;
                phoneTbx.Text = User.PhoneNumber;
                dateTimePicker1.Value = User.BirthDate;
                if (User.Sex == "Man") radioButton1.Checked = true;
                else radioButton2.Checked = true;
                textBox2.ForeColor = Color.LightGray;
                textBox2.Text = "deserialize";
                nameTbx.ForeColor = surnameTbx.ForeColor = FnameTbx.ForeColor = countryTbx.ForeColor = cityTbx.ForeColor = phoneTbx.ForeColor = Color.Black;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.Text = string.Empty;
            textBox2.ForeColor = Color.Black;
        }
    }
    class MyClass
    {
        public int MyProperty { get; set; }
    }
}
