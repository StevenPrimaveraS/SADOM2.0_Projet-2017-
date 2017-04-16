using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using Prj_Final_2017_.DTO;
using Prj_Final_2017_.Models.Exception;

namespace Prj_Final_2017_.Models.DAO {
    public class HotelDAO {

        /* **********************************
         * *** Pour ctrl + F rapidement : ***
         * **********************************
         * 
         * HotelDAO = nom du dao de la table
         * HotelDTO = nom du DTO de la table
         * hotelDTO = instance de HotelDTO
         * Hotel = nom de la table dans la BD (requête)
         * IdHotel = champ d'ID de la table
         * Nom = 1er champ de la table
         * Telephone = 2ième champ de la table
         * Adresse = 3ième champ de la table
         * Ville = 4ième champ de la table
         * Categorie = 5ième champ de la table
         * 
         * (les nom de champ doivent être pareil dans la BD et la classe DTO)
         * 
         */


        Connexion.Connexion connexion;
        private static readonly string INSERT_QUERY = "INSERT INTO Hotel(`Nom`, `Telephone`, `Adresse`, `Ville`, `Categorie`, `Description`) VALUES(@Nom, @Telephone, @Adresse, @Ville, @Categorie, @Description)";
        private static readonly string READ_QUERY = "SELECT `IdHotel`, `Nom`, `Telephone`, `Adresse`, `Ville`, `Categorie`, `Description` FROM Hotel WHERE `IdHotel` = @IdHotel";
        private static readonly string UPDATE_QUERY = "UPDATE Hotel SET `Nom` = @Nom, `Telephone` = @Telephone, `Adresse` = @Adresse, `Ville` = @Ville, `Categorie` = @Categorie, `Description` = @Description WHERE `IdHotel` = @IdHotel";
        private static readonly string DELETE_QUERY = "DELETE FROM Hotel WHERE `IdHotel` = @IdHotel";
        private static readonly string GET_ALL_QUERY = "SELECT `IdHotel`, `Nom`, `Telephone`, `Adresse`, `Ville`, `Categorie`, `Description` FROM Hotel";
        private static readonly string FIND_BY_BASIC_INFO_QUERY = "SELECT `IdHotel`, `Nom`, `Telephone`, `Adresse`, `Ville`, `Categorie`, `Description` FROM Hotel WHERE `Nom` = @Nom AND `Telephone` = @Telephone AND `Adresse` = @Adresse AND `Ville` = @Ville";

        public HotelDAO() {
            connexion = new Connexion.Connexion();
        }

        /// <summary>
        /// Fait un Insert dans la BD sur la table Hotel
        /// </summary>
        /// <param name="hotelDTO">Hotel a ajouter</param>
        public void Add(HotelDTO hotelDTO) {
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(HotelDAO.INSERT_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("Nom", hotelDTO.Nom);
                        command.Parameters.AddWithValue("Telephone", hotelDTO.Telephone);
                        command.Parameters.AddWithValue("Adresse", hotelDTO.Adresse);
                        command.Parameters.AddWithValue("Ville", hotelDTO.Ville);
                        command.Parameters.AddWithValue("Categorie", hotelDTO.Categorie);
                        command.Parameters.AddWithValue("Description", hotelDTO.Description);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException mysqlException) {
                throw new VoyageAhuntsicException(1234,VoyageAhuntsicException.CharteErreur[1234],mysqlException);
            }
        }

