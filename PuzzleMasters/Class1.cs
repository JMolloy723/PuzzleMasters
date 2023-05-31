using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleMasters
{
    class Class1
    {
        RubiksCube cubez;
        public Class1()
        {
            int count = 0;

            //will start with 6 photographs given by front end
            Bitmap img1 = new Bitmap("C:\\University\\3rd Year\\cube_photos\\blue.png");
            Bitmap img2 = new Bitmap("C:\\University\\3rd Year\\cube_photos\\orange.png");
            Bitmap img3 = new Bitmap("C:\\University\\3rd Year\\cube_photos\\green.png");
            Bitmap img4 = new Bitmap("C:\\University\\3rd Year\\cube_photos\\red.png");
            Bitmap img5 = new Bitmap("C:\\University\\3rd Year\\cube_photos\\white.png");
            Bitmap img6 = new Bitmap("C:\\University\\3rd Year\\cube_photos\\yellow.png");

            //Bitmap img1 = new Bitmap("C:\\PuzzleMasters\\Images\\Image1.bmp");
            //Bitmap img2 = new Bitmap("C:\\PuzzleMasters\\Images\\Image2.bmp");
            //Bitmap img3 = new Bitmap("C:\\PuzzleMasters\\Images\\Image3.bmp");
            //Bitmap img4 = new Bitmap("C:\\PuzzleMasters\\Images\\Image4.bmp");
            //Bitmap img5 = new Bitmap("C:\\PuzzleMasters\\Images\\Image5.bmp");
            //Bitmap img6 = new Bitmap("C:\\PuzzleMasters\\Images\\Image6.bmp");



            /*img1 = cropImage2(img1);
            img2 = cropImage2(img2);
            img3 = cropImage2(img3);
            img4 = cropImage2(img4);
            img5 = cropImage2(img5);
            img6 = cropImage2(img6);*/

            img1 = resizeImage(img1);
            img2 = resizeImage(img2);
            img3 = resizeImage(img3);
            img4 = resizeImage(img4);
            img5 = resizeImage(img5);
            img6 = resizeImage(img6);

            Bitmap[] cubeSides = new Bitmap[] { img1, img2, img3, img4, img5, img6 };

            img1.Save("C:\\PuzzleMasters\\Images\\Image1.png");
            img2.Save("C:\\PuzzleMasters\\Images\\Image2.png");
            img3.Save("C:\\PuzzleMasters\\Images\\Image3.png");
            img4.Save("C:\\PuzzleMasters\\Images\\Image4.png");
            img5.Save("C:\\PuzzleMasters\\Images\\Image5.png");
            img6.Save("C:\\PuzzleMasters\\Images\\Image6.png");

            GetCubeSides cubey = new GetCubeSides(cubeSides);


            int[,] blue = cubey.getFaceColours(img1);
            int[,] orange = cubey.getFaceColours(img2);
            int[,] green = cubey.getFaceColours(img3);
            int[,] red = cubey.getFaceColours(img4);
            int[,] white = cubey.getFaceColours(img5);
            int[,] yellow = cubey.getFaceColours(img6);

            RubiksCube cube1 = new RubiksCube(orange, green, red, blue, white, yellow);

            //cube1.printCube();

            cube1.parseCommand("Y");
            
            //cube1.printCube();

            //    int zzz = testCube(cube1);

            SolveCube cubeSolver = new SolveCube(cube1);

            cube1.printCube();

            cubez = cube1;
            
        }


        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>

       /* private static Image cropImage(Image img)
        {

            int xCoord = (img.Width - 200)/2;
            int yCoord = (img.Height - 200)/2;

            Rectangle cropRect = new Rectangle(xCoord, yCoord, 200, 200);
            Bitmap src = img as Bitmap;
            Bitmap target = new Bitmap(cropRect.Width, cropRect.Height);

            using (Graphics g = Graphics.FromImage(target))
            {
                g.DrawImage(src, new Rectangle(xCoord, yCoord, target.Width, target.Height), cropRect, GraphicsUnit.Pixel);
            }
        }*/

        private static Bitmap cropImage2(Bitmap bmpImage)
        {
            int xCoord = (bmpImage.Width - 200) / 2;
            int yCoord = (bmpImage.Height - 200) / 2;
            Rectangle cropArea = new Rectangle(xCoord, yCoord, 200, 200);
            
            return bmpImage.Clone(cropArea, bmpImage.PixelFormat);
        }

        public static Bitmap resizeImage(Image imgToResize)
        {
            return new Bitmap(imgToResize, new Size(600, 600));
        }

        public static int testCube(RubiksCube cube1)
        {
            Bitmap img1 = new Bitmap("C:\\University\\cube_photos\\blue.png");
            Bitmap img2 = new Bitmap("C:\\University\\cube_photos\\orange.png");
            Bitmap img3 = new Bitmap("C:\\University\\cube_photos\\green.png");
            Bitmap img4 = new Bitmap("C:\\University\\cube_photos\\red.png");
            Bitmap img5 = new Bitmap("C:\\University\\cube_photos\\white.png");
            Bitmap img6 = new Bitmap("C:\\University\\cube_photos\\yellow.png");


            Bitmap[] cubeSides = new Bitmap[] { img1, img2, img3, img4, img5, img6 };

            img1 = resizeImage(img1);
            img2 = resizeImage(img2);
            img3 = resizeImage(img3);
            img4 = resizeImage(img4);
            img5 = resizeImage(img5);
            img6 = resizeImage(img6);

            GetCubeSides cubey = new GetCubeSides(cubeSides);


            int[,] blue = cubey.getFaceColours(img1);
            int[,] orange = cubey.getFaceColours(img2);
            int[,] green = cubey.getFaceColours(img3);
            int[,] red = cubey.getFaceColours(img4);
            int[,] white = cubey.getFaceColours(img5);
            int[,] yellow = cubey.getFaceColours(img6);

            RubiksCube cube2 = new RubiksCube(orange, blue, red, green, yellow, white);

            /*      //  cube2.printCube();
                    cube2.parseCommand("L");
                   // cube2.printCube();
                    cube2.parseCommand("L'");
                    //cube2.printCube();

                    cube2.parseCommand("F");
        //            cube2.printCube();
                    cube2.parseCommand("F'");
          //          cube2.printCube();

                    cube2.parseCommand("R");
            //        cube2.printCube();
                    cube2.parseCommand("R'");
              //      cube2.printCube();

                    cube2.parseCommand("B");
                //    cube2.printCube();
                    cube2.parseCommand("B'");
                  //  cube2.printCube();

                    cube2.parseCommand("U");
         //           cube2.printCube();
                    cube2.parseCommand("U'");
           //         cube2.printCube();

                    cube2.parseCommand("D");
        //            cube2.printCube();
                    cube2.parseCommand("D'");
         //           cube2.printCube();
            */
            cube1.printCube();
            cube1.parseCommand("L");
            //          cube1.printCube();
            cube1.parseCommand("L'");
            cube1.printCube();

            cube1.parseCommand("F");
            // cube1.printCube();
            cube1.parseCommand("F'");
            cube1.printCube();

            cube1.parseCommand("R");
            //        cube1.printCube();
            cube1.parseCommand("R'");
            cube1.printCube();

            cube1.parseCommand("B");
            cube1.printCube();
            cube1.parseCommand("B'");
            cube1.printCube();

            cube1.parseCommand("U");
            //     cube1.printCube();
            cube1.parseCommand("U'");
            cube1.printCube();

            cube1.parseCommand("D");
            //        cube1.printCube();
            cube1.parseCommand("D'");
            cube1.printCube();

            cube1.parseCommand("X X X X");
            cube1.printCube();

            return 1;
        }

        public RubiksCube returnCube()
        {
            return cubez;
        }
    }


}

