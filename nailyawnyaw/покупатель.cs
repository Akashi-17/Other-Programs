using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nailyawnyaw
{
    class покупатель
    {
        public int PointX { get; set; }
        public int PointY { get; set; }
        public int SizeX { get; }
        public int SizeY { get; }
        public int speed { get; set; }
        public int счетпокупок { get; set; }
        public bool закупился { get; set; }
        public Color цвет { get; set; }

        магазин магазин1;
        
        public event событие оплата;
        public покупатель(int PointX1, int PointY2, int SizeX2, int SizeY2, int speed1, Color цвет1,int счётпокупок1,bool закупился1,магазин магазин2)
        {
            PointX = PointX1;
            PointY = PointY2;
            SizeX = SizeX2;
            SizeY = SizeY2;
            speed = speed1;
            цвет = цвет1;
            счетпокупок = счётпокупок1;
            закупился = закупился1;
            магазин1 = магазин2;
        }
        public void пойтивмагазин(object sender, PaintEventArgs e)
        {
           
            if (закупился == false)
            {
                if (PointY >= 230)
                {
                    PointY -= speed;
                }
                else
                {
                    if (счетпокупок <= 10)
                    {
                        if (цвет == Color.Blue)
                        {
                            e.Graphics.FillEllipse(new SolidBrush(цвет), PointX, PointY, SizeX, SizeY);
                            счетпокупок += 1;
                            цвет = Color.Red;
                            System.Threading.Thread.Sleep(500);
                        }
                        if (цвет == Color.Red)
                        {
                            e.Graphics.FillEllipse(new SolidBrush(цвет), PointX, PointY, SizeX, SizeY);
                            счетпокупок += 1;
                            цвет = Color.Blue;
                            System.Threading.Thread.Sleep(500);
                        }
                    }
                    else
                    {
                       оплата();
                    }
                }
            }
            else
            {
                if (PointY >= 0)
                {
                    PointY -= speed;
                }
            }
            e.Graphics.DrawEllipse(new Pen(Color.Red), PointX, PointY, SizeX, SizeY);
        }
        public void уйти()
        {
            закупился = true;
        }
    }
}
