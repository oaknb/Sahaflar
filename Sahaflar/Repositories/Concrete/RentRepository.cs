using Sahaflar.Entities;
using Sahaflar.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sahaflar.Repositories.Concrete
{
    public class RentRepository : IRentRepository
    {
        private Sahafs context;
        public RentRepository(Sahafs context)
        {
            this.context = context;
        }
        public bool AddRent(Rent rent)
        {
            context.Rents.Add(rent);

            return context.SaveChanges() > 0;
        }

        public List<Rent> GetRents()
        {
            return context.Rents.ToList();
            
        }

        public Rent GetRentById(int id)
        {
            Rent rent = context.Rents.Where(x => x.RentId == id).SingleOrDefault();

            return rent;
        }

        public int GetRentCountByDay(string date)
        {
            DateTime timeGap = Convert.ToDateTime(date);
            List<Rent> rents = context.Rents.Where(a => a.StartTime == timeGap).ToList();

            return rents.Count();
        }
    }
}
