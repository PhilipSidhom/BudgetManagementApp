using ProjectUndefined.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budget;
using System.Windows.Controls;

namespace ProjectUndefinedTests
{
    public class TestView : IView
    {
        public bool CategoryMenuFilled { get; private set; }
        public bool DisplayedBudgetItemsWithoutSummary { get; private set; }
        public bool DisplayedBudgetItemsWithCategorySummary { get; private set; }
        public bool DisplayedBudgetItemsWithMonthSummary { get; private set; }
        public bool DisplayedBudgetItemsWithCategoryAndMonthSummary { get; private set; }
        public bool ClearedBudgetItems { get; private set; }
        public bool SelectedItemInGrid { get; private set; }
        public TestView() { }

        public void FillCategoryMenu(List<Category> categories)
        {
            CategoryMenuFilled = true;
        }

        public void DisplayBudgetItemsWithoutSummary(List<BudgetItem> budgetItems)
        {
            DisplayedBudgetItemsWithoutSummary = true;
        }

        public void DisplayBudgetItemsWithCategorySummary(List<BudgetItemsByCategory> budgetItems)
        {
            DisplayedBudgetItemsWithCategorySummary = true;
        }

        public void DisplayBudgetItemsWithMonthSummary(List<BudgetItemsByMonth> budgetItems)
        {
            DisplayedBudgetItemsWithMonthSummary = true;
        }

        public void DisplayBudgetItemsWithMonthAndCategorySummary(List<Dictionary<string, object>> budgetItems, DataGridTextColumn column, bool clearedTableOnce)
        {
            DisplayedBudgetItemsWithCategoryAndMonthSummary = true;
        }

        public void ClearBudgetTable()
        {
            ClearedBudgetItems = true;
        }

        public void SelectItemInGrid(int index)
        {
            SelectedItemInGrid = true;
        }
    }
}
