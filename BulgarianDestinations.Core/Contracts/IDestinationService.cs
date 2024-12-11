﻿using BulgarianDestinations.Core.Models.Destination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulgarianDestinations.Core.Contracts
{
    public interface IDestinationService
    {
        Task<DestinationViewModel> DestinationInformation(int id);
        Task<bool> IsContain(int destinationId, int personId);
    }
}
