﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiApplication.Core.Models
{
    public class Department : BaseModel
    {
        public string Name { get; set; }

        public DateOnly DateOfCreation { get; set; }
    }
}
