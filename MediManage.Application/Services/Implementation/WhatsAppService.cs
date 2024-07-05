using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio.Types;
using Twilio;
using MediManage.Application.Services.Interfaces;
using Twilio.Rest.Api.V2010.Account;

namespace MediManage.Application.Services.Implementation
{
    public class WhatsAppService : IWhatsAppService
    {
        private readonly string _accountSid;
        private readonly string _authToken;
        private readonly string _twilioWhatsAppNumber;

        public WhatsAppService(IConfiguration configuration)
        {
            _accountSid = configuration["Twilio:AccountSid"];
            _authToken = configuration["Twilio:AuthToken"];
            _twilioWhatsAppNumber = configuration["Twilio:TwilioNumber"];

            TwilioClient.Init(_accountSid, _authToken);
        }

        public void SendWhatsAppMessage(string to, string message)
        {
            var toPhoneNumber = new PhoneNumber("whatsapp:" + to);
            var fromPhoneNumber = new PhoneNumber("whatsapp:" + _twilioWhatsAppNumber);

            var messageOptions = new CreateMessageOptions(toPhoneNumber)
            {
                From = fromPhoneNumber,
                Body = message
            };

            var msg = MessageResource.Create(messageOptions);
            Console.WriteLine($"Mensagem enviada: SID {msg.Sid}");
        }
    }
}
