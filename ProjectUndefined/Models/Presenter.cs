using Budget;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace ProjectUndefined.Models
{
    public class Presenter
    {
        IView view;
        IExpenseFormView expenseView;
        ICategoryFormView categoryView;

        static public string filePath = "../../../test.db";
        static public string folderPath = "";
        static public string fileName = "";

        HomeBudget? budget;

        List<Category.CategoryType> catTypes = new List<Category.CategoryType>();

        private DateTime? start;
        private DateTime? end;
        private bool filterCategory = false;
        private int categoryId;
        private bool summarizeCategory = false;
        private bool summarizeMonth = false;


        public Presenter(IView view, bool isNew/*string dbFile = "../../../test.db"*/)
        {
            this.view = view;

            ConnectToModel(filePath, isNew);
            FilterBudgetItems();
        }

        public HomeBudget ConnectToModel(string filename, bool newDatabase)
        {
            HomeBudget budget = new HomeBudget(filename, newDatabase);
            this.budget = budget;
            return budget;
        }

        public void InitializeCategoryMenuInMainWindow()
        {
            view.FillCategoryMenu(budget.categories.List());
        }

        public void InitializeCategoryMenuInExpenseForm()
        {
            expenseView.FillCategoryMenu(budget.categories.List());
        }


        public void ExpenseIdMenu()
        {
            expenseView.FillExpenseIdMenu(budget.expenses.List());
        }

        public void InitializeCategoryTypeMenu()
        {
            catTypes.Add(Category.CategoryType.Income);
            catTypes.Add(Category.CategoryType.Expense);
            catTypes.Add(Category.CategoryType.Credit);
            catTypes.Add(Category.CategoryType.Savings);

            expenseView.FillCategoryTypeMenu(catTypes);


        }

        public void AddExpenseFormInterface(IExpenseFormView view)
        {
            expenseView = view;
        }

        public void AddCategoryFormInterface(ICategoryFormView view)
        {
            categoryView = view;
        }

        /// <summary>
        /// Validate adding a category to the category list
        /// </summary>
        /// <param name="text">The category name entered by the user</param>
        public void ValidateAddCategoryField(string text)
        {
            bool categoryExists = false;

            // had to hard code indexes so making sure they are added correctly:

            //Category.CategoryType correctCatType = catType + 1;


            // NOTE: Further validation may be required (i.e. must not be empty)

            if (string.IsNullOrEmpty(text))
            {
                expenseView.AddCategoryError(text);
            }
            else
            {
                // Check that the name of the category entered hasn't already been entered
                foreach (Category category in budget.categories.List())
                {
                    if (category.Description == text)
                    {
                        categoryExists = true;
                        break;
                    }
                }

                // Display error message if exists, otherwise display success and add category
                if (categoryExists)
                {
                    expenseView.AddCategoryError("Category already exists!");
                }
                else
                {

                    //---ADD CATEGORY HERE---//

                    budget.categories.Add(text);


                    expenseView.AddCategorySuccess();



                }
            }
        }

        public static string FileCreationValidation(string fileName, string path)
        {

            char[] charArray = fileName.ToCharArray();
            if (charArray[charArray.Length - 1] == 'b' && charArray[charArray.Length - 2] == 'd' && charArray[charArray.Length - 3] == '.')
            {
                char[] newCharArray = new char[charArray.Length - 3];
                for (int i = 0; i < newCharArray.Length; i++)
                {
                    newCharArray[i] = charArray[i];
                }

                string newFileName = new string(newCharArray);
                fileName = newFileName;

            }

            string fullPath;
            if (fileName.EndsWith(".db"))
            {
                fullPath = path + "\\" + fileName;
            }
            else
            {
                fullPath = path + "\\" + fileName + ".db";
            }
            FileStream fileStreamer = File.Create(fullPath);
            fileStreamer.Close();
            return fullPath;
        }

        public bool VerifyFile(string source)
        {
            if (File.Exists(source))
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        public void AddExpense(System.DateTime? date, int? categoryid, string amount, string desc, string cat)
        {
            double amountParsed;
            bool failedAdd = false;
            if (!double.TryParse(amount, out amountParsed))
            {
                expenseView.AddExpenseError("Amount is not in a correct format");
                failedAdd = true;
            }
            if (string.IsNullOrEmpty(desc))
            {
                expenseView.AddExpenseError("Description is empty");
                failedAdd = true;
            }
            if (categoryid < 0)
            {
                expenseView.AddExpenseError("Category id is invalid");
                failedAdd = true;
            }
            if (amountParsed < 0)
            {
                expenseView.AddExpenseError("Amount cannot be 0 or negative");
                failedAdd = true;
            }
            if (categoryid == null)
            {
                expenseView.AddExpenseError("Category must have a value");
                failedAdd = true;
            }
            if (date == null)
            {
                expenseView.AddExpenseError("Date must have a value");
                failedAdd = true;
            }

            if (!failedAdd)
            {

                budget.expenses.Add((DateTime)date, (int)categoryid, amountParsed, desc);

                List<BudgetItem> items = budget.GetBudgetItems(null, null, false, (int)categoryid);

                expenseView.AddExpenseSuccess(cat, amount, desc);

                view.DisplayBudgetItemsWithoutSummary(items);
            }

        }


        public void UpdateExpense(int? expenseId, DateTime? date, int? categoryid, string amount, string desc, string cat)
        {
            double amountParsed;
            bool failedAdd = false;

            if (!double.TryParse(amount, out amountParsed))
            {
                expenseView.AddExpenseError("Amount is not in a correct format");
                failedAdd = true;
            }
            if (string.IsNullOrEmpty(desc))
            {
                expenseView.AddExpenseError("Description is empty");
                failedAdd = true;
            }
            if (categoryid < 0)
            {
                expenseView.AddExpenseError("Category id is invalid");
                failedAdd = true;
            }
            if (amountParsed < 0)
            {
                expenseView.AddExpenseError("Amount cannot be 0 or negative");
                failedAdd = true;
            }
            if (date == null)
            {
                expenseView.AddExpenseError("Date must have a value");
                failedAdd = true;
            }
            if (categoryid == null)
            {
                expenseView.AddExpenseError("Category must have a value");
                failedAdd = true;
            }
            if (expenseId == null)
            {
                expenseView.AddExpenseError("Expense ID must have a value");
                failedAdd = true;
            }
            if (!failedAdd)
            {
                double.TryParse(amount, out amountParsed);

                budget.expenses.UpdateProperties((int)expenseId, (DateTime)date, (int)categoryid, amountParsed, desc);

                expenseView.UpdateSuccess((int)expenseId, cat, amount, desc);
            }
        }

        public void CreateExpenseForm(ref ExpenseForm expenseForm)
        {
            expenseForm = new ExpenseForm(this);
        }

        /// <summary>
        /// Filters the budget items with the values that are already in the presenter
        /// </summary>
        public void FilterBudgetItems()
        {

            FilterBudgetItems(start, end, filterCategory, categoryId, summarizeCategory, summarizeMonth);

        }

        /// <summary>
        /// Filters the budget items with values recently changed in the main window and updates
        /// the values in the presenter
        /// </summary>
        /// <param name="start">The start range of dates to get budget items</param>
        /// <param name="end">The end range of dates to get budget items</param>
        /// <param name="filterCategory">Whether only the categories of a certain id should be displayed</param>
        /// <param name="categoryId">The id of categories to display should the user want to filter
        /// by category</param>
        /// <param name="summarizeCategory">Whether a summary of the categories should be displayed</param>
        /// <param name="summarizeMonth">Whether a summary of the months should be displayed</param>
        public void FilterBudgetItems(DateTime? start, DateTime? end, bool filterCategory, int? categoryId, bool summarizeCategory, bool summarizeMonth)
        {
            int catId = 0;
            bool filterCat = false;

            if (categoryId != null)
            {
                catId = (int)categoryId;
                filterCat = filterCategory;
            }

            if (budget.expenses.List().Count > 0)
            {
                if (summarizeCategory && !summarizeMonth)
                {
                    view.DisplayBudgetItemsWithCategorySummary(budget.GetBudgetItemsByCategory(start, end, filterCat, catId));
                }
                else if (!summarizeCategory && summarizeMonth)
                {
                    view.DisplayBudgetItemsWithMonthSummary(budget.GetBudgetItemsByMonth(start, end, filterCat, catId));
                }
                else if (summarizeCategory && summarizeMonth)
                {
                    List<Dictionary<string, object>> budgetItems = budget.GetBudgetDictionaryByCategoryAndMonth(start, end, filterCat, catId);

                    List<DataGridTextColumn> columns = new List<DataGridTextColumn>();
                    bool listContainsKey;
                    bool clearedTableOnce = false;
                    foreach (Dictionary<string, object> dict in budgetItems)
                    {
                        foreach (string key in dict.Keys)
                        {
                            listContainsKey = false;
                            if (!key.Contains("details:"))
                            {
                                foreach (var column in columns)
                                {
                                    if (column.Header.Equals(key))
                                    {
                                        listContainsKey = true;
                                        break;
                                    }
                                }
                                if (!listContainsKey)
                                {
                                    var newColumn = new DataGridTextColumn();
                                    newColumn.Header = key;
                                    newColumn.Binding = new System.Windows.Data.Binding($"[{key}]");
                                    if(key == "Amount" || key == "Total" || key == "Balance")
                                    {
                                        newColumn.Binding.StringFormat = "C";
                                        Style s = new Style();
                                        s.Setters.Add(new Setter(TextBlock.TextAlignmentProperty, TextAlignment.Right));
                                        newColumn.CellStyle = s;
                                    }


                                    view.DisplayBudgetItemsWithMonthAndCategorySummary(budgetItems, newColumn, clearedTableOnce);
                                    clearedTableOnce = true;
                                    columns.Add(newColumn);
                                }
                            }
                        }
                    }
                }
                else
                {
                    view.DisplayBudgetItemsWithoutSummary(budget.GetBudgetItems(start, end, filterCat, catId));
                }
            }
            else
            {
                view.ClearBudgetTable();
            }

            // Update the user display settings to be accessed by other windows
            this.start = start;
            this.end = end;
            this.filterCategory = filterCategory;
            this.categoryId = catId;
            this.summarizeCategory = summarizeCategory;
            this.summarizeMonth = summarizeMonth;
        }

        public void SearchForBudgetItemInTable(int index, string searchWord, ItemCollection budgetItems, bool forTesting = false)
        {
            if(forTesting) { view.SelectItemInGrid(index); return; }

            searchWord = searchWord.ToLower();
            if (budgetItems.Count > 0 && searchWord != string.Empty)
            {
                int temp = index == -1 ? budgetItems.Count - 1 : index;
                while (true)
                {
                    index = (index + 1) % budgetItems.Count;

                    if (budgetItems[index] is not BudgetItem) break;

                    if (((BudgetItem)budgetItems[index]).Date.ToString().Contains(searchWord) ||
                        ((BudgetItem)budgetItems[index]).Balance.ToString().Contains(searchWord) ||
                        ((BudgetItem)budgetItems[index]).Amount.ToString().Contains(searchWord) ||
                        ((BudgetItem)budgetItems[index]).Category.ToLower().Contains(searchWord) ||
                        ((BudgetItem)budgetItems[index]).ShortDescription.ToLower().Contains(searchWord))
                    {
                        view.SelectItemInGrid(index);
                        break;
                    }

                    if (temp == index) break;
                }
            }
        }

        public void FillUpdateForm(int exp)
        {
            List<Expense> expenses = budget.expenses.List();

            Expense updatedExpense = null;
            foreach (Expense expense in expenses)
            {

                if (expense.Id == exp)
                {
                    updatedExpense = expense;
                }

            }


            expenseView.FillUpdateInformation(updatedExpense);
        }

        public void DeleteExpense(int id)
        {
            budget.expenses.Delete(id);

        }

        public void DeleteCategory(int categoryId)
        {

            budget.categories.Delete(categoryId);
        }
        public void CopyFile()
        {

            string copyFilePath = Presenter.folderPath + Presenter.fileName + "Copy.db";
            if (filePath == "")
            {
                MessageBox.Show("File must be saved at least once to duplicate");
            }
            else
            {
                File.Copy(Presenter.filePath, copyFilePath);
                MessageBox.Show("File has been successfully duplicated");
            }
        }

       public void CloseDatabase()
        {
            budget.CloseDB();
        }

        public bool CheckBlankFile(string file)
        {
            var dbFileInfo = new FileInfo(file);

            if (dbFileInfo.Length == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
