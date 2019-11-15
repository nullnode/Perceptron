
/*
 * Course: CS4242 Online
 * Name: Alex Henson
 * Student ID: 000244901
 * Assignment #3
 * Due Date: July 12, 2019
 * Signature: Alex Henson
 * Score:
 */
 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Perceptron
{
    public partial class Form1 : Form
    {
        string choice = "";
        int set = 0;

        // all the possible formations of the 2x2 black/white square
        int[,] trainingSets = new int[16, 4] {
                                                 { -1, -1, -1, -1 },
                                                 { -1, -1, -1, 1 },
                                                 { -1, -1, 1, -1 },
                                                 { -1, -1, 1, 1 },
                                                 { -1, 1, -1, -1 },
                                                 { -1, 1, -1, 1 },
                                                 { -1, 1, 1, -1 },
                                                 { -1, 1, 1, 1 },
                                                 { 1, -1, -1, -1 },
                                                 { 1, -1, -1, 1 },
                                                 { 1, -1, 1, -1 },
                                                 { 1, -1, 1, 1 },
                                                 { 1, 1, -1, -1 },
                                                 { 1, 1, -1, 1 },
                                                 { 1, 1, 1, -1 },
                                                 { 1, 1, 1, 1 }
                                                };
        // outputs in order of corresponding inputs, based on 2-4 white squares = bright, and 0-1 white squares = dark
        int[] outputs = { 0, 0, 0, 1, 0, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1 };
        double[] testSet = { 0, 0, 0, 0 }; // used for testing one set at a time
        int[] compare = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // used to store the results of the training session

        public Form1()
        {
            InitializeComponent();
            learn(); // learn() is called first and the results are stored in compare
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            choice = (string)checkedListBox1.SelectedItem;
            switch (choice)
            {
                case "1":
                    pictureBox1.BackColor = Color.Black;
                    pictureBox2.BackColor = Color.Black;
                    pictureBox3.BackColor = Color.Black;
                    pictureBox4.BackColor = Color.Black;
                    set = 0;
                    break;

                case "2":
                    pictureBox1.BackColor = Color.Black;
                    pictureBox2.BackColor = Color.Black;
                    pictureBox3.BackColor = Color.Black;
                    pictureBox4.BackColor = Color.White;
                    set = 1;
                    break;

                case "3":
                    pictureBox1.BackColor = Color.Black;
                    pictureBox2.BackColor = Color.Black;
                    pictureBox3.BackColor = Color.White;
                    pictureBox4.BackColor = Color.Black;
                    set = 2;
                    break;

                case "4":
                    pictureBox1.BackColor = Color.Black;
                    pictureBox2.BackColor = Color.Black;
                    pictureBox3.BackColor = Color.White;
                    pictureBox4.BackColor = Color.White;
                    set = 3;
                    break;

                case "5":
                    pictureBox1.BackColor = Color.Black;
                    pictureBox2.BackColor = Color.White;
                    pictureBox3.BackColor = Color.Black;
                    pictureBox4.BackColor = Color.Black;
                    set = 4;
                    break;

                case "6":
                    pictureBox1.BackColor = Color.Black;
                    pictureBox2.BackColor = Color.White;
                    pictureBox3.BackColor = Color.Black;
                    pictureBox4.BackColor = Color.White;
                    set = 5;
                    break;

                case "7":
                    pictureBox1.BackColor = Color.Black;
                    pictureBox2.BackColor = Color.White;
                    pictureBox3.BackColor = Color.White;
                    pictureBox4.BackColor = Color.Black;
                    set = 6;
                    break;

                case "8":
                    pictureBox1.BackColor = Color.Black;
                    pictureBox2.BackColor = Color.White;
                    pictureBox3.BackColor = Color.White;
                    pictureBox4.BackColor = Color.White;
                    set = 7;
                    break;

                case "9":
                    pictureBox1.BackColor = Color.White;
                    pictureBox2.BackColor = Color.Black;
                    pictureBox3.BackColor = Color.Black;
                    pictureBox4.BackColor = Color.Black;
                    set = 8;
                    break;

                case "10":
                    pictureBox1.BackColor = Color.White;
                    pictureBox2.BackColor = Color.Black;
                    pictureBox3.BackColor = Color.Black;
                    pictureBox4.BackColor = Color.White;
                    set = 9;
                    break;

                case "11":
                    pictureBox1.BackColor = Color.White;
                    pictureBox2.BackColor = Color.Black;
                    pictureBox3.BackColor = Color.White;
                    pictureBox4.BackColor = Color.Black;
                    set = 10;
                    break;

                case "12":
                    pictureBox1.BackColor = Color.White;
                    pictureBox2.BackColor = Color.Black;
                    pictureBox3.BackColor = Color.White;
                    pictureBox4.BackColor = Color.White;
                    set = 11;
                    break;

                case "13":
                    pictureBox1.BackColor = Color.White;
                    pictureBox2.BackColor = Color.White;
                    pictureBox3.BackColor = Color.Black;
                    pictureBox4.BackColor = Color.Black;
                    set = 12;
                    break;

                case "14":
                    pictureBox1.BackColor = Color.White;
                    pictureBox2.BackColor = Color.White;
                    pictureBox3.BackColor = Color.Black;
                    pictureBox4.BackColor = Color.White;
                    set = 13;
                    break;

                case "15":
                    pictureBox1.BackColor = Color.White;
                    pictureBox2.BackColor = Color.White;
                    pictureBox3.BackColor = Color.White;
                    pictureBox4.BackColor = Color.Black;
                    set = 14;
                    break;

                case "16":
                    pictureBox1.BackColor = Color.White;
                    pictureBox2.BackColor = Color.White;
                    pictureBox3.BackColor = Color.White;
                    pictureBox4.BackColor = Color.White;
                    set = 15;
                    break;
            }
        }

        private void checkedListBox1_MouseUp(object sender, MouseEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            int solve = compare[set];
            string answer = (outputs[set] > 0) ? answer = "BRIGHT" : answer = "DARK";
            //MessageBox.Show(solve.ToString());
            if (solve == 1)
            {
                textBox1.AppendText("I believe image " + (set + 1) + " is BRIGHT \n");
            } else
            {
                textBox1.AppendText("I believe image " + (set + 1) + " is DARK \n");
            }
            textBox1.AppendText("The correct answer is: " + answer);
        }

        private void learn()
        {
            // start off by randomizing some weights for each input, in this case a number between 0 and 1
            Random rand = new Random();
            double[] weight = { rand.NextDouble(), rand.NextDouble(), rand.NextDouble(), rand.NextDouble(), rand.NextDouble() };

            double learningRate = .1;
            double errorRate = 1;

            // iterate until our error rate is below .1
            while (errorRate > 0.1)
            {
                errorRate = 0;
                for (int i = 0; i < 16; i++)
                {
                    int output = getOutput(trainingSets[i, 0], trainingSets[i, 1], trainingSets[i, 2], trainingSets[i, 3], weight);
                    int error = outputs[i] - output;
                    weight[0] += learningRate * error * trainingSets[i, 0];
                    weight[1] += learningRate * error * trainingSets[i, 1];
                    weight[2] += learningRate * error * trainingSets[i, 2];
                    weight[3] += learningRate * error * trainingSets[i, 3];
                    weight[4] += learningRate * error * 1; // bias

                    errorRate += Math.Abs(error);
                }
            }
            for (int i = 0; i < 16; i++)
            {
                compare[i] = getOutput(trainingSets[i, 0], trainingSets[i, 1], trainingSets[i, 2], trainingSets[i, 3], weight);
            }
        }

        // takes in the 
        private static int getOutput(double node0, double node1, double node2, double node3, double[] weights)
        {
            double result = node0 * weights[0] + node1 * weights[1] + node2 * weights[2] + node3 * weights[3] + 1 * weights[4];
            //Console.Write(result + "   ");
            return (result >= 0 ? 1 : 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello! A perceptron is a simple neural network using a single neuron! \n" +
                            "We have 16 configurations for an image with 4 squares. If we have 0-1 \n" +
                            "light squares then the image is considered dark. If there are between \n" +
                            "2-4 light squares then the image is considered light! \n");               
        }
    }
}
