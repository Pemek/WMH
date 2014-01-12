using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WMH.Resources;

namespace WMH.View
{
    /// <summary>
    /// Interaction logic for AlgorithmParametersView.xaml
    /// </summary>
    public partial class AlgorithmParametersView : Window
    {
        public int longTermMemory { get; set; }
        public int tabuList { get; set; }
        public int IterationStopCrit { get; set; }
        public AlgorithmParametersView()
        {
            InitializeComponent();
        }
        private void saveParameters(object sender, EventArgs e)
        {
            int longInt, tabuInt, IterationInt;
            bool convertFailFlag = false;
            if (!Int32.TryParse(textBoxLongMemory.Text, out longInt))
                convertFailFlag = true;
            if (!Int32.TryParse(textBoxShortMemory.Text, out tabuInt))
                convertFailFlag = true;
            if (!Int32.TryParse(textBoxIterationCriteria.Text, out IterationInt))
                convertFailFlag = true;

            if (convertFailFlag)
            {
                string message = Resource.ResourceManager.GetString("IncorrectValue");
                MessageBox.Show(message);
            }
            else
            {
                longTermMemory = longInt;
                tabuList = tabuInt;
                IterationStopCrit = IterationInt;
            }
        }
    }
}
