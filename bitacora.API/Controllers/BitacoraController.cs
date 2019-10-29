using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bitacora.API.Data;
using bitacora.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace bitacora.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class BitacoraController: ControllerBase {
        private readonly DataContext _context;

        public BitacoraController(DataContext context){
            _context=context;
        }

       [HttpGet]
        public async Task<IActionResult>GetAll(){
            var bitacoras=await _context.Bitacoras.ToListAsync();
            return Ok(bitacoras);
        }

        [HttpGet("{id}")]
        public IActionResult GetSingle(DateTime id)
        {
            var bitacora = _context.Bitacoras.FirstOrDefault(q=> q.bitacoraFecha== id);
            return Ok(bitacora);
        }




        // [HttpGet("rango")]
        // public Task<IActionResult> GetDatebyRange(IEnumerable<DateTime> ods)
        // {
        //     IEnumerable<Bitacora> bitacora =  _context.Bitacoras.Where(q=>ods.Contains(q.bitacoraFecha)) ;
        //     //var bitacoras = await _context.Bitacoras.Where(s => s.bitacoraFecha >= fechaI && s.bitacoraFecha<=fechaF).ToListAsync();
          
        //     return (bitacora);
        // }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutBitacora(int id, Bitacora bitacora)
        {
            if (id != bitacora.bitacoraId)      
            {
                return BadRequest();
            }

            _context.Entry(bitacora).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BitacoraExists(id))
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

        [HttpPost]
        public async Task<ActionResult<Bitacora>> PostCalificacion(Bitacora bitacora)
        {
            _context.Bitacoras.Add(bitacora);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getbitacora", new { id = bitacora.bitacoraId }, bitacora);
        }

         [HttpDelete("{id}")]
        public async Task<ActionResult<Bitacora>> DeleteBitacora(int id)
        {
            var bitacora = await _context.Bitacoras.FindAsync(id);
            if (bitacora == null)
            {
                return NotFound();
            }

            _context.Bitacoras.Remove(bitacora);
            await _context.SaveChangesAsync();

            return bitacora;
        }

        private bool BitacoraExists(int id)
        {
            return _context.Bitacoras.Any(e => e.bitacoraId == id);
        }
    }
}