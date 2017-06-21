using System.Linq.Dynamic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Co11PropProject.Infrastructure;
using Co11PropProject.Models;
using System.Text;

namespace Co11PropProject.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PropertiesController : ApiController
    {
        private DataContext db = new DataContext();
        



        // GET: api/Properties
        public IQueryable<Property> GetProperties()
        {
            return db.Properties;
        }

        // GET: api/Properties/5
        [ResponseType(typeof(Property))]
        public IHttpActionResult GetProperty(int id)
           {
            Property property = db.Properties.Find(id);
            if (property == null)
            {
                return NotFound();
            }
            return Ok(property);
        }

           

        // PUT: api/Properties/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProperty(int id, Property property)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != property.PropertyId)
            {
                return BadRequest();
            }

            db.Entry(property).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PropertyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Properties
        [ResponseType(typeof(Property))]
        public IHttpActionResult PostProperty(Property property)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Properties.Add(property);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = property.PropertyId }, property);
        }

        // DELETE: api/Properties/5
        [ResponseType(typeof(Property))]
        public IHttpActionResult DeleteProperty(int id)
        {
            Property property = db.Properties.Find(id);
            if (property == null)
            {
                return NotFound();
            }

            db.Properties.Remove(property);
            db.SaveChanges();

            return Ok(property);
        }


        // PropertySearch
        [HttpGet]
        [Route("api/Properties/PropertySearch")]
        public IQueryable<Property> PropertySearch([FromUri] PropertySearch search)
        {
            IQueryable<Property> finalProperties = db.Properties;


            if (search.Bedrooms != null)
            {
                finalProperties = finalProperties.Where(p => p.Bedrooms == search.Bedrooms);
            }
            if (search.Bathrooms != null)
            {
                finalProperties = finalProperties.Where(p => p.Bathrooms == search.Bathrooms);
            }

            if (search.MinRent != null)
            {
                finalProperties = finalProperties.Where(p => p.RentMonth >= search.MinRent);
            }
            if (search.MaxRent != null)
            {
                finalProperties = finalProperties.Where(p => p.RentMonth <= search.MaxRent);
            }

            //if (search.ZipCode != null)
            //{
            //    finalProperties = finalProperties.Where(p => p.ZipCode == search.ZipCode);
            //}

            if (search.City != null)
            {
                finalProperties = finalProperties.Where(p => p.City == search.City);
            }

            return (finalProperties);
        }




        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PropertyExists(int id)
        {
            return db.Properties.Count(e => e.PropertyId == id) > 0;
        }
    }
}



//if(bed!=null)
//{ 
//var beds = from b in db.Properties
//           where b.Equals(bed)
//           select b;

//return Ok(beds);
//}
//if (bath != null)
//{

//    var baths = from b in db.Properties
//                where b.Equals(bath)
//                select b;

//    return Ok(baths);
//}
//if (minRent!= null|| maxRent!= null)
//{
//    var rent = from r in db.Properties
//               where r.RentMonth > minRent && r.RentMonth <= maxRent
//               select r;
//    return Ok(rent);

//   }

//if (city != null)
//{

//    var cities = from c in db.Properties
//                where c.Equals(city)
//                select c;

//    return Ok(city);
//}