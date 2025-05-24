using _2.BLL.Services;
using Microsoft.AspNetCore.Mvc;
using Web_API.DTOs.PrestamosDTO;
using _1.DAL;
using Microsoft.EntityFrameworkCore;
using _1.DAL.DataContext;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web_API.Controllers.Prestamo
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestamoController : ControllerBase
    {

        private readonly IServices _services;

        public PrestamoController(IServices services)
        {
            this._services = services;
        }

        // GET: api/<PrestamoController>  
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrestamoDTO>>> Get()
        {
            try
            {
                List<_1.DAL.DataContext.Prestamo> list_C = await _services.GetPrestamosAllAsync();

                if (list_C.Count <= 0)
                {
                    return NotFound("No se encontraron prestamos");
                }

                List<PrestamoDTO> list_CDTO = list_C.Select(c => new PrestamoDTO()
                {
                    Id = c.Id,
                    UsuarioId = c.UsuarioId,
                    Monto = c.Monto,
                    PlazoEnMeses = c.PlazoEnMeses,
                    EstadoPrestamoId = c.EstadoPrestamoId,
                    FechaSolicitud = c.FechaSolicitud,
                    MotivoRechazo = c.MotivoRechazo,
                    EstadoPrestamo = c.EstadoPrestamo, //
                    Usuario = c.Usuario //id del usuario
                }).ToList();

              
                return Ok(list_CDTO);

            }
            catch (Exception e)
            {
                return NotFound("There was a problem: " + e.Message.ToString());
            }
        }

        // GET api/<PrestamoController>/5  
        [HttpGet("{id}")]
        public async Task<ActionResult<PrestamoDTO>> Get(int id)
        {
            try
            {
                var prestamo = await _services.GetByPrestamoIdAsync(id);
                if (prestamo == null)
                {
                    return NotFound("No se encontraron prestamos con ese Id");
                }

                PrestamoDTO prestamoDTO = new PrestamoDTO()
                {
                    Id = prestamo.Id,
                    UsuarioId = prestamo.UsuarioId,
                    Monto = prestamo.Monto,
                    PlazoEnMeses = prestamo.PlazoEnMeses,
                    EstadoPrestamoId = prestamo.EstadoPrestamoId,
                    FechaSolicitud = prestamo.FechaSolicitud,
                    MotivoRechazo = prestamo.MotivoRechazo,
                    EstadoPrestamo = prestamo.EstadoPrestamo,
                    Usuario = prestamo.Usuario
                };
                return Ok(prestamoDTO);
            }
            catch (Exception e)
            {
                return NotFound("There was a problem: " + e.Message.ToString());
            }
        }

        // POST api/<PrestamoController>  
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PrestamoDTO value)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var prestamo = new _1.DAL.DataContext.Prestamo()
                {
                    UsuarioId = value.UsuarioId,
                    Monto = value.Monto,
                    PlazoEnMeses = value.PlazoEnMeses,
                    EstadoPrestamoId = value.EstadoPrestamoId,
                    FechaSolicitud = DateTime.Now,
                    MotivoRechazo = value.MotivoRechazo
                };
                int result = await _services.CrearPrestamosAsync(prestamo);

                if (result > 0)
                {
                    return Ok("Prestamo creado exitosamente");
                }
                else
                {
                    return BadRequest("Se generó un error en la creación del Prestamo");
                }

            }
            catch (Exception e)
            {
                return NotFound("There was a problem: " + e.Message.ToString());

            }
        }

        // PUT api/<PrestamoController>/5  
        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromBody] PrestamoDTO value)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var prestamo = new _1.DAL.DataContext.Prestamo()
                {
                    UsuarioId = value.UsuarioId,
                    Monto = value.Monto,
                    PlazoEnMeses = value.PlazoEnMeses,
                    EstadoPrestamoId = value.EstadoPrestamoId,
                    FechaSolicitud = DateTime.Now,
                    MotivoRechazo = value.MotivoRechazo
                };
                await _services.ActualizarPrestamoAsync(prestamo);

                return Ok("Prestamo actualizado exitosamente");
            }
            catch (Exception e)
            {
                return NotFound("There was a problem: " + e.Message.ToString());
            }

        }

        //cambiar estado prestamo
        [HttpPut("cambiarEstado/{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult> CambiarEstado(int id, [FromBody] int estadoId)
        {
            try
            {
                var prestamo = await _services.GetByPrestamoIdAsync(id);
                if (prestamo == null)
                {
                    return NotFound("No se encontraron prestamos con ese Id");
                }
                prestamo.EstadoPrestamoId = estadoId;
                await _services.ActualizarPrestamoAsync(prestamo);
                return Ok("Estado del prestamo actualizado exitosamente");
            }
            catch (Exception e)
            {
                return NotFound("There was a problem: " + e.Message.ToString());
            }
        }



        //// DELETE api/<PrestamoController>/5  
        //[HttpDelete("{id}")]
        //public async Task<ActionResult> Delete(int id)
        //{
        //    try
        //    {
        //        var prestamo = await _services.GetByPrestamoIdAsync(id);

        //        if (prestamo == null)
        //        {
        //            return NotFound("No se encontraron prestamos con ese Id");
        //        }
        //        await _services.eliminarPrestamo(prestamo); // No existe este metodo en el servicio
        //        return Ok("Prestamo deleted successfully");
        //    }
        //    catch (Exception e)
        //    {
        //        return NotFound("There was a problem: " + e.Message.ToString());
        //    }
        //}
    }
}
