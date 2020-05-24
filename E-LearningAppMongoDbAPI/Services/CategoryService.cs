using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_LearningAppMongoDbAPI.Models;
using MongoDB.Driver;

namespace E_LearningAppMongoDbAPI.Services
{
    public class CategoryService
    {
        private readonly IMongoCollection<Category> _categories;

        public CategoryService(IE_LearningDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _categories = database.GetCollection<Category>(settings.CategoryCollectionName);
        }

        // GET /api/categories
        public List<Category> Get() =>
            _categories.Find(c => true).ToList();

        // GET /api/categories/{id}
        public Category Get(string id) =>
            _categories.Find(c => c.Id == id).FirstOrDefault();

        // POST
        public Category Create(Category category)
        {
            _categories.InsertOne(category);
            return category;
        }

        // PUT
        public void Update(string id, Category category) =>
            _categories.ReplaceOne(c => c.Id == id, category);

        //DELETE
        public void Remove(string id) =>
            _categories.DeleteOne(c => c.Id == id);
    }
}
