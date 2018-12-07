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
        private readonly SQLiteAsyncConnection database;
        private static DatabaseService dataabseInstance;


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

        public static DatabaseService GetDatabaseInstance()
        {
            if (dataabseInstance == null)
            {
                dataabseInstance = new DatabaseService(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CoffManaDB.db3"));
                dataabseInstance.creatAllTalbe();
            }
            return dataabseInstance;
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

        public Task<int> InsertNewCoffeeAsync(Coffee coff)
        {
            return database.ExecuteAsync("INSERT INTO Coffee(coffee_id, variety, process, description, for_farm_id, for_producter_id, for_history_id) VALUE (?,?,?,?,?,?,?)",
                new object[] {coff.coffee_id, coff.variety, coff.process, coff.description, coff.for_farm_id, coff.for_producter_id, coff.for_history_id});
        }

        public async Task<List<Order>>GetAllMockingCoffeeOrderList()
        {
            return await database.QueryAsync<Order>(
                "SELECT o.order_id, o.quantity, o.order_year, o.order_month, o.order_day, o.order_status, o.comment, o.varionty, o.process " +
                "FROM Order o"
                );
        }

        public Task<int> InsertMockingCoffeeOrderAsync(Order order)
        {
            return database.ExecuteAsync("INSERT INTO Order(for_coffee, quantity, order_year, order_month, order_day, order_status, comment, variety, quantity) VALUE (?,?,?,?,?,?,?,?,?,?)",
                new object[] { order.for_coffee_id, order.quantity, order.order_year, order.order_month, order.order_day, order.order_status, order.comment, order.variety, order.quantity });
        }


        public Task<int> InsertNewCoffeeOrderAsync(Order order)
        {
            return database.ExecuteAsync("INSERT INTO Order(order_id, for_coffee, quantity, order_year, order_month, order_day, order_status, comment) VALUE (?,?,?,?,?,?,?,?)",
                new object[] {order.order_id, order.for_coffee_id, order.quantity, order.order_year, order.order_month, order.order_day, order.order_status, order.comment });
        }

        public Task<List<Order>> GetAllLocalCoffeeOrderAsync()
        {
            return database.QueryAsync<Order>("SELECT * FROM Order WHERE Order.guid IS NULL");
        }
    }
}
