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



    internal class TextWritterCSV
    {
        private string _path;
        private string _fileName;
        private double[] _amplitudo;



        /// <summary>
        /// 
        /// </summary>
        public void Save()
        {
            //make a final path
            string pathFile = _path + _fileName + ".csv";

            //write structure csv
            StringBuilder sb = new StringBuilder();
            foreach (double item in _amplitudo)
            {
                sb.Append($"{item}\n");
            }

            //save csv
            File.WriteAllText(pathFile, sb.ToString());
        }




        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public TextWritterCSV ValidPath(string path)
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
