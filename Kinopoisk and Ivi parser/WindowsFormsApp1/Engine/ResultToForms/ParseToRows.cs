using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Engine.ResultToForms
{
    class ParseToRows
    {
        DataTable dt = new DataTable();

  /*      public void dataToRow(ArrayList data, string row_name)
        {
            foreach (object x in data)
            {
                DataRow dr = dt.NewRow();
            // MessageBox.Show(x.ToString());
                string parameter = x.ToString();
                dr[row_name] = parameter;
                dt.Rows.Add(dr);
            }
        }*/


        public void dataToTable(ArrayList film_name, ArrayList film_rating, ArrayList film_info, ArrayList film_year)
        {
            dt.Columns.Add("Name");
        //    dataToRow(film_name, "Name");
            dt.Columns.Add("Rating");
        //    dataToRow(film_rating, "Rating");
            dt.Columns.Add("Info");
       //     dataToRow(film_jenre, "Jenre");
            dt.Columns.Add("Year");
        //    dataToRow(film_year, "Year");*/
            for (int i = 0; i < Math.Min(film_rating.Count, Math.Min(film_info.Count, film_year.Count)); i++)
            {
                dt.Rows.Add(film_name[i], film_rating[i], film_info[i], film_year[i]);
            }
            Form1 form = new Form1();

            form.dataGridView1.DataSource = dt;

            form.ShowDialog();
        }
    }
}
