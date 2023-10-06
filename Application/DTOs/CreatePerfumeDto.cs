using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public record CreatePerfumeDto(string name, string brand, float volume, string scent, string imageUrl)
    {
        public Perfume ToCreateMovie()
        {
            return new() { Name = name, Brand = brand, Volume = volume, Scent = scent, ImageUrl = imageUrl };
            
        }
    }
}
