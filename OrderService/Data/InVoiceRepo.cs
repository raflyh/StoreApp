﻿

using Microsoft.EntityFrameworkCore;
using OrderService.Interface;
using OrderService.Model;

namespace OrderService.Data
{
    public class InVoiceRepo : IInVoiceRepo
    {
        private readonly AppDbContext _context;

        public InVoiceRepo(AppDbContext context)
        {
            _context = context;
        }

        public void CreateInVoice(int productId, InVoice inVoice)
        {
            if(inVoice == null)
                throw new ArgumentNullException(nameof(inVoice));

            inVoice.ProductId = productId;
            _context.InVoices.Add(inVoice);
        }

        public void CreateProduct(Product prod)
        {
            if(prod == null)
                throw new ArgumentNullException(nameof(prod));
            _context.Products.Add(prod);
        }
            
        public bool ExternalProductExist(int externalProductId)
        {
            return _context.Products.Any(p=>p.ExternalId == externalProductId);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public InVoice GetInVoice(int productId, int inVoiceId)
        {
            return _context.InVoices.Where(i => i.ProductId == productId &&
            i.Id == inVoiceId).FirstOrDefault(); ;
        }


        public Product GetProductByName(string name)
        {
            return _context.Products.FirstOrDefault(p => p.Name == name);
        }

        public bool ProductExist(int productId)
        {
            return _context.Products.Any(p => p.Id == productId);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
