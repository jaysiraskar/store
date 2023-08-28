using API.Dtos;
using AutoMapper;
using Core.Entities;


namespace API.Helpers
{
    public class ProductUrlResolver : IValueResolver<Product, ProductToReturnDto, string>
    {
        private readonly IConfiguration config;
        public ProductUrlResolver(IConfiguration _config){
            config = _config;
        }
        
        public string Resolve(Product source, ProductToReturnDto destination, string destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.PictureUrl)){
                return config["ApiUrl"] + source.PictureUrl;
            }
            return null;
        }

    }
}