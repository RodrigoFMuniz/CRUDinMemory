using CRUDinMemory.Models;
using CRUDinMemory.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CRUDinMemory.Controllers
{
    public class LivroController : Controller
    {
        private readonly LivroRepository _livroRepository;

        public LivroController()
        {
            _livroRepository = new LivroRepository();
        }

        public IActionResult Index()
        {
            return View(_livroRepository.GetAll());
        }

        //Details
        public IActionResult Details(int id)
        {
            return View(_livroRepository.GetById(id));

        }

        //Create
        [HttpGet]
        public IActionResult Create() => View();
        [HttpPost]
        public IActionResult Create(LivroModel livroModel)
        {

            _livroRepository.Add(livroModel);
            return RedirectToAction(nameof(Index));
        }

        //Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_livroRepository.GetById(id));
        }
        [HttpPost]
        public IActionResult Edit(LivroModel livroModel)
        {
            _livroRepository.Edit(livroModel);

            return RedirectToAction(nameof(Index));
        }

        //Delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_livroRepository.GetById(id));
        }
     
        [HttpPost]
        public IActionResult Delete(LivroModel livroModel)
        {
            _livroRepository.Remove(livroModel);
            return RedirectToAction(nameof(Index));
     
        }
    }

}