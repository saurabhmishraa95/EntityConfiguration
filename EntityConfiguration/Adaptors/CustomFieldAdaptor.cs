using EntityConfiguration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace EntityConfiguration.Adaptors
{
    public class CustomFieldAdaptor : ICustomFieldAdaptor
    {
        static HttpClient client = new HttpClient();

        public CustomFieldAdaptor()
        {
            client.BaseAddress = new Uri("https://45363c1f-d47c-46dd-986c-1550578ed04d.mock.pstmn.io");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<FieldNameSet> GetFieldsAsync(string entityName)
        {
            FieldNameSet nameSet = new FieldNameSet();
            HttpResponseMessage response = await client.GetAsync("/API/CustomFields/" + entityName);
            if (response.IsSuccessStatusCode)
            {
                nameSet = await response.Content.ReadAsAsync<FieldNameSet>();
            }
            return nameSet;
        }
    }
}
