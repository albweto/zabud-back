using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace ZabudApi.Models
{
    public class SalesDataAccesLayer
    {
        #region "String Conectio"
        string conection = "Server=localhost;Port=3306;Database=PruebaZabud;Uid=root;Pwd=Shenriquez10";
        #endregion


        #region  "Public Methods"
        public IEnumerable<Sale> getAllSales()
        {
            try
            {
                List<Sale> listSales = new List<Sale>();

                using (MySqlConnection con = new MySqlConnection(conection))
                {
                    MySqlCommand cmd = new MySqlCommand("sp_select_sale ", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();

                    MySqlDataReader read = cmd.ExecuteReader();

                    while (read.Read())
                    {
                        Sale sale = new Sale();

                        sale.ID = Convert.ToInt32(read["id"]);
                        sale.client = Convert.ToInt32(read["client_id"]);
                        sale.dateSale = Convert.ToDateTime(read["date_sale"]);
                        sale.totalPrice = Convert.ToInt32(read["total_price"]);

                        listSales.Add(sale);
                    }
                    con.Close();
                }
                return listSales;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        

        /**
        Method  what function is to delete  the sale 
        @param name="id"
        @returns 
         */
        public int DeleteSale(int id)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(conection))
                {
                    MySqlCommand cmd = new MySqlCommand("sp_delet_sale", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("s_id", id);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return 1;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        


        public int addsales(Sale sale)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(conection))
                {
                    MySqlCommand cmd = new MySqlCommand("sp_insert_sal", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("s_client", sale.client);
                    cmd.Parameters.AddWithValue("s_date", sale.dateSale);
                    cmd.Parameters.AddWithValue("s_total", sale.totalPrice);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return 1;               
            }
            catch (System.Exception)
            {

                throw;
            }
        }


        #endregion
    }
}