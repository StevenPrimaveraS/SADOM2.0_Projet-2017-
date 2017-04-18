using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using Prj_Final_2017_.DTO;
using Prj_Final_2017_.Models.Exception;

namespace Prj_Final_2017_.Models.DAO {
    public class CompteFournisseurChambreDAO {

        /* **********************************
         * *** Pour ctrl + F rapidement : ***
         * **********************************
         * 
         * CompteFournisseurChambreDAO = nom du dao de la table
         * CompteFournisseurChambreDTO = nom du DTO de la table
         * compteFournisseurChambreDTO = instance de CompteFournisseurChambreDTO
         * CompteFournisseurChambre = nom de la table dans la BD (requête)
         * IdFournisseur = champ d'ID de la table
         * Courriel = 1er champ de la table
         * Password = 2ième champ de la table
         * IdHotel = 3ième champ de la table
         * 
         * (les nom de champ doivent être pareil dans la BD et la classe DTO)
         * 
         */


        Connexion.Connexion connexion;
        private static readonly string INSERT_QUERY = "INSERT INTO CompteFournisseurChambre(`Courriel`, `Password`, `IdHotel`) VALUES(@Courriel, @Password, @IdHotel)";
        private static readonly string READ_QUERY = "SELECT `IdFournisseur`, `Courriel`, `Password`, `IdHotel` FROM CompteFournisseurChambre WHERE `IdFournisseur` = @IdFournisseur";
        private static readonly string UPDATE_QUERY = "UPDATE CompteFournisseurChambre SET `Courriel` = @Courriel, `Password` = @Password, `IdHotel` = @IdHotel WHERE `IdFournisseur` = @IdFournisseur";
        private static readonly string DELETE_QUERY = "DELETE FROM CompteFournisseurChambre WHERE `IdFournisseur` = @IdFournisseur";
        private static readonly string GET_ALL_QUERY = "SELECT `IdFournisseur`, `Courriel`, `Password`, `IdHotel` FROM CompteFournisseurChambre";
        private static readonly string FIND_BY_COURRIEL = "SELECT `IdFournisseur`, `Courriel`, `Password`, `IdHotel` FROM CompteFournisseurChambre WHERE `Courriel` = @Courriel";
        private static readonly string AUTHENTICATE_QUERY = "SELECT `IdFournisseur`, `Courriel`, `Password`, `IdHotel` FROM CompteFournisseurChambre WHERE `Courriel` = @Courriel AND `Password` = @Password";


        public CompteFournisseurChambreDAO() {
            connexion = new Connexion.Connexion();
        }

        /// <summary>
        /// Fait un Insert dans la BD sur la table CompteFournisseurChambre
        /// </summary>
        /// <param name="compteFournisseurChambreDTO">CompteFournisseurChambre a ajouter</param>
        public void Add(CompteFournisseurChambreDTO compteFournisseurChambreDTO) {
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(CompteFournisseurChambreDAO.INSERT_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("Courriel", compteFournisseurChambreDTO.Courriel);
                        command.Parameters.AddWithValue("Password", compteFournisseurChambreDTO.Password);
                        command.Parameters.AddWithValue("IdHotel", compteFournisseurChambreDTO.IdHotel);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException mysqlException) {
                throw new VoyageAhuntsicException(1,VoyageAhuntsicException.CharteErreur[1],mysqlException);
            }
        }

