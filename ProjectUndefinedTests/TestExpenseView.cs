using Budget;
using ProjectUndefined.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectUndefinedTests
{
    public class TestExpenseView : IExpenseFormView
    {
        public bool CategoryMenuFilled { get; private set; }
        public bool CategoryErrorAdded { get; private set; }
        public bool CategorySuccessAdded { get; private set; }
        public bool ExpenseErrorAdded { get; private set; }
        public bool ExpenseSuccessAdded { get; private set; }
        public bool CategoryTypeMenuFilled { get; private set; }
        public bool CategorySuccessRemoved { get; private set; }
        public bool FillUpdateMenu { get; private set; }
        public bool ExpenseIdMenuFilled { get; private set; }
        public bool UpdateSuccessfull { get; private set; }
        public void AddCategoryError(string error)
        {
            CategoryErrorAdded = true;
        }

        public void AddCategorySuccess()
        {
            CategorySuccessAdded = true;
        }

        public void AddExpenseError(string error)
        {
            ExpenseErrorAdded = true;
        }

        public void AddExpenseSuccess(string cat, string amount, string desc)
        {
            ExpenseSuccessAdded = true;
        }

        public void FillCategoryMenu(List<Category> categories)
        {
            CategoryMenuFilled = true;
        }

        public void FillCategoryTypeMenu(List<Category.CategoryType> catTypes)
        {
            CategoryTypeMenuFilled = true;
        }

        public void FillExpenseIdMenu(List<Expense> expenses)
        {
            if(expenses.Count >0)
            {
                ExpenseIdMenuFilled = true;
            }
        }

        public void FillUpdateInformation(Expense exp)
        {
           if(exp != null)
            {
                FillUpdateMenu = true;
            }
        }

        public void RemovecategorySuccess()
        {
            CategorySuccessRemoved = true;
        }

        public void UpdateSuccess(int id, string cat, string amount, string desc)
        {
           UpdateSuccessfull = true;
        }
    }
}
