using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IntroXamarin.App.Views.Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalculatorPage : ContentPage
    {
        int currentState = 1;
        string mathOperator;
        double firstNumber, secondNumber;
        public CalculatorPage()
        {
            InitializeComponent();
            CapturarBorrar(this, null);
        }

        void CapturarNumero(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string pressed = button.Text;

            if (this.Visor.Text == "0" || currentState < 0)
            {
                this.Visor.Text = "";
                if (currentState < 0)
                    currentState *= -1;
            }

            this.Visor.Text += pressed;

            double number;
            if (double.TryParse(this.Visor.Text, out number))
            {
                this.Visor.Text = number.ToString("No");
                if (currentState == 1)
                {
                    firstNumber = number;
                }
                else
                {
                    secondNumber = number;
                }
            }
        }

        void CapturarOperador(object sender, EventArgs e)
        {
            currentState = -2;
            Button button = (Button)sender;
            string pressed = button.Text;
            mathOperator = pressed;
        }

        void CapturarBorrar(object sender, EventArgs e)
        {
            firstNumber = 0;
            secondNumber = 0;
            currentState = 1;
            this.Visor.Text = "0";
        }

        void CapturarIgual(object sender, EventArgs e)
        {
            if (currentState == 2)
            {
                var result = SimpleCalculator.Calculate(firstNumber, secondNumber, mathOperator);
                this.Visor.Text = result.ToString();
                firstNumber = result;
                currentState = -1;
            }
        }

    }
}