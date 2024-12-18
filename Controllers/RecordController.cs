
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Recordboxed.Data;

namespace Recordboxed.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordController : ControllerBase 
    {
        private readonly DataContext _context;
        private readonly ILogger<RecordController> _logger;
        public RecordController(DataContext context, ILogger<RecordController> logger) {
            _context = context;
            _logger = logger;
            _logger.LogInformation("=== Controller INIT");
            _logger.LogInformation("=== db connstring {connectionString}", context.Database.GetConnectionString());

        }

        [HttpGet]
        public async Task<ActionResult<List<Record>>> GetAllRecords() {
            var records = await _context.Records.ToListAsync();
            _logger.LogInformation("=== Records contents: {ArrayContents}", records);
             
            return Ok(records);
        }
    }
}