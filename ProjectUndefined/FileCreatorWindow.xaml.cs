using Budget;
using ProjectUndefined.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Path = System.IO.Path;

namespace ProjectUndefined
{
    /// <summary>
    /// Interaction logic for FileCreatorWindow.xaml
    /// </summary>
    public partial class FileCreatorWindow : Window
    {
        private Presenter presenter;
        private bool isStartup;
        public FileCreatorWindow( bool isStartUp)
        {
            InitializeComponent();
            isStartup = isStartUp;
        }

    

        private void btnFindLocation_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folderPicker = new FolderBrowserDialog();
            folderPicker.ShowNewFolderButton = true;
            DialogResult folderResult = folderPicker.ShowDialog();
            if (fileNameText.Text.Length == 0)
            {
                System.Windows.MessageBox.Show("Error: The file name is blank, please give it a name");
            }
            else
            {
         
                string fullPath = Presenter.FileCreationValidation(fileNameText.Text, folderPicker.SelectedPath);


                Presenter.filePath = fullPath;
                Presenter.folderPath = folderPicker.SelectedPath + "\\";
                Presenter.fileName = Path.GetFileNameWithoutExtension(fullPath);
                if (!isStartup)
                {
                    System.Windows.MessageBox.Show("File successfully created, please close this window");
              
                }

                if (isStartup)
                {
                    
                    MainWindow newMainWindow = new MainWindow(true);
                    this.Close();
                    newMainWindow.ShowDialog();
                }

                //this.Close();
                //ExpenseForm newExpenseForm = new ExpenseForm(presenter);
                //newExpenseForm.ShowDialog();

            }



        }

        public void DisplayBudgetItemsWithCategorySummary(List<BudgetItemsByCategory> budgetItems)
        {
            throw new NotImplementedException();
        }

        public void DisplayBudgetItemsWithMonthAndCategorySummary(List<Dictionary<string, object>> budgetItems)
        {
            throw new NotImplementedException();
        }

        public void DisplayBudgetItemsWithMonthSummary(List<BudgetItemsByMonth> budgetItems)
        {
            throw new NotImplementedException();
        }

        public void DisplayBudgetItemsWithoutSummary(List<BudgetItem> budgetItems)
        {
            throw new NotImplementedException();
        }

        public void FillCategoryMenu(List<Category> categories)
        {
            throw new NotImplementedException();
        }
    }
}
