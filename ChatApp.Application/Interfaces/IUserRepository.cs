using ChatApp.Domain.Entities;
using ChatApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Application.Interfaces;

public interface IUserRepository
{
    Task<CrudResults> CreateAccount(User user);
    Task<CrudResults> UpdateAccount(User user);
    Task<CrudResults> FindAccountByEmail(string email);
    Task<CrudResults> DeleteAccount(string accountId);
}
