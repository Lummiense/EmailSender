using AutoMapper;
using EmailSender.Domain;
using EmailSender.Services.Models;
using EmailSender.Services.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;

namespace EmailSender.Services.Mail_Service
{
    public class MailService : IMailService
    {
        private readonly IMapper _mapper;
        private readonly IMailRepository _mailRepository;
        private readonly AppSettings _appSettings;
        public MailService(IMapper mapper, IMailRepository mailRepository,IOptions<AppSettings> appSettings)
        {
            _mapper = mapper;
            _mailRepository = mailRepository;
            _appSettings = appSettings.Value;
        }

        public async Task<Guid> SendMailAsync(MailDTO mailDTO)
        {
            foreach(var r in mailDTO.MailRecipients)
            {                
                #region Create message
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse("SenderApp@app.ru"));
                email.To.Add(MailboxAddress.Parse(r.Recipient.Email));
                email.Subject = mailDTO.Subject;
                email.Body = new TextPart(TextFormat.Html) { Text = mailDTO.Body};
                #endregion

                mailDTO.Id = Guid.NewGuid();
                mailDTO.CreationDate = DateTime.Now;
            }




            var entity = _mapper.Map<Mail>(mailDTO);
            await _mailRepository.AddAsync(entity);
            
            return entity.Id;
        }

        public async Task<ICollection<MailDTO>> GetAllMailsAsync()
        {
            var entities = await _mailRepository.GetMailsAsync();
            var mailsDTO = _mapper.Map<ICollection<MailDTO>>(entities);
            return mailsDTO;           
        }

      
    }
}
