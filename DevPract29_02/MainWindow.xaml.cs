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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DevPract29_02
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static double a, b;
        static string result;
        static string exceptionMessage=string.Empty;
        public MainWindow()
        {
            InitializeComponent();
        }
        void ParseNuumbers()
        {
            try
            {
                if(this.Field1.Text == string.Empty)
                    this.Field1.Text=0.ToString();
                if (this.Field2.Text == string.Empty)
                    this.Field2.Text = 0.ToString();

                a = Convert.ToDouble(this.Field1.Text);
                b = Convert.ToDouble(this.Field2.Text);
            }
            catch (Exception ex)
            {
                string m=string.Empty;
                if (Field1.Text.Contains("."))
                    m = "Замените точку на запятую";
                
                MessageBox.Show(ex.Message+ m, "Ошибка ввода!",MessageBoxButton.OK,MessageBoxImage.Error);
                

                exceptionMessage=((m.Length!=0) ? m : ex.Message);
            }
        }



        enum OperationKind
        {
            Addition,
            Substraction,
            Multiplication,
            Division
        };

        void MakeOperation(OperationKind operationKind)
        {
            try
            {
                double c=0;
                if(exceptionMessage !=string.Empty)
                    throw new Exception(exceptionMessage);
                switch(operationKind)
                {
                    case OperationKind.Addition:
                    {
                            c = a + b;
                        break;
                    }
                    case OperationKind.Substraction:
                    {
                            c = a - b;
                            break;
                    }
                    case OperationKind.Division:
                    {
                            c = a / b;
                            break;
                    }
                    case OperationKind.Multiplication:
                    {
                            c = a * b;
                            break;
                    }
                }
                if(double.IsInfinity(c))
                    throw new DivideByZeroException("Деление на ноль!");

                result = c.ToString();

            }
            catch (System.Exception ex)
            {
                result = ex.Message;
                exceptionMessage = string.Empty;
            }
        }




        private void Addition_Click(object sender, RoutedEventArgs e)
        {
            this.ParseNuumbers();
            MakeOperation(OperationKind.Addition);
            this.ResultField.Text = result;
        }
        private void Substraction_Click(object sender, RoutedEventArgs e)
        {
            this.ParseNuumbers();
            MakeOperation(OperationKind.Substraction);
            this.ResultField.Text = result;
        }
        private void Multiplication_Click(object sender, RoutedEventArgs e)
        {
            this.ParseNuumbers();
            MakeOperation(OperationKind.Multiplication);
            this.ResultField.Text = result;
        }

        private void Division_Click(object sender, RoutedEventArgs e)
        {
            this.ParseNuumbers();
            MakeOperation(OperationKind.Division);
            this.ResultField.Text = result;
        }
    }
}
