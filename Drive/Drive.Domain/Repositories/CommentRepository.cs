﻿using Drive.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drive.Domain.Repositories
{
    public class CommentRepository : BaseRepository
    {
        public CommentRepository(DriveDbContext dbContext) : base(dbContext)
        {
        }
    }
}
