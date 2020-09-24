using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NewPokemon.Dao;
using NewPokemon.Models;

namespace NewPokemon.Controllers
{
    public class PokemonController : Controller
    {
        private readonly PokemonDbContext _context;
        public PokemonController(PokemonDbContext context)
        {
            _context = context;
        }
//---------------------------------------------------------------------------------

        public IActionResult Index()
        {
            return View(_context);
        }

        public IActionResult ViewDetails(int pkmnID)
        {
            PokemonModel matchingPkmn = _context.pokemon.FirstOrDefault(p => p.id == pkmnID);
            if(matchingPkmn != null)
            {
                return View("ViewDetails", matchingPkmn);
            }
            else{
                return Content("No Pokemon with that ID");
            }
        }

//---------------------------------------------------------------------------------

        [HttpPost]
        public IActionResult Add(PokemonModel newPkmn)
        {
            _context.pokemon.Add(newPkmn);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

//---------------------------------------------------------------------------------

        public IActionResult Remove(int pkmnID)
        {
            PokemonModel matchingPkmn = _context.pokemon.FirstOrDefault(p => p.id == pkmnID);
            if(matchingPkmn != null)
            {
                _context.Remove(matchingPkmn);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else{
                return Content("No Pokemon with that ID");
            }
        }
        
    }
}