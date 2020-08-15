using AngleSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Engine
{
    class LoadHTML
    {
        public string url;

        public IParserParams parserSettings;

        public LoadHTML(IParserParams parserSettings) //констуктор
        {
            this.parserSettings = parserSettings;

            url = parserSettings.source; //ссылка урл
        }

        public async Task Parser()
        {
            
            var baseAdress = new Uri(url);
            var cookieContainer = new CookieContainer();
            var handler = new HttpClientHandler() { CookieContainer = cookieContainer };
            var client = new HttpClient(handler) { BaseAddress = baseAdress };

            var firstpage = await client.GetAsync("");

            var query = parserSettings.query;

            var page = await client.GetAsync(query);

            File.WriteAllText("code.html", await page.Content.ReadAsStringAsync(), Encoding.UTF8);

        }
    }
}
