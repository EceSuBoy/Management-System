using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormMenu1 : Form
    {
        public FormMenu1()
        {
            InitializeComponent();
            customizeDesign();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.DoubleBuffered = true;
        }

        #region Forms Functionality
        private int tolerance = 12;
        private const int WM_NCHITTEST = 132;
        private const int HTBOTTOMRIGHT = 17;
        private Rectangle sizeGripRectangle;

        protected override void WndProc(ref Message m)
        {
           switch(m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    var hitPoint = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                    if (sizeGripRectangle.Contains(hitPoint))
                        m.Result = new IntPtr(HTBOTTOMRIGHT);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            var region = new Region(new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));
            sizeGripRectangle = new Rectangle(this.ClientRectangle.Width - tolerance, this.ClientRectangle.Height - tolerance, tolerance, tolerance);
            region.Exclude(sizeGripRectangle);
            this.panelPrincipal.Region = region;
            this.Invalidate();
        }
        private void customizeDesign()
        {
            panelCalc.Visible = false;
            panelIslem.Visible = false;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush blueBrush = new SolidBrush(Color.FromArgb(244, 244, 244));
            e.Graphics.FillRectangle(blueBrush, sizeGripRectangle);
            base.OnPaint(e);
            ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent, sizeGripRectangle);
        }

        private void FormMenu1_Load(object sender, EventArgs e)
        {

        }

        private void gunaPictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //x y positions
        int lx, ly;
        int sw, sh;

        private void btnMinimizer_Click(object sender, EventArgs e)
        {
            btnMaximize.Visible = true;
            btnMinimizer.Visible = false;

            this.Size = new Size(sw, sh);
            this.Location = new Point(lx, ly);
        }


        private void btnMaximize_Click(object sender, EventArgs e)
        {
            lx = this.Location.X;
            ly = this.Location.Y;
            sw = this.Size.Width;
            sh = this.Size.Height;

            btnMaximize.Visible = false;
            btnMinimizer.Visible = true;

            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        }
        // Create Form Drag Function
        private void panelTop_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnMinimized_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        #endregion

        private void OpenForm<MyForm>() where MyForm : Form, new()
        {
            Form form;
            //Search the collection for the form
            form = panelFormul.Controls.OfType<MyForm>().FirstOrDefault();

            //If the form/instance does not exist
            if (form == null)
            {
                form = new MyForm();
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
                panelFormul.Controls.Add(form);
                panelFormul.Tag = form;
                form.Show();
                form.BringToFront();
            }
            //if the form/instance exists
            else
            {
                form.BringToFront();
            }
        }


            private void hideSubMenu()
        {
            if(panelCalc.Visible == true)
               panelCalc.Visible = false;

            if (panelIslem.Visible == true)
                panelIslem.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if(subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }
        #region Muhasebe
        private void btnCalc_Click(object sender, EventArgs e)
        {
            showSubMenu(panelCalc);
        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            //codes...
            OpenForm<FormGelirGiderler>();
            hideSubMenu();
        }

        private void gunaButton4_Click(object sender, EventArgs e)
        {
            //codes...
            OpenForm<FormEskiGelirGiderler>();
            hideSubMenu();
        }
#endregion
        #region Islemler
        private void btnIslem_Click(object sender, EventArgs e)
        {
            showSubMenu(panelIslem);
        }

        private void gunaButton5_Click(object sender, EventArgs e)
        {
            //codes...
            hideSubMenu();
        }

        private void gunaButton6_Click(object sender, EventArgs e)
        {
            //codes...
            hideSubMenu();
        }

        private void gunaButton7_Click(object sender, EventArgs e)
        {
            //codes...
            hideSubMenu();
        }

        #endregion

        bool menuExpand= true;
        private void menuTransition_Tick(object sender, EventArgs e)
        {
            if(menuExpand)
            {
                panelSideMenu.Width -= 10;
                if(panelSideMenu.Width <= 62)
                {
                    menuExpand = false;
                    menuTransition.Stop();

                }
            }
            else
            {
                panelSideMenu.Width += 10;
                if (panelSideMenu.Width >= 230)
                {
                    menuExpand = true;
                    menuTransition.Stop();

                }
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            menuTransition.Start();
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            Dashboard ds = new Dashboard();
            ds.Show();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //PANEL METHODS



    }
}
