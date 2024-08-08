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
    public class BarangController : ControllerBase
    {
        private readonly SuperMarketContext _context;

        public BarangController(SuperMarketContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Barang>>> GetBarangs()
        {
            return await _context.Barangs.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Barang>> GetBarang(int id)
        {
            var barang = await _context.Barangs.FindAsync(id);

            if (barang == null)
            {
                return NotFound();
            }

            return barang;
        }

        [HttpPost]
        public async Task<ActionResult<Barang>> PostBarang(Barang barang)
        {
            _context.Barangs.Add(barang);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBarang), new { id = barang.BarangID }, barang);
        }

        // Implement other CRUD operations (PUT, DELETE) as needed
    }
}
