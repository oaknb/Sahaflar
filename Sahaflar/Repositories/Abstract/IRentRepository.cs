using Sahaflar.Entities;
using System.Collections.Generic;

namespace Sahaflar.Repositories.Abstract
{
    public interface IRentRepository
    {
        bool AddRent(Rent rent);
        List<Rent> GetRents();

        Rent GetRentById(int id);

        int GetRentCountByDay(string date);
    }
}
