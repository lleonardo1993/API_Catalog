﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Catalog.Data;
using API_Catalog.Models;

namespace API_Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly APIDbContext _context;

        public ProdutosController(APIDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            var produtos = _context.Produtos.ToList();
            if (produtos is null)
            {
                return NotFound("Produtos não encontrados...");
            }
            return produtos;
        }
        [HttpGet("{id:int}", Name = "ObterProduto")]
        public ActionResult<Produto> Get(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);
            if(produto is null)
            {
                return NotFound("Não foi encontrado o Id na context..");
            }
            return produto;
        }
        [HttpPost]
        public ActionResult Post(Produto produto) // recebe o produto
        {
            if(produto is null)
            {
                return BadRequest();
            }

            _context.Produtos.Add(produto); // add no context
            _context.SaveChanges(); // salva no db

            return new CreatedAtRouteResult("ObterProduto", // obtem a route passada no get
                new { id = produto.ProdutoId }, produto);
        }
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Produto produto)
        {
            if(id != produto.ProdutoId)
            {
                return BadRequest();
            }

            _context.Entry(produto).State = EntityState.Modified; //alterando dados na context com Entry
            _context.SaveChanges(); // persistindo alteração na context

            return Ok(produto);// retornando dados modificados
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            
            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);
            
            if(produto is null)
            {
                return NotFound("Produto não localizado..");
            }
            _context.Remove(produto);
            _context.SaveChanges();

            return Ok(produto);
        }
    }
}
