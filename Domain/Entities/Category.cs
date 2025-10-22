﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Category
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Note> Notes { get; set; } = new List<Note>();
    }
}
