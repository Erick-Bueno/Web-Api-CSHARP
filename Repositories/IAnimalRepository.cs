public interface IAnimalRepository
{
    Task<IEnumerable<Animal>> Get();

    Task<Animal> Get(int id);

    Task<Animal> create(Animal animal);

    Task update (Animal animal);

    Task Delete (int id);
}