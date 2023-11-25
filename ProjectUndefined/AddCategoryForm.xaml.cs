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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjectUndefined
{
    /// <summary>
    /// Interaction logic for AddCategoryForm.xaml
    /// </summary>
    public partial class AddCategoryForm : Window, ICategoryFormView
    {
        private Presenter _presenter;

        public AddCategoryForm(Presenter presenter)
        {
            InitializeComponent();

            _presenter = presenter;
            presenter.AddCategoryFormInterface(this);
        }

        private void btnAddCategory_Click(object sender, RoutedEventArgs e)
        {
           // _presenter.ValidateAddCategoryField(txtCategory.Text);
        }

        public void AddCategorySuccess()
        {
            MessageBox.Show($"Successfully added {txtCategory.Text} to categories!");
        }

        public void AddCategoryError(string error)
        {
            MessageBox.Show($"Failed to add category: {error}");
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBox.Show("WARNING! Everything done will not be saved when closing the program");
        }
    }
}
