using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using HtmlAgilityPack;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Engine.SiteParse;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Engine.Parse kinopoisk_parser;

        Engine.Parse ivi_parser;

        public Form1()
        {
            InitializeComponent();
        }

        public DataGridView getDataGridView()
        {
            return dataGridView1;
        }

        /*     static Dictionary<string, string> dict_kinopoisk = new Dictionary<string, string>
             {
                 ["Драма"] = "/lists/navigator/drama/",
                 ["Комедия"] = "/lists/navigator/comedy/",
                 ["Приключения"] = "/lists/navigator/adventure/",
                 ["Триллеры"] = "/lists/navigator/thriller/",
                 ["Ужасы"] = "/lists/navigator/horror/",
                 ["Фэнтези"] = "/lists/navigator/fantasy/",
                 ["Фантастика"] = "/lists/navigator/sci-fi/",
                 ["Детективы"] = "/lists/navigator/mystery/"
             };

             static Dictionary<string, string> dict_ivi = new Dictionary<string, string>
             {
                 ["Драма"] = "/movies/drama",
                 ["Комедия"] = "/movies/comedy",
                 ["Приключения"] = "/movies/adventures",
                 ["Триллеры"] = "/movies/thriller",
                 ["Ужасы"] = "/movies/horror",
                 ["Фэнтези"] = "/movies/fentezi",
                 ["Фантастика"] = "/movies/fantastika",
                 ["Детективы"] = "/movies/detective"
             }; */

        private string get_Radiobutton(GroupBox group)
        {
            foreach (Control control in group.Controls)
            {
                if (control.GetType() == typeof(System.Windows.Forms.RadioButton))
                {
                    RadioButton rb = (RadioButton)control;

                    if (rb.Checked)
                    {
                        return rb.Text;
                    }
                }
            }

            return "0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string cinema_jenre = get_Radiobutton(groupBox1);
            if (textBox1.Text != "")
            {
                string source = get_Radiobutton(groupBox2);

                string query = textBox1.Text;

                if (source == "Кинопоиск")
                {
                    // string url_jenrepart = dict_kinopoisk[cinema_jenre];
                    string url = "https://www.kinopoisk.ru/";

                    query = "index.php?kp_query=" + query;

                    kinopoisk_parser = new Engine.Parse();

                    kinopoisk_parser.Settings = new KinopoiskParse(query);

                    kinopoisk_parser.ParsingAsync();
                }

                if (source == "ivi")
                {
                    //  string url_jenrepart = dict_ivi[cinema_jenre];
                    string url = "https://www.ivi.ru/";

                    query = "search/?q=" + query;

                    ivi_parser = new Engine.Parse();

                    ivi_parser.Settings = new IviParse(query);

                    ivi_parser.ParsingAsync();

                    
                }
            }

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
