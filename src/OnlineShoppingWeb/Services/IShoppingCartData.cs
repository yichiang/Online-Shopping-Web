﻿using OnlineShoppingWeb.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingWeb.Services
{
    public interface IShoppingCartData
    {
        IEnumerable<ShoppingCart> GetAll();
    }
}
