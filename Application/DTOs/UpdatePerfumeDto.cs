using Domain;

namespace Application.DTOs
{
    public sealed record UpdatePerfumeDto(int? Id, string? Name, string? Brand, string? ImageUrl, float? Volume, string? Scent)
    {
        public Perfume ToUpdatePerfume(Perfume perfume)
        {
            perfume.Name = this.CheckNullOrWhiteSpace(perfume.Name, Name);
            perfume.Brand = this.CheckNullOrWhiteSpace(perfume.Brand, Brand);
            perfume.ImageUrl = this.CheckNullOrWhiteSpace(perfume?.ImageUrl, ImageUrl);
            perfume.Scent = this.CheckNullOrWhiteSpace(perfume.Scent, Scent);
            perfume.Volume = (float)((Volume is null || Volume == 0) ? perfume.Volume : Volume);

            return perfume;


        }

        private string CheckNullOrWhiteSpace(string currentValue, string providedValue)
        {
            if(string.IsNullOrWhiteSpace(providedValue))
            {
                return currentValue;
            }
            return providedValue;
        }

    }
}
