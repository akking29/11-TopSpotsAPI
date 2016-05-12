using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;

namespace _11_TopSpotsAPI.Controllers
{
    [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
    public class TopSpotsController : ApiController
    {
        public List<Models.TopSpot> objects = new List<Models.TopSpot>();
        // GET: api/TopSpots
        public IEnumerable<Models.TopSpot> Get()
        {
            string json = File.ReadAllText("c://Dev/GitHub/11-TopSpotsAPI/11-TopSpotsAPI/App_Data/TopSpot.json");
            var objects = JsonConvert.DeserializeObject<List<Models.TopSpot>>(json);
            return objects;
        }

        // GET: api/TopSpots/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/TopSpots
        public Models.TopSpot Post(Models.TopSpot spot)
        {

            string json = File.ReadAllText("c://Dev/GitHub/11-TopSpotsAPI/11-TopSpotsAPI/App_Data/TopSpot.json");
            var objects = JsonConvert.DeserializeObject<List<Models.TopSpot>>(json);

            objects.Add(spot);

            string NewJson = Newtonsoft.Json.JsonConvert.SerializeObject(objects);
            File.WriteAllText("c://Dev/GitHub/11-TopSpotsAPI/11-TopSpotsAPI/App_Data/TopSpot.json", NewJson);

            return spot;

        }

        // PUT: api/TopSpots/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TopSpots/5
        public void Delete(int id)
        {
        }
    }
}
