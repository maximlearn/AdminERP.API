using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Repositories
{
    public interface IUserCredentialRepository
    {
        IEnumerable<T> All<T>();
        IEnumerable<T> GetByID<T>(int id);
    }
}
