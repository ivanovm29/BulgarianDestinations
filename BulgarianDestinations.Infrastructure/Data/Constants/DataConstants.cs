﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulgarianDestinations.Infrastructure.Data.Constants
{
    public class DataConstants
    {
        public const int NameMinLength = 1;
        public const int NameMaxLength = 50;

        public const int DescriptionMinLength = 50;
        public const int DescriptionMaxLength = 3000;

        public const int UserFirstNameMinLength = 1;
        public const int UserFirstNameMaxLength = 25;
        public const int UserLastNameMinLength = 1;
        public const int UserLastNameMaxLength = 30;

        public const int CommentMinLength = 1;
        public const int CommentMaxLength = 1000;

        public const int ArticulDescriptionMinLength = 1;
        public const int ArticulDescriptionMaxLength = 500;

        public const string ArticulPriceMin = "0";
        public const string ArticulPriceMax = "1000";
    }
}
