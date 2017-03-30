using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Prj_Final_2017_.Models.Connexion {
    public class Connexion {

            MySqlConnection connexion;
            public Connexion() {
                CreateConnexion();
            }
            private void CreateConnexion() {
                try {
                string ConnexionString = ConfigurationManager.ConnectionStrings["mysqlConnexionString"].ConnectionString;
                    MySqlConnection Connexion = new MySqlConnection(ConnexionString);
                    setConnexion(Connexion);
                }
                catch (MySqlException sqlException) {
                    Console.WriteLine(sqlException.Message);
                }
            }
            public void Open() {
                getConnexion().Open();
            }
            public void Close() {
                getConnexion().Close();
            }
            public void setConnexion(MySqlConnection Connexion) {
                this.connexion = Connexion;
            }
            public MySqlConnection getConnexion() {
                return this.connexion;
            }
        
    }
}