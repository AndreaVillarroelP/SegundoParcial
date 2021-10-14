using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SegundoParcial.Data;
using SegundoParcial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SegundoParcial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MagicController : ControllerBase
    {
        private readonly AppDbContext _context;
        public MagicController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<Magic>> GetMagic()
        {
            var list = await _context.Magic.ToListAsync();
            var max = list.Count;
            int index = new Random().Next(0, max);
            var Magic = list[index];
            if (Magic == null)
            {
                return NoContent();
            }

            return Magic;
        }
    }
}
