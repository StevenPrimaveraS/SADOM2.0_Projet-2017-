using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using Prj_Final_2017_.DTO;

namespace Prj_Final_2017_.Models.DAO {
    public class VoitureDAO {

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
        private static readonly string INSERT_QUERY = "INSERT INTO Voiture('Type', 'IdAgence', 'Tarif', 'nbPassager', 'Nom', 'Plaque') VALUES(@champ1, @champ2, @champ3, @champ4, @champ5, @champ6)";
        private static readonly string READ_QUERY = "SELECT 'IdVoiture', 'Type', 'IdAgence', 'Tarif', 'nbPassager', 'Nom', 'Plaque' FROM Voiture WHERE 'IdVoiture' = @champID";
        private static readonly string UPDATE_QUERY = "UPDATE Voiture SET 'Type' = @champ1, 'IdAgence' = @champ2, 'Tarif' = @champ3, 'nbPassager' = @champ4, 'Nom' = @champ5, 'Plaque' = @champ6 WHERE 'IdVoiture' = @champID";
        private static readonly string DELETE_QUERY = "DELETE FROM Voiture WHERE 'IdVoiture' = @champID";
        private static readonly string GET_ALL_QUERY = "SELECT 'IdVoiture', 'Type', 'IdAgence', 'Tarif', 'nbPassager', 'Nom', 'Plaque' FROM Voiture";

        public VoitureDAO() {
            connexion = new Connexion.Connexion();
        }

        /// <summary>
        /// Fait un Insert dans la BD sur la table tableBD
        /// </summary>
        /// <param name="tableDTO">tableBD a ajouter</param>
        public void Add(VoitureDTO voitureDTO) {
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(VoitureDAO.INSERT_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("champ1", voitureDTO.Type);
                        command.Parameters.AddWithValue("champ2", voitureDTO.IdAgence);
                        command.Parameters.AddWithValue("champ3", voitureDTO.Tarif);
                        command.Parameters.AddWithValue("champ4", voitureDTO.Nbpassager);
                        command.Parameters.AddWithValue("champ5", voitureDTO.Nom);
                        command.Parameters.AddWithValue("champ6", voitureDTO.Plaque);

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
        public VoitureDTO Read(int champID) {
            VoitureDTO voitureDTO = null;
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(VoitureDAO.READ_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("champID", champID);
                        using (MySqlDataReader reader = command.ExecuteReader()) {
                            if (reader.Read()) {
                                voitureDTO= new VoitureDTO();
                                voitureDTO.IdVoiture= reader.GetString("champID");
                                voitureDTO.Type = reader.GetString("champ1");
                                voitureDTO.IdAgence = reader.GetString("champ2");
                                voitureDTO.Tarif = reader.GetString("champ3");
                                voitureDTO.Nbpassager = reader.GetString("champ4");
                                voitureDTO.Nom = reader.GetString("champ5");
                                voitureDTO.Plaque = reader.GetString("champ6");
                            }
                        }
                    }
                }
            }
            catch (MySqlException mysqlException) {
                System.Diagnostics.Debug.WriteLine(mysqlException.Message);
            }
            return voitureDTO;
        }

        /// <summary>
        /// Fait un Update dans la BD sur la table tableBD
        /// </summary>
        /// <param name="tableDTO">tableBD a modifier</param>
        public void Update(VoitureDTO voitureDTO) {
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(VoitureDAO.UPDATE_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("champ1", voitureDTO.Type);
                        command.Parameters.AddWithValue("champ2", voitureDTO.IdAgence);
                        command.Parameters.AddWithValue("champ3", voitureDTO.Tarif);
                        command.Parameters.AddWithValue("champ4", voitureDTO.Nbpassager);
                        command.Parameters.AddWithValue("champ5", voitureDTO.Nom);
                        command.Parameters.AddWithValue("champ6", voitureDTO.Plaque);
                        command.Parameters.AddWithValue("champID", voitureDTO.IdVoiture);

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
        public void Delete(VoitureDTO voitureDTO) {
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(VoitureDAO.DELETE_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("champID", voitureDTO.IdVoiture);

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
                    using (MySqlCommand command = new MySqlCommand(VoitureDAO.GET_ALL_QUERY, connection)) {
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
