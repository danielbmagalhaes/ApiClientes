using AutoMapper;

namespace ApiClientes.App.Models.DTOs.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
            CreateMap<Cliente, ClienteSimplesDTO>().ReverseMap();
            CreateMap<Endereco, EnderecoDTO>().ReverseMap();
            CreateMap<Endereco, EnderecoSimplesDTO>().ReverseMap();
        }
    }
}
