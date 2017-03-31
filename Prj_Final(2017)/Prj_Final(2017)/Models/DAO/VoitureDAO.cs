using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using Prj_Final_2017_.DTO;
using Prj_Final_2017_.Models.Exception;

namespace Prj_Final_2017_.Models.DAO {
    public class VoitureDAO {

        /* **********************************
         * *** Pour ctrl + F rapidement : ***
         * **********************************
         * 
         * VoitureDAO = nom du dao de la table
         * VoitureDTO = nom du DTO de la table
         * voitureDTO = instance de VoitureDTO
         * Voiture = nom de la table dans la BD (requête)
         * IdVoiture = champ d'ID de la table
         * Type = 1er champ de la table
         * IdAgence = 2ième champ de la table
         * Tarif = 3ième champ de la table
         * NbPassager = 4ième champ de la table
         * Nom = 5ième champ de la table
         * Plaque = 5ième champ de la table
         * 
         * (les nom de champ doivent être pareil dans la BD et la classe DTO)
         * 
         */


        Connexion.Connexion connexion;
        private static readonly string INSERT_QUERY = "INSERT INTO Voiture(`Type`, `IdAgence`, `Tarif`, `NbPassager`, `Nom`, `Plaque`) VALUES(@Type, @IdAgence, @Tarif, @NbPassager, @Plaque, @Plaque)";
        private static readonly string READ_QUERY = "SELECT `IdVoiture`, `Type`, `IdAgence`, `Tarif`, `NbPassager`, `Nom`, `Plaque` FROM Voiture WHERE `IdVoiture` = @IdVoiture";
        private static readonly string UPDATE_QUERY = "UPDATE Voiture SET `Type` = @Type, `IdAgence` = @IdAgence, `Tarif` = @Tarif, `NbPassager` = @NbPassager, `Nom` = @Nom, `Plaque` = @Plaque WHERE `IdVoiture` = @IdVoiture";
        private static readonly string DELETE_QUERY = "DELETE FROM Voiture WHERE `IdVoiture` = @IdVoiture";
        private static readonly string GET_ALL_QUERY = "SELECT `IdVoiture`, `Type`, `IdAgence`, `Tarif`, `NbPassager`, `Nom`, `Plaque` FROM Voiture";

        public VoitureDAO() {
            connexion = new Connexion.Connexion();
        }

        /// <summary>
        /// Fait un Insert dans la BD sur la table Voiture
        /// </summary>
        /// <param name="voitureDTO">Voiture a ajouter</param>
        public void Add(VoitureDTO voitureDTO) {
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(VoitureDAO.INSERT_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("Type", voitureDTO.Type);
                        command.Parameters.AddWithValue("IdAgence", voitureDTO.IdAgence);
                        command.Parameters.AddWithValue("Tarif", voitureDTO.Tarif);
                        command.Parameters.AddWithValue("NbPassager", voitureDTO.NbPassager);
                        command.Parameters.AddWithValue("Nom", voitureDTO.Nom);
                        command.Parameters.AddWithValue("Plaque", voitureDTO.Plaque);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException mysqlException) {
                throw new VoyageAhuntsicException(1234,VoyageAhuntsicException.CharteErreur[1234],mysqlException);
            }
        }

        /// <summary>
        /// Fait un Read dans la BD sur la table Voiture
        /// </summary>
        /// <param name="IdVoiture">l'id de Voiture que l'on veut read</param>
        /// <returns>une instance de VoitureDTO; null sinon</returns>
        public VoitureDTO Read(int IdVoiture) {
            VoitureDTO voitureDTO = null;
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(VoitureDAO.READ_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("IdVoiture", IdVoiture);
                        using (MySqlDataReader reader = command.ExecuteReader()) {
                            if (reader.Read()) {
                                voitureDTO = new VoitureDTO();
                                voitureDTO.IdVoiture = reader.GetInt32("IdVoiture");
                                voitureDTO.Type = reader.GetString("Type");
                                voitureDTO.IdAgence = reader.GetInt32("IdAgence");
                                voitureDTO.Tarif = reader.GetInt32("Tarif");
                                voitureDTO.NbPassager = reader.GetInt32("NbPassager");
                                voitureDTO.Nom = reader.GetString("Nom");
                                voitureDTO.Plaque = reader.GetString("Plaque");
                            }
                        }
                    }
                }
            }
            catch (MySqlException mysqlException) {
                throw new VoyageAhuntsicException(1234,VoyageAhuntsicException.CharteErreur[1234],mysqlException);
            }
            return voitureDTO;
        }

        /// <summary>
        /// Fait un Update dans la BD sur la table Voiture
        /// </summary>
        /// <param name="voitureDTO">Voiture a modifier</param>
        public void Update(VoitureDTO voitureDTO) {
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(VoitureDAO.UPDATE_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("Type", voitureDTO.Type);
                        command.Parameters.AddWithValue("IdAgence", voitureDTO.IdAgence);
                        command.Parameters.AddWithValue("Tarif", voitureDTO.Tarif);
                        command.Parameters.AddWithValue("NbPassager", voitureDTO.NbPassager);
                        command.Parameters.AddWithValue("Nom", voitureDTO.Nom);
                        command.Parameters.AddWithValue("Plaque", voitureDTO.Plaque);
                        command.Parameters.AddWithValue("IdVoiture", voitureDTO.IdVoiture);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException mysqlException) {
                throw new VoyageAhuntsicException(1234,VoyageAhuntsicException.CharteErreur[1234],mysqlException);
            }
        }

        /// <summary>
        /// Fait un Delete dans la BD sur la table Voiture
        /// </summary>
        /// <param name="voitureDTO">Voiture a supprimer</param>
        public void Delete(VoitureDTO voitureDTO) {
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(VoitureDAO.DELETE_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("IdVoiture", voitureDTO.IdVoiture);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException mysqlException) {
                throw new VoyageAhuntsicException(1234,VoyageAhuntsicException.CharteErreur[1234],mysqlException);
            }
        }

        /// <summary>
        /// Retourne la liste de tous les Voitures de la table Voiture
        /// </summary>
        /// <returns>La liste de tous les Voitures; une liste vide sinon</returns>
        public DataSet GetAll() {
            DataSet dataset = null;
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(VoitureDAO.GET_ALL_QUERY, connection)) {
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
