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

        private void button53_Click(object sender, EventArgs e)
        {
            new View3DForm().Show();
        }

        private void button71_Click(object sender, EventArgs e)
        {
            new View3DForm().Show();
        }


        #region thuc hanh
        private void button7_Click(object sender, EventArgs e)
        {
            ShapeNode node = diagram1.Factory.CreateShapeNode(10, 10, 20, 20);
            node.Id = "Cau dao thuong";            
            node.Image = Properties.Resources._7_Cau_dao_1_pha;
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
    }
}
