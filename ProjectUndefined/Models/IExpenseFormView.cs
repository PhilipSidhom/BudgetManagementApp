using Budget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectUndefined.Models
{
    public interface IExpenseFormView
    {
        /// <summary>
        /// Fills the category drop-down list in the menu
        /// </summary>
        public void FillCategoryMenu(List<Category> categories);

        public void AddCategorySuccess();

        public void RemovecategorySuccess();

        public void AddCategoryError(string error);

        public void FillCategoryTypeMenu(List<Category.CategoryType> catTypes);


        public void AddExpenseError(string error);

        public void AddExpenseSuccess(string cat, string amount,string desc);

        public void FillExpenseIdMenu(List<Expense> expenses);

        public void UpdateSuccess(int id,string cat, string amount,string desc);

        public void FillUpdateInformation(Expense exp);

    }
}
