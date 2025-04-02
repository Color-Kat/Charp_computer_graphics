namespace _03._Primitive_Shapes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.Paint += Form1_Paint;
        }

        private void Form1_Paint(object sender, PaintEventArgs e) {

            // Create tools for graphics
            Graphics g = e.Graphics;
            Pen solidPen = new Pen(Color.Black, 3);
            Pen dashedPen = new Pen(Color.Black, 3);
            dashedPen.DashPattern = [5, 5];

            // --- 0. Add primitive - rectangle --- //
            g.DrawRectangle(solidPen, 10, 10, 100, 50);

            // --- 2.1 Cylinder --- //
            DrawCylindr(g, solidPen, dashedPen);

            // --- 2.2 Dimonds Pattern --- //
            DrawDiamonds(g, solidPen);

            // --- 7.1 Trapezoid --- //
            DrawTrapezoid(g, solidPen, dashedPen);

            // --- 7.2 Cycle ornament --- //
            DrawPattern7(g, solidPen);
        }

        private void DrawCylindr(Graphics g, Pen solidPen, Pen dashedPen)
        {
            int centerX = 200, centerY = 200;
            int radius = 60, height = 120;

            // Top ellips
            g.DrawEllipse(solidPen, centerX - radius, centerY - 20, 2 * radius, 40);

            // Left adn right bound
            g.DrawLine(solidPen, centerX - radius, centerY, centerX - radius, centerY + height);
            g.DrawLine(solidPen, centerX + radius, centerY, centerX + radius, centerY + height);

            // Bottom ellips
            g.DrawArc(dashedPen, centerX - radius, centerY + height - 20, 2 * radius, 40, 180, 180);
            g.DrawArc(solidPen, centerX - radius, centerY + height - 20, 2 * radius, 40, 0, 180);

            // Formula
            Font font = new Font("Arial", 14);
            g.DrawString("V = πr^2h", font, Brushes.Black, new PointF(150, centerY + height + 30));
    
        }

        private void DrawDiamonds(Graphics g, Pen pen)
        {
            int size = 60;

            for (int i = 0; i < 4; i++)
            {
                DrawDiamond(g, pen, 200 + i * size, 60, size);
            }
        }

        private void DrawDiamond(Graphics g, Pen pen, int x, int y, int size)
        {
            Point[] diamondPoints = {
                new Point(x, y - size / 2),   
                new Point(x + size / 2, y),   
                new Point(x, y + size / 2),   
                new Point(x - size / 2, y),   
                new Point(x, y - size / 2)
            };

            g.DrawPolygon(pen, diamondPoints);
        }

        private void DrawTrapezoid(Graphics g, Pen solidPen, Pen dashedPen)
        {
            int baseTop = 60;
            int baseBottom = 140;
            int leftX = 500, rightX = 700;
            int topLeftX = 550, topRightX = 650;
            int centerX = (topLeftX + topRightX) / 2;

            // Points of trapezoid
            Point[] trapezoidPoints = {
                new Point(topLeftX, baseTop),   
                new Point(topRightX, baseTop),  
                new Point(rightX, baseBottom),  
                new Point(leftX, baseBottom),   
                new Point(topLeftX, baseTop)    
            };

            // Draw it as a polygon
            g.DrawPolygon(solidPen, trapezoidPoints);

            // Height
            g.DrawLine(dashedPen, centerX, baseTop, centerX, baseBottom);

            // Formula
            Font font = new Font("Arial", 14);
            g.DrawString("S = (a + b) * h / 2", font, Brushes.Black, new PointF(leftX, baseBottom + 20));

        }

        private void DrawPattern7(Graphics g, Pen pen)
        {
            Brush brush = new SolidBrush(Color.LightGray); // Цвет закраски
            int waves = 4; // Количество дуг
            int width = this.ClientSize.Width / waves; // Ширина каждой дуги
            int height = 100; // Высота дуг

            for (int wave = 0; wave < waves; wave++)
            {
                // Рисуем закрашенную дугу (полуовал)
                Rectangle rect = new Rectangle(
                    wave * width,
                    this.ClientSize.Height - height, // Центрируем по вертикали
                    width,
                    height
                );
                g.FillPie(brush, rect, 0, 180); // Закрашиваем нижнюю половину эллипса (дугу)
                g.DrawPie(pen, rect, 0, 180); // Рисуем контур дуги
            }
        }
    }
}
