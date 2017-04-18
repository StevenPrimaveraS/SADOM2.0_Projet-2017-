using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using Prj_Final_2017_.DTO;
using Prj_Final_2017_.Models.Exception;

namespace Prj_Final_2017_.Models.DAO {
    public class SiegeDAO {

        /* **********************************
         * *** Pour ctrl + F rapidement : ***
         * **********************************
         * 
         * SiegeDAO = nom du dao de la table
         * SiegeDTO = nom du DTO de la table
         * siegeDTO = instance de SiegeDTO
         * Siege = nom de la table dans la BD (requête)
         * IdSiege = champ d'ID de la table
         * Type = 1er champ de la table
         * Numero = 2ième champ de la table
         * IdVol = 3ième champ de la table
         * champ4 = 4ième champ de la table
         * champ5 = 5ième champ de la table
         * 
         * (les nom de champ doivent être pareil dans la BD et la classe DTO)
         * 
         */


        Connexion.Connexion connexion;
        private static readonly string INSERT_QUERY = "INSERT INTO Siege(`Type`, `Numero`, `IdVol`) VALUES(@Type, @Numero, @IdVol)";
        private static readonly string READ_QUERY = "SELECT `IdSiege`, `Type`, `Numero`, `IdVol` FROM Siege WHERE `IdSiege` = @IdSiege";
        private static readonly string UPDATE_QUERY = "UPDATE Siege SET `Type` = @Type, `Numero` = @Numero, `IdVol` = @IdVol WHERE `IdSiege` = @IdSiege";
        private static readonly string DELETE_QUERY = "DELETE FROM Siege WHERE `IdSiege` = @IdSiege";
        private static readonly string GET_ALL_QUERY = "SELECT `IdSiege`, `Type`, `Numero`, `IdVol` FROM Siege";
        private static readonly string FIND_BY_VOL = "SELECT `IdSiege`, `Type`, `Numero`, `IdVol` FROM Siege WHERE `IdVol` = @IdVol";

        public SiegeDAO() {
            connexion = new Connexion.Connexion();
        }

        /// <summary>
        /// Fait un Insert dans la BD sur la table Siege
        /// </summary>
        /// <param name="siegeDTO">Siege a ajouter</param>
        public void Add(SiegeDTO siegeDTO) {
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(SiegeDAO.INSERT_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("Type", siegeDTO.Type);
                        command.Parameters.AddWithValue("Numero", siegeDTO.Numero);
                        command.Parameters.AddWithValue("IdVol", siegeDTO.IdVol);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException mysqlException) {
                throw new VoyageAhuntsicException(1,VoyageAhuntsicException.CharteErreur[1],mysqlException);
            }
        }

        /// <summary>
        /// Fait un Read dans la BD sur la table Siege
        /// </summary>
        /// <param name="IdSiege">l'id de Siege que l'on veut read</param>
        /// <returns>une instance de SiegeDTO; null sinon</returns>
        public SiegeDTO Read(int IdSiege) {
            SiegeDTO siegeDTO = null;
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(SiegeDAO.READ_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("IdSiege", IdSiege);
                        using (MySqlDataReader reader = command.ExecuteReader()) {
                            if (reader.Read()) {
                                siegeDTO = new SiegeDTO();
                                siegeDTO.IdSiege = reader.GetInt32("IdSiege");
                                siegeDTO.Type = reader.GetString("Type");
                                siegeDTO.Numero = reader.GetInt32("Numero");
                                siegeDTO.IdVol = reader.GetInt32("IdVol");
                            }
                        }
                    }
                }
            }
            catch (MySqlException mysqlException) {
                throw new VoyageAhuntsicException(1,VoyageAhuntsicException.CharteErreur[1],mysqlException);
            }
            return siegeDTO;
        }

        /// <summary>
        /// Fait un Update dans la BD sur la table Siege
        /// </summary>
        /// <param name="siegeDTO">Siege a modifier</param>
        public void Update(SiegeDTO siegeDTO) {
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(SiegeDAO.UPDATE_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("Type", siegeDTO.Type);
                        command.Parameters.AddWithValue("Numero", siegeDTO.Numero);
                        command.Parameters.AddWithValue("IdVol", siegeDTO.IdVol);
                        command.Parameters.AddWithValue("IdSiege", siegeDTO.IdSiege);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException mysqlException) {
                throw new VoyageAhuntsicException(1,VoyageAhuntsicException.CharteErreur[1],mysqlException);
            }
        }

        /// <summary>
        /// Fait un Delete dans la BD sur la table Siege
        /// </summary>
        /// <param name="siegeDTO">Siege a supprimer</param>
        public void Delete(SiegeDTO siegeDTO) {
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(SiegeDAO.DELETE_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("IdSiege", siegeDTO.IdSiege);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException mysqlException) {
                throw new VoyageAhuntsicException(1,VoyageAhuntsicException.CharteErreur[1],mysqlException);
            }
        }

        /// <summary>
        /// Retourne la liste de tous les Sieges de la table Siege
        /// </summary>
        /// <returns>La liste de tous les Sieges; une liste vide sinon</returns>
        public DataSet GetAll() {
            DataSet dataset = null;
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(SiegeDAO.GET_ALL_QUERY, connection)) {
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

        /// <summary>
        /// Retorune la liste de tous les Sieges de la table Siege ayant le IdVol entré
        /// </summary>
        /// <param name="idVol">Vol à vérifier</param>
        /// <returns>La liste des Siege du vol; une liste vide sinon</returns>

        public DataSet FindByVol(int idVol)
        {
            DataSet dataset = null;
            try
            {
                using (MySqlConnection connection = connexion.getConnexion())
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(SiegeDAO.FIND_BY_VOL, connection))
                    {
                        command.Prepare();
                        command.Parameters.AddWithValue("IdVol", idVol);
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
