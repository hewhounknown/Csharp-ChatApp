using ChatApp.Domain.Entities;
using ChatApp.Domain.Enums;

namespace ChatApp.Application.Interfaces.Repositories;

public interface IUserRepository
{
  Task<CrudResults> CreateAccount(User user);
  Task<CrudResults> UpdateAccount(User user);
  Task<User> FindAccountByEmail(string email);
  Task<CrudResults> DeleteAccount(string accountId);
}
