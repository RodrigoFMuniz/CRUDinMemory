//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using CRUDinMemory.Models;
//using Microsoft.AspNetCore.Mvc;

//namespace CRUDinMemory.Controllers
//{
//    public class LivroController : Controller
//    {
//        //Coleção em memória - Estado global por ser static
//        public static List<LivroModel> Livros { get; } = new List<LivroModel>();//Lista não é thead safe, pois pode haver concorrência

//        // List
//        public IActionResult Index()
//        {
//            return View(Livros);
//        }

//        //Details
//        public IActionResult Details(int id)
//        {
//            var livro = Livros.FirstOrDefault(x => x.Id == id);

//            if (livro != null)
//            {
//                return View(livro);
//            }
//            else
//            {
//                return RedirectToAction(nameof(Index));
//            }
           
//        }

//        //Create
//        [HttpGet]
//        public IActionResult Create() => View();
//        [HttpPost]
//        public IActionResult Create(LivroModel livroModel)
//        {
//            Livros.Add(livroModel);
//            if (livroModel.AutorId > 0)
//            {
//                var autor = AutorController.Autores.First(x=>x.Id == livroModel.AutorId);
//                autor.Livros.Add(livroModel);
//                livroModel.Autor = autor;
                
//            }
//            return RedirectToAction(nameof(Index));
//        }

//        //Edit
//        [HttpGet]
//        public IActionResult Edit(int id) => View(Livros.First(x => x.Id == id));
//        [HttpPost]
//        public IActionResult Edit(LivroModel livroModel)
//        {
//            var livroToEdit = Livros.First(x => x.Id == livroModel.Id);

//            livroToEdit.Titulo = livroModel.Titulo;
//            livroToEdit.Isbn = livroModel.Isbn;
//            livroToEdit.Publicacao = livroModel.Publicacao;

//            if (livroToEdit.AutorId != livroModel.AutorId)
//            {
//                var autor = AutorController.Autores.First(x => x.Id == livroModel.AutorId);
//                var autorAntigo = AutorController.Autores.First(x => x.Id == livroToEdit.AutorId);

//                //Inserção do livro para autor novo
//                autor.Livros.Add(livroToEdit);

//                //Remoção do livro para autor antigo
//                var livroParaRemover = autorAntigo.Livros.First(x=>x.Id==livroToEdit.Id);
//                autorAntigo.Livros.Remove(livroParaRemover);

//                livroToEdit.Autor = autor;
//                livroToEdit.AutorId = autor.Id;
//            }

//            return RedirectToAction(nameof(Index));
//        }

//        //Delete
//        [HttpGet]
//        public IActionResult Delete(int id) => View(Livros.First(x => x.Id == id));
//        [HttpPost]
//        public IActionResult Delete(LivroModel livroModel)
//        {
//            var livroToRemove = Livros.FirstOrDefault(x => x.Id == livroModel.Id);
//            Livros.Remove(livroToRemove);

//            if(livroModel.AutorId > 0)
//            {
//                var autor = AutorController.Autores.First(x=>x.Id == livroModel.AutorId);
//                autor.Livros.Remove(livroModel);
//            }
//            return RedirectToAction(nameof(Index));
//        }

//    }
//}