public interface IPessoaRepository
{
    Task<IEnumerable<Pessoa>> Get();

    Task<Pessoa> Get(int id);

    Task<Pessoa> Create(Pessoa pessoa);

    Task Delete(int id);

    Task Update(Pessoa pessoa);
}