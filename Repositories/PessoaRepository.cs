using Microsoft.EntityFrameworkCore;

public class PessoaRepository : IPessoaRepository
{
    public readonly PessoaContext Context;
   public PessoaRepository(PessoaContext context ){
        Context = context;
    }
    public async Task<Pessoa> Create(Pessoa pessoa)
    {
        //adicionando uma nova pessoa na model pessoa2
        Context.pessoas.Add(pessoa);
        //adicionando as mudanças ao banco
        await Context.SaveChangesAsync();
        return pessoa;
    }

    public async Task Delete(int id)
    {
       //buscando id da pessoa na model pessoa
       var pessoaDeletada = await Context.pessoas.FindAsync(id);
       Context.pessoas.Remove(pessoaDeletada);
       //adicionando as mudanças ao banco
       await Context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Pessoa>> Get()
    {
        //listando os dados
        return await Context.pessoas.ToListAsync();
    }

    public async Task<Pessoa> Get(int id)
    {
        return await Context.pessoas.FindAsync(id);
    }

    public async Task Update(Pessoa pessoa)
    {
        Context.Entry(pessoa).State=EntityState.Modified;
        await Context.SaveChangesAsync();
    }
}