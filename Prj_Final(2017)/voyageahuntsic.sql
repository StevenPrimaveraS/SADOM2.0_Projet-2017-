-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Client :  127.0.0.1
-- Généré le :  Mar 28 Mars 2017 à 19:14
-- Version du serveur :  10.1.19-MariaDB
-- Version de PHP :  7.0.13

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données :  voyageahuntsic
--

-- --------------------------------------------------------

--
-- Structure de la table agencevoiture
--

CREATE TABLE agencevoiture (
  IdAgenceVoiture int(4) NOT NULL,
  Nom varchar(32) COLLATE utf8_unicode_ci NOT NULL,
  Telephone varchar(20) COLLATE utf8_unicode_ci NOT NULL,
  Adresse varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  Ville varchar(32) COLLATE utf8_unicode_ci NOT NULL,
  Aeroport varchar(20) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Structure de la table chambre
--

CREATE TABLE chambre (
  IdChambre int(4) NOT NULL,
  NumeroChambre int(4) NOT NULL,
  NomChambre int(32) NOT NULL,
  Tarif float NOT NULL,
  MaxPersonne int(4) NOT NULL,
  Taille float NOT NULL,
  Description text COLLATE utf8_unicode_ci NOT NULL,
  IdHotel int(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Structure de la table compagnieaerienne
--

CREATE TABLE compagnieaerienne (
  IdCompagnieAerienne int(4) NOT NULL,
  Nom varchar(32) COLLATE utf8_unicode_ci NOT NULL,
  Telephone varchar(20) COLLATE utf8_unicode_ci NOT NULL,
  Adresse varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  Ville varchar(32) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Structure de la table comptefournisseurchambre
--

CREATE TABLE comptefournisseurchambre (
  IdFournisseur int(4) NOT NULL,
  Courriel varchar(64) COLLATE utf8_unicode_ci NOT NULL,
  Password varchar(64) COLLATE utf8_unicode_ci NOT NULL,
  IdHotel int(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Structure de la table comptefournisseursiege
--

CREATE TABLE comptefournisseursiege (
  IdFournisseur int(4) NOT NULL,
  Courriel varchar(64) COLLATE utf8_unicode_ci NOT NULL,
  Password varchar(64) COLLATE utf8_unicode_ci NOT NULL,
  IdCompagnieAerienne int(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Structure de la table comptefournisseurvoiture
--

CREATE TABLE comptefournisseurvoiture (
  IdFournisseur int(4) NOT NULL,
  Courriel varchar(64) COLLATE utf8_unicode_ci NOT NULL,
  Password varchar(64) COLLATE utf8_unicode_ci NOT NULL,
  IdAgenceVoiture int(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Structure de la table compteparticulier
--

CREATE TABLE compteparticulier (
  IdParticulier int(4) NOT NULL,
  Password varchar(64) COLLATE utf8_unicode_ci NOT NULL,
  Prenom varchar(20) COLLATE utf8_unicode_ci NOT NULL,
  Nom varchar(20) COLLATE utf8_unicode_ci NOT NULL,
  Courriel varchar(40) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Structure de la table forfait
--

CREATE TABLE forfait (
  IdForfait int(4) NOT NULL,
  IdChambre int(4) NOT NULL,
  IdVoiture int(4) NOT NULL,
  IdSiege int(4) NOT NULL,
  TarifReduit float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Structure de la table hotel
--

CREATE TABLE hotel (
  IdHotel int(4) NOT NULL,
  Nom varchar(32) COLLATE utf8_unicode_ci NOT NULL,
  Telephone varchar(20) COLLATE utf8_unicode_ci NOT NULL,
  Adresse varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  Ville varchar(32) COLLATE utf8_unicode_ci NOT NULL,
  Categorie int(2) NOT NULL,
  Description text COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Structure de la table reservationchambre
--

CREATE TABLE reservationchambre (
  IdReservationChambre int(4) NOT NULL,
  IdChambre int(4) NOT NULL,
  IdParticulier int(4) NOT NULL,
  DateReservation date NOT NULL,
  DateFinReservation date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Structure de la table reservationforfait
--

CREATE TABLE reservationforfait (
  IdReservationForfait int(4) NOT NULL,
  IdForfait int(4) NOT NULL,
  IdParticulier int(4) NOT NULL,
  DateReservation date NOT NULL,
  DateFinReservation date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Structure de la table reservationsiege
--

CREATE TABLE reservationsiege (
  IdReservationSiege int(4) NOT NULL,
  IdSiege int(4) NOT NULL,
  IdParticulier int(4) NOT NULL,
  DateReservation date NOT NULL,
  DateFinReservation date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Structure de la table reservationvoiture
--

CREATE TABLE reservationvoiture (
  IdReservationVoiture int(4) NOT NULL,
  IdVoiture int(4) NOT NULL,
  IdParticulier int(4) NOT NULL,
  DateReservation date NOT NULL,
  DateFinReservation date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Structure de la table siege
--

CREATE TABLE siege (
  IdSiege int(4) NOT NULL,
  Type varchar(16) COLLATE utf8_unicode_ci NOT NULL,
  Numero int(4) NOT NULL,
  IdVol int(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Structure de la table voiture
--

CREATE TABLE voiture (
  IdVoiture int(4) NOT NULL,
  Type varchar(32) COLLATE utf8_unicode_ci NOT NULL,
  IdAgence int(4) NOT NULL,
  Tarif float NOT NULL,
  NbPassager int(4) NOT NULL,
  Nom varchar(32) COLLATE utf8_unicode_ci NOT NULL,
  Plaque varchar(8) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Structure de la table vol
--

CREATE TABLE vol (
  IdVol int(4) NOT NULL,
  AeroportDepart varchar(32) COLLATE utf8_unicode_ci NOT NULL,
  AeroportDestination varchar(32) COLLATE utf8_unicode_ci NOT NULL,
  VilleDepart varchar(32) COLLATE utf8_unicode_ci NOT NULL,
  VilleDestination varchar(32) COLLATE utf8_unicode_ci NOT NULL,
  DateDepart date NOT NULL,
  DateArrivee date NOT NULL,
  IdCompagnieAerienne int(4) NOT NULL,
  Classe varchar(16) COLLATE utf8_unicode_ci NOT NULL,
  IsRemboursable tinyint(1) NOT NULL,
  Tarif float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Index pour les tables exportées
--

--
-- Index pour la table agencevoiture
--
ALTER TABLE agencevoiture
  ADD PRIMARY KEY (IdAgenceVoiture);

--
-- Index pour la table chambre
--
ALTER TABLE chambre
  ADD PRIMARY KEY (IdChambre);

--
-- Index pour la table compagnieaerienne
--
ALTER TABLE compagnieaerienne
  ADD PRIMARY KEY (IdCompagnieAerienne);

--
-- Index pour la table comptefournisseurchambre
--
ALTER TABLE comptefournisseurchambre
  ADD PRIMARY KEY (IdFournisseur);

--
-- Index pour la table comptefournisseursiege
--
ALTER TABLE comptefournisseursiege
  ADD PRIMARY KEY (IdFournisseur);

--
-- Index pour la table comptefournisseurvoiture
--
ALTER TABLE comptefournisseurvoiture
  ADD PRIMARY KEY (IdFournisseur);

--
-- Index pour la table compteparticulier
--
ALTER TABLE compteparticulier
  ADD PRIMARY KEY (IdParticulier);

--
-- Index pour la table hotel
--
ALTER TABLE hotel
  ADD PRIMARY KEY (IdHotel);

--
-- Index pour la table reservationchambre
--
ALTER TABLE reservationchambre
  ADD PRIMARY KEY (IdReservationChambre);

--
-- Index pour la table reservationforfait
--
ALTER TABLE reservationforfait
  ADD PRIMARY KEY (IdReservationForfait);

--
-- Index pour la table reservationsiege
--
ALTER TABLE reservationsiege
  ADD PRIMARY KEY (IdReservationSiege);

--
-- Index pour la table reservationvoiture
--
ALTER TABLE reservationvoiture
  ADD PRIMARY KEY (IdReservationVoiture);

--
-- Index pour la table siege
--
ALTER TABLE siege
  ADD PRIMARY KEY (IdSiege);

--
-- Index pour la table voiture
--
ALTER TABLE voiture
  ADD PRIMARY KEY (IdVoiture);

--
-- Index pour la table vol
--
ALTER TABLE vol
  ADD PRIMARY KEY (IdVol);

--
-- AUTO_INCREMENT pour les tables exportées
--

--
-- AUTO_INCREMENT pour la table agencevoiture
--
ALTER TABLE agencevoiture
  MODIFY IdAgenceVoiture int(4) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT pour la table chambre
--
ALTER TABLE chambre
  MODIFY IdChambre int(4) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT pour la table compagnieaerienne
--
ALTER TABLE compagnieaerienne
  MODIFY IdCompagnieAerienne int(4) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT pour la table comptefournisseurchambre
--
ALTER TABLE comptefournisseurchambre
  MODIFY IdFournisseur int(4) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT pour la table comptefournisseursiege
--
ALTER TABLE comptefournisseursiege
  MODIFY IdFournisseur int(4) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT pour la table comptefournisseurvoiture
--
ALTER TABLE comptefournisseurvoiture
  MODIFY IdFournisseur int(4) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT pour la table compteparticulier
--
ALTER TABLE compteparticulier
  MODIFY IdParticulier int(4) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT pour la table hotel
--
ALTER TABLE hotel
  MODIFY IdHotel int(4) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT pour la table reservationchambre
--
ALTER TABLE reservationchambre
  MODIFY IdReservationChambre int(4) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT pour la table reservationforfait
--
ALTER TABLE reservationforfait
  MODIFY IdReservationForfait int(4) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT pour la table reservationsiege
--
ALTER TABLE reservationsiege
  MODIFY IdReservationSiege int(4) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT pour la table reservationvoiture
--
ALTER TABLE reservationvoiture
  MODIFY IdReservationVoiture int(4) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT pour la table siege
--
ALTER TABLE siege
  MODIFY IdSiege int(4) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT pour la table voiture
--
ALTER TABLE voiture
  MODIFY IdVoiture int(4) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT pour la table vol
--
ALTER TABLE vol
  MODIFY IdVol int(4) NOT NULL AUTO_INCREMENT;
--
-- Constraints for dumped tables
--

--
-- Constraints for table comptefournisseurchambre
--
ALTER TABLE comptefournisseurchambre
ADD CONSTRAINT comptefournisseurchambre_ibfk_1 FOREIGN KEY (IdHotel) REFERENCES hotel (IdHotel);
--
-- Constraints for table comptefournisseurvoiture
--
ALTER TABLE comptefournisseurvoiture
ADD CONSTRAINT comptefournisseurvoiture_ibfk_1 FOREIGN KEY (IdAgenceDeVoiture) REFERENCES agencevoiture (IdAgenceVoiture);
--
-- Constraints for table comptefournisseursiege
--
ALTER TABLE comptefournisseursiege
ADD CONSTRAINT comptefournisseursiege_ibfk_1 FOREIGN KEY (IdCompagnieAerienne) REFERENCES compagnieaerienne (IdCompagnieAerienne);
--
-- Constraints for table chambre
--
ALTER TABLE chambre
ADD CONSTRAINT chambre_ibfk_1 FOREIGN KEY (IdHotel) REFERENCES hotel (IdHotel);
--
-- Constraints for table voiture
--
ALTER TABLE voiture
ADD CONSTRAINT voiture_ibfk_1 FOREIGN KEY (IdAgence) REFERENCES agencevoiture (IdAgenceVoiture);
--
-- Constraints for table vol
--
ALTER TABLE vol
ADD CONSTRAINT vol_ibfk_1 FOREIGN KEY (IdCompagnieAerienne) REFERENCES compagnieaerienne (IdCompagnieAerienne);
--
-- Constraints for table siege
--
ALTER TABLE siege
ADD CONSTRAINT siege_ibfk_1 FOREIGN KEY (IdVol) REFERENCES vol (IdVol);
--
-- Constraints for table forfait
--
ALTER TABLE forfait
ADD CONSTRAINT forfait_ibfk_1 FOREIGN KEY (IdChambre) REFERENCES chambre (IdChambre),
ADD CONSTRAINT forfait_ibfk_2 FOREIGN KEY (IdVoiture) REFERENCES voiture (IdVoiture),
ADD CONSTRAINT forfait_ibfk_3 FOREIGN KEY (IdSiege) REFERENCES siege (IdSiege);
--
-- Constraints for table reservationchambre
--
ALTER TABLE reservationchambre
ADD CONSTRAINT reservationchambre_ibfk_1 FOREIGN KEY (IdChambre) REFERENCES hotel (IdChambre),
ADD CONSTRAINT reservationchambre_ibfk_2 FOREIGN KEY (IdParticulier) REFERENCES compteparticulier (IdParticulier);
--
-- Constraints for table reservationvoiture
--
ALTER TABLE reservationvoiture
ADD CONSTRAINT reservationvoiture_ibfk_1 FOREIGN KEY (IdVoiture) REFERENCES voiture (IdVoiture),
ADD CONSTRAINT reservationvoiture_ibfk_2 FOREIGN KEY (IdParticulier) REFERENCES compteparticulier (IdParticulier);
--
-- Constraints for table reservationsiege
--
ALTER TABLE reservationsiege
ADD CONSTRAINT reservationsiege_ibfk_1 FOREIGN KEY (IdSiege) REFERENCES siege (IdSiege),
ADD CONSTRAINT reservationsiege_ibfk_2 FOREIGN KEY (IdParticulier) REFERENCES compteparticulier (IdParticulier);
--
-- Constraints for table reservationchambre
--
ALTER TABLE reservationchambre
ADD CONSTRAINT reservationchambre_ibfk_1 FOREIGN KEY (IdForfait) REFERENCES forfait (IdForfait),
ADD CONSTRAINT reservationchambre_ibfk_2 FOREIGN KEY (IdParticulier) REFERENCES compteparticulier (IdParticulier);
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
