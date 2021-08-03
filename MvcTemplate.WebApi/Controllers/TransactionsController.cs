using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcTemplate.WebApi.Models;
using MvcTemplate.WebApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace MvcTemplate.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionsController : ControllerBase
    {
        private readonly OracleDbContext _context;
        private readonly ILogger<TransactionsController> _logger;

        public TransactionsController(ILogger<TransactionsController> logger, OracleDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: Blog
        [HttpGet]
        public async Task<IEnumerable<Transaction>> Get()
        {
            return await _context.Transactions.ToListAsync();
        }
    }
}
