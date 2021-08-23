using Microsoft.AspNetCore.Mvc; // Referencia para ControllerBase
using System.Collections.Generic; // Referencia para o "List" 
using System.Linq; // Referencia para o FirstOrDefault
using TechSmartSchool.WebAPI.Models; // Referencia para a Aluno da List

namespace TechSmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {   
        public List<Aluno> Alunos = new List<Aluno>() 
        // Listagem (List) de Objetos do tipo Aluno
        {
            new Aluno 
            {
                Id = 1,
                Nome = "Gilliard",
                Sobrenome = "Santos",
                Telefone = "41396568"
            },
            
            new Aluno 
            {
                Id = 2,
                Nome = "Bruna",
                Sobrenome = "Amaral",
                Telefone = "41396669"
            },
            
            new Aluno 
            {
                Id = 3,
                Nome = "Mateus",
                Sobrenome = "Costa",
                Telefone = "41396001"
            },
        } ;
        public AlunoController() {}

        [HttpGet]
        public IActionResult Get() 
        {
            return Ok(Alunos);
        }
        
        [HttpGet("{id:int}")]
        public IActionResult GetId(int id)    
        {
            var aluno = Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest ("Aluno Não encontrado");

            return Ok(aluno);
        }

        //Exemplo de acesso via QueryString. 

        //Para este modo funcionar é necessario passar o nome do get o get e o parametro do get

        //Exemplo: NomeDoGet?id=Parametro

        [HttpGet("ById")] // Nome do Get sem as chaves e apenas com as aspas duplas
        public IActionResult GetbyId(int id) // O Get    
        {
            var aluno = Alunos.FirstOrDefault(a => a.Id == id); // Parametro do Get
            if (aluno == null) return BadRequest ("Aluno Não encontrado");

            return Ok(aluno);
        }

        [HttpGet("{nome}")]
        public IActionResult GetNome(string nome)    
        {
            var aluno = Alunos.FirstOrDefault(a => a.Nome.Contains(nome));
            if (aluno == null) return BadRequest ("Aluno Não encontrado");

            return Ok(aluno);
        }

        //Exemplo de acesso via QueryString. 

        //Para este modo funcionar é necessario passar o nome do get o get e o parametro do get

        //Exemplo: NomeDoGet?id=Parametro

        [HttpGet("NomeSobrenome")]  // Nome do Get sem as chaves e apenas com as aspas duplas
            public IActionResult ByGetNomeSobrenome(string nome, string sobrenome) // O Get    
        {
            var aluno = Alunos.FirstOrDefault(a => a.Nome.Contains(nome) 
            && a.Sobrenome.Contains(sobrenome));
            if (aluno == null) return BadRequest ("Aluno Não encontrado");

            return Ok(aluno);
        }

        [HttpPost]// Metodo POST consulta
            public IActionResult Post(Aluno aluno) // O Get    
        {
            return Ok(aluno);
        }

        [HttpPut("{id}")]// Metodo PUT edita/atualiza, MAS é preciso passar todos parametros do metodo
            public IActionResult Put(int id, Aluno aluno) // O Get    
        {
            return Ok(aluno);
        }

        [HttpPatch("{id}")]// Metodo PATCH edita/atualiza, MAS é possivel alterar o resgistro desejado. 
            public IActionResult Patch(int id, Aluno aluno) // O Get    
        {
            return Ok(aluno);
        }

        [HttpDelete("{id}")] // Metodo DELETE deleta
            public IActionResult Delete(int id) // O Get    
        {
            return Ok("10");
        }
    }
}