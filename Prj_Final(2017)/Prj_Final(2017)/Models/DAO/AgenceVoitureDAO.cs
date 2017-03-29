using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using Prj_Final_2017_.DTO;

namespace Prj_Final_2017_.Models.DAO {
    public class AgenceVoitureDAO {

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
        private static readonly string INSERT_QUERY = "INSERT INTO AgenceVoiture('Nom', 'Telephone', 'Adresse', 'Ville', 'Aeroport') VALUES (@champ1, @champ2, @champ3, @champ4, @champ5)";
        private static readonly string READ_QUERY = "SELECT 'IdAgenceVoiture', 'Nom', 'Telephone', 'Adresse', 'Ville', 'Aeroport' FROM AgenceVoiture WHERE 'IdAgenceVoiture' = @champID";
        private static readonly string UPDATE_QUERY = "UPDATE AgenceVoiture SET 'Nom' = @champ1, 'Telephone' = @champ2, 'Adresse' = @champ3, 'Ville' = @champ4, 'Aeroport' = @champ5 WHERE 'IdAgenceVoiture' = @champID";
        private static readonly string DELETE_QUERY = "DELETE FROM AgenceVoiture WHERE 'IdAgenceVoiture' = @champID";
        private static readonly string GET_ALL_QUERY = "SELECT 'IdAgenceVoiture', 'Nom', 'Telephone', 'Adresse', 'Ville', 'Aeroport' FROM AgenceVoiture";

        public AgenceVoitureDAO() {
            connexion = new Connexion.Connexion();
        }

        /// <summary>
        /// Fait un Insert dans la BD sur la table tableBD
        /// </summary>
        /// <param name="tableDTO">tableBD a ajouter</param>
        public void Add(AgenceVoitureDTO agenceVoitureDTO) {
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(AgenceVoitureDAO.INSERT_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("champ1", agenceVoitureDTO.Nom);
                        command.Parameters.AddWithValue("champ2", agenceVoitureDTO.Telephone);
                        command.Parameters.AddWithValue("champ3", agenceVoitureDTO.Adresse);
                        command.Parameters.AddWithValue("champ4", agenceVoitureDTO.Ville);
                        command.Parameters.AddWithValue("champ5", agenceVoitureDTO.Aeroport);

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
        public AgenceVoitureDTO Read(int champID) {
            AgenceVoitureDTO agenceVoitureDTO = null;
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(AgenceVoitureDAO.READ_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("champID", champID);
                        using (MySqlDataReader reader = command.ExecuteReader()) {
                            if (reader.Read()) {
                                agenceVoitureDTO = new AgenceVoitureDTO();
                                agenceVoitureDTO.IdAgenceVoiture = reader.GetString("champID");
                                agenceVoitureDTO.Nom = reader.GetString("champ1");
                                agenceVoitureDTO.Telephone = reader.GetString("champ2");
                                agenceVoitureDTO.Adresse = reader.GetString("champ3");
                                agenceVoitureDTO.Ville = reader.GetString("champ4");
                                agenceVoitureDTO.Aeroport = reader.GetString("champ5");
                            }
                        }
                    }
                }
            }
            catch (MySqlException mysqlException) {
                System.Diagnostics.Debug.WriteLine(mysqlException.Message);
            }
            return agenceVoitureDTO;
        }

        /// <summary>
        /// Fait un Update dans la BD sur la table tableBD
        /// </summary>
        /// <param name="tableDTO">tableBD a modifier</param>
        public void Update(AgenceVoitureDTO agenceVoitureDTO) {
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(AgenceVoitureDAO.UPDATE_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("champ1", agenceVoitureDTO.Nom);
                        command.Parameters.AddWithValue("champ2", agenceVoitureDTO.Telephone);
                        command.Parameters.AddWithValue("champ3", agenceVoitureDTO.Adresse);
                        command.Parameters.AddWithValue("champ4", agenceVoitureDTO.Ville);
                        command.Parameters.AddWithValue("champ5", agenceVoitureDTO.Aeroport);
                        command.Parameters.AddWithValue("champID", agenceVoitureDTO.IdAgenceVoiture);

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
        public void Delete(AgenceVoitureDTO agenceVoitureDTO) {
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(AgenceVoitureDAO.DELETE_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("champID", agenceVoitureDTO.IdAgenceVoiture);

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
                    using (MySqlCommand command = new MySqlCommand(AgenceVoitureDAO.GET_ALL_QUERY, connection)) {
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
