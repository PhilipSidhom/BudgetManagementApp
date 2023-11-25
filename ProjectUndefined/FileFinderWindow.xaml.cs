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
using System.IO;
using ProjectUndefined.Models;
using Path = System.IO.Path;
using Budget;

namespace ProjectUndefined
{
    /// <summary>
    /// Interaction logic for FileFinderWindow.xaml
    /// </summary>
    public partial class FileFinderWindow : Window
    {
        private Presenter presenter;
        private MainWindow window;
        public FileFinderWindow()
        {
            InitializeComponent();
            //presenter = new Presenter(this);


        }
        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            string newFile = "";
            Microsoft.Win32.OpenFileDialog openFile = new Microsoft.Win32.OpenFileDialog();
            openFile.Filter = "Database files (*.db)|*.db";
            if (openFile.ShowDialog() == true)
            {
                newFile = openFile.FileName;
            }

            Presenter.fileName = Path.GetFileNameWithoutExtension(newFile);
            Presenter.folderPath = Path.GetDirectoryName(newFile) + "\\";
            Presenter.filePath = newFile;

            if(Presenter.filePath == "")
            {
                MessageBox.Show("Please select a valid file");
            }
            else
            {
                var dbFileInfo = new FileInfo(Presenter.filePath);
                if (dbFileInfo.Length != 0)
                {
                    MainWindow newMainWindow = new MainWindow(false);
                    this.Close();
                    newMainWindow.ShowDialog();
                }
                else
                {
                    MainWindow newMainWindow = new MainWindow(true);
                    this.Close();
                    newMainWindow.ShowDialog();
                }
            }

           

        }

      

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {

            FileCreatorWindow createWindow = new FileCreatorWindow(true);
            //this.Close();
            createWindow.ShowDialog();



        }

        public void FillCategoryMenu(List<Category> categories)
        {
            throw new NotImplementedException();
        }

        public void DisplayBudgetItemsWithoutSummary(List<BudgetItem> budgetItems)
        {
            throw new NotImplementedException();
        }

        public void DisplayBudgetItemsWithCategorySummary(List<BudgetItemsByCategory> budgetItems)
        {
            throw new NotImplementedException();
        }

        public void DisplayBudgetItemsWithMonthSummary(List<BudgetItemsByMonth> budgetItems)
        {
            throw new NotImplementedException();
        }

        public void DisplayBudgetItemsWithMonthAndCategorySummary(List<Dictionary<string, object>> budgetItems)
        {
            throw new NotImplementedException();
        }
    }
}
