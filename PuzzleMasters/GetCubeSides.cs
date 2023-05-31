using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleMasters
{
    class GetCubeSides
    {
        Color[] colours = new Color[6];
        int colourCount = 0;

        public GetCubeSides(Bitmap[] img)
        {
            recordColours(img);
        }

        /// <summary>
        /// Retrieves the colours of the Rubik's Cube face from an image.
        /// </summary>
        /// <param name="img">The image of the Rubik's Cube face.</param>
        /// <returns>A 2D array representing the colours of the face.</returns>
        public int[,] getFaceColours(Bitmap img)
        {
            // The increment value for iterating over the image pixels
            int incrementValue = 200;

            // Variables for tracking the position within the faceColours array
            int x = 0;
            int y = 0;

            // Boolean flag indicating if the colours are close to any predefined Rubik's Cube colours
            bool closeColours = false;

            // 2D array to store the face colours
            int[,] faceColours = new int[3, 3];

            // Iterating over the image pixels
            for (int i = 100; i < img.Height; i = i + incrementValue)
            {
                for (int j = 100; j < img.Width; j = j + incrementValue)
                {
                    // Get the colour of the current pixel
                    Color pixel = img.GetPixel(i, j);

                    // Checking if the pixel colour is close to any predefined Rubik's Cube colours
                    for (int a = 0; a <= colourCount; a++)
                    {
                        if (ColoursAreClose(pixel, colours[a]))
                        {
                            // Assigning the corresponding colour index to the faceColours array
                            faceColours[y, x] = a + 1;
                            closeColours = true;
                        }
                    }

                    // If the pixel colour is not close to any predefined colours, assign a new colour index
                    if (closeColours == false)
                    {
                        faceColours[y, x] = (Array.FindIndex(colours, colour => colour == pixel)) + 1;

                        // Increment the colourCount if it's not at its maximum value
                        if (colourCount != 5)
                        {
                            colourCount++;
                        }
                    }

                    // Update the position within the faceColours array
                    y++;
                    closeColours = false;
                }

                x++;
                y = 0;
            }

            return faceColours;
        }
        bool ColoursAreClose(Color a, Color z, int threshold = 70)
        {
            int r = (int)a.R - z.R,
                g = (int)a.G - z.G,
                b = (int)a.B - z.B;
            return (r * r + g * g + b * b) <= threshold * threshold;
        }

        /// <summary>
        /// Records all of the colours present in the current photo of the cube.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        void recordColours(Bitmap[] cubeSides)
        {

            foreach (Bitmap img in cubeSides)
            {
                Color pixel = img.GetPixel(300, 300);
                colours[colourCount] = pixel;
                colourCount++;
            }
            colourCount = 5;
        }

        /// <summary>
        /// Gets the average color of a square on a Rubik's Cube side.
        /// </summary>
        /// <param name="img">The image of the Rubik's Cube side.</param>
        /// <param name="i">The X coordinate of the square.</param>
        /// <param name="j">The Y coordinate of the square.</param>
        /// <returns>The average color of the square.</returns>
        Color getAveragePixel(Bitmap img, int i, int j)
        {
            Color pixel1 = img.GetPixel(i, j);
            Color pixel2 = img.GetPixel(i - 25, j - 25);
            Color pixel3 = img.GetPixel(i - 25, j + 25);
            Color pixel4 = img.GetPixel(i + 25, j - 25);
            Color pixel5 = img.GetPixel(i + 25, j + 25);

            int rVal = (pixel1.R + pixel2.R + pixel3.R + pixel4.R + pixel5.R) / 5;
            int gVal = (pixel1.G + pixel2.G + pixel3.G + pixel4.G + pixel5.G) / 5;
            int bVal = (pixel1.B + pixel2.B + pixel3.B + pixel4.B + pixel5.B) / 5;

            

            Color pixel = Color.FromArgb(rVal, gVal, bVal);

            return pixel;

        }
    }
}
