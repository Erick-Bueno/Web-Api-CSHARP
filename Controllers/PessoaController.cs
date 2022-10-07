using Microsoft.AspNetCore.Mvc;


namespace API.Controllers;
[ApiController]
[Route("api/[Controller]")]

public class PessoaController: ControllerBase
{
    private readonly IPessoaRepository PessoaRepository;
    public PessoaController( IPessoaRepository pessoaRepository ){
        PessoaRepository = pessoaRepository;
    }
    [HttpGet]
    public async Task<IEnumerable<Pessoa>> GetPessoas(){
        return await PessoaRepository.Get();
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Pessoa>> GetPessoa(int id){
        return await PessoaRepository.Get(id);
    }

    [HttpPost]
    public async Task<ActionResult<Pessoa>> PostPessoa([FromBody] Pessoa pessoa){
        var novaPessoa = await PessoaRepository.Create(pessoa);
        return pessoa;
    }
    [HttpDelete]
    public async Task<ActionResult<Pessoa>> DeletePessoa(int id){
        var Pessoa_deletada = await PessoaRepository.Get(id);
        if(Pessoa_deletada != null){
            await PessoaRepository.Delete(Pessoa_deletada.Id);
            
        }
        return Ok("usuario deletado com sucesso");
    }
    [HttpPut]
    public async Task<ActionResult<Pessoa>> AtualizarPessoa(int id, [FromBody] Pessoa pessoa){
        try
        {
            var id_pessoa = PessoaRepository.Get(id);
             if(id == pessoa.Id){
            await PessoaRepository.Update(pessoa);
            return Ok("usuario atualizado com sucesso");
        }
        }
        catch (System.Exception)
        {
            
            throw;
        }
       
        return NotFound("usuario não encontrado");
    }
}

