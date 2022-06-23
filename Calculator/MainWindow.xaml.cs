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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        double value = 0;
        string op = null;
        bool op_pressed = false;
        bool equal_pressed = false;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtbox.Text == "0" || op_pressed == true)
            {
                txtbox.Clear();
            }
            op_pressed = false;
            Button button = (Button)sender;
            txtbox.Text = txtbox.Text + button.Content;
        }

        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            op_pressed = true;
            var op_btn = (Button)sender;
            op = op_btn.Content.ToString();
            value = Convert.ToDouble(txtbox.Text);
            lbl.Content = value + " " + op + " ";
        }

        private void ce_btn_Click(object sender, RoutedEventArgs e)
        {
            if (equal_pressed == true)
            {
                txtbox.Text = "0";
                lbl.Content = "0";
            }
            else
                txtbox.Text = "0";
        }

        private void c_btn_Click(object sender, RoutedEventArgs e)
        {
            txtbox.Text = "0";
            lbl.Content = "0";
        }

        private void equal_btn_Click(object sender, RoutedEventArgs e)
        {
            equal_pressed = true;
            double value2 = Convert.ToDouble(txtbox.Text);
            lbl.Content += txtbox.Text + " = ";
            switch (op)
            {
                case "+":
                    txtbox.Text = (value + value2).ToString();
                    break;
                case "-":
                    txtbox.Text = (value - value2).ToString();
                    break;
                case "×":
                    txtbox.Text = (value * value2).ToString();
                    break;
                case "÷":
                    try
                    {
                        txtbox.Text = value>0 && value2 == 0 ? throw new DivideByZeroException("Cannot by divide zero") : (value / value2).ToString(); ;
                    }
                    catch (Exception ex)
                    {
                        lbl.Content = ex.Message;
                    }


                    break;
                default:
                    break;
            }
        }
        private void pos_neg_btn_Click(object sender, RoutedEventArgs e)
        {
            var value = -Convert.ToDouble(txtbox.Text);
            txtbox.Text = value.ToString();
        }

        private void denominator_Click(object sender, RoutedEventArgs e)
        {
            var value = 1 / Convert.ToDouble(txtbox.Text);
            lbl.Content = "";
            lbl.Content += $"1/({txtbox.Text})";
            txtbox.Text = value.ToString();
        }

        private void pow_btn_Click(object sender, RoutedEventArgs e)
        {
            var value = Convert.ToDouble(Math.Pow(Convert.ToDouble(txtbox.Text), 2));
            lbl.Content = "";
            lbl.Content = $"{txtbox.Text}²";
            txtbox.Text = value.ToString();
        }

        private void sqrt_Click(object sender, RoutedEventArgs e)
        {
            var value = Convert.ToDouble(Math.Sqrt(Convert.ToDouble(txtbox.Text)));
            lbl.Content = "";
            lbl.Content += "√(" + txtbox.Text + ")";
            txtbox.Text = value.ToString();
        }

        private void erase_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                txtbox.Text = txtbox.Text.Length > 0 ? txtbox.Text.Remove(txtbox.Text.Length - 1) : throw new NullReferenceException("Cannot delete");

            }
            catch (Exception ex)
            {
                lbl.Content = ex.Message;
            }

        }

        private void point_btn_Click(object sender, RoutedEventArgs e)
        {
           // var value = Convert.ToDouble(txtbox.Text) + 0.0;
            txtbox.Text = Convert.ToDouble(txtbox.Text) + ".";
        }
    }
}
