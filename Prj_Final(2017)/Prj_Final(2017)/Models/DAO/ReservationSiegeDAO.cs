using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using Prj_Final_2017_.DTO;
using Prj_Final_2017_.Models.Exception;

namespace Prj_Final_2017_.Models.DAO {
    public class ReservationSiegeDAO {

        /* **********************************
         * *** Pour ctrl + F rapidement : ***
         * **********************************
         * 
         * ReservationSiegeDAO = nom du dao de la table
         * ReservationSiegeDTO = nom du DTO de la table
         * reservationSiegeDTO = instance de ReservationSiegeDTO
         * ReservationSiege = nom de la table dans la BD (requête)
         * IdReservationSiege = champ d'ID de la table
         * IdSiege = 1er champ de la table
         * IdParticulier = 2ième champ de la table
         * DateReservation = 3ième champ de la table
         * DateFinReservation = 4ième champ de la table
         * champ5 = 5ième champ de la table
         * 
         * (les nom de champ doivent être pareil dans la BD et la classe DTO)
         * 
         */


        Connexion.Connexion connexion;
        private static readonly string INSERT_QUERY = "INSERT INTO ReservationSiege(`IdSiege`, `IdParticulier`, `DateReservation`, `DateFinReservation`) VALUES(@IdSiege, @IdParticulier, @DateReservation, @DateFinReservation)";
        private static readonly string READ_QUERY = "SELECT `IdReservationSiege`, `IdSiege`, `IdParticulier`, `DateReservation`, `DateFinReservation` FROM ReservationSiege WHERE `IdReservationSiege` = @IdReservationSiege";
        private static readonly string UPDATE_QUERY = "UPDATE ReservationSiege SET `IdSiege` = @IdSiege, `IdParticulier` = @IdParticulier, `DateReservation` = @DateReservation, `DateFinReservation` = @DateFinReservation WHERE `IdReservationSiege` = @IdReservationSiege";
        private static readonly string DELETE_QUERY = "DELETE FROM ReservationSiege WHERE `IdReservationSiege` = @IdReservationSiege";
        private static readonly string GET_ALL_QUERY = "SELECT `IdReservationSiege`, `IdSiege`, `IdParticulier`, `DateReservation`, `DateFinReservation` FROM ReservationSiege";

        public ReservationSiegeDAO() {
            connexion = new Connexion.Connexion();
        }

        /// <summary>
        /// Fait un Insert dans la BD sur la table ReservationSiege
        /// </summary>
        /// <param name="reservationSiegeDTO">ReservationSiege a ajouter</param>
        public void Add(ReservationSiegeDTO reservationSiegeDTO) {
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(ReservationSiegeDAO.INSERT_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("IdSiege", reservationSiegeDTO.IdSiege);
                        command.Parameters.AddWithValue("IdParticulier", reservationSiegeDTO.IdParticulier);
                        command.Parameters.AddWithValue("DateReservation", reservationSiegeDTO.DateReservation);
                        command.Parameters.AddWithValue("DateFinReservation", reservationSiegeDTO.DateFinReservation);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException mysqlException) {
                throw new VoyageAhuntsicException(1234,VoyageAhuntsicException.CharteErreur[1234],mysqlException);
            }
        }

        /// <summary>
        /// Fait un Read dans la BD sur la table ReservationSiege
        /// </summary>
        /// <param name="IdReservationSiege">l'id de ReservationSiege que l'on veut read</param>
        /// <returns>une instance de ReservationSiegeDTO; null sinon</returns>
        public ReservationSiegeDTO Read(int IdReservationSiege) {
            ReservationSiegeDTO reservationSiegeDTO = null;
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(ReservationSiegeDAO.READ_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("IdReservationSiege", IdReservationSiege);
                        using (MySqlDataReader reader = command.ExecuteReader()) {
                            if (reader.Read()) {
                                reservationSiegeDTO = new ReservationSiegeDTO();
                                reservationSiegeDTO.IdReservationSiege = reader.GetInt32("IdReservationSiege");
                                reservationSiegeDTO.IdSiege = reader.GetInt32("IdSiege");
                                reservationSiegeDTO.IdParticulier = reader.GetInt32("IdParticulier");
                                reservationSiegeDTO.DateReservation = reader.GetDateTime("DateReservation");
                                reservationSiegeDTO.DateFinReservation = reader.GetDateTime("DateFinReservation");
                            }
                        }
                    }
                }
            }
            catch (MySqlException mysqlException) {
                throw new VoyageAhuntsicException(1234,VoyageAhuntsicException.CharteErreur[1234],mysqlException);
            }
            return reservationSiegeDTO;
        }

        /// <summary>
        /// Fait un Update dans la BD sur la table ReservationSiege
        /// </summary>
        /// <param name="reservationSiegeDTO">ReservationSiege a modifier</param>
        public void Update(ReservationSiegeDTO reservationSiegeDTO) {
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(ReservationSiegeDAO.UPDATE_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("IdSiege", reservationSiegeDTO.IdSiege);
                        command.Parameters.AddWithValue("IdParticulier", reservationSiegeDTO.IdParticulier);
                        command.Parameters.AddWithValue("DateReservation", reservationSiegeDTO.DateReservation);
                        command.Parameters.AddWithValue("DateFinReservation", reservationSiegeDTO.DateFinReservation);
                        command.Parameters.AddWithValue("IdReservationSiege", reservationSiegeDTO.IdReservationSiege);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException mysqlException) {
                throw new VoyageAhuntsicException(1234,VoyageAhuntsicException.CharteErreur[1234],mysqlException);
            }
        }

        /// <summary>
        /// Fait un Delete dans la BD sur la table ReservationSiege
        /// </summary>
        /// <param name="reservationSiegeDTO">ReservationSiege a supprimer</param>
        public void Delete(ReservationSiegeDTO reservationSiegeDTO) {
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(ReservationSiegeDAO.DELETE_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("IdReservationSiege", reservationSiegeDTO.IdReservationSiege);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException mysqlException) {
                throw new VoyageAhuntsicException(1234,VoyageAhuntsicException.CharteErreur[1234],mysqlException);
            }
        }

        /// <summary>
        /// Retourne la liste de tous les ReservationSieges de la table ReservationSiege
        /// </summary>
        /// <returns>La liste de tous les ReservationSieges; une liste vide sinon</returns>
        public DataSet GetAll() {
            DataSet dataset = null;
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(ReservationSiegeDAO.GET_ALL_QUERY, connection)) {
                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                        dataset = new DataSet();
                        adapter.Fill(dataset);
                    }
                }
            }
            catch (MySqlException mysqlException) {
                throw new VoyageAhuntsicException(1234,VoyageAhuntsicException.CharteErreur[1234],mysqlException);
            }
            return dataset;
        }
    }
}
