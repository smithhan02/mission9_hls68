using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using mission9_hls68.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace mission9_hls68.Models
{
    public class SessionBasket : Basket
    {

        public static Basket GetBasket(IServiceProvider services)
        {
            //This line pulls info about the session. 
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

           // if basket already exists, this will get that one, otherwise it will make a new one
            SessionBasket basket = session?.GetJson<SessionBasket>("Basket") ?? new SessionBasket();

            //creating an instance of session basket called basket and 
            basket.Session = session;
            //return basket to GetBasket method 
            return basket;
        }
        //JsonIgnor prevents a property from being serialized or deserialized
        [JsonIgnore]
        public ISession Session { get; set; }

        public override void AddItem(Books Book, int qty)
        {
            base.AddItem(Book, qty);
            Session.SetJson("Basket", this) ;
        }

        public override void RemoveItem(Books Book)
        {
            base.RemoveItem(Book);
            Session.SetJson("Basket", this);
        }


        public override void ClearBasket()
        {
            base.ClearBasket();
            Session.Remove("Basket");
        }
    }
}
