using AutoMapper;
using EmailSender.Domain;
using EmailSender.Services.Models;
using EmailSender.Services.Repository;
using MailKit.Net.Smtp;
using MailKit.Security;
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
        private readonly IConfiguration _configuration;
        public MailService(IMapper mapper, IMailRepository mailRepository,IConfiguration configuration)
        {
            _mapper = mapper;
            _mailRepository = mailRepository;
            _configuration = configuration;
        }

        public async Task<Guid> SendMailAsync(MailDTO mailDTO)
        {
            foreach(var r in mailDTO.MailRecipients)
            {
                mailDTO.Id = Guid.NewGuid();
                mailDTO.CreationDate = DateTime.Now;
                #region Create message
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(_configuration["EmailFrom"]));
                email.To.Add(MailboxAddress.Parse(r.Recipient.Email));
                email.Subject = mailDTO.Subject;
                email.Body = new TextPart(TextFormat.Html) { Text = mailDTO.Body};
                #endregion
                /*var smtp = new SmtpClient();
                smtp.Connect(_configuration["SmtpHost"], _configuration["AppSettings:SmtpPort"]);
                smtp.Authenticate(_appSettings.SmtpUser, _appSettings.SmtpPass);
                smtp.Send(email);
                smtp.Disconnect(true);*/

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
