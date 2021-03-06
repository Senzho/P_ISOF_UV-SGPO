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
-- Table structure for table `acabado`
--

DROP TABLE IF EXISTS `acabado`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `acabado` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(100) DEFAULT NULL,
  `ancho` double DEFAULT NULL,
  `alto` double DEFAULT NULL,
  `grosor` double DEFAULT NULL,
  `precio` double DEFAULT NULL,
  `iva` tinyint(1) DEFAULT NULL,
  `idMoneda` int(11) DEFAULT NULL,
  `idMaterial` int(11) DEFAULT NULL,
  `activo` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `idMoneda` (`idMoneda`),
  KEY `idMaterial` (`idMaterial`),
  CONSTRAINT `acabado_ibfk_1` FOREIGN KEY (`idMoneda`) REFERENCES `moneda` (`id`),
  CONSTRAINT `acabado_ibfk_2` FOREIGN KEY (`idMaterial`) REFERENCES `material` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `acabado`
--

LOCK TABLES `acabado` WRITE;
/*!40000 ALTER TABLE `acabado` DISABLE KEYS */;
INSERT INTO `acabado` VALUES (1,'Frosy',2,2,1.5,220.33,1,1,1,1),(2,'Agatha',2,2,1.5,220.33,1,1,1,1),(3,'Acabado Prueba 1',2.5,2,0.5,300.3,1,2,4,1),(4,'Acabado Prueba 2',2.5,2,0.5,450,1,2,4,0),(5,'klhñjkmpoi 988',2.5,2,0.5,99,1,1,5,1),(6,'9876976',8,8,8,987,1,2,6,1),(7,'546465657',4,4,4,21,1,2,6,1),(8,'987toiukjn',8,8,8,65,1,1,7,1),(9,'oyilukjbn',9,9,9,56,1,1,7,1),(10,'kjhkjgh',5,5,5,987,1,1,8,1),(11,'98769876',5,5,5,234,1,1,8,1),(12,'kljkh 654785 fgds',65,56,65,45,1,2,9,1),(13,'hklj asdfsf ´p´l',1,1,0.5,500,1,1,10,1),(14,'lkjlkhlkjh',8,8,8,89,1,1,11,NULL);
/*!40000 ALTER TABLE `acabado` ENABLE KEYS */;
UNLOCK TABLES;

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
-- Table structure for table `material`
--

DROP TABLE IF EXISTS `material`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `material` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(100) DEFAULT NULL,
  `proveedor` varchar(100) DEFAULT NULL,
  `clave` varchar(100) DEFAULT NULL,
  `alto` double DEFAULT NULL,
  `ancho` double DEFAULT NULL,
  `grosor` double DEFAULT NULL,
  `precio` double DEFAULT NULL,
  `iva` tinyint(1) DEFAULT NULL,
  `idCategoria` int(11) DEFAULT NULL,
  `idMoneda` int(11) DEFAULT NULL,
  `activo` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `idCategoria` (`idCategoria`),
  KEY `idMoneda` (`idMoneda`),
  CONSTRAINT `material_ibfk_1` FOREIGN KEY (`idCategoria`) REFERENCES `categoria` (`id`),
  CONSTRAINT `material_ibfk_2` FOREIGN KEY (`idMoneda`) REFERENCES `moneda` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `material`
--

LOCK TABLES `material` WRITE;
/*!40000 ALTER TABLE `material` DISABLE KEYS */;
INSERT INTO `material` VALUES (1,'MDF','Maisa','X00YU7',1.5,1,0.5,230.6,1,1,1,1),(2,'Melamina','Maisa','X01Z67',1,0.5,0.5,88.36,1,1,1,1),(3,'Material de Prueba','Un Proveedor','X007YKF',2,2.5,0.5,200,1,1,2,1),(4,'Material de Prueba','Un Proveedor','X007YKF',2,2.5,0.5,200,1,1,2,1),(5,'iojhojhkñj kljhkolh','iyugkhjbknm','ioug87fcj',2,2.5,0.5,230.1,1,1,1,1),(6,'yo79869786','8976987','98767896',7,7,7,54,1,1,2,1),(7,'mnm asdfas','lkjhlkjh','ñkjnljk',6,6,6,253,1,1,1,0),(8,'lihhkjhlkjh','kljhlkjhlkjh','lkjhlkjhlkjh',8,8,8,654,1,1,1,1),(9,'kjhkgh yiutty k.b,mn','jdbsjkk','7668767',32,34,30,211,1,1,2,1),(10,'kljhlkjh m,nb,mnb ssdfad','nvjdjdn jsjsj','263453456',1,1,0.3,980,1,2,1,1),(11,'luhlkjhljhk','lkjhlkjhlkjhlkjh','kljhlkjhlkjh',7,7,7,32,1,2,1,NULL);
/*!40000 ALTER TABLE `material` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `moneda`
--

DROP TABLE IF EXISTS `moneda`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `moneda` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `moneda`
--

LOCK TABLES `moneda` WRITE;
/*!40000 ALTER TABLE `moneda` DISABLE KEYS */;
INSERT INTO `moneda` VALUES (1,'MXN'),(2,'USD');
/*!40000 ALTER TABLE `moneda` ENABLE KEYS */;
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
) ENGINE=InnoDB AUTO_INCREMENT=171 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `permiso`
--

