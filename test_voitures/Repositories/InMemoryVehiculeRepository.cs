using System.Collections.Concurrent;
using TestVoitures.Models;

namespace TestVoitures.Repositories;

public class InMemoryVehiculeRepository : IVehiculeRepository
{
    private readonly ConcurrentDictionary<int, Vehicule> _data =
        new(new[]
        {
            new KeyValuePair<int, Vehicule>(1, new Vehicule { Id = 1, Marque = "Porsche", Modele = "Macan", Annee = 2020, Kilometrage = 145000 }),
            new KeyValuePair<int, Vehicule>(2, new Vehicule { Id = 2, Marque = "Nissan",  Modele = "GTR",   Annee = 2021, Kilometrage = 150000 }),
            new KeyValuePair<int, Vehicule>(3, new Vehicule { Id = 3, Marque = "Audi",    Modele = "R8",    Annee = 2019, Kilometrage = 90000  }),
        });

    public IEnumerable<Vehicule> GetAll() => _data.Values;

    public Vehicule? GetById(int id)
    {
        _data.TryGetValue(id, out var vehicule);
        return vehicule;
    }
}
