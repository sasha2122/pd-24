using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{

  

    public partial class Form1 : Form
    {
        int CursorX = Cursor.Position.X;
        int CursorY = Cursor.Position.Y;
        bool flag = false;
        bool flag2 = false;
        int i = 0;
        int j = 0;
        public Form1()
        {
            InitializeComponent();        
            this.timer1.Enabled = true;
            this.MouseMove += button1_MouseMove;
            this.button1.TabStop = false;
           
        }
        int b = 0;
        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            
            int delta = 30;
            int speed = 2;
            int bX = button1.Location.X;
            int bY = button1.Location.Y;
            int width = button1.Width;
            int height = button1.Height;

            if (e.X > (bX - delta) & e.Y < bY & e.X < bX & e.Y > (bY - delta))
            {
                this.button1.Location = new Point(bX + speed, bY + speed);
                if (b == 15)
                {
                 this.button1.Height -= 1;
                this.button1.Width -= 1;
                }
                b++;
            }
            else if(e.X > bX & e.Y < bY & e.X < bX + width & e.Y > bY - delta)
            {
                this.button1.Location = new Point(bX, bY + speed);
                if (b == 5)
                {
                    this.button1.Height -= 1;
                    this.button1.Width -= 1;
                }
                b++;
            }
            else if(e.X > bX + width & e.Y < bY & e.X < bX + width + delta & e.Y > bY - delta)
            {
                this.button1.Location = new Point(bX - speed, bY + speed);
                if (b == 5)
                {
                    this.button1.Height -= 1;
                    this.button1.Width -= 1;
                    
                }
                b++;
            }
            else if (e.X > (bX - delta) & (e.X < bX) & e.Y > bY & e.Y < bY + height) 
            {
                this.button1.Location = new Point(bX + speed, bY);
                if (b == 5)
                {
                    this.button1.Height -= 1;
                    this.button1.Width -= 1;

                }
                b++;
            }
            else if (e.X < (bX + delta + width) & (e.X > bX) & e.Y > bY & e.Y < bY + height) // влево
            {
                button1.Location = new Point(bX - speed, bY);
                if (b == 5)
                {
                    this.button1.Height -= 1;
                    this.button1.Width -= 1;
                }
                b++;
            }
            else if (e.X > (bX - delta) & e.Y > bY & e.X < bX & e.Y < (bY + delta + height))
            {
                this.button1.Location = new Point(bX + speed, bY - speed);
                if (b == 5)
                {
                    this.button1.Height -= 1;
                    this.button1.Width -= 1;
                }
                b++;
            }
            else if (e.X > bX & e.Y > bY & e.X < bX + width & e.Y < (bY + delta + height))
            {
                this.button1.Location = new Point(bX, bY - speed);
                if (b == 5)
                {
                    this.button1.Height -= 1;
                    this.button1.Width -= 1;
                }
                b++;
            }
            else if (e.X > bX + width & e.Y > bY & e.X < bX + width + delta & e.Y < (bY + delta + height))
            {
                this.button1.Location = new Point(bX - speed, bY - speed);
                if (b == 5)
                {
                    this.button1.Height -= 1;
                    this.button1.Width -= 1;
                }
                b++;
            }
            
            if (b == 6)
            {
                b = 0;
            }
       
            if (bX >= this.Size.Width - this.button1.Width || bY >= this.Size.Height - this.button1.Height - 30)
            {
                this.button1.Location = new Point(bX - 75, bY - 75);
            }
            if (bX <= 0 || bY <= 0)
            {
                this.button1.Location = new Point(bX + 70, bY + 70);
            }
            if(this.button1.Height == 1 || this.button1.Width == 1)
            {
                this.timer2.Enabled = true;
            }

        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            
        }
        private void button1_MouseEnter(object sender, EventArgs e)
        {

        }
        private void button1_MouseLeave(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if (flag)
            {
                this.Text = "Click 'OK' to continue!";
                flag = false;
            }
            else
            {
                this.Text = "";
                flag = true;
            }

            if (i == 7)
            {
                this.timer1.Stop();
            }
            i++;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Кнопка Ок натиснена");
           
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            
            if (flag2)
            {
                this.Text = "'OK' will never be clicked!";
                flag2 = false;
            }
            else
            {
                this.Text = "";
                flag2 = true;
            }
            if (j >= 7)
            {
                this.timer2.Stop();
            }

            j++;
        }

        private void button1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                e.Handled = true;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (!msg.HWnd.Equals(this.Handle) && (keyData == Keys.Left || keyData == Keys.Down || keyData == Keys.Up ||
                                                  keyData == Keys.Right))
                return true;
            return base.ProcessCmdKey(ref msg, keyData);
        }


    }
}
