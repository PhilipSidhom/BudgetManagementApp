using ProjectUndefined.Models;
using Budget;
using static Budget.Category;
using System.Windows.Controls;

namespace ProjectUndefinedTests
{
    public class PresenterTests
    {
        private static TestView view = new TestView();
        private static Presenter presenter = new Presenter(view, true);

        [Fact]
        public void PresenterMethod_ClearBudgetTable_ClearsBudgetTable()
        {
            // Preparation

            // Action
            presenter.FilterBudgetItems(null, null, false, 0, false, false);

            // Assert
            Assert.True(view.ClearedBudgetItems);
        }

        [Fact]
        public void PresenterMethod_DisplayBudgetItemsWithoutSummary_DisplaysBudgetItemsWithoutSummary()
        {
            // Preparation
            var expenseView = new TestExpenseView();
            presenter.AddExpenseFormInterface(expenseView);
            presenter.AddExpense(DateTime.Now, 1, "5", "description", "");

            // Action
            presenter.FilterBudgetItems(null, null, false, 0, false, false);

            // Assert
            Assert.True(view.DisplayedBudgetItemsWithoutSummary);
        }

        [Fact]
        public void PresenterMethod_DisplayBudgetItemsWithCategorySummary_DisplaysBudgetItemsWithCategorySummary()
        {
            // Preparation
            var expenseView = new TestExpenseView();
            presenter.AddExpenseFormInterface(expenseView);
            presenter.AddExpense(DateTime.Now, 1, "5", "description", "");

            // Action
            presenter.FilterBudgetItems(null, null, false, 0, true, false);

            // Assert
            Assert.True(view.DisplayedBudgetItemsWithCategorySummary);
        }

        [Fact]
        public void PresenterMethod_DisplayBudgetItemsWithMonthSummary_DisplaysBudgetItemsWithMonthSummary()
        {
            // Preparation
            var expenseView = new TestExpenseView();
            presenter.AddExpenseFormInterface(expenseView);
            presenter.AddExpense(DateTime.Now, 1, "5", "description", "");

            // Action
            presenter.FilterBudgetItems(null, null, false, 0, false, true);

            // Assert
            Assert.True(view.DisplayedBudgetItemsWithMonthSummary);
        }

        [Fact]
        public void PresenterMethod_DisplayBudgetItemsWithCategoryAndMonthSummary_DisplaysBudgetItemsWithCategoryAndMonthSummary()
        {
            // Preparation
            var expenseView = new TestExpenseView();
            presenter.AddExpenseFormInterface(expenseView);
            presenter.AddExpense(DateTime.Now, 1, "5", "description", "");

            // Action
            presenter.FilterBudgetItems(null, null, false, 0, true, true);

            // Assert
            Assert.True(view.DisplayedBudgetItemsWithCategoryAndMonthSummary);
        }

        [Fact]
        public void PresenterMethod_InitializeCategoryMenuInMainWindow_CreatesList()
        {
            // Preparation
            var expenseView = new TestExpenseView();
            presenter.AddExpenseFormInterface(expenseView);

            // Action
            presenter.InitializeCategoryMenuInMainWindow();

            // Assert
            Assert.True(view.CategoryMenuFilled);
        }

        [Fact]
        public void PresenterMethod_InitializeCategoryTypeMenu_FillsTypeMenu()
        {
            // Preparation
            var expenseView = new TestExpenseView();
            presenter.AddExpenseFormInterface(expenseView);

            // Action
            presenter.InitializeCategoryTypeMenu();

            // Assert
            Assert.True(expenseView.CategoryTypeMenuFilled);
        }

        [Fact]
        public void PresenterMethod_ExpenseIdMenu_FillsIdMenu()
        {
            // Preparation
            var expenseView = new TestExpenseView();
            presenter.AddExpenseFormInterface(expenseView);
            presenter.AddExpense(DateTime.Now, 1, "5", "description", "");
            presenter.AddExpense(DateTime.Now, 2, "6", "other description", "");

            // Action
            presenter.ExpenseIdMenu();

            // Assert
            Assert.True(expenseView.ExpenseIdMenuFilled);
        }

