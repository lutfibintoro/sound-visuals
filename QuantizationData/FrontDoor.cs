namespace QuantizationData
{
    using NAudio.Wave;
    using NAudio.Wave.SampleProviders;
    using System;
    using System.Text;
    using System.Text.RegularExpressions;


    internal class FrontDoor
    {
        internal static void AccesPoint(string args)
        {
            if (!IsValidPath(args))
                return;

            StringBuilder buffer = new();
            List<double> doubles = [];
            foreach (float sample in GetAmplitudoDataWave(args))
            {
                buffer.Append($"{sample}\n");
                doubles.Add(sample);
            }

            string pathWriteFile = GetPath(args, out string nameFile);
            WriteTextBasedFile(pathWriteFile, nameFile, ".csv", buffer.ToString());
            MakeColumnChart(pathWriteFile, nameFile, ".png", [.. doubles]);

            
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="nameFile"></param>
        /// <param name="extension"></param>
        /// <param name="amplitudo"></param>
        internal static void MakeColumnChart(string path, string nameFile, string extension, double[] amplitudo)
        {
            string fullPath = path + nameFile + extension;

            ScottPlot.Plot myPlot = new();
            double[] dataX = new double[amplitudo.Length];
            double[] dataY = new double[amplitudo.Length];
            for (int i = 0; i < amplitudo.Length; i++)
            {
                dataX[i] = i;
                dataY[i] = amplitudo[i];
            }


            myPlot.Add.Scatter(dataX, dataY);
            myPlot.SavePng(fullPath, 1920, 1080);
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        internal static string GetPath(string filePath, out string fileName)
        {
            filePath = filePath.Replace("\\", "/");
#pragma warning disable IDE0079 // Remove unnecessary suppression
#pragma warning disable SYSLIB1045 // Convert to 'GeneratedRegexAttribute'.
            string[] partPath = Regex.Split(filePath, "/");
#pragma warning restore SYSLIB1045 // Convert to 'GeneratedRegexAttribute'.
#pragma warning restore IDE0079 // Remove unnecessary suppression
            string[] nameFile = partPath[^1].Split('.');
            fileName = nameFile[0];

            string[] newPath = new string[partPath.Length - 1];
            for (int i = 0; i < partPath.Length - 1; i++)
                newPath[i] = partPath[i];

            StringBuilder finalPath = new();
            foreach (string part in newPath)
            {
                finalPath.Append($"{part}/");
            }

            return finalPath.ToString();
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="nameFile"></param>
        /// <param name="extension"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        internal static string WriteTextBasedFile(string path, string nameFile, string extension, string text)
        {
            string pathFile = path + nameFile + extension;
            File.WriteAllText(pathFile, text);

            return pathFile;
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        internal static bool IsValidPath(string args)
        {
            if (args.Length >= 2)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                string warning = "Warning: ";
                Console.Write(warning);
                Console.ResetColor();
                Console.WriteLine("only can one path of file wav");
                return false;
            }

            if (!args.EndsWith(".wav"))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                string warning = "Warning: ";
                Console.Write(warning);
                Console.ResetColor(); Console.WriteLine("only wav file can use");
                return false;
            }

            if (!File.Exists(args))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                string warning = "Warning: ";
                Console.Write(warning);
                Console.ResetColor(); Console.WriteLine("wav file not found");
                return false;
            }

            return true;
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        internal static IEnumerable<float> GetAmplitudoDataWave(string path)
        {
#pragma warning disable IDE0063 // Use simple 'using' statement
            using (WaveFileReader reader = new(path))
            {
                StereoToMonoSampleProvider sampleProvider = new(reader.ToSampleProvider())
                {
                    LeftVolume = 1.0f,
                    RightVolume = 0.0f
                };

                float[] buffer = new float[reader.SampleCount];
                int read = sampleProvider.Read(buffer, 0, buffer.Length);

                foreach (float sample in buffer.Take(read))
                {
                    yield return sample;
                }
            }
#pragma warning restore IDE0063 // Use simple 'using' statement
        }
    }
}
