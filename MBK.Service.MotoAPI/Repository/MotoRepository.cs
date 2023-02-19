using Handmade.Service.EmbroideryAPI.DbContexts;
using Handmade.Service.EmbroideryAPI.Models;
using Handmade.Service.EmbroideryAPI.Models.Dto;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Text;

namespace Handmade.Service.EmbroideryAPI.Repository
{
	public class EmbroideryRepository : IEmbroideryRepository
	{
		private readonly ApplicationDbContext _db;
		private IMapper _mapper;

		//Injection des dependece (constructeurs)
		public EmbroideryRepository(ApplicationDbContext db, IMapper mapper)
		{
			_db = db;
			_mapper = mapper;
		}

		// La première ligne déclare une méthode asynchrone qui retourne un objet de type ProductDto et prend en paramètre un objet de type ProductDto également.

		public async Task<EmbroideryDto> CreateUpdateEmbroidery(EmbroideryDto embroideryDto)
		{
			// Product product =  await _db.Products.Where(x => x.ProductId ==productDto.ProductId).FirstOrDefaultAsync();
			//La ligne suivante utilise un objet "mapper" pour convertir l'objet productDto en un objet "Product"
			Embroidery em = _mapper.Map<Embroidery>(embroideryDto);
			// La ligne suivante utilise une condition "if" pour vérifier si l'identifiant de produit (ProductId) est inférieur ou égal à 0. Si c'est le cas, cela signifie qu'il s'agit d'un nouveau produit qui doit être ajouté à la base de données.

			if (em.EmbroideryId <= 0)
			{

				// La ligne suivante utilise la méthode "Add" pour ajouter le nouveau produit à la base de données.

				// La ligne suivante utilise la méthode "SaveChanges" pour enregistrer les modifications dans la base de données.
				_db.Embroideries.Add(em);
				_db.SaveChanges();
			}
			// La ligne suivante est un "else", qui est exécuté si l'identifiant de produit est supérieur à 0. Cela signifie qu'il s'agit d'un produit existant qui doit être mis à jour dans la base de données.

			else
			{
				// La ligne suivante utilise la méthode "Update" pour mettre à jour le produit dans la base de données.

				// La ligne suivante utilise la méthode "SaveChanges" pour enregistrer les modifications dans la base de données.


				_db.Embroideries.Update(em);
				_db.SaveChanges();
			}

			// La dernière ligne utilise à nouveau l'objet "mapper" pour convertir l'objet "Product" mis à jour en un objet "ProductDto" et le retourne

			return _mapper.Map<EmbroideryDto>(em); ;
		}

		public async Task<bool> DeleteEmbroidery(int embroideryId)
		{
			Embroidery embroidery = await _db.Embroideries.Where(x => x.Id == embroideryId).FirstOrDefaultAsync();
			if (embroidery == null) { return false; }
			else
			{
				_db.Embroideries.Remove(embroidery);
				_db.SaveChanges(); return true;
			}

		}

		public async Task<EmbroideryDto> GetEmbroideryById(int embroideryId)
		{
			Embroidery embroidery = await _db.Embroideries.Where(x => x.Id == embroideryId).FirstOrDefaultAsync();
			return _mapper.Map<EmbroideryDto>(embroidery);
		}

		public async Task<IEnumerable<EmbroideryDto>> GetEmbroideries()
		{

			List<Embroidery> embroideryList = await _db.Embroideries.ToListAsync();
			return _mapper.Map<List<EmbroideryDto>>(embroideryList);
		}

		public Task<EmbroideryDto> CreateUpdateProduct(EmbroideryDto embroideryDto)
		{
			throw new NotImplementedException();
		}
	}
}
