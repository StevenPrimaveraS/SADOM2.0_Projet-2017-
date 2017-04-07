using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using Prj_Final_2017_.DTO;
using Prj_Final_2017_.Models.Exception;

namespace Prj_Final_2017_.Models.DAO {
    public class VolDAO {

        /* **********************************
         * *** Pour ctrl + F rapidement : ***
         * **********************************
         * 
         * VolDAO = nom du dao de la table
         * VolDTO = nom du DTO de la table
         * volDTO = instance de VolDTO
         * Vol = nom de la table dans la BD (requête)
         * IdVol = champ d'ID de la table
         * AeroportDepart = 1er champ de la table
         * AeroportDestination = 2ième champ de la table
         * VilleDepart = 3ième champ de la table
         * VilleDestination = 4ième champ de la table
         * DateDepart = 5ième champ de la table
         * DateArrivee = 6ième champ de la table
         * IdCompagnieAerienne = 7ième champ de la table
         * Classe = 8ième champ de la table
         * IsRemboursable = 9ième champ de la table
         * Tarif = 10ième champ de la table
         * 
         * (les nom de champ doivent être pareil dans la BD et la classe DTO)
         * 
         */


        Connexion.Connexion connexion;
        private static readonly string INSERT_QUERY = "INSERT INTO Vol(`AeroportDepart`, `AeroportDestination`, `VilleDepart`, `VilleDestination`, `DateDepart`, `DateArrivee`, `IdCompagnieAerienne`, `Classe`, `IsRemboursable`, `Tarif`) VALUES(@AeroportDepart, @AeroportDestination, @VilleDepart, @VilleDestination, @DateDepart, @DateArrivee, @IdCompagnieAerienne, @Classe, @IsRemboursable, @Tarif)";
        private static readonly string READ_QUERY = "SELECT `IdVol`, `AeroportDepart`, `AeroportDestination`, `VilleDepart`, `VilleDestination`, `DateDepart`, `DateArrivee`, `IdCompagnieAerienne`, `Classe`, `IsRemboursable`, `Tarif` FROM Vol WHERE `IdVol` = @IdVol";
        private static readonly string UPDATE_QUERY = "UPDATE Vol SET `AeroportDepart` = @AeroportDepart, `AeroportDestination` = @AeroportDestination, `VilleDepart` = @VilleDepart, `VilleDestination` = @VilleDestination, `DateDepart` = @DateDepart, `DateArrivee` = @DateArrivee, `IdCompagnieAerienne` = @IdCompagnieAerienne, `Classe` = @Classe, `IsRemboursable` = @IsRemboursable, `Tarif` = @Tarif WHERE `IdVol` = @IdVol";
        private static readonly string DELETE_QUERY = "DELETE FROM Vol WHERE `IdVol` = @IdVol";
        private static readonly string GET_ALL_QUERY = "SELECT `IdVol`, `AeroportDepart`, `AeroportDestination`, `VilleDepart`, `VilleDestination`, `DateDepart`, `DateArrivee`, `IdCompagnieAerienne`, `Classe`, `IsRemboursable`, `Tarif` FROM Vol";

        public VolDAO() {
            connexion = new Connexion.Connexion();
        }

        /// <summary>
        /// Fait un Insert dans la BD sur la table Vol
        /// </summary>
        /// <param name="volDTO">Vol a ajouter</param>
        public void Add(VolDTO volDTO) {
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(VolDAO.INSERT_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("AeroportDepart", volDTO.AeroportDepart);
                        command.Parameters.AddWithValue("AeroportDestination", volDTO.AeroportDestination);
                        command.Parameters.AddWithValue("VilleDepart", volDTO.VilleDepart);
                        command.Parameters.AddWithValue("VilleDestination", volDTO.VilleDestination);
                        command.Parameters.AddWithValue("DateDepart", volDTO.DateDepart);
                        command.Parameters.AddWithValue("DateArrivee", volDTO.DateArrivee);
                        command.Parameters.AddWithValue("IdCompagnieAerienne", volDTO.IdCompagnieAerienne);
                        command.Parameters.AddWithValue("Classe", volDTO.Classe);
                        command.Parameters.AddWithValue("IsRemboursable", volDTO.IsRemboursable);
                        command.Parameters.AddWithValue("Tarif", volDTO.Tarif);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException mysqlException) {
                throw new VoyageAhuntsicException(1234,VoyageAhuntsicException.CharteErreur[1234],mysqlException);
            }
        }

