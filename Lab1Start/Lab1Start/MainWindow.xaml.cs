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

using Lab1Start.Models;
using Lab1Start.Exceptions;

namespace Lab1Start
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Builder currentBuilder = null;
        public MainWindow()
        {
            InitializeComponent();
            ListOfBuilders.ItemsSource = new List<Builder>()
            {
                new Builder("Anton"){ IsOnWork = true },
                new Builder("Ruslan"){ IsOnWork = false },
                new Builder("Oleg")
            };
            UpdateInfo();
        }

        private void ListOfBuilders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateInfo();
        }
        

        private void BtnStartWork_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                (ListOfBuilders.SelectedItem as Builder).StartWork();
            }
            catch(BuilderAlreadyOnWorkException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                UpdateInfo();
            }
        }

        private void BtnFinishWork_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                (ListOfBuilders.SelectedItem as Builder).FinishWork();
            }
            catch (BuilderNotOnWorkException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                UpdateInfo();
            }
        }

        private void BtnDoTimeout_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (int.TryParse(TextBoxTimeoutLength.Text, out int length) && length >= 0)
                {
                    UpdateTimeout(true);
                    (ListOfBuilders.SelectedItem as Builder).DoTimeout(length);
                    TextBoxTimeoutLength.Text = String.Empty;
                }
                else MessageBox.Show("Ooops, please enter non-negative integer number");
            }
            catch (BuilderNotOnWorkException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                UpdateInfo();
            }
        }

        private void BtnPutBricks_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (int.TryParse(TextBoxCountOfBricks.Text, out int count) && count >= 0)
                {                    
                    (ListOfBuilders.SelectedItem as Builder).PutBricks(count);
                    TextBoxTimeoutLength.Text = String.Empty;
                }
                else MessageBox.Show("Ooops, please enter non-negative integer number");
            }
            catch(BuilderNotOnWorkException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                UpdateInfo();
            }
        }

        private void ShowElements()
        {
            StackPanelBuilderInfo.Visibility = currentBuilder == null ? Visibility.Hidden : Visibility.Visible;         
        }
        
        private void UpdateInfo()
        {            
            if (ListOfBuilders.SelectedIndex == -1)
            {
                currentBuilder = null;
                ShowElements();
                return;
            }
            ShowElements();
            currentBuilder = (ListOfBuilders.SelectedItem as Builder);
            LblbuilderName.Content = currentBuilder.Name;

            UpdateWork(currentBuilder.IsOnWork);
            UpdateTimeout(currentBuilder.IsOnTimeout);

            TextBlockTotalInfo.Text = currentBuilder.GetCurrentInfo();
        }

        private void UpdateTimeout(bool isOnTimeout)
        {
            if (currentBuilder == null) return;
            if (isOnTimeout)
                RBOnTimeOut.IsChecked = true;
            else
                RBNotOnTimeout.IsChecked = true;
        }
        private void UpdateWork(bool isOnWork)
        {
            if (isOnWork)
                RBOnWork.IsChecked = true;
            else
                RBNotOnWork.IsChecked = true;
        }

    }
}
