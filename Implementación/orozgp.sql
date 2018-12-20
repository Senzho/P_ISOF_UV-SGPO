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
-- Table structure for table `categoria`
--

DROP TABLE IF EXISTS `categoria`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `categoria` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(100) DEFAULT NULL,
  `tipo` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categoria`
--

LOCK TABLES `categoria` WRITE;
/*!40000 ALTER TABLE `categoria` DISABLE KEYS */;
INSERT INTO `categoria` VALUES (1,'Madera',1),(2,'Aluminio',1),(3,'Mármol',1),(4,'Vidrio',1),(5,'Fierro',1),(6,'Acrílico',1),(7,'Sintético',1);
/*!40000 ALTER TABLE `categoria` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `permiso`
--

DROP TABLE IF EXISTS `permiso`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `permiso` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `ambito` varchar(12) DEFAULT NULL,
  `consultar` tinyint(1) DEFAULT NULL,
  `crear` tinyint(1) DEFAULT NULL,
  `modificar` tinyint(1) DEFAULT NULL,
  `eliminar` tinyint(1) DEFAULT NULL,
  `idUsuario` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `idUsuario` (`idUsuario`),
  CONSTRAINT `permiso_ibfk_1` FOREIGN KEY (`idUsuario`) REFERENCES `usuario` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=86 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `permiso`
--

LOCK TABLES `permiso` WRITE;
/*!40000 ALTER TABLE `permiso` DISABLE KEYS */;
INSERT INTO `permiso` VALUES (1,'Materiales',1,1,1,1,1),(2,'Herrajes',1,1,1,1,1),(3,'Accesorios',1,1,1,1,1),(4,'Usuarios',1,1,1,1,1),(5,'Presupuestos',1,1,1,1,1),(11,'Materiales',1,1,0,0,39),(12,'Herrajes',1,1,0,0,39),(13,'Accesorios',1,1,0,0,39),(14,'Usuarios',1,0,0,0,39),(15,'Presupuestos',1,0,0,0,39),(16,'Materiales',1,0,0,1,40),(17,'Herrajes',1,0,0,1,40),(18,'Accesorios',1,0,0,1,40),(19,'Usuarios',1,0,0,0,40),(20,'Presupuestos',1,1,1,1,40),(21,'Materiales',1,0,0,1,41),(22,'Herrajes',1,0,0,1,41),(23,'Accesorios',1,0,0,1,41),(24,'Usuarios',0,0,0,0,41),(25,'Presupuestos',0,0,0,0,41),(26,'Materiales',0,0,0,0,42),(27,'Herrajes',0,0,0,0,42),(28,'Accesorios',0,0,0,0,42),(29,'Usuarios',0,0,0,0,42),(30,'Presupuestos',1,1,1,0,42),(31,'Materiales',0,0,0,0,43),(32,'Herrajes',0,0,0,0,43),(33,'Accesorios',0,0,0,0,43),(34,'Usuarios',1,1,1,0,43),(35,'Presupuestos',1,0,1,1,43),(36,'Materiales',1,0,0,0,44),(37,'Herrajes',1,0,0,0,44),(38,'Accesorios',1,0,0,0,44),(39,'Usuarios',0,0,0,0,44),(40,'Presupuestos',1,1,1,0,44),(41,'Materiales',1,1,0,0,45),(42,'Herrajes',1,1,0,0,45),(43,'Accesorios',1,1,0,0,45),(44,'Usuarios',1,1,0,0,45),(45,'Presupuestos',1,1,0,0,45),(46,'Materiales',1,0,1,0,46),(47,'Herrajes',1,0,1,0,46),(48,'Accesorios',1,0,1,0,46),(49,'Usuarios',0,0,0,0,46),(50,'Presupuestos',1,1,1,1,46),(51,'Materiales',1,0,0,1,47),(52,'Herrajes',1,0,0,1,47),(53,'Accesorios',1,0,0,1,47),(54,'Usuarios',0,0,0,0,47),(55,'Presupuestos',1,0,0,0,47),(56,'Materiales',0,0,0,0,48),(57,'Herrajes',0,0,0,0,48),(58,'Accesorios',0,0,0,0,48),(59,'Usuarios',1,1,1,0,48),(60,'Presupuestos',1,1,1,0,48),(61,'Materiales',1,0,0,0,49),(62,'Herrajes',1,1,0,0,49),(63,'Accesorios',1,0,1,0,49),(64,'Usuarios',1,0,0,1,49),(65,'Presupuestos',0,0,0,0,49),(66,'Materiales',1,1,1,0,50),(67,'Herrajes',1,1,1,0,50),(68,'Accesorios',1,1,1,0,50),(69,'Usuarios',0,0,0,0,50),(70,'Presupuestos',0,0,0,0,50),(71,'Materiales',0,0,0,0,51),(72,'Herrajes',0,0,0,0,51),(73,'Accesorios',0,0,0,0,51),(74,'Usuarios',1,1,1,0,51),(75,'Presupuestos',1,0,0,0,51),(76,'Materiales',1,0,0,0,52),(77,'Herrajes',1,0,0,0,52),(78,'Accesorios',1,0,0,0,52),(79,'Usuarios',0,0,0,0,52),(80,'Presupuestos',1,1,1,0,52),(81,'Materiales',1,1,0,0,53),(82,'Herrajes',1,1,0,0,53),(83,'Accesorios',1,1,0,0,53),(84,'Usuarios',0,0,0,0,53),(85,'Presupuestos',0,0,0,0,53);
/*!40000 ALTER TABLE `permiso` ENABLE KEYS */;
UNLOCK TABLES;

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
) ENGINE=InnoDB AUTO_INCREMENT=54 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuario`
--

