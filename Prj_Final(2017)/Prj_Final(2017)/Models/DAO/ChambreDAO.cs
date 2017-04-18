using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using Prj_Final_2017_.DTO;
using Prj_Final_2017_.Models.Exception;

namespace Prj_Final_2017_.Models.DAO {
    public class ChambreDAO {

        /* **********************************
         * *** Pour ctrl + F rapidement : ***
         * **********************************
         * 
         * ChambreDAO = nom du dao de la table
         * ChambreDTO = nom du DTO de la table
         * chambreDTO = instance de ChambreDTO
         * Chambre = nom de la table dans la BD (requête)
         * IdChambre = champ d'ID de la table
         * NumeroChambre = 1er champ de la table
         * NomChambre = 2ième champ de la table
         * Tarif = 3ième champ de la table
         * MaxPersonne = 4ième champ de la table
         * Taille = 5ième champ de la table
         * Description = 6ième champ de la table
         * IdHotel = 7ième champ de la table
         * 
         * (les nom de champ doivent être pareil dans la BD et la classe DTO)
         * 
         */


        Connexion.Connexion connexion;
        private static readonly string INSERT_QUERY = "INSERT INTO Chambre(`NumeroChambre`, `NomChambre`, `Tarif`, `MaxPersonne`, `Taille`, `Description`, `IdHotel`) VALUES(@NumeroChambre, @NomChambre, @Tarif, @MaxPersonne, @Taille, @Description, @IdHotel)";
        private static readonly string READ_QUERY = "SELECT `IdChambre`, `NumeroChambre`, `NomChambre`, `Tarif`, `MaxPersonne`, `Taille`, `Description`, `IdHotel` FROM Chambre WHERE `IdChambre` = @IdChambre";
        private static readonly string UPDATE_QUERY = "UPDATE Chambre SET `NumeroChambre` = @NumeroChambre, `NomChambre` = @NomChambre, `Tarif` = @Tarif, `MaxPersonne` = @MaxPersonne, `Taille` = @Taille, `Description` = @Description, `IdHotel` = @IdHotel WHERE `IdChambre` = @IdChambre";
        private static readonly string DELETE_QUERY = "DELETE FROM Chambre WHERE `IdChambre` = @IdChambre";
        private static readonly string GET_ALL_QUERY = "SELECT `IdChambre`, `NumeroChambre`, `NomChambre`, `Tarif`, `MaxPersonne`, `Taille`, `Description`, `IdHotel` FROM Chambre";
        private static readonly string FIND_BY_HOTEL = "SELECT `IdChambre`, `NumeroChambre`, `NomChambre`, `Tarif`, `MaxPersonne`, `Taille`, `Description`, `IdHotel` FROM Chambre WHERE `IdHotel` = @IdHotel";


        public ChambreDAO() {
            connexion = new Connexion.Connexion();
        }

        /// <summary>
        /// Fait un Insert dans la BD sur la table Chambre
        /// </summary>
        /// <param name="chambreDTO">Chambre a ajouter</param>
        public void Add(ChambreDTO chambreDTO) {
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(ChambreDAO.INSERT_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("NumeroChambre", chambreDTO.NumeroChambre);
                        command.Parameters.AddWithValue("NomChambre", chambreDTO.NomChambre);
                        command.Parameters.AddWithValue("Tarif", chambreDTO.Tarif);
                        command.Parameters.AddWithValue("MaxPersonne", chambreDTO.MaxPersonne);
                        command.Parameters.AddWithValue("Taille", chambreDTO.Taille);
                        command.Parameters.AddWithValue("Description", chambreDTO.Description);
                        command.Parameters.AddWithValue("IdHotel", chambreDTO.IdHotel);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException mysqlException) {
                throw new VoyageAhuntsicException(1, VoyageAhuntsicException.CharteErreur[1], mysqlException);
            }
        }

