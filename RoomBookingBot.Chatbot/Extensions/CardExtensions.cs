﻿using Microsoft.Bot.Schema;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace RoomBookingBot.Chatbot.Extensions
{
    public static class CardExtensions
    {

        public static void AddAdaptiveCardRoomConfirmationAttachment(this Activity activity, string room, string date, string time, string attendees)
        {
            activity.Attachments = new List<Attachment>() { CreateAdaptiveCardRoomConfirmationAttachment(room, date, time, attendees) };
        }


        private static Attachment CreateAdaptiveCardRoomConfirmationAttachment(string room, string date, string time, string attendees)
        {
            var adaptiveCard = File.ReadAllText(@".\adaptivecard.roomconfirmation.json");
            adaptiveCard= adaptiveCard.Replace("$(room)", room);
            adaptiveCard= adaptiveCard.Replace("$(date)", date);
            adaptiveCard= adaptiveCard.Replace("$(time)", time);
            adaptiveCard= adaptiveCard.Replace("$(attendees)", attendees);
            return new Attachment()
            {
                ContentType = "application/vnd.microsoft.card.adaptive",
                Content = JsonConvert.DeserializeObject(adaptiveCard)
            };
        }
    }
}