LOCK TABLES `usuario` WRITE;
/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
INSERT INTO `usuario` VALUES (1,'Víctor Javier García Mascareñas','vijagama@outlook.es','Diseñador','victor','e63c8c8a0f530555c761a7f3383121d33be720b83bc038a8ca54b6e6c42300e1',1),(36,'María Violeta Magaña Castelán','mavimacas@gmail.com','Hostess','mavimacasgmail.com','896e97a0aa774754268d03e36fde262761f4e1d1fc5e14adb649dbdf90324936',1),(39,'Usuario Prueba','usupru@gmail.com','Puesto Prueba','usuprugmail.com','32e1b7f5275444ef919636649aeb6f78b983e497f25ec25ec1835fdc2ffc8bd9',1),(40,'Darth Vader','darth_vader@dark.side','Lord Sith','darth_vaderdark.side','71eecf883c6c8cf8c4940ba1074444e55dc8b12ebe51a562a8cc8040470deee5',1),(41,'Batman','real_batman@super.hero','Batman (Millionaire)','real_batmansuper.hero','ec2fb5bf1f7ae6767e146aefc44ec3cf4b2efd5f34946e2a35e44c9ab952a598',1),(42,'Luis Miguel','elsol@luis.miguel','Cantante Mediocre','elsolluis.miguel','a9f58d878280981d983db52906e0834f2bfd3a3f99d20243be8562260a39dc58',1),(43,'Tom Cruise','tom_cruise@tom.cruise','Actor Sobrevalorado','tom_cruisetom.cruise','2cde9d3671d713bf10f0afc9218d7e7d9fd84adbed2419c95d6a5b174af7c8e0',1),(44,'Michael Jackson','jack_mich@jack.son','Rey del Pop','jack_michjack.son','e90b72b878103f7388b3c6fcc52614315cb82bdd35656095c5c473136b686269',1),(45,'89769876 98769876','98769876@87687.364','987896','9876987687687.364','c9a5d6b98c6bebb4e039cf835c03b118976dce3a171609a914363b6b19fedf3b',1),(46,'Juan Mendoza','jumendo@gmail.com','Arquitecto','jumendogmail.com','86ffbc3c17f8ef95729250699dae34b4dc5922941a41aeba6833a6715c520125',1),(47,'Helena Vabiera','helebaba@outlook.es','Contador','helebabaoutlook.es','f9e868b676808a78b1c76ab04bf9145663b77863d8eb2337d16bf4e06bbed77a',1),(48,'khjgjgf utfutrfyutv','iytiyut@gmail.com','0987hkbj','iytiyutgmail.com','ba562de948e622b1772928920301933d540dcf175c1f260c874f94d8244152c0',1),(49,'kfmbfkln lkjgkfjcfr','hbkmnnmn@gmail.com','ydxbzvsad','hbkmnnmngmail.com','a7e9a32747fdb93348685f5e78a4a9b8f41694cbf812383c9b737365288395ef',1),(50,'Pancho Villa','pancho@villa.rev','Revolucionario','panchovilla.rev','a7dfb75d72e0462df7d4669d91b5be096859e9355a6e299e2a372c6178d95657',1),(51,'Mujer Maravilla','ww_official@universe.dc','Amazona','ww_officialuniverse.dc','188203187cc0b400754d5e39002f59a8ce84d1c1a061dbb72edbae4632c370fc',1),(52,'Oliver Queen','o_queen@universe.tv.dc','Alcalde / Green Arrow','o_queenuniverse.tv.dc','8af8f97b064e5ae2450d8a3134d1ca6684e685147269e01d3fed427b61c83973',1),(53,'Bob Esponja','bobosponge@nick.cn','Idiota Submairno','bobospongenick.cn','9c6576c75b5e32e3a5323ee8e4de6ff1a6475129d5ee9f4abef5c99791faa1a4',1);
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

-- Dump completed on 2018-12-20 14:50:52
