using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceOrderCreatorApi.Models;

namespace ServiceOrderCreatorApi.Data
{
    public class DatabaseSeeder
    {
        private readonly ApplicationDBContext _context;

        public DatabaseSeeder(ApplicationDBContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (!_context.ServiceTypes.Any())
            {
                _context.ServiceTypes.AddRange(
                    new ServiceType
                    {
                        Title = "Developer",
                        OptionsData =
                            "{\"Version\":1,\"Options\":[\"Create database\",\"Finish backend\",\"Play with css and html\",\"Dont sleep\"]}",
                    },
                    new ServiceType
                    {
                        Title = "Mechanic",
                        OptionsData =
                            "{\"Version\":1,\"Options\":[\"Fix Car\",\"Drive arround clients car\",\"Fix truck\",\"Uber\"]}",
                    },
                    new ServiceType
                    {
                        Title = "Designer",
                        OptionsData =
                            "{\"Version\":1,\"Options\":[\"Do pretty screens, I guess\"]}",
                    }
                );

                _context.SaveChanges();
            }
        }
    }
}
