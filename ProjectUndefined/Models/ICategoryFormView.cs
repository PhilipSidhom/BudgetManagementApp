using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectUndefined.Models
{
    public interface ICategoryFormView
    {
        public void AddCategorySuccess();

        public void AddCategoryError(string error);
    }
}