        /// <summary>
        /// Fait un Read dans la BD sur la table Chambre
        /// </summary>
        /// <param name="IdChambre">l'id de Chambre que l'on veut read</param>
        /// <returns>une instance de ChambreDTO; null sinon</returns>
        public ChambreDTO Read(int IdChambre) {
            ChambreDTO chambreDTO = null;
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(ChambreDAO.READ_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("IdChambre", IdChambre);
                        using (MySqlDataReader reader = command.ExecuteReader()) {
                            if (reader.Read()) {
                                chambreDTO = new ChambreDTO();
                                chambreDTO.IdChambre = reader.GetInt32("IdChambre");
                                chambreDTO.NumeroChambre = reader.GetInt32("NumeroChambre");
                                chambreDTO.NomChambre = reader.GetString("NomChambre");
                                chambreDTO.Tarif = reader.GetDouble("Tarif");
                                chambreDTO.MaxPersonne = reader.GetInt32("MaxPersonne");
                                chambreDTO.Taille = reader.GetInt32("Taille");
                                chambreDTO.Description = reader.GetString("Description");
                                chambreDTO.IdHotel = reader.GetInt32("IdHotel");
                            }
                        }
                    }
                }
            }
            catch (MySqlException mysqlException) {
                throw new VoyageAhuntsicException(1, VoyageAhuntsicException.CharteErreur[1], mysqlException);
            }
            return chambreDTO;
        }

        /// <summary>
        /// Fait un Update dans la BD sur la table Chambre
        /// </summary>
        /// <param name="chambreDTO">Chambre a modifier</param>
        public void Update(ChambreDTO chambreDTO) {
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(ChambreDAO.UPDATE_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("NumeroChambre", chambreDTO.NumeroChambre);
                        command.Parameters.AddWithValue("NomChambre", chambreDTO.NomChambre);
                        command.Parameters.AddWithValue("Tarif", chambreDTO.Tarif);
                        command.Parameters.AddWithValue("MaxPersonne", chambreDTO.MaxPersonne);
                        command.Parameters.AddWithValue("Taille", chambreDTO.Taille);
                        command.Parameters.AddWithValue("Description", chambreDTO.Description);
                        command.Parameters.AddWithValue("IdHotel", chambreDTO.IdHotel);
                        command.Parameters.AddWithValue("IdChambre", chambreDTO.IdChambre);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException mysqlException) {
                throw new VoyageAhuntsicException(1, VoyageAhuntsicException.CharteErreur[1], mysqlException);
            }
        }

        /// <summary>
        /// Fait un Delete dans la BD sur la table Chambre
        /// </summary>
        /// <param name="chambreDTO">Chambre a supprimer</param>
        public void Delete(ChambreDTO chambreDTO) {
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(ChambreDAO.DELETE_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("IdChambre", chambreDTO.IdChambre);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException mysqlException) {
                throw new VoyageAhuntsicException(1, VoyageAhuntsicException.CharteErreur[1], mysqlException);
            }
        }

        /// <summary>
        /// Retourne la liste de tous les Chambres de la table Chambre
        /// </summary>
        /// <returns>La liste de tous les Chambres; une liste vide sinon</returns>
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
                throw new VoyageAhuntsicException(1, VoyageAhuntsicException.CharteErreur[1], mysqlException);
            }
            return dataset;
        }

        /// <summary>
        /// Retorune la liste de tous les Chambre de la table Chambre ayant le IdHotel entré
        /// </summary>
        /// <param name="idHotel">Hotel à vérifier</param>
        /// <returns>La liste des Chambre de l'hotel; une liste vide sinon</returns>

        public DataSet FindByHotel(int idHotel)
        {
            DataSet dataset = null;
            try
            {
                using (MySqlConnection connection = connexion.getConnexion())
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(ChambreDAO.FIND_BY_HOTEL, connection))
                    {
                        command.Prepare();
                        command.Parameters.AddWithValue("IdHotel", idHotel);
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
    }
}
