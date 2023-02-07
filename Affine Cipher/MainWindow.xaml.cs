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
using System.Text.RegularExpressions;
using Microsoft.Win32;
using System.IO;
using System.Security;

namespace Affine_Cipher
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

        //Encrypt button
        private void txtEncrypt_Click(object sender, RoutedEventArgs e)
        {
            scrllOutput.Text = "";

            int a; //mutiplicative value
            int b; //additive value
            int c; //cipher index number
            int p; //plaintext index number (a=0, b=1...)

            bool checkA = int.TryParse(txtA.Text, out a);
            bool checkB = int.TryParse(txtB.Text, out b);

            //Checking correct user input
            if (checkA == false || checkB == false)
            {
                errors.Text = "Please enter valid integers.";
                return;
            }
            else
            {
                errors.Text = "";
            }

            //Checking if a has an inverse
            if (GCD(a, b) != 1)
            {
                errors.Text += "\nNo inverse.";
                return;
            }
            else
            {
                errors.Text = "";
            }

            String tempInput = "";
            String unfInput = "";
            String encOutput = "";
            String alphaText = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            tempInput += scrllInput.Text.ToLower();
            unfInput += Regex.Replace(tempInput, "[^a-z]", "");

            //loop for encryption
            foreach (char letter in unfInput)
            {
                p = (int)(letter); //converts chars to ascii
                p = p - 97;
                c = (a * p + b) % 26; //encryption formula for each char
                encOutput += alphaText[c];
            }

            //TEST OUTPUT
            //scrllOutput.Text = a.ToString() + " " + b.ToString() + " " + unfInput + " \n" + encOutput;
            scrllOutput.Text = encOutput;
        }

        //Decrypt button
        private void txtDecrypt_Click(object sender, RoutedEventArgs e)
        {
            scrllOutput.Text = "";

            int a; //mutiplicative value
            int b; //additive value
            int c; //cipher index number
            int p; //plaintext index number (a=0, b=1...)

            bool checkA = int.TryParse(txtA.Text, out a);
            bool checkB = int.TryParse(txtB.Text, out b);

            //Checking correct user input
            if (checkA == false || checkB == false)
            {
                errors.Text = "Please enter valid integers.";
                return;
            }
            else
            {
                errors.Text = "";
            }

            //Checking if a has an inverse
            if (GCD(a, b) != 1)
            {
                errors.Text += "\nNo inverse.";
                return;
            }
            else
            {
                errors.Text = "";
            }

            String tempInput = "";
            String unfInput = "";
            String decOutput = "";
            String alphaText = "abcdefghijklmnopqrstuvwxyz";

            tempInput += scrllInput.Text.ToLower();
            unfInput += Regex.Replace(tempInput, "[^a-z]", "");

            //extended euclidian algorithm
            int A, B, temp, q, lastX = 1, lastY = 0, x = 0, y = 1, aInv;
            A = 26;
            B = a;
            while (B != 0)
            {
                temp = B;
                q = A / B;
                B = A % B;
                A = temp;

                temp = x;
                x = lastX - q * x;
                lastX = temp;

                temp = y;
                y = lastY - q * y;
                lastY = temp;
            }

            //calculating a-inverse
            if (lastY < 0)
            {
                aInv = (A + lastY);
            }
            else
            {
                aInv = lastY;
            }

            //loop for decryption
            foreach (char letter in unfInput)
            {
                c = (int)(letter); //converts chars to ascii
                c = c - 97;
                p = (aInv * (c - b)) % 26; //decryption formula for each char
                if (p < 0)
                {
                    p += 26;
                }
                decOutput += alphaText[p];
            }

            //TEST OUTPUT
            //scrllOutput.Text = a.ToString() + " " + b.ToString() + " " + unfInput + " \n" + decOutput;
            scrllOutput.Text = decOutput;
        }

        //Open text file button
        private void openText_Click(object sender, RoutedEventArgs e)
        {
            String tempTxt = "";
            OpenFileDialog fileDialog = new OpenFileDialog();

            if(fileDialog.ShowDialog() == true)
            {
                try
                {
                    var sr = new StreamReader(fileDialog.FileName);
                    tempTxt = sr.ReadToEnd();
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error. \n\n Error message: {ex.Message}\n\n" + $"Details:\n\n{ex.StackTrace}");
                }
            }

            scrllInput.Text = tempTxt;
        }

        //Save button
        private void saveText_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();

            saveDialog.RestoreDirectory = true;
            saveDialog.FileName = "*.txt";
            saveDialog.DefaultExt = "txt";
            saveDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

            if (saveDialog.ShowDialog() == true)
            {
                Stream fileStream = saveDialog.OpenFile();
                StreamWriter sw = new StreamWriter(fileStream);

                sw.Write(scrllOutput.Text);
                sw.Close();
                fileStream.Close();
            }    
        }

        //GCD method
        int GCD(int a, int b)
        {
            int temp = 0;
            while (b != 0)
            {
                temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
    }
}
