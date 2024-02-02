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
    public partial class UserControlDays : UserControl
    {
        String connString = "server=localhost;user=root;database=db_calendar;sslmode=none";

        public static string static_day;
        public UserControlDays()
        {
            InitializeComponent();
        }

        private void UserControlDays_Load(object sender, EventArgs e)
        {

        }
        public void days (int numday)
        {
            lbdays.Text = numday + "";
        }

        private void UserControlDays_Click(object sender, EventArgs e)
        {
            static_day = lbdays.Text;
            //start timer if usercontroldays clicked
            saat.Start();
            EventForm eventform = new EventForm();
            eventform.Show();
        }

        //new method to display the event
        private void displayEvent()
        {
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            String sql = "SELECT * FROM tbl_calendar where date = ?";
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("date",Dashboard.static_year + "/" + Dashboard.static_month + "/" + lbdays.Text);
            MySqlDataReader reader = cmd.ExecuteReader();
            if(reader.Read())
            {
                lbevent.Text = reader["event"].ToString();
            }
            reader.Dispose();
            cmd.Dispose();
            conn.Close();
        }

        //create a timer for autodisplay event if new event is added
        private void saat_Tick(object sender, EventArgs e)
        {
            displayEvent(); 
        }



    }
}
