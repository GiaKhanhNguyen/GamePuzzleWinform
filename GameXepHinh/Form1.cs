using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameXepHinh
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Init();
            Setmap();
            ShowpB();
        }
        private int x, y;
        private int[] A = new int[9];
        //khởi tạo giá trị ban đầu cho mảng có giá trị từ 1-9 và các giá trị ban đầu của biến
        private void InitA()
        {
            for(int i = 1; i <= 9; i++)
            {
                A[i - 1] = i;
            }
        }
        private void Init()
        {
            x = y = 2;
            InitA();
            pBmain.Image = GameXepHinh.Properties.Resources.main;
        }
        //hàm trả về vị trí của picture trên mảng
        private int getvt(int x, int y)
        {
            return x + 3 * y;
        }
        //hàm load ảnh ra đúng với giá trị
        private void getanh(PictureBox pB, int a)
        {
            switch(a)
            {
                case 1: pB.Image = GameXepHinh.Properties.Resources._1; break;
                case 2: pB.Image = GameXepHinh.Properties.Resources._2; break;
                case 3: pB.Image = GameXepHinh.Properties.Resources._3; break;
                case 4: pB.Image = GameXepHinh.Properties.Resources._4; break;
                case 5: pB.Image = GameXepHinh.Properties.Resources._5; break;
                case 6: pB.Image = GameXepHinh.Properties.Resources._6; break;
                case 7: pB.Image = GameXepHinh.Properties.Resources._7; break;
                case 8: pB.Image = GameXepHinh.Properties.Resources._8; break;
                case 9: pB.Image = null; pB.BackColor = Color.White; break;
            }
        }
        //hàm load ảnh lên picturebox
        private void ShowpB()
        {
            getanh(pB1, A[0]);
            getanh(pB2, A[1]);
            getanh(pB3, A[2]);
            getanh(pB4, A[3]);
            getanh(pB5, A[4]);
            getanh(pB6, A[5]);
            getanh(pB7, A[6]);
            getanh(pB8, A[7]);
            getanh(pB9, A[8]);
        }
        //hàm di chuyển các hình ảnh
        private void Move_left()
        {
            if(x > 0)
            {
                int t = A[getvt(x, y)];
                A[getvt(x, y)] = A[getvt(x - 1, y)];
                A[getvt(x - 1, y)] = t;
                x--;
                ShowpB();
            }
        }
        private void Move_right()
        {
            if (x < 2)
            {
                int t = A[getvt(x, y)];
                A[getvt(x, y)] = A[getvt(x + 1, y)];
                A[getvt(x + 1, y)] = t;
                x++;
                ShowpB();
            }
        }
        private void Move_top()
        {
            if (y > 0)
            {
                int t = A[getvt(x, y)];
                A[getvt(x, y)] = A[getvt(x, y - 1)];
                A[getvt(x, y - 1)] = t;
                y--;
                ShowpB();
            }
        }
        private void Move_bottom()
        {
            if (y < 2)
            {
                int t = A[getvt(x, y)];
                A[getvt(x, y)] = A[getvt(x, y + 1)];
                A[getvt(x, y + 1)] = t;
                y++;
                ShowpB();
            }
        }
        //hàm xáo trộn các hình ảnh
        Random rd = new Random();
        private void Setmap()
        {
            for(int i = 0; i < 20; i++)
            {
                int rrd = rd.Next(1, 5);
                switch(rrd)
                {
                    case 1: Move_top(); break;
                    case 2: Move_right(); break;
                    case 3: Move_left(); break;
                    case 4: Move_bottom(); break;
                }
            }
            int t = A[getvt(x, y)];
            A[getvt(x, y)] = A[8];
            A[8] = t;
            x = 2;
            y = 2;
            ShowpB();
        }
        //hàm xử lý di chuyển
        private void btn_XulyMove_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left)
            {
                Move_right();
            }
            if (e.KeyCode == Keys.Right)
            {
                Move_left();
            }
            if (e.KeyCode == Keys.Up)
            {
                Move_bottom();
            }
            if (e.KeyCode == Keys.Down)
            {
                Move_top();
            }
            if(checkwin() == true)
            {
                MessageBox.Show("Bạn Thật Giỏi");
                Init();
                Setmap();
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            Init();
            Setmap();
        }
        private bool checkwin()
        {
            for(int i = 1; i < 10; i++)
            {
                if (A[i - 1] != i)
                    return false;
            }
            return true;
        }
    }
}
