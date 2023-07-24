using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

namespace First_GUI
{
    public partial class Form1 : Form
    {
        int timeCs = 0;
        int timeS = 0;
        int timeM = 0;
        int num = 0;
        int choose;
        bool isActive;
        bool isWin;
        int button;

        int[] points = { 2000, 3000, 4000, 5500, 9000};
        int tempNum, tempNum2;
        int scoreinput;
        int attempts = 0;
        Random random= new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)//This will run when the project start
        {
            int width = Screen.PrimaryScreen.Bounds.Width;//The height and width of the sreen
            int height = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(width, height);
            //ResetButton();
            //RandomNumber();

        }
        private void button1_Click(object sender, EventArgs e)//Start and Stop button
        {
            
            isActive = !isActive;
            if(isActive)
            {
                button1.Text = "STOP"; 
                RandomNumber();
            }
            else
            {
                button1.Text = "START";
                ShowResults1();
                ShowResults2();
            }
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            isActive = false;
        }


        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void timer3_Tick(object sender, EventArgs e)//This will loop
        {
            if(isActive)
            {
                Thread.Sleep(10);
                num ++;
                //timeCs++;
                
            }
                if(num >= 100)
                {
                    //timeS++;
                    Thread.Sleep(10);
                    num = 0;
                    //timeCs = 0;
                    
                }
                /*if(timeS >= 60)
                {
                    timeM++;
                    timeS= 0;
                }*/
            DrawTime();
        }

        private void DrawTime()
        {
            //The name of the buttons are wrong
            labelMin.Text = String.Format("{0:00}", num);
            //labelSec.Text = String.Format("{0:00}", timeS);
            //labelCs.Text = String.Format("{0:00}", timeM);

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
        private void ResetButton()//This will reset time
        {
            timeCs = 0;
            timeS = 0;
            timeM = 0;
            num = 0;
        }

        private void button3_Click(object sender, EventArgs e)//Reset button
        {
            //isActive= false;
            ResetButton();
            //Thread.Sleep(1000);
        }

        private void rnd_Click(object sender, EventArgs e)
        {

        }

        private void labelMin_Click(object sender, EventArgs e)
        {

        }
        public void RandomNumber()//Random Number
        {
            choose = random.Next(100);
            rnd.Text = String.Format("{0:00}", choose);
        }
        
        private void CheckWin_Click(object sender, EventArgs e)
        {

        }
        private void ShowResults1()//Checking if the player won or lose
        {
            if (num == choose)
            {
                isWin = true;     
            }
            else
            {
                isWin = false;

            }
        }
        private void ShowResults2()
        {
            if (isWin)
            {
                //CheckWin.Text = String.Format("You Win!");
                var newForm = new ThirdForm();
                newForm.Show();   
            }
            else
            {
                //CheckWin.Text = String.Format("You Loose!");
                var newForm = new SecondForm();
                newForm.Show();
                //Thread.Sleep(5000);
                //newForm.Hide();
            }
        }

        private void Score1_Click(object sender, EventArgs e)
        {
            //score1 = num;
            //Score1.Text = String.Format("{0:00}", score1);
        }

        private void Score2_Click(object sender, EventArgs e)
        {
            //score2 = 1000;
        }

        private void Score3_Click(object sender, EventArgs e)
        {
            //score3= 2000;
        }

        private void Score4_Click(object sender, EventArgs e)
        {
            //score4= 3000;
        }

        private void Score5_Click(object sender, EventArgs e)
        {
            //score5= 4000;
        }
        /// <summary>
        ///work in proces
        /// </summary>
        public void DrawScoreBoard()
        {
            for (int e = 0; e < 5; e++)
            {
                if (attempts == 8)
                {

                    e += 1;
                    if (scoreinput > points[e])
                    {
                        points[e] = scoreinput;
                        break;
                    }

                }

                if (scoreinput > points[e])//Va a comparar si el scoreinput es mayor que los Puntos
                {
                    tempNum = points[e];//Gualdad la posicion que esta el array.
                    tempNum2 = points[e + 1];//Gualda la posciondel proximo array.

                    //tempName = username[e];
                    //tempName2 = username[e + 1];

                    points[e] = scoreinput;//La posicion de este array es igual a el input del usario
                    //username[e] = usernameinput;

                    points[e + 1] = tempNum;//La posicion del proximo array ahora tiene el valor del tempNum(point[e])
                    //username[e + 1] = tempName;

                    e += 1;

                    while (e < 5)
                    {
                        //tempName = username[e + 1];//Gualdamos la posicion del proximo array en tempName
                        //username[e + 1] = tempName2;//Ahora el proximo array va tener la posicion
                        //tempName2 = tempName;//El valor que tiene tempName ahora lo tiene tempName2
                                             //Se hace lo mismo con los puntos

                        tempNum = points[e + 1];
                        points[e + 1] = tempNum2;
                        tempNum2 = tempNum;

                        e++;
                        attempts += 1;

                    }

                }


            }
        }
    }
}
