using Aplicacion.Contratos;
using Aplicacion.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryTRAVELApi.Controllers
{
    [Route("api/Editoriales")]
    [ApiController]
    public class EditorialesController : ControllerBase
    {
        #region Atributos        
        private readonly IEditorialesServicio editorialesServicio;
        #endregion

        #region Variables
        editotialesDTO libros = new editotialesDTO();
        #endregion

        #region Construtor
        public EditorialesController(IEditorialesServicio pEditorialesServicio)
        {   
            this.editorialesServicio = pEditorialesServicio;
        }
        #endregion

        [HttpGet]
        // GET: Libros
        public IEnumerable<editotialesDTO> Get()
        {
            var editorialesLibros = this.editorialesServicio.ObtenerTodas();
            return editorialesLibros;
        }

        [HttpGet("{id}")]
        // GET: Libros/id
        public editotialesDTO Get(int id)
        {
            var listaLibros = this.editorialesServicio.ObtenerUno(id);
            return listaLibros;
        }

        // POST: Libros/Create
        [HttpPost]
        public editotialesDTO Create(editotialesDTO Unaeditorial)
        {
            // TODO: Add insert logic here
            var resultado = this.editorialesServicio.AgregarEditorial(Unaeditorial);
            return resultado;
        }

        // POST: Libros/Create
        [HttpPut("{id}")]
        public editotialesDTO Actulizar(int id, editotialesDTO Unaeditorial)
        {
            Unaeditorial.id = id;
            // TODO: Add insert logic here
            var resultado = this.editorialesServicio.Actualizar(Unaeditorial);
            return resultado;
        }


        // DELETE: Libros/id
        [HttpDelete("{id}")]
        public editotialesDTO Delete(int id)
        {
            // TODO: Add insert logic here    
            var resultado = this.editorialesServicio.Eliminar(id);
            return resultado;
        }


    }
}
