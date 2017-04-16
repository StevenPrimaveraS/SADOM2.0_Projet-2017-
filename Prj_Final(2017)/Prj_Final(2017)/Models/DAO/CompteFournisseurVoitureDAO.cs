using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using Prj_Final_2017_.DTO;
using Prj_Final_2017_.Models.Exception;

namespace Prj_Final_2017_.Models.DAO {
    public class CompteFournisseurVoitureDAO {

        /* **********************************
         * *** Pour ctrl + F rapidement : ***
         * **********************************
         * 
         * CompteFournisseurVoitureDAO = nom du dao de la table
         * CompteFournisseurVoitureDTO = nom du DTO de la table
         * compteFournisseurVoitureDTO = instance de CompteFournisseurVoitureDTO
         * CompteFournisseurVoiture = nom de la table dans la BD (requête)
         * IdFournisseur = champ d'ID de la table
         * Courriel = 1er champ de la table
         * Password = 2ième champ de la table
         * IdAgenceVoiture = 3ième champ de la table
         * champ4 = 4ième champ de la table
         * champ5 = 5ième champ de la table
         * 
         * (les nom de champ doivent être pareil dans la BD et la classe DTO)
         * 
         */


        Connexion.Connexion connexion;
        private static readonly string INSERT_QUERY = "INSERT INTO CompteFournisseurVoiture(`Courriel`, `Password`, `IdAgenceVoiture`) VALUES(@Courriel, @Password, @IdAgenceVoiture)";
        private static readonly string READ_QUERY = "SELECT `IdFournisseur`, `Courriel`, `Password`, `IdAgenceVoiture` FROM CompteFournisseurVoiture WHERE `IdFournisseur` = @IdFournisseur";
        private static readonly string UPDATE_QUERY = "UPDATE CompteFournisseurVoiture SET `Courriel` = @Courriel, `Password` = @Password, `IdAgenceVoiture` = @IdAgenceVoiture WHERE `IdFournisseur` = @IdFournisseur";
        private static readonly string DELETE_QUERY = "DELETE FROM CompteFournisseurVoiture WHERE `IdFournisseur` = @IdFournisseur";
        private static readonly string GET_ALL_QUERY = "SELECT `IdFournisseur`, `Courriel`, `Password`, `IdAgenceVoiture` FROM CompteFournisseurVoiture";
        private static readonly string FIND_BY_COURRIEL = "SELECT 'IdFournisseur', `Courriel`, `Password`, `IdAgenceVoiture` FROM CompteFournisseurVoiture WHERE `Courriel` = @Courriel";
        private static readonly string AUTHENTICATE_QUERY = "SELECT 'IdFournisseur', `Courriel`, `Password`, `IdAgenceVoiture` FROM CompteFournisseurVoiture WHERE `Courriel` = @Courriel AND `Password` = @Password";

        public CompteFournisseurVoitureDAO() {
            connexion = new Connexion.Connexion();
        }

        /// <summary>
        /// Fait un Insert dans la BD sur la table CompteFournisseurVoiture
        /// </summary>
        /// <param name="compteFournisseurVoitureDTO">CompteFournisseurVoiture a ajouter</param>
        public void Add(CompteFournisseurVoitureDTO compteFournisseurVoitureDTO) {
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(CompteFournisseurVoitureDAO.INSERT_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("Courriel", compteFournisseurVoitureDTO.Courriel);
                        command.Parameters.AddWithValue("Password", compteFournisseurVoitureDTO.Password);
                        command.Parameters.AddWithValue("IdAgenceVoiture", compteFournisseurVoitureDTO.IdAgenceVoiture);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException mysqlException) {
                throw new VoyageAhuntsicException(1234,VoyageAhuntsicException.CharteErreur[1234],mysqlException);
            }
        }