        [Fact]
        public void PresenterMethod_ExpenseIdMenu_EmptyListFailCase()
        {
            // Preparation
            var expenseView = new TestExpenseView();
            presenter.AddExpenseFormInterface(expenseView);

            // Action
            presenter.ExpenseIdMenu();

            // Assert
            Assert.False(expenseView.ExpenseIdMenuFilled);
        }

        [Fact]
        public void PresenterMethod_InitializeCategoryMenuInExpenseForm_CreatesList()
        {
            // Preparation
            var expenseView = new TestExpenseView();
            presenter.AddExpenseFormInterface(expenseView);

            // Action
            presenter.InitializeCategoryMenuInExpenseForm();

            // Assert
            Assert.True(expenseView.CategoryMenuFilled);
        }

        [Fact]
        public void PresenterMethod_ValidateAddCategoryField_AddCategorySuccess()
        {
            // Preparation
            var expenseView = new TestExpenseView();
            presenter.AddExpenseFormInterface(expenseView);

            // Action
            presenter.ValidateAddCategoryField("New category");

            // Assert
            Assert.True(expenseView.CategorySuccessAdded);
        }

        [Fact]
        public void PresenterMethod_ValidateAddCategoryField_AddCategoryError()
        {
            // Preparation
            var expenseView = new TestExpenseView();
            presenter.AddExpenseFormInterface(expenseView);

            // Action
            presenter.ValidateAddCategoryField("Utilities");

            // Assert
            Assert.True(expenseView.CategoryErrorAdded);
        }

        [Fact]
        public void PresenterMethod_ValidateAddExpenseField_AddExpenseSuccess()
        {
            // Preparation
            var expenseView = new TestExpenseView();
            presenter.AddExpenseFormInterface(expenseView);

            // Action
            presenter.AddExpense(DateTime.Now, 1, "5", "description", "");

            // Assert
            Assert.True(expenseView.ExpenseSuccessAdded);
        }

        [Fact]
        public void PresenterMethod_ValidateAddExpenseField_AddExpenseErrorWithInvalidAmountInput()
        {
            // Preparation
            var expenseView = new TestExpenseView();
            presenter.AddExpenseFormInterface(expenseView);

            // Action
            presenter.AddExpense(DateTime.Now, 1, "five", "description", "");

            // Assert
            Assert.True(expenseView.ExpenseErrorAdded);
        }

        [Fact]
        public void PresenterMethod_ValidateAddExpenseField_AddExpenseErrorWithInvalidDescription()
        {
            // Preparation
            var expenseView = new TestExpenseView();
            presenter.AddExpenseFormInterface(expenseView);

            // Action
            presenter.AddExpense(DateTime.Now, 1, "5", "", "");

            // Assert
            Assert.True(expenseView.ExpenseErrorAdded);
        }

        [Fact]
        public void PresenterMethod_ValidateAddExpenseField_AddExpenseErrorWithInvalidCategoryId()
        {
            // Preparation
            var expenseView = new TestExpenseView();
            presenter.AddExpenseFormInterface(expenseView);

            // Action
            presenter.AddExpense(DateTime.Now, -1, "5", "description", "");

            // Assert
            Assert.True(expenseView.ExpenseErrorAdded);
        }

        [Fact]
        public void PresenterMethod_ValidateAddExpenseField_AddExpenseErrorWithInvalidAmount()
        {
            // Preparation
            var expenseView = new TestExpenseView();
            presenter.AddExpenseFormInterface(expenseView);

            // Action
            presenter.AddExpense(DateTime.Now, 1, "-5", "description", "");

            // Assert
            Assert.True(expenseView.ExpenseErrorAdded);
        }

        //-----------------------------------------

