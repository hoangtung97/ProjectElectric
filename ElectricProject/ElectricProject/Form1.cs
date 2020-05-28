using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElectricProject
{
    public partial class Form1 : Form
    {
        int mov;
        int movX;
        int movY;
        public Form1()
        {
            InitializeComponent();
            btn_Restoredown.Visible = false;
            panel5.Visible = false;

        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private const int CS_DropShadow = 0x00020000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle = CS_DropShadow;
                return cp;

            }
        }
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_Restoredown_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btn_Fullscreen.Visible = true;
            btn_Restoredown.Visible = false;
        }

        private void btn_Fullscreen_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btn_Restoredown.Visible = true;
            btn_Fullscreen.Visible = false;
        }

        private void btn_Minimized_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.WindowState = FormWindowState.Normal;
        }

        private void btb_Simulate_Click(object sender, EventArgs e)
        {
            panel_lythuyet.Visible = false;
            panel_2D.Visible = false;
            panel_3D.Visible = false;
            if (panel_Thuchanh.Visible == true)
            {
                panel_Thuchanh.Visible = false;
            }
            else
            {
                panel_Thuchanh.Visible = true;
            }
            panel5.Visible = true;

        }

        private void btn_Document_Click(object sender, EventArgs e)
        {
            panel_Thuchanh.Visible = false;
            panel8.Visible = false;
            panel9.Visible = false;
            panel_2D.Visible = false;
            panel_3D.Visible = false;


            if (panel_lythuyet.Visible == true)
            {
                panel_lythuyet.Visible = false;
            }
            else
            {
                panel_lythuyet.Visible = true;
            }
            panel5.Visible = true;
        }

        private void btn_2D_Click(object sender, EventArgs e)
        {
            panel_lythuyet.Visible = false;
            panel_Thuchanh.Visible = false;
            panel_3D.Visible = false;
            if ( panel_2D.Visible == true)
            {
                panel_2D.Visible = false;
            }
            else
            {
                panel_2D.Visible = true;
            }
            panel5.Visible = true;
        }

        private void btn_3D_Click(object sender, EventArgs e)
        {
            panel_2D.Visible = false;
            panel_lythuyet.Visible = false;
            panel_Thuchanh.Visible = false;
            if(panel_3D.Visible == true)
            {
                panel_3D.Visible = false;
            }
            else
            {
                panel_3D.Visible = true;
            }
            panel5.Visible = true;
        }

        private void btn_Help_Click(object sender, EventArgs e)
        {

        }

        private void btn_Option_Click(object sender, EventArgs e)
        {

        }

        private void btn_Lythuyetdien1_Click(object sender, EventArgs e)
        {
            if (panel8.Visible == false)
            {
                panel8.Visible = true;
            }
            else
            {
                panel8.Visible = false;
            }
            panel9.Visible = false;
        }

        private void btn_Lythuyetdien2_Click(object sender, EventArgs e)
        {
            if (panel9.Visible == false)
            {
                panel9.Visible = true;
            }
            else
            {
                panel9.Visible = false;
            }
            panel8.Visible = false;
        }
    }
}
