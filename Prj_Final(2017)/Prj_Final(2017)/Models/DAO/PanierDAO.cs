using MySql.Data.MySqlClient;
using Prj_Final_2017_.Models.DTO;
using Prj_Final_2017_.Models.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prj_Final_2017_.Models.DAO
{
    public class PanierDAO
    {
        Connexion.Connexion connexion;
        private static readonly string INSERT_QUERY = "INSERT INTO Panier(`Information`, `Prix`, `Quantite`) VALUES(@information, @prix, @quantite)";
        private static readonly string READ_QUERY = "SELECT `IdPanier`, `Information`, `Prix`, `Quantite` FROM Panier WHERE `IdPanier` = @idPanier";
        private static readonly string DELETE_QUERY = "DELETE FROM Panier WHERE `IdPanier` = @idPanier";

        public PanierDAO()
        {
            connexion = new Connexion.Connexion();
        }

        /// <summary>
        /// Fait un Insert dans la BD sur la table Panier
        /// </summary>
        /// <param name="panierDTO">Siege a ajouter</param>
        public void Add(PanierDTO panierDTO)
        {
            try
            {
                using (MySqlConnection connection = connexion.getConnexion())
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(PanierDAO.INSERT_QUERY, connection))
                    {
                        command.Prepare();
                        command.Parameters.AddWithValue("@information", panierDTO.Information);
                        command.Parameters.AddWithValue("@prix", panierDTO.Prix);
                        command.Parameters.AddWithValue("@quantite", panierDTO.Quantite);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException mysqlException)
            {
                throw new VoyageAhuntsicException(1, VoyageAhuntsicException.CharteErreur[1], mysqlException);
            }
        }

        /// <summary>
        /// Fait un Read dans la BD sur la table Panier
        /// </summary>
        /// <param name="IdPanier">l'id de l'item du panier que l'on veut read</param>
        /// <returns>une instance de SiegeDTO; null sinon</returns>
        public PanierDTO Read(int IdPanier)
        {
            PanierDTO panierDTO = null;
            try
            {
                using (MySqlConnection connection = connexion.getConnexion())
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(PanierDAO.READ_QUERY, connection))
                    {
                        command.Prepare();
                        command.Parameters.AddWithValue("@idPanier", IdPanier);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                panierDTO = new PanierDTO();
                                panierDTO.IdPanier = reader.GetInt32("IdPanier");
                                panierDTO.Information = reader.GetString("Information");
                                panierDTO.Prix = reader.GetDouble("Prix");
                                panierDTO.Quantite = reader.GetInt32("Quantite");
                            }
                        }
                    }
                }
            }
            catch (MySqlException mysqlException)
            {
                throw new VoyageAhuntsicException(1, VoyageAhuntsicException.CharteErreur[1], mysqlException);
            }
            return panierDTO;
        }

        /// <summary>
        /// Fait un Delete dans la BD sur la table Panier(Enlever un Item)
        /// </summary>
        /// <param name="panierDTO">Item du panier a supprimer</param>
        public void Delete(PanierDTO panierDTO)
        {
            try
            {
                using (MySqlConnection connection = connexion.getConnexion())
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(PanierDAO.DELETE_QUERY, connection))
                    {
                        command.Prepare();
                        command.Parameters.AddWithValue("@idPanier", panierDTO.IdPanier);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException mysqlException)
            {
                throw new VoyageAhuntsicException(1, VoyageAhuntsicException.CharteErreur[1], mysqlException);
            }
        }
    }
}