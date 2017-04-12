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
                throw new VoyageAhuntsicException(1234, VoyageAhuntsicException.CharteErreur[1234], mysqlException);
            }
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
                throw new VoyageAhuntsicException(1234, VoyageAhuntsicException.CharteErreur[1234], mysqlException);
            }
        }
    }
}