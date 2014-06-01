using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

//How to work with Mongo in .NET? http://docs.mongodb.org/ecosystem/tutorial/getting-started-with-csharp-driver/
namespace CES.ASP.Models
{
    public class Sample
    {
        public ObjectId Id { get; set; }
        public int sqft { get; set; }
        public float grand_total_weight { get; set; }
        public float grand_total_percentage { get; set; }
        public string weight_unit { get; set; }

        public virtual HashSet<Collection_Bin> MyProperty { get; set; }
    }

    public class Collection_Bin
    {
        public ObjectId Id {get; set;}
        public string Name { get; set; }
    }

    public class Location
    {
        public ObjectId Id { get; set; }
        public float Latitude { get; set; }

    }
}