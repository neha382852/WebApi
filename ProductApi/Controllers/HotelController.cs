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
    public class HotelController : ApiController
    {
        [HttpGet]
        public IEnumerable<HotelProduct> GetAllHotels()
        {
            using (ProductsApiEntities productobject = new ProductsApiEntities())
            {
                return productobject.HotelProducts.ToList();
            }
        }

        [HttpPost]
        public void AddHotel([FromBody]HotelProduct hotelObject)

        {
            using (ProductsApiEntities productobject = new ProductsApiEntities())
            {
              
                productobject.HotelProducts.Add(hotelObject);
                productobject.SaveChanges();
            }

        }
        [HttpPut]
        public IHttpActionResult HotelOperation([FromBody]Item item)
        {
            using (ProductsApiEntities productobject = new ProductsApiEntities())
            {
                if (item.OperationType == "save")
                {
                    var referneceobject = productobject.HotelProducts.Find(item.ProductId);
                    string IsSaved = productobject.HotelProducts.Find(item.ProductId).IsSaved;
                    IsSaved = "true";
                    referneceobject.IsSaved = IsSaved;
                    productobject.SaveChanges();
                    return Ok("saved");
                }
                else
                {
                    var referneceobject = productobject.HotelProducts.Find(item.ProductId);
                    string IsBooked = productobject.HotelProducts.Find(item.ProductId).IsBooked;
                    IsBooked = "true";
                    referneceobject.IsBooked = IsBooked;
                    productobject.SaveChanges();
                    return Ok("Booked");
                }
            }
        }
    }
}
