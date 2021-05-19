using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace shapes_quiz_MaurederChristoph {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {            
            InitializeComponent();
        }
        private double totalSum =0;

        private void ValidateNumericInput(object sender, TextCompositionEventArgs e) {
            e.Handled = new Regex("[^0-9,]+").IsMatch(e.Text);
        }

        private void SquareTextChanged(object sender, TextChangedEventArgs e) {
            if (string.IsNullOrEmpty(squareA.Text) || string.IsNullOrEmpty(squareB.Text)) return;
            try {
                squareArea.Text = Convert.ToInt32(squareA.Text) * Convert.ToInt32(squareB.Text) + "";

            } catch (OverflowException) {
                MessageBox.Show("This number is too larg");
            }
        }

        private void TriangleTextChanged(object sender, TextChangedEventArgs e) {
            if (string.IsNullOrEmpty(triangleA.Text) || string.IsNullOrEmpty(dreieckH.Text)) return;
                triangleArea.Text = string.Format("{0:0.##}",Convert.ToDouble(triangleA.Text) * Convert.ToDouble(dreieckH.Text) /2);
        }

        private void CircleTextChanged(object sender, TextChangedEventArgs e) {
            if (string.IsNullOrEmpty(cireleR.Text)) return;
                circleArea.Text = string.Format("{0:0.##}", Math.Pow(Convert.ToDouble(cireleR.Text),2) * Math.PI);
        }

        private void ButtonTriangle(object sender, RoutedEventArgs e) {
            TextBox textBox = new TextBox {
                FontSize =35,
                Text = " Triangle: \n a: " + triangleA.Text + "          h: " + dreieckH.Text + "          A: " + triangleArea.Text
            };
            totalSum += Convert.ToDouble(triangleArea.Text);
            sumField.Text = string.Format("{0:0.##}", totalSum);
            triangleA.Text = "";
            dreieckH.Text = "";
            triangleArea.Text = "";
            listBox.Items.Add(textBox.Text);
        }

        private void ButtonCircle(object sender, RoutedEventArgs e) {
            TextBox textBox = new TextBox {
                FontSize = 35,
                Text = " Circle: \n r: " + cireleR.Text + "          A: " + circleArea.Text
            };
            totalSum += Convert.ToDouble(circleArea.Text);
            sumField.Text = string.Format("{0:0.##}", totalSum);
            cireleR.Text = "";
            circleArea.Text = "";
            listBox.Items.Add(textBox.Text);
        }

        private void ButtonSquare(object sender, RoutedEventArgs e) {
            TextBox textBox = new TextBox {
                FontSize = 35,
                Text = " Square: \n a: " + squareA.Text + "          h: " + squareB.Text + "          A: " + squareArea.Text
            };
            totalSum += Convert.ToDouble(squareArea.Text); 
            sumField.Text = string.Format("{0:0.##}", totalSum) ;
            squareA.Text = "";
            squareB.Text = "";
            squareArea.Text = "";
            listBox.Items.Add(textBox.Text);
        }
    }
}
