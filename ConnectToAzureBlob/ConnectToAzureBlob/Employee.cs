using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectToMongoDB
{
    public class Employee
    {
        public ObjectId _id;
        public string Emp_Id;
        public string Emp_Name;
        public bool InActive;
        public DateTime? Created;
        public IDictionary<string, object> CollectionDict;
        public List<string> CollectionString;
        public double Salary;
        public List<ObjectId> Files;
        public List<Uri> FilesUri;
        public dynamic DynamicField;
        public object ObjectField;

        public Employee()
        {
            CollectionDict = new Dictionary<string, object>();
            CollectionString = new List<string>();
            Files = new List<ObjectId>();
            FilesUri = new List<Uri>();
        }
    }
}
