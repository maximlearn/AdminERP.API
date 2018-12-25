using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Repositories
{
    public interface IGatePassStatusRepository
    {
        IEnumerable<T> All<T>();
        IEnumerable<T> GetByID<T>(int id);
    }
}
