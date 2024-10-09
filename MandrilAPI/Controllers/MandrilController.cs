using MandrilAPI.models;
using MandrilAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace MandrilAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MandrilController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Mandril>> GetMandriles()
    {
return Ok(MandrilDataStore.Current.Mandriles);
    }

    [HttpGet("{mandrilId}")]
    public ActionResult<Mandril> GetMandrilById(int mandrilId)
    {
var mandril = MandrilDataStore.Current.Mandriles.FirstOrDefault(x => x.Id == mandrilId);

if(mandril == null)
return NotFound("El mandril solicitado no existe");
return Ok(mandril);
    }

    [HttpPost]
    public ActionResult<Mandril> PostMandril(MandrilInsert mandrilInsert)
    {
     var maxMandrilId = MandrilDataStore.Current.Mandriles.Max(x => x.Id);

     var mandrilNuevo = new Mandril(){
     Id = maxMandrilId + 1,
     Nombre = mandrilInsert.Nombre,
     Apellido = mandrilInsert.Apellido
     };

     MandrilDataStore.Current.Mandriles.Add(mandrilNuevo);

     return CreatedAtAction(nameof(GetMandrilById), 
     new { mandrilId = mandrilNuevo.Id },
     mandrilNuevo
     );
    }
}