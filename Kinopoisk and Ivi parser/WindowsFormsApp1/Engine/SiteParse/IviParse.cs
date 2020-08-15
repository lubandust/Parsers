using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Engine.SiteParse
{
    class IviParse : IParserParams
    {
        // Parse parsing = new Parse();//Выгрузка html там же
        
        public IviParse(string form_query)
        {
            query = form_query;
        }

        public string source { get; set; } = "https://www.ivi.ru/";
        public string query { get; set; }
        public string xfile_name { get; set; } = "//div[@class='nbl-slimPosterBlock__title']";
        public string xfile_rating { get; set; } = "//div[@class='nbl-ratingCompact__value']";
        public string xfile_year { get; set; } = "//div[@class='nbl-poster__propertiesInfo']/div[@class='nbl-poster__propertiesRow'][2]";
        public string xfile_info { get; set; } = "//div[@class='nbl-poster__propertiesInfo']/div[@class='nbl-poster__propertiesRow'][1]";

    }
}
