using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzleMasters
{
    public class RubiksCube
    {
        //int[,,] cube;

        int[,] frontFace;
        int[,] rightFace;
        int[,] upperFace;
        int[,] leftFace;
        int[,] backFace;
        int[,] downFace;

        ArrayList commandsUsed = new ArrayList();
        String lastCommand = "#";
        int commandCount = 1;

        public RubiksCube(int[,] frontFace, int[,] rightFace, int[,] backFace, int[,] leftFace,
                   int[,] upperFace, int[,] downFace)
        {
            this.frontFace = frontFace;
            this.rightFace = rightFace;
            this.backFace = backFace;
            this.leftFace = leftFace;
            this.upperFace = upperFace;
            this.downFace = downFace;

        }

        public bool parseCommand(string unparsedCommand)
        {

            string[] splitCommand = unparsedCommand.Split(' ');

            foreach (var commandItem in splitCommand)
            {
                switch (commandItem)
                {
                    case "F":
                        F();
                        // printCube();
                        break;
                    case "R":
                        R();
                        // printCube();
                        break;
                    case "U":
                        U();
                        // printCube();
                        break;
                    case "L":
                        L();
                        // printCube();
                        break;
                    case "B":
                        B();
                        // printCube();
                        break;
                    case "D":
                        D();
                        //  printCube();
                        break;
                    case "X":
                        xTurn();
                        //  printCube();
                        break;
                    case "Y":
                        yTurn();
                        //  printCube();
                        break;
                    case "F'":
                        Fdash();
                        //  printCube();
                        break;
                    case "R'":
                        Rdash();
                        //  printCube();
                        break;
                    case "U'":
                        Udash();
                        //  printCube();
                        break;
                    case "L'":
                        Ldash();
                        //  printCube();
                        break;
                    case "B'":
                        Bdash();
                        //  printCube();
                        break;
                    case "D'":
                        Ddash();
                        //  printCube();
                        break;
                }



                if (commandsUsed != null)
                {

                    if (commandItem != lastCommand)
                    {
                        if (commandCount != 1 && commandCount != 0)
                        {
                            commandsUsed.Add(lastCommand + commandCount);
                            lastCommand = commandItem;
                            commandCount = 1;
                        }
                        else if (commandCount != 0)
                        {
                            commandsUsed.Add(lastCommand);
                            lastCommand = commandItem;
                            commandCount = 1;
                        }
                        else
                        {
                            lastCommand = commandItem;
                        }
                    }
                    else
                    {
                        commandCount++;
                        if (commandCount == 4)
                        {
                            commandCount = 0;
                        }

                    }
                }
                else
                {
                    lastCommand = commandItem;
                }

                //commandsUsed.Add(commandItem);
                if (commandsUsed.Count>2000)
                {
                    int x = commandsUsed.LastIndexOf("#");
                    commandsUsed.RemoveRange(x, (commandsUsed.Count-x));
                    commandsUsed.Add("##");
                    return false;
                    
                }

            }
            return true;
        }

        void F()
        {
            int[,] newFace = new int[3, 3];
            int[,] rightFace = (int[,])this.rightFace.Clone();
            int[,] upperFace = (int[,])this.upperFace.Clone();
            int[,] leftFace = (int[,])this.leftFace.Clone();
            int[,] downFace = (int[,])this.downFace.Clone();
            int newX = 0;
            int newY = 0;
            for (int x = 0; x <= 2; x++)
            {
                for (int y = 2; y >= 0; y--)
                {
                    newFace[newY, newX] = frontFace[y, x];
                    newX++;
                }
                newY++;
                newX = 0;
            }
            frontFace = newFace;
            for (int i = 0; i <= 2; i++)
            {

                this.leftFace[i, 2] = downFace[0, i];
                this.rightFace[i, 0] = upperFace[2, i];
            }

            this.upperFace[2, 0] = leftFace[2, 2];
            this.upperFace[2, 1] = leftFace[1, 2];
            this.upperFace[2, 2] = leftFace[0, 2];

            this.downFace[0, 0] = rightFace[2, 0];
            this.downFace[0, 1] = rightFace[1, 0];
            this.downFace[0, 2] = rightFace[0, 0];





        }

        void R()
        {
            int[,] newFace = new int[3, 3];
            int[,] frontFace = (int[,])this.frontFace.Clone();
            int[,] upperFace = (int[,])this.upperFace.Clone();
            int[,] backFace = (int[,])this.backFace.Clone();
            int[,] downFace = (int[,])this.downFace.Clone();


            newFace[0, 0] = rightFace[2, 0];
            newFace[0, 1] = rightFace[1, 0];
            newFace[0, 2] = rightFace[0, 0];
            newFace[1, 0] = rightFace[2, 1];
            newFace[1, 1] = rightFace[1, 1];
            newFace[1, 2] = rightFace[0, 1];
            newFace[2, 0] = rightFace[2, 2];
            newFace[2, 1] = rightFace[1, 2];
            newFace[2, 2] = rightFace[0, 2];

            for (int i = 0; i <= 2; i++)
            {
                this.upperFace[i, 2] = frontFace[i, 2];
                this.frontFace[i, 2] = downFace[i, 2];
            }
            rightFace = newFace;
            this.backFace[2, 0] = upperFace[0, 2];
            this.backFace[1, 0] = upperFace[1, 2];
            this.backFace[0, 0] = upperFace[2, 2];

            this.downFace[2, 2] = backFace[0, 0];
            this.downFace[1, 2] = backFace[1, 0];
            this.downFace[0, 2] = backFace[2, 0];
        }

        void U()
        {
            int[,] newFace = new int[3, 3];
            int[,] newRightFace = (int[,])rightFace.Clone();
            int[,] newFrontFace = (int[,])frontFace.Clone();
            int[,] newLeftFace = (int[,])leftFace.Clone();
            int[,] newBackFace = (int[,])backFace.Clone();

            newFace[0, 0] = upperFace[2, 0];
            newFace[0, 1] = upperFace[1, 0];
            newFace[0, 2] = upperFace[0, 0];
            newFace[1, 0] = upperFace[2, 1];
            newFace[1, 1] = upperFace[1, 1];
            newFace[1, 2] = upperFace[0, 1];
            newFace[2, 0] = upperFace[2, 2];
            newFace[2, 1] = upperFace[1, 2];
            newFace[2, 2] = upperFace[0, 2];
            upperFace = newFace;
            for (int i = 0; i <= 2; i++)
            {
                frontFace[0, i] = newRightFace[0, i];
                rightFace[0, i] = newBackFace[0, i];
                backFace[0, i] = newLeftFace[0, i];
                leftFace[0, i] = newFrontFace[0, i];
            }

            //printCube();
        }

        void L()
        {
            // needs checking - make sure going right way
            int[,] newFace = new int[3, 3];
            int[,] frontFace = (int[,])this.frontFace.Clone();
            int[,] upperFace = (int[,])this.upperFace.Clone();
            int[,] backFace = (int[,])this.backFace.Clone();
            int[,] downFace = (int[,])this.downFace.Clone();
            int newX = 0;
            int newY = 0;
            for (int x = 0; x <= 2; x++)
            {
                for (int y = 2; y >= 0; y--)
                {
                    newFace[newY, newX] = leftFace[y, x];
                    newX++;
                }
                newY++;
                newX = 0;
            }
            leftFace = newFace;
            for (int i = 0; i <= 2; i++)
            {

                this.frontFace[i, 0] = upperFace[i, 0];
                this.downFace[i, 0] = frontFace[i, 0];

            }
            this.upperFace[0, 0] = backFace[2, 2];
            this.upperFace[1, 0] = backFace[1, 2];
            this.upperFace[2, 0] = backFace[0, 2];

            this.backFace[2, 2] = downFace[0, 0];
            this.backFace[1, 2] = downFace[1, 0];
            this.backFace[0, 2] = downFace[2, 0];


        }

        void B()
        {
            int[,] newFace = new int[3, 3];
            int[,] rightFace = (int[,])this.rightFace.Clone();
            int[,] upperFace = (int[,])this.upperFace.Clone();
            int[,] leftFace = (int[,])this.leftFace.Clone();
            int[,] downFace = (int[,])this.downFace.Clone();
            int newX = 0;
            int newY = 0;
            for (int x = 0; x <= 2; x++)
            {
                for (int y = 2; y >= 0; y--)
                {
                    newFace[newY, newX] = backFace[y, x];
                    newX++;
                }
                newY++;
                newX = 0;
            }
            backFace = newFace;
            for (int i = 0; i <= 2; i++)
            {
                this.upperFace[0, i] = rightFace[i, 2];

                this.downFace[2, i] = leftFace[i, 0];

            }
            this.leftFace[2, 0] = upperFace[0, 0];
            this.leftFace[1, 0] = upperFace[0, 1];
            this.leftFace[0, 0] = upperFace[0, 2];

            this.rightFace[0, 2] = downFace[2, 2];
            this.rightFace[1, 2] = downFace[2, 1];
            this.rightFace[2, 2] = downFace[2, 0];
        }

        void D()
        {
            int[,] newFace = new int[3, 3];
            int[,] newRightFace = (int[,])rightFace.Clone();
            int[,] newFrontFace = (int[,])frontFace.Clone();
            int[,] newLeftFace = (int[,])leftFace.Clone();
            int[,] newBackFace = (int[,])backFace.Clone();


            int newX = 0;
            int newY = 0;
            for (int x = 0; x <= 2; x++)
            {
                for (int y = 2; y >= 0; y--)
                {
                    newFace[newY, newX] = downFace[y, x];
                    newX++;
                }
                newY++;
                newX = 0;
            }
            downFace = newFace;
            for (int i = 0; i <= 2; i++)
            {
                frontFace[2, i] = newLeftFace[2, i];
                rightFace[2, i] = newFrontFace[2, i];
                backFace[2, i] = newRightFace[2, i];
                leftFace[2, i] = newBackFace[2, i];
            }
        }

        void Fdash()
        {
            int[,] newFace = new int[3, 3];
            int[,] rightFace = (int[,])this.rightFace.Clone();
            int[,] upperFace = (int[,])this.upperFace.Clone();
            int[,] leftFace = (int[,])this.leftFace.Clone();
            int[,] downFace = (int[,])this.downFace.Clone();

            newFace[0, 0] = frontFace[0, 2];
            newFace[0, 1] = frontFace[1, 2];
            newFace[0, 2] = frontFace[2, 2];
            newFace[1, 0] = frontFace[0, 1];
            newFace[1, 1] = frontFace[1, 1];
            newFace[1, 2] = frontFace[2, 1];
            newFace[2, 0] = frontFace[0, 0];
            newFace[2, 1] = frontFace[1, 0];
            newFace[2, 2] = frontFace[2, 0];

            for (int i = 0; i <= 2; i++)
            {
                this.upperFace[2, i] = rightFace[i, 0];
                this.downFace[0, i] = leftFace[i, 2];
            }

            this.leftFace[2, 2] = upperFace[2, 0];
            this.leftFace[1, 2] = upperFace[2, 1];
            this.leftFace[0, 2] = upperFace[2, 2];

            this.rightFace[2, 0] = downFace[0, 0];
            this.rightFace[1, 0] = downFace[0, 1];
            this.rightFace[0, 0] = downFace[0, 2];

            frontFace = newFace;
        }

        void Rdash()
        {
            int[,] newFace = new int[3, 3];
            int[,] frontFace = (int[,])this.frontFace.Clone();
            int[,] upperFace = (int[,])this.upperFace.Clone();
            int[,] backFace = (int[,])this.backFace.Clone();
            int[,] downFace = (int[,])this.downFace.Clone();

            newFace[0, 0] = rightFace[0, 2];
            newFace[0, 1] = rightFace[1, 2];
            newFace[0, 2] = rightFace[2, 2];
            newFace[1, 0] = rightFace[0, 1];
            newFace[1, 1] = rightFace[1, 1];
            newFace[1, 2] = rightFace[2, 1];
            newFace[2, 0] = rightFace[0, 0];
            newFace[2, 1] = rightFace[1, 0];
            newFace[2, 2] = rightFace[2, 0];


            rightFace = newFace;
            for (int i = 0; i <= 2; i++)
            {
                this.frontFace[i, 2] = upperFace[i, 2];
                this.downFace[i, 2] = frontFace[i, 2];
            }

            this.upperFace[2, 2] = backFace[0, 0];
            this.upperFace[1, 2] = backFace[1, 0];
            this.upperFace[0, 2] = backFace[2, 0];

            this.backFace[2, 0] = downFace[0, 2];
            this.backFace[1, 0] = downFace[1, 2];
            this.backFace[0, 0] = downFace[2, 2];

            //printCube();
        }

        void Udash()
        {
            int[,] newFace = new int[3, 3];
            int[,] rightFace = (int[,])this.rightFace.Clone();
            int[,] frontFace = (int[,])this.frontFace.Clone();
            int[,] leftFace = (int[,])this.leftFace.Clone();
            int[,] backFace = (int[,])this.backFace.Clone();

            newFace[0, 0] = upperFace[0, 2];
            newFace[0, 1] = upperFace[1, 2];
            newFace[0, 2] = upperFace[2, 2];
            newFace[1, 0] = upperFace[0, 1];
            newFace[1, 1] = upperFace[1, 1];
            newFace[1, 2] = upperFace[2, 1];
            newFace[2, 0] = upperFace[0, 0];
            newFace[2, 1] = upperFace[1, 0];
            newFace[2, 2] = upperFace[2, 0];

            upperFace = newFace;
            for (int i = 0; i <= 2; i++)
            {
                this.frontFace[0, i] = leftFace[0, i];
                this.rightFace[0, i] = frontFace[0, i];
                this.backFace[0, i] = rightFace[0, i];
                this.leftFace[0, i] = backFace[0, i];
            }
            // printCube();
        }

        void Ldash()
        {
            // needs checking - make sure going right way
            int[,] newFace = new int[3, 3];
            int[,] frontFace = (int[,])this.frontFace.Clone();
            int[,] upperFace = (int[,])this.upperFace.Clone();
            int[,] backFace = (int[,])this.backFace.Clone();
            int[,] downFace = (int[,])this.downFace.Clone();
            int newX = 0;
            int newY = 0;
            //  needs changing to match
            newFace[0, 0] = leftFace[0, 2];
            newFace[0, 1] = leftFace[1, 2];
            newFace[0, 2] = leftFace[2, 2];
            newFace[1, 0] = leftFace[0, 1];
            newFace[1, 1] = leftFace[1, 1];
            newFace[1, 2] = leftFace[2, 1];
            newFace[2, 0] = leftFace[0, 0];
            newFace[2, 1] = leftFace[1, 0];
            newFace[2, 2] = leftFace[2, 0];

            leftFace = newFace;
            for (int i = 0; i <= 2; i++)
            {
                this.upperFace[i, 0] = frontFace[i, 0];
                this.frontFace[i, 0] = downFace[i, 0];
            }

            this.backFace[2, 2] = upperFace[0, 0];
            this.backFace[1, 2] = upperFace[1, 0];
            this.backFace[0, 2] = upperFace[2, 0];

            this.downFace[2, 0] = backFace[0, 2];
            this.downFace[1, 0] = backFace[1, 2];
            this.downFace[0, 0] = backFace[2, 2];


        }

        void Bdash()
        {
            int[,] newFace = new int[3, 3];
            int[,] rightFace = (int[,])this.rightFace.Clone();
            int[,] upperFace = (int[,])this.upperFace.Clone();
            int[,] leftFace = (int[,])this.leftFace.Clone();
            int[,] downFace = (int[,])this.downFace.Clone();
            int newX = 0;
            int newY = 0;

            newFace[0, 0] = backFace[0, 2];
            newFace[0, 1] = backFace[1, 2];
            newFace[0, 2] = backFace[2, 2];
            newFace[1, 0] = backFace[0, 1];
            newFace[1, 1] = backFace[1, 1];
            newFace[1, 2] = backFace[2, 1];
            newFace[2, 0] = backFace[0, 0];
            newFace[2, 1] = backFace[1, 0];
            newFace[2, 2] = backFace[2, 0];

            backFace = newFace;
            for (int i = 0; i <= 2; i++)
            {
                this.rightFace[i, 2] = upperFace[0, i];
                this.leftFace[i, 0] = downFace[2, i];
            }

            this.upperFace[0, 2] = leftFace[0, 0];
            this.upperFace[0, 1] = leftFace[1, 0];
            this.upperFace[0, 0] = leftFace[2, 0];

            this.downFace[2, 2] = rightFace[0, 2];
            this.downFace[2, 1] = rightFace[1, 2];
            this.downFace[2, 0] = rightFace[2, 2];
        }

        void Ddash()
        {
            int[,] newFace = new int[3, 3];
            int[,] rightFace = (int[,])this.rightFace.Clone();
            int[,] frontFace = (int[,])this.frontFace.Clone();
            int[,] leftFace = (int[,])this.leftFace.Clone();
            int[,] backFace = (int[,])this.backFace.Clone();

            int newX = 0;
            int newY = 0;
            // needs changing to match

            newFace[0, 0] = downFace[0, 2];
            newFace[0, 1] = downFace[1, 2];
            newFace[0, 2] = downFace[2, 2];
            newFace[1, 0] = downFace[0, 1];
            newFace[1, 1] = downFace[1, 1];
            newFace[1, 2] = downFace[2, 1];
            newFace[2, 0] = downFace[0, 0];
            newFace[2, 1] = downFace[1, 0];
            newFace[2, 2] = downFace[2, 0];

            downFace = newFace;
            for (int i = 0; i <= 2; i++)
            {
                this.frontFace[2, i] = rightFace[2, i];
                this.rightFace[2, i] = backFace[2, i];
                this.backFace[2, i] = leftFace[2, i];
                this.leftFace[2, i] = frontFace[2, i];
            }
        }

        void xTurn()
        {

            R();
            Ldash();

            int[,] frontFace = (int[,])this.frontFace.Clone();
            int[,] upperFace = (int[,])this.upperFace.Clone();
            int[,] backFace = (int[,])this.backFace.Clone();
            int[,] downFace = (int[,])this.downFace.Clone();

            for (int i = 0; i <= 2; i++)
            {
                this.upperFace[i, 1] = frontFace[i, 1];
                this.frontFace[i, 1] = downFace[i, 1];
            }

            this.backFace[2, 1] = upperFace[0, 1];
            this.backFace[1, 1] = upperFace[1, 1];
            this.backFace[0, 1] = upperFace[2, 1];

            this.downFace[2, 1] = backFace[0, 1];
            this.downFace[1, 1] = backFace[1, 1];
            this.downFace[0, 1] = backFace[2, 1];

        }

        void yTurn()
        {
            int[,] newUpperFace = new int[3, 3];
            int[,] newDownFace = new int[3, 3];
            int[,] frontFace = (int[,])this.rightFace.Clone();
            int[,] rightFace = (int[,])this.backFace.Clone();
            int[,] backFace = (int[,])this.leftFace.Clone();
            int[,] leftFace = (int[,])this.frontFace.Clone();

            newUpperFace[0, 0] = upperFace[2, 0];
            newUpperFace[0, 1] = upperFace[1, 0];
            newUpperFace[0, 2] = upperFace[0, 0];
            newUpperFace[1, 0] = upperFace[2, 1];
            newUpperFace[1, 1] = upperFace[1, 1];
            newUpperFace[1, 2] = upperFace[0, 1];
            newUpperFace[2, 0] = upperFace[2, 2];
            newUpperFace[2, 1] = upperFace[1, 2];
            newUpperFace[2, 2] = upperFace[0, 2];

            newDownFace[0, 0] = downFace[0, 2];
            newDownFace[0, 1] = downFace[1, 2];
            newDownFace[0, 2] = downFace[2, 2];
            newDownFace[1, 0] = downFace[0, 1];
            newDownFace[1, 1] = downFace[1, 1];
            newDownFace[1, 2] = downFace[2, 1];
            newDownFace[2, 0] = downFace[0, 0];
            newDownFace[2, 1] = downFace[1, 0];
            newDownFace[2, 2] = downFace[2, 0];


            this.frontFace = frontFace;
            this.rightFace = rightFace;
            this.backFace = backFace;
            this.leftFace = leftFace;
            upperFace = newUpperFace;
            downFace = newDownFace;

        }

        void zTurn()
        {

        }

        public int[,] getFrontFace()
        {
            return frontFace;
        }

        public int[,] getBackFace()
        {
            return backFace;
        }

        public int[,] getUpperFace()
        {
            return upperFace;
        }

        public int[,] getDownFace()
        {
            return downFace;
        }

        public int[,] getLeftFace()
        {
            return leftFace;
        }

        public int[,] getRightFace()
        {
            return rightFace;
        }

        public int[][,] getFullCube()
        {
            int[][,] fullCube = { frontFace, backFace, upperFace, downFace, leftFace, rightFace };

            return fullCube;
        }

        public void printCube()
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("\r\n" + "Left");
            for (int i = 0; i < 3; i++)
            {
                for (int x = 0; x < 3; x++)
                {
                    Console.Write(leftFace[i, x]);
                }
                Console.WriteLine("");
            }

            Console.WriteLine("\r\n" + "front" + "\r\n");

            for (int i = 0; i < 3; i++)
            {
                for (int x = 0; x < 3; x++)
                {
                    Console.Write(frontFace[i, x]);
                }
                Console.WriteLine("");
            }

            Console.WriteLine("\r\n" + "right" + "\r\n");
            for (int i = 0; i < 3; i++)
            {
                for (int x = 0; x < 3; x++)
                {
                    Console.Write(rightFace[i, x]);
                }
                Console.WriteLine("");
            }

            Console.WriteLine("\r\n" + "back" + "\r\n");
            for (int i = 0; i < 3; i++)
            {
                for (int x = 0; x < 3; x++)
                {
                    Console.Write(backFace[i, x]);
                }
                Console.WriteLine("");
            }

            Console.WriteLine("\r\n" + "upper" + "\r\n");

            for (int i = 0; i < 3; i++)
            {
                for (int x = 0; x < 3; x++)
                {
                    Console.Write(upperFace[i, x]);
                }
                Console.WriteLine("");
            }

            Console.WriteLine("\r\n" + "down" + "\r\n");
            for (int i = 0; i < 3; i++)
            {
                for (int x = 0; x < 3; x++)
                {
                    Console.Write(downFace[i, x]);
                }
                Console.WriteLine("");
            }
            Console.WriteLine("-----------------------------------");
        }

        public ArrayList returnCommands()
        {
            return commandsUsed;
        }

    }
}
