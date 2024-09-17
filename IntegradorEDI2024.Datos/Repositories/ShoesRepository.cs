using Azure.Core.Pipeline;
using IntegradorEDI2024.Datos.Interfaces;
using IntegradorEDI2024.Entidades;
using IntegradorEDI2024.Entidades.Dto;
using IntegradorEDI2024.Entidades.Enum;
using Microsoft.EntityFrameworkCore;
using System.Security.AccessControl;

namespace IntegradorEDI2024.Datos.Repositories
{
    public class ShoesRepository : IShoesRepository
    {
        private readonly MiDbContext _context;

        public ShoesRepository(MiDbContext context)
        {
            _context = context;
        }

        public void Add(Shoe shoe)
        {
            var colorInDb = _context.Colors.FirstOrDefault(c=>c.ColorId==shoe.ColorId);
            if (colorInDb!=null)
            {
                _context.Attach(colorInDb);
                shoe.Color = colorInDb;
            }
            var genreInDb=_context.Genres.FirstOrDefault(g=>g.GenreId==shoe.GenreId);
            if (genreInDb!=null) 
            {
                _context.Attach(genreInDb);
                shoe.Genre= genreInDb;
            }
            var sportInDb = _context.Sports.FirstOrDefault(s => s.SportId == shoe.SportId);
            if (sportInDb != null)
            {
                _context.Attach(sportInDb);
                shoe.Sport = sportInDb;
            }
            var brandInDb = _context.Brands.FirstOrDefault(b => b.BrandId == shoe.BrandId);
            if (brandInDb != null)
            {
                _context.Attach(brandInDb);
                shoe.Brand = brandInDb;
            }
            _context.Shoes.Add(shoe);
        }

        public void Delete(Shoe shoe)
        {
            _context.Shoes.Remove(shoe);
        }

        public void Edit(Shoe shoe)
        {
            var colorInDb = _context.Colors.FirstOrDefault(c => c.ColorId == shoe.ColorId);
            if (colorInDb != null)
            {
                _context.Attach(colorInDb);
                shoe.Color = colorInDb;
            }
            var genreInDb = _context.Genres.FirstOrDefault(g => g.GenreId == shoe.GenreId);
            if (genreInDb != null)
            {
                _context.Attach(genreInDb);
                shoe.Genre = genreInDb;
            }
            var sportInDb = _context.Sports.FirstOrDefault(s => s.SportId == shoe.SportId);
            if (sportInDb != null)
            {
                _context.Attach(sportInDb);
                shoe.Sport = sportInDb;
            }
            var brandInDb = _context.Brands.FirstOrDefault(b => b.BrandId == shoe.BrandId);
            if (brandInDb != null)
            {
                _context.Attach(brandInDb);
                shoe.Brand = brandInDb;
            }
            _context.Shoes.Update(shoe);
        }

        public bool Exist(Shoe shoe)
        {
            if (shoe.ShoeId==0)
            {
                return _context.Shoes.Any(sh => sh.BrandId == shoe.BrandId
                                          && sh.SportId==shoe.SportId
                                          && sh.GenreId==shoe.GenreId
                                          && sh.ColorId==shoe.ColorId
                                          && sh.Model==shoe.Model);
            }
            return _context.Shoes.Any(sh => sh.BrandId == shoe.BrandId
                                          && sh.SportId == shoe.SportId
                                          && sh.GenreId == shoe.GenreId
                                          && sh.ColorId == shoe.ColorId
                                          && sh.Model == shoe.Model
                                          && sh.ShoeId!=shoe.ShoeId);
        }

        public List<ShoeListDto> GetList()
        {
            
            return _context.Shoes
                           .Include(sh => sh.Brand)
                           .Include(sh => sh.Color)
                           .Include(sh => sh.Genre)
                           .Include(sh => sh.Sport)
                           .Select(s => new ShoeListDto
                           {
                               ShoeId = s.ShoeId,
                               BrandName = s.Brand != null ? s.Brand.BrandName : string.Empty,
                               SportName = s.Sport != null ? s.Sport.SportName : string.Empty,
                               ColorName = s.Color != null ? s.Color.ColorName : string.Empty,
                               GenreName = s.Genre != null ? s.Genre.GenreName : string.Empty,
                               Description = s.Description != null ? s.Description : string.Empty,
                               Model = s.Model != null ? s.Model : string.Empty,
                               Price = s.Price
                           })
                           .OrderBy(s=>s.ShoeId)
                           .ToList();
        }

