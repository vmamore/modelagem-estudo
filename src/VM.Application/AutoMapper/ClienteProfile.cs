using AutoMapper;
using VM.Domain.Models;
using VM.Presentation.Application.ViewModels;

namespace VM.Application.AutoMapper
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            CreateMap<Cliente, ClienteViewModel>()
                .ForMember(d => d.CPF, opt => opt.MapFrom(src => src.Cpf.Numero))
                .ForMember(d => d.Email, opt => opt.MapFrom(src => src.Email.Endereco))
                .ForMember(d => d.DataDeNascimento, opt => opt.MapFrom(src => src.Idade.DataNascimento))
                .ReverseMap();
        }
    }
}
