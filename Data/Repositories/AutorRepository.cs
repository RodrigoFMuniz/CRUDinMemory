using CRUDinMemory.Models;
using System.Collections.Generic;
using System.Linq;

namespace CRUDinMemory.Repositories
{
    public class AutorRepository
    {
        public static List<AutorModel> Autores { get; } = new List<AutorModel>();

        public IEnumerable<AutorModel> GetAll()
        {
            return Autores;
        }
        public AutorModel GetById(int id)
        {
            var autor = Autores.First(x=>x.Id == id);
            return autor;
        }       
        public void Add(AutorModel autorModel)
        {
            Autores.Add(autorModel);
        }
        public void Remove(AutorModel autorModel)
        {
            var autorInMemory = GetById(autorModel.Id);
            Autores.Remove(autorInMemory);
        }
        public void Edit(AutorModel autorModel)
        {
            var autorInMemory = GetById(autorModel.Id);
            autorInMemory.Nome = autorModel.Nome;
            autorInMemory.UltimoNome = autorModel.UltimoNome;
            autorInMemory.Nascimento = autorModel.Nascimento;
        }
    }
}
