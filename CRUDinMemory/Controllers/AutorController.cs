using CrudComAdo.Models;
using CrudComAdo.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CrudComAdo.Controllers
{
    public class AutorController : Controller
    {
        private readonly AutorRepository _autorRepository;

        public AutorController(AutorRepository autorRepository)
        {
            _autorRepository = autorRepository;
        }
        //Coleção em memória - Estado global por ser static
        // public static List<AutorModel> Autores { get; } = new List<AutorModel>();//Lista não é thead safe, pois pode haver concorrência
        //public static Dictionary<int,AutorModel> Autores { get; } = new Dictionary<int, AutorModel>();
        // List
        public IActionResult Index() 
        {
            //var autores = Autores.Select(x=>x.Value);
            //return View(autores);
            
            return View(_autorRepository.GetAll());
        }

        //Details
        public IActionResult Details(int id)
        {
            return View(_autorRepository.GetById(id));


            //if (Autores.TryGetValue(id, out var autorModel))
            //{
            //    return View(autorModel);
            //}

            //return RedirectToAction(nameof(Index));




            //Com Lambda
            //var autor = Autores.FirstOrDefault(x=>x.Id == id);
            //if(autor != null)
            //{
            //    return View(autor);
            //}
            //else
            //{
            //    return RedirectToAction(nameof(Index));
            //}

        }

        //Create
        [HttpGet]
        public IActionResult Create() => View();
        [HttpPost]
        public IActionResult Create(AutorModel autorModel)
        {

            _autorRepository.Add(autorModel);
            //Autores.AddOrUpdate(autorModel.Id, autorModel,(key, model)=>autorModel);
            return RedirectToAction(nameof(Index));
        }

        //Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {

            return View(_autorRepository.GetById(id));
            //View(Autores.First(x => x.Id == id));
            //if (Autores.TryGetValue(id, out var autorModel))
            //{
            //    return View(autorModel);
            //}

            //return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult Edit(AutorModel autorModel)
        {
            _autorRepository.Edit(autorModel);         

            return RedirectToAction(nameof(Index));
            // var autorToEdit = Autores.First(x => x.Id == autorModel.Id);
            //if (Autores.TryGetValue(autorModel.Id, out var autorToEdit))
            //{
            //    autorToEdit.Nome = autorModel.Nome;
            //    autorToEdit.UltimoNome = autorModel.UltimoNome;
            //    autorToEdit.Nascimento = autorModel.Nascimento;
            //    return RedirectToAction(nameof(Index));
            //}



            //ModelState.AddModelError(string.Empty, "Id não encontrado em memória");
            //ModelState.AddModelError(nameof(AutorModel.Id), "Id não encontrado em memória");
            //return View(autorModel);

        }

        //Delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_autorRepository.GetById(id));
            // View(Autores.First(x => x.Id == id));
            //if (Autores.TryGetValue(id, out var autorModel))
            //{
            //    return View(autorModel);
            //}

            //return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult Delete(AutorModel autorModel)
        {
            _autorRepository.Remove(autorModel);
            return RedirectToAction(nameof(Index));
            ////var autorToRemove = Autores.FirstOrDefault(x => x.Id == autorModel.Id);          
            //Autores.TryRemove(autorModel.Id, out var autorRemoved);
            //return RedirectToAction(nameof(Index));
        }

    }
}
