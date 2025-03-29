using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ServiceOrderCreatorApi.Data
{
    public class ApplicationDBContext(DbContextOptions dbContextOptions)
        : DbContext(dbContextOptions) { }
}
