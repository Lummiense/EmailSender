using AutoMapper;
using EmailSender.Domain;
using EmailSender.Services.Models;
using EmailSender.WebApi.Models;

namespace EmailSender.Services.Mapping
{
    public class MailMappingConfiguration:Profile
    {
        public MailMappingConfiguration()
        {
            CreateMap<Mail, MailDTO>().ReverseMap();

            CreateMap<MailDTO, MailResponseModel>()
                .ForMember(d => d.Recipients, map => map.MapFrom(src=>src.MailRecipients.Select(x=>x.Recipient.Email)));

            CreateMap<MailRequestModel, MailDTO>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.CreationDate, map => map.Ignore())
                .ForMember(d => d.Result, map => map.Ignore())
                .ForMember(d => d.FailedMessage, map => map.Ignore())
                .ForMember(d => d.MailRecipients, map => map.Ignore());
        }

    }
}
