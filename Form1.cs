using tom.GameGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using EZInput;

namespace tom
{
    public partial class Form1 : Form
    {

        Tom tom;
        Fire fire;
        public static int Score = 0;
        public static int Health = 3;
        GameGrid grid;
        public static List<Ghost> ghosts = new List<Ghost>();
        public static List<FireList> fireLists = new List<FireList>();

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Keyboard.IsKeyPressed(Key.UpArrow))
            {
                tom.move(GameDirection.Up);
            }

            if (Keyboard.IsKeyPressed(Key.DownArrow))
            {
                tom.move(GameDirection.Down);
            }

            if (Keyboard.IsKeyPressed(Key.RightArrow))
            {
                tom.move(GameDirection.Right);
            }

            if (Keyboard.IsKeyPressed(Key.LeftArrow))
            {
                tom.move(GameDirection.Left);
            }

            if (Keyboard.IsKeyPressed(Key.Space))
            {
                Image fireImage = Game.getGameObjectImage('f');
                GameCell fireCell = grid.getCell(tom.CurrentCell.X - 1, tom.CurrentCell.Y);
                FireList firelIst = new Fire(fireImage, fireCell);
                fireLists.Add(firelIst);
            }
            moveFire();
            moveGhost();
            textBox2.Text = Score.ToString();
            textBox5.Text = Health.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            grid = new GameGrid("maze.txt", 15, 29);

            Image tomImage = Game.getGameObjectImage('T');
            Image turtleImage = Game.getGameObjectImage('G');
            Image cheetaImage = Game.getGameObjectImage('g');
            Image bouncyImage = Game.getGameObjectImage('b');
           

            GameCell startCell = grid.getCell(14, 3);
            GameCell turtleCell = grid.getCell(8, 27);
            GameCell cheetaCell = grid.getCell(3, 4);
            for (int x = 4; x < 30; x = x + 10)
            {
                GameCell bouncyCell = grid.getCell(0, x);
                Ghost bouncy = new Bouncy(bouncyImage, bouncyCell);
                ghosts.Add(bouncy);
            }

            tom = new Tom(tomImage, startCell);
            Ghost turtle = new Turtle(turtleImage, turtleCell);
            Ghost cheeta = new Cheeta(cheetaImage, cheetaCell);

            printMaze(grid);
            ghosts.Add(turtle);
            ghosts.Add(cheeta);
        }
        void printMaze(GameGrid grid)
        {
            for (int x = 0; x < grid.Rows; x++)
            {
                for (int y = 0; y < grid.Cols; y++)
                {
                    GameCell cell = grid.getCell(x, y);
                    this.Controls.Add(cell.PictureBox);
                }
            }
        }

        public static void moveGhost()
        {
            foreach (Ghost g in ghosts)
            {
                g.Move();
            }

        }

        public static void moveFire()
        {
            if(fireLists.Count() > 0)
            {
                for (int i = 0; i < fireLists.Count(); i++)
                {
                    fireLists[i].FireMove();
                }
            }
            
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        public static void DecreaseHealth()
        {
            Health -= 1;
            if (Health == 0)
            {
                MessageBox.Show("Game Over!");
                End end = new End();
                end.Show();
                //Application.Exit();
            }
            
        }

        public static void increaseScore()
        {
            Score += 2;
            if (Score == 10)
            {
                MessageBox.Show("You won the Game!!");
                Win win = new Win();
                win.Show();
                //Application.Exit();
            }
        }
    
        public void resetTom()
        {
            Image tomImage = Game.getGameObjectImage('T');
            grid = new GameGrid("maze.txt", 15, 29);
            GameCell startCell = grid.getCell(14, 3);
            tom = new Tom(tomImage, startCell);
           // printMaze(grid);
        }
    }
}
