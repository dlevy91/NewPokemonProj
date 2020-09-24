using System;
using System.ComponentModel.DataAnnotations;

namespace NewPokemon.Models
{
    public class PokemonModel
    {
        [Key]
        public int id {get; set;}

        [Display(Name = "Pokemon Number")]
        public int pkmnNumber {get; set;}

        [Display(Name = "Pokemon Name")]
        public string name {get; set;}

        [Display(Name = "Pokemon Description")]
        public string description {get; set;}
    }
}