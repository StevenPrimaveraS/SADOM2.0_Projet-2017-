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
         * AgenceVoitureDAO = nom du dao de la table
         * AgenceVoitureDTO = nom du DTO de la table
         * agenceVoitureDTO = instance de AgenceVoitureDTO
         * AgenceVoiture = nom de la table dans la BD (requête)
         * IdAgenceVoiture = champ d'ID de la table
         * Nom = 1er champ de la table
         * Telephone = 2ième champ de la table
         * Adresse = 3ième champ de la table
         * Ville = 4ième champ de la table
         * Aeroport = 5ième champ de la table
         * 
         * (les nom de champ doivent être pareil dans la BD et la classe DTO)
         * 
         */


        Connexion.Connexion connexion;
        private static readonly string INSERT_QUERY = "INSERT INTO AgenceVoiture(`Nom`, `Telephone`, `Adresse`, `Ville`, `Aeroport`) VALUES(@Nom, @Telephone, @Adresse, @Ville, @Aeroport)";
        private static readonly string READ_QUERY = "SELECT `IdAgenceVoiture`, `Nom`, `Telephone`, `Adresse`, `Ville`, `Aeroport` FROM AgenceVoiture WHERE `IdAgenceVoiture` = @IdAgenceVoiture";
        private static readonly string UPDATE_QUERY = "UPDATE AgenceVoiture SET `Nom` = @Nom, `Telephone` = @Telephone, `Adresse` = @Adresse, `Ville` = @Ville, `Aeroport` = @Aeroport WHERE `IdAgenceVoiture` = @IdAgenceVoiture";
        private static readonly string DELETE_QUERY = "DELETE FROM AgenceVoiture WHERE `IdAgenceVoiture` = @IdAgenceVoiture";
        private static readonly string GET_ALL_QUERY = "SELECT `IdAgenceVoiture`, `Nom`, `Telephone`, `Adresse`, `Ville`, `Aeroport` FROM AgenceVoiture";

        public AgenceVoitureDAO() {
            connexion = new Connexion.Connexion();
        }

        /// <summary>
        /// Fait un Insert dans la BD sur la table AgenceVoiture
        /// </summary>
        /// <param name="agenceVoitureDTO">AgenceVoiture a ajouter</param>
        public void Add(AgenceVoitureDTO agenceVoitureDTO) {
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(AgenceVoitureDAO.INSERT_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("Nom", agenceVoitureDTO.Nom);
                        command.Parameters.AddWithValue("Telephone", agenceVoitureDTO.Telephone);
                        command.Parameters.AddWithValue("Adresse", agenceVoitureDTO.Adresse);
                        command.Parameters.AddWithValue("Ville", agenceVoitureDTO.Ville);
                        command.Parameters.AddWithValue("Aeroport", agenceVoitureDTO.Aeroport);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException mysqlException) {
                System.Diagnostics.Debug.WriteLine(mysqlException.Message);
            }
        }

        /// <summary>
        /// Fait un Read dans la BD sur la table AgenceVoiture
        /// </summary>
        /// <param name="IdAgenceVoiture">l'id de AgenceVoiture que l'on veut read</param>
        /// <returns>une instance de AgenceVoitureDTO; null sinon</returns>
        public AgenceVoitureDTO Read(int IdAgenceVoiture) {
            AgenceVoitureDTO agenceVoitureDTO = null;
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(AgenceVoitureDAO.READ_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("IdAgenceVoiture", IdAgenceVoiture);
                        using (MySqlDataReader reader = command.ExecuteReader()) {
                            if (reader.Read()) {
                                agenceVoitureDTO = new AgenceVoitureDTO();
                                agenceVoitureDTO.IdAgenceVoiture = reader.GetInt32("IdAgenceVoiture");
                                agenceVoitureDTO.Nom = reader.GetString("Nom");
                                agenceVoitureDTO.Telephone = reader.GetString("Telephone");
                                agenceVoitureDTO.Adresse = reader.GetString("Adresse");
                                agenceVoitureDTO.Ville = reader.GetString("Ville");
                                agenceVoitureDTO.Aeroport = reader.GetString("Aeroport");
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
        /// Fait un Update dans la BD sur la table AgenceVoiture
        /// </summary>
        /// <param name="agenceVoitureDTO">AgenceVoiture a modifier</param>
        public void Update(AgenceVoitureDTO agenceVoitureDTO) {
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(AgenceVoitureDAO.UPDATE_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("Nom", agenceVoitureDTO.Nom);
                        command.Parameters.AddWithValue("Telephone", agenceVoitureDTO.Telephone);
                        command.Parameters.AddWithValue("Adresse", agenceVoitureDTO.Adresse);
                        command.Parameters.AddWithValue("Ville", agenceVoitureDTO.Ville);
                        command.Parameters.AddWithValue("Aeroport", agenceVoitureDTO.Aeroport);
                        command.Parameters.AddWithValue("IdAgenceVoiture", agenceVoitureDTO.IdAgenceVoiture);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException mysqlException) {
                System.Diagnostics.Debug.WriteLine(mysqlException.Message);
            }
        }

        /// <summary>
        /// Fait un Delete dans la BD sur la table AgenceVoiture
        /// </summary>
        /// <param name="agenceVoitureDTO">AgenceVoiture a supprimer</param>
        public void Delete(AgenceVoitureDTO agenceVoitureDTO) {
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(AgenceVoitureDAO.DELETE_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("IdAgenceVoiture", agenceVoitureDTO.IdAgenceVoiture);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException mysqlException) {
                System.Diagnostics.Debug.WriteLine(mysqlException.Message);
            }
        }

        /// <summary>
        /// Retourne la liste de tous les AgenceVoitures de la table AgenceVoiture
        /// </summary>
        /// <returns>La liste de tous les AgenceVoitures; une liste vide sinon</returns>
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
