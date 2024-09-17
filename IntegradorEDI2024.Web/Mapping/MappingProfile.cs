using AutoMapper;
using IntegradorEDI2024.Entidades;
using IntegradorEDI2024.Entidades.ViewModels.Brand;
using IntegradorEDI2024.Entidades.ViewModels.Color;
using IntegradorEDI2024.Entidades.ViewModels.Genre;
using IntegradorEDI2024.Entidades.ViewModels.Sport;

namespace IntegradorEDI2024.Web.Mapping
{
	public class MappingProfile:Profile
	{
        public MappingProfile()
        {
            LoadBrandsMapping();
			LoadColorsMapping();
			LoadSportMapping();
            LoadGenresMapping();
        }

        private void LoadGenresMapping()
        {
            CreateMap<Genre, GenreEditVm>().ReverseMap();
        }

        private void LoadSportMapping()
		{
			CreateMap<Sport,SportEditVm>().ReverseMap();
		}
		private void LoadBrandsMapping()
		{
			CreateMap<Brand,BrandEditVm>().ReverseMap();
		}
		private void LoadColorsMapping()
		{
            CreateMap<Color,ColorEditVm>().ReverseMap();
        }
	}
}
