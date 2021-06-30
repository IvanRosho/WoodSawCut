using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WoodSawCut {
    public partial class DelPlank : Form {
        List<Plank> Planks;
        List<Label> Labels;
        Graphics Field;
        System.Drawing.Drawing2D.GraphicsState gs;
        Microsoft.VisualBasic.PowerPacks.ShapeContainer sc;
        bool move;
        Point current;
        public DelPlank() {
            InitializeComponent();
            Planks = new List<Plank>();
            Labels = new List<Label>();
            //Planks = new List<Label>();
            Field = FieldPanel.CreateGraphics();
            
        }



        private void DrawPlanks(){
            foreach (Plank p in Planks) {
                SolidBrush Brush = new SolidBrush(p.Color);
                Field.DrawRectangle(new Pen(Color.Black),p.GetRectangle());
                Field.FillPolygon(Brush, p.GetPoints());
                Field.DrawString(p.ToString(), new Font("Arial", (float)(p.Width / 2f), FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black),p.GetPointToText());
            }
        }

        private void AddPlank_Click(object sender, EventArgs e) {
            WoodShape_Click(sender, e);
            Planks.Add(new Plank((int)WeigthPlank.Value, (int)WidthPlank.Value, (double)LengthPlank.Value * 1000, 0.0, ColorPanel.BackColor));
            Labels.Add(new Label());
            Labels.Last().Location = Planks.Last().GetPoints()[0];
            Labels.Last().AutoSize = false;
            Labels.Last().Width = (int)WidthPlank.Value;
            Labels.Last().Height = (int)WeigthPlank.Value;
            Labels.Last().TextAlign = ContentAlignment.MiddleCenter;
            Labels.Last().Text = Planks.Count + ": " + Planks.Last().ToString();
            Labels.Last().BackColor = Planks.Last().Color;
            Labels.Last().Font = new Font("Arial", 20f, FontStyle.Bold);
            Labels.Last().BorderStyle = BorderStyle.FixedSingle;
            Labels.Last().Tag = "Plank";
            Labels.Last().Name = String.Format("P{0}", Planks.Count);
            Labels.Last().BringToFront();
            Labels.Last().Text = String.Format("{0}: {1}", Planks.Count, Planks.Last().ToString());
            Labels.Last().MouseMove += new System.Windows.Forms.MouseEventHandler(this.Plank_MouseMove);
            Labels.Last().MouseDown += new System.Windows.Forms.MouseEventHandler(this.Plank_MouseDown);
            Labels.Last().MouseUp += new System.Windows.Forms.MouseEventHandler(this.Plank_MouseUp);
            FieldPanel.Controls.Add(Labels.Last());
            PlanksBox.Items.Add(Planks.Last().ToString());
        }
        /// <summary>
        /// Обновление данных
        /// </summary>
        /// <param name="p">true - Из досок в метки, false - из меток в доски</param>
        private void RefreshPosition(bool p) {
            PlanksBox.Items.Clear();
            if (p == true) { //из досок в метки
                for (int i = 0; i < Planks.Count; i++) {
                    Labels[i].Location = new Point((int)Planks[i].Left, (int)Planks[i].Top);
                    Labels[i].Width = (int)Planks[i].Width;
                    Labels[i].Height = (int)Planks[i].Height;
                    Labels[i].Text = (i + 1) + ": " + Planks[i].ToString();
                    PlanksBox.Items.Add(Planks[i].ToString());
                }
            }
            else {
                for (int i = 0; i < Planks.Count; i++) {
                    Planks[i].X = Labels[i].Left + Labels[i].Width/2;
                    Planks[i].Y = Labels[i].Top + Labels[i].Height/2;
                    Planks[i].Width = Labels[i].Width;
                    Planks[i].Height = Labels[i].Height;
                    Labels[i].Text = (i + 1) + ": " + Planks[i].ToString();
                    PlanksBox.Items.Add(Planks[i].ToString());
                }
            }
        }

        private void Plank_MouseMove(object sender, MouseEventArgs e) {
            if (move && (string)((sender as Label).Tag) == "Plank") {
                Point newlocation = (sender as Label).Location;
                newlocation.X += e.X - current.X;
                newlocation.Y += e.Y - current.Y;
                (sender as Label).Location = newlocation;
                RefreshPosition(false);
            }
        }
        private void Plank_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                move = true;
                current = new Point(e.X, e.Y);
            }
        }
        private void Plank_MouseUp(object sender, MouseEventArgs e) {
            move = false;
            if (e.Button == MouseButtons.Right && (string)((sender as Label).Tag) == "Plank")
            {
                int index = FieldPanel.Controls.IndexOf(sender as Label);
                Planks[index].Rotate();
                RefreshPosition(true);
            }
        }
        private void ColorPanel_Click(object sender, EventArgs e) {
            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) ColorPanel.BackColor = colorDialog.Color; 
        }

        private void RemovePlank_Click(object sender, EventArgs e) {
            WoodShape_Click(sender, e);
            if (PlanksBox.SelectedIndex == -1) return;
            FieldPanel.Controls.Remove(Labels[PlanksBox.SelectedIndex]);
            Labels.RemoveAt(PlanksBox.SelectedIndex);
            Planks.RemoveAt(PlanksBox.SelectedIndex);
            PlanksBox.Items.RemoveAt(PlanksBox.SelectedIndex);
            //RefreshPosition();
        }

        private void BoxingPlanks_Click(object sender, EventArgs e) {
            WoodShape_Click(sender, e);
            if (Planks.Count == 0) return;
            var tempPlanks = Planks.OrderByDescending(t => t.Area).ToList<Plank>(); //Сортируем планки по размеру по убыванию
            var PackingPlanks = new List<Plank>();                                  //лист упакованных планок
            PackingPlanks.Add(tempPlanks.First());
            if (PackingPlanks[0].Orientation != 1) PackingPlanks[0].Rotate();       //уложили первую планку в центр
            PackingPlanks[0].X = 0;
            PackingPlanks[0].Y = 0;
            tempPlanks.RemoveAt(0);
            int orr = 1;
            int tp = tempPlanks.Count / 2;
            for (int i = 0; i < tp; i++) {
                try {
                    if (orr == 1) {
                        if (tempPlanks.First().Orientation != orr) tempPlanks.First().Rotate();
                        tempPlanks.First().X = PackingPlanks.First().X;
                        tempPlanks.First().Bottom = PackingPlanks.Min(t => t.Top);
                        PackingPlanks.Add(tempPlanks.First());
                        tempPlanks.RemoveAt(0);
                        if (tempPlanks.First().Orientation != orr) tempPlanks.First().Rotate();
                        tempPlanks.First().X = PackingPlanks.First().X;
                        tempPlanks.First().Top = PackingPlanks.Max(t => t.Bottom);
                        PackingPlanks.Add(tempPlanks.First());
                        tempPlanks.RemoveAt(0);
                    }
                    if (orr == -1) {
                        if (tempPlanks.First().Orientation != orr) tempPlanks.First().Rotate();
                        tempPlanks.First().Y = PackingPlanks.First().Y;
                        tempPlanks.First().Left = PackingPlanks.Max(t => t.Right);
                        PackingPlanks.Add(tempPlanks.First());
                        tempPlanks.RemoveAt(0);
                        if (tempPlanks.First().Orientation != orr) tempPlanks.First().Rotate();
                        tempPlanks.First().Y = PackingPlanks.First().Y;
                        tempPlanks.First().Right = PackingPlanks.Min(t => t.Left);
                        PackingPlanks.Add(tempPlanks.First());
                        tempPlanks.RemoveAt(0);
                    }
                    orr *= -1;
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            if (tempPlanks.Count != 0) {
                tempPlanks[0].Right = PackingPlanks.First().Left;
                tempPlanks[0].Bottom = PackingPlanks.First().Top;
                PackingPlanks.Add(tempPlanks[0]);
                tempPlanks.RemoveAt(0);
            }
            Planks = PackingPlanks;
            double d = Planks.Max(t=>t.Distance())*2;
            double left = Planks.Min(t => t.Left) -d / 10.0;
            double top = Planks.Min(u => u.Top) -d / 10.0;
            foreach (var p in Planks) {
                p.Left -= left;
                p.Top -= top;
            }
            Report.Text = "";
            Report.AppendText(String.Format("Диаметр бревна {0} мм\n\n", d));
            foreach (var p in Planks)
            {
                Report.AppendText(String.Format("Доска {0} положение по X: {1}; Положение по Y:{2}\n\n", p.ToString(), Math.Round(p.X,2), Math.Round(p.Y,2)));
            }
            RefreshPosition(true);
            Microsoft.VisualBasic.PowerPacks.OvalShape osh = new Microsoft.VisualBasic.PowerPacks.OvalShape();
            osh.Size = new Size((int)d,(int)d);
            osh.Location = new Point((int)(Planks.First().X - d / 2.0), (int)(Planks.First().Y - d / 2.0));
            osh.BorderWidth = 2;
            osh.BorderColor = Color.Maroon;
            osh.Visible = true;
            sc = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            sc.Name = "sc";
            FieldPanel.Controls.Add(sc);
            (FieldPanel.Controls[FieldPanel.Controls.Count-1] as Microsoft.VisualBasic.PowerPacks.ShapeContainer).Shapes.Add(osh);
            osh.Click += new System.EventHandler(this.WoodShape_Click);
            //Field.DrawEllipse(new Pen(Color.Brown), (float)(Planks.First().X - d/2.0), (float)(Planks.First().Y - d/2.0), (float)(d), (float)(d));

        }

        private void CheckPlanks_Click(object sender, EventArgs e) {
            WoodShape_Click(sender, e);
            if (Planks.Count == 0) return;
            for (int i = 0; i < Planks.Count - 1; i++)
            {
                for (int j = i + 1; j < Planks.Count; j++)
                {
                    if (Planks[j].Orientation == 1 && Planks[i].Orientation == 1) {
                        if ((Planks[i].Top > Planks[j].Top && Planks[i].Top < Planks[j].Bottom) && //общее для 1-2-3
                            ((Planks[i].Left > Planks[j].Left && Planks[i].Left < Planks[j].Right) || //1
                            (Planks[i].Left < Planks[j].Left && Planks[i].Right > Planks[j].Right) || //2
                            (Planks[i].Right < Planks[j].Right && Planks[i].Right > Planks[j].Left))) { //3
                            Planks[j].Bottom = Planks[i].Top;
                            continue;
                        }
                        if (Planks[i].Right>Planks[j].Left && Planks[i].Right<Planks[j].Right && Planks[i].Top<Planks[j].Top && Planks[i].Bottom>Planks[j].Bottom){
                            Planks[j].Left = Planks[i].Right; //4
                            continue;
                        }
                        if ((Planks[i].Bottom < Planks[j].Bottom && Planks[i].Bottom > Planks[j].Top) && //общее для 5-6-7
                            ((Planks[i].Right < Planks[j].Right && Planks[i].Right > Planks[j].Left) || //5
                            (Planks[i].Left < Planks[j].Left && Planks[i].Right > Planks[j].Right) || //6
                            (Planks[i].Left > Planks[j].Left && Planks[i].Left < Planks[j].Right))) { //7
                            Planks[j].Top = Planks[i].Bottom;
                            continue;
                        }
                        if (Planks[i].Left > Planks[j].Left && Planks[i].Left < Planks[j].Right && Planks[i].Top < Planks[j].Top && Planks[i].Bottom > Planks[j].Bottom) {
                            Planks[j].Right = Planks[i].Left; //8
                            continue;
                        }
                    }
                    else if (Planks[i].Orientation == -1 && Planks[j].Orientation == -1) {
                        if ((Planks[i].Right > Planks[j].Left && Planks[i].Right < Planks[j].Right) && //общее для 3-4-5
                            ((Planks[i].Top > Planks[j].Top && Planks[i].Top < Planks[j].Bottom) || //3
                            (Planks[i].Top < Planks[j].Top && Planks[i].Bottom > Planks[j].Bottom) || //4
                            (Planks[i].Bottom < Planks[j].Bottom && Planks[i].Bottom > Planks[j].Top))) { //5
                            Planks[j].Left = Planks[i].Right;
                            continue;
                        }
                        if (Planks[i].Left < Planks[j].Left && Planks[i].Right > Planks[j].Right && Planks[i].Bottom < Planks[j].Bottom && Planks[i].Bottom < Planks[j].Top) {
                            Planks[j].Top = Planks[i].Bottom; //6
                            continue;
                        }
                        if ((Planks[i].Left > Planks[j].Left && Planks[i].Left < Planks[j].Right) && //общее для 7-8-1
                            ((Planks[i].Bottom < Planks[j].Bottom && Planks[i].Bottom > Planks[j].Top) || //7
                            (Planks[i].Top < Planks[j].Top && Planks[i].Bottom > Planks[j].Bottom) || //8
                            (Planks[i].Top > Planks[j].Top && Planks[i].Top < Planks[j].Bottom))) { //1
                            Planks[j].Right = Planks[i].Left;
                            continue;
                        }
                        if (Planks[i].Left < Planks[j].Left && Planks[i].Right > Planks[j].Right && Planks[i].Top > Planks[j].Bottom && Planks[i].Top < Planks[j].Top) {
                            Planks[j].Bottom = Planks[i].Top; //2
                            continue;
                        }
                    }
                    else {
                        if ((Planks[i].Left < Planks[j].Right && Planks[i].Left > Planks[j].Left && Planks[i].Top < Planks[j].Bottom && Planks[i].Top > Planks[j].Top) ||
                            (Planks[i].Left < Planks[j].Left && Planks[i].Right > Planks[j].Right && Planks[i].Top < Planks[j].Bottom && Planks[i].Top > Planks[j].Top)) {
                            Planks[j].Bottom = Planks[i].Top;
                            continue;
                        } //v1-2
                        if ((Planks[i].Right > Planks[j].Left && Planks[i].Right < Planks[j].Left && Planks[i].Top < Planks[j].Bottom && Planks[i].Top > Planks[j].Top) ||
                            (Planks[i].Right > Planks[j].Left && Planks[i].Right < Planks[j].Left && Planks[i].Bottom > Planks[j].Bottom && Planks[i].Top < Planks[j].Top)) {
                            Planks[j].Left = Planks[i].Right;
                            continue;
                        } //v3-4
                        if ((Planks[i].Right < Planks[j].Right && Planks[i].Right > Planks[j].Left && Planks[i].Bottom < Planks[j].Bottom && Planks[i].Bottom > Planks[j].Top) ||
                            (Planks[i].Right > Planks[j].Right && Planks[i].Left < Planks[j].Left && Planks[i].Bottom < Planks[j].Bottom && Planks[i].Bottom > Planks[j].Top)) {
                            Planks[j].Bottom = Planks[i].Top;
                            continue;
                        } //v5-6
                        if ((Planks[i].Left < Planks[j].Right && Planks[i].Left > Planks[j].Left && Planks[i].Bottom < Planks[j].Bottom && Planks[i].Bottom > Planks[j].Top) ||
                            (Planks[i].Left < Planks[j].Right && Planks[i].Left > Planks[j].Left && Planks[i].Bottom > Planks[j].Bottom && Planks[i].Top < Planks[j].Top)) {
                            Planks[j].Right = Planks[i].Left;
                            continue;
                        } //v7-8
                    }
                }
            }
            double XX = Planks.Sum(t => t.X) / Planks.Count;
            double YY = Planks.Sum(t => t.Y) / Planks.Count;
            //double d = (Planks.Max(t => t.Distance(Planks.First().X, Planks.First().Y))) * 2;
            double d = (Planks.Max(t => t.Distance(XX, YY))) * 2;
            Report.Text = "";
            Report.AppendText(String.Format("Диаметр бревна {0} мм\n\n", d));
            foreach (var p in Planks)
            {
                Report.AppendText(String.Format("Доска {0} положение по X: {1}; Положение по Y:{2}\n\n", p.ToString(), Math.Round(p.X, 2), Math.Round(p.Y, 2)));
            }
            RefreshPosition(true);
            Microsoft.VisualBasic.PowerPacks.OvalShape osh = new Microsoft.VisualBasic.PowerPacks.OvalShape();
            osh.Size = new Size((int)d,(int)d);
            osh.Location = new Point((int)(Planks.First().X - d / 2.0), (int)(Planks.First().Y - d / 2.0));
            osh.BorderWidth = 2;
            osh.BorderColor = Color.Maroon;
            osh.Visible = true;
            sc = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            sc.Name = "sc";
            FieldPanel.Controls.Add(sc);
            (FieldPanel.Controls[FieldPanel.Controls.Count-1] as Microsoft.VisualBasic.PowerPacks.ShapeContainer).Shapes.Add(osh);
            osh.Click += new System.EventHandler(this.WoodShape_Click);
            //Field.DrawEllipse(new Pen(Color.Brown), (float)(Planks.First().X - d / 2.0), (float)(Planks.First().Y - d / 2.0), (float)(d), (float)(d));

        }

        private double GetWidth() {
            return Planks.Max(t => t.Right) - Planks.Min(t=>t.Left);
        }
        private double GetHeigth() {
            return Planks.Max(t => t.Bottom) - Planks.Min(t => t.Top);
        }

        private void WoodShape_Click(object sender, EventArgs e) {
            FieldPanel.Controls.RemoveByKey("sc");
        }
    }
}
