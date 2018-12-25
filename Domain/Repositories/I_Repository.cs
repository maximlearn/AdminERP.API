using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Repositories
{
    public interface I_Repository
    {
        IEnumerable<T> All<T>();
        IEnumerable<T> GetByID<T>(int id);
    }
}
