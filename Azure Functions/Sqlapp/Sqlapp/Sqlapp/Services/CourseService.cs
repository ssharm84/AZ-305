using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Sqlapp.Models;
using StackExchange.Redis;
using System.Text.Json;
using System.Net.Http;

namespace Sqlapp.Services
{
    
    public class CourseService
    {
               
        public async Task<IEnumerable<Course>> GetCourses()
        {
            // Here we now make a call to the Azure Function
            // Make sure to replace the URL with your Azure Function
            string functionurl = "https://ss-function.azurewebsites.net/api/GetCourses?code=_2kDtMtvNMHL3L6ZlW7szHfvuHwxxCubno9TpboNyFsPAzFuPshAoA==";
            // We are using the HttpClient class to send a request to the Azure Function and to get a response
            using (HttpClient _client = new HttpClient())
            {
                HttpResponseMessage _response = await _client.GetAsync(functionurl);
                string _content = await _response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<IEnumerable<Course>>(_content);
            }
        }

    }
}

    