        /// <summary>
        /// Fait un Read dans la BD sur la table Vol
        /// </summary>
        /// <param name="IdVol">l'id de Vol que l'on veut read</param>
        /// <returns>une instance de VolDTO; null sinon</returns>
        public VolDTO Read(int IdVol) {
            VolDTO volDTO = null;
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(VolDAO.READ_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("IdVol", IdVol);
                        using (MySqlDataReader reader = command.ExecuteReader()) {
                            if (reader.Read()) {
                                volDTO = new VolDTO();
                                volDTO.IdVol = reader.GetInt32("IdVol");
                                volDTO.AeroportDepart = reader.GetString("AeroportDepart");
                                volDTO.AeroportDestination = reader.GetString("AeroportDestination");
                                volDTO.VilleDepart = reader.GetString("VilleDepart");
                                volDTO.VilleDestination = reader.GetString("VilleDestination");
                                volDTO.DateDepart = reader.GetDateTime("DateDepart");
                                volDTO.DateArrivee = reader.GetDateTime("DateArrivee");
                                volDTO.IdCompagnieAerienne = reader.GetInt32("IdCompagnieAerienne");
                                volDTO.Classe = reader.GetString("Classe");
                                volDTO.IsRemboursable = reader.GetBoolean("IsRemboursable");
                                volDTO.Tarif = reader.GetDouble("Tarif");
                            }
                        }
                    }
                }
            }
            catch (MySqlException mysqlException) {
                throw new VoyageAhuntsicException(1234,VoyageAhuntsicException.CharteErreur[1234],mysqlException);
            }
            return volDTO;
        }

        /// <summary>
        /// Fait un Update dans la BD sur la table Vol
        /// </summary>
        /// <param name="volDTO">Vol a modifier</param>
        public void Update(VolDTO volDTO) {
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(VolDAO.UPDATE_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("AeroportDepart", volDTO.AeroportDepart);
                        command.Parameters.AddWithValue("AeroportDestination", volDTO.AeroportDestination);
                        command.Parameters.AddWithValue("VilleDepart", volDTO.VilleDepart);
                        command.Parameters.AddWithValue("VilleDestination", volDTO.VilleDestination);
                        command.Parameters.AddWithValue("DateDepart", volDTO.DateDepart);
                        command.Parameters.AddWithValue("DateArrivee", volDTO.DateArrivee);
                        command.Parameters.AddWithValue("IdCompagnieAerienne", volDTO.IdCompagnieAerienne);
                        command.Parameters.AddWithValue("Classe", volDTO.Classe);
                        command.Parameters.AddWithValue("IsRemboursable", volDTO.IsRemboursable);
                        command.Parameters.AddWithValue("Tarif", volDTO.Tarif);
                        command.Parameters.AddWithValue("IdVol", volDTO.IdVol);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException mysqlException) {
                throw new VoyageAhuntsicException(1234,VoyageAhuntsicException.CharteErreur[1234],mysqlException);
            }
        }

        /// <summary>
        /// Fait un Delete dans la BD sur la table Vol
        /// </summary>
        /// <param name="volDTO">Vol a supprimer</param>
        public void Delete(VolDTO volDTO) {
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(VolDAO.DELETE_QUERY, connection)) {
                        command.Prepare();
                        command.Parameters.AddWithValue("IdVol", volDTO.IdVol);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException mysqlException) {
                throw new VoyageAhuntsicException(1234,VoyageAhuntsicException.CharteErreur[1234],mysqlException);
            }
        }

        /// <summary>
        /// Retourne la liste de tous les Vols de la table Vol
        /// </summary>
        /// <returns>La liste de tous les Vols; une liste vide sinon</returns>
        public DataSet GetAll() {
            DataSet dataset = null;
            try {
                using (MySqlConnection connection = connexion.getConnexion()) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(VolDAO.GET_ALL_QUERY, connection)) {
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
