using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System.Configuration;

using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

using Twilio.TwiML;
using Twilio.AspNet.Mvc;

namespace nowui.Controllers
{
   
    public class SMSController : Controller
    {
        public IActionResult Index()
        {
            
            var accountSid = "AC39fb4c5becd80182966bb90d4b795cdf";
            var authToken = "50fa999051822c4e265bb0a0a7e0bbf4";

            TwilioClient.Init(accountSid, authToken);


            var to = new PhoneNumber("+61435947076");
            var from = new PhoneNumber("+12513602050");

            var message = MessageResource.Create(
                to: to,
                from: from,
                body: " Hi Worker, Accept today's shift by logging at https://smarttrash.azurewebsites.net/WorkerDashboard/Index. Go to Routes and select the particular council you are wokring on to get the optimized route to start. :) ");



            return View();
        }

        public ActionResult ReceiveSms()
        {
            var respone = new MessagingResponse();
            respone.Message("Got it bro!!");

            return View(respone);
        }
    }
}