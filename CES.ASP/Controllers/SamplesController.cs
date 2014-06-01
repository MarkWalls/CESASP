using System;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using CES.ASP.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CES.ASP.Controllers
{
   

    public class SamplesController : Controller
    {
         //Ok, this is awful - should put this in its own repository, but.... It works for now
        public MongoClient mongoClient { get; set; }
        public MongoServer mongoServer { get; set; }
        public MongoDatabase db { get; set; }
        public string connectionString { get; set; }
        

        /// <summary>
        /// Initializes a new instance of the <see cref="SamplesController" /> class.
        /// </summary>
        public SamplesController()
        {
            //Create Instance
            //Get the connection string from Web.Config
            this.connectionString = ConfigurationManager.ConnectionStrings["MongoConnection"].ConnectionString;
            
            //Create the connection to the MongoDb
            this.mongoClient = new MongoClient(connectionString);
            this.mongoServer = mongoClient.GetServer();
            db = mongoServer.GetDatabase("SampleDb");
            
        }

        // GET: Samples
        public ActionResult Index()
        {
            MongoCollection<Sample> Samples = null;
            if(db.CollectionExists("Samples"))
                Samples = db.GetCollection<Sample>("Samples");
            else
                db.CreateCollection("Samples");

            if (Samples != null)
                return View(Samples.FindAll());
            else
                return View();
          
        }

        // GET: Samples/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Samples/Create
        public ActionResult Create()
        {

            //Just create a sample object for now to add
                //I am getting a bit sleepy :)
                Sample NewSample = new Sample{
                     sqft = 123,
                     grand_total_weight = 5246,
                     grand_total_percentage = 12.0f,
                     weight_unit = "lbs"
                };

               AddSample(NewSample);

            return View();
        }

        private ObjectId AddSample(Sample NewSample)
        {
            var Samples = db.GetCollection<Sample>("Samples");
            Samples.Insert<Sample>(NewSample);
            return NewSample.Id;

        }

        //// POST: Samples/Create
        //[HttpPost]
        //public ActionResult Create()
        //{
        //    try
        //    {
               
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: Samples/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Samples/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Samples/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Samples/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
