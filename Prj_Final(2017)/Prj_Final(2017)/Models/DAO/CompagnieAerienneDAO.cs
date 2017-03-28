using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;

namespace Prj_Final_2017_.Models.DAO {
    public class TableDAO {

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
        private static readonly string INSERT_QUERY = "INSERT INTO tableBD(`champ1`, `champ2`, `champ3`, `champ4`, `champ5`) VALUES(@champ1, @champ2, @champ3, @champ4, @champ5)";
        private static readonly string READ_QUERY = "SELECT `champID`, `champ1`, `champ2`, `champ3`, `champ4`, `champ5` FROM tableBD WHERE `champID` = @champID";
        private static readonly string UPDATE_QUERY = "UPDATE tableBD SET `champ1` = @champ1, `champ2` = @champ2, `champ3` = @champ3, `champ4` = @champ4, `champ5` = @champ5 WHERE `champID` = @champID";
        private static readonly string DELETE_QUERY = "DELETE FROM tableBD WHERE `champID` = @champID";
        private static readonly string GET_ALL_QUERY = "SELECT `champID`, `champ1`, `champ2`, `champ3`, `champ4`, `champ5` FROM tableBD";

        public TableDAO() {
            connexion = new Connexion.Connexion();
        }

        /// <summary>
        /// Fait un Insert dans la BD sur la table tableBD
        /// </summary>
        /// <param name="tableDTO">tableBD a ajouter</param>
        public void Add(TableDTO tableDTO) {
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(TableDAO.INSERT_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("champ1", tableDTO.champ1);
                        command.Parameters.AddWithValue("champ2", tableDTO.champ2);
                        command.Parameters.AddWithValue("champ3", tableDTO.champ3);
                        command.Parameters.AddWithValue("champ4", tableDTO.champ4);
                        command.Parameters.AddWithValue("champ5", tableDTO.champ5);

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
        public TableDTO Read(int champID) {
            TableDTO tableDTO = null;
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(TableDAO.READ_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("champID", champID);
                        using (MySqlDataReader reader = command.ExecuteReader()) {
                            if (reader.Read()) {
                                tableDTO = new TableDTO();
                                tableDTO.champID = reader.GetString("champID");
                                tableDTO.champ2 = reader.GetString("champ1");
                                tableDTO.champ2 = reader.GetString("champ2");
                                tableDTO.champ3 = reader.GetString("champ3");
                                tableDTO.champ4 = reader.GetString("champ4");
                                tableDTO.champ5 = reader.GetString("champ5");
                            }
                        }
                    }
                }
            }
            catch (MySqlException mysqlException) {
                System.Diagnostics.Debug.WriteLine(mysqlException.Message);
            }
            return tableDTO;
        }

        /// <summary>
        /// Fait un Update dans la BD sur la table tableBD
        /// </summary>
        /// <param name="tableDTO">tableBD a modifier</param>
        public void Update(TableDTO tableDTO) {
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(TableDAO.UPDATE_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("champ1", tableDTO.champ1);
                        command.Parameters.AddWithValue("champ1", tableDTO.champ1);
                        command.Parameters.AddWithValue("champ2", tableDTO.champ2);
                        command.Parameters.AddWithValue("champ3", tableDTO.champ3);
                        command.Parameters.AddWithValue("champ4", tableDTO.champ4);
                        command.Parameters.AddWithValue("champID", tableDTO.champID);

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
        public void Delete(TableDTO tableDTO) {
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(TableDAO.DELETE_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("champID", tableDTO.champID);

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
                    using (MySqlCommand command = new MySqlCommand(TableDAO.GET_ALL_QUERY, connection)) {
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
