using IntegradorEDI2024.Entidades;
using IntegradorEDI2024.Entidades.Dto;
using IntegradorEDI2024.Entidades.Enum;

namespace IntegradorEDI2024.Servicios.Interfaces
{
    public interface IShoesService
    {
        void Save(Shoe shoe);
        void Delete(Shoe shoe);
        List<ShoeListDto> GetList();
        bool Exist(Shoe shoe);
        Shoe? GetShoeById(int shoesId);
        int GetQuantity(Brand? brand, Color? color, Sport? sport, Genre? genre);
        List<ShoeListDto> GetPaginatedList(int page, int itemsPerPage,Orden orden, Brand? brand, Color? color, Sport? sport, Genre? genre);
    }
}
