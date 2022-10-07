using Microsoft.EntityFrameworkCore;
public class AnimalRepository : IAnimalRepository
{
    public readonly PessoaContext AnimalContext;
    public AnimalRepository(PessoaContext animalContext){
        AnimalContext = animalContext;
    }
    public async Task<Animal> create(Animal animal)
    {
        AnimalContext.animais.Add(animal);
        await AnimalContext.SaveChangesAsync();
        return animal;
    }

    public async Task Delete(int id)
    {
       var Id_animal_deletado =  await AnimalContext.animais.FindAsync(id);
        AnimalContext.animais.Remove(Id_animal_deletado);
        await AnimalContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Animal>> Get()
    {
       return await AnimalContext.animais.ToListAsync();

    }

    public async Task<Animal> Get(int id)
    {
        return await AnimalContext.animais.FindAsync(id);
    }

    public async Task update(Animal animal)
    {
        AnimalContext.Entry(animal).State = EntityState.Modified;
        await AnimalContext.SaveChangesAsync();
        
    }
}