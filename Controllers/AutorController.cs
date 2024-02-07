using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using SQLite;
using Tarea_1._3_Aplicacion_de_Autores.Models;

namespace Tarea_1._3_Aplicacion_de_Autores.Controllers
{
    public class AutorController
    {
        readonly SQLiteAsyncConnection _connection;

        // Constructor VACIO
        public AutorController() 
        {
            SQLite.SQLiteOpenFlags extensiones = SQLite.SQLiteOpenFlags.ReadWrite |
                                                SQLite.SQLiteOpenFlags.Create |
                                                SQLite.SQLiteOpenFlags.SharedCache;

            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, "DBAutor.db3"), extensiones);

            _connection.CreateTableAsync<Autor>();
        }

        // Inicialización
       

        // CREATE
        public async Task<int> AgregarAutor(Autor autor)
        {
            
            if (autor.Id == 0)
            {
                return await _connection.InsertAsync(autor);
            }
            else
            {
                return await _connection.UpdateAsync(autor);
            }
        }

        // READ
        public async Task<List<Autor>> ObtenerListaAutores()
        {
           
            return await _connection.Table<Autor>().ToListAsync();
        }

        // READ elemento
        public async Task<Autor> ObtenerAutor(int id)
        {
            
            return await _connection.Table<Autor>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        // DELETE
        public async Task<int> EliminarAutor(Autor autor)
        {
            
            return await _connection.DeleteAsync(autor);
        }

        // Método para buscar autores por nombre o país
        public async Task<List<Autor>> BuscarAutores(string textoBusqueda)
        {
            // Realizar la búsqueda utilizando LINQ
            return await _connection.Table<Autor>()
                                    .Where(a => a.Nombre.Contains(textoBusqueda) || a.Pais.Contains(textoBusqueda))
                                    .ToListAsync();
        }
    }
}

