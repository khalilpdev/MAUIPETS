namespace MAUIPETS.Services;

public class PetService
{
    List<Pet> petList;
    string _jsonContent;

    private async Task FillJsonContent()
    {
        using var stream = await FileSystem.OpenAppPackageFileAsync("pets.json");
        using var reader = new StreamReader(stream);

        _jsonContent = reader.ReadToEnd();    }

    public async Task<List<Pet>> GetPets()
    {
        if (petList?.Count > 0)
            return petList;

        try
        {
            await FillJsonContent();
            petList = JsonSerializer.Deserialize<List<Pet>>(_jsonContent) ?? new List<Pet>();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Erro ao carregar pets: {ex.Message}");
            petList = new List<Pet>();
        }

        return petList;
    }
}