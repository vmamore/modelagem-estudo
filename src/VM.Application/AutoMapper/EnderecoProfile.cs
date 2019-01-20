using AutoMapper;
using VM.Domain.ValueObjects;
using VM.Presentation.Application.ViewModels;

namespace VM.Application.AutoMapper
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            CreateMap<Endereco, EnderecoViewModel>()
                .ForMember(d => d.Cep, opt => opt.MapFrom(src => src.Cep.Numero));

            CreateMap<EnderecoViewModel, Endereco>()
                .ForMember(d => d.Cep, opt => opt.MapFrom(src =>  new Cep(src.Cep)));
        }
    }
}
