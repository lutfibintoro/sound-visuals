
namespace QuantizationDataForm.FormPlotViews
{
    using ScottPlot.WinForms;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    internal interface IFormPlotInitialize
    {
        void DataInit(FormsPlot plot);
        void Display(string nameForm);
    }
}
