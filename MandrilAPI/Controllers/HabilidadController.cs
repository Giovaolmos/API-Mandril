using MandrilAPI.Models;
using MandrilAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace MandrilAPI.Controllers;

[ApiController]
[Route("api/mandril/{mandrilId}/[controller]")]
public class HabilidadController : ControllerBase
{
    [HttpGet()]
    public ActionResult<IEnumerable<Habilidad>> GetHabilidades(int mandrilId)
    {
      var mandril = MandrilDataStore.Current.Mandriles.FirstOrDefault(x => x.Id == mandrilId);
        if(mandril == null)
        return NotFound("El mandril solicitado no existe");
        
     return Ok(mandril.Habilidades);
    }

    [HttpGet("{habilidadId}")]
    public ActionResult<Habilidad> GetHabilidadById(int mandrilId, int habilidadId)
    {
        var mandril = MandrilDataStore.Current.Mandriles.FirstOrDefault(x => x.Id == mandrilId);
        if(mandril == null)
        return NotFound("El mandril solicitado no existe");
       
       var habilidad = mandril.Habilidades?.FirstOrDefault(h => h.Id == habilidadId);
       if (habilidad == null) return NotFound("La habilidad solicitada no existe");
       return Ok(habilidad);
    }

    [HttpPost]
    public ActionResult<Habilidad> PostHabilidad(int mandrilId, HabilidadInsert habilidadInsert)
    {
 var mandril = MandrilDataStore.Current.Mandriles.FirstOrDefault(x => x.Id == mandrilId);
        if(mandril == null) return NotFound("El mandril al que quieres agregarle una habilidad no existe");
      var habilidadExistente = mandril.Habilidades.FirstOrDefault(h => h.Nombre == habilidadInsert.Nombre);
      if(habilidadExistente != null) return BadRequest("Ya existe una habilidad con este nombre.");

      var maxIdHabilidad = mandril.Habilidades.Max(h => h.Id);

      var habilidadNueva = new Habilidad(){
        Id = maxIdHabilidad + 1,
        Nombre = habilidadInsert.Nombre,
        Potencia = habilidadInsert.Potencia
      };
      mandril.Habilidades.Add(habilidadNueva);
      return CreatedAtAction(nameof(GetHabilidades),
      new {mandrilId = mandrilId, habilidadId = habilidadNueva.Id },
      habilidadNueva);
    }

    // [HttpPut]
    // public ActionResult<Habilidad> PutHabilidad()
    // {

    // }

    // [HttpDelete]
    // public ActionResult<Habilidad> DeleteHabilidad()
    // {

    // }

}