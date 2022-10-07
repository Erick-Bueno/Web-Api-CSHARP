using Microsoft.EntityFrameworkCore;
public class PessoaContext : DbContext
{
    public PessoaContext(DbContextOptions options) : base(options)
    {
    
    }
    //tabela
    public DbSet<Pessoa> pessoas {get; set;}
    public DbSet<Animal> animais {get; set;}
}