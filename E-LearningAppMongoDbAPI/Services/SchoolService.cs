using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_LearningAppMongoDbAPI.Models;
using MongoDB.Driver;

namespace E_LearningAppMongoDbAPI.Services
{
    public class SchoolService
    {
        private readonly IMongoCollection<School> _schools;

        public SchoolService(IE_LearningDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _schools = database.GetCollection<School>(settings.SchoolsCollectionName);
        }

        // GET /api/schools
        public List<School> Get() =>
            _schools.Find(s => true).ToList();

        // GET /api/schools/{id}
        public School Get(string id) =>
            _schools.Find(s => s.Id == id).FirstOrDefault();

        // POST
        public School Create(School school)
        {
            _schools.InsertOne(school);
            return school;
        }

        // PUT
        public void Update(string id, School school) =>
            _schools.ReplaceOne(s => s.Id == id, school);

        //DELETE
        public void Remove(string id) =>
            _schools.DeleteOne(s => s.Id == id);
    }
}
