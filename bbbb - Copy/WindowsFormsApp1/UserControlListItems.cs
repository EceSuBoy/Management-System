using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class UserControlListItems : UserControl
    {
        public UserControlListItems()
        {
            InitializeComponent();
        }

        #region Properties
        private string _title;
        private string _message;
        private Image _Icon;

        [Category("Custom Props")]
        public string Title
        {
            get { return _title; }
            set { _title = value; lblTitle.Text = value; }
        }

        [Category("Custom Props")]
        public  string Message
        {
            get { return _message; }
            set { _message = value; lblMessage.Text = value; }
        }

        [Category("Custom Props")]
        public Image icon
        {
            get { return _Icon; }
            set { _Icon = value; pictureBox1.Image = value; }
        }

        #endregion

        private void UserControlListItems_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.Silver;
        }

        private void UserControlListItems_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }
    }
}
