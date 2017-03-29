using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using Prj_Final_2017_.DTO;
using Prj_Final_2017_.Models.DTO;

namespace Prj_Final_2017_.Models.DAO {
    public class CompagnieAerienneDAO {

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
        private static readonly string INSERT_QUERY = "INSERT INTO CompagnieAerienne('Nom', 'Telephone') VALUES(@champ1, @champ2)";
        private static readonly string READ_QUERY = "SELECT 'IdCompagnieAerienne', 'Nom', 'Telephone' FROM CompagnieAerienne WHERE 'IdCompagnieAerienne' = @champID";
        private static readonly string UPDATE_QUERY = "UPDATE CompagnieAerienne SET 'Nom' = @champ1, 'Telephone' = @champ2 WHERE 'IdCompagnieAerienne' = @champID";
        private static readonly string DELETE_QUERY = "DELETE FROM CompagnieAerienne WHERE 'IdCompagnieAerienne' = @champID";
        private static readonly string GET_ALL_QUERY = "SELECT 'IdCompagnieAerienne', 'Nom', 'Telephone' FROM CompagnieAerienne";

        public CompagnieAerienneDAO() {
            connexion = new Connexion.Connexion();
        }

        /// <summary>
        /// Fait un Insert dans la BD sur la table tableBD
        /// </summary>
        /// <param name="tableDTO">tableBD a ajouter</param>
        public void Add(CompagnieAerienneDTO compagnieAerienneDTO) {
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(CompagnieAerienneDAO.INSERT_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("champ1", compagnieAerienneDTO.Nom);
                        command.Parameters.AddWithValue("champ2", compagnieAerienneDTO.Telephone);
         
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
        public CompagnieAerienneDTO Read(int champID) {
            CompagnieAerienneDTO compagnieAerienneDTO = null;
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(CompagnieAerienneDAO.READ_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("champID", champID);
                        using (MySqlDataReader reader = command.ExecuteReader()) {
                            if (reader.Read()) {
                                compagnieAerienneDTO = new CompagnieAerienneDTO();
                                compagnieAerienneDTO.IdCompagnieAerienne = reader.GetString("champID");
                                compagnieAerienneDTO.Nom = reader.GetString("champ1");
                                compagnieAerienneDTO.Telephone = reader.GetString("champ2");
                            }
                        }
                    }
                }
            }
            catch (MySqlException mysqlException) {
                System.Diagnostics.Debug.WriteLine(mysqlException.Message);
            }
            return compagnieAerienneDTO;
        }

        /// <summary>
        /// Fait un Update dans la BD sur la table tableBD
        /// </summary>
        /// <param name="tableDTO">tableBD a modifier</param>
        public void Update(CompagnieAerienneDTO compagnieAerienneDTO) {
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(CompagnieAerienneDAO.UPDATE_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("champ1", compagnieAerienneDTO.Nom);
                        command.Parameters.AddWithValue("champ2", compagnieAerienneDTO.Telephone);
                        command.Parameters.AddWithValue("champID", compagnieAerienneDTO.IdCompagnieAerienne);

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
        public void Delete(CompagnieAerienneDTO compagnieAerienneDTO) {
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(CompagnieAerienneDAO.DELETE_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("champID", compagnieAerienneDTO.IdCompagnieAerienne);

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
                    using (MySqlCommand command = new MySqlCommand(CompagnieAerienneDAO.GET_ALL_QUERY, connection)) {
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
