using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleMasters
{
    class SolveCube
    {
        RubiksCube cube1;
        bool whiteCrossComplete = false;
        bool ableToComplete = true;

        /* public SolveCube(RubiksCube fullCube) - The method in which all methods involved with the steps in solving the cube are called sequentially
                                                   based on the current completion stage of the cube
        RubiksCube fullCube - The virtual representation of the Rubik's cube supplied by the user */
        public SolveCube(RubiksCube fullCube)
        {
            
            cube1 = fullCube;

            cube1.printCube();

            if (ableToComplete)
            {
                whiteCross();
                Console.WriteLine("White Cross Complete!");
                cube1.printCube();

                ableToComplete = cube1.parseCommand("#");
            }
            else
            {
                ableToComplete = cube1.parseCommand("##");
                return;
            }

            if (ableToComplete)
            {
                whiteCorners();
                Console.WriteLine("White Corners Complete!");
                cube1.printCube();

                ableToComplete = cube1.parseCommand("#");
            }
            else
            {
                ableToComplete = cube1.parseCommand("##");
                return;
            }

            if (ableToComplete)
            {
                ableToComplete = cube1.parseCommand("X X");
                cube1.printCube();

                secondLayer();
                if (ableToComplete)
                {
                    Console.WriteLine("Second Layer Complete!");
                    cube1.printCube();

                    ableToComplete = cube1.parseCommand("#");
                }
                
            }
            else
            {
                ableToComplete = cube1.parseCommand("##");
                ableToComplete = false;
                return;
            }

            if (ableToComplete)
            {
                yellowCross();
                if (ableToComplete)
                {
                    ableToComplete = cube1.parseCommand("#");
                }
                
            }
            else
            {
                ableToComplete = cube1.parseCommand("##");
                ableToComplete = false;
                return;
            }


            if (ableToComplete)
            {
                swapYellowEdges();
                Console.WriteLine("Yellow Cross Complete!");
                cube1.printCube();

                ableToComplete = cube1.parseCommand("#");
            }
            else
            {
                ableToComplete = cube1.parseCommand("##");
                return;
            }

            if (ableToComplete)
            {
                positionYellowCorners(false);
                Console.WriteLine("Yellow Corner Positioning Complete!");
                cube1.printCube();

                ableToComplete = cube1.parseCommand("#");
            }
            else
            {
                ableToComplete = cube1.parseCommand("##");
                return;
            }

            if (ableToComplete)
            {
                if (verifyCompleteCube() == false)
                {
                    orientYellowCorners();
                    Console.WriteLine("Rubik's Cube Complete!");
                    cube1.printCube();

                }

                ableToComplete = cube1.parseCommand("#");
                ableToComplete = cube1.parseCommand("");

                cube1.returnCommands();
            }
            else
            {
                ableToComplete = cube1.parseCommand("##");
                return;
            }

        }

        /* private void WhiteCross() - This is where the moves for the solving the "White Cross" steps of the cube are carried out.
         * The method only reaches a close once this section is completed in line with the requirements */
        private void whiteCross()
        {
            int spinCount = 0;
            bool ableToComplete = true;
            while (whiteCrossComplete == false)
            {
                if (ableToComplete == false)
                {
                    return;
                }
                while (cube1.getUpperFace()[2, 1] == cube1.getUpperFace()[1, 1] && cube1.getFrontFace()[0, 1] != cube1.getFrontFace()[1, 1])
                {
                    ableToComplete = cube1.parseCommand("U");
                    //cube1.printCube();
                }
                while (cube1.getUpperFace()[2, 1] != cube1.getUpperFace()[1, 1] && spinCount != 4)
                {
                    if (cube1.getFrontFace()[0, 1] == cube1.getUpperFace()[1, 1] && cube1.getFrontFace()[1, 1] == cube1.getUpperFace()[2, 1])
                    {
                        //cube1.printCube();
                        ableToComplete = cube1.parseCommand("F U' R U");
                        //cube1.printCube();
                    }
                    else if (cube1.getFrontFace()[2, 1] == cube1.getUpperFace()[1, 1] && cube1.getFrontFace()[1, 1] == cube1.getDownFace()[0, 1])
                    {
                        //cube1.printCube();
                        ableToComplete = cube1.parseCommand("F' U' R U");
                        //cube1.printCube();
                    }
                    else if (cube1.getFrontFace()[1, 2] == cube1.getUpperFace()[1, 1] && cube1.getFrontFace()[1, 1] == cube1.getRightFace()[1, 0])
                    {
                        ableToComplete = cube1.parseCommand("U' R U");
                        //cube1.printCube();
                    }
                    else if (cube1.getFrontFace()[1, 0] == cube1.getUpperFace()[1, 1] && cube1.getFrontFace()[1, 1] == cube1.getLeftFace()[1, 2])
                    {
                        ableToComplete = cube1.parseCommand("U L' U'");
                        //cube1.printCube();
                    }
                    else if (cube1.getBackFace()[0, 1] == cube1.getUpperFace()[1, 1] && cube1.getRightFace()[1, 2] == cube1.getFrontFace()[1, 1])
                    {
                        ableToComplete = cube1.parseCommand("U' R' U");
                        //cube1.printCube();
                    }
                    else if (cube1.getDownFace()[0, 1] == cube1.getUpperFace()[1, 1] && cube1.getFrontFace()[2, 1] == cube1.getFrontFace()[1, 1])
                    {
                        ableToComplete = cube1.parseCommand("F F");
                        //cube1.printCube();
                    }
                    else if (cube1.getFrontFace()[1, 1] == cube1.getBackFace()[1, 0] && cube1.getRightFace()[1, 2] == cube1.getUpperFace()[1, 1])
                    {
                        Console.WriteLine("U' R' U");
                        ableToComplete = cube1.parseCommand("U' R' U F U' R U");
                        //cube1.printCube();
                    }
                    else if (cube1.getFrontFace()[0, 1] == cube1.getUpperFace()[1, 1] && cube1.getUpperFace()[2, 1] != cube1.getFrontFace()[1, 1])
                    {
                        ableToComplete = cube1.parseCommand("F F");
                    }
                    else if (cube1.getBackFace()[1,0] == cube1.getUpperFace()[1, 1])
                    {
                        ableToComplete = cube1.parseCommand("R D' R'");
                    }
                    else
                    {
                        if (spinCount < 4)
                        {
                            ableToComplete = cube1.parseCommand("D");
                            //Console.WriteLine("D");
                            //cube1.printCube();
                        }
                        else if (spinCount < 8)
                        {
                            ableToComplete = cube1.parseCommand("U");
                            //Console.WriteLine("U");
                            //cube1.printCube();
                        }
                        spinCount++;

                    }
                }

                //cube1.printCube();


                // full turn
                ableToComplete = cube1.parseCommand("Y");

                cube1.printCube();
                spinCount = 0;

                if (verifyWhiteCross(cube1))
                {
                    whiteCrossComplete = true;
                }
            }
            
        }

        /* private void WhiteCorners() - This is where the moves for the solving the "White Corners" steps of the cube are carried out.
         * The method only reaches a close once this section is completed in line with the requirements */
        public void whiteCorners()
        {
            int spinCount = 0;

            //cube1.printCube();
            
            while (verifyWhiteCorners() == false)
            {
                cube1.printCube();
                if (ableToComplete == false)
                {
                    return;
                }
                if ((cube1.getUpperFace()[2, 0] == cube1.getUpperFace()[1, 1] && cube1.getFrontFace()[0, 0] != cube1.getFrontFace()[0, 1]) || (cube1.getFrontFace()[0, 0] == cube1.getUpperFace()[1, 1]))
                {

                    ableToComplete = cube1.parseCommand("L D L'");
                    cube1.printCube();
                }
                if ((cube1.getFrontFace()[0, 2] == cube1.getUpperFace()[1, 1]))
                {
                    ableToComplete = cube1.parseCommand("R' D R");
                }

                while (cube1.getUpperFace()[2, 2] != cube1.getUpperFace()[1, 1] && spinCount != 4)
                {

                    if (cube1.getRightFace()[2, 0] == cube1.getUpperFace()[1, 1] && cube1.getFrontFace()[2, 2] == cube1.getFrontFace()[1, 1] && cube1.getDownFace()[0, 2] == cube1.getRightFace()[1, 1])
                    {
                        ableToComplete = cube1.parseCommand("R' D' R");
                        cube1.printCube();
                    }
                    else if (cube1.getFrontFace()[2, 2] == cube1.getUpperFace()[1, 1] && cube1.getDownFace()[0, 2] == cube1.getFrontFace()[1, 1] && cube1.getRightFace()[2, 0] == cube1.getRightFace()[1, 1])
                    {
                        ableToComplete = cube1.parseCommand("F D F'");
                        cube1.printCube();
                    }
                    else if (cube1.getDownFace()[2, 2] == cube1.getUpperFace()[1, 1] && cube1.getRightFace()[2, 0] == cube1.getFrontFace()[1, 1] && cube1.getFrontFace()[2, 2] == cube1.getRightFace()[1, 1])
                    {
                        ableToComplete = cube1.parseCommand("R' D' D' R D R' D' R");
                        cube1.printCube();
                    }
                    else if (cube1.getDownFace()[0, 2] == cube1.getUpperFace()[1, 1] && cube1.getFrontFace()[2, 2] == cube1.getRightFace()[1, 1] && cube1.getRightFace()[2,0] == cube1.getFrontFace()[1, 1])
                    {
                        ableToComplete = cube1.parseCommand("R R D' R R D R R");
                    }
                    else
                    {
                        if (spinCount < 4)
                        {
                            ableToComplete = cube1.parseCommand("D");
                            Console.WriteLine("D");
                            cube1.printCube();
                        }
                        spinCount++;
                    }

                }

                ableToComplete = cube1.parseCommand("Y");
                Console.WriteLine("Y");
                spinCount = 0;

                //cube1.printCube();

            }
            // white corner in wrong position

        }

        /* private void secondLayer() - This is where the moves for the solving the second layer of the cube are carried out.
         * The method only reaches a close once this section is completed in line with the requirements */
        public void secondLayer()
        {
            int spinCount = 0;

            int downMoveCount = 0;
            while (verifySecondLayer() == false)
            {
                while (spinCount < 4)
                {
                    while (downMoveCount < 2)
                    {
                        if (ableToComplete == false)
                        {
                            return;
                        }

                        if (cube1.getFrontFace()[1, 2] == cube1.getRightFace()[1, 1] && cube1.getRightFace()[1, 0] == cube1.getFrontFace()[1, 1])
                        {
                            ableToComplete = cube1.parseCommand("U R U' R' U' F' U F");
                        }

                        if (cube1.getFrontFace()[0, 1] == cube1.getFrontFace()[1, 1])
                        {
                            if (cube1.getUpperFace()[2, 1] == cube1.getRightFace()[1, 1])
                            {
                                ableToComplete = cube1.parseCommand("U R U' R' U' F' U F");
                                downMoveCount++;
                            }
                            else if (cube1.getUpperFace()[2, 1] == cube1.getLeftFace()[1, 1])
                            {
                                ableToComplete = cube1.parseCommand("U' L' U L U F U' F'");
                                downMoveCount++;
                            }
                            else if (cube1.getFrontFace()[1, 2] == cube1.getFrontFace()[1, 1] && cube1.getRightFace()[1,0] != cube1.getRightFace()[1, 1])
                            {
                                ableToComplete = cube1.parseCommand("U R U' R' U' F' U F");
                            }
                            else if (cube1.getRightFace()[1, 0] == cube1.getRightFace()[1, 1] && cube1.getFrontFace()[1, 2] == cube1.getFrontFace()[1, 1])
                            {
                                ableToComplete = cube1.parseCommand("U R U' R' U' F' U F");
                            }
                            else
                            {
                                ableToComplete = cube1.parseCommand("U");
                                downMoveCount = 2;
                                spinCount++;
                                cube1.printCube();
                            }
                        }

                        
                        //else if (cube1.getFrontFace()[1, 2] != cube1.getFrontFace()[1, 1] || cube1.getRightFace()[1, 0] != cube1.getRightFace()[1, 1])
                        //{
                        //    if (cube1.getFrontFace()[1, 2] != cube1.getFrontFace()[1, 1] || cube1.getRightFace()[1, 0] != cube1.getRightFace()[1, 1])
                        //    {
                        //        ableToComplete = cube1.parseCommand("U R U' R' U' F' U F");
                        //        ableToComplete = cube1.parseCommand("U");
                        //        downMoveCount = 2;
                        //        spinCount++;
                        //    }
                        //}
                        else {
                            ableToComplete = cube1.parseCommand("U");
                            downMoveCount = 2;
                            spinCount++;
                        }
                        cube1.printCube();
                    }
                    downMoveCount = 0;
                }
                // full turn
                if (ableToComplete == false)
                {
                    return;
                }
                ableToComplete = cube1.parseCommand("Y");
                spinCount = 0;
                cube1.printCube();
            }
            
        }

        /* private void yellowCross() - This is where the moves for the solving the "Yellow Cross" steps of the cube are carried out.
         * The method only reaches a close once this section is completed in line with the requirements */
        public void yellowCross()
        {
            bool patternFound = false;
            int[,] startingFace = cube1.getUpperFace();
            int spinCount = 0;

            while (patternFound == false && spinCount < 4)
            {
                if (ableToComplete == false)
                {
                    return;
                }
                if (cube1.getUpperFace()[1, 1] == cube1.getUpperFace()[1, 0] && cube1.getUpperFace()[1, 1] == cube1.getUpperFace()[1, 2])
                {
                    ableToComplete = cube1.parseCommand("F R U R' U' F'");
                    patternFound = true;
                }
                else if (cube1.getUpperFace()[0, 1] == cube1.getUpperFace()[1, 1] && cube1.getUpperFace()[1, 0] == cube1.getUpperFace()[1, 1])
                {
                    ableToComplete = cube1.parseCommand("F U R U' R' F'");
                    patternFound = true;
                }
                else
                {
                    ableToComplete = cube1.parseCommand("Y");
                    spinCount++;
                    
                }
                cube1.printCube();
            }
            spinCount = 0;
            if (patternFound == false)
            {
                ableToComplete = cube1.parseCommand("F R U R' U' F'");

                cube1.printCube();

                while (patternFound == false && spinCount < 4)
                {
                    if (cube1.getUpperFace()[0, 1] == cube1.getUpperFace()[1, 1] && cube1.getUpperFace()[1, 0] == cube1.getUpperFace()[1, 1])
                    {

                        ableToComplete = cube1.parseCommand("F U R U' R' F'");

                        patternFound = true;
                    }
                    else
                    {
                        ableToComplete = cube1.parseCommand("Y");
                        spinCount++;
                    }
                }
            }
            if (ableToComplete == false)
            {
                return;
            }
        }

        /* private void swapYellowEdges() - This is where the moves for the swapping the yellow edges of the cube are carried out.
         * The method only reaches a close once this section is completed in line with the requirements */
        public void swapYellowEdges()
        {
            while (verifyYellowEdges() == false)
            {
                if (ableToComplete == false)
                {
                    return;
                }
                if (cube1.getFrontFace()[0, 1] == cube1.getFrontFace()[1, 1])
                {
                    //full turn
                    ableToComplete = cube1.parseCommand("Y");
                }
                else if (cube1.getFrontFace()[0, 1] == cube1.getLeftFace()[1, 1])
                {
                    ableToComplete = cube1.parseCommand("R U R' U R U U R' U");
                }
                else if (cube1.getFrontFace()[0, 1] == cube1.getBackFace()[1, 1])
                {
                    ableToComplete = cube1.parseCommand("Y Y Y U R U R' U R U U R' U Y Y R U R' U R U U R' U Y");
                }
                else
                {
                    // fullturn
                    ableToComplete = cube1.parseCommand("Y");
                }
                
                cube1.printCube();
            }

        }

        /* private void positionYellowCorners() - This is where the moves for the positioning the yellow corners of the cube are carried out.
         * The method only reaches a close once this section is completed in line with the requirements */
        public void positionYellowCorners(bool singleCorner)
        {
            int spinCount = 0;
            int correctCornerCount = 0;

            /* while (verifyYellowCorners() != 4)
             {
                 if (verifyYellowCorners() == 0)
                 {
                     ableToComplete = cube1.parseCommand("U R U' L' U R' U' L");
                 }

                 if (cube1.getUpperFace()[2, 2] == cube1.getUpperFace()[1, 1] && cube1.getFrontFace()[0, 2] == cube1.getFrontFace()[1, 1] && cube1.getRightFace()[0, 2] == cube1.getRightFace()[1, 1])
                 {
                     ableToComplete = cube1.parseCommand("U R U' L' U R' U' L");
                 }
                 else if (cube1.getFrontFace()[0, 2] == cube1.getRightFace()[1, 1] && cube1.getRightFace()[0, 2] == cube1.getUpperFace()[1, 1] && cube1.getUpperFace()[2, 2] == cube1.getFrontFace()[1, 1] && verifyYellowCorners() == 1)
                 {
                     ableToComplete = cube1.parseCommand("U R U' L' U R' U' L");
                 }
                 else if (cube1.getFrontFace()[0, 2] == cube1.getUpperFace()[1, 1] && cube1.getRightFace()[0, 0] == cube1.getFrontFace()[1, 1] && cube1.getUpperFace()[2, 2] == cube1.getRightFace()[1, 1] && verifyYellowCorners() == 1)
                 {
                     ableToComplete = cube1.parseCommand("U R U' L' U R' U' L");
                 }

                 verifyYellowCorners();
                 ableToComplete = cube1.parseCommand("Y");
                 spinCount++;
            }*/

            int x = verifyYellowCorners();
            cube1.printCube();
            if (ableToComplete == false)
            {
                return;
            }
            if (x == 1)
            {
                ableToComplete = cube1.parseCommand("U R U' L' U R' U' L");
                cube1.printCube();
                if (verifyYellowCorners() == 1)
                {
                    ableToComplete = cube1.parseCommand("U R U' L' U R' U' L");
                    cube1.printCube();
                }
            }
            else
            {
                ableToComplete = cube1.parseCommand("U R U' L' U R' U' L");
                if (verifyYellowCorners() == 1)
                {
                    ableToComplete = cube1.parseCommand("U R U' L' U R' U' L");

                    if (verifyYellowCorners() != 4)
                    {
                        ableToComplete = cube1.parseCommand("U R U' L' U R' U' L");
                    }
                }
            }    
        }

        /* private void orientYellowCorners() - This is where the moves for orienting the yellow corners of the cube are carried out.
         * The method only reaches a close once this section is completed in line with the requirements */
        public void orientYellowCorners()
        {
            bool solveStarted = false;
            if (ableToComplete == false)
            {
                return;
            }
            while (verifyCompleteCube() == false)
            {
                if (ableToComplete == false)
                {
                    return;
                }
                if (cube1.getUpperFace()[2, 2] != cube1.getUpperFace()[1, 1])
                {
                    solveStarted = true;
                    while (cube1.getUpperFace()[2, 2] != cube1.getUpperFace()[1, 1])
                    {
                        ableToComplete = cube1.parseCommand("R' D' R D");
                    }
                }
                if (solveStarted)
                {
                    ableToComplete = cube1.parseCommand("U");
                }
                else
                {
                    ableToComplete = cube1.parseCommand("Y");
                }
            }
        }
        
        /* private void verifyWhiteCross() - This method verifies if the method WhiteCross() has been completed successfully with each move
         Return TRUE: The white cross has been completed successfully
         Return FALSE: The white cross is not yet complete
         */
        private bool verifyWhiteCross(RubiksCube cube1)
        {
            int col = cube1.getUpperFace()[1, 1];
            int[,] upperFace = cube1.getUpperFace();

            bool checker;

            if (col == upperFace[1, 0] && col == upperFace[1, 2] && col == upperFace[0, 1] && col == upperFace[2, 1])
            {
                checker = true;
            }
            else
            {
                checker = false;
            }

            return checker;
        }
       
        /* private void verifyWhiteCorners() - This method verifies if the method WhiteCorners() has been completed successfully with each move
         Return TRUE: The white corners have been completed successfully
         Return FALSE: The white corners are not yet complete
         */
        private bool verifyWhiteCorners()
        {
            bool verify = false;
            if (cube1.getUpperFace()[2, 0] == cube1.getUpperFace()[1, 1] && cube1.getUpperFace()[2, 2] == cube1.getUpperFace()[1, 1] && cube1.getUpperFace()[0, 0] == cube1.getUpperFace()[1, 1] && cube1.getUpperFace()[0, 2] == cube1.getUpperFace()[1, 1])
            {
                if (cube1.getFrontFace()[0, 1] == cube1.getFrontFace()[0, 0] && cube1.getFrontFace()[0, 1] == cube1.getFrontFace()[0, 2])
                {
                    if (cube1.getRightFace()[0, 1] == cube1.getRightFace()[0, 0] && cube1.getRightFace()[0, 1] == cube1.getRightFace()[0, 2])
                    {
                        if (cube1.getBackFace()[0, 1] == cube1.getBackFace()[0, 0] && cube1.getBackFace()[0, 1] == cube1.getBackFace()[0, 2])
                        {
                            if (cube1.getLeftFace()[0, 1] == cube1.getLeftFace()[0, 0] && cube1.getLeftFace()[0, 1] == cube1.getLeftFace()[0, 2])
                            {
                                verify = true;
                            }
                        }
                    }
                }
            }
            return verify;

        }

        private bool verifySecondLayer()
        {
            bool verify = false;
            if (cube1.getFrontFace()[1, 0] == cube1.getFrontFace()[1, 1] && cube1.getFrontFace()[1, 2] == cube1.getFrontFace()[1, 1])
            {
                if (cube1.getRightFace()[1, 0] == cube1.getRightFace()[1, 1] && cube1.getRightFace()[1, 2] == cube1.getRightFace()[1, 1])
                {
                    if (cube1.getBackFace()[1, 0] == cube1.getBackFace()[1, 1] && cube1.getBackFace()[1, 2] == cube1.getBackFace()[1, 1])
                    {
                        if (cube1.getLeftFace()[1, 0] == cube1.getLeftFace()[1, 1] && cube1.getLeftFace()[1, 2] == cube1.getLeftFace()[1, 1])
                        {
                            verify = true;
                        }
                    }
                }
            }
            return verify;
        }

        private bool verifyYellowCross()
        {
            bool verify = false;
            if (cube1.getUpperFace()[1, 1] == cube1.getUpperFace()[0, 1] && cube1.getUpperFace()[1, 1] == cube1.getUpperFace()[2, 1] && cube1.getUpperFace()[1, 1] == cube1.getUpperFace()[1, 0] && cube1.getUpperFace()[1, 1] == cube1.getUpperFace()[1, 2])
            {
                verify = true;
            }
            return verify;
        }

        private bool verifyYellowEdges()
        {
            bool verify = false;

            if (cube1.getFrontFace()[0, 1] == cube1.getFrontFace()[1, 1] && cube1.getRightFace()[0, 1] == cube1.getRightFace()[1, 1] && cube1.getBackFace()[0, 1] == cube1.getBackFace()[1, 1] && cube1.getLeftFace()[0, 1] == cube1.getLeftFace()[1, 1])
            {
                verify = true;
            }

            return verify;
        }

        private int verifyYellowCorners()
        {
            int cornerCount = 0;
            int spinCount = 0;
            bool notAll = false;
            bool correctCorner = false;
            for (int i = 0; i < 4; i++)
            {
                cube1.printCube();
                if (cube1.getUpperFace()[2, 2] == cube1.getUpperFace()[1, 1] && cube1.getFrontFace()[0, 2] == cube1.getFrontFace()[1, 1] && cube1.getRightFace()[0, 0] == cube1.getRightFace()[1, 1])
                {
                    cornerCount++;
                }
                else if (cube1.getFrontFace()[0, 2] == cube1.getRightFace()[1, 1] && cube1.getRightFace()[0, 2] == cube1.getUpperFace()[1, 1] && cube1.getUpperFace()[2, 2] == cube1.getFrontFace()[1, 1])
                {
                    cornerCount++;
                }
                else if (cube1.getFrontFace()[0, 2] == cube1.getUpperFace()[1, 1] && cube1.getRightFace()[0, 0] == cube1.getFrontFace()[1, 1] && cube1.getUpperFace()[2, 2] == cube1.getRightFace()[1, 1])
                {
                    cornerCount++;
                    if (notAll == true)
                    {
                        return cornerCount;
                    }
                }
                ableToComplete = cube1.parseCommand("Y");
                spinCount++;
                if ((cornerCount == 0)||(cornerCount == 1 && spinCount > 1))
                {
                    notAll = true;
                }
                
            }

            spinCount = 0;
            while (correctCorner == false && spinCount < 4 && cornerCount == 1)
            {
                if (cube1.getUpperFace()[2, 2] == cube1.getUpperFace()[1, 1] && cube1.getFrontFace()[0, 2] == cube1.getFrontFace()[1, 1] && cube1.getRightFace()[0, 2] == cube1.getRightFace()[1, 1])
                {
                    return cornerCount;
                }
                else if (cube1.getFrontFace()[0, 2] == cube1.getRightFace()[1, 1] && cube1.getRightFace()[0, 2] == cube1.getUpperFace()[1, 1] && cube1.getUpperFace()[2, 2] == cube1.getFrontFace()[1, 1])
                {
                    return cornerCount;
                }
                else if (cube1.getFrontFace()[0, 2] == cube1.getUpperFace()[1, 1] && cube1.getRightFace()[0, 0] == cube1.getFrontFace()[1, 1] && cube1.getUpperFace()[2, 2] == cube1.getRightFace()[1, 1])
                {
                    return cornerCount;
                }
                ableToComplete = cube1.parseCommand("Y");
                spinCount++;
            }

            return cornerCount;
        }

        private bool verifyCompleteCube()
        {
            int[][,] fullCube = cube1.getFullCube();

            foreach (int[,] face in fullCube)
            {
                for (int y = 0; y < 3; y++)
                {
                    for (int x = 0; x < 3; x++)
                    {
                        if (face[y, x] != face[1, 1])
                        {
                            return false;
                        }
                    }
                }
            }

            return true;

        }
    }
}
