using MultiLanguage.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using Microsoft.Extensions.Options;
using MongoDB.Driver.Linq;
using Microsoft.EntityFrameworkCore.Extensions.Internal;

namespace MultiLanguage.Data
{
    public class PizzaDbContext : IPizzaDbContext
    {
        private readonly IOptions<DbConfig> _dbConfig;
        private IMongoDatabase _context;

        public PizzaDbContext(IOptions<DbConfig> dbConfig)
        {
            _dbConfig = dbConfig;
            var mongoClient = new MongoClient(_dbConfig.Value.ConnectionString);
            _context = mongoClient.GetDatabase(_dbConfig.Value.DbName);
        }

        public IEnumerable<Pizza> GetPizzasCollection()
        {
            var pizzasCollection = _context.GetCollection<Pizza>(_dbConfig.Value.Collection);
            return pizzasCollection.AsQueryable().ToList();
        }
    }
}
