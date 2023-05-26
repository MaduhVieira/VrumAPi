using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VrumApi.Models;

namespace VrumApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrosController : ControllerBase
    {
        private readonly VrumApiContext _context;

        public CarrosController(VrumApiContext context)
        {
            _context = context;
        }

        // GET: api/Carros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarroDTO>>> GetCarro()
        {
            return await _context.Carro
            .Select(x => CarroToDTO(x))
            .ToListAsync();
        }

        // GET: api/Carros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarroDTO>> GetCarro(int id)
        {
            var carro = await _context.Carro.FindAsync(id);

            if (carro == null)
            {
                return NotFound();
            }

            return CarroToDTO(carro);
        }

        // PUT: api/Carros/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarro(int id, Carro carro)
        {
            if (id != carro.Id)
            {
                return BadRequest();
            }

            _context.Entry(carro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarroExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Carros
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Carro>> PostCarro(Carro carro)
        {
            _context.Carro.Add(carro);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCarro), new { id = carro.Id }, carro);
        }

        // DELETE: api/Carros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarro(int id)
        {
            var carro = await _context.Carro.FindAsync(id);
            if (carro == null)
            {
                return NotFound();
            }

            _context.Carro.Remove(carro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarroExists(int id)
        {
            return _context.Carro.Any(e => e.Id == id);
        }

        private static CarroDTO CarroToDTO(Carro carro)=>
            new CarroDTO
            {
                Id = carro.Id,
                Marca = carro.Marca,
                Modelo = carro.Modelo,
                Ano = carro.Ano,
                Placa = carro.Placa,
                Tipo = carro.Tipo,
                Idade = carro.CalculaIdade()
            };
    }
}
