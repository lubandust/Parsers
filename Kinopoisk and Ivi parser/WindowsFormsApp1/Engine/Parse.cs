using AngleSharp.Common;
using HtmlAgilityPack;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Engine.ResultToForms;

namespace WindowsFormsApp1.Engine
{
    class Parse 
    {
        IParserParams parserSettings; 
        LoadHTML loader;
        //поля нужных xfile
        string names;

        string info;

        string rating;

        string year;

        public IParserParams Settings
        {
            get { return parserSettings; }
            set
            {
                parserSettings = value; //Новые настройки парсера
                loader = new LoadHTML(parserSettings);
            }
        }

        private ArrayList ReturnNodes(string xfile, HtmlDocument html_code)
        {
            ArrayList list = new ArrayList();

            var GetNodes = html_code.DocumentNode.SelectNodes(xfile);

            foreach (var x in GetNodes)
            {
                list.Add(x.InnerText);
            }

            return list;
        }

        private void SetToRows(ArrayList Names, ArrayList Rating, ArrayList Info, ArrayList Year)
        {
            ParseToRows rows = new ParseToRows();

            rows.dataToTable(Names, Rating, Info, Year);
        }

        public async void ParsingAsync() {
        
        names = parserSettings.xfile_name;

        info = parserSettings.xfile_info;

        rating = parserSettings.xfile_rating;

        year = parserSettings.xfile_year;

        HtmlDocument html_code = new HtmlDocument();

        await loader.Parser();

        html_code.Load("code.html");

        ArrayList Names = new ArrayList();

        Names = ReturnNodes(names, html_code);

        ArrayList Info = new ArrayList();

        Info = ReturnNodes(info, html_code);

        ArrayList Rating = new ArrayList();

        Rating = ReturnNodes(rating, html_code);

        ArrayList Year = new ArrayList();

        Year = ReturnNodes(year, html_code);

        SetToRows(Names, Rating, Info, Year);
        }
    }
}
