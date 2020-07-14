using ElectricProject.Resource3D;
using MindFusion.Diagramming;
using MindFusion.Diagramming.Fluent;
using MindFusion.Diagramming.Lanes;
using System;
using System.Collections.Generic;
using MindFusion.Diagramming.WinForms;
using System.Drawing;
using System.Linq;
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

            diagram1.UndoManager.UndoEnabled = true;
            diagram1.UndoManager.History.Capacity = 20;

        }

        private void btn_trangchu_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form2().Show();
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
        public int countDevice = 0;

        private void button7_Click(object sender, EventArgs e)
        {
            Device device = new Device(2);
            ShapeNode node = diagram1.Factory.CreateShapeNode(10, 10, 40, 40);

            device.SetNode(node);

            countDevice += 1;
            node.Id = "" + countDevice;
            node.Image = Properties.Resources._1_CauDao1Pha;
            node.Transparent = true;
            node.ImageAlign = MindFusion.Drawing.ImageAlign.Fit;


            device.PortCount = 4;
            device.port.Add(new PointF(0*device.shapenode.Bounds.Width + device.shapenode.Bounds.X,
                0.45f * device.shapenode.Bounds.Height + device.shapenode.Bounds.Y));
            device.port.Add(new PointF(0 * device.shapenode.Bounds.Width + device.shapenode.Bounds.X, 
                0.55f * device.shapenode.Bounds.Height + device.shapenode.Bounds.Y));
            device.port.Add(new PointF(1 * device.shapenode.Bounds.Width + device.shapenode.Bounds.X,
                0.45f * device.shapenode.Bounds.Height + device.shapenode.Bounds.Y));
            device.port.Add(new PointF(1 * device.shapenode.Bounds.Width + device.shapenode.Bounds.X,
                0.55f * device.shapenode.Bounds.Height + device.shapenode.Bounds.Y));

            AllDevice.Add(device);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Device device = new Device(3);
            ShapeNode node = diagram1.Factory.CreateShapeNode(10, 10, 40, 40);

            device.SetNode(node);

            countDevice += 1;
            node.Id = "" + countDevice;
            node.Image = Properties.Resources._2_CauDao1PhaDaoChieu;
            node.Transparent = true;
            node.ImageAlign = MindFusion.Drawing.ImageAlign.Fit;


            device.PortCount = 4;
            device.port.Add(new PointF(0 * device.shapenode.Bounds.Width + device.shapenode.Bounds.X,
                0.45f * device.shapenode.Bounds.Height + device.shapenode.Bounds.Y));
            device.port.Add(new PointF(0 * device.shapenode.Bounds.Width + device.shapenode.Bounds.X,
                0.55f * device.shapenode.Bounds.Height + device.shapenode.Bounds.Y));
            device.port.Add(new PointF(1 * device.shapenode.Bounds.Width + device.shapenode.Bounds.X,
                0.45f * device.shapenode.Bounds.Height + device.shapenode.Bounds.Y));
            device.port.Add(new PointF(1 * device.shapenode.Bounds.Width + device.shapenode.Bounds.X,
                0.55f * device.shapenode.Bounds.Height + device.shapenode.Bounds.Y));

            AllDevice.Add(device);
            //ShapeNode node = diagram1.Factory.CreateShapeNode(20, 20, 40, 40);
            //node.Id = "Cong tac to";
            //node.Image = Properties.Resources._2_CauDao1PhaDaoChieu;
            //node.Transparent = true;
            //node.ImageAlign = MindFusion.Drawing.ImageAlign.Fit;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Device device = new Device(4);
            ShapeNode node = diagram1.Factory.CreateShapeNode(10, 10, 40, 40);

            device.SetNode(node);

            countDevice += 1;
            node.Id = "" + countDevice;
            node.Image = Properties.Resources._3_CauDao3Pha;
            node.Transparent = true;
            node.ImageAlign = MindFusion.Drawing.ImageAlign.Fit;


            device.PortCount = 4;
            device.port.Add(new PointF(0 * device.shapenode.Bounds.Width + device.shapenode.Bounds.X,
                0.45f * device.shapenode.Bounds.Height + device.shapenode.Bounds.Y));
            device.port.Add(new PointF(0 * device.shapenode.Bounds.Width + device.shapenode.Bounds.X,
                0.55f * device.shapenode.Bounds.Height + device.shapenode.Bounds.Y));
            device.port.Add(new PointF(1 * device.shapenode.Bounds.Width + device.shapenode.Bounds.X,
                0.45f * device.shapenode.Bounds.Height + device.shapenode.Bounds.Y));
            device.port.Add(new PointF(1 * device.shapenode.Bounds.Width + device.shapenode.Bounds.X,
                0.55f * device.shapenode.Bounds.Height + device.shapenode.Bounds.Y));

            AllDevice.Add(device);
            //ShapeNode node = diagram1.Factory.CreateShapeNode(20, 20, 40, 40);
            //node.Id = "Role thoi gian";
            //node.Image = Properties.Resources._12_ro_le_thoi_gian;
            //node.Transparent = true;
            //node.ImageAlign = MindFusion.Drawing.ImageAlign.Fit;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Device device = new Device(5);
            ShapeNode node = diagram1.Factory.CreateShapeNode(10, 10, 40, 40);

            device.SetNode(node);

            countDevice += 1;
            node.Id = "" + countDevice;
            node.Image = Properties.Resources._4_CauDao3PhaDaoChieu;
            node.Transparent = true;
            node.ImageAlign = MindFusion.Drawing.ImageAlign.Fit;


            device.PortCount = 4;
            device.port.Add(new PointF(0 * device.shapenode.Bounds.Width + device.shapenode.Bounds.X,
                0.45f * device.shapenode.Bounds.Height + device.shapenode.Bounds.Y));
            device.port.Add(new PointF(0 * device.shapenode.Bounds.Width + device.shapenode.Bounds.X,
                0.55f * device.shapenode.Bounds.Height + device.shapenode.Bounds.Y));
            device.port.Add(new PointF(1 * device.shapenode.Bounds.Width + device.shapenode.Bounds.X,
                0.45f * device.shapenode.Bounds.Height + device.shapenode.Bounds.Y));
            device.port.Add(new PointF(1 * device.shapenode.Bounds.Width + device.shapenode.Bounds.X,
                0.55f * device.shapenode.Bounds.Height + device.shapenode.Bounds.Y));

            AllDevice.Add(device);
            //ShapeNode node = diagram1.Factory.CreateShapeNode(20, 20, 40, 40);
            //node.Id = "Role";
            //node.Image = Properties.Resources._;
            //node.Transparent = true;
            //node.ImageAlign = MindFusion.Drawing.ImageAlign.Fit;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Device device = new Device(6);
            ShapeNode node = diagram1.Factory.CreateShapeNode(10, 10, 40, 40);

            device.SetNode(node);

            countDevice += 1;
            node.Id = "" + countDevice;
            node.Image = Properties.Resources._5_Contactor;
            node.Transparent = true;
            node.ImageAlign = MindFusion.Drawing.ImageAlign.Fit;


            device.PortCount = 4;
            device.port.Add(new PointF(0.45f * device.shapenode.Bounds.Width + device.shapenode.Bounds.X,
                0 * device.shapenode.Bounds.Height + device.shapenode.Bounds.Y));
            device.port.Add(new PointF(0.55f * device.shapenode.Bounds.Width + device.shapenode.Bounds.X,
                0 * device.shapenode.Bounds.Height + device.shapenode.Bounds.Y));
            device.port.Add(new PointF(0.45f * device.shapenode.Bounds.Width + device.shapenode.Bounds.X,
                1 * device.shapenode.Bounds.Height + device.shapenode.Bounds.Y));
            device.port.Add(new PointF(0.55f * device.shapenode.Bounds.Width + device.shapenode.Bounds.X,
                1 * device.shapenode.Bounds.Height + device.shapenode.Bounds.Y));

            AllDevice.Add(device);
            //ShapeNode node = diagram1.Factory.CreateShapeNode(20, 20, 40, 40);
            //node.Id = "Role nhiet";
            //node.Image = Properties.Resources._15_RoLE_NHIeT;
            //node.Transparent = true;
            //node.ImageAlign = MindFusion.Drawing.ImageAlign.Fit;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Device device = new Device(7);
            ShapeNode node = diagram1.Factory.CreateShapeNode(10, 10, 40, 40);

            device.SetNode(node);

            countDevice += 1;
            node.Id = "" + countDevice;
            node.Image = Properties.Resources._6_CongTac;
            node.Transparent = true;
            node.ImageAlign = MindFusion.Drawing.ImageAlign.Fit;


            device.PortCount = 2;
            device.port.Add(new PointF(0.4f * device.shapenode.Bounds.Width + device.shapenode.Bounds.X,
                1 * device.shapenode.Bounds.Height + device.shapenode.Bounds.Y));
            device.port.Add(new PointF(0.6f * device.shapenode.Bounds.Width + device.shapenode.Bounds.X,
                1 * device.shapenode.Bounds.Height + device.shapenode.Bounds.Y));

            AllDevice.Add(device);
            //    ShapeNode node = diagram1.Factory.CreateShapeNode(20, 20, 40, 40);
            //    node.Id = "Role bao ve qua dong";
            //    node.Image = Properties.Resources._16_role_bao_ve_qua_dong;
            //    node.Transparent = true;
            //    node.ImageAlign = MindFusion.Drawing.ImageAlign.Fit;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Device device = new Device(8);
            ShapeNode node = diagram1.Factory.CreateShapeNode(10, 10, 40, 40);

            device.SetNode(node);

            countDevice += 1;
            node.Id = "" + countDevice;
            node.Image = Properties.Resources._7_CongTacNgat;
            node.Transparent = true;
            node.ImageAlign = MindFusion.Drawing.ImageAlign.Fit;


            device.PortCount = 2;
            device.port.Add(new PointF(0.4f * device.shapenode.Bounds.Width + device.shapenode.Bounds.X,
                1 * device.shapenode.Bounds.Height + device.shapenode.Bounds.Y));
            device.port.Add(new PointF(0.6f * device.shapenode.Bounds.Width + device.shapenode.Bounds.X,
                1 * device.shapenode.Bounds.Height + device.shapenode.Bounds.Y));

            AllDevice.Add(device);
            //ShapeNode node = diagram1.Factory.CreateShapeNode(20, 20, 40, 40);
            //node.Id = "Role bao ve mat pha";
            //node.Image = Properties.Resources._17_role_bao_ve_mat_pha;
            //node.Transparent = true;
            //node.ImageAlign = MindFusion.Drawing.ImageAlign.Fit;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Device device = new Device(9);
            ShapeNode node = diagram1.Factory.CreateShapeNode(10, 10, 40, 40);

            device.SetNode(node);

            countDevice += 1;
            node.Id = "" + countDevice;
            node.Image = Properties.Resources._8_CongTacHanhTrinh;
            node.Transparent = true;
            node.ImageAlign = MindFusion.Drawing.ImageAlign.Fit;


            device.PortCount = 2;
            device.port.Add(new PointF(0.4f * device.shapenode.Bounds.Width + device.shapenode.Bounds.X,
                1 * device.shapenode.Bounds.Height + device.shapenode.Bounds.Y));
            device.port.Add(new PointF(0.6f * device.shapenode.Bounds.Width + device.shapenode.Bounds.X,
                1 * device.shapenode.Bounds.Height + device.shapenode.Bounds.Y));

            AllDevice.Add(device);
            //ShapeNode node = diagram1.Factory.CreateShapeNode(20, 20, 40, 40);
            //node.Id = "Role bao ve dien ap";
            //node.Image = Properties.Resources._18_role_bao_ve_dien_ap;
            //node.Transparent = true;
            //node.ImageAlign = MindFusion.Drawing.ImageAlign.Fit;
        }
        private void button13_Click(object sender, EventArgs e)
        {
            Device device = new Device(10);
            ShapeNode node = diagram1.Factory.CreateShapeNode(10, 10, 40, 40);

            device.SetNode(node);

            countDevice += 1;
            node.Id = "" + countDevice;
            node.Image = Properties.Resources._9_NutAnXanhKhongNho;
            node.Transparent = true;
            node.ImageAlign = MindFusion.Drawing.ImageAlign.Fit;


            device.PortCount = 2;
            device.port.Add(new PointF(0.4f * device.shapenode.Bounds.Width + device.shapenode.Bounds.X,
                1 * device.shapenode.Bounds.Height + device.shapenode.Bounds.Y));
            device.port.Add(new PointF(0.6f * device.shapenode.Bounds.Width + device.shapenode.Bounds.X,
                1 * device.shapenode.Bounds.Height + device.shapenode.Bounds.Y));

            AllDevice.Add(device);
            //ShapeNode node = diagram1.Factory.CreateShapeNode(20, 20, 40, 40);
            //node.Id = "Role bao ve dien ap";
            //node.Image = Properties.Resources._18_role_bao_ve_dien_ap;
            //node.Transparent = true;
            //node.ImageAlign = MindFusion.Drawing.ImageAlign.Fit;
        }

        private void button18_Click_1(object sender, EventArgs e)
        {
            Device device = new Device(11);
            ShapeNode node = diagram1.Factory.CreateShapeNode(10, 10, 40, 40);

            device.SetNode(node);

            countDevice += 1;
            node.Id = "" + countDevice;
            node.Image = Properties.Resources._10_NutAnXanhNho;
            node.Transparent = true;
            node.ImageAlign = MindFusion.Drawing.ImageAlign.Fit;


            device.PortCount = 2;
            device.port.Add(new PointF(0 * device.shapenode.Bounds.Width + device.shapenode.Bounds.X,
                0.4f * device.shapenode.Bounds.Height + device.shapenode.Bounds.Y));
            device.port.Add(new PointF(0 * device.shapenode.Bounds.Width + device.shapenode.Bounds.X,
                0.6f * device.shapenode.Bounds.Height + device.shapenode.Bounds.Y));

            AllDevice.Add(device);
            //ShapeNode node = diagram1.Factory.CreateShapeNode(20, 20, 40, 40);
            //node.Id = "Role bao ve dien ap";
            //node.Image = Properties.Resources._18_role_bao_ve_dien_ap;
            //node.Transparent = true;
            //node.ImageAlign = MindFusion.Drawing.ImageAlign.Fit;
        }
        private void button17_Click(object sender, EventArgs e)
        {
            Device device = new Device(12);
            ShapeNode node = diagram1.Factory.CreateShapeNode(10, 10, 40, 40);

            device.SetNode(node);

            countDevice += 1;
            node.Id = "" + countDevice;
            node.Image = Properties.Resources._11_NutAnDoKhongNho;
            node.Transparent = true;
            node.ImageAlign = MindFusion.Drawing.ImageAlign.Fit;


            device.PortCount = 2;
            device.port.Add(new PointF(0.4f * device.shapenode.Bounds.Width + device.shapenode.Bounds.X,
                1 * device.shapenode.Bounds.Height + device.shapenode.Bounds.Y));
            device.port.Add(new PointF(0.6f * device.shapenode.Bounds.Width + device.shapenode.Bounds.X,
                1 * device.shapenode.Bounds.Height + device.shapenode.Bounds.Y));

            AllDevice.Add(device);
            //ShapeNode node = diagram1.Factory.CreateShapeNode(20, 20, 40, 40);
            //node.Id = "Role bao ve dien ap";
            //node.Image = Properties.Resources._18_role_bao_ve_dien_ap;
            //node.Transparent = true;
            //node.ImageAlign = MindFusion.Drawing.ImageAlign.Fit; 
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Device device = new Device(13);
            ShapeNode node = diagram1.Factory.CreateShapeNode(10, 10, 40, 40);

            device.SetNode(node);

            countDevice += 1;
            node.Id = "" + countDevice;
            node.Image = Properties.Resources._12_NutAnDoNho;
            node.Transparent = true;
            node.ImageAlign = MindFusion.Drawing.ImageAlign.Fit;


            device.PortCount = 2;
            device.port.Add(new PointF(0.4f * device.shapenode.Bounds.Width + device.shapenode.Bounds.X,
                1 * device.shapenode.Bounds.Height + device.shapenode.Bounds.Y));
            device.port.Add(new PointF(0.6f * device.shapenode.Bounds.Width + device.shapenode.Bounds.X,
                1 * device.shapenode.Bounds.Height + device.shapenode.Bounds.Y));

            AllDevice.Add(device);
            //ShapeNode node = diagram1.Factory.CreateShapeNode(20, 20, 40, 40);
            //node.Id = "Role bao ve dien ap";
            //node.Image = Properties.Resources._18_role_bao_ve_dien_ap;
            //node.Transparent = true;
            //node.ImageAlign = MindFusion.Drawing.ImageAlign.Fit;
        }

        #endregion

        #endregion


        #region properties

        //ZOOM IN ZOOM OUT
        private void btn_ZoomOut_Click(object sender, EventArgs e)
        {
            float zoom = diagramView1.ZoomFactor;
            if (zoom < 500)
            {
                zoom += 25;
                diagramView1.ZoomFactor = zoom;
                labelZoom.Text = zoom + "%";
            }
            else return;

        }

        private void btn_ZoomIn_Click(object sender, EventArgs e)
        {
            float zoom = diagramView1.ZoomFactor;
            if (zoom > 25)
            {
                zoom -= 25;
                diagramView1.ZoomFactor = zoom;
                labelZoom.Text = zoom + "%";
            }
            else return;
        }

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
                    if (comboBox2.SelectedIndex == 2)
                    {
                        ListItemDiagram[0].Pen = new MindFusion.Drawing.Pen(Color.Yellow, Convert.ToInt32(TextboxWidth.Text));
                    }
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
                        if (TextboxWidth.Text != null)
                        {
                            TextboxWidth.Text = ListItemDiagram[0].Pen.Width.ToString();
                        }
                        

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
           

        }

        private void panel_Thuchanh_Paint(object sender, PaintEventArgs e)
        {

        }

        #region Save
        private void btn_Export_Click(object sender, EventArgs e)
        {
            //unselected node
            diagram1.Selection.Items.ToList().ForEach(num => num.Selected = false);
            //save 
            saveFileDialog1.DefaultExt = "png";
            saveFileDialog1.Filter = "PNG files|*.png";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Image image = diagram1.CreateImage();
                image.Save(saveFileDialog1.FileName);
                image.Dispose();
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            this.saveFileDialog2.DefaultExt = "elec";
            this.saveFileDialog2.FileName = "Flowchart";
            this.saveFileDialog2.Filter = "Electric documents|*.elec|All files|*.*";
            this.saveFileDialog2.Title = "Save document";

            if (saveFileDialog2.ShowDialog(this) == DialogResult.OK)
            {
                diagram1.SaveToFile(saveFileDialog2.FileName, true);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    diagram1.LoadFromFile(openFileDialog1.FileName);

                    this.tb_NameDocument.Text = "Name : ";
                    //this.tb_NameDocument.Text += openFileDialog1.FileName;


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
                catch
                {
                    MessageBox.Show(this, "Không mở được định dạng này!");
                }
            }
        }

        private void btn_Grid_Click(object sender, EventArgs e)
        {


            diagram1.EnableLanes = !diagram1.EnableLanes;
            Grid grid = diagram1.LaneGrid;
            grid.RowCount = 400;
            grid.ColumnCount = 400;
            grid.HookHeaders = false;
            grid.HeadersOnTop = false;

        }

        #endregion


        List<Device> AllDevice = new List<Device>();

        public Device FindDevice(DiagramNode node)
        {
            foreach (var item in AllDevice)
            {
                if (item.shapenode.Id == node.Id)
                {
                    return item;
                }

            }
            return null;


        }

        private double GetDistance(PointF point1, PointF point2)
        {
            return Math.Sqrt(Math.Pow((point2.X - point1.X), 2) + Math.Pow((point2.Y - point1.Y), 2));
        }

        private void diagram1_LinkRouted(object sender, LinkEventArgs e)
        {

        }



        private void diagram1_LinkCreating(object sender, LinkValidationEventArgs e)
        {
            e.Link.Pen(new MindFusion.Drawing.Pen(Color.Red, 2));

        }

        private void diagram1_LinkCreated(object sender, LinkEventArgs e)
        {
            //tim kiem device goc
            Device origin = FindDevice(e.Link.Origin);
            Device destination = FindDevice(e.Link.Destination);

            // tim kiem diem port 
            //port origin
            PointF portOrigin = origin.port[0];
            double distanceOrigin = GetDistance(e.Link.StartPoint, portOrigin);
            for (int i = 1; i < origin.PortCount; i++)
            {
                if (distanceOrigin> GetDistance(portOrigin,origin.port[i]))
                {
                    portOrigin = origin.port[i];
                    distanceOrigin = GetDistance(portOrigin, origin.port[i]);
                }
            }
            if (distanceOrigin<20)
            {
                e.Link.StartPoint = portOrigin;
            }


            //port destination

            PointF portDestination = destination.port[0];
            double distanceDestination = GetDistance(e.Link.EndPoint, portDestination);
            for (int i = 1; i < destination.PortCount; i++)
            {
                if (distanceDestination > GetDistance(portDestination, destination.port[i]))
                {
                    portDestination = destination.port[i];
                    distanceDestination = GetDistance(portDestination, destination.port[i]);
                }
            }
            if (distanceDestination < 20)
            {
                e.Link.EndPoint = portDestination;
                e.Link.AutoRoute = true;
            }


        }




        public ShapeNode portNode;        
        /// <summary>
        /// Khi chuột rê đến một node, phát hiện có rê vào cổng - port của node đó hay không
        /// nếu rê vào thì hiển thị hình tròn tại port đó
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        DiagramLink link;
        int createLink = 0;

        private void diagramView1_MouseMove(object sender, MouseEventArgs e)
        {
            //MessageBox.Show("asdf");
            if (createLink == 1)
            {
                //link.EndPoint(new PointF(e.X, e.Y));
                
            }
          
        }

        private void diagram1_LinkSplit(object sender, LinkEventArgs e)
        {
           


        }
        public PointF SubPointF(PointF p1,PointF p2)
        {
            return new PointF(p1.X - p2.X, p1.Y - p2.Y);
        }
        public PointF TotalPointF(PointF p1, PointF p2)
        {
            return new PointF(p1.X + p2.X, p1.Y + p2.Y);
            
           
        }


        private void diagram1_NodeModified(object sender, NodeEventArgs e)
        {
            Device device = FindDevice(e.Node);
            //cap nhat lai cac port 
            for (int i = 0; i < device.PortCount; i++)
            {
                PointF SubPoint = SubPointF(new PointF(e.Node.Bounds.X, e.Node.Bounds.Y), device.prePos);
                device.port[i] = TotalPointF(device.port[i], SubPoint);
            }
            device.prePos = new PointF(e.Node.Bounds.X, e.Node.Bounds.Y);
        }

        private void diagram1_LinkModified(object sender, LinkEventArgs e)
        {
            //tim kiem device goc
            Device origin = FindDevice(e.Link.Origin);
            Device destination = FindDevice(e.Link.Destination);

            // tim kiem diem port 
            //port origin
            PointF portOrigin = origin.port[0];
            double distanceOrigin = GetDistance(e.Link.StartPoint, portOrigin);
            for (int i = 1; i < origin.PortCount; i++)
            {
                if (distanceOrigin > GetDistance(portOrigin, origin.port[i]))
                {
                    portOrigin = origin.port[i];
                    distanceOrigin = GetDistance(portOrigin, origin.port[i]);
                }
            }
            if (distanceOrigin < 20)
            {
                e.Link.StartPoint = portOrigin;
            }


            //port destination

            PointF portDestination = destination.port[0];
            double distanceDestination = GetDistance(e.Link.EndPoint, portDestination);
            for (int i = 1; i < destination.PortCount; i++)
            {
                if (distanceDestination > GetDistance(portDestination, destination.port[i]))
                {
                    portDestination = destination.port[i];
                    distanceDestination = GetDistance(portDestination, destination.port[i]);
                }
            }
            if (distanceDestination < 20)
            {
                e.Link.EndPoint = portDestination;
                e.Link.AutoRoute = true;
            }
            

        }

        private void buttonUndo_Click(object sender, EventArgs e)
        {
           
            diagram1.UndoManager.Undo();
            
        }

        private void buttonRedo_Click(object sender, EventArgs e)
        {
            diagram1.UndoManager.Redo();
        }

        
    }
}
