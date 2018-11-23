using System;
using System.Collections.Generic;
using System.Text;
using CoffMana.Models;
using System.Threading.Tasks;

namespace CoffMana.Services
{
    public interface IRestService
    {
        Task<List<User>> RefreshDataAsync();

        Task SaveTodoItemAsync(User item, bool isNewItem);

        Task DeleteTodoItemAsync(String id);
    }
}
