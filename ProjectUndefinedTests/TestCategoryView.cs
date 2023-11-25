using ProjectUndefined.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// testing commit 
// testing2

namespace ProjectUndefinedTests
{
    public class TestCategoryView : ICategoryFormView
    {
        public bool CategoryErrorAdded { get; private set; }
        public bool CategorySuccessAdded { get; private set; }
        public void AddCategoryError(string error)
        {
            CategoryErrorAdded = true;
        }

        public void AddCategorySuccess()
        {
            CategorySuccessAdded = true;
        }
    }
}
