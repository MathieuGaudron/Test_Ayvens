using TestVoitures.Models;

namespace TestVoitures.Repositories;

public interface IVehiculeRepository
{
    IEnumerable<Vehicule> GetAll();
    Vehicule? GetById(int id);
    bool Delete(int id); 

}
