using ScottPlot;
using ScottPlot.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScottPlot.Plottables;
using System.Xml.Linq;
using System.Threading;

namespace QuantizationDataForm.FormPlotViews
{
    internal class IndependentFormPlot : IFormPlotInitialize
    {
        private readonly Form _form;
        private readonly Panel _panel;
        private FormsPlot _plotForms;


        /// <summary>
        /// initialize forms and panel
        /// </summary>
        internal IndependentFormPlot()
        {
            _panel = new Panel
            {
                Dock = DockStyle.Fill
            };

            _form = new Form
            {
                ClientSize = new System.Drawing.Size(600, 400),
                AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F)
            };
            _form.Controls.Add(_panel);
        }


        public void DataInit(FormsPlot plot)
        {
            _plotForms = plot;
            _plotForms.Dock = DockStyle.Fill;
            _plotForms.Refresh();
            _panel.Controls.Add(_plotForms);
        }


        public void Display(string formName)
        {
            _form.Text = formName;
            _form.Name = formName;
            _form.Show();
        }
    }
}
