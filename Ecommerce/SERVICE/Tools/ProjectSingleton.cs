﻿using DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICE.Tools
{
    public class ProjectSingleton
    {
        private ProjectSingleton()
        {

        }

        private static AppDbContext _context;
        public static AppDbContext Context
        {
            get
            {
                if (_context == null)
                    _context = new AppDbContext();
                return _context;
            }
        }
    }
}
