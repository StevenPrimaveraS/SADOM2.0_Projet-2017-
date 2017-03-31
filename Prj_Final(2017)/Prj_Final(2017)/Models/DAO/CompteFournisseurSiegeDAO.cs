using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using Prj_Final_2017_.DTO;
using Prj_Final_2017_.Models.Exception;

namespace Prj_Final_2017_.Models.DAO {
    public class CompteFournisseurSiegeDAO {

        /* **********************************
         * *** Pour ctrl + F rapidement : ***
         * **********************************
         * 
         * CompteFournisseurSiegeDAO = nom du dao de la table
         * CompteFournisseurSiegeDTO = nom du DTO de la table
         * compteFournisseurSiegeDTO = instance de CompteFournisseurSiegeDTO
         * CompteFournisseurSiege = nom de la table dans la BD (requête)
         * IdFournisseur = champ d'ID de la table
         * Courriel = 1er champ de la table
         * Password = 2ième champ de la table
         * IdCompagnieAerienne = 3ième champ de la table
         * champ4 = 4ième champ de la table
         * champ5 = 5ième champ de la table
         * 
         * (les nom de champ doivent être pareil dans la BD et la classe DTO)
         * 
         */


        Connexion.Connexion connexion;
        private static readonly string INSERT_QUERY = "INSERT INTO CompteFournisseurSiege(`Courriel`, `Password`, `IdCompagnieAerienne`) VALUES(@Courriel, @Password, @IdCompagnieAerienne)";
        private static readonly string READ_QUERY = "SELECT `IdFournisseur`, `Courriel`, `Password`, `IdCompagnieAerienne` FROM CompteFournisseurSiege WHERE `IdFournisseur` = @IdFournisseur";
        private static readonly string UPDATE_QUERY = "UPDATE CompteFournisseurSiege SET `Courriel` = @Courriel, `Password` = @Password, `IdCompagnieAerienne` = @IdCompagnieAerienne WHERE `IdFournisseur` = @IdFournisseur";
        private static readonly string DELETE_QUERY = "DELETE FROM CompteFournisseurSiege WHERE `IdFournisseur` = @IdFournisseur";
        private static readonly string GET_ALL_QUERY = "SELECT `IdFournisseur`, `Courriel`, `Password`, `IdCompagnieAerienne` FROM CompteFournisseurSiege";

        public CompteFournisseurSiegeDAO() {
            connexion = new Connexion.Connexion();
        }

        /// <summary>
        /// Fait un Insert dans la BD sur la table CompteFournisseurSiege
        /// </summary>
        /// <param name="compteFournisseurSiegeDTO">CompteFournisseurSiege a ajouter</param>
        public void Add(CompteFournisseurSiegeDTO compteFournisseurSiegeDTO) {
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(CompteFournisseurSiegeDAO.INSERT_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("Courriel", compteFournisseurSiegeDTO.Courriel);
                        command.Parameters.AddWithValue("Password", compteFournisseurSiegeDTO.Password);
                        command.Parameters.AddWithValue("IdCompagnieAerienne", compteFournisseurSiegeDTO.IdCompagnieAerienne);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException mysqlException) {
                throw new VoyageAhuntsicException(1234,VoyageAhuntsicException.CharteErreur[1234],mysqlException);
            }
        }

        /// <summary>
        /// Fait un Read dans la BD sur la table CompteFournisseurSiege
        /// </summary>
        /// <param name="IdFournisseur">l'id de CompteFournisseurSiege que l'on veut read</param>
        /// <returns>une instance de CompteFournisseurSiegeDTO; null sinon</returns>
        public CompteFournisseurSiegeDTO Read(int IdFournisseur) {
            CompteFournisseurSiegeDTO compteFournisseurSiegeDTO = null;
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(CompteFournisseurSiegeDAO.READ_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("IdFournisseur", IdFournisseur);
                        using (MySqlDataReader reader = command.ExecuteReader()) {
                            if (reader.Read()) {
                                compteFournisseurSiegeDTO = new CompteFournisseurSiegeDTO();
                                compteFournisseurSiegeDTO.IdFournisseur = reader.GetInt32("IdFournisseur");
                                compteFournisseurSiegeDTO.Courriel = reader.GetString("Courriel");
                                compteFournisseurSiegeDTO.Password = reader.GetString("Password");
                                compteFournisseurSiegeDTO.IdCompagnieAerienne = reader.GetInt32("IdCompagnieAerienne");
                            }
                        }
                    }
                }
            }
            catch (MySqlException mysqlException) {
                throw new VoyageAhuntsicException(1234,VoyageAhuntsicException.CharteErreur[1234],mysqlException);
            }
            return compteFournisseurSiegeDTO;
        }

        /// <summary>
        /// Fait un Update dans la BD sur la table CompteFournisseurSiege
        /// </summary>
        /// <param name="compteFournisseurSiegeDTO">CompteFournisseurSiege a modifier</param>
        public void Update(CompteFournisseurSiegeDTO compteFournisseurSiegeDTO) {
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(CompteFournisseurSiegeDAO.UPDATE_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("Courriel", compteFournisseurSiegeDTO.Courriel);
                        command.Parameters.AddWithValue("Password", compteFournisseurSiegeDTO.Password);
                        command.Parameters.AddWithValue("IdCompagnieAerienne", compteFournisseurSiegeDTO.IdCompagnieAerienne);
                        command.Parameters.AddWithValue("IdFournisseur", compteFournisseurSiegeDTO.IdFournisseur);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException mysqlException) {
                throw new VoyageAhuntsicException(1234,VoyageAhuntsicException.CharteErreur[1234],mysqlException);
            }
        }

        /// <summary>
        /// Fait un Delete dans la BD sur la table CompteFournisseurSiege
        /// </summary>
        /// <param name="compteFournisseurSiegeDTO">CompteFournisseurSiege a supprimer</param>
        public void Delete(CompteFournisseurSiegeDTO compteFournisseurSiegeDTO) {
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(CompteFournisseurSiegeDAO.DELETE_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("IdFournisseur", compteFournisseurSiegeDTO.IdFournisseur);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException mysqlException) {
                throw new VoyageAhuntsicException(1234,VoyageAhuntsicException.CharteErreur[1234],mysqlException);
            }
        }

        /// <summary>
        /// Retourne la liste de tous les CompteFournisseurSieges de la table CompteFournisseurSiege
        /// </summary>
        /// <returns>La liste de tous les CompteFournisseurSieges; une liste vide sinon</returns>
        public DataSet GetAll() {
            DataSet dataset = null;
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(CompteFournisseurSiegeDAO.GET_ALL_QUERY, connection)) {
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
