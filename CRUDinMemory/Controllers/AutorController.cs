using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using CRUDinMemory.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUDinMemory.Controllers
{
    public class AutorController : Controller
    {
        //Coleção em memória - Estado global por ser static
        public static List<AutorModel> Autores { get; } = new List<AutorModel>();//Lista não é thead safe, pois pode haver concorrência

        // List
        public IActionResult Index() 
        {
            return View(Autores);
        }

        //Details
        public IActionResult Details(int id)
        {
            var autor = Autores.FirstOrDefault(x=>x.Id == id);
            if(autor != null)
            {
                return View(autor);
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
            
        }

        //Create
        [HttpGet]
        public IActionResult Create() => View();
        [HttpPost]
        public IActionResult Create(AutorModel autorModel)
        {
            Autores.Add(autorModel);
            return RedirectToAction(nameof(Index));
        }

        //Edit
        [HttpGet]
        public IActionResult Edit(int id) => View(Autores.First(x=>x.Id==id));
        [HttpPost]
        public IActionResult Edit(AutorModel autorModel)
        {
            var autorToEdit = Autores.First(x => x.Id == autorModel.Id);

            autorToEdit.Nome = autorModel.Nome;
            autorToEdit.UltimoNome = autorModel.UltimoNome;
            autorToEdit.Nascimento = autorModel.Nascimento;

            return RedirectToAction(nameof(Index));
        }

        //Delete
        [HttpGet]
        public IActionResult Delete(int id) => View(Autores.First(x => x.Id == id));
        [HttpPost]
        public IActionResult Delete(AutorModel autorModel)
        {
            var autorToRemove = Autores.FirstOrDefault(x => x.Id == autorModel.Id);
            Autores.Remove(autorToRemove);
            return RedirectToAction(nameof(Index));
        }

    }
}
