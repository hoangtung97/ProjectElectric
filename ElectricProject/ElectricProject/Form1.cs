using ElectricProject.Resource3D;
using MindFusion.Diagramming;
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
            panel_Menu.Visible = false;
            panel_Simulate.Visible = false;
            panel_LineProperties1.Visible = false;
         
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

            this.workpanel.Controls.Add(this.panel_work2d);        
            this.workpanel.Controls.Add(this.panel_work3d);
            this.workpanel.Controls.Add(this.panel_worklythuyet);
            this.workpanel.Controls.Add(this.panel_workthuchanh);

            this.panel_workthuchanh.Dock = DockStyle.Fill;
            this.panel_worklythuyet.Dock = DockStyle.Fill;
            this.panel_work3d.Dock = DockStyle.Fill;
            this.panel_work2d.Dock = DockStyle.Fill;


        }

        private void InvisibleWork()
        {
            panel_work2d.Visible = false;
            panel_work3d.Visible = false;
            panel_worklythuyet.Visible = false;
            panel_workthuchanh.Visible = false;
            panel_LineProperties1.Visible = false ;
            panel_Simulate.Visible = false;
        }

        private void InvisibleMenu()
        {
            panel_Menu.Visible = false;
            panel_2D.Visible = false;
            panel_3D.Visible = false;
            panel_lythuyet.Visible = false;
            panel_Thuchanh.Visible = false;
            //displaypanel.Visible = true;


        }

        private void btb_Simulate_Click(object sender, EventArgs e)
        {
            if (panel_Thuchanh.Visible == true)
            {
                InvisibleMenu();
                return;
            }
            else
            {

                InvisibleWork();
                InvisibleMenu();
                panel_Menu.Visible = true;
                panel_Thuchanh.Visible = true;
                panel_workthuchanh.Visible = true;
                panel_LineProperties1.Visible = true;
                panel_Simulate.Visible = true;
            }


        }

        private void btn_Document_Click(object sender, EventArgs e)
        {
            if (panel_lythuyet.Visible == true)
            {
                InvisibleMenu();
                return;
            }
            else
            {
                
                InvisibleWork();
                InvisibleMenu();
                panel_Menu.Visible = true;
                panel_lythuyet.Visible = true;
                panel_worklythuyet.Visible = true;

            }
            

            //fill form
            PDFViewerForm objForm = new PDFViewerForm();
            objForm.TopLevel = false;
            panel_worklythuyet.Controls.Add(objForm);
            objForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            objForm.Dock = DockStyle.Fill;
            objForm.Show();

        }

        private void btn_2D_Click(object sender, EventArgs e)
        {
             if (panel_2D.Visible == true)
            {
                InvisibleMenu();
                return;
            }
            else
            {
                
                InvisibleWork();
                InvisibleMenu();
                panel_Menu.Visible = true;
                panel_2D.Visible = true;
                panel_work2d.Visible = true;
            }
           
        }
         

        private void btn_3D_Click(object sender, EventArgs e)
        {
            if (panel_3D.Visible == true)
            {
                InvisibleMenu();
                return;
            }
            else
            {

                InvisibleWork();
                InvisibleMenu();
                panel_Menu.Visible = true;
                panel_3D.Visible = true;
                panel_work3d.Visible = true;
            }

        }

        private void btn_Help_Click(object sender, EventArgs e)
        {

        }

        private void btn_Option_Click(object sender, EventArgs e)
        {

        }

        private void btn_Lythuyetdien1_Click(object sender, EventArgs e)
        {
            if (panel_SubmenuDoccument1.Visible == false)
            {
                panel_SubmenuDoccument1.Visible = true;
            }
            else
            {
                panel_SubmenuDoccument1.Visible = false;
            }
            panel_SubmenuDoccument2.Visible = false;
        }

        private void btn_Lythuyetdien2_Click(object sender, EventArgs e)
        {
            if (panel_SubmenuDoccument2.Visible == false)
            {
                panel_SubmenuDoccument2.Visible = true;
            }
            else
            {
                panel_SubmenuDoccument2.Visible = false;
            }
            panel_SubmenuDoccument1.Visible = false;
        }

    #region Cac cong cu 3d

        private void Display3d(int DeviceIndex)
        {

            switch (DeviceIndex)
            {
                case 1:
                    {
                        elementHost1.Child = new Mayphatdien();
                        break;
                    }
                case 2:
                    {
                        elementHost1.Child = new Aptomat();
                        break;
                    }
                case 3:
                    {
                        break;
                    }
                case 4:
                    {
                        elementHost1.Child = new Aptomat();
                        break;
                    }
                case 5:
                    {
                        elementHost1.Child = new Aptomat();
                        break;
                    }
                case 6:
                    {
                        elementHost1.Child = new Aptomat();
                        break;
                    }
                case 7:
                    {
                        elementHost1.Child = new Aptomat();
                        break;
                    }
                case 8:
                    {
                        elementHost1.Child = new Aptomat();
                        break;
                    }
                case 9:
                    {
                        elementHost1.Child = new Aptomat();
                        break;
                    }
                case 10:
                    {
                        elementHost1.Child = new Aptomat();
                        break;
                    }

                default:
                    break;
            }
        }

        private void button53_Click(object sender, EventArgs e)
        {
            Display3d(1);

        }

        private void button71_Click(object sender, EventArgs e)
        {
            Display3d(2);
        }