        public List<ShoeListDto> GetPaginatedList(int page, int itemsPerPage,Orden orden, Brand? brand, Color? color, Sport? sport, Genre? genre)
        {
            IQueryable<Shoe> query = _context.Shoes
                                   .Include(sh => sh.Brand)
                                   .Include(sh => sh.Color)
                                   .Include(sh => sh.Genre)
                                   .Include(sh => sh.Sport)
                                   .AsNoTracking();
            if (brand!=null)
            {
                query = query.Where(sh => sh.BrandId == brand.BrandId);
            }
            if (color != null)
            {
                query = query.Where(sh => sh.ColorId ==color.ColorId);
            }
            if (sport != null)
            {
                query = query.Where(sh => sh.SportId == sport.SportId);
            }
            if (genre != null)
            {
                query = query.Where(sh => sh.GenreId == genre.GenreId);
            }
            List<Shoe> paginatedList = query.Skip(page * itemsPerPage)
                                            .Take(itemsPerPage)
                                            .ToList();

            List<ShoeListDto>paginatedListDto=paginatedList.Select(s => new ShoeListDto
                                                    {
                                                        ShoeId = s.ShoeId,
                                                        BrandName = s.Brand != null ? s.Brand.BrandName : string.Empty,
                                                        SportName = s.Sport != null ? s.Sport.SportName : string.Empty,
                                                        ColorName = s.Color != null ? s.Color.ColorName : string.Empty,
                                                        GenreName = s.Genre != null ? s.Genre.GenreName : string.Empty,
                                                        Description = s.Description != null ? s.Description : string.Empty,
                                                        Model = s.Model != null ? s.Model : string.Empty,
                                                        Price = s.Price
                                                    }).ToList();
            switch (orden)
            {
                case Orden.AZ:
                    return paginatedListDto.OrderBy(s => s.BrandName)
                                .ThenBy(s => s.Model)
                                .ToList();
                case Orden.ZA:
                    return paginatedListDto.OrderByDescending(s => s.BrandName)
                                .ThenBy(s => s.Model)
                                .ToList();
                case Orden.LowestPrice:
                    return paginatedListDto.OrderBy(s => s.Price)
                                .ToList();
                case Orden.highestPrice:
                    return paginatedListDto.OrderByDescending(s => s.Price)
                                .ToList();
                case Orden.brandAZ:
                    return paginatedListDto.OrderBy(s => s.BrandName)
                                .ToList();
                case Orden.brandZA:
                    return paginatedListDto.OrderByDescending(s => s.BrandName)
                                .ToList();
                case Orden.colorAZ:
                    return paginatedListDto.OrderBy(s => s.ColorName)
                                .ToList();
                case Orden.colorZA:
                    return paginatedListDto.OrderByDescending(s => s.ColorName)
                                .ToList();
                case Orden.genreAZ:
                    return paginatedListDto.OrderBy(s => s.GenreName)
                                .ToList();
                case Orden.genreZA:
                    return paginatedListDto.OrderByDescending(s => s.GenreName)
                                .ToList();
                case Orden.sportAZ:
                    return paginatedListDto.OrderBy(s => s.SportName)
                                .ToList();
                case Orden.sportZA:
                    return paginatedListDto.OrderByDescending(s => s.SportName)
                                .ToList();
                default: 
                    return paginatedListDto.ToList();
            }
        }

        public int GetQuantity(Brand? brand, Color? color, Sport? sport, Genre? genre)
        {
            int quantity = 0;
            if (brand!=null)
            {
                quantity = _context.Shoes.Where(s => s.BrandId == brand.BrandId).Count();
            }
            if (color != null)
            {
                quantity = _context.Shoes.Where(s => s.ColorId == color.ColorId).Count();
            }
            if (sport != null)
            {
                quantity = _context.Shoes.Where(s => s.SportId == sport.SportId).Count();
            }
            if (genre != null)
            {
                quantity=_context.Shoes.Where(s => s.GenreId == genre.GenreId).Count();
            }
            quantity=_context.Shoes.Count();
            return quantity;
        }

        public Shoe? GetShoeById(int shoeId)
        {
            return _context.Shoes.Include(s => s.Brand)
                                 .Include(s => s.Color)
                                 .Include(s => s.Sport)
                                 .Include(s => s.Genre)
                                 .FirstOrDefault(s => s.ShoeId == shoeId);
        }
    }
}
