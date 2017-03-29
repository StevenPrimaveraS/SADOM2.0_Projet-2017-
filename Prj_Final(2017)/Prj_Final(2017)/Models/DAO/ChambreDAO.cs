using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using Prj_Final_2017_.DTO;

namespace Prj_Final_2017_.Models.DAO {
    public class ChambreDAO {

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
        private static readonly string INSERT_QUERY = "INSERT INTO Chambre('NumeroChambre','NomChambre', 'Tarif', 'MaxPersonne', 'Taille', 'Description', 'IdHotel') VALUES(@champ1, @champ2, @champ3, @champ4, @champ5, @champ6, @champ7)";
        private static readonly string READ_QUERY = "SELECT 'IdChambre','NumeroChambre', 'NomChambre', 'Tarif', 'MaxPersonne', 'Taille', 'Description', 'IdHotel' FROM Chambre WHERE 'IdChambre' = @champID";
        private static readonly string UPDATE_QUERY = "UPDATE Chambre SET 'NumeroChambre' = @champ1, 'NomChambre' = @champ2, 'Tarif' = @champ3, 'MaxPersonne' = @champ4, 'Taille' = @champ5, 'Description' = @champ6, 'IdHotel = @champ7' WHERE 'IdChambre' = @champID";
        private static readonly string DELETE_QUERY = "DELETE FROM Chambre WHERE 'IdChambre' = @champID";
        private static readonly string GET_ALL_QUERY = "SELECT 'IdChambre', 'NumeroChambre', 'NomChambre', 'Tarif', 'MaxPersonne', 'Taille', 'Description', 'IdHotel' FROM Chambre";

        public ChambreDAO() {
            connexion = new Connexion.Connexion();
        }

        /// <summary>
        /// Fait un Insert dans la BD sur la table tableBD
        /// </summary>
        /// <param name="tableDTO">tableBD a ajouter</param>
        public void Add(ChambreDTO chambreDTO) {
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(ChambreDAO.INSERT_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("champ1", chambreDTO.NumeroChambre);
                        command.Parameters.AddWithValue("champ2", chambreDTO.NomChambre);
                        command.Parameters.AddWithValue("champ3", chambreDTO.Tarif);
                        command.Parameters.AddWithValue("champ4", chambreDTO.MaxPersonne);
                        command.Parameters.AddWithValue("champ5", chambreDTO.Taille);
                        command.Parameters.AddWithValue("champ6", chambreDTO.Description);
                        command.Parameters.AddWithValue("champ7", chambreDTO.IdHotel);

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
        public ChambreDTO Read(int champID) {
            ChambreDTO chambreDTO = null;
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(ChambreDAO.READ_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("champID", champID);
                        using (MySqlDataReader reader = command.ExecuteReader()) {
                            if (reader.Read()) {
                                chambreDTO= new ChambreDTO();
                                chambreDTO.IdChambre= reader.GetString("champID");
                                chambreDTO.NumeroChambre = reader.GetString("champ1");
                                chambreDTO.NomChambre = reader.GetString("champ2");
                                chambreDTO.Tarif = reader.GetString("champ3");
                                chambreDTO.MaxPersonne = reader.GetString("champ4");
                                chambreDTO.Taille = reader.GetString("champ5");
                                chambreDTO.Description = reader.GetString("champ6");
                                chambreDTO.IdHotel = reader.GetString("champ7");
                            }
                        }
                    }
                }
            }
            catch (MySqlException mysqlException) {
                System.Diagnostics.Debug.WriteLine(mysqlException.Message);
            }
            return chambreDTO;
        }

        /// <summary>
        /// Fait un Update dans la BD sur la table tableBD
        /// </summary>
        /// <param name="tableDTO">tableBD a modifier</param>
        public void Update(ChambreDTO chambreDTO) {
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(ChambreDAO.UPDATE_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("champ1", chambreDTO.NumeroChambre);
                        command.Parameters.AddWithValue("champ2", chambreDTO.NomChambre);
                        command.Parameters.AddWithValue("champ3", chambreDTO.Tarif);
                        command.Parameters.AddWithValue("champ4", chambreDTO.MaxPersonne);
                        command.Parameters.AddWithValue("champ5", chambreDTO.Taille);
                        command.Parameters.AddWithValue("champ6", chambreDTO.Description);
                        command.Parameters.AddWithValue("champ7", chambreDTO.IdHotel);
                        command.Parameters.AddWithValue("champID", chambreDTO.IdChambre);

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
        public void Delete(ChambreDTO chambreDTO) {
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(ChambreDAO.DELETE_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("champID", chambreDTO.IdChambre);

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
                    using (MySqlCommand command = new MySqlCommand(ChambreDAO.GET_ALL_QUERY, connection)) {
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
