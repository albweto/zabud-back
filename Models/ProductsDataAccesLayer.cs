using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace ZabudApi.Models {
    public class ProductsDataAccesLayer {
        string conection = "Server=localhost;Port=3306;Database=PruebaZabud;Uid=root;Pwd=Shenriquez10";

        public IEnumerable<Products> getAllProducts () {
            try {
                List<Products> listProducts = new List<Products> ();

                using (MySqlConnection con = new MySqlConnection (conection)) {
                    MySqlCommand cmd = new MySqlCommand ("sp_select_allProduct", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open ();

                    MySqlDataReader read = cmd.ExecuteReader ();

                    while (read.Read ()) {
                        Products products = new Products ();

                        products.ID = Convert.ToInt32 (read["id"]);
                        products.Price = Convert.ToInt32 (read["price"]);
                        products.name = read["product_name"].ToString ();
                        products.stock = Convert.ToInt32 (read["stock"]);

                        listProducts.Add (products);
                    }
                    con.Close ();
                }
                return listProducts;
            } catch (System.Exception) {

                throw;
            }
        }

        public int AddProducts (Products products) {
            try {
                using (MySqlConnection con = new MySqlConnection (conection)) {
                    MySqlCommand cmd = new MySqlCommand ("sp_insert_product ", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue ("p_price", products.Price);
                    cmd.Parameters.AddWithValue ("p_name", products.name);
                    cmd.Parameters.AddWithValue ("p_stock", products.stock);

                    con.Open ();
                    cmd.ExecuteNonQuery ();
                    con.Close ();
                }
                return 1;
            } catch (System.Exception) {

                throw;
            }
        }

        public int UpdateProduct (Products products) {
            try {
                using (MySqlConnection con = new MySqlConnection (conection)) {
                    MySqlCommand cmd = new MySqlCommand ("sp_update_product ", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue ("p_id", products.ID);
                    cmd.Parameters.AddWithValue ("p_stock", products.stock);
                    cmd.Parameters.AddWithValue ("p_name", products.name);
                    cmd.Parameters.AddWithValue ("p_price", products.Price);

                    con.Open ();
                    cmd.ExecuteNonQuery ();
                    con.Close ();
                }
                return 1;
            } catch (System.Exception) {

                throw;
            }
        }

        public Products getProductById (int id)

        {
            try {
                Products products = new Products ();

                using (MySqlConnection con = new MySqlConnection (conection)) {
                    MySqlCommand cmd = new MySqlCommand ("sp_select_productById ", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue ("p_id", id);
                    con.Open ();
                    MySqlDataReader read = cmd.ExecuteReader ();

                    while (read.Read ()) {
                        products.ID = Convert.ToInt32 (read["id"]);
                        products.Price = Convert.ToInt32 (read["price"]);
                        products.name = read["product_name"].ToString ();
                        products.stock = Convert.ToInt32 (read["stock"]);
                    }
                    con.Close ();
                }
                return products;
            } catch (System.Exception) {

                throw;
            }
        }

        public int DeleteProduct (int id) {
            try {
                using (MySqlConnection con = new MySqlConnection (conection)) {
                    MySqlCommand cmd = new MySqlCommand ("sp_product_delete", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue ("p_id", id);

                    con.Open ();
                    cmd.ExecuteNonQuery ();
                    con.Close ();
                }
                return 1;
            } catch (System.Exception) {

                throw;
            }
        }
    }
}