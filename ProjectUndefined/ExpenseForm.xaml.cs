using Budget;
using ProjectUndefined.Models;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ProjectUndefined
{
    /// <summary>
    /// Interaction logic for ExpenseForm.xaml
    /// </summary>
    public partial class ExpenseForm : Window, IExpenseFormView
    {
        private Presenter _presenter;
        private MainWindow _mainWindow;

        public ExpenseForm(Presenter presenter)
        {
            InitializeComponent();

            datePicker.SelectedDate = DateTime.Today;
            Background = new SolidColorBrush(Color.FromRgb(31, 41, 51));
            Menu.Background = new SolidColorBrush(Color.FromRgb(203, 210, 217));
            ItemCollection items = Menu.Items;

            foreach (ComboBoxItem item in items)
            {
                item.Background = new SolidColorBrush(Color.FromRgb(97, 119, 124));
                item.FontWeight = FontWeights.Bold;
                item.FontSize = 12;


            }

            txtAmount.Background = new SolidColorBrush(Color.FromRgb(97, 119, 124));
            txtDescription.Background = new SolidColorBrush(Color.FromRgb(97, 119, 124));
            txtCategory.Background = new SolidColorBrush(Color.FromRgb(97, 119, 124));

            Menu.SelectedIndex = 0;

            presenter.AddExpenseFormInterface(this);
            presenter.InitializeCategoryMenuInExpenseForm();
            presenter.InitializeCategoryTypeMenu();
            presenter.ExpenseIdMenu();
            _presenter = presenter;
        }

        /// <summary>
        /// Fills the category drop-down list in the menu
        /// </summary>
        public void FillCategoryMenu(List<Category> categories)
        {
            // Add logic here
            cmbCategories.ItemsSource = categories;
            cmbCategoriesUpdate.ItemsSource = categories;
            cmbcategoriescollection.ItemsSource = categories;
        }


        private void DarkMode_Selected(object sender, RoutedEventArgs e)
        {
            MainWindowTemplate.Background = new SolidColorBrush(Color.FromRgb(31, 41, 51));
            Menu.Background = new SolidColorBrush(Color.FromRgb(203, 210, 217));
            ItemCollection items = Menu.Items;

            foreach (ListBoxItem item in items)
            {
                item.Background = new SolidColorBrush(Color.FromRgb(97, 119, 124));
                item.FontWeight = FontWeights.Bold;
                item.FontSize = 12;


            }

            txtAmount.Background = new SolidColorBrush(Color.FromRgb(97, 119, 124));
            txtDescription.Background = new SolidColorBrush(Color.FromRgb(97, 119, 124));
            expenseGrid.Background = new SolidColorBrush(Color.FromRgb(31, 41, 51));
            TextBlock.SetForeground(expenseGrid, Brushes.LightGray);
            chkIsCredit.Foreground = Brushes.LightGray;
            catGrid.Background = new SolidColorBrush(Color.FromRgb(31, 41, 51));
            UpdateExpenseGrid.Background = new SolidColorBrush(Color.FromRgb(31, 41, 51));
            TextBlock.SetForeground(UpdateExpenseGrid, Brushes.LightGray);
            chkIsCreditUpdate.Foreground = Brushes.LightGray;
            TextBlock.SetForeground(catGrid, Brushes.LightGray);
            txtAmountUpdate.Background = new SolidColorBrush(Color.FromRgb(97, 119, 124));
            txtDescriptionUpdate.Background = new SolidColorBrush(Color.FromRgb(97, 119, 124));
            txtCategory.Background = new SolidColorBrush(Color.FromRgb(97, 119, 124));

        }

        private void LightMode_Selected(object sender, RoutedEventArgs e)
        {
            MainWindowTemplate.Background = new SolidColorBrush(Color.FromRgb(147, 148, 165));
            Menu.Background = new SolidColorBrush(Color.FromRgb(72, 75, 106));
            ItemCollection items = Menu.Items;

            foreach (ListBoxItem item in items)
            {
                item.Background = new SolidColorBrush(Color.FromRgb(210, 211, 219));
                item.FontWeight = FontWeights.Bold;
                item.FontSize = 12;


            }

            txtAmount.Background = new SolidColorBrush(Color.FromRgb(210, 211, 219));
            txtDescription.Background = new SolidColorBrush(Color.FromRgb(210, 211, 219));
            expenseGrid.Background = new SolidColorBrush(Color.FromRgb(147, 148, 165));
            catGrid.Background = new SolidColorBrush(Color.FromRgb(147, 148, 165));
            UpdateExpenseGrid.Background = new SolidColorBrush(Color.FromRgb(147, 148, 165));
            TextBlock.SetForeground(UpdateExpenseGrid, Brushes.Black);
            TextBlock.SetForeground(catGrid, Brushes.Black);
            txtCategory.Background = new SolidColorBrush(Color.FromRgb(210, 211, 219));
            txtDescriptionUpdate.Background = new SolidColorBrush(Color.FromRgb(210, 211, 219));
            txtAmountUpdate.Background = new SolidColorBrush(Color.FromRgb(210, 211, 219));
            chkIsCredit.Foreground = Brushes.Black;
            chkIsCreditUpdate.Foreground = Brushes.Black;
            TextBlock.SetForeground(expenseGrid, Brushes.Black);
        }

        private void Ocean_Selected(object sender, RoutedEventArgs e)
        {
            MainWindowTemplate.Background = new SolidColorBrush(Color.FromRgb(45, 153, 174));
            Menu.Background = new SolidColorBrush(Color.FromRgb(0, 28, 68));
            ItemCollection items = Menu.Items;

            foreach (ListBoxItem item in items)
            {
                item.Background = new SolidColorBrush(Color.FromRgb(12, 87, 118));
                item.FontWeight = FontWeights.Bold;
                item.FontSize = 12;


            }

            txtAmount.Background = new SolidColorBrush(Color.FromRgb(12, 87, 118));
            txtDescription.Background = new SolidColorBrush(Color.FromRgb(12, 87, 118));
            expenseGrid.Background = new SolidColorBrush(Color.FromRgb(45, 153, 174));
            catGrid.Background = new SolidColorBrush(Color.FromRgb(45, 153, 174));
            UpdateExpenseGrid.Background = new SolidColorBrush(Color.FromRgb(45, 153, 174));
            TextBlock.SetForeground(UpdateExpenseGrid, Brushes.Black);
            TextBlock.SetForeground(catGrid, Brushes.Black);

            txtCategory.Background = new SolidColorBrush(Color.FromRgb(12, 87, 118));
            txtDescriptionUpdate.Background = new SolidColorBrush(Color.FromRgb(12, 87, 118));
            txtAmountUpdate.Background = new SolidColorBrush(Color.FromRgb(12, 87, 118));
            chkIsCredit.Foreground = Brushes.Black;
            chkIsCreditUpdate.Foreground = Brushes.Black;
            TextBlock.SetForeground(expenseGrid, Brushes.Black);

        }

        private void GreenMix_Selected(object sender, RoutedEventArgs e)
        {
            MainWindowTemplate.Background = new SolidColorBrush(Color.FromRgb(64, 127, 62));
            Menu.Background = new SolidColorBrush(Color.FromRgb(137, 180, 73));
            ItemCollection items = Menu.Items;
            foreach (ListBoxItem item in items)
            {
                item.Background = new SolidColorBrush(Color.FromRgb(231, 224, 196));
                item.FontWeight = FontWeights.Bold;
                item.FontSize = 12;


            }

            txtAmount.Background = new SolidColorBrush(Color.FromRgb(231, 224, 196));
            txtDescription.Background = new SolidColorBrush(Color.FromRgb(231, 224, 196));
            expenseGrid.Background = new SolidColorBrush(Color.FromRgb(64, 127, 62));
            catGrid.Background = new SolidColorBrush(Color.FromRgb(64, 127, 62));
            UpdateExpenseGrid.Background = new SolidColorBrush(Color.FromRgb(64, 127, 62));
            TextBlock.SetForeground(UpdateExpenseGrid, Brushes.Black);
            TextBlock.SetForeground(catGrid, Brushes.Black);

            txtCategory.Background = new SolidColorBrush(Color.FromRgb(231, 224, 196));
            txtAmountUpdate.Background = new SolidColorBrush(Color.FromRgb(231, 224, 196));
            txtDescriptionUpdate.Background = new SolidColorBrush(Color.FromRgb(231, 224, 196));
            chkIsCredit.Foreground = Brushes.Black;
            chkIsCreditUpdate.Foreground = Brushes.Black;
            TextBlock.SetForeground(expenseGrid, Brushes.Black);

        }

        private void Sunset_Selected(object sender, RoutedEventArgs e)
        {
            MainWindowTemplate.Background = new SolidColorBrush(Color.FromRgb(255, 183, 88));
            Menu.Background = new SolidColorBrush(Color.FromRgb(210, 65, 80));
            ItemCollection items = Menu.Items;
            foreach (ListBoxItem item in items)
            {
                item.Background = new SolidColorBrush(Color.FromRgb(233, 114, 84));
                item.FontWeight = FontWeights.Bold;
                item.FontSize = 12;


            }

            txtAmount.Background = new SolidColorBrush(Color.FromRgb(233, 114, 84));
            txtDescription.Background = new SolidColorBrush(Color.FromRgb(233, 114, 84));
            expenseGrid.Background = new SolidColorBrush(Color.FromRgb(255, 183, 88));
            catGrid.Background = new SolidColorBrush(Color.FromRgb(255, 183, 88));
            UpdateExpenseGrid.Background = new SolidColorBrush(Color.FromRgb(255, 183, 88));
            TextBlock.SetForeground(UpdateExpenseGrid, Brushes.Black);
            TextBlock.SetForeground(catGrid, Brushes.Black);
            txtDescriptionUpdate.Background = new SolidColorBrush(Color.FromRgb(233, 114, 84));
            txtAmountUpdate.Background = new SolidColorBrush(Color.FromRgb(233, 114, 84));
            txtCategory.Background = new SolidColorBrush(Color.FromRgb(233, 114, 84));
            chkIsCredit.Foreground = Brushes.Black;
            chkIsCreditUpdate.Foreground = Brushes.Black;
            TextBlock.SetForeground(expenseGrid, Brushes.Black);

        }

        public void AddCategorySuccess()
        {
            MessageBox.Show($"Successfully added {txtCategory.Text} to categories!");
        }


        private void btnAddCategory_Click(object sender, RoutedEventArgs e)
        {
            _presenter.ValidateAddCategoryField(txtCategory.Text);
            _presenter.InitializeCategoryMenuInExpenseForm();
            txtCategory.Clear();
        }



        public void AddCategoryError(string error)
        {
            MessageBox.Show($"Failed to add category: {error}");
        }



        public void RemovecategorySuccess()
        {

        }

        public void FillCategoryTypeMenu(List<Category.CategoryType> catTypes)
        {
            catTypeBox.ItemsSource = catTypes;
        }


        public void AddExpenseError(string error)
        {
            MessageBox.Show($"Failed to add expense: {error}");
        }

        public void AddExpenseSuccess(string cat, string amount, string desc)
        {
            string lastAction = $"{cat}: ${amount}, {desc}";

            txtLastAction.Text = lastAction;

        }

        private void btnAddExpense_Click(object sender, RoutedEventArgs e)
        {
            int? catId = null;
            DateTime? date = null;

            if(datePicker.SelectedDate != null)
            {
                date = (DateTime)datePicker.SelectedDate;
            }

            Category? CatItem = (Category)cmbCategories.SelectedItem;

            string cat = cmbCategories.Text;

            string desc = txtDescription.Text;

            string amount = txtAmount.Text;

            if(CatItem != null) { catId = CatItem.Id; }


            _presenter.AddExpense(date, catId, amount, desc, cat);
            _presenter.FilterBudgetItems();
            _presenter.ExpenseIdMenu();

        }

        private void btnAddExpenseUpdate_Click(object sender, RoutedEventArgs e)
        {
            int? catId = null;

            DateTime? date = null;

            if (datePicker.SelectedDate != null)
            {
                date = (DateTime)datePicker.SelectedDate;
            }

            Category? CatItem = (Category)cmbCategoriesUpdate.SelectedItem;

            if (CatItem != null) { catId = CatItem.Id; }

            string desc = txtDescriptionUpdate.Text;

            string amount = txtAmountUpdate.Text;

            int? expId = null;

            if (cmbExpId.SelectedValue != null)
            {
                expId = (int)cmbExpId.SelectedValue;
            }

            string cat = cmbCategoriesUpdate.Text;
            _presenter.UpdateExpense(expId, date, catId, amount, desc, cat);
            _presenter.FilterBudgetItems();

        }

        public void UpdateSuccess(int expenseId, string cat, string amount, string desc)
        {
            string lastAction = $"ExpenseId: {expenseId}, {cat}: ${amount}, {desc}";
            txtLastActionUpdate.Text = lastAction;
        }

        public void FillExpenseIdMenu(List<Expense> expenses)
        {
            List<int> ids = new List<int>();

            foreach (Expense expense in expenses)
            {
                ids.Add(expense.Id);
            }



            cmbExpId.ItemsSource = ids;
        }

        public void FillUpdateInformation(Expense exp)
        {
            cmbCategoriesUpdate.SelectedItem = exp.Category;
            cmbExpId.SelectedItem = exp.Id;
            txtDescriptionUpdate.Text = exp.Description;
            txtAmountUpdate.Text = (exp.Amount).ToString();
        }

        private void btnDeleteExpense_Click(object sender, RoutedEventArgs e)
        {
            int expenseId = (int)cmbExpId.SelectedItem;

            _presenter.DeleteExpense(expenseId);
            _presenter.FilterBudgetItems();
        }

        private void bthDeleteCategory_Click(object sender, RoutedEventArgs e)
        {
            Category cat = (Category)cmbcategoriescollection.SelectedItem;
            _presenter.DeleteCategory(cat.Id);
            txtCategory.Clear();

        }

        private void btnCancelExpense_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnCancelCategory_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnCancelExpenseUpdate_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
