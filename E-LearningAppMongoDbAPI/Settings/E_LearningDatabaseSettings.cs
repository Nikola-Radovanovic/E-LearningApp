using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_LearningAppMongoDbAPI.Models
{
    public class E_LearningDatabaseSettings : IE_LearningDatabaseSettings
    {
        public string DatabaseName { get; set; }
        public string ConnectionString { get; set; }
        public string UsersCollectionName { get; set; }
        public string CoursesCollectionName { get; set; }
        public string SchoolsCollectionName { get; set; }
        public string CategoryCollectionName { get; set; }
    }

    public interface IE_LearningDatabaseSettings
    {
        string DatabaseName { get; set; }
        string ConnectionString { get; set; }
        string UsersCollectionName { get; set; }
        string CoursesCollectionName { get; set; }
        string SchoolsCollectionName { get; set; }
        string CategoryCollectionName { get; set; }
    }
}