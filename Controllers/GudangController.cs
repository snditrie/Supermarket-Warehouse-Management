using Microsoft.AspNetCore.Mvc;
using SuperMarketApp.Data;
using SuperMarketApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SuperMarketApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GudangController : ControllerBase
    {
        private readonly SuperMarketContext _context;

        public GudangController(SuperMarketContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gudang>>> GetGudangs()
        {
            return await _context.Gudangs.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Gudang>> GetGudang(int id)
        {
            var gudang = await _context.Gudangs.FindAsync(id);

            if (gudang == null)
            {
                return NotFound();
            }

            return gudang;
        }

        [HttpPost]
        public async Task<ActionResult<Gudang>> PostGudang(Gudang gudang)
        {
            _context.Gudangs.Add(gudang);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGudang), new { id = gudang.GudangID }, gudang);
        }

        // Implement other CRUD operations (PUT, DELETE) as needed
    }
}
