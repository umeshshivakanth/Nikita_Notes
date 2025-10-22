﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface INoteRepository
    {
        IEnumerable<Note> GetAll();
        Note GetById(int id);
        void Add(Note note);
        void Update(Note note);
        void Delete(int id);
    }
}
