using AutoMapper;
using EmailSender.Domain;
using EmailSender.Services;
using EmailSender.Services.Models;
using EmailSender.Services.Repository;
using EmailSender.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmailSender.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailsController : ControllerBase
    {
        private IMailService _mailService;
        private IRepository<Recipient> _recipientRepository;
        private IMapper _mapper;
        public MailsController(IMailService mailService, IRepository<Recipient> recipientRepository, IMapper mapper)
        {
            _mailService = mailService;
            _recipientRepository = recipientRepository;
            _mapper = mapper;
        }
        /// <summary>
        /// Получить список всех писем.
        /// </summary>
        /// <returns>Статус-код выполнения запроса и список всех сформированных писем.</returns>        
        [HttpGet]
        public async Task <IActionResult> GetMails()
        {           
            var mails = await _mailService.GetAllMailsAsync();
            if (mails == null)
            {
                throw new Exception();
            }
            var result = _mapper.Map<List<MailResponseModel>>(mails);
            /*foreach (var mail in result)
            {
                mail.Recipients.Add(mails.Select(x=>x.MailRecipi);
               
            }*/
            return Ok(result);
        }


        /// <summary>
        /// Сформировать и отправить письмо.
        /// </summary>
        /// <param name="mailRequest">Тема, тело и список получателей письма.</param>
        /// <returns>Статус-код выполнения запроса</returns>
        [HttpPost]
        public async Task <IActionResult> CreateMail(MailRequestModel mailRequest)
        {
            var mailDTO = _mapper.Map<MailDTO>(mailRequest);
            foreach (var r in mailRequest.Recipients)
            {
                var recipient =await _recipientRepository.GetByFilter(x => x.Email == r);
                if (recipient == null)
                {
                    mailDTO.MailRecipients = new List<MailRecipient>{(new MailRecipient()
                    {
                        MailId = Guid.NewGuid(),
                        RecipientId = Guid.NewGuid(),
                        Recipient = new Recipient()
                        {
                            Email = r,
                            Name = r,
                        }
                    }) };
                }
                
                else
                {
                    mailDTO.MailRecipients = new List<MailRecipient>{(new MailRecipient()
                    {
                        MailId = Guid.NewGuid(),
                        RecipientId = recipient.Id,
                    }) };
                }
            }
            var resultMessages = await _mailService.SendMailAsync(mailDTO);

           
            
            try
            {
                await _mailService.SaveMails(resultMessages);
            }
            catch (Exception ex)
            {
                throw;
            }
            return Ok("Сообщение сформировано");
        }       
    }
}
