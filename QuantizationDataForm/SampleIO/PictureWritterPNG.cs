namespace QuantizationDataForm.SampleIO
{
    using QuantizationDataForm.AudioReader;
    using ScottPlot;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class PictureWritterPNG
    {
        private string _path;
        private string _fileName;
        private double[] _amplitudo;





        public void Save()
        {
            string fullPath = _path + _fileName + ".png";

            Plot myPlot = new Plot();
            myPlot.Add.Signal(_amplitudo);
            myPlot.SavePng(fullPath, 1920, 1080);
        }




        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public PictureWritterPNG ValidPath(string path)
        {
            if (!ValidationPath.IsValidPath(path))
                return null;

            _path = ValidationPath.GetPath(path, out _fileName);
            List<double> result = new List<double>();
            foreach (double item in new MonoAudioSampling().GetAudioSample(path))
            {
                result.Add(item);
            }
            _amplitudo = result.ToArray();
            return this;
        }
    }
}
