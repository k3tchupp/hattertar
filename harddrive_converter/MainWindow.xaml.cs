using System;
using System.Windows;
using System.Windows.Controls;

namespace HardDriveSpeedCalculator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int capacity = int.Parse(CapacityTextBox.Text);
                if (capacity < 0 || capacity > 5000)
                {
                    return;
                }

                string capacitySelect = ((ComboBoxItem)CapacityComboBox.SelectedItem).Content.ToString();
                int speed = int.Parse(SpeedTextBox.Text);
                string speedSelect = ((ComboBoxItem)SpeedComboBox.SelectedItem).Content.ToString();

                double convertedValue = Convert(capacity, capacitySelect, speed, speedSelect);
                ResultTextBlock.Text = "Eredmény: " + SecondToMinute(Math.Round(convertedValue));
            }
            catch (Exception ex)
            {
                ResultTextBlock.Text = "Hiba: " + ex.Message;
            }
        }

        private string SecondToMinute(double second)
        {
            if (second < 60)
            {
                return $"{second} másodperc";
            }
            else
            {
                int minutes = (int)Math.Floor(second / 60);
                int seconds = (int)(second - minutes * 60);
                return $"{minutes} perc {seconds} másodperc";
            }
        }

        private double Convert(int capacity, string capacitySelect, int speed, string speedSelect)
        {
            double result = 0;
            switch (capacitySelect)
            {
                case "Mb":
                    switch (speedSelect)
                    {
                        case "mbps":
                            result = capacity / (speed / 8.0);
                            break;
                        case "Kbps":
                            result = capacity / (speed / 1000.0);
                            break;
                        case "Mbps":
                            result = capacity / speed;
                            break;
                        case "Gbps":
                            result = capacity / (speed * 1000.0);
                            break;
                    }
                    break;
                case "Gb":
                    switch (speedSelect)
                    {
                        case "mbps":
                            result = capacity / (speed / 1000.0 / 8.0);
                            break;
                        case "Kbps":
                            result = capacity / (speed / 1000.0 / 1000.0);
                            break;
                        case "Mbps":
                            result = capacity / (speed / 1000.0);
                            break;
                        case "Gbps":
                            result = capacity / speed;
                            break;
                    }
                    break;
                case "Tb":
                    switch (speedSelect)
                    {
                        case "mbps":
                            result = capacity / (speed / 1000.0 / 1000.0 / 8.0);
                            break;
                        case "Kbps":
                            result = capacity / (speed / 1000.0 / 1000.0 / 1000.0);
                            break;
                        case "Mbps":
                            result = capacity / (speed / 1000.0 / 1000.0);
                            break;
                        case "Gbps":
                            result = capacity / (speed / 1000.0);
                            break;
                    }
                    break;
            }
            return result;
        }
    }
}