        /// <summary>
        /// Fait un Read dans la BD sur la table CompteFournisseurChambre
        /// </summary>
        /// <param name="IdFournisseur">l'id de CompteFournisseurChambre que l'on veut read</param>
        /// <returns>une instance de CompteFournisseurChambreDTO; null sinon</returns>
        public CompteFournisseurChambreDTO Read(int IdFournisseur) {
            CompteFournisseurChambreDTO compteFournisseurChambreDTO = null;
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(CompteFournisseurChambreDAO.READ_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("IdFournisseur", IdFournisseur);
                        using (MySqlDataReader reader = command.ExecuteReader()) {
                            if (reader.Read()) {
                                compteFournisseurChambreDTO = new CompteFournisseurChambreDTO();
                                compteFournisseurChambreDTO.IdFournisseur = reader.GetInt32("IdFournisseur");
                                compteFournisseurChambreDTO.Courriel = reader.GetString("Courriel");
                                compteFournisseurChambreDTO.Password = reader.GetString("Password");
                                compteFournisseurChambreDTO.IdHotel = reader.GetInt32("IdHotel");
                            }
                        }
                    }
                }
            }
            catch (MySqlException mysqlException) {
                throw new VoyageAhuntsicException(1,VoyageAhuntsicException.CharteErreur[1],mysqlException);
            }
            return compteFournisseurChambreDTO;
        }

        /// <summary>
        /// Fait un Update dans la BD sur la table CompteFournisseurChambre
        /// </summary>
        /// <param name="compteFournisseurChambreDTO">CompteFournisseurChambre a modifier</param>
        public void Update(CompteFournisseurChambreDTO compteFournisseurChambreDTO) {
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(CompteFournisseurChambreDAO.UPDATE_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("Courriel", compteFournisseurChambreDTO.Courriel);
                        command.Parameters.AddWithValue("Password", compteFournisseurChambreDTO.Password);
                        command.Parameters.AddWithValue("IdHotel", compteFournisseurChambreDTO.IdHotel);
                        command.Parameters.AddWithValue("IdFournisseur", compteFournisseurChambreDTO.IdFournisseur);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException mysqlException) {
                throw new VoyageAhuntsicException(1,VoyageAhuntsicException.CharteErreur[1],mysqlException);
            }
        }

        /// <summary>
        /// Fait un Delete dans la BD sur la table CompteFournisseurChambre
        /// </summary>
        /// <param name="compteFournisseurChambreDTO">CompteFournisseurChambre a supprimer</param>
        public void Delete(CompteFournisseurChambreDTO compteFournisseurChambreDTO) {
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(CompteFournisseurChambreDAO.DELETE_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("IdFournisseur", compteFournisseurChambreDTO.IdFournisseur);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException mysqlException) {
                throw new VoyageAhuntsicException(1,VoyageAhuntsicException.CharteErreur[1],mysqlException);
            }
        }

        /// <summary>
        /// Retourne la liste de tous les CompteFournisseurChambres de la table CompteFournisseurChambre
        /// </summary>
        /// <returns>La liste de tous les CompteFournisseurChambres; une liste vide sinon</returns>
        public DataSet GetAll() {
            DataSet dataset = null;
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(CompteFournisseurChambreDAO.GET_ALL_QUERY, connection)) {
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
        /// Retorune la liste de tous les CompteFournisseurChambre de la table CompteFournisseurChambre ayant le Courriel entré
        /// </summary>
        /// <param name="courriel">Particulier à vérifier</param>
        /// <returns>La liste des CompteFournisseurChambre du courriel; une liste vide sinon</returns>
        public DataSet FindByCourriel(string courriel)
        {
            DataSet dataset = null;
            try
            {
                using (MySqlConnection connection = connexion.getConnexion())
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(CompteFournisseurChambreDAO.FIND_BY_COURRIEL, connection))
                    {
                        command.Prepare();
                        command.Parameters.AddWithValue("Courriel", courriel);
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

        /// <summary>
        /// Authentifie un utilisateur qui a un CompteFournisseurChambre
        /// </summary>
        /// <param name="compteFournisseurChambreDTO">l'utilisateur qu'on veut authentifier</param>
        /// <returns>une instance de CompteFournisseurChambreDTO; null sinon</returns>
        public CompteFournisseurChambreDTO Authenticate(CompteFournisseurChambreDTO compteFournisseurChambreDTO) {
            CompteFournisseurChambreDTO retourCompteFournisseurChambreDTO = null;
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(CompteFournisseurChambreDAO.AUTHENTICATE_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("Courriel", compteFournisseurChambreDTO.Courriel);
                        command.Parameters.AddWithValue("Password", compteFournisseurChambreDTO.Password);
                        using (MySqlDataReader reader = command.ExecuteReader()) {
                            if (reader.Read()) {
                                retourCompteFournisseurChambreDTO = new CompteFournisseurChambreDTO();
                                retourCompteFournisseurChambreDTO.IdFournisseur = reader.GetInt32("IdFournisseur");
                                retourCompteFournisseurChambreDTO.Courriel = reader.GetString("Courriel");
                                retourCompteFournisseurChambreDTO.Password = reader.GetString("Password");
                                retourCompteFournisseurChambreDTO.IdHotel = reader.GetInt32("IdHotel");
                            }
                        }
                    }
                }
            }
            catch (MySqlException mysqlException) {
                throw new VoyageAhuntsicException(1, VoyageAhuntsicException.CharteErreur[1], mysqlException);
            }
            return retourCompteFournisseurChambreDTO;
        }

    }
}
