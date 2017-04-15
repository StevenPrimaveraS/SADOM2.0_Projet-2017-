using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using Prj_Final_2017_.DTO;
using Prj_Final_2017_.Models.Exception;

namespace Prj_Final_2017_.Models.DAO {
    public class ReservationChambreDAO {

        /* **********************************
         * *** Pour ctrl + F rapidement : ***
         * **********************************
         * 
         * ReservationChambreDAO = nom du dao de la table
         * ReservationChambreDTO = nom du DTO de la table
         * reservationChambreDTO = instance de ReservationChambreDTO
         * ReservationChambre = nom de la table dans la BD (requête)
         * IdReservationChambre = champ d'ID de la table
         * IdChambre = 1er champ de la table
         * IdParticulier = 2ième champ de la table
         * DateReservation = 3ième champ de la table
         * DateFinReservation = 4ième champ de la table
         * champ5 = 5ième champ de la table
         * 
         * (les nom de champ doivent être pareil dans la BD et la classe DTO)
         * 
         */


        Connexion.Connexion connexion;
        private static readonly string INSERT_QUERY = "INSERT INTO ReservationChambre(`IdChambre`, `IdParticulier`, `DateReservation`, `DateFinReservation`) VALUES(@IdChambre, @IdParticulier, @DateReservation, @DateFinReservation)";
        private static readonly string READ_QUERY = "SELECT `IdReservationChambre`, `IdChambre`, `IdParticulier`, `DateReservation`, `DateFinReservation` FROM ReservationChambre WHERE `IdReservationChambre` = @IdReservationChambre";
        private static readonly string UPDATE_QUERY = "UPDATE ReservationChambre SET `IdChambre` = @IdChambre, `IdParticulier` = @IdParticulier, `DateReservation` = @DateReservation, `DateFinReservation` = @DateFinReservation WHERE `IdReservationChambre` = @IdReservationChambre";
        private static readonly string DELETE_QUERY = "DELETE FROM ReservationChambre WHERE `IdReservationChambre` = @IdReservationChambre";
        private static readonly string GET_ALL_QUERY = "SELECT `IdReservationChambre`, `IdChambre`, `IdParticulier`, `DateReservation`, `DateFinReservation` FROM ReservationChambre";
        private static readonly string FIND_BY_PARTICULIER = "SELECT `IdReservationChambre`, `IdChambre`, `IdParticulier`, `DateReservation`, `DateFinReservation` FROM ReservationChambre WHERE `IdParticulier` = @IdParticulier AND `DateFinReservation`< @DateActuelle";

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
                throw new VoyageAhuntsicException(21001, VoyageAhuntsicException.CharteErreur[21001],mysqlException);
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
                throw new VoyageAhuntsicException(21002, VoyageAhuntsicException.CharteErreur[21002],mysqlException);
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
                throw new VoyageAhuntsicException(21003, VoyageAhuntsicException.CharteErreur[21003],mysqlException);
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
                throw new VoyageAhuntsicException(21004, VoyageAhuntsicException.CharteErreur[21004],mysqlException);
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
                throw new VoyageAhuntsicException(21005, VoyageAhuntsicException.CharteErreur[21005],mysqlException);
            }
            return dataset;
        }

        /// <summary>
        /// Retorune la liste de tous les ReservationChambre de la table ReservationChambre ayant le IdParticulier entré
        /// </summary>
        /// <param name="idParticulier">Particulier à vérifier</param>
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
                throw new VoyageAhuntsicException(21006, VoyageAhuntsicException.CharteErreur[21006], mysqlException);
            }
            return dataset;
        }
    }
}
