using System;
using System.Drawing;
using System.Windows.Forms;
/*
    JLaneAssignment3
    A C# version of the classic game Tic Tac Toe
    Completed by:
    John Lane, 2019 11 15
 */
namespace JLAssignment3
{
    /// <summary>
    /// TicTacToe inherits from Form
    /// </summary>
    public partial class TicTacToe : Form
    {
        /// <summary>
        /// Constructor initializes component 
        /// and calls CreateGameBoard();
        /// </summary>
        public TicTacToe()
        {
            InitializeComponent();
            CreateGameBoard();
        }

        private const byte ROWS = 3; //set rows in array as int constant
        
        private const byte COLUMNS = 3; //set columns in array as int constant
        
        private readonly Image redX = Properties.Resources.redX; //set red x image as global
        
        private readonly Image blue0 = Properties.Resources.blue0; //set blue 0 image as global
       
        private string x = "x"; //set a global and reassignable variable x to keep track of turns
       
        private int numberOfClicks = 0; //set number of clicks to 0

        private PictureBox[,] pbArray = new PictureBox[ROWS, COLUMNS]; //create a 2D array of picture boxes
        
        /// <summary>
        /// CreateGameBoard() assigns picturebox
        /// objects to 2D array
        /// </summary>
        private void CreateGameBoard()
        {
            for (int i = 0; i < pbArray.GetLength(0); i++)
            {
                for (int j = 0; j < pbArray.GetLength(1); j++)
                {
                    PictureBox pb = new PictureBox();
                    pbArray[i, j] = pb;

                }
            }
        }

        /// <summary>
        /// Picture boxes get cast with each click
        /// and logic assigns images to picturbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickPictureBox(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;

            if (pb.Image == null && x == "x")
            {
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                pb.Image = redX; //assign image to picture box
                x = "o"; //set the turn to 'o'
                numberOfClicks++; //increment the number of clicks
                AssignImage(pb); //send picture box to the array
            }

            if (pb.Image == null && x == "o")
            {
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                pb.Image = blue0;//assign image to picture box
                x = "x";//set the turn to 'x'
                numberOfClicks++; //increment the number of clicks
                AssignImage(pb); //send picture box to the array
            }

            if (numberOfClicks >= 5) //victory occurs at 5 cicks or greater
            {
                CheckGameOver(); //if 5 or more clicks, check game method called. 
            }
        }
        /// <summary>
        /// Picture boxes with images assigned
        /// are passed to a method and each picturebox
        /// is given a spot on a 2D array
        /// </summary>
        /// <param name="pb"></param>
        private void AssignImage(PictureBox pb) 
        {
            if (pb.Name == "pb1")
            {
                pbArray[0, 0].Image = pb.Image;
            }

            if (pb.Name == "pb2")
            {
                pbArray[0, 1].Image = pb.Image;
            }

            if (pb.Name == "pb3")
            {
                pbArray[0,2].Image = pb.Image;
            }

            if (pb.Name == "pb4")
            {
                pbArray[1,0].Image = pb.Image;
            }

            if (pb.Name == "pb5")
            {
                pbArray[1,1].Image = pb.Image;
            }

            if (pb.Name == "pb6")
            {
                pbArray[1,2].Image = pb.Image;
            }

            if (pb.Name == "pb7")
            {
                pbArray[2,0].Image = pb.Image;
            }

            if (pb.Name == "pb8")
            {
                pbArray[2,1].Image = pb.Image;
            }

            if (pb.Name == "pb9")
            {
                pbArray[2,2].Image = pb.Image;
            }
        }

