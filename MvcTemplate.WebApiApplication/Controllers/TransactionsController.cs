using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcTemplate.Api.WebApplication.Models;
using static MvcTemplate.Api.WebApplication.Helper;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace MvcTemplate.Api.WebApplication.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly ILogger<TransactionsController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;
        private readonly string _url;

        public TransactionsController(ILogger<TransactionsController> logger, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _url = _configuration["Position:ApiService"];
            //_clientHandler.ServerCertificateCustomValidationCallback(sender, cert, chain, sslPolicyErrors) => { return true; };
        }

        [HttpGet]
        public async Task<List<Transaction>> GetAll()
        {
            var models = new List<Transaction>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_url + "/api/Transactions"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    models = JsonConvert.DeserializeObject<List<Transaction>>(apiResponse);
                }
            }
            return models;
        }

        // GET: Transaction
        public async Task<IActionResult> Index()
        {
            return View(await GetAll());
        }

        // GET: Transaction/AddOrEdit(Insert)
        // GET: Transaction/AddOrEdit/5(Update)
        [NoDirectAccess]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Transaction());
            else
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(_url + "/api/Transactions/" + id.ToString()))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        var model = JsonConvert.DeserializeObject<Transaction>(apiResponse);
                        if (model == null)
                        {
                            return NotFound();
                        }
                        return View(model);
                    }
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("TransactionId,AccountNumber,BeneficiaryName,BankName,SwiftCode,Amount,TransactionDate")] Transaction model)
        {
            if (ModelState.IsValid)
            {
                //Insert
                if (id == 0)
                {
                    model.TransactionDate = DateTime.Now;
                    StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                    using (var httpClient = new HttpClient())
                    {
                        using (var response = await httpClient.PostAsync(_url + "/api/Transactions", content))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            var result = JsonConvert.DeserializeObject<int>(apiResponse);
                            //if (result == null)
                            //{
                            //    return NotFound();
                            //}
                        }
                    }
                }
                //Update
                else
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                    using (var httpClient = new HttpClient())
                    {
                        using (var response = await httpClient.PutAsync(_url + "/api/Transactions", content))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            var result = JsonConvert.DeserializeObject<int>(apiResponse);
                            //if (result == null)
                            //{
                            //    return NotFound();
                            //}
                        }
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await GetAll()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", model) });
        }

        //// GET: Transaction/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var model = await _context.Transactions
        //        .FirstOrDefaultAsync(m => m.TransactionId == id);
        //    if (model == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(model);
        //}

        //// POST: Transaction/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var model = await _context.Transactions.FindAsync(id);
        //    _context.Transactions.Remove(model);
        //    await _context.SaveChangesAsync();
        //    return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Transactions.ToList()) });
        //}

        //private bool TransactionExists(int id)
        //{
        //    return _context.Transactions.Any(e => e.TransactionId == id);
        //}
    }
}