#endregion

        #region thuc hanh
        #region thuc hanh
        private void button7_Click(object sender, EventArgs e)
        {
            ShapeNode node = diagram1.Factory.CreateShapeNode(10, 10, 20, 20);
            node.Id = "Nguon xoay chieu 1 pha";
            node.Image = Properties.Resources._2_nguon_xoay_chieu_mot_pha;
            node.Transparent = true;
            node.ImageAlign = MindFusion.Drawing.ImageAlign.Fit;
        }

        #endregion


        #region properties



        bool firstClick = true;
        private void TextboxLine_Click(object sender, EventArgs e)
        {


            if (firstClick)
            {
                List<DiagramItem> ListItemDiagram = GetItemSelected();
                if (ListItemDiagram.Count == 1)
                {
                    if (ListItemDiagram[0].GetType() == typeof(DiagramLink))
                    {
                        TextboxLine.Text = ListItemDiagram[0].Text;
                    }
                }
                TextboxLine.SelectAll();
                firstClick = false;
            }

        }
        /// <summary>
        /// get all item seleted in diagram 
        /// </summary>
        /// <returns></returns>
        private List<DiagramItem> GetItemSelected()
        {
            List<DiagramItem> ListItemDiagram = new List<DiagramItem>();
            foreach (var item in diagram1.Items)
            {
                if (item.Selected == true)
                {
                    ListItemDiagram.Add(item);
                }
            }
            return ListItemDiagram;
        }
        private void TextboxLine_Leave(object sender, EventArgs e)
        {
            firstClick = !firstClick;
            List<DiagramItem> ListItemDiagram = GetItemSelected();
            if (ListItemDiagram.Count == 1)
            {
                if (ListItemDiagram[0].GetType() == typeof(DiagramLink))
                {
                    ListItemDiagram[0].Text = TextboxLine.Text;
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("sele");
            List<DiagramItem> ListItemDiagram = GetItemSelected();

            if (ListItemDiagram.Count == 1)
            {
                if (ListItemDiagram[0].GetType() == typeof(DiagramLink))
                {
                    if (comboBox2.SelectedIndex == 0)
                    {
                        ListItemDiagram[0].Pen = new MindFusion.Drawing.Pen(Color.Red, Convert.ToInt32(TextboxWidth.Text));
                    }
                    if (comboBox2.SelectedIndex == 1)
                    {
                        ListItemDiagram[0].Pen = new MindFusion.Drawing.Pen(Color.Blue, Convert.ToInt32(TextboxWidth.Text));
                    }
                }
                else if (comboBox2.SelectedIndex == 2)
                {

                }
            }

        }

        private void TextboxWidth_Click(object sender, EventArgs e)
        {

        }

        private void TextboxWidth_Leave(object sender, EventArgs e)
        {
            List<DiagramItem> ListItemDiagram = GetItemSelected();
            if (ListItemDiagram.Count == 1)
            {
                if (ListItemDiagram[0].GetType() == typeof(DiagramLink))
                {
                    Color color = ListItemDiagram[0].Pen.Color;
                    ListItemDiagram[0].Pen = new MindFusion.Drawing.Pen(color, Convert.ToInt32(TextboxWidth.Text));
                }
            }
        }

        private void diagram1_LinkSelected(object sender, LinkEventArgs e)
        {

            List<DiagramItem> ListItemDiagram = GetItemSelected();
            if (ListItemDiagram.Count == 1)
            {
                if (ListItemDiagram[0].GetType() == typeof(DiagramLink))
                {
                    try
                    {
                        TextboxLine.Text = ListItemDiagram[0].Text;
                        TextboxWidth.Text = ListItemDiagram[0].Pen.Width.ToString();

                        if (ListItemDiagram[0].Pen.Color == Color.Red)
                        {
                            comboBox2.SelectedItem = 1;
                        }
                        else
                        {
                            comboBox2.SelectedItem = 2;
                        }
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
        }

        private void diagram1_LinkCreated(object sender, LinkEventArgs e)
        {
            e.Link.Pen = new MindFusion.Drawing.Pen(Color.Blue, 0);
        }

        #endregion


        private void button8_Click(object sender, EventArgs e)
        {
            ShapeNode node = diagram1.Factory.CreateShapeNode(10, 10, 20, 20);
            node.Id = "Cong tac to";
            node.Image = Properties.Resources._11_CoNG_TaC_To;
            node.Transparent = true;
            node.ImageAlign = MindFusion.Drawing.ImageAlign.Fit;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ShapeNode node = diagram1.Factory.CreateShapeNode(10, 10, 20, 20);
            node.Id = "Role thoi gian";
            node.Image = Properties.Resources._12_ro_le_thoi_gian;
            node.Transparent = true;
            node.ImageAlign = MindFusion.Drawing.ImageAlign.Fit;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ShapeNode node = diagram1.Factory.CreateShapeNode(10, 10, 20, 20);
            node.Id = "Role";
            node.Image = Properties.Resources._13_RoLE;
            node.Transparent = true;
            node.ImageAlign = MindFusion.Drawing.ImageAlign.Fit;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            ShapeNode node = diagram1.Factory.CreateShapeNode(10, 10, 20, 20);
            node.Id = "Role nhiet";
            node.Image = Properties.Resources._15_RoLE_NHIeT;
            node.Transparent = true;
            node.ImageAlign = MindFusion.Drawing.ImageAlign.Fit;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ShapeNode node = diagram1.Factory.CreateShapeNode(10, 10, 20, 20);
            node.Id = "Role bao ve qua dong";
            node.Image = Properties.Resources._16_role_bao_ve_qua_dong;
            node.Transparent = true;
            node.ImageAlign = MindFusion.Drawing.ImageAlign.Fit;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            ShapeNode node = diagram1.Factory.CreateShapeNode(10, 10, 20, 20);
            node.Id = "Role bao ve mat pha";
            node.Image = Properties.Resources._17_role_bao_ve_mat_pha;
            node.Transparent = true;
            node.ImageAlign = MindFusion.Drawing.ImageAlign.Fit;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            ShapeNode node = diagram1.Factory.CreateShapeNode(10, 10, 20, 20);
            node.Id = "Role bao ve dien ap";
            node.Image = Properties.Resources._18_role_bao_ve_dien_ap;
            node.Transparent = true;
            node.ImageAlign = MindFusion.Drawing.ImageAlign.Fit;
        }


        #endregion


        

        #region hiển thị flash
        private void button3_Click(object sender, EventArgs e)
        {
            axShockwaveFlash1.Visible = true;
            axShockwaveFlash1.Movie = Environment.CurrentDirectory + @"\2D\HeThongBoiTronAI9B.swf";
        }
        #endregion

        private void button4_Click(object sender, EventArgs e)
        {
            PDFViewerForm pdf = new PDFViewerForm();
            pdf.Loadpdf(@"D:\vidu.pdf");

        }

        private void panel_Thuchanh_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
