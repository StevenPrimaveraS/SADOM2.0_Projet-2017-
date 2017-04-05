using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Prj_Final_2017_.Models.DAO;
using Prj_Final_2017_.Models.Service;
using Prj_Final_2017_.Models.Facade;
using Prj_Final_2017_.Models.Exception;

namespace Prj_Final_2017_.Models.util {
    public class ApplicationFunctions {

        public ApplicationFunctions() {
            //pour une instance en tout temps
            if(ApplicationFunctions.CompteParticulierFacade == null) {
                // Initialisation des DAO, Services et Facades
                try {
                    //DAOs
                    CompteFournisseurChambreDAO compteFournisseurChambreDAO = new CompteFournisseurChambreDAO();
                    CompteFournisseurSiegeDAO compteFournisseurSiegeDAO = new CompteFournisseurSiegeDAO();
                    CompteFournisseurVoitureDAO compteFournisseurVoitureDAO = new CompteFournisseurVoitureDAO();
                    CompteParticulierDAO compteParticulierDAO = new CompteParticulierDAO();
                    HotelDAO hotelDAO = new HotelDAO();
                    CompagnieAerienneDAO compagnieAerienneDAO = new CompagnieAerienneDAO();
                    AgenceVoitureDAO agenceVoitureDAO = new AgenceVoitureDAO();
                    ChambreDAO chambreDAO = new ChambreDAO();
                    VolDAO volDAO = new VolDAO();
                    SiegeDAO siegeDAO = new SiegeDAO();
                    VoitureDAO voitureDAO = new VoitureDAO();
                    ForfaitDAO forfaitDAO = new ForfaitDAO();
                    ReservationChambreDAO reservationChambreDAO = new ReservationChambreDAO();
                    ReservationSiegeDAO reservationSiegeDAO = new ReservationSiegeDAO();
                    ReservationVoitureDAO reservationVoitureDAO = new ReservationVoitureDAO();
                    ReservationForfaitDAO reservationForfaitDAO = new ReservationForfaitDAO();
                    //Services
                    CompteFournisseurChambreService compteFournisseurChambreService = new CompteFournisseurChambreService(compteFournisseurChambreDAO);
                    CompteFournisseurSiegeService compteFournisseurSiegeService = new CompteFournisseurSiegeService(compteFournisseurSiegeDAO);
                    CompteFournisseurVoitureService compteFournisseurVoitureService = new CompteFournisseurVoitureService(compteFournisseurVoitureDAO);
                    CompteParticulierService compteParticulierService = new CompteParticulierService(compteParticulierDAO, reservationChambreDAO, reservationForfaitDAO, reservationSiegeDAO, reservationVoitureDAO);
                    HotelService hotelService = new HotelService(hotelDAO, chambreDAO, compteFournisseurChambreDAO);
                    CompagnieAerienneService compagnieAerienneService = new CompagnieAerienneService(compagnieAerienneDAO);
                    AgenceVoitureService agenceVoitureService = new AgenceVoitureService(agenceVoitureDAO);
                    ChambreService chambreService = new ChambreService(chambreDAO,hotelDAO,compteFournisseurChambreDAO);
                    VolService volService = new VolService(volDAO,siegeDAO);
                    SiegeService siegeService = new SiegeService(siegeDAO);
                    VoitureService voitureService = new VoitureService(voitureDAO,compteFournisseurVoitureDAO);
                    ForfaitService forfaitService = new ForfaitService(forfaitDAO);
                    ReservationChambreService reservationChambreService = new ReservationChambreService(reservationChambreDAO, chambreDAO, compteParticulierDAO);
                    ReservationSiegeService reservationSiegeService = new ReservationSiegeService(reservationSiegeDAO, siegeDAO, compteParticulierDAO);
                    ReservationVoitureService reservationVoitureService = new ReservationVoitureService(reservationVoitureDAO, voitureDAO, compteParticulierDAO);
                    ReservationForfaitService reservationForfaitService = new ReservationForfaitService(reservationForfaitDAO, forfaitDAO, compteParticulierDAO);
                    //Facades
                    CompteFournisseurChambreFacade compteFournisseurChambreFacade = new CompteFournisseurChambreFacade(compteFournisseurChambreService);
                    CompteFournisseurSiegeFacade compteFournisseurSiegeFacade = new CompteFournisseurSiegeFacade(compteFournisseurSiegeService);
                    CompteFournisseurVoitureFacade compteFournisseurVoitureFacade = new CompteFournisseurVoitureFacade(compteFournisseurVoitureService);
                    CompteParticulierFacade compteParticulierFacade = new CompteParticulierFacade(compteParticulierService);
                    HotelFacade hotelFacade = new HotelFacade(hotelService);
                    CompagnieAerienneFacade compagnieAerienneFacade = new CompagnieAerienneFacade(compagnieAerienneService);
                    AgenceVoitureFacade agenceVoitureFacade = new AgenceVoitureFacade(agenceVoitureService);
                    ChambreFacade chambreFacade = new ChambreFacade(chambreService);
                    VolFacade volFacade = new VolFacade(volService);
                    SiegeFacade siegeFacade = new SiegeFacade(siegeService);
                    VoitureFacade voitureFacade = new VoitureFacade(voitureService);
                    ForfaitFacade forfaitFacade = new ForfaitFacade(forfaitService);
                    ReservationChambreFacade reservationChambreFacade = new ReservationChambreFacade(reservationChambreService);
                    ReservationSiegeFacade reservationSiegeFacade = new ReservationSiegeFacade(reservationSiegeService);
                    ReservationVoitureFacade reservationVoitureFacade = new ReservationVoitureFacade(reservationVoitureService);
                    ReservationForfaitFacade reservationForfaitFacade = new ReservationForfaitFacade(reservationForfaitService);

                    ApplicationFunctions.CompteFournisseurChambreFacade = compteFournisseurChambreFacade;
                    ApplicationFunctions.CompteFournisseurSiegeFacade = compteFournisseurSiegeFacade;
                    ApplicationFunctions.CompteFournisseurVoitureFacade = compteFournisseurVoitureFacade;
                    ApplicationFunctions.CompteParticulierFacade = compteParticulierFacade;
                    ApplicationFunctions.HotelFacade = hotelFacade;
                    ApplicationFunctions.CompagnieAerienneFacade = compagnieAerienneFacade;
                    ApplicationFunctions.AgenceVoitureFacade = agenceVoitureFacade;
                    ApplicationFunctions.ChambreFacade = chambreFacade;
                    ApplicationFunctions.VolFacade = volFacade;
                    ApplicationFunctions.SiegeFacade = siegeFacade;
                    ApplicationFunctions.VoitureFacade = voitureFacade;
                    ApplicationFunctions.ForfaitFacade = forfaitFacade;
                    ApplicationFunctions.ReservationChambreFacade = reservationChambreFacade;
                    ApplicationFunctions.ReservationSiegeFacade = reservationSiegeFacade;
                    ApplicationFunctions.ReservationVoitureFacade = reservationVoitureFacade;
                    ApplicationFunctions.ReservationForfaitFacade = reservationForfaitFacade;

                }
                catch (VoyageAhuntsicException voyageAhuntsicException) {
                    System.Diagnostics.Debug.WriteLine(voyageAhuntsicException);
                }
            }            
        }

        public static CompteFournisseurChambreFacade CompteFournisseurChambreFacade { get; private set; }
        public static CompteFournisseurSiegeFacade CompteFournisseurSiegeFacade { get; private set; }
        public static CompteFournisseurVoitureFacade CompteFournisseurVoitureFacade { get; private set; }
        public static CompteParticulierFacade CompteParticulierFacade { get; private set; }
        public static HotelFacade HotelFacade { get; private set; }
        public static CompagnieAerienneFacade CompagnieAerienneFacade { get; private set; }
        public static AgenceVoitureFacade AgenceVoitureFacade { get; private set; }
        public static ChambreFacade ChambreFacade { get; private set; }
        public static VolFacade VolFacade { get; private set; }
        public static SiegeFacade SiegeFacade { get; private set; }
        public static VoitureFacade VoitureFacade { get; private set; }
        public static ForfaitFacade ForfaitFacade { get; private set; }
        public static ReservationChambreFacade ReservationChambreFacade { get; private set; }
        public static ReservationSiegeFacade ReservationSiegeFacade { get; private set; }
        public static ReservationVoitureFacade ReservationVoitureFacade { get; private set; }
        public static ReservationForfaitFacade ReservationForfaitFacade { get; private set; }

    }
}