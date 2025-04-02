using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class PaintForm : Form
    {
        public PaintForm()
        {
            InitializeComponent();
            SetupControls();
        }

        private string selectedPrimitive = "Rectangle"; // Примитив по умолчанию
        private Color shapeColor = Color.Black; // Цвет примитива по умолчанию

        // Настройка элементов управления
        private void SetupControls()
        {
            // Создание ListBox для выбора примитивов
            ListBox primitiveListBox = new ListBox();
            primitiveListBox.Location = new Point(10, 10);
            primitiveListBox.Size = new Size(150, 100);
            primitiveListBox.Items.AddRange(new string[] { "Rectangle", "Ellipse", "Line" });
            primitiveListBox.SelectedIndexChanged += PrimitiveListBox_SelectedIndexChanged;
            primitiveListBox.SelectedIndex = 0; // Выбор первого элемента по умолчанию
            this.Controls.Add(primitiveListBox);

            // Создание ListBox для выбора цвета фона
            ListBox backgroundColorListBox = new ListBox();
            backgroundColorListBox.Location = new Point(170, 10);
            backgroundColorListBox.Size = new Size(150, 100);
            backgroundColorListBox.Items.AddRange(new string[] { "White", "Red", "Blue", "Green", "Yellow" });
            backgroundColorListBox.SelectedIndexChanged += BackgroundColorListBox_SelectedIndexChanged;
            backgroundColorListBox.SelectedIndex = 0;
            this.Controls.Add(backgroundColorListBox);

            // Создание ListBox для выбора цвета фигуры
            ListBox shapeColorListBox = new ListBox();
            shapeColorListBox.Location = new Point(330, 10);
            shapeColorListBox.Size = new Size(150, 100);
            shapeColorListBox.Items.AddRange(new string[] { "Black", "Red", "Blue", "Green", "Purple" });
            shapeColorListBox.SelectedIndexChanged += ShapeColorListBox_SelectedIndexChanged;
            shapeColorListBox.SelectedIndex = 0;
            this.Controls.Add(shapeColorListBox);

            // Настройка формы
            this.Size = new Size(600, 400);
            this.Paint += Form1_Paint;
        }

        // Обработчик выбора примитива
        private void PrimitiveListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedPrimitive = ((ListBox)sender).SelectedItem.ToString();
            this.Invalidate(); // Перерисовка формы
        }

        // Обработчик выбора цвета фона
        private void BackgroundColorListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedColor = ((ListBox)sender).SelectedItem.ToString();
            switch (selectedColor)
            {
                case "White":
                    this.BackColor = Color.White;
                    break;
                case "Red":
                    this.BackColor = Color.Red;
                    break;
                case "Blue":
                    this.BackColor = Color.Blue;
                    break;
                case "Green":
                    this.BackColor = Color.Green;
                    break;
                case "Yellow":
                    this.BackColor = Color.Yellow;
                    break;
            }
            this.Invalidate();
        }

        // Обработчик выбора цвета фигуры
        private void ShapeColorListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedColor = ((ListBox)sender).SelectedItem.ToString();
            switch (selectedColor)
            {
                case "Black":
                    shapeColor = Color.Black;
                    break;
                case "Red":
                    shapeColor = Color.Red;
                    break;
                case "Blue":
                    shapeColor = Color.Blue;
                    break;
                case "Green":
                    shapeColor = Color.Green;
                    break;
                case "Purple":
                    shapeColor = Color.Purple;
                    break;
            }
            this.Invalidate();
        }

        // Отрисовка примитивов
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(shapeColor, 2);
            int x = 200, y = 150, width = 100, height = 100;

            switch (selectedPrimitive)
            {
                case "Rectangle":
                    g.DrawRectangle(pen, x, y, width, height);
                    break;
                case "Ellipse":
                    g.DrawEllipse(pen, x, y, width, height);
                    break;
                case "Line":
                    g.DrawLine(pen, x, y, x + width, y + height);
                    break;
            }
        }
    }
}
