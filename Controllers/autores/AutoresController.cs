using Aplicacion.Contratos;
using Aplicacion.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryTRAVELApi.Controllers.autores
{
    [Route("api/autores")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        #region Atributos
        private readonly IAutoresServicio autoresServicio;
        // private readonly IEditorialesServicio editorialesServicio;
        #endregion

        #region Variables
        autoresDTO autores = new autoresDTO();
        #endregion

        #region Construtor
        public AutoresController(IAutoresServicio pAutoresServicio)
        {
            this.autoresServicio = pAutoresServicio;           
        }
        #endregion


        [HttpGet]
        // GET: Libros
        public IEnumerable<autoresDTO> Get()
        {
            var listaAutores = this.autoresServicio.ObtenerTodas();
            return listaAutores;
        }

        [HttpGet("{id}")]
        // GET: Libros/id
        public autoresDTO Get(int id)
        {
            var listaAutores = this.autoresServicio.ObtenerUno(id);
            return listaAutores;
        }

        // POST: Libros/Create
        [HttpPost]
        public autoresDTO Create(autoresDTO Unautor)
        {
            // TODO: Add insert logic here
            var resultado = this.autoresServicio.AgregarAutor(Unautor);
            return resultado;
        }

        // POST: Libros/Create
        [HttpPut("{id}")]
        public autoresDTO Actulizar(int id, autoresDTO Unautor)
        {
            Unautor.id = id;
            // TODO: Add insert logic here
            var resultado = this.autoresServicio.Actualizar(Unautor);
            return resultado;
        }


        // DELETE: Libros/id
        [HttpDelete("{id}")]
        public autoresDTO Delete(int id)
        {
            // TODO: Add insert logic here    
            var resultado = this.autoresServicio.Eliminar(id);
            return resultado;
        }
    }
}
