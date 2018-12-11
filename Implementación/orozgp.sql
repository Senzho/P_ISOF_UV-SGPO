-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: localhost    Database: orozgp
-- ------------------------------------------------------
-- Server version	5.7.17-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `usuario`
--

DROP TABLE IF EXISTS `usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `usuario` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(100) DEFAULT NULL,
  `correo` varchar(100) DEFAULT NULL,
  `puesto` varchar(100) DEFAULT NULL,
  `nombreUsuario` varchar(100) DEFAULT NULL,
  `contraseña` varchar(100) DEFAULT NULL,
  `activo` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=35 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuario`
--

LOCK TABLES `usuario` WRITE;
/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
INSERT INTO `usuario` VALUES (1,'Víctor Javier García Mascareñas','vijagama@outlook.es','Diseñador','victor','e63c8c8a0f530555c761a7f3383121d33be720b83bc038a8ca54b6e6c42300e1',1),(27,'María Antonieta de las Nieves','marantoneves@gmail.com','Carpintero','anotonia','jfnsfpokhfdjd63839rufwywbdmcywdnf9383bdmoe8',1),(28,'Juan Daniel Murrieta','judamu@gmail.com','Diseñador','judamu','jfnsfpokhfdjd63839rufwywbdmcywdnf9383bdmoe8',1),(31,'Ana de la Reguera','andelareg@gmail.com','Hostess','andelareggmail.com','fbb6a08e1ae849a81d7bbabc408de98bbea47c7ead4368dfed4abd466dca7cd9',1),(32,'Luis Gerardo Bonilla','lugebon@gmail.com','Carpintero','lugebongmail.com','8f1b737836b38a34b5e6002eae43a6fe54efdae54d342edf499f18fb8dd1f490',1),(34,'Laura Gabriela Sarmiento García','lagasaga@outlook.es','Diseñador','lagasaoutlook.es','3702c38a8aa38a2abf2fd87f49ff0c2d4a0e5cfcbfc4730c2bde3152eba27cf8',1);
/*!40000 ALTER TABLE `usuario` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-12-11 12:08:25
