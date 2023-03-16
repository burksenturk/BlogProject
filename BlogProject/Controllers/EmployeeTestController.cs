using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlogProjectUI.Controllers
{
    public class EmployeeTestController : Controller
    {

        public async Task<IActionResult> Index()  //GET
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            var httpClient = new HttpClient(clientHandler);
            var responseMessage = await httpClient.GetAsync("https://localhost:44335/api/Default/");
            var jsonString = await responseMessage.Content.ReadAsStringAsync(); //response den gelen mesajın içeriğini read.. olarak al
            var values = JsonConvert.DeserializeObject<List<Class1>>(jsonString);  //claas1 employee'u yakalaması için atanan geçici class
            return View(values);
        }
        [HttpGet] //post un get i
        public IActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee(Class1 p) //post
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            var httpClient = new HttpClient(clientHandler);
            var jsonEmployee = JsonConvert.SerializeObject(p);
            StringContent content = new StringContent(jsonEmployee,Encoding.UTF8,"application/json");
            var responseMessage = await httpClient.PostAsync("https://localhost:44335/api/Default/", content); //contentden gelen değerle url ye gidecek
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index"); 
            }
            return View(p);
        }
        [HttpGet]
        public async Task<IActionResult> EditEmployee(int id) //put
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            var httpClient = new HttpClient(clientHandler);
            var responseMessage = await httpClient.GetAsync("https://localhost:44335/api/Default/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonString = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<Class1>(jsonString);
                return View(values);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> EditEmployee(Class1 p)  //put
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            var httpClient = new HttpClient(clientHandler);
            var jsonEmployee = JsonConvert.SerializeObject(p);
            var content = new StringContent(jsonEmployee,Encoding.UTF8,"application/json");
            var responseMessage = await httpClient.PutAsync("https://localhost:44335/api/Default/", content);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(p);
        }
        public async  Task<IActionResult> DeleteEmployee(int id)  //delete
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            var httpClient = new HttpClient(clientHandler);
            var responseMessage = await httpClient.DeleteAsync("https://localhost:44335/api/Default/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }


    }
    public class Class1
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
