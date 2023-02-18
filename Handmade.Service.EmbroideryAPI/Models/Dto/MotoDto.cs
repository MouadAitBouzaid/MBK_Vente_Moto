﻿using System.ComponentModel.DataAnnotations;

namespace Handmade.Service.EmbroideryAPI.Models.Dto
{
    public class EmbroideryDto
	{
        public int Id { get; set; }
        public string Nom { get; set; }
        public double Prix { get; set; }
        public string Categorie { get; set; }
        public string ImageURL { get; set; }

    }
}

