using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RpgApi;
namespace RpgApi.Controllers
{
    [ApiController] //diferente da outra controller, esses dados sao mutaveis
    [Route("[controller]")]  //sempre tirar api/ 
    public class PersonagensController : ControllerBase
    {
        private readonly DataContext _context; 

        public PersonagensController(DataContext context)
        {
            _context = context;  //atribuir a var global para a var desse metodo. ou seja, atribuindo o banco de dados nessa var (injecao de dependencia)
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
             Personagem p = await _context.TB_PERSONAGENS
                .FirstOrDefaultAsync(pBusca => pBusca.Id == id)   ;
                return Ok(p);

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAll")]

        public async Task<IActionResult> GET ()
        {
            try
            {
                List<Personagem> lista = await _context.TB_PERSONAGENS.ToListAsync();
                return Ok (lista);
                
            }
            catch (System.Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]

        public async Task<IActionResult> Add(Personagem novoPersonagem)
        {
            try

            {
                
                if (novoPersonagem.PontosVida > 100){
                    throw new Exception("Pontos de vida nao podem ser maior que 100!");
                }
                await _context.TB_PERSONAGENS.AddAsync(novoPersonagem);
                await _context.SaveChangesAsync();

                return Ok (novoPersonagem.Id);
            }
            catch (System.Exception ex)
            {
                
            return BadRequesta(ex.Message);
            }
        }


        [HttpPut]
        public async Task<IActionResult> Update(Personagem novoPersonagem)
        {
            try
            {
                if (novoPersonagem.PontosVida > 100)
                {
                    throw new System.Exception("pontos de vida nao pode ser maior que 100");
                }
                _context.TB_PERSONAGENS.Update(novoPersonagem);
                int linhasAfetadas = await _context.SaveChangesAsync();
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);                
                
            }
        }
  
        [HttpGet("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Personagem pRemover = await _context.TB_PERSONAGENS.FirstOrDefaultAsync(p => p.id == id);

                _context.TB_PERSONAGENS.Remove(pRemover);
                int linhasAfetadas = await _context.SaveChangesAsync
                
            }
            catch (System.Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
    }
}