using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
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
using System.Diagnostics;

namespace CameraVisualizations
{
    /// <summary>
    /// Interaction logic for SurfaceWindow1.xaml
    /// </summary>
    public partial class SurfaceWindow1 : SurfaceWindow
    {
        List<Steps> stepList;
        int currentStepNum;
        int maxStepNum;
        bool[] aufTisch;
        /// <summary>
        /// Default constructor.
        /// </summary>
        public SurfaceWindow1()
        {
            InitializeComponent();
            // Add handlers for window availability events
            AddWindowAvailabilityHandlers();
            stepList = new List<Steps>();
            currentStepNum = 0;
            aufTisch = new bool[256];
            maxStepNum = 0;
            initUI();
        }

        private void initUI()
        {
            initArbeitsschritte();
            StreamReader sr = new StreamReader(@"C:\Users\Philipp-VM\Documents\GitHub\FS_MMI_15_16\LekkerFutter\v2\CameraVisualizations\CameraVisualizations\Resources\tomatensuppe.txt");
            int i = 0;
            while (!sr.EndOfStream)
            {
                String line = sr.ReadLine();
                Label tmp = new Label();
                if (i == 0)
                {
                    Thickness th = tmp.Margin;
                    th.Top = 15;
                    tmp.Margin = th;
                }
                tmp.Content = line;
                tmp.Name = "zutat_" + i.ToString();
                tmp.Height = 30;
                tmp.Width = 200;

                i++;

                zutatenStack.Children.Add(tmp);
            }
            sr.Close();
            sr.Dispose();

            zutatenStack.Height = 400 + i * 40;
        }

        private void initArbeitsschritte()
        {
            StreamReader sr = new StreamReader(@"C:\Users\Philipp-VM\Documents\GitHub\FS_MMI_15_16\LekkerFutter\v2\CameraVisualizations\CameraVisualizations\Resources\arbeitsschritte.txt");
            
            while (!sr.EndOfStream)
            {
                String line = sr.ReadLine();
                String[] s = line.Split(';');
                Steps steps = new Steps(s[0], s[1]);//line.Trim(';').ToString(), line.Trim(';').ToString());
                stepList.Add(steps);
                maxStepNum++;
            }
            sr.Close();
            sr.Dispose();

            setStep(currentStepNum);
        }

        private void setStep(int stepNum)
        {
            asheading.Content = stepList[stepNum].head;
            ascontent.Text = stepList[stepNum].text;
            //niceLine(0,0);
            
        }

        private void niceLine(int x1, int y1)
        {
            foreach (UIElement ue in asd.Children)
            {
                if (ue.Uid == "penis")
                {
                    asd.Children.Remove(ue);
                    break;
                }
            }
            Line line = new Line();
            line.Uid = "penis";
            line.Name = "irgendwas";
            Thickness th = new Thickness(1,1,1,1);
            line.Margin = th;
            line.Visibility = System.Windows.Visibility.Visible;
            line.StrokeThickness = 5;
            line.Stroke = System.Windows.Media.Brushes.Aqua;
            switch (currentStepNum)
            {
                case 0:
                    if (aufTisch[2] && asd.FindName("irgendwas") != null)
                    {
                        line.X1 = x1 + 250;
                        line.Y1 = y1 + 250;
                    }
                    
                    break;
                default:
                    break;
            }
            line.X2 = 960;
            line.Y2 = 900;
            Debug.WriteLine(x1 + " " + " " + y1);
            asd.Children.Add(line);
            asd.InvalidateVisual();
        }

        /// <summary>
        /// Occurs when the window is about to close. 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            // Remove handlers for window availability events
            RemoveWindowAvailabilityHandlers();
        }

        /// <summary>
        /// Adds handlers for window availability events.
        /// </summary>
        private void AddWindowAvailabilityHandlers()
        {
            // Subscribe to surface window availability events
            ApplicationServices.WindowInteractive += OnWindowInteractive;
            ApplicationServices.WindowNoninteractive += OnWindowNoninteractive;
            ApplicationServices.WindowUnavailable += OnWindowUnavailable;
        }

        /// <summary>
        /// Removes handlers for window availability events.
        /// </summary>
        private void RemoveWindowAvailabilityHandlers()
        {
            // Unsubscribe from surface window availability events
            ApplicationServices.WindowInteractive -= OnWindowInteractive;
            ApplicationServices.WindowNoninteractive -= OnWindowNoninteractive;
            ApplicationServices.WindowUnavailable -= OnWindowUnavailable;
        }

        /// <summary>
        /// This is called when the user can interact with the application's window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowInteractive(object sender, EventArgs e)
        {
            //TODO: enable audio, animations here
        }

        /// <summary>
        /// This is called when the user can see but not interact with the application's window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowNoninteractive(object sender, EventArgs e)
        {
            //TODO: Disable audio here if it is enabled

            //TODO: optionally enable animations here
        }

        /// <summary>
        /// This is called when the application's window is not visible or interactive.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowUnavailable(object sender, EventArgs e)
        {
            //TODO: disable audio, animations here
        }
        private void OnVisualizationAdded(object sender, TagVisualizerEventArgs e)
        {
            CameraVisualization camera = (CameraVisualization)e.TagVisualization;
            
            switch (camera.VisualizedTag.Value)
            {
                case 1:
                    camera.tomaten.Visibility = System.Windows.Visibility.Visible;
                    aufTisch[1] = true;                    
                    break;
                case 2:
                    camera.zwiebeln.Visibility = System.Windows.Visibility.Visible;
                    aufTisch[2] = true;
                    break;
                case 3:
                    //camera.CameraModel.Content = "Olivenöl";
                    break;
                case 4:
                    //camera.CameraModel.Content = "Frisches Basilikum";
                    break;
                case 5:
                    //camera.CameraModel.Content = "Creme Fraiche";
                    break;
                default:
                    //camera.CameraModel.Content = "Unbekannte Zutat";
                    break;
            }
            Point rp = camera.TranslatePoint(new Point(0, 0), this);
            niceLine((int)rp.X, (int)rp.Y);
        }

        private void Image_TouchUp(object sender, TouchEventArgs e)
        {
            if (currentStepNum < maxStepNum)
            {
                setStep(currentStepNum++);
            }
            
        }

        private void MyTagVisualizer_VisualizationMoved(object sender, TagVisualizerEventArgs e)
        {
            CameraVisualization camera = (CameraVisualization)e.TagVisualization;
            Point rp = camera.TranslatePoint(new Point(0,0), this);
            niceLine((int)rp.X, (int)rp.Y);
        }

        private void MyTagVisualizer_VisualizationRemoved(object sender, TagVisualizerEventArgs e)
        {
            CameraVisualization camera = (CameraVisualization)e.TagVisualization;

            switch (camera.VisualizedTag.Value)
            {
                case 1:
                    aufTisch[1] = false;
                    break;
                case 2:
                    aufTisch[2] = false;
                    break;
                case 3:
                    //camera.CameraModel.Content = "Olivenöl";
                    break;
                case 4:
                    //camera.CameraModel.Content = "Frisches Basilikum";
                    break;
                case 5:
                    //camera.CameraModel.Content = "Creme Fraiche";
                    break;
                default:
                    //camera.CameraModel.Content = "Unbekannte Zutat";
                    break;
            }
            foreach (UIElement ue in asd.Children)
            {
                if (ue.Uid == "penis")
                {
                    asd.Children.Remove(ue);
                    break;
                }
            }

        }


    }
}