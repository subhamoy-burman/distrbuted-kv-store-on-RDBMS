using KeyValuePair.API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KeyValuePair.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeyValueController : ControllerBase
    {
        private readonly KeyValuePairsContext _context;

        public KeyValueController(KeyValuePairsContext context)
        {
            _context = context;
        }

        // GET: api/<KeyValueController>
        [HttpGet("{key}")]
        public async Task<ActionResult<KeyValuePairs>> GetMyTable(string key)
        {
            var myTable = await _context.MyTables.FindAsync(key);

            if (myTable == null || myTable.isDeleted)
            {
                return NotFound();
            }

            return myTable;
        }

        [HttpDelete("{key}")]
        public async Task<IActionResult> DeleteMyTable(string key)
        {
            var myTable = await _context.MyTables.FindAsync(key);
            if (myTable == null)
            {
                return NotFound();
            }

            myTable.isDeleted = true;
            _context.Entry(myTable).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
