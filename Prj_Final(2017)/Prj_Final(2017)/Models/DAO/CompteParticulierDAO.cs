using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using Prj_Final_2017_.DTO;

namespace Prj_Final_2017_.Models.DAO {
    public class CompteParticulierDAO {

        /* **********************************
         * *** Pour ctrl + F rapidement : ***
         * **********************************
         * 
         * CompteParticulierDAO = nom du dao de la table
         * CompteParticulierDTO = nom du DTO de la table
         * compteParticulierDTO = instance de CompteParticulierDTO
         * CompteParticulier = nom de la table dans la BD (requête)
         * IdParticulier = champ d'ID de la table
         * Password = 1er champ de la table
         * Prenom = 2ième champ de la table
         * Nom = 3ième champ de la table
         * Courriel = 4ième champ de la table
         * champ5 = 5ième champ de la table
         * 
         * (les nom de champ doivent être pareil dans la BD et la classe DTO)
         * 
         */


        Connexion.Connexion connexion;
        private static readonly string INSERT_QUERY = "INSERT INTO CompteParticulier(`Password`, `Prenom`, `Nom`, `Courriel`, `champ5`) VALUES(@Password, @Prenom, @Nom, @Courriel, @champ5)";
        private static readonly string READ_QUERY = "SELECT `IdParticulier`, `Password`, `Prenom`, `Nom`, `Courriel`, `champ5` FROM CompteParticulier WHERE `IdParticulier` = @IdParticulier";
        private static readonly string UPDATE_QUERY = "UPDATE CompteParticulier SET `Password` = @Password, `Prenom` = @Prenom, `Nom` = @Nom, `Courriel` = @Courriel, `champ5` = @champ5 WHERE `IdParticulier` = @IdParticulier";
        private static readonly string DELETE_QUERY = "DELETE FROM CompteParticulier WHERE `IdParticulier` = @IdParticulier";
        private static readonly string GET_ALL_QUERY = "SELECT `IdParticulier`, `Password`, `Prenom`, `Nom`, `Courriel`, `champ5` FROM CompteParticulier";

        public CompteParticulierDAO() {
            connexion = new Connexion.Connexion();
        }

        /// <summary>
        /// Fait un Insert dans la BD sur la table CompteParticulier
        /// </summary>
        /// <param name="compteParticulierDTO">CompteParticulier a ajouter</param>
        public void Add(CompteParticulierDTO compteParticulierDTO) {
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(CompteParticulierDAO.INSERT_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("Password", compteParticulierDTO.Password);
                        command.Parameters.AddWithValue("Prenom", compteParticulierDTO.Prenom);
                        command.Parameters.AddWithValue("Nom", compteParticulierDTO.Nom);
                        command.Parameters.AddWithValue("Courriel", compteParticulierDTO.Courriel);
                        command.Parameters.AddWithValue("champ5", compteParticulierDTO.champ5);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException mysqlException) {
                System.Diagnostics.Debug.WriteLine(mysqlException.Message);
            }
        }

        /// <summary>
        /// Fait un Read dans la BD sur la table CompteParticulier
        /// </summary>
        /// <param name="IdParticulier">l'id de CompteParticulier que l'on veut read</param>
        /// <returns>une instance de CompteParticulierDTO; null sinon</returns>
        public CompteParticulierDTO Read(int IdParticulier) {
            CompteParticulierDTO compteParticulierDTO = null;
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(CompteParticulierDAO.READ_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("IdParticulier", IdParticulier);
                        using (MySqlDataReader reader = command.ExecuteReader()) {
                            if (reader.Read()) {
                                compteParticulierDTO = new CompteParticulierDTO();
                                compteParticulierDTO.IdParticulier = reader.GetString("IdParticulier");
                                compteParticulierDTO.Password = reader.GetString("Password");
                                compteParticulierDTO.Prenom = reader.GetString("Prenom");
                                compteParticulierDTO.Nom = reader.GetString("Nom");
                                compteParticulierDTO.Courriel = reader.GetString("Courriel");
                                compteParticulierDTO.champ5 = reader.GetString("champ5");
                            }
                        }
                    }
                }
            }
            catch (MySqlException mysqlException) {
                System.Diagnostics.Debug.WriteLine(mysqlException.Message);
            }
            return compteParticulierDTO;
        }

        /// <summary>
        /// Fait un Update dans la BD sur la table CompteParticulier
        /// </summary>
        /// <param name="compteParticulierDTO">CompteParticulier a modifier</param>
        public void Update(CompteParticulierDTO compteParticulierDTO) {
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(CompteParticulierDAO.UPDATE_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("Password", compteParticulierDTO.Password);
                        command.Parameters.AddWithValue("Prenom", compteParticulierDTO.Prenom);
                        command.Parameters.AddWithValue("Nom", compteParticulierDTO.Nom);
                        command.Parameters.AddWithValue("Courriel", compteParticulierDTO.Courriel);
                        command.Parameters.AddWithValue("champ5", compteParticulierDTO.champ5);
                        command.Parameters.AddWithValue("IdParticulier", compteParticulierDTO.IdParticulier);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException mysqlException) {
                System.Diagnostics.Debug.WriteLine(mysqlException.Message);
            }
        }

        /// <summary>
        /// Fait un Delete dans la BD sur la table CompteParticulier
        /// </summary>
        /// <param name="compteParticulierDTO">CompteParticulier a supprimer</param>
        public void Delete(CompteParticulierDTO compteParticulierDTO) {
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(CompteParticulierDAO.DELETE_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("IdParticulier", compteParticulierDTO.IdParticulier);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException mysqlException) {
                System.Diagnostics.Debug.WriteLine(mysqlException.Message);
            }
        }

        /// <summary>
        /// Retourne la liste de tous les CompteParticuliers de la table CompteParticulier
        /// </summary>
        /// <returns>La liste de tous les CompteParticuliers; une liste vide sinon</returns>
        public DataSet GetAll() {
            DataSet dataset = null;
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(CompteParticulierDAO.GET_ALL_QUERY, connection)) {
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