        /// <summary>
        /// If any of the conditions are met below
        /// it means X or O has won a vertical,
        /// horizontal, or diagonal victory and 
        /// GameOverMessage() called. If none are true
        /// and there have been 9 clicks, it means a Tie
        /// and TieMessage() called. 
        /// </summary>
        private void CheckGameOver() 
        {
            //check if x wins
            if (pbArray[0,0].Image == redX && pbArray[1,0].Image == redX && pbArray[2,0].Image == redX)
            {
                GaveOverMessage("X");
            }

            if (pbArray[0, 1].Image == redX && pbArray[1, 1].Image == redX && pbArray[2, 1].Image == redX)
            {
                GaveOverMessage("X");
            }

            if (pbArray[0, 2].Image == redX && pbArray[1, 2].Image == redX && pbArray[2, 2].Image == redX)
            {
                GaveOverMessage("X");
            }

            if (pbArray[0, 0].Image == redX && pbArray[0, 1].Image == redX && pbArray[0, 2].Image == redX)
            {
                GaveOverMessage("X");
            }

            if (pbArray[1, 0].Image == redX && pbArray[1, 1].Image == redX && pbArray[1, 2].Image == redX)
            {
                GaveOverMessage("X");
            }

            if (pbArray[2, 0].Image == redX && pbArray[2, 1].Image == redX && pbArray[2, 2].Image == redX)
            {
                GaveOverMessage("X");
            }

            if (pbArray[0, 0].Image == redX && pbArray[1, 1].Image == redX && pbArray[2, 2].Image == redX)
            {
                GaveOverMessage("X");
            }

            if (pbArray[0, 2].Image == redX && pbArray[1, 1].Image == redX && pbArray[2, 0].Image == redX)
            {
                GaveOverMessage("X");
            }
            //check if 0 wins
           
            if (pbArray[0, 0].Image == blue0 && pbArray[1, 0].Image == blue0 && pbArray[2, 0].Image == blue0)
            {
                GaveOverMessage("O");
            }

            if (pbArray[0, 1].Image == blue0 && pbArray[1, 1].Image == blue0 && pbArray[2, 1].Image == blue0)
            {
                GaveOverMessage("O");
            }

            if (pbArray[0, 2].Image == blue0 && pbArray[1, 2].Image == blue0 && pbArray[2, 2].Image == blue0)
            {
                GaveOverMessage("O");
            }

            if (pbArray[0, 0].Image == blue0 && pbArray[0, 1].Image == blue0 && pbArray[0, 2].Image == blue0)
            {
                GaveOverMessage("O");
            }

            if (pbArray[1, 0].Image == blue0 && pbArray[1, 1].Image == blue0 && pbArray[1, 2].Image == blue0)
            {
                GaveOverMessage("O");
            }

            if (pbArray[2, 0].Image == blue0 && pbArray[2, 1].Image == blue0 && pbArray[2, 2].Image == blue0)
            {
                GaveOverMessage("O");
            }

            if (pbArray[0, 0].Image == blue0 && pbArray[1, 1].Image == blue0 && pbArray[2, 2].Image == blue0)
            {
                GaveOverMessage("O");
            }

            if (pbArray[0, 2].Image == blue0 && pbArray[1, 1].Image == blue0 && pbArray[2, 0].Image == blue0)
            {
                GaveOverMessage("O");
            }

            if (numberOfClicks==9) //none of prior conditions met, TieMessage() called.
            {
                TieMessage();
            }  
        }

        /// <summary>
        /// This method clears the images from 
        /// the control and empties the 2D
        /// picture box array
        /// </summary>
        /// <param name="winner"></param>
        private void GaveOverMessage(string winner)
        {
          DialogResult dr= MessageBox.Show($"{winner} won!", "Game Over" , MessageBoxButtons.OK);

            if (dr == DialogResult.OK)
            {
                for (int i = 0; i < gbGame.Controls.Count; i++)
                {
                    PictureBox pb = (PictureBox)gbGame.Controls[i];
                    pb.Image = null;
                }

                for (int i = 0; i < pbArray.GetLength(0); i++)
                {
                    for (int j = 0; j < pbArray.GetLength(1); j++)
                    {
                        pbArray[i, j].Image = null;
                    }
                }

                numberOfClicks = 0;
            }
        }

        /// <summary>
        /// This method just displays the "Tie" message
        /// and clears the controls and 2D array of 
        /// pictureboxes. 
        /// </summary>
        private void TieMessage() 
        {
            DialogResult dr = MessageBox.Show("Tie");

            if (dr == DialogResult.OK)
            {
                for (int i = 0; i < gbGame.Controls.Count; i++)
                {
                    //this just clears the controls, not the array
                    PictureBox pb = (PictureBox)gbGame.Controls[i]; 
                    pb.Image = null;
                }

                for (int i = 0; i < pbArray.GetLength(0); i++)
                {
                    for (int j = 0; j < pbArray.GetLength(1); j++)
                    {
                        pbArray[i, j].Image = null;
                    }
                }

                numberOfClicks = 0;
            }
        }
    }
}
