using SimpleEchoBot.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleEchoBot.Handlers
{
    public class ReservationIntent
    {
        internal static CommonModel Process(CommonModel commonModel)
        {
            var time = commonModel.Request.Parameters.FirstOrDefault(p => p.Key == "time");
            var date = commonModel.Request.Parameters.FirstOrDefault(p => p.Key == "date");
            var number = commonModel.Request.Parameters.FirstOrDefault(p => p.Key == "number");

            commonModel.Response.Text = $"Perfect, your table for {number} is reserved for {time}. See you later!";

            return commonModel;
        }
    }
}