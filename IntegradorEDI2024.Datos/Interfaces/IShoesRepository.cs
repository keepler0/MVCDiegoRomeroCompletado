using IntegradorEDI2024.Entidades;
using IntegradorEDI2024.Entidades.Dto;
using IntegradorEDI2024.Entidades.Enum;

namespace IntegradorEDI2024.Datos.Interfaces
{
    public interface IShoesRepository
    {
        List<ShoeListDto> GetList();
        void Add(Shoe shoe);
        void Edit(Shoe shoe);
        void Delete(Shoe shoe);
        bool Exist(Shoe shoe);
        int GetQuantity(Brand? brand, Color? color, Sport? sport, Genre? genre);
        Shoe? GetShoeById(int shoeId);
        List<ShoeListDto> GetPaginatedList(int page, int itemsPerPage,Orden orden, Brand? brand, Color? color, Sport? sport, Genre? genre);
    }
}
