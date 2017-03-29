using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using Prj_Final_2017_.DTO;

namespace Prj_Final_2017_.Models.DAO {
    public class HotelDAO {

        /* **********************************
         * *** Pour ctrl + F rapidement : ***
         * **********************************
         * 
         * TableDAO = nom du dao de la table
         * TableDTO = nom du DTO de la table
         * tableDTO = instance de TableDTO
         * tableBD = nom de la table dans la BD (requête)
         * champID = champ d'ID de la table
         * champ1 = 1er champ de la table
         * champ2 = 2ième champ de la table
         * champ3 = 3ième champ de la table
         * champ4 = 4ième champ de la table
         * champ5 = 5ième champ de la table
         * 
         * (les nom de champ doivent être pareil dans la BD et la classe DTO)
         * 
         */


        Connexion.Connexion connexion;
        private static readonly string INSERT_QUERY = "INSERT INTO Hotel('Nom', 'Telephone', 'Adresse', 'Ville', 'Categorie', 'Description') VALUES(@champ1, @champ2, @champ3, @champ4, @champ5, @champ6)";
        private static readonly string READ_QUERY = "SELECT 'Nom', 'Telephone', 'Adresse', 'Ville', 'Categorie', 'Description' FROM Hotel WHERE `champID` = @champID";
        private static readonly string UPDATE_QUERY = "UPDATE Hotel SET 'Nom' = @champ1, 'Telephone' = @champ2, 'Adresse' = @champ3, 'Ville' = @champ4, 'Categorie' = @champ5, 'Description' = @champ6 WHERE 'IdHotel' = @champID";
        private static readonly string DELETE_QUERY = "DELETE FROM Hotel WHERE 'IdHotel' = @champID";
        private static readonly string GET_ALL_QUERY = "SELECT 'IdHotel', 'Nom', 'Telephone', 'Adresse', 'Ville', 'Categorie', 'Description' FROM Hotel";

        public HotelDAO() {
            connexion = new Connexion.Connexion();
        }

        /// <summary>
        /// Fait un Insert dans la BD sur la table tableBD
        /// </summary>
        /// <param name="tableDTO">tableBD a ajouter</param>
        public void Add(HotelDTO hotelDTO) {
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(HotelDAO.INSERT_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("champ1", hotelDTO.Nom);
                        command.Parameters.AddWithValue("champ2", hotelDTO.Telephone);
                        command.Parameters.AddWithValue("champ3", hotelDTO.Adresse);
                        command.Parameters.AddWithValue("champ4", hotelDTO.Ville);
                        command.Parameters.AddWithValue("champ5", hotelDTO.Categorie);
                        command.Parameters.AddWithValue("champ6", hotelDTO.Categorie);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException mysqlException) {
                System.Diagnostics.Debug.WriteLine(mysqlException.Message);
            }
        }

        /// <summary>
        /// Fait un Read dans la BD sur la table tableBD
        /// </summary>
        /// <param name="champID">l'id de tableBD que l'on veut read</param>
        /// <returns>une instance de TableDTO; null sinon</returns>
        public HotelDTO Read(int champID) {
            HotelDTO hotelDTO = null;
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(HotelDAO.READ_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("HotelID", champID);
                        using (MySqlDataReader reader = command.ExecuteReader()) {
                            if (reader.Read()) {
                                hotelDTO = new HotelDTO();
                                hotelDTO.IdHotel= reader.GetString("HotelID");
                                hotelDTO.Nom = reader.GetString("Nom");
                                hotelDTO.Telephone= reader.GetString("Telephone");
                                hotelDTO.Adresse = reader.GetString("Adresse");
                                hotelDTO.Ville = reader.GetString("Ville");
                                hotelDTO.Categorie = reader.GetString("Categorie");
                                hotelDTO.Description = reader.GetString("Description");
                            }
                        }
                    }
                }
            }
            catch (MySqlException mysqlException) {
                System.Diagnostics.Debug.WriteLine(mysqlException.Message);
            }
            return hotelDTO;
        }

        /// <summary>
        /// Fait un Update dans la BD sur la table tableBD
        /// </summary>
        /// <param name="tableDTO">tableBD a modifier</param>
        public void Update(HotelDTO hotelDTO) {
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(HotelDAO.UPDATE_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("champ1", hotelDTO.Nom);
                        command.Parameters.AddWithValue("champ2", hotelDTO.Telephone);
                        command.Parameters.AddWithValue("champ3", hotelDTO.Adresse);
                        command.Parameters.AddWithValue("champ4", hotelDTO.Ville);
                        command.Parameters.AddWithValue("champ5", hotelDTO.Categorie);
                        command.Parameters.AddWithValue("champ6", hotelDTO.Description);
                        command.Parameters.AddWithValue("champID", hotelDTO.IdHotel);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException mysqlException) {
                System.Diagnostics.Debug.WriteLine(mysqlException.Message);
            }
        }

        /// <summary>
        /// Fait un Delete dans la BD sur la table tableBD
        /// </summary>
        /// <param name="tableDTO">tableBD a supprimer</param>
        public void Delete(HotelDTO hotelDTO) {
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(HotelDAO.DELETE_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("champID", hotelDTO.IdHotel);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException mysqlException) {
                System.Diagnostics.Debug.WriteLine(mysqlException.Message);
            }
        }

        /// <summary>
        /// Retourne la liste de tous les tableBDs de la table tableBD
        /// </summary>
        /// <returns>La liste de tous les tableBDs; une liste vide sinon</returns>
        public DataSet GetAll() {
            DataSet dataset = null;
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(HotelDAO.GET_ALL_QUERY, connection)) {
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
