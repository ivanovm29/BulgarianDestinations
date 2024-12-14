﻿using BulgarianDestinations.Core.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulgarianDestinations.Core.Contracts
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderViewModel>> All();

        Task<OrderDeatilsViewModel> OrderInformation(int orderId);

        Task DeleteOrder(int orderId);
    }
}