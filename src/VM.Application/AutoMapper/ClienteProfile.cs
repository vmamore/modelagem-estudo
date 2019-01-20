using AutoMapper;
using VM.Domain.Models;
using VM.Domain.ValueObjects;
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
                .ForSourceMember(src => src.CascadeMode, opt => opt.DoNotValidate())
                .ForSourceMember(src => src.ValidationResult, opt => opt.DoNotValidate())
                .ForSourceMember(src => src.Endereco, opt => opt.DoNotValidate());

            CreateMap<ClienteViewModel, Cliente>()
                .ForMember(d => d.Email, opt => opt.MapFrom(src => new Email(src.Email)))
                .ForMember(d => d.Cpf, opt => opt.MapFrom(src => new CPF(src.CPF)))
                .ForMember(d => d.Idade, opt => opt.MapFrom(src => new Idade(src.DataDeNascimento)));
        }
    }
}
