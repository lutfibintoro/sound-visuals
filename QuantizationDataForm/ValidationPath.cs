
namespace QuantizationDataForm
{
    using NAudio.Wave.SampleProviders;
    using NAudio.Wave;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using ScottPlot;
    using System.Threading.Tasks;
    using System.IO;
    using System.Windows.Forms;

    internal static class ValidationPath
    {
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
            string[] nameFile = partPath[partPath.Length - 1].Split('.');
            fileName = nameFile[0];

            string[] newPath = new string[partPath.Length - 1];
            for (int i = 0; i < partPath.Length - 1; i++)
                newPath[i] = partPath[i];

            StringBuilder finalPath = new StringBuilder();
            foreach (string part in newPath)
            {
                finalPath.Append($"{part}/");
            }

            return finalPath.ToString();
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        internal static bool IsValidPath(string args)
        {
            if (!args.EndsWith(".wav"))
            {
                string warning = "only wav file can use";
                MessageBox.Show(warning, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!File.Exists(args))
            {
                string warning = "wav file not found";
                MessageBox.Show(warning, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}