        [Fact]
        public void PresenterMethod_ValidateUpdateExpenseField_UpdateExpenseSuccess()
        {
            // Preparation
            var expenseView = new TestExpenseView();
            presenter.AddExpenseFormInterface(expenseView);
            presenter.AddExpense(DateTime.Now, 1, "5", "description", "");

            // Action
            presenter.UpdateExpense(1, DateTime.Now, 2, "10", "updated description", "");

            // Assert
            Assert.True(expenseView.UpdateSuccessfull);
        }

        [Fact]
        public void PresenterMethod_ValidateUpdateExpenseField_UpdateExpenseErrorWithInvalidIDInput()
        {
            // Preparation
            var expenseView = new TestExpenseView();
            presenter.AddExpenseFormInterface(expenseView);
            presenter.AddExpense(DateTime.Now, 1, "5", "description", "");

            // Action
            presenter.UpdateExpense(null, DateTime.Now, 2, "10", "updated description", "");

            // Assert
            Assert.True(expenseView.ExpenseErrorAdded);
        }

        [Fact]
        public void PresenterMethod_ValidateUpdateExpenseField_UpdateExpenseErrorWithInvalidAmountInput()
        {
            // Preparation
            var expenseView = new TestExpenseView();
            presenter.AddExpenseFormInterface(expenseView);
            presenter.AddExpense(DateTime.Now, 1, "5", "description", "");

            // Action
            presenter.UpdateExpense(1, DateTime.Now, 2, "ten", "updated description", "");

            // Assert
            Assert.True(expenseView.ExpenseErrorAdded);
        }

        [Fact]
        public void PresenterMethod_ValidateUpdateExpenseField_UpdateExpenseErrorWithInvalidDescription()
        {
            // Preparation
            var expenseView = new TestExpenseView();
            presenter.AddExpenseFormInterface(expenseView);
            presenter.AddExpense(DateTime.Now, 1, "5", "description", "");

            // Action
            presenter.UpdateExpense(1, DateTime.Now, 2, "10", "", "");

            // Assert
            Assert.True(expenseView.ExpenseErrorAdded);
        }

        [Fact]
        public void PresenterMethod_ValidateUpdateExpenseField_UpdateExpenseErrorWithInvalidCategoryId()
        {
            // Preparation
            var expenseView = new TestExpenseView();
            presenter.AddExpenseFormInterface(expenseView);
            presenter.AddExpense(DateTime.Now, 1, "5", "description", "");

            // Action
            presenter.UpdateExpense(1, DateTime.Now, -1, "10", "updated description", "");

            // Assert
            Assert.True(expenseView.ExpenseErrorAdded);
        }

        [Fact]
        public void PresenterMethod_ValidateUpdateExpenseField_UpdateExpenseErrorWithInvalidAmount()
        {
            // Preparation
            var expenseView = new TestExpenseView();
            presenter.AddExpenseFormInterface(expenseView);
            presenter.AddExpense(DateTime.Now, 1, "5", "description", "");

            // Action
            presenter.UpdateExpense(1, DateTime.Now, 2, "-1", "updated description", "");

            // Assert
            Assert.True(expenseView.ExpenseErrorAdded);
        }

        [Fact]
        public void PresenterMethod_FillUpdateForm_FillsUpdateForm()
        {
            // Preparation
            var expenseView = new TestExpenseView();
            presenter.AddExpenseFormInterface(expenseView);
            presenter.AddExpense(DateTime.Now, 1, "5", "description", "");

            // Action
            presenter.FillUpdateForm(1);

            // Assert
            Assert.True(expenseView.FillUpdateMenu);
        }

        [Fact]
        public void PresenterMethod_SearchForBudgetItemInTable_SelectsItemInGrid()
        {
            // Preparation
            ItemCollection temp = null;
            // Action
            presenter.SearchForBudgetItemInTable(0, "budget", temp, true);

            // Assert
            Assert.True(view.SelectedItemInGrid);
        }
    }
}