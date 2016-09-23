using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingWeb.Enities
{
    public enum DepartmentType
    {
        unKnown,
        ElectronicsAndComputers,
        ClothingAndShoesAndJewelry,
        HomeAndGardenAndTools
    }
    public interface IProduct
    {
        DepartmentType Department { get; set; }
    }
}
