namespace Paint
{
    public partial class PictureForm : Form
    {
        public PictureForm()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            // 1. ����������� ��� � �������
            g.FillRectangle(Brushes.SaddleBrown, 50, 300, 100, 100); // ���
            g.FillPolygon(Brushes.DarkRed, new Point[] { new Point(50, 300), new Point(100, 250), new Point(150, 300) }); // �����
            g.FillEllipse(Brushes.LightBlue, 200, 300, 150, 100); // �����
            g.FillRectangle(Brushes.Green, 300, 350, 20, 50); // ������
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PaintForm newForm = new PaintForm();
            newForm.Show();
        }
    }
}
