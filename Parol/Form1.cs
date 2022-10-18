using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parol
{
    public partial class Form1 : Form
    {
        Button[] buttons;
        Color[] btnColors;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            buttons = new Button[]{button1,button2,button3,button4,button5,button6,button7,button8};
            btnColors = new Color[buttons.Length];
            for (int i = 0; i < btnColors.Length; i++)
            {
                btnColors[i] = Color.Transparent;
            }
            timer1.Start();
        }

        private void submit_Click(object sender, EventArgs e)
        {
            //setButtonColor(IndexBox.Text)
            try
            {
                int index = Convert.ToInt32(IndexBox.Text);
                Color color = stringtoColor(ColorBox.Text);
                setButtonColor(index -1, color);
            }
            catch (Exception err)
            {
                MessageBox.Show("Invalid: "+ err.Message);
            }

        }
        Color stringtoColor(String str)
        {
            switch (str.ToLower())
            {
                case "red":return Color.Red;
                case "blue":return Color.Blue;
                case "green":return Color.Green;
                case "yellow":return Color.Yellow;
                case "violet":return Color.Violet;
                case "brown":return Color.Brown;
                case "black":return Color.Black;
                default:return Color.Transparent;
            }
        }
        void setButtonColor(int index,Color color)
        {
            buttons[index].BackColor = color;
            btnColors[index] = color;
        }
        bool blink = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            clearAllBtnColor();
            for (int i = 0; i < buttons.Length; i++)
            {
                if (blink == true)
                {
                    if (i % 2 == 0) buttons[i].BackColor = btnColors[i];
                }
                else
                {
                    if (i % 2 != 0) buttons[i].BackColor = btnColors[i];
                }
            }
            blink = !blink;
        }
        void clearAllBtnColor()
        {
            foreach (Button button in buttons)
            {
                button.BackColor = Color.Transparent;
            }
        }
    }
}
