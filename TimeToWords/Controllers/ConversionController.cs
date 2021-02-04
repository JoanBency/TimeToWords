//using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using TimeToWords.Models;


namespace TimeToWords.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    public class ConversionController : ControllerBase
    {
        //private readonly IOptions<AppOptions> _options;

        /*public ConversionController(IOptions<AppOptions> options)
        {
            _options = options;
        }*/

      /*  public ConversionController(ILogger<ConversionController> logger)
        {
            _logger = logger;
        }*/
        public static String HoursToWords(String str)
        {
            String strInStr = "";
            switch (str)
            {
                case "01":
                    strInStr = "One";
                    break;
                case "02":
                    strInStr = "Two";
                    break;
                case "03":
                    strInStr = "Three";
                    break;
                case "04":
                    strInStr = "Four";
                    break;
                case "05":
                    strInStr = "Five";
                    break;
                case "06":
                    strInStr = "Six";
                    break;
                case "07":
                    strInStr = "Seven";
                    break;
                case "08":
                    strInStr = "Eight";
                    break;
                case "09":
                    strInStr = "Nine";
                    break;
                case "10":
                    strInStr = "Ten";
                    break;
                case "11":
                    strInStr = "Eleven";
                    break;
                case "12":
                    strInStr = "Twelve";
                    break;
            }
            return strInStr;
        }

        public static String MinutesToWords(String str)
        {
            String strInStr = "";
            if (str[0] != '1')
            {
                switch (str[0])
                {
                    case '2':
                        strInStr = "Twenty";
                        break;
                    case '3':
                        strInStr = "Thirty";
                        break;
                    case '0':
                        strInStr = "";
                        break;
                }
            }
            else if (str[0] == '1')
            {
                switch (str)
                {
                    case "10":
                        strInStr = "Ten";
                        break;
                    case "11":
                        strInStr = "Eleven";
                        break;
                    case "12":
                        strInStr = "Twelve";
                        break;
                    case "13":
                        strInStr = "Thirteen";
                        break;
                    case "14":
                        strInStr = "Fourteen";
                        break;
                    case "15":
                        strInStr = "Fifteen";
                        break;
                    case "16":
                        strInStr = "Sixteen";
                        break;
                    case "17":
                        strInStr = "Seventeen";
                        break;
                    case "18":
                        strInStr = "Eighteen";
                        break;
                    case "19":
                        strInStr = "Nineteen";
                        break;
                }
            }
            if (str[0] != '1')
            {
                switch (str[1])
                {
                    case '1':
                        strInStr = strInStr + "One";
                        break;
                    case '2':
                        strInStr = strInStr + "Two";
                        break;
                    case '3':
                        strInStr = strInStr + "Three";
                        break;
                    case '4':
                        strInStr = strInStr + "Four";
                        break;
                    case '5':
                        strInStr = strInStr + "Five";
                        break;
                    case '6':
                        strInStr = strInStr + "Six";
                        break;
                    case '7':
                        strInStr = strInStr + "Seven";
                        break;
                    case '8':
                        strInStr = strInStr + "Eight";
                        break;
                    case '9':
                        strInStr = strInStr + "Nine";
                        break;
                }
            }
            return strInStr;
        }


        public static String Timetowordsfunc(string time_num)
        {
            String TimeinWords = "";
            int flag = 0;
            String hours = "", minutes = "";
            for (int i = 0; i < time_num?.Length; i++)
            {
                if (time_num[i] != ':' && flag == 0)
                {
                    hours = hours + time_num[i];
                }
                else if (time_num[i] == ':')
                {
                    flag = 1;
                }
                else if (time_num[i] != ':' && flag == 1)
                {
                    minutes = minutes + time_num[i];
                }
            }
            int flag_minMoreThan30 = 0;
            if (Int32.Parse(minutes) > 30)
            {
                string temp_hours = hours, temp_minutes = minutes;
                flag_minMoreThan30 = 1;
                hours = (1 + Int32.Parse(hours)).ToString();
                minutes = (60 - Int32.Parse(minutes)).ToString();
                if (temp_hours[0] == '0' && temp_hours[1] != '9')
                {
                    hours = '0' + hours;
                }
                if (temp_hours == "12")
                {
                    hours = "01";
                }
                if (temp_minutes[0] == '5' && temp_minutes[1] != '0')
                {
                    minutes = '0' + minutes;
                }
                //Console.WriteLine(hours);
                //Console.WriteLine(minutes);
            }

            string hoursInWords = HoursToWords(hours);
            string minutesInWords = MinutesToWords(minutes);

            if (flag_minMoreThan30 == 0)
            {
                if (minutes == "30")
                {
                    TimeinWords = "Half past " + hoursInWords;
                }
                else if (minutes == "15")
                {
                    TimeinWords = "Quarter past " + hoursInWords;
                }
                else if (minutes == "00")
                {
                    TimeinWords = hoursInWords + " o' clock";
                }
                else
                {
                    TimeinWords = minutesInWords + " past " + hoursInWords;
                }
            }
            if (flag_minMoreThan30 == 1)
            {
                if (minutes == "15")
                {
                    TimeinWords = "Quarter to " + hoursInWords;
                }
                else
                {
                    TimeinWords = minutesInWords + " to " + hoursInWords;
                }
            }
            return TimeinWords;
        }

        [HttpGet("[action]/{time_num}")]
        public IEnumerable<Time> towords(String time_num1)
        {
            string TimeinWord = Timetowordsfunc(time_num1);
            var result = new Time
            {
                time_num = time_num1,
                TimeinWords = TimeinWord
        };
            return (IEnumerable<Time>)result;
        }
    }
}