        /// <summary>
        /// Fait un Read dans la BD sur la table Hotel
        /// </summary>
        /// <param name="IdHotel">l'id de Hotel que l'on veut read</param>
        /// <returns>une instance de HotelDTO; null sinon</returns>
        public HotelDTO Read(int IdHotel) {
            HotelDTO hotelDTO = null;
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(HotelDAO.READ_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("IdHotel", IdHotel);
                        using (MySqlDataReader reader = command.ExecuteReader()) {
                            if (reader.Read()) {
                                hotelDTO = new HotelDTO();
                                hotelDTO.IdHotel = reader.GetInt32("IdHotel");
                                hotelDTO.Nom = reader.GetString("Nom");
                                hotelDTO.Telephone = reader.GetString("Telephone");
                                hotelDTO.Adresse = reader.GetString("Adresse");
                                hotelDTO.Ville = reader.GetString("Ville");
                                hotelDTO.Categorie = reader.GetString("Categorie");
                                hotelDTO.Description = reader.GetString("Description");

                            }
                        }
                    }
                }
            }
            catch (MySqlException mysqlException) {
                throw new VoyageAhuntsicException(1234,VoyageAhuntsicException.CharteErreur[1234],mysqlException);
            }
            return hotelDTO;
        }

        /// <summary>
        /// Fait un Update dans la BD sur la table Hotel
        /// </summary>
        /// <param name="hotelDTO">Hotel a modifier</param>
        public void Update(HotelDTO hotelDTO) {
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(HotelDAO.UPDATE_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("Nom", hotelDTO.Nom);
                        command.Parameters.AddWithValue("Telephone", hotelDTO.Telephone);
                        command.Parameters.AddWithValue("Adresse", hotelDTO.Adresse);
                        command.Parameters.AddWithValue("Ville", hotelDTO.Ville);
                        command.Parameters.AddWithValue("Categorie", hotelDTO.Categorie);
                        command.Parameters.AddWithValue("Description", hotelDTO.Description);
                        command.Parameters.AddWithValue("IdHotel", hotelDTO.IdHotel);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException mysqlException) {
                throw new VoyageAhuntsicException(1234,VoyageAhuntsicException.CharteErreur[1234],mysqlException);
            }
        }

        /// <summary>
        /// Fait un Delete dans la BD sur la table Hotel
        /// </summary>
        /// <param name="hotelDTO">Hotel a supprimer</param>
        public void Delete(HotelDTO hotelDTO) {
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(HotelDAO.DELETE_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("IdHotel", hotelDTO.IdHotel);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException mysqlException) {
                throw new VoyageAhuntsicException(1234,VoyageAhuntsicException.CharteErreur[1234],mysqlException);
            }
        }

        /// <summary>
        /// Retourne la liste de tous les Hotels de la table Hotel
        /// </summary>
        /// <returns>La liste de tous les Hotels; une liste vide sinon</returns>
        public DataSet GetAll() {
            DataSet dataset = null;
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(HotelDAO.GET_ALL_QUERY, connection)) {
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

        /// <summary>
        /// trouve une Hotel selon ses informations de base
        /// </summary>
        /// <param name="hotelDTO">informations de bases de l'hotel</param>
        /// <returns>une instance de HotelDTO; null sinon</returns>
        public HotelDTO FindByBasicInfo(HotelDTO hotelDTO) {
            HotelDTO retourHotelDTO = null;
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(HotelDAO.FIND_BY_BASIC_INFO_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("Nom", hotelDTO.Nom);
                        command.Parameters.AddWithValue("Telephone", hotelDTO.Telephone);
                        command.Parameters.AddWithValue("Adresse", hotelDTO.Adresse);
                        command.Parameters.AddWithValue("Ville", hotelDTO.Ville);
                        using (MySqlDataReader reader = command.ExecuteReader()) {
                            if (reader.Read()) {
                                retourHotelDTO = new HotelDTO();
                                retourHotelDTO.IdHotel = reader.GetInt32("IdHotel");
                                retourHotelDTO.Nom = reader.GetString("Nom");
                                retourHotelDTO.Telephone = reader.GetString("Telephone");
                                retourHotelDTO.Adresse = reader.GetString("Adresse");
                                retourHotelDTO.Ville = reader.GetString("Ville");
                                retourHotelDTO.Categorie = reader.GetString("Categorie");
                                retourHotelDTO.Description = reader.GetString("Description");
                            }
                        }
                    }
                }
            }
            catch (MySqlException mysqlException) {
                throw new VoyageAhuntsicException(1234, VoyageAhuntsicException.CharteErreur[1234], mysqlException);
            }
            return retourHotelDTO;
        }

    }
}
