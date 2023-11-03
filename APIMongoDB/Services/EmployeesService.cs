using APIMongoDB.Models;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using APIMongoDB.Configcurations;

namespace APIMongoDB.Services
{
    public class EmployeesService
    {
        private readonly IMongoCollection<Employees> _employees;

        public EmployeesService(IOptions<DatabaseSetting> databasesetting)
        {
            var mongoclient = new MongoClient(databasesetting.Value.ConnectionString);
            var mongodb = mongoclient.GetDatabase(databasesetting.Value.DatabaseName);
            _employees = mongodb.GetCollection<Employees>(databasesetting.Value.CollectionName);
        }

        public async Task<List<Employees>> GetEmployeesAsync() => await _employees.Find(filter: _ => true).ToListAsync();
        public async Task<Employees> GetEmployeesAsync(string id) => await _employees.Find(x=> x.Id == id).FirstOrDefaultAsync();
        public async Task InsertEmployeesAsync(Employees employees) => await _employees.InsertOneAsync(employees);
        public async Task UpdateEmployeesAsync(Employees employees) => await _employees.ReplaceOneAsync(x => x.Id == employees.Id, employees);
        public async Task DeleteEmployeesAsync(string id) => await _employees.DeleteManyAsync(x => x.Id == id);



    }

}
