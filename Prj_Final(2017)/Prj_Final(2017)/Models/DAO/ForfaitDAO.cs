using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using Prj_Final_2017_.DTO;
using Prj_Final_2017_.Models.Exception;

namespace Prj_Final_2017_.Models.DAO {
    public class ForfaitDAO {

        /* **********************************
         * *** Pour ctrl + F rapidement : ***
         * **********************************
         * 
         * ForfaitDAO = nom du dao de la table
         * ForfaitDTO = nom du DTO de la table
         * forfaitDTO = instance de ForfaitDTO
         * Forfait = nom de la table dans la BD (requête)
         * IdForfait = champ d'ID de la table
         * IdChambre = 1er champ de la table
         * IdVoiture = 2ième champ de la table
         * IdSiege = 3ième champ de la table
         * TarifReduit = 4ième champ de la table
         * champ5 = 5ième champ de la table
         * 
         * (les nom de champ doivent être pareil dans la BD et la classe DTO)
         * 
         */


        Connexion.Connexion connexion;
        private static readonly string INSERT_QUERY = "INSERT INTO Forfait(`IdChambre`, `IdVoiture`, `IdSiege`, `TarifReduit`) VALUES(@IdChambre, @IdVoiture, @IdSiege, @TarifReduit)";
        private static readonly string READ_QUERY = "SELECT `IdForfait`, `IdChambre`, `IdVoiture`, `IdSiege`, `TarifReduit` FROM Forfait WHERE `IdForfait` = @IdForfait";
        private static readonly string UPDATE_QUERY = "UPDATE Forfait SET `IdChambre` = @IdChambre, `IdVoiture` = @IdVoiture, `IdSiege` = @IdSiege, `TarifReduit` = @TarifReduit WHERE `IdForfait` = @IdForfait";
        private static readonly string DELETE_QUERY = "DELETE FROM Forfait WHERE `IdForfait` = @IdForfait";
        private static readonly string GET_ALL_QUERY = "SELECT `IdForfait`, `IdChambre`, `IdVoiture`, `IdSiege`, `TarifReduit` FROM Forfait";

        public ForfaitDAO() {
            connexion = new Connexion.Connexion();
        }

        /// <summary>
        /// Fait un Insert dans la BD sur la table Forfait
        /// </summary>
        /// <param name="forfaitDTO">Forfait a ajouter</param>
        public void Add(ForfaitDTO forfaitDTO) {
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(ForfaitDAO.INSERT_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("IdChambre", forfaitDTO.IdChambre);
                        command.Parameters.AddWithValue("IdVoiture", forfaitDTO.IdVoiture);
                        command.Parameters.AddWithValue("IdSiege", forfaitDTO.IdSiege);
                        command.Parameters.AddWithValue("TarifReduit", forfaitDTO.TarifReduit);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException mysqlException) {
                throw new VoyageAhuntsicException(1,VoyageAhuntsicException.CharteErreur[1],mysqlException);
            }
        }

        /// <summary>
        /// Fait un Read dans la BD sur la table Forfait
        /// </summary>
        /// <param name="IdForfait">l'id de Forfait que l'on veut read</param>
        /// <returns>une instance de ForfaitDTO; null sinon</returns>
        public ForfaitDTO Read(int IdForfait) {
            ForfaitDTO forfaitDTO = null;
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(ForfaitDAO.READ_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("IdForfait", IdForfait);
                        using (MySqlDataReader reader = command.ExecuteReader()) {
                            if (reader.Read()) {
                                forfaitDTO = new ForfaitDTO();
                                forfaitDTO.IdForfait = reader.GetInt32("IdForfait");
                                forfaitDTO.IdChambre = reader.GetInt32("IdChambre");
                                forfaitDTO.IdVoiture = reader.GetInt32("IdVoiture");
                                forfaitDTO.IdSiege = reader.GetInt32("IdSiege");
                                forfaitDTO.TarifReduit = reader.GetDouble("TarifReduit");
                            }
                        }
                    }
                }
            }
            catch (MySqlException mysqlException) {
                throw new VoyageAhuntsicException(1,VoyageAhuntsicException.CharteErreur[1],mysqlException);
            }
            return forfaitDTO;
        }

        /// <summary>
        /// Fait un Update dans la BD sur la table Forfait
        /// </summary>
        /// <param name="forfaitDTO">Forfait a modifier</param>
        public void Update(ForfaitDTO forfaitDTO) {
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(ForfaitDAO.UPDATE_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("IdChambre", forfaitDTO.IdChambre);
                        command.Parameters.AddWithValue("IdVoiture", forfaitDTO.IdVoiture);
                        command.Parameters.AddWithValue("IdSiege", forfaitDTO.IdSiege);
                        command.Parameters.AddWithValue("TarifReduit", forfaitDTO.TarifReduit);
                        command.Parameters.AddWithValue("IdForfait", forfaitDTO.IdForfait);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException mysqlException) {
                throw new VoyageAhuntsicException(1,VoyageAhuntsicException.CharteErreur[1],mysqlException);
            }
        }

        /// <summary>
        /// Fait un Delete dans la BD sur la table Forfait
        /// </summary>
        /// <param name="forfaitDTO">Forfait a supprimer</param>
        public void Delete(ForfaitDTO forfaitDTO) {
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(ForfaitDAO.DELETE_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("IdForfait", forfaitDTO.IdForfait);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException mysqlException) {
                throw new VoyageAhuntsicException(1,VoyageAhuntsicException.CharteErreur[1],mysqlException);
            }
        }

        /// <summary>
        /// Retourne la liste de tous les Forfaits de la table Forfait
        /// </summary>
        /// <returns>La liste de tous les Forfaits; une liste vide sinon</returns>
        public DataSet GetAll() {
            DataSet dataset = null;
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(ForfaitDAO.GET_ALL_QUERY, connection)) {
                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                        dataset = new DataSet();
                        adapter.Fill(dataset);
                    }
                }
            }
            catch (MySqlException mysqlException) {
                throw new VoyageAhuntsicException(1,VoyageAhuntsicException.CharteErreur[1],mysqlException);
            }
            return dataset;
        }
    }
}
