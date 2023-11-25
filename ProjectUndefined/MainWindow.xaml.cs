using Budget;
using ProjectUndefined.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
using Path = System.IO.Path;

namespace ProjectUndefined
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IView
    {
        private Presenter _presenter;
        private ExpenseForm? _expenseForm;
        private bool doneClickEventOnce;
        public MainWindow(bool isNewFile)
        {
            InitializeComponent();

            _presenter = new Presenter(this,isNewFile);

            /* ATTENTION: MOVE THIS CALL TO THE OPEN/CREATE NEW FILE METHOD WHEN COMPLETED */
            _presenter.InitializeCategoryMenuInMainWindow();
        }

        /// <summary>
        /// Fills the category drop-down list in the menu
        /// </summary>
        public void FillCategoryMenu(List<Category> categories)
        {
            cmbCategoryList.ItemsSource = categories;
        }

        private void eventChangeFilter(object sender, RoutedEventArgs e)
        {
            Category? CatItem = (Category)cmbCategoryList.SelectedItem;
            int? catId = null;
            if (CatItem != null)
            {
                catId = CatItem.Id;
            }

            _presenter.FilterBudgetItems(dpStart.SelectedDate, dpEnd.SelectedDate, (bool)chkFilterCategory.IsChecked, catId, (bool)chkSummaryCategory.IsChecked, (bool)chkSummaryMonth.IsChecked);
        }

        /////////////////////////////////////////
        // BEGIN DISPLAY BUDGET ITEMS ON TABLE //
        /// <summary>
        /// Empties the table displaying budget items
        /// </summary>
        public void ClearBudgetTable()
        {
            BudgetItemGrid.ItemsSource = null;
        }

        /// <summary>
        /// Displays budget items without summary on the table
        /// </summary>
        /// <param name="budgetItems">List of regular budget items</param>
        public void DisplayBudgetItemsWithoutSummary(List<BudgetItem> budgetItems)
        {
            BudgetItemGrid.ItemsSource = null;
            BudgetItemGrid.Columns.Clear();
            BudgetItemGrid.ItemsSource = budgetItems;

            var col1 = new DataGridTextColumn();
            var col2 = new DataGridTextColumn();
            var col3 = new DataGridTextColumn();
            var col4 = new DataGridTextColumn();
            var col5 = new DataGridTextColumn();

            col1.Header = "Date";
            System.Windows.Data.Binding binding = new System.Windows.Data.Binding(@"Date");
            binding.Mode = BindingMode.OneTime;
            col1.Binding = binding;
            BudgetItemGrid.Columns.Add(col1);

            col2.Header = "Category";
            binding = new System.Windows.Data.Binding("Category");
            binding.Mode = BindingMode.OneTime;
            col2.Binding = binding;
            BudgetItemGrid.Columns.Add(col2);

            col3.Header = "Description";
            binding = new System.Windows.Data.Binding("ShortDescription");
            binding.Mode = BindingMode.OneTime;
            col3.Binding = binding;
            BudgetItemGrid.Columns.Add(col3);

            col4.Header = "Amount";
            binding = new System.Windows.Data.Binding("Amount");
            binding.Mode = BindingMode.OneTime;
            binding.StringFormat = "C";
            Style s = new Style();
            s.Setters.Add(new Setter(TextBlock.TextAlignmentProperty, TextAlignment.Right));
            col4.CellStyle = s;
            col4.Binding = binding;
           
            BudgetItemGrid.Columns.Add(col4);

            col5.Header = "Balance";
            binding = new System.Windows.Data.Binding("Balance");
            binding.Mode = BindingMode.OneTime;
            binding.StringFormat = "C";
            Style z = new Style();
            z.Setters.Add(new Setter(TextBlock.TextAlignmentProperty, TextAlignment.Right));
            col5.CellStyle = z;
            col5.Binding = binding;
            BudgetItemGrid.Columns.Add(col5);
        }

        /// <summary>
        /// Displays budget items with a category summary to the table
        /// </summary>
        /// <param name="budgetItems">List of budget items by category</param>
        public void DisplayBudgetItemsWithCategorySummary(List<BudgetItemsByCategory> budgetItems)
        {
            BudgetItemGrid.ItemsSource = null;
            BudgetItemGrid.Columns.Clear();
            BudgetItemGrid.ItemsSource = budgetItems;
            var col1 = new DataGridTextColumn();
            var col2 = new DataGridTextColumn();

            col1.Header = "Category";
            System.Windows.Data.Binding binding = new System.Windows.Data.Binding("Category");
            binding.Mode = BindingMode.OneTime;
            col1.Binding = binding;
            BudgetItemGrid.Columns.Add(col1);

            col2.Header = "Amount";
            binding = new System.Windows.Data.Binding("Total");
            binding.Mode = BindingMode.OneTime;
            binding.StringFormat = "C";
            Style z = new Style();
            z.Setters.Add(new Setter(TextBlock.TextAlignmentProperty, TextAlignment.Right));
            col2.CellStyle = z;
            col2.Binding = binding;

            BudgetItemGrid.Columns.Add(col2);
        }

        /// <summary>
        /// Displays budget items with a month summary to the table
        /// </summary>
        /// <param name="budgetItems">List of budget items by month</param>
        public void DisplayBudgetItemsWithMonthSummary(List<BudgetItemsByMonth> budgetItems)
        {
            BudgetItemGrid.ItemsSource = null;
            BudgetItemGrid.Columns.Clear();
            BudgetItemGrid.ItemsSource = budgetItems;
            var col1 = new DataGridTextColumn();
            var col2 = new DataGridTextColumn();

            col1.Header = "Month";
            System.Windows.Data.Binding binding = new System.Windows.Data.Binding("Month");
            binding.Mode = BindingMode.OneTime;
            col1.Binding = binding;
            BudgetItemGrid.Columns.Add(col1);

            col2.Header = "Amount";
            binding = new System.Windows.Data.Binding("Total");
            binding.Mode = BindingMode.OneTime;
            binding.StringFormat = "C";
            Style z = new Style();
            z.Setters.Add(new Setter(TextBlock.TextAlignmentProperty, TextAlignment.Right));
            col2.CellStyle = z;
            col2.Binding = binding;
            BudgetItemGrid.Columns.Add(col2);
        }

        /// <summary>
        /// Displays budget items with a category and month summary to the table
        /// </summary>
        /// <param name="budgetItems">List of budget items to be added to the table</param>
        /// <param name="column">The column to be added to the table</param>
        /// <param name="clearedTableOnce">Whether the table currently needs to be reset</param>
        public void DisplayBudgetItemsWithMonthAndCategorySummary(List<Dictionary<string, object>> budgetItems, DataGridTextColumn column, bool clearedTableOnce)
        {
            if (!clearedTableOnce)
            {
                BudgetItemGrid.ItemsSource = null;
                BudgetItemGrid.Columns.Clear();
                BudgetItemGrid.ItemsSource = budgetItems;
            }

            BudgetItemGrid.Columns.Add(column);
            
        }
        // END DISPLAY BUDGET ITEMS ON TABLE //
        ///////////////////////////////////////

        private void btnOpenExpenses_Click(object sender, RoutedEventArgs e)
        {
            _presenter.CreateExpenseForm(ref _expenseForm);
            _expenseForm.homeBudgetCT.SelectedIndex = 0;
            _expenseForm.Show();
        }

        private void BudgetItemGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (BudgetItemGrid.SelectedItem != null && !(bool)chkSummaryCategory.IsChecked && !(bool)chkSummaryMonth.IsChecked)
            {
                _presenter.CreateExpenseForm(ref _expenseForm);
                BudgetItem exp = (BudgetItem)BudgetItemGrid.SelectedItem;
                _presenter.FillUpdateForm(exp.ExpenseID);
                _expenseForm.homeBudgetCT.SelectedIndex = 2;
                _expenseForm.Show();
            }
        }

        private void btnCreateNewFile_Click(object sender, RoutedEventArgs e)
        {
            FileCreatorWindow newFileWindow = new FileCreatorWindow(false);
            newFileWindow.ShowDialog();

            ClearBudgetTable();
            _presenter.CloseDatabase();
            bool isNew = _presenter.CheckBlankFile(Presenter.filePath);
            _presenter.ConnectToModel(Presenter.filePath, isNew);
            _presenter.FilterBudgetItems();
        }

        private void btnDuplicateFile_Click(object sender, RoutedEventArgs e)
        {

            _presenter.CopyFile();
        }


        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            System.Windows.MessageBox.Show("WARNING! Everything done will not be saved when closing the program");
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
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

            ClearBudgetTable();
            _presenter.CloseDatabase();
            bool isNew = _presenter.CheckBlankFile(Presenter.filePath);
            _presenter.ConnectToModel(Presenter.filePath, isNew);
            _presenter.FilterBudgetItems();


        }

      

        private void DarkMode_Selected(object sender, RoutedEventArgs e)
        {
            BudgetGrid.Background = new SolidColorBrush(Color.FromRgb(31, 41, 51));
            gbFilter.Background = new SolidColorBrush(Color.FromRgb(97, 119, 124));
            gbSummary.Background= new SolidColorBrush(Color.FromRgb(97, 119, 124));
            BudgetItemGrid.Background = new SolidColorBrush(Color.FromRgb(97, 119, 124));
            gbFilter.Foreground = Brushes.White;
            gbSummary.Foreground = Brushes.White;
            FileMenu.Background = new SolidColorBrush(Color.FromRgb(31, 41, 51));
            FileMenu.Foreground = Brushes.White;
            btnCreateNewFile.Background = new SolidColorBrush(Color.FromRgb(97, 119, 124));
            btnDuplicateFile.Background = new SolidColorBrush(Color.FromRgb(97, 119, 124));
            btnExit.Background = new SolidColorBrush(Color.FromRgb(97, 119, 124));
            btnOpen.Background = new SolidColorBrush(Color.FromRgb(97, 119, 124));

        }

        private void LightMode_Selected(object sender, RoutedEventArgs e)
        {


            BudgetGrid.Background = new SolidColorBrush(Color.FromRgb(147,148,165));
            gbFilter.Background = new SolidColorBrush(Color.FromRgb(210,211,219));
            gbSummary.Background = new SolidColorBrush(Color.FromRgb(210,211,219));
            BudgetItemGrid.Background = new SolidColorBrush(Color.FromRgb(210, 211, 219));
            gbFilter.Foreground = Brushes.Black;
            gbSummary.Foreground = Brushes.Black;
            FileMenu.Background = new SolidColorBrush(Color.FromRgb(147,148,165));
            FileMenu.Foreground = Brushes.Black;
            btnCreateNewFile.Background = new SolidColorBrush(Color.FromRgb(210, 211, 219));
            btnDuplicateFile.Background = new SolidColorBrush(Color.FromRgb(210, 211, 219));
            btnExit.Background = new SolidColorBrush(Color.FromRgb(210, 211, 219));
            btnOpen.Background = new SolidColorBrush(Color.FromRgb(210, 211, 219));

        }

        private void Ocean_Selected(object sender, RoutedEventArgs e)
        {
           
            

            BudgetGrid.Background = new SolidColorBrush(Color.FromRgb(45, 153, 174));
            gbFilter.Background = new SolidColorBrush(Color.FromRgb(12, 87, 118));
            gbSummary.Background = new SolidColorBrush(Color.FromRgb(12, 87, 118));
            BudgetItemGrid.Background = new SolidColorBrush(Color.FromRgb(12, 87, 118));
            gbFilter.Foreground = Brushes.White;
            gbSummary.Foreground = Brushes.White;
            chkSummaryCategory.Foreground = Brushes.White;
            chkSummaryMonth.Foreground =  Brushes.White;
            chkFilterCategory.Foreground = Brushes.White;
            FileMenu.Background = new SolidColorBrush(Color.FromRgb(45, 153, 174));
            FileMenu.Foreground = Brushes.Black;
            btnCreateNewFile.Background = new SolidColorBrush(Color.FromRgb(12, 87, 118));
            btnDuplicateFile.Background = new SolidColorBrush(Color.FromRgb(12, 87, 118));
            btnExit.Background = new SolidColorBrush(Color.FromRgb(12, 87, 118));
            btnOpen.Background = new SolidColorBrush(Color.FromRgb(12, 87, 118));

        }

        private void GreenMix_Selected(object sender, RoutedEventArgs e)
        {
         

            BudgetGrid.Background = new SolidColorBrush(Color.FromRgb(137, 180, 73));
            gbFilter.Background = new SolidColorBrush(Color.FromRgb(64, 127, 62));
            gbSummary.Background = new SolidColorBrush(Color.FromRgb(64, 127, 62));
            BudgetItemGrid.Background = new SolidColorBrush(Color.FromRgb(64, 127, 62));
            gbFilter.Foreground = Brushes.White;
            gbSummary.Foreground = Brushes.White;
            chkSummaryCategory.Foreground = Brushes.White;
            chkSummaryMonth.Foreground = Brushes.White;
            chkFilterCategory.Foreground = Brushes.White;
            FileMenu.Background = new SolidColorBrush(Color.FromRgb(137, 180, 73));
            FileMenu.Foreground = Brushes.Black;
            btnCreateNewFile.Background = new SolidColorBrush(Color.FromRgb(64, 127, 62));
            btnDuplicateFile.Background = new SolidColorBrush(Color.FromRgb(64, 127, 62));
            btnExit.Background = new SolidColorBrush(Color.FromRgb(64, 127, 62));
            btnOpen.Background = new SolidColorBrush(Color.FromRgb(64, 127, 62));


        }

        private void Sunset_Selected(object sender, RoutedEventArgs e)
        {
           


            BudgetGrid.Background = new SolidColorBrush(Color.FromRgb(255, 183, 88));
            gbFilter.Background = new SolidColorBrush(Color.FromRgb(233, 114, 84));
            gbSummary.Background = new SolidColorBrush(Color.FromRgb(233, 114, 84));
            BudgetItemGrid.Background = new SolidColorBrush(Color.FromRgb(233, 114, 84));
            gbFilter.Foreground = Brushes.White;
            gbSummary.Foreground = Brushes.White;
            gbFilter.BorderBrush = new SolidColorBrush(Color.FromRgb(77, 1, 128));
            gbSummary.BorderBrush = new SolidColorBrush(Color.FromRgb(77, 1, 128));
            chkSummaryCategory.Foreground = Brushes.Black;
            chkSummaryMonth.Foreground = Brushes.Black;
            chkFilterCategory.Foreground = Brushes.Black;
            FileMenu.Background = new SolidColorBrush(Color.FromRgb(255, 183, 88));
            FileMenu.Foreground = Brushes.Black;
            btnCreateNewFile.Background = new SolidColorBrush(Color.FromRgb(233, 114, 84));
            btnDuplicateFile.Background = new SolidColorBrush(Color.FromRgb(233, 114, 84));
            btnExit.Background = new SolidColorBrush(Color.FromRgb(233, 114, 84));
            btnOpen.Background = new SolidColorBrush(Color.FromRgb(233, 114, 84));
        }

        private void txtSearchBar_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!doneClickEventOnce)
            {
                ((TextBox)sender).Text = "";
                ((TextBox)sender).Foreground = Brushes.Black;
                doneClickEventOnce = true;
            }
        }

        private void btnSearchBar_Click(object sender, RoutedEventArgs e)
        {
            _presenter.SearchForBudgetItemInTable(BudgetItemGrid.SelectedIndex, txtSearchBar.Text, BudgetItemGrid.Items);
        }

        /// <summary>
        /// Selects a budget item in the item grid and scrolls to it
        /// </summary>
        /// <param name="index">The index in the table of the item to select</param>
        public void SelectItemInGrid(int index)
        {
            BudgetItemGrid.SelectedIndex = index;
            BudgetItemGrid.ScrollIntoView(BudgetItemGrid.SelectedItem);
            BudgetItemGrid.Focus();
        }

        private void btnOpenInNewWindow_Click(object sender, RoutedEventArgs e)
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

            if (Presenter.filePath == "")
            {
                MessageBox.Show("Please select a valid file");
            }
            else
            {
                var dbFileInfo = new FileInfo(Presenter.filePath);
                if (dbFileInfo.Length != 0)
                {
                    MainWindow newMainWindow = new MainWindow(false);
                    newMainWindow.ShowDialog();
                }
                else
                {
                    MainWindow newMainWindow = new MainWindow(true);
                    newMainWindow.ShowDialog();
                }
            }
        }
    }
}