LOCK TABLES `permiso` WRITE;
/*!40000 ALTER TABLE `permiso` DISABLE KEYS */;
INSERT INTO `permiso` VALUES (1,'Materiales',1,1,1,1,1),(2,'Herrajes',1,1,1,1,1),(3,'Accesorios',1,1,1,1,1),(4,'Usuarios',1,1,1,1,1),(5,'Presupuestos',1,1,1,1,1),(11,'Materiales',1,1,0,0,39),(12,'Herrajes',1,1,0,0,39),(13,'Accesorios',1,1,0,0,39),(14,'Usuarios',1,0,0,0,39),(15,'Presupuestos',1,0,0,0,39),(16,'Materiales',1,0,0,1,40),(17,'Herrajes',1,0,0,1,40),(18,'Accesorios',1,0,0,1,40),(19,'Usuarios',1,0,0,0,40),(20,'Presupuestos',1,1,1,1,40),(21,'Materiales',1,0,0,1,41),(22,'Herrajes',1,0,0,1,41),(23,'Accesorios',1,0,0,1,41),(24,'Usuarios',0,0,0,0,41),(25,'Presupuestos',0,0,0,0,41),(26,'Materiales',0,0,0,0,42),(27,'Herrajes',0,0,0,0,42),(28,'Accesorios',0,0,0,0,42),(29,'Usuarios',0,0,0,0,42),(30,'Presupuestos',1,1,1,0,42),(31,'Materiales',0,0,0,0,43),(32,'Herrajes',0,0,0,0,43),(33,'Accesorios',0,0,0,0,43),(34,'Usuarios',1,1,1,0,43),(35,'Presupuestos',1,0,1,1,43),(36,'Materiales',1,0,0,0,44),(37,'Herrajes',1,0,0,0,44),(38,'Accesorios',1,0,0,0,44),(39,'Usuarios',0,0,0,0,44),(40,'Presupuestos',1,1,1,0,44),(41,'Materiales',1,1,0,0,45),(42,'Herrajes',1,1,0,0,45),(43,'Accesorios',1,1,0,0,45),(44,'Usuarios',1,1,0,0,45),(45,'Presupuestos',1,1,0,0,45),(46,'Materiales',1,0,1,0,46),(47,'Herrajes',1,0,1,0,46),(48,'Accesorios',1,0,1,0,46),(49,'Usuarios',0,0,0,0,46),(50,'Presupuestos',1,1,1,1,46),(51,'Materiales',1,0,0,1,47),(52,'Herrajes',1,0,0,1,47),(53,'Accesorios',1,0,0,1,47),(54,'Usuarios',0,0,0,0,47),(55,'Presupuestos',1,0,0,0,47),(56,'Materiales',0,0,0,0,48),(57,'Herrajes',0,0,0,0,48),(58,'Accesorios',0,0,0,0,48),(59,'Usuarios',1,1,1,0,48),(60,'Presupuestos',1,1,1,0,48),(61,'Materiales',1,0,0,0,49),(62,'Herrajes',1,1,0,0,49),(63,'Accesorios',1,0,1,0,49),(64,'Usuarios',1,0,0,1,49),(65,'Presupuestos',0,0,0,0,49),(66,'Materiales',1,1,1,0,50),(67,'Herrajes',1,1,1,0,50),(68,'Accesorios',1,1,1,0,50),(69,'Usuarios',0,0,0,0,50),(70,'Presupuestos',0,0,0,0,50),(71,'Materiales',0,0,0,0,51),(72,'Herrajes',0,0,0,0,51),(73,'Accesorios',0,0,0,0,51),(74,'Usuarios',1,1,1,0,51),(75,'Presupuestos',1,0,0,0,51),(76,'Materiales',1,0,0,0,52),(77,'Herrajes',1,0,0,0,52),(78,'Accesorios',1,0,0,0,52),(79,'Usuarios',0,0,0,0,52),(80,'Presupuestos',1,1,1,0,52),(81,'Materiales',1,1,0,0,53),(82,'Herrajes',1,1,0,0,53),(83,'Accesorios',1,1,0,0,53),(84,'Usuarios',0,0,0,0,53),(85,'Presupuestos',0,0,0,0,53),(86,'Materiales',1,0,0,0,54),(87,'Herrajes',1,0,0,0,54),(88,'Accesorios',1,0,0,0,54),(89,'Usuarios',1,0,0,0,54),(90,'Presupuestos',1,0,0,0,54),(91,'Materiales',0,0,0,0,55),(92,'Herrajes',0,0,0,0,55),(93,'Accesorios',0,0,0,0,55),(94,'Usuarios',0,0,0,0,55),(95,'Presupuestos',1,0,0,0,55),(96,'Materiales',0,0,0,0,56),(97,'Herrajes',0,0,0,0,56),(98,'Accesorios',0,0,0,0,56),(99,'Usuarios',1,1,1,1,56),(100,'Presupuestos',0,0,0,0,56),(101,'Materiales',0,0,0,0,57),(102,'Herrajes',0,0,0,0,57),(103,'Accesorios',1,0,0,1,57),(104,'Usuarios',1,0,0,1,57),(105,'Presupuestos',0,0,0,0,57),(106,'Materiales',1,1,1,0,58),(107,'Herrajes',0,0,0,0,58),(108,'Accesorios',0,0,0,0,58),(109,'Usuarios',0,0,0,0,58),(110,'Presupuestos',0,0,0,0,58),(111,'Materiales',1,0,0,0,59),(112,'Herrajes',0,0,0,0,59),(113,'Accesorios',0,0,0,0,59),(114,'Usuarios',0,0,0,0,59),(115,'Presupuestos',0,0,0,0,59),(116,'Materiales',0,0,0,0,60),(117,'Herrajes',0,0,0,0,60),(118,'Accesorios',1,1,1,0,60),(119,'Usuarios',0,0,0,0,60),(120,'Presupuestos',0,0,0,0,60),(121,'Materiales',0,0,0,0,61),(122,'Herrajes',0,0,0,0,61),(123,'Accesorios',0,0,0,0,61),(124,'Usuarios',0,0,0,0,61),(125,'Presupuestos',1,0,1,1,61),(126,'Materiales',0,0,0,0,62),(127,'Herrajes',0,0,0,0,62),(128,'Accesorios',0,0,0,0,62),(129,'Usuarios',1,0,0,1,62),(130,'Presupuestos',0,0,0,0,62),(131,'Materiales',0,0,0,0,63),(132,'Herrajes',0,0,0,0,63),(133,'Accesorios',0,0,0,0,63),(134,'Usuarios',0,0,0,0,63),(135,'Presupuestos',1,0,1,0,63),(136,'Materiales',1,0,0,0,64),(137,'Herrajes',1,1,0,0,64),(138,'Accesorios',1,0,1,0,64),(139,'Usuarios',1,0,0,1,64),(140,'Presupuestos',1,0,0,0,64),(141,'Materiales',1,1,1,1,65),(142,'Herrajes',0,0,0,0,65),(143,'Accesorios',0,0,0,0,65),(144,'Usuarios',0,0,0,0,65),(145,'Presupuestos',0,0,0,0,65),(146,'Materiales',1,0,0,0,66),(147,'Herrajes',0,1,0,0,66),(148,'Accesorios',0,0,1,0,66),(149,'Usuarios',0,0,0,1,66),(150,'Presupuestos',0,0,1,0,66),(151,'Materiales',1,0,0,0,67),(152,'Herrajes',1,0,0,0,67),(153,'Accesorios',0,0,0,0,67),(154,'Usuarios',0,0,0,0,67),(155,'Presupuestos',0,0,0,0,67),(156,'Materiales',0,0,0,0,68),(157,'Herrajes',0,0,0,0,68),(158,'Accesorios',0,0,0,0,68),(159,'Usuarios',1,0,0,1,68),(160,'Presupuestos',1,0,0,1,68),(161,'Materiales',0,0,0,0,69),(162,'Herrajes',1,0,0,0,69),(163,'Accesorios',1,0,0,0,69),(164,'Usuarios',0,0,0,0,69),(165,'Presupuestos',0,0,0,0,69),(166,'False',0,0,0,0,70),(167,'False',0,0,0,0,70),(168,'False',1,0,0,0,70),(169,'False',0,0,0,0,70),(170,'False',1,0,0,0,70);
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
) ENGINE=InnoDB AUTO_INCREMENT=71 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuario`
--

LOCK TABLES `usuario` WRITE;
/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
INSERT INTO `usuario` VALUES (1,'Víctor Javier García Mascareñas','vijagama@outlook.es','Diseñador','victor','e63c8c8a0f530555c761a7f3383121d33be720b83bc038a8ca54b6e6c42300e1',1),(36,'María Violeta Magaña Castelán','mavimacas@gmail.com','Hostess','mavimacasgmail.com','896e97a0aa774754268d03e36fde262761f4e1d1fc5e14adb649dbdf90324936',1),(39,'Usuario Prueba','usupru@gmail.com','Puesto Prueba','usuprugmail.com','32e1b7f5275444ef919636649aeb6f78b983e497f25ec25ec1835fdc2ffc8bd9',1),(40,'Darth Vader','darth_vader@dark.side','Lord Sith','darth_vaderdark.side','71eecf883c6c8cf8c4940ba1074444e55dc8b12ebe51a562a8cc8040470deee5',1),(41,'Batman','real_batman@super.hero','Batman (Millionaire)','real_batmansuper.hero','ec2fb5bf1f7ae6767e146aefc44ec3cf4b2efd5f34946e2a35e44c9ab952a598',1),(42,'Luis Miguel','elsol@luis.miguel','Cantante Mediocre','elsolluis.miguel','a9f58d878280981d983db52906e0834f2bfd3a3f99d20243be8562260a39dc58',1),(43,'Tom Cruise','tom_cruise@tom.cruise','Actor Sobrevalorado','tom_cruisetom.cruise','2cde9d3671d713bf10f0afc9218d7e7d9fd84adbed2419c95d6a5b174af7c8e0',1),(44,'Michael Jackson','jack_mich@jack.son','Rey del Pop','jack_michjack.son','e90b72b878103f7388b3c6fcc52614315cb82bdd35656095c5c473136b686269',1),(45,'89769876 98769876','98769876@87687.364','987896','9876987687687.364','c9a5d6b98c6bebb4e039cf835c03b118976dce3a171609a914363b6b19fedf3b',1),(46,'Juan Mendoza','jumendo@gmail.com','Arquitecto','jumendogmail.com','86ffbc3c17f8ef95729250699dae34b4dc5922941a41aeba6833a6715c520125',1),(47,'Helena Vabiera','helebaba@outlook.es','Contador','helebabaoutlook.es','f9e868b676808a78b1c76ab04bf9145663b77863d8eb2337d16bf4e06bbed77a',1),(48,'khjgjgf utfutrfyutv','iytiyut@gmail.com','0987hkbj','iytiyutgmail.com','ba562de948e622b1772928920301933d540dcf175c1f260c874f94d8244152c0',1),(49,'kfmbfkln lkjgkfjcfr','hbkmnnmn@gmail.com','ydxbzvsad','hbkmnnmngmail.com','a7e9a32747fdb93348685f5e78a4a9b8f41694cbf812383c9b737365288395ef',1),(50,'Pancho Villa','pancho@villa.rev','Revolucionario','panchovilla.rev','a7dfb75d72e0462df7d4669d91b5be096859e9355a6e299e2a372c6178d95657',1),(51,'Mujer Maravilla','ww_official@universe.dc','Amazona','ww_officialuniverse.dc','188203187cc0b400754d5e39002f59a8ce84d1c1a061dbb72edbae4632c370fc',1),(52,'Oliver Queen','o_queen@universe.tv.dc','Alcalde / Green Arrow','o_queenuniverse.tv.dc','8af8f97b064e5ae2450d8a3134d1ca6684e685147269e01d3fed427b61c83973',1),(53,'Bob Esponja','bobosponge@nick.cn','Idiota Submairno','bobospongenick.cn','9c6576c75b5e32e3a5323ee8e4de6ff1a6475129d5ee9f4abef5c99791faa1a4',1),(54,'jlkjn iutfuiy 987guhi','igkjlh@mgisl.com','ijlkjlñjkñk','igkjlhmgisl.com','7523cb3d99cc159d32249423a2f79b0673720c7e4c16b982dd9e09a04a28c065',1),(55,'lkjlhñkjlkbn','ñlkjñkljñ@kuhoiul.com','oihlkjh','ñlkjñkljñkuhoiul.com','152130e5ed074789f628b1a0ce21b9970ddc7103bccbc27988ac39fce2aa3a2d',1),(56,'9087098708','0980897@0987.com','90869876','09808970987.com','b2476aa85eea5fb48f72dc00f0520e2ef0783f5825b7bfd1702cdd8799f51545',1),(57,'okjpio´poi´','kjhj@kjhj.com','iougiuyty','kjhjkjhj.com','062a21c453d01f6d444d14ffc4aec4ca6a0c2a7be13f9914b82d1a3e31377679',1),(58,'kfkfk shspe isaplk','jdkdncp@jgil.cos','jfpsne jdap','jdkdncpjgil.cos','8128f265e61ffee09f42100c29fa872a8b7a50211eeceaeefb554704da622e3d',1),(59,'jhkljh ouygio ioyou','oiuy@ihkljh.com','iulkjkhñlk','oiuyihkljh.com','ee7e2ddd98f6deea8cc8eb47a5c55ffaf5d3ae31b3ad5a0488c48cefee705b70',1),(60,'ph0íjokok','9876@0987.987','897yuhjbn','98760987.987','7746c1513181162ca5118c4765c7a954a92a68ccee920a16cfb20dba993a08e0',1),(61,'0987p987','09870987@0987.omj','987guoijn','098709870987.omj','678d218e2416971fc3fa6f94a43a4370d6a16ec9a022a05f31393649cb0bea59',1),(62,'098709870987','09870987@987.com','098p897','09870987987.com','07583a9ab032e9dcf3424a758d9160f9003f11663e5e32c463e125d860639fcd',1),(63,'jdism hsiqps ksoao','jdjsk@hgmai.cimk','jcn lxojsm','jdjskhgmai.cimk','fd575be5532eddfddd1a0bb3d7fcf123d80e9fec3b31df53f5835764f2ec8574',1),(64,'jdjd uwodl 0pqo iwksñ','jdhdi@gmail.com','kdjso isiso','jdhdigmail.com','0009d9ad82dc98ad5d8132c0c56e08ce4e2cf2c3860ddf0dccfb47b86b10898a',1),(65,'kjh,kg','kjhgkjgh@kjhgkh.lkjh','kljhlkhljh','kjhgkjghkjhgkh.lkjh','bf344b0839b232d7091df0e45937ac5e9a606a6a49ddd802eaeb196f82e03890',1),(66,'jhgkjhgkhg','ljlkjh@lkjh.com','ljkhhjk','ljlkjhlkjh.com','2b208f940983a8c09a93cea4ae2fd868664d807b2478ecbab925be1339bcc3c0',1),(67,'vkghhjgv','hjhgfjhgf@ljhkhlkjh.kjgf','uiljkhklj.h','hjhgfjhgfljhkhlkjh.kjgf','847a4e5a52ec8b795823be7cc0372d3df745fee93e944e0e5d57bc5e9136d1a5',1),(68,'jgvkln hgfd','jhkgkj@kjh.nih','jkhgfhjk','jhkgkjkjh.nih','8e0944d99e14cc1460fdd1974228dfcd17f88835900a541a15370daee95551f7',1),(69,'ohlkjhlkjh','lkjlkjh@kjh.com','lijhljh','lkjlkjhkjh.com','dd74f38f9932f0151b1c35e2d105542c246741b88d21bf40237505386e6bf6ec',1),(70,'lkjjhlkjh','saba@sabaa.com','oiblkj.,n','sabasabaa.com','83222c181c1af6c79693c034b8dae75c91bc746870ab3167ee92aceaeb66eabd',1);
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

-- Dump completed on 2018-12-22 13:46:30
