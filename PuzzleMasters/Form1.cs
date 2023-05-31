using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Drawing.Imaging;
using System.Collections;

namespace PuzzleMasters
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Global Variable Declaration

        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice;
        Bitmap bitmapImage;
        int count = 0;

        //Starts the Video Captur Device

        private void btnStart_Click(object sender, EventArgs e)
        {
            videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[cboCamera.SelectedIndex].MonikerString);
            videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            videoCaptureDevice.Start();
        }

        //Gets the image from the camera.

        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            bitmapImage=(Bitmap)eventArgs.Frame.Clone();
            pictureBox1.Image = bitmapImage;
        }

        //Initialised Combo Box and fills in all available cameras.

        private void Form1_Load(object sender, EventArgs e)
        {
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo Device in filterInfoCollection)
            cboCamera.Items.Add(Device.Name);
            cboCamera.SelectedIndex = 0;
            videoCaptureDevice = new VideoCaptureDevice();
        }

        //Disposes of camera when form closes

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videoCaptureDevice.IsRunning == true)
            {
                videoCaptureDevice.Stop();
            }
        }

        //Capture Function

        private void btnCapture_Click(object sender, EventArgs e)
        {
            
            
            if (pictureBox1.Image != null)
            {
                count++;
                if (count == 6)
                {
                    solveButton.Visible = true;
                    textBox1.Text = "All photos have now been taken, please press Solve to solve the cube";
                }

                Bitmap currentImage = (Bitmap)bitmapImage.Clone();
                string filePath = @"C:\PuzzleMasters\Images\";
                string fileName = "Image" + count + ".bmp";

                currentImage.Save(filePath + fileName);
                currentImage.Dispose();


            }
            else
            { MessageBox.Show("null exception"); }

            
            if (count == 1)
            {
                textBox1.Text = "Take a photograph of the Orange face, with the white face positioned on top";
            }
            if (count == 2)
            {
                textBox1.Text = "Take a photograph of the Green face, with the white face positioned on top";
            }
            if (count == 3)
            {
                textBox1.Text = "Take a photograph of the Red face, with the white face positioned on top";
            }
            if (count == 4)
            {
                textBox1.Text = "Take a photograph of the White face, with the Red face positioned on top";
            }
            if (count == 5)
            {
                textBox1.Text = "Take a photograph of the Yellow face, with the Orange face positioned ON TOP";
            }
            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        public void button1_Click(object sender, EventArgs e)
        {
            Class1 c = new Class1();
            RubiksCube cube1 = c.returnCube();

            printCube(cube1);

            outputBox.Visible = true;
        }

        private void solveButton_Click(object sender, EventArgs e)
        {
            Class1 c = new Class1();
            RubiksCube cube1 = c.returnCube();

            printCube(cube1);
            outputBox.Visible = true;
        }

        public void printCube(RubiksCube cube1)
        {
            ArrayList cubeCommands = cube1.returnCommands();
            int hashCount = 0;
            foreach (String item in cubeCommands)
            {
                if (item.Equals("#"))
                {
                    hashCount++;
                    switch (hashCount)
                    {
                        case 1:
                            outputBox.AppendText("Starting with the Orange face towards you and the White face facing upwards... \r\n \r\n");
                            outputBox.AppendText("White Cross Instructions... \r\n");
                            outputBox.AppendText("---------------------------------------------------- \r\n");
                            break;
                        case 2:
                            outputBox.AppendText("\r\n---------------------------------------------------- \r\n");
                            outputBox.AppendText("White Corners Instructions... \r\n");
                            outputBox.AppendText("---------------------------------------------------- \r\n");
                            break;
                        case 3:
                            outputBox.AppendText("\r\n---------------------------------------------------- \r\n");
                            outputBox.AppendText("Second Layer Instructions... \r\n");
                            outputBox.AppendText("---------------------------------------------------- \r\n");
                            break;
                        case 4:
                            outputBox.AppendText("\r\n---------------------------------------------------- \r\n");
                            outputBox.AppendText("Yellow Cross Instructions... \r\n");
                            outputBox.AppendText("---------------------------------------------------- \r\n");
                            break;
                        case 5:
                            outputBox.AppendText("\r\n---------------------------------------------------- \r\n");
                            outputBox.AppendText("Yellow Corners Instructions... \r\n");
                            outputBox.AppendText("---------------------------------------------------- \r\n");
                            break;
                        case 6:
                            outputBox.AppendText("\r\n---------------------------------------------------- \r\n");
                            outputBox.AppendText("Congratulations! Cube Complete! \r\n");
                            outputBox.AppendText("---------------------------------------------------- \r\n");
                            break;

                    }
                }
                else if (item.Equals("##"))
                {
                    outputBox.AppendText("Unable to fully complete cube - partial instructions are above");
                }
                else
                {
                    outputBox.AppendText(item + ", ");
                }

            }
        }
    }
}
