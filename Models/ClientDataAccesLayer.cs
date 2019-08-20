using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using MySql.Data.MySqlClient;
using ZabudApi.Models;

namespace ZabudApi.Models {
    public class ClientDataAccesLayer {
        string conection = "Server=localhost;Port=3306;Database=PruebaZabud;Uid=root;Pwd=Shenriquez10";

        public IEnumerable<Client> getAll () {
            try {
                List<Client> listClients = new List<Client> ();
                using (MySqlConnection con = new MySqlConnection (conection)) {
                    MySqlCommand cmd = new MySqlCommand ("select_allClient", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open ();

                    MySqlDataReader read = cmd.ExecuteReader ();

                    while (read.Read ()) {
                        Client client = new Client ();

                        client.ID = Convert.ToInt32 (read["id"]);
                        client.Document = Convert.ToInt32 (read["docuemnt"]);
                        client.clientName = read["client_name"].ToString ();
                        client.clientLastName = read["client_lastname"].ToString ();
                        client.username = read["username"].ToString ();
                        client.password = read["password"].ToString ();
                        client.email = read["email"].ToString ();

                        listClients.Add (client);
                    }
                    con.Close ();
                }
                return listClients;

            } catch (System.Exception) {

                throw;
            }
        }

        public int AddClient (Client client) {
            try {
                using (MySqlConnection connect = new MySqlConnection (conection)) {
                    MySqlCommand cmd = new MySqlCommand ("insert_client", connect);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue ("c_document", client.Document);
                    cmd.Parameters.AddWithValue ("c_name", client.clientName);
                    cmd.Parameters.AddWithValue ("c_lastname", client.clientLastName);
                    cmd.Parameters.AddWithValue ("c_username", client.username);
                    cmd.Parameters.AddWithValue ("c_password", client.password);
                    cmd.Parameters.AddWithValue ("c_email", client.email);

                    connect.Open ();
                    cmd.ExecuteNonQuery ();
                    connect.Close ();

                }
                return 1;
            } catch (System.Exception) {

                throw;
            }
        }

        public int UpdateClient (Client client) {
            try {
                using (MySqlConnection connect = new MySqlConnection (conection)) {
                    MySqlCommand cmd = new MySqlCommand ("update_client", connect);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue ("c_id", client.ID);
                    cmd.Parameters.AddWithValue ("c_document", client.Document);
                    cmd.Parameters.AddWithValue ("c_name", client.clientName);
                    cmd.Parameters.AddWithValue ("c_lastname", client.clientLastName);
                    cmd.Parameters.AddWithValue ("c_username", client.username);
                    cmd.Parameters.AddWithValue ("c_password", ToSHA256(client.password));
                    cmd.Parameters.AddWithValue ("c_email", client.email);

                    connect.Open ();
                    cmd.ExecuteNonQuery ();
                    connect.Close ();

                }
                return 1;
            } catch (System.Exception) {

                throw;
            }
        }

        public Client GetClientsAll (int id) {
            try {
                Client client = new Client ();

                using (MySqlConnection conect = new MySqlConnection (conection)) {
                    MySqlCommand cmd = new MySqlCommand ("select_clientById", conect);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue ("c_id", id);
                    conect.Open ();
                    MySqlDataReader read = cmd.ExecuteReader ();

                    while (read.Read ()) {
                        client.ID = Convert.ToInt32 (read["id"]);
                        client.Document = Convert.ToInt32 (read["docuemnt"]);
                        client.clientName = read["client_name"].ToString ();
                        client.clientLastName = read["client_lastname"].ToString ();
                        client.username = read["username"].ToString ();
                        client.username = read["password"].ToString ();
                        client.email = read["email"].ToString ();

                    }
                    conect.Close ();
                }
                return client;
            } catch (System.Exception) {

                throw;
            }
        }

        public int DeleteClient (int id) {
            try {
                using (MySqlConnection connect = new MySqlConnection (conection)) {
                    MySqlCommand cmd = new MySqlCommand ("delete_client", connect);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue ("c_id", id);

                    connect.Open ();
                    cmd.ExecuteNonQuery ();
                    connect.Close ();
                }
                return 1;
            } catch (System.Exception) {

                throw;
            }
        }

        public string ToSHA256 (string value) {
            SHA256 sha256 = SHA256.Create ();

            byte[] hashData = sha256.ComputeHash (Encoding.Default.GetBytes (value));
            StringBuilder returnValue = new StringBuilder ();

            for (int i = 0; i < hashData.Length; i++) {
                returnValue.Append (hashData[i].ToString ());
            }

            return returnValue.ToString ();
        }
    }
}