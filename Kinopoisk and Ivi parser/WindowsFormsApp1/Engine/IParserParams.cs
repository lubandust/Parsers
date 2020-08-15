using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Engine
{
    interface IParserParams
    {
        string source { get; set; }
        string query { get; set; }
        string xfile_name { get; set; }
        string xfile_rating { get; set; }
        string xfile_year { get; set; }
        string xfile_info { get; set; }
    }
}
