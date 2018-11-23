using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.IO;
using System.Threading.Tasks;
using CoffMana.Models;

namespace CoffMana.Services
{
    public class DatabaseService
    {
        readonly SQLiteAsyncConnection database;

        public DatabaseService(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
        }

        public void creatAllTalbe(){
            database.CreateTableAsync<User>().Wait();
            database.CreateTableAsync<Producer>().Wait();
            database.CreateTableAsync<Farm>().Wait();
            database.CreateTableAsync<Coffee>().Wait();
            database.CreateTableAsync<CoffeeHistory>().Wait();
            database.CreateTableAsync<Order>().Wait();
        }

        public Task<List<User>> GetUserAsync(User u)
        {
            return database.QueryAsync<User>("SELECT User.username FROM User WHERE User.username = ? AND User.password = ?",
                new Object[] { u.username, u.password });
        }

        public Task<int> InsertNewUserAsync(User u)
        {
            return database.ExecuteAsync("INSERT INTO User(username, password) VALUE (?,?)",
                new object[] { u.username, u.password});
        }

        public Task<int> UpdateUserTokenAsync(User u)
        {
            return database.ExecuteAsync("UPDATE User SET User.temp_token = ? WHERE User.username = ?",
                new object[] {u.temp_token, u.username});
        }

        public Task<int> InsertNewCoffeeOrderAsync(Order order)
        {
            return database.ExecuteAsync("INSERT INTO Order(for_coffee, quantity, order_year, order_month, order_day, order_status, comment) VALUE (?,?,?,?,?,?,?)",
                new object[] { order.for_coffee_id, order.quantity, order.order_year, order.order_month, order.order_day, order.order_status, order.comment });
        }

        public Task<List<Order>> GetAllLocalCoffeeOrderAsync()
        {
            return database.QueryAsync<Order>("SELECT * FROM Order WHERE Order.guid IS NULL");
        }
    }
}
