using Budget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProjectUndefined.Models
{
    public interface IView
    {
        /// <summary>
        /// Fills the category drop-down list in the menu
        /// </summary>
        public void FillCategoryMenu(List<Category> categories);

        /// <summary>
        /// Displays budget items without a specific summary on the main window table
        /// </summary>
        /// <param name="budgetItems">The list of budget items to display on the table</param>
        public void DisplayBudgetItemsWithoutSummary(List<BudgetItem> budgetItems);

        /// <summary>
        /// Displays budget items with category summary on the main window table
        /// </summary>
        /// <param name="budgetItems">The list of budget items to display on the table</param>
        public void DisplayBudgetItemsWithCategorySummary(List<BudgetItemsByCategory> budgetItems);

        /// <summary>
        /// Displays budget items with month summary on the main window table
        /// </summary>
        /// <param name="budgetItems">The list of budget items to display on the table</param>
        public void DisplayBudgetItemsWithMonthSummary(List<BudgetItemsByMonth> budgetItems);

        /// <summary>
        /// Displays budget items with a category and month summary to the table
        /// </summary>
        /// <param name="budgetItems">List of budget items to be added to the table</param>
        /// <param name="column">The column to be added to the table</param>
        /// <param name="clearedTableOnce">Whether the table currently needs to be reset</param>
        public void DisplayBudgetItemsWithMonthAndCategorySummary(List<Dictionary<string, object>> budgetItems, DataGridTextColumn column, bool clearedTableOnce);

        /// <summary>
        /// Clears the table displaying budget items
        /// </summary>
        public void ClearBudgetTable();

        /// <summary>
        /// Selects a budget item in the item grid and scrolls to it
        /// </summary>
        /// <param name="index">The index in the table of the item to select</param>
        public void SelectItemInGrid(int index);
    }
}
