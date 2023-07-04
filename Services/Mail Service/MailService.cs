using AutoMapper;
using EmailSender.Domain;
using EmailSender.Services.Models;
using EmailSender.Services.Repository;
using EmailSender.WebApi.Helpers;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;

namespace EmailSender.Services.Mail_Service
{
    public class MailService : IMailService
    {
        private readonly IMapper _mapper;
        private readonly IMailRepository _mailRepository;
        //private readonly IRepository<Recipient> _recipientRepository;
        private readonly SMTPSettings _smtp;
        public MailService(IMapper mapper, IMailRepository mailRepository, IOptions<SMTPSettings> smtp)
        {
            _mapper = mapper;
            _mailRepository = mailRepository;
            //_recipientRepository = recipientRepository;
            _smtp = smtp.Value;
        }

        public Task<List<MailDTO>> SendMailAsync(MailDTO mailDTO)
        {
            var mails = new List<MailDTO>();
            foreach (var r in mailDTO.MailRecipients)
            {               
                mailDTO.CreationDate = DateTime.Now;
                #region Create message
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(_smtp.EmailFrom));
                email.To.Add(MailboxAddress.Parse(r.Recipient.Email));
                email.Subject = mailDTO.Subject;
                email.Body = new TextPart(TextFormat.Plain) { Text = mailDTO.Body};
                #endregion

                #region Send Message
                var smtp = new SmtpClient();
                smtp.Connect(_smtp.SmtpHost, _smtp.SmtpPort);
                smtp.Authenticate(_smtp.SmtpUser, _smtp.SmtpPass);
                try
                {
                    smtp.Send(email);                    
                }
                catch (Exception ex)
                {
                    mailDTO.Result = "Failed";
                    mailDTO.FailedMessage=ex.Message;
                    throw;
                 }
                finally
                {
                    mailDTO.Result = "OK";
                    mailDTO.FailedMessage = "";
                }
                smtp.Disconnect(true);
                #endregion
                mails.Add(mailDTO);
            }
            return Task.FromResult(mails);
        } 
        public async Task SaveMails(List<MailDTO> mails)
        {
            var entities = _mapper.Map<List<Mail>>(mails);
            await _mailRepository.AddRangeAsync(entities);
            await _mailRepository.SaveChangesAsync();
        }
        public async Task<IQueryable<MailDTO>> GetAllMailsAsync()
        {
            var entities = await _mailRepository.GetMailsAsync();
            var mailsDTO = _mapper.Map<IQueryable<MailDTO>>(entities);
            return mailsDTO;           
        }       
    }
}