        /// <summary>
        /// Fait un Read dans la BD sur la table CompteFournisseurVoiture
        /// </summary>
        /// <param name="IdFournisseur">l'id de CompteFournisseurVoiture que l'on veut read</param>
        /// <returns>une instance de CompteFournisseurVoitureDTO; null sinon</returns>
        public CompteFournisseurVoitureDTO Read(int IdFournisseur) {
            CompteFournisseurVoitureDTO compteFournisseurVoitureDTO = null;
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(CompteFournisseurVoitureDAO.READ_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("IdFournisseur", IdFournisseur);
                        using (MySqlDataReader reader = command.ExecuteReader()) {
                            if (reader.Read()) {
                                compteFournisseurVoitureDTO = new CompteFournisseurVoitureDTO();
                                compteFournisseurVoitureDTO.IdFournisseur = reader.GetInt32("IdFournisseur");
                                compteFournisseurVoitureDTO.Courriel = reader.GetString("Courriel");
                                compteFournisseurVoitureDTO.Password = reader.GetString("Password");
                                compteFournisseurVoitureDTO.IdAgenceVoiture = reader.GetInt32("IdAgenceVoiture");
                            }
                        }
                    }
                }
            }
            catch (MySqlException mysqlException) {
                throw new VoyageAhuntsicException(1234,VoyageAhuntsicException.CharteErreur[1234],mysqlException);
            }
            return compteFournisseurVoitureDTO;
        }

        /// <summary>
        /// Fait un Update dans la BD sur la table CompteFournisseurVoiture
        /// </summary>
        /// <param name="compteFournisseurVoitureDTO">CompteFournisseurVoiture a modifier</param>
        public void Update(CompteFournisseurVoitureDTO compteFournisseurVoitureDTO) {
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(CompteFournisseurVoitureDAO.UPDATE_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("Courriel", compteFournisseurVoitureDTO.Courriel);
                        command.Parameters.AddWithValue("Password", compteFournisseurVoitureDTO.Password);
                        command.Parameters.AddWithValue("IdAgenceVoiture", compteFournisseurVoitureDTO.IdAgenceVoiture);
                        command.Parameters.AddWithValue("IdFournisseur", compteFournisseurVoitureDTO.IdFournisseur);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException mysqlException) {
                throw new VoyageAhuntsicException(1234,VoyageAhuntsicException.CharteErreur[1234],mysqlException);
            }
        }

        /// <summary>
        /// Fait un Delete dans la BD sur la table CompteFournisseurVoiture
        /// </summary>
        /// <param name="compteFournisseurVoitureDTO">CompteFournisseurVoiture a supprimer</param>
        public void Delete(CompteFournisseurVoitureDTO compteFournisseurVoitureDTO) {
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(CompteFournisseurVoitureDAO.DELETE_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("IdFournisseur", compteFournisseurVoitureDTO.IdFournisseur);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException mysqlException) {
                throw new VoyageAhuntsicException(1234,VoyageAhuntsicException.CharteErreur[1234],mysqlException);
            }
        }

        /// <summary>
        /// Retourne la liste de tous les CompteFournisseurVoitures de la table CompteFournisseurVoiture
        /// </summary>
        /// <returns>La liste de tous les CompteFournisseurVoitures; une liste vide sinon</returns>
        public DataSet GetAll() {
            DataSet dataset = null;
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(CompteFournisseurVoitureDAO.GET_ALL_QUERY, connection)) {
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
        /// Retorune la liste de tous les CompteFournisseurVoiture de la table CompteFournisseurVoiture ayant le Courriel entré
        /// </summary>
        /// <param name="courriel">Particulier à vérifier</param>
        /// <returns>La liste des CompteFournisseurVoiture du courriel; une liste vide sinon</returns>
        public DataSet FindByCourriel(string courriel)
        {
            DataSet dataset = null;
            try
            {
                using (MySqlConnection connection = connexion.getConnexion())
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(CompteFournisseurVoitureDAO.FIND_BY_COURRIEL, connection))
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
                throw new VoyageAhuntsicException(4444, VoyageAhuntsicException.CharteErreur[4444], mysqlException);
            }
            return dataset;
        }

        /// <summary>
        /// Authentifie un utilisateur qui a un CompteFournisseurVoiture
        /// </summary>
        /// <param name="compteFournisseurVoitureDTO">l'utilisateur qu'on veut authentifier</param>
        /// <returns>une instance de CompteFournisseurVoitureDTO; null sinon</returns>
        public CompteFournisseurVoitureDTO Authenticate(CompteFournisseurVoitureDTO compteFournisseurVoitureDTO) {
            CompteFournisseurVoitureDTO retourCompteFournisseurVoitureDTO = null;
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(CompteFournisseurVoitureDAO.AUTHENTICATE_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("Courriel", compteFournisseurVoitureDTO.Courriel);
                        command.Parameters.AddWithValue("Password", compteFournisseurVoitureDTO.Password);
                        using (MySqlDataReader reader = command.ExecuteReader()) {
                            if (reader.Read()) {
                                retourCompteFournisseurVoitureDTO = new CompteFournisseurVoitureDTO();
                                retourCompteFournisseurVoitureDTO.IdFournisseur = reader.GetInt32("IdFournisseur");
                                retourCompteFournisseurVoitureDTO.Courriel = reader.GetString("Courriel");
                                retourCompteFournisseurVoitureDTO.Password = reader.GetString("Password");
                                retourCompteFournisseurVoitureDTO.IdAgenceVoiture = reader.GetInt32("IdAgenceVoiture");
                            }
                        }
                    }
                }
            }
            catch (MySqlException mysqlException) {
                throw new VoyageAhuntsicException(1234, VoyageAhuntsicException.CharteErreur[1234], mysqlException);
            }
            return retourCompteFournisseurVoitureDTO;
        }

    }
}
