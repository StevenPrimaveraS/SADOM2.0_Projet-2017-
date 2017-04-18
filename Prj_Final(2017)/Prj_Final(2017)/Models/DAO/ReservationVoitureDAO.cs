using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using Prj_Final_2017_.DTO;
using Prj_Final_2017_.Models.Exception;
using Prj_Final_2017_.Models.util;

namespace Prj_Final_2017_.Models.DAO {
    public class ReservationVoitureDAO {

        /* **********************************
         * *** Pour ctrl + F rapidement : ***
         * **********************************
         * 
         * ReservationVoitureDAO = nom du dao de la table
         * ReservationVoitureDTO = nom du DTO de la table
         * reservationVoitureDTO = instance de ReservationVoitureDTO
         * ReservationVoiture = nom de la table dans la BD (requête)
         * IdReservationVoiture = champ d'ID de la table
         * IdVoiture = 1er champ de la table
         * IdParticulier = 2ième champ de la table
         * DateReservation = 3ième champ de la table
         * DateFinReservation = 4ième champ de la table
         * champ5 = 5ième champ de la table
         * 
         * (les nom de champ doivent être pareil dans la BD et la classe DTO)
         * 
         */


        Connexion.Connexion connexion;
        private static readonly string INSERT_QUERY = "INSERT INTO ReservationVoiture(`IdVoiture`, `IdParticulier`, `DateReservation`, `DateFinReservation`) VALUES(@IdVoiture, @IdParticulier, @DateReservation, @DateFinReservation)";
        private static readonly string READ_QUERY = "SELECT `IdReservationVoiture`, `IdVoiture`, `IdParticulier`, `DateReservation`, `DateFinReservation` FROM ReservationVoiture WHERE `IdReservationVoiture` = @IdReservationVoiture";
        private static readonly string UPDATE_QUERY = "UPDATE ReservationVoiture SET `IdVoiture` = @IdVoiture, `IdParticulier` = @IdParticulier, `DateReservation` = @DateReservation, `DateFinReservation` = @DateFinReservation WHERE `IdReservationVoiture` = @IdReservationVoiture";
        private static readonly string DELETE_QUERY = "DELETE FROM ReservationVoiture WHERE `IdReservationVoiture` = @IdReservationVoiture";
        private static readonly string GET_ALL_QUERY = "SELECT `IdReservationVoiture`, `IdVoiture`, `IdParticulier`, `DateReservation`, `DateFinReservation` FROM ReservationVoiture";
        private static readonly string FIND_BY_DATE_AND_VOITURE_QUERY = "SELECT `IdReservationVoiture`, `IdVoiture`, `IdParticulier`, `DateReservation`, `DateFinReservation` FROM ReservationVoiture WHERE ((`DateReservation` BETWEEN @DateReservation1 AND @DateFinReservation1) OR (`DateFinReservation` BETWEEN @DateReservation2 AND @DateFinReservation2)) AND `IdVoiture` = @IdVoiture";


        public ReservationVoitureDAO() {
            connexion = new Connexion.Connexion();
        }

        /// <summary>
        /// Fait un Insert dans la BD sur la table ReservationVoiture
        /// </summary>
        /// <param name="reservationVoitureDTO">ReservationVoiture a ajouter</param>
        public void Add(ReservationVoitureDTO reservationVoitureDTO) {
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(ReservationVoitureDAO.INSERT_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("IdVoiture", reservationVoitureDTO.IdVoiture);
                        command.Parameters.AddWithValue("IdParticulier", reservationVoitureDTO.IdParticulier);
                        command.Parameters.AddWithValue("DateReservation", reservationVoitureDTO.DateReservation);
                        command.Parameters.AddWithValue("DateFinReservation", reservationVoitureDTO.DateFinReservation);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException mysqlException) {
                throw new VoyageAhuntsicException(1,VoyageAhuntsicException.CharteErreur[1],mysqlException);
            }
        }

