using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Surface;
using Microsoft.Surface.Presentation;
using Microsoft.Surface.Presentation.Controls;
using Microsoft.Surface.Presentation.Input;

namespace CameraVisualizations
{
    /// <summary>
    /// Interaction logic for CameraVisualization.xaml
    /// </summary>
    public partial class CameraVisualization : TagVisualization
    {
        public CameraVisualization()
        {
            InitializeComponent();
        }

        private void CameraVisualization_Loaded(object sender, RoutedEventArgs e)
        {
            //TODO: customize CameraVisualization's UI based on this.VisualizedTag here
        }
        private void OnVisualizationAdded(object sender, TagVisualizerEventArgs e)
        {
            CameraVisualization camera = (CameraVisualization)e.TagVisualization;
            switch (camera.VisualizedTag.Value)
            {
                case 1:
                    camera.CameraModel.Content = "Fabrikam, Inc. ABC-12";
                    camera.myEllipse.Fill = SurfaceColors.Accent1Brush;
                    break;
                case 2:
                    camera.CameraModel.Content = "Fabrikam, Inc. DEF-34";
                    camera.myEllipse.Fill = SurfaceColors.Accent2Brush;
                    break;
                case 3:
                    camera.CameraModel.Content = "Fabrikam, Inc. GHI-56";
                    camera.myEllipse.Fill = SurfaceColors.Accent3Brush;
                    break;
                case 4:
                    camera.CameraModel.Content = "Fabrikam, Inc. JKL-78";
                    camera.myEllipse.Fill = SurfaceColors.Accent4Brush;
                    break;
                default:
                    camera.CameraModel.Content = "UNKNOWN MODEL";
                    camera.myEllipse.Fill = SurfaceColors.ControlAccentBrush;
                    break;
            }
        }
    }
}
