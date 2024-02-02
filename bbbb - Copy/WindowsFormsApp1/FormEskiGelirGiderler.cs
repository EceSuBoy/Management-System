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
    public partial class FormEskiGelirGiderler : Form
    {
        public FormEskiGelirGiderler()
        {
            InitializeComponent();
        }

        private void populateItems()
        {
            UserControlListItems[] listItems = new UserControlListItems[20];

            for( int i = 0; i < listItems.Length; i++ )
            {
                listItems[i] = new UserControlListItems();
                listItems[i].Width = flowLayoutPanel1.Width;
                listItems[i].Title = "Get Data Somewhere";
                listItems[i].Message = "Any Data Source";

                if (flowLayoutPanel1.Controls.Count < 0)
                {
                    flowLayoutPanel1.Controls.Clear();
                }
                else

                    flowLayoutPanel1.Controls.Add(listItems[i] );
                
            }
        }

        private void FormEskiGelirGiderler_Load(object sender, EventArgs e)
        {
            populateItems();
        }
    }
}
