using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Engine.SiteParse
{
    class KinopoiskParse : IParserParams
    {
        public KinopoiskParse(string form_query)
        {
            query = form_query;
        }
        public string source { get; set; } = "https://www.kinopoisk.ru/";
        public string query { get; set; }
        public string xfile_name { get; set; } = "//div[@class='info']/p[@class='name']/a[@class='js-serp-metrika']";
        public string xfile_rating { get; set; } = "//div[@class='rating  ratingGreenBG']";
        public string xfile_year { get; set; } = "//span[@class='year']";
        public string xfile_info { get; set; } = "//div[@class='info']/span[@class='gray'][2]";

        //указываем пути для вытаскивания html'ек
    }
}
