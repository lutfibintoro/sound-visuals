
namespace QuantizationDataForm
{
    using OpenTK.Input;
    using QuantizationDataForm.AudioReader;
    using QuantizationDataForm.Controller;
    using QuantizationDataForm.FormPlotViews;
    using QuantizationDataForm.SampleIO;
    using ScottPlot;
    using ScottPlot.Plottables;
    using ScottPlot.WinForms;
    using SkiaSharp.Views.Desktop;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class AudioAnalisisForm : Form
    {
        private string _pathWAV = string.Empty;
        private string _saveeFile = string.Empty;
        private DisplaySignalPlot _displaySignalPlot = null;
        private Annotation _tooltip;
        private FormsPlot _formPlotAnnotation;
        FormsPlot _visualFormPlot = new FormsPlot
        {
            Dock = DockStyle.Fill
        };

        public AudioAnalisisForm()
        {
            InitializeComponent();
        }

        private void Browse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    _pathWAV = fileDialog.FileName;
                    _pathWAVText.Text = _pathWAV;

                    if (ValidationPath.IsValidPath(_pathWAVText.Text))
                    {
                        // visualizing walking
                        double[] samples = new DisplaySignalPlot().SytlingFormPlot(new MonoAudioSampling(), _pathWAVText.Text);
                        visualPanel.Controls.Add(_visualFormPlot);
                        _ = MovementSamples(_visualFormPlot, samples);
                    }
                }
            }
        }




        private void View_Click(object sender, EventArgs e)
        {
            if (_pathWAV == string.Empty)
            {
                string warning = "invalid empty path, please try-again";
                MessageBox.Show(warning, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_displaySignalPlot == null)
            {
                string warning = "invalid style, please try-again";
                MessageBox.Show(warning, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _displaySignalPlot?.Run();
            _saveeFile = _pathWAV;
            Thread thread = new Thread(() =>
            {
                new TextWritterCSV().ValidPath(_saveeFile)?.Save();
                new PictureWritterPNG().ValidPath(_saveeFile)?.Save();
            });
            thread.Start();

            _pathWAV = string.Empty;
            _pathWAVText.Text = _pathWAV;
            _displaySignalPlot = null;
        }





        private void Apply_Click(object sender, EventArgs e)
        {
            if (_pathWAV == string.Empty)
            {
                string warning = "invalid empty path, please try-again";
                MessageBox.Show(warning, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (!ValidationPath.IsValidPath(_pathWAV))
                return;


            FormsPlot formPlot = new FormsPlot();
            _displaySignalPlot = new DisplaySignalPlot().Stagging(new IndependentFormPlot(), formPlot);
            double[] samples = _displaySignalPlot.SytlingFormPlot(new MonoAudioSampling(), _pathWAV);

            double[] x = new double[samples.Length - 1];
            for (int i = 0; i < samples.Length - 1; i++)
                x[i] = i;

            if (checkedListBox1.GetItemChecked(0))
            {
                Scatter scatter = formPlot.Plot.Add.ScatterLine(x, samples);
                scatter.Smooth = true;
                scatter.SmoothTension = 1;
            }
            if (checkedListBox1.GetItemChecked(1))
            {
                formPlot.Plot.Add.ScatterPoints(x, samples);
            }
            if (checkedListBox1.GetItemChecked(2))
            {
                LollipopPlot lolipop = formPlot.Plot.Add.Lollipop(samples);
                lolipop.MarkerSize = 0;
            }
            if (checkedListBox1.GetItemChecked(3))
            {
                Scatter scatter = formPlot.Plot.Add.ScatterLine(x, samples);
                scatter.FillY = true;
                scatter.FillYValue = 0;
                scatter.FillYAboveColor = Colors.Green.WithAlpha(.2);
                scatter.FillYBelowColor = Colors.Red.WithAlpha(.2);
                scatter.LineWidth = 0;
                scatter.MarkerSize = 0;
            }
            if (checkedListBox1.GetItemChecked(4))
            {
                formPlot.Plot.Add.VerticalLine(0);
                formPlot.Plot.Add.HorizontalLine(0);
            }
            if (checkedListBox1.GetItemChecked(5))
            {
                FloatingAxis floatingX = new FloatingAxis(formPlot.Plot.Axes.Bottom);
                FloatingAxis floatingY = new FloatingAxis(formPlot.Plot.Axes.Left);

                formPlot.Plot.Axes.Frameless();
                formPlot.Plot.Add.Plottable(floatingX);
                formPlot.Plot.Add.Plottable(floatingY);
            }
            if (checkedListBox1.GetItemChecked(6))
            {
                Scatter scatter = formPlot.Plot.Add.ScatterLine(x, samples);
                scatter.ConnectStyle = ConnectStyle.StepHorizontal;
                scatter.Color = Colors.DarkSalmon;
            }
            if (checkedListBox1.GetItemChecked(7))
            {
                Scatter scatter = formPlot.Plot.Add.ScatterLine(x, samples);
                scatter.ConnectStyle = ConnectStyle.StepVertical;
                scatter.Color = Colors.DarkSalmon;
            }
            if (checkedListBox1.GetItemChecked(8))
            {
                _formPlotAnnotation = formPlot;
                _tooltip = formPlot.Plot.Add.Annotation("x: 0\ny: 0");
                formPlot.MouseMove += MouseMovement;
            }
            if (checkedListBox1.GetItemChecked(9))
            {
                formPlot.Plot.FigureBackground.Color = Colors.Navy;
                formPlot.Plot.DataBackground.Color = Colors.Navy.Darken(0.1);
                formPlot.Plot.Grid.MajorLineColor = Colors.Navy.Lighten(0.1);
                formPlot.Plot.Axes.Color(Colors.Navy.Lighten(0.8));
            }
        }

        private void MouseMovement(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Coordinates coordinate = _formPlotAnnotation.Plot.GetCoordinates(e.Location.X, e.Location.Y);
            _tooltip.LabelText = $"x: {coordinate.X}\ny: {coordinate.Y}";
            _formPlotAnnotation.Refresh();
        }

        private async Task MovementSamples(FormsPlot visualFormPlot, double[] datay)
        {
            await Task.Run(async () =>
            {
                DataStreamer streamerLeft = visualFormPlot.Plot.Add.DataStreamer(100);
                streamerLeft.ViewScrollLeft();

                for (int i = 0; i < datay.Length - 1; i++)
                {
                    await Task.Delay(10);
                    streamerLeft.Add(datay[i] * 100);
                    visualFormPlot.Refresh();
                }

                streamerLeft.Clear();
            });
        }

        private void ResetApplication_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
