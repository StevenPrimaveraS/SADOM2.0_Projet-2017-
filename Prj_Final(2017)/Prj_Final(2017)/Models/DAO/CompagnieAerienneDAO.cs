using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using Prj_Final_2017_.DTO;
using Prj_Final_2017_.Models.DTO;
using Prj_Final_2017_.Models.Exception;

namespace Prj_Final_2017_.Models.DAO {
    public class CompagnieAerienneDAO {

        /* **********************************
         * *** Pour ctrl + F rapidement : ***
         * **********************************
         * 
         * CompagnieAerienneDAO = nom du dao de la table
         * CompagnieAerienneDTO = nom du DTO de la table
         * compagnieAerienneDTO = instance de CompagnieAerienneDTO
         * CompagnieAerienne = nom de la table dans la BD (requête)
         * IdCompagnieAerienne = champ d'ID de la table
         * Nom = 1er champ de la table
         * Telephone = 2ième champ de la table
         * Adresse = 3ième champ de la table
         * Ville = 4ième champ de la table
         * champ5 = 5ième champ de la table
         * 
         * (les nom de champ doivent être pareil dans la BD et la classe DTO)
         * 
         */


        Connexion.Connexion connexion;
        private static readonly string INSERT_QUERY = "INSERT INTO CompagnieAerienne(`Nom`, `Telephone`, `Adresse`, `Ville`) VALUES(@Nom, @Telephone, @Adresse, @Ville)";
        private static readonly string READ_QUERY = "SELECT `IdCompagnieAerienne`, `Nom`, `Telephone`, `Adresse`, `Ville` FROM CompagnieAerienne WHERE `IdCompagnieAerienne` = @IdCompagnieAerienne";
        private static readonly string UPDATE_QUERY = "UPDATE CompagnieAerienne SET `Nom` = @Nom, `Telephone` = @Telephone, `Adresse` = @Adresse, `Ville` = @Ville WHERE `IdCompagnieAerienne` = @IdCompagnieAerienne";
        private static readonly string DELETE_QUERY = "DELETE FROM CompagnieAerienne WHERE `IdCompagnieAerienne` = @IdCompagnieAerienne";
        private static readonly string GET_ALL_QUERY = "SELECT `IdCompagnieAerienne`, `Nom`, `Telephone`, `Adresse`, `Ville` FROM CompagnieAerienne";

        public CompagnieAerienneDAO() {
            connexion = new Connexion.Connexion();
        }

        /// <summary>
        /// Fait un Insert dans la BD sur la table CompagnieAerienne
        /// </summary>
        /// <param name="compagnieAerienneDTO">CompagnieAerienne a ajouter</param>
        public void Add(CompagnieAerienneDTO compagnieAerienneDTO) {
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(CompagnieAerienneDAO.INSERT_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("Nom", compagnieAerienneDTO.Nom);
                        command.Parameters.AddWithValue("Telephone", compagnieAerienneDTO.Telephone);
                        command.Parameters.AddWithValue("Adresse", compagnieAerienneDTO.Adresse);
                        command.Parameters.AddWithValue("Ville", compagnieAerienneDTO.Ville);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException mysqlException) {
                throw new VoyageAhuntsicException(1234,VoyageAhuntsicException.CharteErreur[1234],mysqlException);
            }
        }

        /// <summary>
        /// Fait un Read dans la BD sur la table CompagnieAerienne
        /// </summary>
        /// <param name="IdCompagnieAerienne">l'id de CompagnieAerienne que l'on veut read</param>
        /// <returns>une instance de CompagnieAerienneDTO; null sinon</returns>
        public CompagnieAerienneDTO Read(int IdCompagnieAerienne) {
            CompagnieAerienneDTO compagnieAerienneDTO = null;
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(CompagnieAerienneDAO.READ_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("IdCompagnieAerienne", IdCompagnieAerienne);
                        using (MySqlDataReader reader = command.ExecuteReader()) {
                            if (reader.Read()) {
                                compagnieAerienneDTO = new CompagnieAerienneDTO();
                                compagnieAerienneDTO.IdCompagnieAerienne = reader.GetInt32("IdCompagnieAerienne");
                                compagnieAerienneDTO.Nom = reader.GetString("Nom");
                                compagnieAerienneDTO.Telephone = reader.GetString("Telephone");
                                compagnieAerienneDTO.Adresse = reader.GetString("Adresse");
                                compagnieAerienneDTO.Ville = reader.GetString("Ville");
                            }
                        }
                    }
                }
            }
            catch (MySqlException mysqlException) {
                throw new VoyageAhuntsicException(1234,VoyageAhuntsicException.CharteErreur[1234],mysqlException);
            }
            return compagnieAerienneDTO;
        }

        /// <summary>
        /// Fait un Update dans la BD sur la table CompagnieAerienne
        /// </summary>
        /// <param name="compagnieAerienneDTO">CompagnieAerienne a modifier</param>
        public void Update(CompagnieAerienneDTO compagnieAerienneDTO) {
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(CompagnieAerienneDAO.UPDATE_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("Nom", compagnieAerienneDTO.Nom);
                        command.Parameters.AddWithValue("Telephone", compagnieAerienneDTO.Telephone);
                        command.Parameters.AddWithValue("Adresse", compagnieAerienneDTO.Adresse);
                        command.Parameters.AddWithValue("Ville", compagnieAerienneDTO.Ville);
                        command.Parameters.AddWithValue("IdCompagnieAerienne", compagnieAerienneDTO.IdCompagnieAerienne);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException mysqlException) {
                throw new VoyageAhuntsicException(1234,VoyageAhuntsicException.CharteErreur[1234],mysqlException);
            }
        }

        /// <summary>
        /// Fait un Delete dans la BD sur la table CompagnieAerienne
        /// </summary>
        /// <param name="compagnieAerienneDTO">CompagnieAerienne a supprimer</param>
        public void Delete(CompagnieAerienneDTO compagnieAerienneDTO) {
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(CompagnieAerienneDAO.DELETE_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("IdCompagnieAerienne", compagnieAerienneDTO.IdCompagnieAerienne);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException mysqlException) {
                throw new VoyageAhuntsicException(1234,VoyageAhuntsicException.CharteErreur[1234],mysqlException);
            }
        }

        /// <summary>
        /// Retourne la liste de tous les CompagnieAeriennes de la table CompagnieAerienne
        /// </summary>
        /// <returns>La liste de tous les CompagnieAeriennes; une liste vide sinon</returns>
        public DataSet GetAll() {
            DataSet dataset = null;
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(CompagnieAerienneDAO.GET_ALL_QUERY, connection)) {
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
