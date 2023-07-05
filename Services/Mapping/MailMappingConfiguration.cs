using AutoMapper;
using EmailSender.Domain;
using EmailSender.Services.Contracts;
using EmailSender.Services.Models;
using EmailSender.WebApi.Models;

namespace EmailSender.Services.Mapping
{
    /// <summary>
    /// Класс конфигурации маппинга сущностей и моделей писем.
    /// </summary>
    public class MailMappingConfiguration:Profile
    {
        public MailMappingConfiguration()
        {
            CreateMap<Mail, MailDTO>().ReverseMap();            
            CreateMap<MailDTO, MailResponseModel>()
                .ForMember(d => d.Recipients, map => map.MapFrom(src=>src.MailRecipients));
            CreateMap<MailRecipientDTO, RecipientResponse>()
                .ForMember(d => d.Id, map => map.MapFrom(src => src.RecipientId))
                .ForMember(d => d.Email, map => map.MapFrom(src => src.Recipient.Email))
                .ForMember(d => d.Name, map => map.MapFrom(src => src.Recipient.Name));

            CreateMap<MailRecipient, MailRecipientDTO>().ReverseMap();

            CreateMap<MailRequestModel, MailDTO>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.CreationDate, map => map.Ignore())
                .ForMember(d => d.Result, map => map.Ignore())
                .ForMember(d => d.FailedMessage, map => map.Ignore())
                .ForMember(d => d.MailRecipients, map => map.Ignore());
        }

    }
}
