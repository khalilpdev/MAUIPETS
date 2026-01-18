using System;
using System.Text.Json;
using MAUIPETS.Models;

namespace MAUIPETS.Services;

public 	class PetService
{
    List<Pet> petList;
    
    public async Task<List<Pet>> GetPets()
    {
        if (petList?.Count > 0)
            return petList;

        try
        {
            var filePath = Path.Combine(AppContext.BaseDirectory, "Data", "pets.json");
            
            if (!File.Exists(filePath))
            {
                Debug.WriteLine($"Arquivo não encontrado: {filePath}");
                return new List<Pet>();
            }

            var json = await File.ReadAllTextAsync(filePath);
            petList = JsonSerializer.Deserialize<List<Pet>>(json) ?? new List<Pet>();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Erro ao carregar pets: {ex.Message}");
            petList = new List<Pet>();
        }

        return petList;
    }
}