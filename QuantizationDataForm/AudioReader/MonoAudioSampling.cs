using NAudio.Wave.SampleProviders;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuantizationDataForm.AudioReader
{
    internal class MonoAudioSampling : IGetAudioSample
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public IEnumerable<double> GetAudioSample(string path)
        {
            path = path.Replace(@"\", "/");

            using (WaveFileReader reader = new WaveFileReader(path))
            {
                if (reader.WaveFormat.Channels == 1)
                {
                    ISampleProvider sampleProvider = reader.ToSampleProvider();
                    float[] buffer = new float[reader.SampleCount];
                    int read = sampleProvider.Read(buffer, 0, buffer.Length);

                    foreach (float sample in buffer.Take(read))
                    {
                        yield return (double)sample;
                    }
                }
                else if (reader.WaveFormat.Channels == 2)
                {
                    StereoToMonoSampleProvider sampleProvider = new StereoToMonoSampleProvider(reader.ToSampleProvider())
                    {
                        LeftVolume = 1.0f,
                        RightVolume = 0.0f
                    };

                    float[] buffer = new float[reader.SampleCount];
                    int read = sampleProvider.Read(buffer, 0, buffer.Length);

                    foreach (float sample in buffer.Take(read))
                    {
                        yield return (double)sample;
                    }
                }
                else
                {
                    string warning = "invalid audio, audio must be stereo or mono";
                    MessageBox.Show(warning, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    yield break;
                }
            }
        }
    }
}
