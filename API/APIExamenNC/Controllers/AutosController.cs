using APIExamen.Core;
using APIExamen.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIExamenNC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutosController : ControllerBase
    {
        private readonly DataContext _context;

        public AutosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetMarca")]
        public async Task<ActionResult<List<DescripcionBase>>> GetMarca()
        {
            //return null;
            return Ok(await new ManejadorAutos(_context).GetMarca());
        }

        [HttpGet("GetSubMarca/{idMarca}")]
        public async Task<ActionResult<List<DescripcionBase>>> GetSubMarca(int idMarca)
        {
            //return null;
            return Ok(await new ManejadorAutos(_context).GetSubMarca(idMarca));
        }

        [HttpGet]
        [Route("GetModeloSubMarca/{idSubMarca}")]
        public async Task<ActionResult<List<DescripcionBase>>> GetModeloSubMarca(int idSubMarca)
        {
            return await new ManejadorAutos(_context).GetModeloSubMarca(idSubMarca);
        }

        [HttpGet]
        [Route("GetDescripcion/{idMarca}/{idSubMarca}/{idModeloSubMarca}")]
        public async Task<List<DescripcionModel>> GetDescripcion(int idMarca, int idSubMarca, int idModeloSubMarca)
        {
            return await new ManejadorAutos(_context).GetDescripcion(idMarca, idSubMarca, idModeloSubMarca);
        }
    }
}
