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

    // [HttpPost]
    // public ActionResult<Habilidad> PostHabilidad()
    // {

    // }

    // [HttpPut]
    // public ActionResult<Habilidad> PutHabilidad()
    // {

    // }

    // [HttpDelete]
    // public ActionResult<Habilidad> DeleteHabilidad()
    // {

    // }

}