        /// <summary>
        /// Fait un Read dans la BD sur la table ReservationVoiture
        /// </summary>
        /// <param name="IdReservationVoiture">l'id de ReservationVoiture que l'on veut read</param>
        /// <returns>une instance de ReservationVoitureDTO; null sinon</returns>
        public ReservationVoitureDTO Read(int IdReservationVoiture) {
            ReservationVoitureDTO reservationVoitureDTO = null;
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(ReservationVoitureDAO.READ_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("IdReservationVoiture", IdReservationVoiture);
                        using (MySqlDataReader reader = command.ExecuteReader()) {
                            if (reader.Read()) {
                                reservationVoitureDTO = new ReservationVoitureDTO();
                                reservationVoitureDTO.IdReservationVoiture = reader.GetInt32("IdReservationVoiture");
                                reservationVoitureDTO.IdVoiture = reader.GetInt32("IdVoiture");
                                reservationVoitureDTO.IdParticulier = reader.GetInt32("IdParticulier");
                                reservationVoitureDTO.DateReservation = reader.GetDateTime("DateReservation");
                                reservationVoitureDTO.DateFinReservation = reader.GetDateTime("DateFinReservation");
                            }
                        }
                    }
                }
            }
            catch (MySqlException mysqlException) {
                throw new VoyageAhuntsicException(1,VoyageAhuntsicException.CharteErreur[1],mysqlException);
            }
            return reservationVoitureDTO;
        }

        /// <summary>
        /// Fait un Update dans la BD sur la table ReservationVoiture
        /// </summary>
        /// <param name="reservationVoitureDTO">ReservationVoiture a modifier</param>
        public void Update(ReservationVoitureDTO reservationVoitureDTO) {
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(ReservationVoitureDAO.UPDATE_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("IdVoiture", reservationVoitureDTO.IdVoiture);
                        command.Parameters.AddWithValue("IdParticulier", reservationVoitureDTO.IdParticulier);
                        command.Parameters.AddWithValue("DateReservation", reservationVoitureDTO.DateReservation);
                        command.Parameters.AddWithValue("DateFinReservation", reservationVoitureDTO.DateFinReservation);
                        command.Parameters.AddWithValue("IdReservationVoiture", reservationVoitureDTO.IdReservationVoiture);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException mysqlException) {
                throw new VoyageAhuntsicException(1,VoyageAhuntsicException.CharteErreur[1],mysqlException);
            }
        }

        /// <summary>
        /// Fait un Delete dans la BD sur la table ReservationVoiture
        /// </summary>
        /// <param name="reservationVoitureDTO">ReservationVoiture a supprimer</param>
        public void Delete(ReservationVoitureDTO reservationVoitureDTO) {
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(ReservationVoitureDAO.DELETE_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("IdReservationVoiture", reservationVoitureDTO.IdReservationVoiture);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException mysqlException) {
                throw new VoyageAhuntsicException(1,VoyageAhuntsicException.CharteErreur[1],mysqlException);
            }
        }

        /// <summary>
        /// Retourne la liste de tous les ReservationVoitures de la table ReservationVoiture
        /// </summary>
        /// <returns>La liste de tous les ReservationVoitures; une liste vide sinon</returns>
        public DataSet GetAll() {
            DataSet dataset = null;
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(ReservationVoitureDAO.GET_ALL_QUERY, connection)) {
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

        public ReservationVoitureDTO FindByDateAndVoiture(ReservationVoitureDTO reservationVoitureDTO) {
            ReservationVoitureDTO retourReservationVoitureDTO = null;
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(ReservationVoitureDAO.FIND_BY_DATE_AND_VOITURE_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("IdVoiture", reservationVoitureDTO.IdVoiture);
                        command.Parameters.AddWithValue("DateReservation1", VADateHandler.BetweenDate(reservationVoitureDTO.DateReservation)[0]);
                        command.Parameters.AddWithValue("DateFinReservation1", VADateHandler.BetweenDate(reservationVoitureDTO.DateFinReservation)[0]);
                        command.Parameters.AddWithValue("DateReservation2", VADateHandler.BetweenDate(reservationVoitureDTO.DateReservation)[0]);
                        command.Parameters.AddWithValue("DateFinReservation2", VADateHandler.BetweenDate(reservationVoitureDTO.DateFinReservation)[0]);
                        using (MySqlDataReader reader = command.ExecuteReader()) {
                            if (reader.Read()) {
                                retourReservationVoitureDTO = new ReservationVoitureDTO();
                                retourReservationVoitureDTO.IdReservationVoiture = reader.GetInt32("IdReservationVoiture");
                                retourReservationVoitureDTO.IdVoiture = reader.GetInt32("IdVoiture");
                                retourReservationVoitureDTO.IdParticulier = reader.GetInt32("IdParticulier");
                                retourReservationVoitureDTO.DateReservation = reader.GetDateTime("DateReservation");
                                retourReservationVoitureDTO.DateFinReservation = reader.GetDateTime("DateFinReservation");
                            }
                        }
                    }
                }
            }
            catch (MySqlException mysqlException) {
                throw new VoyageAhuntsicException(1, VoyageAhuntsicException.CharteErreur[1], mysqlException);
            }
            return retourReservationVoitureDTO;
        }

    }
}
