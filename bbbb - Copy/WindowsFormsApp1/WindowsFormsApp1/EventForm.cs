using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class EventForm : Form
    {
        String connString = "server=localhost;user id=root;database=db_calendar;sslmode=none";
        
        public EventForm()
        {
            InitializeComponent();
        }

        private void EventForm_Load(object sender, EventArgs e)
        {
            panel1.Height = 39;
            txdate.Text = UserControlDays.static_day + "/" + Dashboard.static_month+"/" + Dashboard.static_year;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            String sql = "INSERT INTO tbl_calendar(date,event)values(?,?)";
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("date",txdate.Text);
            cmd.Parameters.AddWithValue("event",txevent.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Kaydedildi");
            cmd.Dispose();
            conn.Close();
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            if(panel1.Height == 238)
            {
                panel1.Height = 39;
            }
            else
            {
                panel1.Height = 238;
            }

        }
    }
}
