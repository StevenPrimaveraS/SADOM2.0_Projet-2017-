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
    public class ReservationChambreDAO {

        /* **********************************
         * *** Pour ctrl + F rapidement : ***
         * **********************************
         * 
         * ReservationChambreDAO = nom du dao de la table
         * ReservationChambreDTO = nom du DTO de la table
         * reservationChambreDTO = instance de ReservationChambreDTO
         * ReservationChambre = nom de la table dans la BD (requ�te)
         * IdReservationChambre = champ d'ID de la table
         * IdChambre = 1er champ de la table
         * IdParticulier = 2i�me champ de la table
         * DateReservation = 3i�me champ de la table
         * DateFinReservation = 4i�me champ de la table
         * champ5 = 5i�me champ de la table
         * 
         * (les nom de champ doivent �tre pareil dans la BD et la classe DTO)
         * 
         */


        Connexion.Connexion connexion;
        private static readonly string INSERT_QUERY = "INSERT INTO ReservationChambre(`IdChambre`, `IdParticulier`, `DateReservation`, `DateFinReservation`) VALUES(@IdChambre, @IdParticulier, @DateReservation, @DateFinReservation)";
        private static readonly string READ_QUERY = "SELECT `IdReservationChambre`, `IdChambre`, `IdParticulier`, `DateReservation`, `DateFinReservation` FROM ReservationChambre WHERE `IdReservationChambre` = @IdReservationChambre";
        private static readonly string UPDATE_QUERY = "UPDATE ReservationChambre SET `IdChambre` = @IdChambre, `IdParticulier` = @IdParticulier, `DateReservation` = @DateReservation, `DateFinReservation` = @DateFinReservation WHERE `IdReservationChambre` = @IdReservationChambre";
        private static readonly string DELETE_QUERY = "DELETE FROM ReservationChambre WHERE `IdReservationChambre` = @IdReservationChambre";
        private static readonly string GET_ALL_QUERY = "SELECT `IdReservationChambre`, `IdChambre`, `IdParticulier`, `DateReservation`, `DateFinReservation` FROM ReservationChambre";
        private static readonly string FIND_BY_PARTICULIER = "SELECT `IdReservationChambre`, `IdChambre`, `IdParticulier`, `DateReservation`, `DateFinReservation` FROM ReservationChambre WHERE `IdParticulier` = @IdParticulier AND `DateFinReservation`< @DateActuelle";
        private static readonly string FIND_BY_DATE_AND_CHAMBRE_QUERY = "SELECT `IdReservationChambre`, `IdChambre`, `IdParticulier`, `DateReservation`, `DateFinReservation` FROM ReservationChambre WHERE ((`DateReservation` BETWEEN @DateReservation1 AND @DateFinReservation1) OR (`DateFinReservation` BETWEEN @DateReservation2 AND @DateFinReservation2)) AND `IdChambre` = @IdChambre";


        public ReservationChambreDAO() {
            connexion = new Connexion.Connexion();
        }

        /// <summary>
        /// Fait un Insert dans la BD sur la table ReservationChambre
        /// </summary>
        /// <param name="reservationChambreDTO">ReservationChambre a ajouter</param>
        public void Add(ReservationChambreDTO reservationChambreDTO) {
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(ReservationChambreDAO.INSERT_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("IdChambre", reservationChambreDTO.IdChambre);
                        command.Parameters.AddWithValue("IdParticulier", reservationChambreDTO.IdParticulier);
                        command.Parameters.AddWithValue("DateReservation", reservationChambreDTO.DateReservation);
                        command.Parameters.AddWithValue("DateFinReservation", reservationChambreDTO.DateFinReservation);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException mysqlException) {
                throw new VoyageAhuntsicException(1, VoyageAhuntsicException.CharteErreur[1],mysqlException);
            }
        }

        /// <summary>
        /// Fait un Read dans la BD sur la table ReservationChambre
        /// </summary>
        /// <param name="IdReservationChambre">l'id de ReservationChambre que l'on veut read</param>
        /// <returns>une instance de ReservationChambreDTO; null sinon</returns>
        public ReservationChambreDTO Read(int IdReservationChambre) {
            ReservationChambreDTO reservationChambreDTO = null;
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(ReservationChambreDAO.READ_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("IdReservationChambre", IdReservationChambre);
                        using (MySqlDataReader reader = command.ExecuteReader()) {
                            if (reader.Read()) {
                                reservationChambreDTO = new ReservationChambreDTO();
                                reservationChambreDTO.IdReservationChambre = reader.GetInt32("IdReservationChambre");
                                reservationChambreDTO.IdChambre = reader.GetInt32("IdChambre");
                                reservationChambreDTO.IdParticulier = reader.GetInt32("IdParticulier");
                                reservationChambreDTO.DateReservation = reader.GetDateTime("DateReservation");
                                reservationChambreDTO.DateFinReservation = reader.GetDateTime("DateFinReservation");
                            }
                        }
                    }
                }
            }
            catch (MySqlException mysqlException) {
                throw new VoyageAhuntsicException(1, VoyageAhuntsicException.CharteErreur[1],mysqlException);
            }
            return reservationChambreDTO;
        }

        /// <summary>
        /// Fait un Update dans la BD sur la table ReservationChambre
        /// </summary>
        /// <param name="reservationChambreDTO">ReservationChambre a modifier</param>
        public void Update(ReservationChambreDTO reservationChambreDTO) {
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(ReservationChambreDAO.UPDATE_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("IdChambre", reservationChambreDTO.IdChambre);
                        command.Parameters.AddWithValue("IdParticulier", reservationChambreDTO.IdParticulier);
                        command.Parameters.AddWithValue("DateReservation", reservationChambreDTO.DateReservation);
                        command.Parameters.AddWithValue("DateFinReservation", reservationChambreDTO.DateFinReservation);
                        command.Parameters.AddWithValue("IdReservationChambre", reservationChambreDTO.IdReservationChambre);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException mysqlException) {
                throw new VoyageAhuntsicException(1, VoyageAhuntsicException.CharteErreur[1],mysqlException);
            }
        }

        /// <summary>
        /// Fait un Delete dans la BD sur la table ReservationChambre
        /// </summary>
        /// <param name="reservationChambreDTO">ReservationChambre a supprimer</param>
        public void Delete(ReservationChambreDTO reservationChambreDTO) {
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(ReservationChambreDAO.DELETE_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("IdReservationChambre", reservationChambreDTO.IdReservationChambre);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException mysqlException) {
                throw new VoyageAhuntsicException(1, VoyageAhuntsicException.CharteErreur[1],mysqlException);
            }
        }

        /// <summary>
        /// Retourne la liste de tous les ReservationChambres de la table ReservationChambre
        /// </summary>
        /// <returns>La liste de tous les ReservationChambres; une liste vide sinon</returns>
        public DataSet GetAll() {
            DataSet dataset = null;
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(ReservationChambreDAO.GET_ALL_QUERY, connection)) {
                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                        dataset = new DataSet();
                        adapter.Fill(dataset);
                    }
                }
            }
            catch (MySqlException mysqlException) {
                throw new VoyageAhuntsicException(1, VoyageAhuntsicException.CharteErreur[1],mysqlException);
            }
            return dataset;
        }

        /// <summary>
        /// Retorune la liste de tous les ReservationChambre de la table ReservationChambre ayant le IdParticulier entr�
        /// </summary>
        /// <param name="idParticulier">Particulier � v�rifier</param>
        /// <returns>La liste des ReservationChambre du particulier; une liste vide sinon</returns>

        public DataSet FindByParticulier(int idParticulier)
        {
            DataSet dataset = null;
            try
            {
                using (MySqlConnection connection = connexion.getConnexion())
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(ReservationChambreDAO.FIND_BY_PARTICULIER, connection))
                    {
                        command.Prepare();
                        command.Parameters.AddWithValue("IdParticulier", idParticulier);
                        command.Parameters.AddWithValue("DateActuelle", DateTime.Now);
                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                        dataset = new DataSet();
                        adapter.Fill(dataset);
                    }
                }
            }
            catch (MySqlException mysqlException)
            {
                throw new VoyageAhuntsicException(1, VoyageAhuntsicException.CharteErreur[1], mysqlException);
            }
            return dataset;
        }

        public ReservationChambreDTO FindByDateAndChambre(ReservationChambreDTO reservationChambreDTO) {
            ReservationChambreDTO retourReservationChambreDTO = null;
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(ReservationChambreDAO.FIND_BY_DATE_AND_CHAMBRE_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("IdChambre", reservationChambreDTO.IdChambre);
                        command.Parameters.AddWithValue("DateReservation1", VADateHandler.BetweenDate(reservationChambreDTO.DateReservation)[0]);
                        command.Parameters.AddWithValue("DateFinReservation1", VADateHandler.BetweenDate(reservationChambreDTO.DateFinReservation)[0]);
                        command.Parameters.AddWithValue("DateReservation2", VADateHandler.BetweenDate(reservationChambreDTO.DateReservation)[0]);
                        command.Parameters.AddWithValue("DateFinReservation2", VADateHandler.BetweenDate(reservationChambreDTO.DateFinReservation)[0]);
                        using (MySqlDataReader reader = command.ExecuteReader()) {
                            if (reader.Read()) {
                                retourReservationChambreDTO = new ReservationChambreDTO();
                                retourReservationChambreDTO.IdReservationChambre = reader.GetInt32("IdReservationChambre");
                                retourReservationChambreDTO.IdChambre = reader.GetInt32("IdChambre");
                                retourReservationChambreDTO.IdParticulier = reader.GetInt32("IdParticulier");
                                retourReservationChambreDTO.DateReservation = reader.GetDateTime("DateReservation");
                                retourReservationChambreDTO.DateFinReservation = reader.GetDateTime("DateFinReservation");
                            }
                        }
                    }
                }
            }
            catch (MySqlException mysqlException) {
                throw new VoyageAhuntsicException(1, VoyageAhuntsicException.CharteErreur[1], mysqlException);
            }
            return retourReservationChambreDTO;
        }

    }
}
