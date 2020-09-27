using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDinMemory.Models
{
    public class AutorModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string UltimoNome { get; set; }
        public DateTime Nascimento { get; set; }

        public List<LivroModel> Livros { get; set; }
    }
}
