using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using Prj_Final_2017_.DTO;
using Prj_Final_2017_.Models.Exception;

namespace Prj_Final_2017_.Models.DAO {
    public class CompteParticulierDAO {

        /* **********************************
         * *** Pour ctrl + F rapidement : ***
         * **********************************
         * 
         * CompteParticulierDAO = nom du dao de la table
         * CompteParticulierDTO = nom du DTO de la table
         * compteParticulierDTO = instance de CompteParticulierDTO
         * CompteParticulier = nom de la table dans la BD (requ�te)
         * IdParticulier = champ d'ID de la table
         * Password = 1er champ de la table
         * Prenom = 2i�me champ de la table
         * Nom = 3i�me champ de la table
         * Courriel = 4i�me champ de la table
         * champ5 = 5i�me champ de la table
         * 
         * (les nom de champ doivent �tre pareil dans la BD et la classe DTO)
         * 
         */


        Connexion.Connexion connexion;
        private static readonly string INSERT_QUERY = "INSERT INTO CompteParticulier(`Password`, `Prenom`, `Nom`, `Courriel`) VALUES(@Password, @Prenom, @Nom, @Courriel)";
        private static readonly string READ_QUERY = "SELECT `IdParticulier`, `Password`, `Prenom`, `Nom`, `Courriel` FROM CompteParticulier WHERE `IdParticulier` = @IdParticulier";
        private static readonly string UPDATE_QUERY = "UPDATE CompteParticulier SET `Password` = @Password, `Prenom` = @Prenom, `Nom` = @Nom, `Courriel` = @Courriel WHERE `IdParticulier` = @IdParticulier";
        private static readonly string DELETE_QUERY = "DELETE FROM CompteParticulier WHERE `IdParticulier` = @IdParticulier";
        private static readonly string GET_ALL_QUERY = "SELECT `IdParticulier`, `Password`, `Prenom`, `Nom`, `Courriel` FROM CompteParticulier";
        private static readonly string FIND_BY_COURRIEL = "SELECT `IdParticulier`, `Password`, `Prenom`, `Nom`, `Courriel` FROM CompteParticulier WHERE `Courriel` = @Courriel";
        private static readonly string AUTHENTICATE_QUERY = "SELECT `IdParticulier`, `Password`, `Prenom`, `Nom`, `Courriel` FROM CompteParticulier WHERE `Courriel` = @Courriel AND `Password` = @Password";

        public CompteParticulierDAO() {
            connexion = new Connexion.Connexion();
        }

        /// <summary>
        /// Fait un Insert dans la BD sur la table CompteParticulier
        /// </summary>
        /// <param name="compteParticulierDTO">CompteParticulier a ajouter</param>
        public void Add(CompteParticulierDTO compteParticulierDTO) {
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(CompteParticulierDAO.INSERT_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("Password", compteParticulierDTO.Password);
                        command.Parameters.AddWithValue("Prenom", compteParticulierDTO.Prenom);
                        command.Parameters.AddWithValue("Nom", compteParticulierDTO.Nom);
                        command.Parameters.AddWithValue("Courriel", compteParticulierDTO.Courriel);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException mysqlException) {
                throw new VoyageAhuntsicException(1,VoyageAhuntsicException.CharteErreur[1],mysqlException);
            }
        }

