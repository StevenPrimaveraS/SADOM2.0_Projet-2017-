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
    public class ReservationForfaitDAO {

        /* **********************************
         * *** Pour ctrl + F rapidement : ***
         * **********************************
         * 
         * ReservationForfaitDAO = nom du dao de la table
         * ReservationForfaitDTO = nom du DTO de la table
         * reservationForfaitDTO = instance de ReservationForfaitDTO
         * ReservationForfait = nom de la table dans la BD (requ�te)
         * IdReservationForfait = champ d'ID de la table
         * IdForfait = 1er champ de la table
         * IdParticulier = 2i�me champ de la table
         * DateReservation = 3i�me champ de la table
         * DateFinReservation = 4i�me champ de la table
         * champ5 = 5i�me champ de la table
         * 
         * (les nom de champ doivent �tre pareil dans la BD et la classe DTO)
         * 
         */


        Connexion.Connexion connexion;
        private static readonly string INSERT_QUERY = "INSERT INTO ReservationForfait(`IdForfait`, `IdParticulier`, `DateReservation`, `DateFinReservation`) VALUES(@IdForfait, @IdParticulier, @DateReservation, @DateFinReservation)";
        private static readonly string READ_QUERY = "SELECT `IdReservationForfait`, `IdForfait`, `IdParticulier`, `DateReservation`, `DateFinReservation` FROM ReservationForfait WHERE `IdReservationForfait` = @IdReservationForfait";
        private static readonly string UPDATE_QUERY = "UPDATE ReservationForfait SET `IdForfait` = @IdForfait, `IdParticulier` = @IdParticulier, `DateReservation` = @DateReservation, `DateFinReservation` = @DateFinReservation WHERE `IdReservationForfait` = @IdReservationForfait";
        private static readonly string DELETE_QUERY = "DELETE FROM ReservationForfait WHERE `IdReservationForfait` = @IdReservationForfait";
        private static readonly string GET_ALL_QUERY = "SELECT `IdReservationForfait`, `IdForfait`, `IdParticulier`, `DateReservation`, `DateFinReservation` FROM ReservationForfait";
        private static readonly string FIND_BY_DATE_AND_FORFAIT_QUERY = "SELECT `IdReservationForfait`, `IdForfait`, `IdParticulier`, `DateReservation`, `DateFinReservation` FROM ReservationForfait WHERE ((`DateReservation` BETWEEN @DateReservation1 AND @DateFinReservation1) OR (`DateFinReservation` BETWEEN @DateReservation2 AND @DateFinReservation2)) AND `IdForfait` = @IdForfait";


        public ReservationForfaitDAO() {
            connexion = new Connexion.Connexion();
        }

        /// <summary>
        /// Fait un Insert dans la BD sur la table ReservationForfait
        /// </summary>
        /// <param name="reservationForfaitDTO">ReservationForfait a ajouter</param>
        public void Add(ReservationForfaitDTO reservationForfaitDTO) {
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(ReservationForfaitDAO.INSERT_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("IdForfait", reservationForfaitDTO.IdForfait);
                        command.Parameters.AddWithValue("IdParticulier", reservationForfaitDTO.IdParticulier);
                        command.Parameters.AddWithValue("DateReservation", reservationForfaitDTO.DateReservation);
                        command.Parameters.AddWithValue("DateFinReservation", reservationForfaitDTO.DateFinReservation);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException mysqlException) {
                throw new VoyageAhuntsicException(1,VoyageAhuntsicException.CharteErreur[1],mysqlException);
            }
        }

        /// <summary>
        /// Fait un Read dans la BD sur la table ReservationForfait
        /// </summary>
        /// <param name="IdReservationForfait">l'id de ReservationForfait que l'on veut read</param>
        /// <returns>une instance de ReservationForfaitDTO; null sinon</returns>
        public ReservationForfaitDTO Read(int IdReservationForfait) {
            ReservationForfaitDTO reservationForfaitDTO = null;
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(ReservationForfaitDAO.READ_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("IdReservationForfait", IdReservationForfait);
                        using (MySqlDataReader reader = command.ExecuteReader()) {
                            if (reader.Read()) {
                                reservationForfaitDTO = new ReservationForfaitDTO();
                                reservationForfaitDTO.IdReservationForfait = reader.GetInt32("IdReservationForfait");
                                reservationForfaitDTO.IdForfait = reader.GetInt32("IdForfait");
                                reservationForfaitDTO.IdParticulier = reader.GetInt32("IdParticulier");
                                reservationForfaitDTO.DateReservation = reader.GetDateTime("DateReservation");
                                reservationForfaitDTO.DateFinReservation = reader.GetDateTime("DateFinReservation");
                            }
                        }
                    }
                }
            }
            catch (MySqlException mysqlException) {
                throw new VoyageAhuntsicException(1,VoyageAhuntsicException.CharteErreur[1],mysqlException);
            }
            return reservationForfaitDTO;
        }

        /// <summary>
        /// Fait un Update dans la BD sur la table ReservationForfait
        /// </summary>
        /// <param name="reservationForfaitDTO">ReservationForfait a modifier</param>
        public void Update(ReservationForfaitDTO reservationForfaitDTO) {
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(ReservationForfaitDAO.UPDATE_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("IdForfait", reservationForfaitDTO.IdForfait);
                        command.Parameters.AddWithValue("IdParticulier", reservationForfaitDTO.IdParticulier);
                        command.Parameters.AddWithValue("DateReservation", reservationForfaitDTO.DateReservation);
                        command.Parameters.AddWithValue("DateFinReservation", reservationForfaitDTO.DateFinReservation);
                        command.Parameters.AddWithValue("IdReservationForfait", reservationForfaitDTO.IdReservationForfait);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException mysqlException) {
                throw new VoyageAhuntsicException(1,VoyageAhuntsicException.CharteErreur[1],mysqlException);
            }
        }

        /// <summary>
        /// Fait un Delete dans la BD sur la table ReservationForfait
        /// </summary>
        /// <param name="reservationForfaitDTO">ReservationForfait a supprimer</param>
        public void Delete(ReservationForfaitDTO reservationForfaitDTO) {
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(ReservationForfaitDAO.DELETE_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("IdReservationForfait", reservationForfaitDTO.IdReservationForfait);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException mysqlException) {
                throw new VoyageAhuntsicException(1,VoyageAhuntsicException.CharteErreur[1],mysqlException);
            }
        }

        /// <summary>
        /// Retourne la liste de tous les ReservationForfaits de la table ReservationForfait
        /// </summary>
        /// <returns>La liste de tous les ReservationForfaits; une liste vide sinon</returns>
        public DataSet GetAll() {
            DataSet dataset = null;
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(ReservationForfaitDAO.GET_ALL_QUERY, connection)) {
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

        public ReservationForfaitDTO FindByDateAndForfait(ReservationForfaitDTO reservationForfaitDTO) {
            ReservationForfaitDTO retourReservationForfaitDTO = null;
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(ReservationForfaitDAO.FIND_BY_DATE_AND_FORFAIT_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("IdForfait", reservationForfaitDTO.IdForfait);
                        command.Parameters.AddWithValue("DateReservation1", VADateHandler.BetweenDate(reservationForfaitDTO.DateReservation)[0]);
                        command.Parameters.AddWithValue("DateFinReservation1", VADateHandler.BetweenDate(reservationForfaitDTO.DateFinReservation)[0]);
                        command.Parameters.AddWithValue("DateReservation2", VADateHandler.BetweenDate(reservationForfaitDTO.DateReservation)[0]);
                        command.Parameters.AddWithValue("DateFinReservation2", VADateHandler.BetweenDate(reservationForfaitDTO.DateFinReservation)[0]);
                        using (MySqlDataReader reader = command.ExecuteReader()) {
                            if (reader.Read()) {
                                retourReservationForfaitDTO = new ReservationForfaitDTO();
                                retourReservationForfaitDTO.IdReservationForfait = reader.GetInt32("IdReservationForfait");
                                retourReservationForfaitDTO.IdForfait = reader.GetInt32("IdForfait");
                                retourReservationForfaitDTO.IdParticulier = reader.GetInt32("IdParticulier");
                                retourReservationForfaitDTO.DateReservation = reader.GetDateTime("DateReservation");
                                retourReservationForfaitDTO.DateFinReservation = reader.GetDateTime("DateFinReservation");
                            }
                        }
                    }
                }
            }
            catch (MySqlException mysqlException) {
                throw new VoyageAhuntsicException(1, VoyageAhuntsicException.CharteErreur[1], mysqlException);
            }
            return retourReservationForfaitDTO;
        }

    }
}
