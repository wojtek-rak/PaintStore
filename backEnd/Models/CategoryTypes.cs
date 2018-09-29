﻿using System;
using System.Collections.Generic;
using backEnd.Interfaces;

namespace backEnd.Models
{
    public partial class CategoryTypes : ITypeSearchResult
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public int Count { get; set; }
    }
}
