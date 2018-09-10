using DataAccessLibrary;
using ProductApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProductApi.Controllers
{
    public class ActivityController : ApiController
    {
            [HttpGet]
            public IEnumerable<ActivityProduct> GetAllActivities()
            {
                using (ProductsApiEntities productObject = new ProductsApiEntities())
                {
                    return productObject.ActivityProducts.ToList();
                }
            }

            [HttpPost]
            public void AddActivity([FromBody]ActivityProduct activityObject)

            {
                using (ProductsApiEntities productObject = new ProductsApiEntities())
                {
                   
                    productObject.ActivityProducts.Add(activityObject);
                    productObject.SaveChanges();
                }

            }
            [HttpPut]
            public IHttpActionResult ActivityOperation([FromBody]Item item)
            {
                using (ProductsApiEntities productObject = new ProductsApiEntities())
                {
                    if (item.OperationType == "save")
                    {
                        var referenceobject = productObject.ActivityProducts.Find(item.ProductId);
                        string IsSaved = productObject.ActivityProducts.Find(item.ProductId).IsSaved;
                        IsSaved = "true";
                        referenceobject.IsSaved = IsSaved;
                        productObject.SaveChanges();
                        return Ok("saved");
                }
                    else
                    {
                        var referenceobject = productObject.ActivityProducts.Find(item.ProductId);
                        string IsBooked = productObject.ActivityProducts.Find(item.ProductId).IsBooked;
                        IsBooked = "true";
                        referenceobject.IsBooked = IsBooked;
                        productObject.SaveChanges();
                        return Ok("Booked");
                }
                }
            }
        }
}
