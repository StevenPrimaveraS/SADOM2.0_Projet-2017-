-- phpMyAdmin SQL Dump
-- version 4.2.11
-- http://www.phpmyadmin.net
--
-- Client :  127.0.0.1
-- Généré le :  Lun 10 Avril 2017 à 22:27
-- Version du serveur :  5.6.21
-- Version de PHP :  5.6.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Base de données :  `voyageahuntsic`
--

-- --------------------------------------------------------

--
-- Structure de la table `agencevoiture`
--

CREATE TABLE IF NOT EXISTS `agencevoiture` (
`IdAgenceVoiture` int(4) NOT NULL,
  `Nom` varchar(32) COLLATE utf8_unicode_ci NOT NULL,
  `Telephone` varchar(20) COLLATE utf8_unicode_ci NOT NULL,
  `Adresse` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `Ville` varchar(32) COLLATE utf8_unicode_ci NOT NULL,
  `Aeroport` varchar(20) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Contenu de la table `agencevoiture`
--

INSERT INTO `agencevoiture` (`IdAgenceVoiture`, `Nom`, `Telephone`, `Adresse`, `Ville`, `Aeroport`) VALUES
(1, 'Enterprise', '1-888-555-5460', '4862 rue Boyle', 'Montreal', 'Mirabelle'),
(2, 'AutoExpress', '1-800-521-5554', '55469 rue St-Denis', 'Montreal', 'Mirabelle'),
(3, 'CarNow', '1-888-487-8249', '4521 Somerville St', 'Vancouver', 'International'),
(4, 'LocAuto', '78452958', '458 rue des Archives', 'Paris', 'Charles-de-Gaulles');

-- --------------------------------------------------------

--
-- Structure de la table `chambre`
--

CREATE TABLE IF NOT EXISTS `chambre` (
`IdChambre` int(4) NOT NULL,
  `NumeroChambre` int(4) NOT NULL,
  `NomChambre` varchar(32) COLLATE utf8_unicode_ci NOT NULL,
  `Tarif` float NOT NULL,
  `MaxPersonne` int(4) NOT NULL,
  `Taille` float NOT NULL,
  `Description` text COLLATE utf8_unicode_ci NOT NULL,
  `IdHotel` int(4) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Contenu de la table `chambre`
--

INSERT INTO `chambre` (`IdChambre`, `NumeroChambre`, `NomChambre`, `Tarif`, `MaxPersonne`, `Taille`, `Description`, `IdHotel`) VALUES
(1, 452, 'Chambre 452', 256.25, 4, 100, 'Chambre avec deux lits doubles et vue sur le parc.', 1),
(2, 482, 'Room 482', 481.62, 2, 80, 'Room with one queen bed and view on the English Bay.', 2),
(3, 666, 'Suite Démoniaque', 666.66, 4, 100, 'Suite avec theme demonique.', 3);

-- --------------------------------------------------------

--
-- Structure de la table `compagnieaerienne`
--

CREATE TABLE IF NOT EXISTS `compagnieaerienne` (
`IdCompagnieAerienne` int(4) NOT NULL,
  `Nom` varchar(32) COLLATE utf8_unicode_ci NOT NULL,
  `Telephone` varchar(20) COLLATE utf8_unicode_ci NOT NULL,
  `Adresse` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `Ville` varchar(32) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Contenu de la table `compagnieaerienne`
--

INSERT INTO `compagnieaerienne` (`IdCompagnieAerienne`, `Nom`, `Telephone`, `Adresse`, `Ville`) VALUES
(1, 'Air Transat', '1-877-872-6728', '4444 48e avenue', 'Montreal'),
(2, 'Air Canada', '1-888-247-2262', '305 Boulevard Crémazie O', 'Montreal'),
(3, 'Air Fance', '1-800-667-2747', '2 rue de la Belle Borne', 'Tremblay-en-France');

-- --------------------------------------------------------

--
-- Structure de la table `comptefournisseurchambre`
--

CREATE TABLE IF NOT EXISTS `comptefournisseurchambre` (
`IdFournisseur` int(4) NOT NULL,
  `Courriel` varchar(64) COLLATE utf8_unicode_ci NOT NULL,
  `Password` varchar(64) COLLATE utf8_unicode_ci NOT NULL,
  `IdHotel` int(4) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Contenu de la table `comptefournisseurchambre`
--

INSERT INTO `comptefournisseurchambre` (`IdFournisseur`, `Courriel`, `Password`, `IdHotel`) VALUES
(1, 'gouverneur@gouverneur.com', 'Gouverneur1', 1),
(2, 'innsmouth@insmouth.com', 'InnsMouth1', 2),
(3, 'CharlesdeGaulles@CharlesdeGaulles.fr', 'CharlesdeGaulles1', 3);

-- --------------------------------------------------------

--
-- Structure de la table `comptefournisseursiege`
--

CREATE TABLE IF NOT EXISTS `comptefournisseursiege` (
`IdFournisseur` int(4) NOT NULL,
  `Courriel` varchar(64) COLLATE utf8_unicode_ci NOT NULL,
  `Password` varchar(64) COLLATE utf8_unicode_ci NOT NULL,
  `IdCompagnieAerienne` int(4) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Contenu de la table `comptefournisseursiege`
--

INSERT INTO `comptefournisseursiege` (`IdFournisseur`, `Courriel`, `Password`, `IdCompagnieAerienne`) VALUES
(1, 'airTransat@airTransat.qc.ca', 'AirTransat1', 1),
(2, 'airCanada@airCanada.qc.ca', 'AirCanada1', 2),
(3, 'airFrance@airFrance.fr', 'AirFrance1', 3);

-- --------------------------------------------------------

--
-- Structure de la table `comptefournisseurvoiture`
--

CREATE TABLE IF NOT EXISTS `comptefournisseurvoiture` (
`IdFournisseur` int(4) NOT NULL,
  `Courriel` varchar(64) COLLATE utf8_unicode_ci NOT NULL,
  `Password` varchar(64) COLLATE utf8_unicode_ci NOT NULL,
  `IdAgenceVoiture` int(4) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Contenu de la table `comptefournisseurvoiture`
--

INSERT INTO `comptefournisseurvoiture` (`IdFournisseur`, `Courriel`, `Password`, `IdAgenceVoiture`) VALUES
(1, 'enterprise@enterprise.ca', 'Enterprise1', 1),
(2, 'autoExpress@autoExpress.ca', 'AutoExpress1', 2),
(3, 'carNow@carNow.com', 'CarNow1', 3),
(4, 'locAuto@locAuto.fr', 'LocAuto1', 4);

-- --------------------------------------------------------

--
-- Structure de la table `compteparticulier`
--

CREATE TABLE IF NOT EXISTS `compteparticulier` (
`IdParticulier` int(4) NOT NULL,
  `Password` varchar(64) COLLATE utf8_unicode_ci NOT NULL,
  `Prenom` varchar(20) COLLATE utf8_unicode_ci NOT NULL,
  `Nom` varchar(20) COLLATE utf8_unicode_ci NOT NULL,
  `Courriel` varchar(40) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Contenu de la table `compteparticulier`
--

INSERT INTO `compteparticulier` (`IdParticulier`, `Password`, `Prenom`, `Nom`, `Courriel`) VALUES
(1, 'Dominic1', 'Dominic', 'Leroux', 'dominicleroux@hotmail.com'),
(2, 'Mathieu1', 'Mathieu', 'Lafond', 'mathieulafond1@hotmail.com'),
(3, 'Anthony1', 'Anthony', 'Chan', 'anthonychan@hotmail.com');

-- --------------------------------------------------------

--
-- Structure de la table `forfait`
--

CREATE TABLE IF NOT EXISTS `forfait` (
  `IdForfait` int(4) NOT NULL,
  `IdChambre` int(4) NOT NULL,
  `IdVoiture` int(4) NOT NULL,
  `IdSiege` int(4) NOT NULL,
  `TarifReduit` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Contenu de la table `forfait`
--

INSERT INTO `forfait` (`IdForfait`, `IdChambre`, `IdVoiture`, `IdSiege`, `TarifReduit`) VALUES
(1, 1, 1, 1, 799.99);

-- --------------------------------------------------------

--
-- Structure de la table `hotel`
--

CREATE TABLE IF NOT EXISTS `hotel` (
`IdHotel` int(4) NOT NULL,
  `Nom` varchar(32) COLLATE utf8_unicode_ci NOT NULL,
  `Telephone` varchar(20) COLLATE utf8_unicode_ci NOT NULL,
  `Adresse` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `Ville` varchar(32) COLLATE utf8_unicode_ci NOT NULL,
  `Categorie` int(2) NOT NULL,
  `Description` text COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Contenu de la table `hotel`
--

INSERT INTO `hotel` (`IdHotel`, `Nom`, `Telephone`, `Adresse`, `Ville`, `Categorie`, `Description`) VALUES
(1, 'Gouverneur', '514-555-9865', '4521 Rue st-hubert', 'Montreal', 4, 'Piscine intérieure, buffet continental'),
(2, 'InnsMouth', '475-555-9624', '4852 Somerville St', 'Vancouver', 3, 'Beautiful decoration, swimming pool, nice staff'),
(3, 'Charles-de-Gaules', '89654128', '588 rue des Archives', 'Paris', 5, 'Venez visiter le meilleur hotel de Paris durant votre séjour');

-- --------------------------------------------------------

--
-- Structure de la table `reservationchambre`
--

CREATE TABLE IF NOT EXISTS `reservationchambre` (
`IdReservationChambre` int(4) NOT NULL,
  `IdChambre` int(4) NOT NULL,
  `IdParticulier` int(4) NOT NULL,
  `DateReservation` date NOT NULL,
  `DateFinReservation` date NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Contenu de la table `reservationchambre`
--

INSERT INTO `reservationchambre` (`IdReservationChambre`, `IdChambre`, `IdParticulier`, `DateReservation`, `DateFinReservation`) VALUES
(1, 2, 3, '2017-04-25', '2017-04-28');

-- --------------------------------------------------------

--
-- Structure de la table `reservationforfait`
--

CREATE TABLE IF NOT EXISTS `reservationforfait` (
`IdReservationForfait` int(4) NOT NULL,
  `IdForfait` int(4) NOT NULL,
  `IdParticulier` int(4) NOT NULL,
  `DateReservation` date NOT NULL,
  `DateFinReservation` date NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Contenu de la table `reservationforfait`
--

INSERT INTO `reservationforfait` (`IdReservationForfait`, `IdForfait`, `IdParticulier`, `DateReservation`, `DateFinReservation`) VALUES
(1, 1, 1, '2017-04-24', '2017-04-26');

-- --------------------------------------------------------

--
-- Structure de la table `reservationsiege`
--

CREATE TABLE IF NOT EXISTS `reservationsiege` (
`IdReservationSiege` int(4) NOT NULL,
  `IdSiege` int(4) NOT NULL,
  `IdParticulier` int(4) NOT NULL,
  `DateReservation` date NOT NULL,
  `DateFinReservation` date NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Contenu de la table `reservationsiege`
--

INSERT INTO `reservationsiege` (`IdReservationSiege`, `IdSiege`, `IdParticulier`, `DateReservation`, `DateFinReservation`) VALUES
(1, 2, 2, '2017-04-24', '2017-04-24'),
(2, 3, 3, '2017-04-25', '2017-04-25');

-- --------------------------------------------------------

--
-- Structure de la table `reservationvoiture`
--

CREATE TABLE IF NOT EXISTS `reservationvoiture` (
`IdReservationVoiture` int(4) NOT NULL,
  `IdVoiture` int(4) NOT NULL,
  `IdParticulier` int(4) NOT NULL,
  `DateReservation` date NOT NULL,
  `DateFinReservation` date NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Contenu de la table `reservationvoiture`
--

INSERT INTO `reservationvoiture` (`IdReservationVoiture`, `IdVoiture`, `IdParticulier`, `DateReservation`, `DateFinReservation`) VALUES
(1, 3, 3, '2017-04-25', '2017-04-28');

-- --------------------------------------------------------

--
-- Structure de la table `siege`
--

CREATE TABLE IF NOT EXISTS `siege` (
`IdSiege` int(4) NOT NULL,
  `Type` varchar(16) COLLATE utf8_unicode_ci NOT NULL,
  `Numero` int(4) NOT NULL,
  `IdVol` int(4) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Contenu de la table `siege`
--

INSERT INTO `siege` (`IdSiege`, `Type`, `Numero`, `IdVol`) VALUES
(1, 'Hublot', 10, 1),
(2, 'Allee', 2, 1),
(3, 'Hublot', 3, 2),
(4, 'Allee', 2, 3);

-- --------------------------------------------------------

--
-- Structure de la table `voiture`
--

CREATE TABLE IF NOT EXISTS `voiture` (
`IdVoiture` int(4) NOT NULL,
  `Type` varchar(32) COLLATE utf8_unicode_ci NOT NULL,
  `IdAgence` int(4) NOT NULL,
  `Tarif` float NOT NULL,
  `NbPassager` int(4) NOT NULL,
  `Nom` varchar(32) COLLATE utf8_unicode_ci NOT NULL,
  `Plaque` varchar(8) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Contenu de la table `voiture`
--

INSERT INTO `voiture` (`IdVoiture`, `Type`, `IdAgence`, `Tarif`, `NbPassager`, `Nom`, `Plaque`) VALUES
(1, '2/4 portes', 1, 350.98, 4, 'Honda Civic', 'erc524'),
(2, 'Limousine', 2, 450.85, 10, 'Chrysler', '5482red'),
(3, 'Sport', 3, 362.94, 6, 'Mazda Sport', '256swj'),
(4, 'Minibus', 4, 752.34, 15, 'Minibus', 'df258tg');

-- --------------------------------------------------------

--
-- Structure de la table `vol`
--

CREATE TABLE IF NOT EXISTS `vol` (
`IdVol` int(4) NOT NULL,
  `AeroportDepart` varchar(32) COLLATE utf8_unicode_ci NOT NULL,
  `AeroportDestination` varchar(32) COLLATE utf8_unicode_ci NOT NULL,
  `VilleDepart` varchar(32) COLLATE utf8_unicode_ci NOT NULL,
  `VilleDestination` varchar(32) COLLATE utf8_unicode_ci NOT NULL,
  `DateDepart` date NOT NULL,
  `DateArrivee` date NOT NULL,
  `IdCompagnieAerienne` int(4) NOT NULL,
  `Classe` varchar(16) COLLATE utf8_unicode_ci NOT NULL,
  `IsRemboursable` tinyint(1) NOT NULL,
  `Tarif` float NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Contenu de la table `vol`
--

INSERT INTO `vol` (`IdVol`, `AeroportDepart`, `AeroportDestination`, `VilleDepart`, `VilleDestination`, `DateDepart`, `DateArrivee`, `IdCompagnieAerienne`, `Classe`, `IsRemboursable`, `Tarif`) VALUES
(1, 'Mirabelle', 'Pearson', 'Montreal', 'Toronto', '2017-04-24', '2017-04-24', 1, 'Economique', 1, 216),
(2, 'Mirabelle', 'International', 'Montreal', 'Vancouver', '2017-04-25', '2017-04-25', 2, '1ere classe', 0, 419.18),
(3, 'Charles-de-Gaulles', 'Mirabelle', 'Paris', 'Montreal', '2017-04-20', '2017-04-21', 3, 'Affaire', 0, 667.84);

--
-- Index pour les tables exportées
--

--
-- Index pour la table `agencevoiture`
--
ALTER TABLE `agencevoiture`
 ADD PRIMARY KEY (`IdAgenceVoiture`);

--
-- Index pour la table `chambre`
--
ALTER TABLE `chambre`
 ADD PRIMARY KEY (`IdChambre`), ADD KEY `chambre_ibfk_1` (`IdHotel`);

--
-- Index pour la table `compagnieaerienne`
--
ALTER TABLE `compagnieaerienne`
 ADD PRIMARY KEY (`IdCompagnieAerienne`);

--
-- Index pour la table `comptefournisseurchambre`
--
ALTER TABLE `comptefournisseurchambre`
 ADD PRIMARY KEY (`IdFournisseur`), ADD KEY `comptefournisseurchambre_ibfk_1` (`IdHotel`);

--
-- Index pour la table `comptefournisseursiege`
--
ALTER TABLE `comptefournisseursiege`
 ADD PRIMARY KEY (`IdFournisseur`), ADD KEY `comptefournisseursiege_ibfk_1` (`IdCompagnieAerienne`);

--
-- Index pour la table `comptefournisseurvoiture`
--
ALTER TABLE `comptefournisseurvoiture`
 ADD PRIMARY KEY (`IdFournisseur`), ADD KEY `comptefournisseurvoiture_ibfk_1` (`IdAgenceVoiture`);

--
-- Index pour la table `compteparticulier`
--
ALTER TABLE `compteparticulier`
 ADD PRIMARY KEY (`IdParticulier`);

--
-- Index pour la table `forfait`
--
ALTER TABLE `forfait`
 ADD PRIMARY KEY (`IdForfait`), ADD KEY `forfait_ibfk_1` (`IdChambre`), ADD KEY `forfait_ibfk_2` (`IdVoiture`), ADD KEY `forfait_ibfk_3` (`IdSiege`);

--
-- Index pour la table `hotel`
--
ALTER TABLE `hotel`
 ADD PRIMARY KEY (`IdHotel`);

--
-- Index pour la table `reservationchambre`
--
ALTER TABLE `reservationchambre`
 ADD PRIMARY KEY (`IdReservationChambre`), ADD KEY `reservationchambre_ibfk_1` (`IdChambre`), ADD KEY `reservationchambre_ibfk_2` (`IdParticulier`);

--
-- Index pour la table `reservationforfait`
--
ALTER TABLE `reservationforfait`
 ADD PRIMARY KEY (`IdReservationForfait`), ADD KEY `reservationforfait_ibfk_1` (`IdForfait`), ADD KEY `reservationforfait_ibfk_2` (`IdParticulier`);

--
-- Index pour la table `reservationsiege`
--
ALTER TABLE `reservationsiege`
 ADD PRIMARY KEY (`IdReservationSiege`), ADD KEY `reservationsiege_ibfk_1` (`IdSiege`), ADD KEY `reservationsiege_ibfk_2` (`IdParticulier`);

--
-- Index pour la table `reservationvoiture`
--
ALTER TABLE `reservationvoiture`
 ADD PRIMARY KEY (`IdReservationVoiture`), ADD KEY `reservationvoiture_ibfk_1` (`IdVoiture`), ADD KEY `reservationvoiture_ibfk_2` (`IdParticulier`);

--
-- Index pour la table `siege`
--
ALTER TABLE `siege`
 ADD PRIMARY KEY (`IdSiege`), ADD KEY `siege_ibfk_1` (`IdVol`);

--
-- Index pour la table `voiture`
--
ALTER TABLE `voiture`
 ADD PRIMARY KEY (`IdVoiture`), ADD KEY `voiture_ibfk_1` (`IdAgence`);

--
-- Index pour la table `vol`
--
ALTER TABLE `vol`
 ADD PRIMARY KEY (`IdVol`), ADD KEY `vol_ibfk_1` (`IdCompagnieAerienne`);

--
-- AUTO_INCREMENT pour les tables exportées
--

--
-- AUTO_INCREMENT pour la table `agencevoiture`
--
ALTER TABLE `agencevoiture`
MODIFY `IdAgenceVoiture` int(4) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT pour la table `chambre`
--
ALTER TABLE `chambre`
MODIFY `IdChambre` int(4) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT pour la table `compagnieaerienne`
--
ALTER TABLE `compagnieaerienne`
MODIFY `IdCompagnieAerienne` int(4) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT pour la table `comptefournisseurchambre`
--
ALTER TABLE `comptefournisseurchambre`
MODIFY `IdFournisseur` int(4) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT pour la table `comptefournisseursiege`
--
ALTER TABLE `comptefournisseursiege`
MODIFY `IdFournisseur` int(4) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT pour la table `comptefournisseurvoiture`
--
ALTER TABLE `comptefournisseurvoiture`
MODIFY `IdFournisseur` int(4) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT pour la table `compteparticulier`
--
ALTER TABLE `compteparticulier`
MODIFY `IdParticulier` int(4) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT pour la table `hotel`
--
ALTER TABLE `hotel`
MODIFY `IdHotel` int(4) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT pour la table `reservationchambre`
--
ALTER TABLE `reservationchambre`
MODIFY `IdReservationChambre` int(4) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT pour la table `reservationforfait`
--
ALTER TABLE `reservationforfait`
MODIFY `IdReservationForfait` int(4) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT pour la table `reservationsiege`
--
ALTER TABLE `reservationsiege`
MODIFY `IdReservationSiege` int(4) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT pour la table `reservationvoiture`
--
ALTER TABLE `reservationvoiture`
MODIFY `IdReservationVoiture` int(4) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT pour la table `siege`
--
ALTER TABLE `siege`
MODIFY `IdSiege` int(4) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT pour la table `voiture`
--
ALTER TABLE `voiture`
MODIFY `IdVoiture` int(4) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT pour la table `vol`
--
ALTER TABLE `vol`
MODIFY `IdVol` int(4) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=5;
--
-- Contraintes pour les tables exportées
--

--
-- Contraintes pour la table `chambre`
--
ALTER TABLE `chambre`
ADD CONSTRAINT `chambre_ibfk_1` FOREIGN KEY (`IdHotel`) REFERENCES `hotel` (`IdHotel`);

--
-- Contraintes pour la table `comptefournisseurchambre`
--
ALTER TABLE `comptefournisseurchambre`
ADD CONSTRAINT `comptefournisseurchambre_ibfk_1` FOREIGN KEY (`IdHotel`) REFERENCES `hotel` (`IdHotel`);

--
-- Contraintes pour la table `comptefournisseursiege`
--
ALTER TABLE `comptefournisseursiege`
ADD CONSTRAINT `comptefournisseursiege_ibfk_1` FOREIGN KEY (`IdCompagnieAerienne`) REFERENCES `compagnieaerienne` (`IdCompagnieAerienne`);

--
-- Contraintes pour la table `comptefournisseurvoiture`
--
ALTER TABLE `comptefournisseurvoiture`
ADD CONSTRAINT `comptefournisseurvoiture_ibfk_1` FOREIGN KEY (`IdAgenceVoiture`) REFERENCES `agencevoiture` (`IdAgenceVoiture`);

--
-- Contraintes pour la table `forfait`
--
ALTER TABLE `forfait`
ADD CONSTRAINT `forfait_ibfk_1` FOREIGN KEY (`IdChambre`) REFERENCES `chambre` (`IdChambre`),
ADD CONSTRAINT `forfait_ibfk_2` FOREIGN KEY (`IdVoiture`) REFERENCES `voiture` (`IdVoiture`),
ADD CONSTRAINT `forfait_ibfk_3` FOREIGN KEY (`IdSiege`) REFERENCES `siege` (`IdSiege`);

--
-- Contraintes pour la table `reservationchambre`
--
ALTER TABLE `reservationchambre`
ADD CONSTRAINT `reservationchambre_ibfk_1` FOREIGN KEY (`IdChambre`) REFERENCES `chambre` (`IdChambre`),
ADD CONSTRAINT `reservationchambre_ibfk_2` FOREIGN KEY (`IdParticulier`) REFERENCES `compteparticulier` (`IdParticulier`);

--
-- Contraintes pour la table `reservationforfait`
--
ALTER TABLE `reservationforfait`
ADD CONSTRAINT `reservationforfait_ibfk_1` FOREIGN KEY (`IdForfait`) REFERENCES `forfait` (`IdForfait`),
ADD CONSTRAINT `reservationforfait_ibfk_2` FOREIGN KEY (`IdParticulier`) REFERENCES `compteparticulier` (`IdParticulier`);

--
-- Contraintes pour la table `reservationsiege`
--
ALTER TABLE `reservationsiege`
ADD CONSTRAINT `reservationsiege_ibfk_1` FOREIGN KEY (`IdSiege`) REFERENCES `siege` (`IdSiege`),
ADD CONSTRAINT `reservationsiege_ibfk_2` FOREIGN KEY (`IdParticulier`) REFERENCES `compteparticulier` (`IdParticulier`);

--
-- Contraintes pour la table `reservationvoiture`
--
ALTER TABLE `reservationvoiture`
ADD CONSTRAINT `reservationvoiture_ibfk_1` FOREIGN KEY (`IdVoiture`) REFERENCES `voiture` (`IdVoiture`),
ADD CONSTRAINT `reservationvoiture_ibfk_2` FOREIGN KEY (`IdParticulier`) REFERENCES `compteparticulier` (`IdParticulier`);

--
-- Contraintes pour la table `siege`
--
ALTER TABLE `siege`
ADD CONSTRAINT `siege_ibfk_1` FOREIGN KEY (`IdVol`) REFERENCES `vol` (`IdVol`);

--
-- Contraintes pour la table `voiture`
--
ALTER TABLE `voiture`
ADD CONSTRAINT `voiture_ibfk_1` FOREIGN KEY (`IdAgence`) REFERENCES `agencevoiture` (`IdAgenceVoiture`);

--
-- Contraintes pour la table `vol`
--
ALTER TABLE `vol`
ADD CONSTRAINT `vol_ibfk_1` FOREIGN KEY (`IdCompagnieAerienne`) REFERENCES `compagnieaerienne` (`IdCompagnieAerienne`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
