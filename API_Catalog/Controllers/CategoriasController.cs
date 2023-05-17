using API_Catalog.Data;
using API_Catalog.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Catalog.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        // Injeção de dependencia
        private readonly APIDbContext _context;

        public CategoriasController(APIDbContext context)
        {
            _context = context;
        }

        // Método retorna os produtos das Caterias relacionadas
        [HttpGet("produtos")]
        public ActionResult<IEnumerable<Categoria>> GetCategoriasProdutos()
        {
            return _context.Categorias.Include(p => p.Produtos).ToList();
            return _context.Categorias.Include(p => p.Produtos).Where(c => c.CategoriaId <= 5).ToList();
                //o método Include, que é o responsável pelo carregamento de registros associados as entidades de nossas consultas "Include força a consulta"
        }

        // Método retorna uma lista de Categorias
        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            return _context.Categorias.AsNoTracking().ToList(); // AsNoTracking(), Método que melhora o desenpenho da consulta não armazenando cache da context
            // esse método só pode ser usado se o retorno da consulta não for alterado ex: get
        }
        // Método retorna Categoria por id
        [HttpGet("{id:int}", Name = "ObterCategoria")]
        public ActionResult<IEnumerable<Categoria>> Get(int id)
        {
            var categoria = _context.Categorias.FirstOrDefault(p => p.CategoriaId == id);

            if (categoria == null)
            {
                return NotFound("Categoria não encontrada...");
            }
            return Ok(categoria);
        }
        // Método de inserção
        [HttpPost("{id:int}", Name = "ObterCategoria")]
        public ActionResult Post(Categoria categoria)
        {
            if (categoria is null)
            {
                return NotFound("Id da Categoria não existe..");
            }

            _context.Add(categoria);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterCategoria",
                new { id = categoria.CategoriaId }, categoria);
        }

        // Método para atualizar categoria
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Categoria categoria)
        {
            if( id != categoria.CategoriaId)
            {
                return BadRequest();
            }
            _context.Entry(categoria).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(categoria);
        }
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var categoria = _context.Categorias.FirstOrDefault(p => p.CategoriaId == id);

            if(categoria == null)
            {
                return NotFound("Categoria não encontrada.");
            }
            _context.Remove(categoria);
            _context.SaveChanges();
            return Ok(categoria);
        }
    }
}




