using System.Linq;
using System.Threading.Tasks;
using bitacora.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bitacora.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class CategoryController: ControllerBase {
        private readonly DataContext _context;

        public CategoryController(DataContext context){
            _context=context;
        }

       
        public async Task<IActionResult>GetAll(){
            var categories=await _context.Categories.ToListAsync();
            return Ok(categories);
        
        }

        [HttpGet("{id}")]
        public IActionResult GetSingle(int id)
        {
            var category = _context.Categories.FirstOrDefault(q=> q.Id == id);
            return Ok(category);
        }
    }
}