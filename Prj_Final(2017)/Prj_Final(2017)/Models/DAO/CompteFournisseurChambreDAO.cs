using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using Prj_Final_2017_.DTO;

namespace Prj_Final_2017_.Models.DAO {
    public class CompteFournisseurChambreDAO {

        /* **********************************
         * *** Pour ctrl + F rapidement : ***
         * **********************************
         * 
         * CompteFournisseurChambreDAO = nom du dao de la table
         * CompteFournisseurChambreDTO = nom du DTO de la table
         * compteFournisseurChambreDTO = instance de CompteFournisseurChambreDTO
         * CompteFournisseurChambre = nom de la table dans la BD (requête)
         * IdFournisseur = champ d'ID de la table
         * Courriel = 1er champ de la table
         * Password = 2ième champ de la table
         * IdHotel = 3ième champ de la table
         * 
         * (les nom de champ doivent être pareil dans la BD et la classe DTO)
         * 
         */


        Connexion.Connexion connexion;
        private static readonly string INSERT_QUERY = "INSERT INTO CompteFournisseurChambre(`Courriel`, `Password`, `IdHotel`) VALUES(@Courriel, @Password, @IdHotel)";
        private static readonly string READ_QUERY = "SELECT `IdFournisseur`, `Courriel`, `Password`, `IdHotel` FROM CompteFournisseurChambre WHERE `IdFournisseur` = @IdFournisseur";
        private static readonly string UPDATE_QUERY = "UPDATE CompteFournisseurChambre SET `Courriel` = @Courriel, `Password` = @Password, `IdHotel` = @IdHotel WHERE `IdFournisseur` = @IdFournisseur";
        private static readonly string DELETE_QUERY = "DELETE FROM CompteFournisseurChambre WHERE `IdFournisseur` = @IdFournisseur";
        private static readonly string GET_ALL_QUERY = "SELECT `IdFournisseur`, `Courriel`, `Password`, `IdHotel` FROM CompteFournisseurChambre";

        public CompteFournisseurChambreDAO() {
            connexion = new Connexion.Connexion();
        }

        /// <summary>
        /// Fait un Insert dans la BD sur la table CompteFournisseurChambre
        /// </summary>
        /// <param name="compteFournisseurChambreDTO">CompteFournisseurChambre a ajouter</param>
        public void Add(CompteFournisseurChambreDTO compteFournisseurChambreDTO) {
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(CompteFournisseurChambreDAO.INSERT_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("Courriel", compteFournisseurChambreDTO.Courriel);
                        command.Parameters.AddWithValue("Password", compteFournisseurChambreDTO.Password);
                        command.Parameters.AddWithValue("IdHotel", compteFournisseurChambreDTO.IdHotel);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException mysqlException) {
                System.Diagnostics.Debug.WriteLine(mysqlException.Message);
            }
        }

        /// <summary>
        /// Fait un Read dans la BD sur la table CompteFournisseurChambre
        /// </summary>
        /// <param name="IdFournisseur">l'id de CompteFournisseurChambre que l'on veut read</param>
        /// <returns>une instance de CompteFournisseurChambreDTO; null sinon</returns>
        public CompteFournisseurChambreDTO Read(int IdFournisseur) {
            CompteFournisseurChambreDTO compteFournisseurChambreDTO = null;
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(CompteFournisseurChambreDAO.READ_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("IdFournisseur", IdFournisseur);
                        using (MySqlDataReader reader = command.ExecuteReader()) {
                            if (reader.Read()) {
                                compteFournisseurChambreDTO = new CompteFournisseurChambreDTO();
                                compteFournisseurChambreDTO.IdFournisseur = reader.GetInt32("IdFournisseur");
                                compteFournisseurChambreDTO.Courriel = reader.GetString("Courriel");
                                compteFournisseurChambreDTO.Password = reader.GetString("Password");
                                compteFournisseurChambreDTO.IdHotel = reader.GetInt32("IdHotel");
                            }
                        }
                    }
                }
            }
            catch (MySqlException mysqlException) {
                System.Diagnostics.Debug.WriteLine(mysqlException.Message);
            }
            return compteFournisseurChambreDTO;
        }

        /// <summary>
        /// Fait un Update dans la BD sur la table CompteFournisseurChambre
        /// </summary>
        /// <param name="compteFournisseurChambreDTO">CompteFournisseurChambre a modifier</param>
        public void Update(CompteFournisseurChambreDTO compteFournisseurChambreDTO) {
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(CompteFournisseurChambreDAO.UPDATE_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("Courriel", compteFournisseurChambreDTO.Courriel);
                        command.Parameters.AddWithValue("Password", compteFournisseurChambreDTO.Password);
                        command.Parameters.AddWithValue("IdHotel", compteFournisseurChambreDTO.IdHotel);
                        command.Parameters.AddWithValue("IdFournisseur", compteFournisseurChambreDTO.IdFournisseur);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException mysqlException) {
                System.Diagnostics.Debug.WriteLine(mysqlException.Message);
            }
        }

        /// <summary>
        /// Fait un Delete dans la BD sur la table CompteFournisseurChambre
        /// </summary>
        /// <param name="compteFournisseurChambreDTO">CompteFournisseurChambre a supprimer</param>
        public void Delete(CompteFournisseurChambreDTO compteFournisseurChambreDTO) {
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(CompteFournisseurChambreDAO.DELETE_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("IdFournisseur", compteFournisseurChambreDTO.IdFournisseur);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException mysqlException) {
                System.Diagnostics.Debug.WriteLine(mysqlException.Message);
            }
        }

        /// <summary>
        /// Retourne la liste de tous les CompteFournisseurChambres de la table CompteFournisseurChambre
        /// </summary>
        /// <returns>La liste de tous les CompteFournisseurChambres; une liste vide sinon</returns>
        public DataSet GetAll() {
            DataSet dataset = null;
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(CompteFournisseurChambreDAO.GET_ALL_QUERY, connection)) {
                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                        dataset = new DataSet();
                        adapter.Fill(dataset);
                    }
                }
            }
            catch (MySqlException mysqlException) {
                System.Diagnostics.Debug.WriteLine(mysqlException.Message);
            }
            return dataset;
        }
    }
}
