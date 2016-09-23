
using System;

namespace OnlineShoppingWeb.Enities
{
    public class ElectronicsAndComputers : IProduct
    {
        public DepartmentType Department
        {
            get
            {
                return DepartmentType.ElectronicsAndComputers;
             }

            set
            {
                Department = DepartmentType.ElectronicsAndComputers;
            }
        }
    }
}
