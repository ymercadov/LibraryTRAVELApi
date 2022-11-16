using Aplicacion.Contratos;
using Aplicacion.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LibraryTRAVELApi.Controllers
{
    [Route("api/libros")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        #region Atributos
        private readonly ILibrosServicio librosServicio;
         private readonly IEditorialesServicio editorialesServicio;
        #endregion

        #region Variables
        librosDTO libros = new librosDTO();
        #endregion

        #region Construtor
        public LibrosController(ILibrosServicio pLibrosServicio
            ,IEditorialesServicio pEditorialesServicio)
        {
            this.librosServicio = pLibrosServicio;
            this.editorialesServicio = pEditorialesServicio;
        }
        #endregion


        [HttpGet]
        // GET: Libros
        public IEnumerable<librosDTO> Get()
        {
            var listaLibros = this.librosServicio.ObtenerTodas();
            return listaLibros;
        }

        [HttpGet("{isbn}")]
        // GET: Libros/id
        public mymodeloDTO Get(int isbn)
        {
            var listaLibros = this.librosServicio.ObtenerUnoporId(isbn);
            return listaLibros;
        }

        // POST: Libros/Create
        [HttpPost]
        public librosDTO Create(mymodeloDTO unlibro)
        {
            // TODO: Add insert logic here          

            librosDTO otrolibro = new librosDTO();           
            otrolibro.isbn = 0;
            otrolibro.editorialesId = unlibro.editorialesId;
            otrolibro.titulo = unlibro.titulo;
            otrolibro.sinopsis = unlibro.sinopsis;
            otrolibro.nPagina = unlibro.nPagina;
            var resultado = this.librosServicio.AgregarLibro(otrolibro, unlibro.autores);
            return resultado;
        }

        // POST: Libros/Create
        [HttpPut("{id}")]
        public librosDTO Actulizar(int id, mymodeloDTO unlibro)
        {
            //unlibro.isbn = id;
            // TODO: Add insert logic here

            librosDTO otrolibro = new librosDTO();
            otrolibro.isbn = id;
            otrolibro.editorialesId = unlibro.editorialesId;
            otrolibro.titulo = unlibro.titulo;
            otrolibro.sinopsis = unlibro.sinopsis;
            otrolibro.nPagina = unlibro.nPagina;
            var resultado = this.librosServicio.Actualizar(otrolibro, unlibro.autores);
            return resultado;
        }


        // DELETE: Libros/id
        [HttpDelete("{id}")]
        public librosDTO Delete(int id)
        {
            // TODO: Add insert logic here    
            var resultado = this.librosServicio.Eliminar(id);
            return resultado;
        }
    }
}
