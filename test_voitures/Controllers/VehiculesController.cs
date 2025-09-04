using Microsoft.AspNetCore.Mvc;
using TestVoitures.Models;
using TestVoitures.Repositories;

namespace TestVoitures.Controllers;

[ApiController]
[Route("vehicules")]
public class VehiculesController : ControllerBase
{
    private readonly IVehiculeRepository _repo;

    public VehiculesController(IVehiculeRepository repo) => _repo = repo;



// route qui récupère tous les véhicules par ordre d'id croissant
    [HttpGet]
    public ActionResult<IEnumerable<Vehicule>> GetAll()
    {
        var items = _repo.GetAll().OrderBy(v => v.Id);
        return Ok(items);
    }


// route qui récupère un véhicule par id    
    [HttpGet("{id:int}")]
    public ActionResult<Vehicule> GetById(int id)
    {
        var v = _repo.GetById(id);
        return v is null ? NotFound() : Ok(v);
    }
}
