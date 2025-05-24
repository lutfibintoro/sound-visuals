namespace QuantizationDataForm.Controller
{
    using QuantizationDataForm.AudioReader;
    using QuantizationDataForm.FormPlotViews;
    using QuantizationDataForm.SampleIO;
    using ScottPlot.WinForms;
    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    internal class DisplaySignalPlot
    {
        private IGetAudioSample _sample;
        private IFormPlotInitialize _window;
        private string _fileLocation;
        private FormsPlot _formsPlot;

        internal DisplaySignalPlot Stagging(IFormPlotInitialize window, FormsPlot formPlot)
        {
            _formsPlot = formPlot;
            _window = window;
            return this;
        }



        internal double[] SytlingFormPlot(IGetAudioSample sample, string fileLocation)
        {
            _fileLocation = fileLocation;
            _sample = sample;


            if (!ValidationPath.IsValidPath(_fileLocation))
                return null;

            List<double> samples = new List<double>();
            foreach (double item in _sample.GetAudioSample(_fileLocation))
            {
                samples.Add(item);
            }

            return samples.ToArray();
        }
        


        internal void Run()
        {
            if (!ValidationPath.IsValidPath(_fileLocation))
                return;

            ValidationPath.GetPath(_fileLocation, out string fileName);

            _window.DataInit(_formsPlot);
            _window.Display(fileName);
        }


    }
}
