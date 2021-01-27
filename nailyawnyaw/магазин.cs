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
    public delegate void событие();
    class магазин
    {
        public int PointX { get; set; }
        public int PointY { get; set; }
        public int SizeX { get; }
        public int SizeY { get; }
        public Color цвет { get; set; }
        public int продажи { get; set; }

        bool готовпродать = false;

        public покупатель покупатель1 { get; set; }

        public event событие выдатьчек;

        public магазин(int PointX1, int PointY1, int SizeX1, int SizeY1,Color цвет1,int продажи1,покупатель покупатель2)
        {
            PointX = PointX1;
            PointY = PointY1;
            SizeX = SizeX1;
            SizeY = SizeY1;
            покупатель1 = покупатель2;
            цвет = цвет1;
            продажи = продажи1;

        }
        public void построить(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(Color.Blue), PointX, PointY, SizeX, SizeY);
            if (готовпродать == true)
            {
                if (продажи <= 10)
                {
                    if (цвет == Color.Red)
                    {
                        e.Graphics.FillRectangle(new SolidBrush(цвет), PointX, PointY, SizeX, SizeY);
                        продажи += 1;
                        цвет = Color.Blue;
                        System.Threading.Thread.Sleep(500);
                    }
                    if (цвет == Color.Blue)
                    {
                        e.Graphics.FillRectangle(new SolidBrush(цвет), PointX, PointY, SizeX, SizeY);
                        продажи += 1;
                        цвет = Color.Red;
                        System.Threading.Thread.Sleep(500);
                    }
                }
                else
                {
                    выдатьчек();
                }
            }
        }    
        public void продать()
        {
            готовпродать = true;
        }
    }
}
