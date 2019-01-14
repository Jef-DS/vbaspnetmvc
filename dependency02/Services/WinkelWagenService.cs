using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dependency02.Services
{
    public class WinkelWagenService:IEnumerable<String>
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        public WinkelWagenService(IHttpContextAccessor contextAccessor)
        {
            this.httpContextAccessor = contextAccessor;
        }
        private List<String> GetProductList()
        {
            ISession session = this.httpContextAccessor.HttpContext.Session;
            List<String> producten = session.GetObjectFromJson<List<String>>("producten");
            if (producten == null)
            {
                producten = new List<String>();
            }
            return producten;
        }
        private void BewaarProductList(List<String> producten)
        {
            ISession session = this.httpContextAccessor.HttpContext.Session;
            session.SetObjectAsJSon("producten", producten);
        }
        public void AddProduct(String product)
        {
            List<String> producten = GetProductList();
            producten.Add(product);
            BewaarProductList(producten);
        }

        public IEnumerator<string> GetEnumerator()
        {
            List<String> producten = GetProductList();
            return producten.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetProductList().GetEnumerator();
        }
    }
    public static class SessionExtensions
    {
        public static void SetObjectAsJSon<T>(this ISession session, String key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
        public static T GetObjectFromJson<T>(this ISession session, String key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
