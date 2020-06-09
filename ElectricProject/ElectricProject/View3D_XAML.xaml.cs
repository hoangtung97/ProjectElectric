using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Media3D;
using HelixToolkit.Wpf;
using ElectricProject;
using System.IO;

namespace ElectricProject
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class View3D_XAML : UserControl
    {
        public string MODEL_PATH = Environment.CurrentDirectory + "\\3DResource\\";

        public View3D_XAML()
        {

            //MODEL_PATH = Environment.CurrentDirectory + "\\3DResource\\May-Bien-Ap-1-Pha.obj";
            InitializeComponent();
            //ModelVisual3D device3D = new ModelVisual3D();
            //device3D.Content = Display3d(MODEL_PATH);

            //// Add to view port

            //viewPort3d.Children.Add(device3D);
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }
        //public View3D_XAML(String name)
        //{
        //    MODEL_PATH += name;
        //    InitializeComponent();
        //    ModelVisual3D device3D = new ModelVisual3D();
        //    device3D.Content = Display3d(MODEL_PATH);

        //    // Add to view port

        //    viewPort3d.Children.Add(device3D);
        //}

        //    private void Load3dFile(object sender, EventArgs e)
        //    {

        //    }

        //    public void SetPath(String name)
        //    {
        //        MODEL_PATH += name;
        //    }

        //    /// <summary>
        //    /// Display 3D Model
        //    /// </summary>
        //    /// <param name="model">Path to the Model file</param>
        //    /// <returns>3D Model Content</returns>
        //    public Model3D Display3d(string model)
        //    {
        //        Model3D device = null;
        //        try
        //        {
        //            //Adding a gesture here

        //            viewPort3d.RotateGesture = new MouseGesture(MouseAction.LeftClick);

        //            //Import 3D model file
        //            ModelImporter import = new ModelImporter();

        //            //Load the 3D model file
        //            device = import.Load(model);
        //        }
        //        catch (Exception e)
        //        {
        //            // Handle exception in case can not file 3D model

        //        }
        //        return device;

        //    }
        //}
    }
}
