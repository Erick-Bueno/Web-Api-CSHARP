using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiController]
[Route("api/[Controller]")]

public class AnimalController: ControllerBase
{
    private readonly IAnimalRepository AnimalRepository;

    public AnimalController(IAnimalRepository animalRepository)
    {
        AnimalRepository = animalRepository;
    }
    [HttpGet]
    public async Task<IEnumerable<Animal>> GetAnimais(){
       return await AnimalRepository.Get();
           
        
    }
    [HttpPost]
    public async Task <ActionResult<Animal>> PostAnimais([FromBody] Animal animal){
        var novo_animal = await AnimalRepository.create(animal);
        return animal;
    }
}
    
