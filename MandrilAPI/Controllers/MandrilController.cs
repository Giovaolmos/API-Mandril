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

     var mandrilNuevoo = new Mandril(){
     Id = maxMandrilId + 1,
     Nombre = mandrilInsert.Nombre,
     Apellido = mandrilInsert.Apellido
     };

     MandrilDataStore.Current.Mandriles.Add(mandrilNuevoo);

     return CreatedAtAction(nameof(GetMandrilById), 
     new { mandrilId = mandrilNuevoo.Id },
     mandrilNuevoo
     );
    }

    [HttpPut("{mandrilId}")]
    public ActionResult<Mandril> PutMandril([FromRoute] int mandrilId, [FromBody]MandrilInsert mandrilInsert)
    {
        var mandril = MandrilDataStore.Current.Mandriles.FirstOrDefault(x => x.Id == mandrilId);
        if(mandril == null)
        return NotFound("El mandril que quieres editar no existe");

        mandril.Nombre = mandrilInsert.Nombre;
        mandril.Apellido = mandrilInsert.Apellido;
        return NoContent();
    }

    [HttpDelete("{mandrilId}")]
    public ActionResult<Mandril> DeleteMandril(int mandrilId)
    {
        var mandril = MandrilDataStore.Current.Mandriles.FirstOrDefault(x => x.Id == mandrilId);
        if(mandril == null) return NotFound("El mandril que quieres eliminar no existe");
        MandrilDataStore.Current.Mandriles.Remove(mandril);
        return NoContent();
    }
}