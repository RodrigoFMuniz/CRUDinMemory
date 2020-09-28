using CrudComAdo.Models;
using System.Collections.Generic;
using System.Linq;

namespace CrudComAdo.Repositories
{
    public class LivroRepository
    {
        public static List<LivroModel> Livros { get; } = new List<LivroModel>();

        public IEnumerable<LivroModel> GetAll()
        {
            return Livros;
        }
        public LivroModel GetById(int id)
        {
            var livro = Livros.First(x => x.Id == id);
            return livro;
        }
        public void Add(LivroModel livroModel)
        {
            Livros.Add(livroModel);
        }
        public void Remove(LivroModel livroModel)
        {
            var livroInMemory = GetById(livroModel.Id);
            Livros.Remove(livroInMemory);
        }
        public void Edit(LivroModel livroModel)
        {
            var livroInMemory = GetById(livroModel.Id);
            livroInMemory.Titulo = livroModel.Titulo;
            livroInMemory.Isbn = livroModel.Isbn;
            livroInMemory.Publicacao = livroModel.Publicacao;
            livroInMemory.Autor = livroModel.Autor;
            livroInMemory.AutorId = livroModel.AutorId;
        }
    }
}
