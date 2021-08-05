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
    [Route("api/[controller]")]
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
            _logger.LogInformation("Get");
            return await _context.Transactions.ToListAsync();
        }

        // GET: Transactions/Details/5
        [HttpGet("{id}")]
        public async Task<Transaction> Get(int id)
        {
            _logger.LogInformation("Get/id={0}", id);
            return await _context.Transactions.FirstOrDefaultAsync(m => m.TransactionId == id);
        }

        // POST: Transactions/Create
        [ValidateAntiForgeryToken]
        [HttpPost()]
        public async Task<int> Create(Transaction transaction)
        {
            _logger.LogInformation("Create/AccountNumber={0}", transaction.AccountNumber);
            _context.Add(transaction);
            return await _context.SaveChangesAsync();
        }

        // POST: Transactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [ValidateAntiForgeryToken]
        [HttpPut("{id}")]
        public async Task<int> Update(int id, Transaction transaction)
        {
            _logger.LogInformation("Update/AccountNumber={0}", transaction.AccountNumber);
            _context.Update(transaction);
            return await _context.SaveChangesAsync();
        }

    }
}