        /// <summary>
        /// Fait un Read dans la BD sur la table CompteParticulier
        /// </summary>
        /// <param name="IdParticulier">l'id de CompteParticulier que l'on veut read</param>
        /// <returns>une instance de CompteParticulierDTO; null sinon</returns>
        public CompteParticulierDTO Read(int IdParticulier) {
            CompteParticulierDTO compteParticulierDTO = null;
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(CompteParticulierDAO.READ_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("IdParticulier", IdParticulier);
                        using (MySqlDataReader reader = command.ExecuteReader()) {
                            if (reader.Read()) {
                                compteParticulierDTO = new CompteParticulierDTO();
                                compteParticulierDTO.IdParticulier = reader.GetInt32("IdParticulier");
                                compteParticulierDTO.Password = reader.GetString("Password");
                                compteParticulierDTO.Prenom = reader.GetString("Prenom");
                                compteParticulierDTO.Nom = reader.GetString("Nom");
                                compteParticulierDTO.Courriel = reader.GetString("Courriel");
                            }
                        }
                    }
                }
            }
            catch (MySqlException mysqlException) {
                throw new VoyageAhuntsicException(1,VoyageAhuntsicException.CharteErreur[1],mysqlException);
            }
            return compteParticulierDTO;
        }

        /// <summary>
        /// Fait un Update dans la BD sur la table CompteParticulier
        /// </summary>
        /// <param name="compteParticulierDTO">CompteParticulier a modifier</param>
        public void Update(CompteParticulierDTO compteParticulierDTO) {
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(CompteParticulierDAO.UPDATE_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("Password", compteParticulierDTO.Password);
                        command.Parameters.AddWithValue("Prenom", compteParticulierDTO.Prenom);
                        command.Parameters.AddWithValue("Nom", compteParticulierDTO.Nom);
                        command.Parameters.AddWithValue("Courriel", compteParticulierDTO.Courriel);
                        command.Parameters.AddWithValue("IdParticulier", compteParticulierDTO.IdParticulier);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException mysqlException) {
                throw new VoyageAhuntsicException(1,VoyageAhuntsicException.CharteErreur[1],mysqlException);
            }
        }

        /// <summary>
        /// Fait un Delete dans la BD sur la table CompteParticulier
        /// </summary>
        /// <param name="compteParticulierDTO">CompteParticulier a supprimer</param>
        public void Delete(CompteParticulierDTO compteParticulierDTO) {
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(CompteParticulierDAO.DELETE_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("IdParticulier", compteParticulierDTO.IdParticulier);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException mysqlException) {
                throw new VoyageAhuntsicException(1,VoyageAhuntsicException.CharteErreur[1],mysqlException);
            }
        }

        /// <summary>
        /// Retourne la liste de tous les CompteParticuliers de la table CompteParticulier
        /// </summary>
        /// <returns>La liste de tous les CompteParticuliers; une liste vide sinon</returns>
        public DataSet GetAll() {
            DataSet dataset = null;
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(CompteParticulierDAO.GET_ALL_QUERY, connection)) {
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
        /// Retorune la liste de tous les CompteParticulier de la table CompteParticulier ayant le Courriel entr�
        /// </summary>
        /// <param name="courriel">Particulier � v�rifier</param>
        /// <returns>La liste des CompteParticulier du courriel; une liste vide sinon</returns>
        public DataSet FindByCourriel(string courriel)
        {
            DataSet dataset = null;
            try
            {
                using (MySqlConnection connection = connexion.getConnexion())
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(CompteParticulierDAO.FIND_BY_COURRIEL, connection))
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
        /// Authentifie un utilisateur qui a un CompteParticulier
        /// </summary>
        /// <param name="compteParticulierDTO">l'utilisateur qu'on veut authentifier</param>
        /// <returns>une instance de CompteParticulierDTO; null sinon</returns>
        public CompteParticulierDTO Authenticate(CompteParticulierDTO compteParticulierDTO) {
            CompteParticulierDTO retourCompteParticulierDTO = null;
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(CompteParticulierDAO.AUTHENTICATE_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("Courriel", compteParticulierDTO.Courriel);
                        command.Parameters.AddWithValue("Password", compteParticulierDTO.Password);
                        using (MySqlDataReader reader = command.ExecuteReader()) {
                            if (reader.Read()) {
                                retourCompteParticulierDTO = new CompteParticulierDTO();
                                retourCompteParticulierDTO.IdParticulier = reader.GetInt32("IdParticulier");
                                retourCompteParticulierDTO.Password = reader.GetString("Password");
                                retourCompteParticulierDTO.Prenom = reader.GetString("Prenom");
                                retourCompteParticulierDTO.Nom = reader.GetString("Nom");
                                retourCompteParticulierDTO.Courriel = reader.GetString("Courriel");
                            }
                        }
                    }
                }
            }
            catch (MySqlException mysqlException) {
                throw new VoyageAhuntsicException(1, VoyageAhuntsicException.CharteErreur[1], mysqlException);
            }
            return retourCompteParticulierDTO;
        }

    }
}
