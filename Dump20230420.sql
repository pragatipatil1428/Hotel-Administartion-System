-- MySQL dump 10.13  Distrib 8.0.23, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: restaurant
-- ------------------------------------------------------
-- Server version	8.0.22

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `add_items`
--

DROP TABLE IF EXISTS `add_items`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `add_items` (
  `id` varchar(20) NOT NULL,
  `name` varchar(45) NOT NULL,
  `price` decimal(10,2) NOT NULL,
  `date` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `add_items`
--

LOCK TABLES `add_items` WRITE;
/*!40000 ALTER TABLE `add_items` DISABLE KEYS */;
INSERT INTO `add_items` VALUES ('BN4638','Pizza',150.00,'12 June 2022'),('BN6026','pani puri',80.00,'13 February 2021'),('BN6500','Bhel',30.00,'20 April 2023'),('BN7435','samosa',20.00,'13 February 2021'),('BN7559','noodles',80.88,'13 February 2021'),('BN9388','Pav Bhaji',60.00,'13 February 2021'),('BN9759','dhokla',70.68,'13 February 2021');
/*!40000 ALTER TABLE `add_items` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `customer_details`
--

DROP TABLE IF EXISTS `customer_details`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `customer_details` (
  `bill_id` varchar(45) NOT NULL,
  `name` varchar(45) NOT NULL,
  `phone` varchar(45) NOT NULL,
  `total` decimal(10,2) NOT NULL,
  `date_time` varchar(45) NOT NULL,
  PRIMARY KEY (`bill_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customer_details`
--

LOCK TABLES `customer_details` WRITE;
/*!40000 ALTER TABLE `customer_details` DISABLE KEYS */;
INSERT INTO `customer_details` VALUES ('BILL131','ajay','9090909090',824.00,'15-02-2021 11:49:22'),('BILL167','Prate','9876789877',201.36,'15-02-2021 12:38:11'),('BILL2319','AAA','8765456789',80.88,'15-02-2021 12:19:24'),('BILL2955','ghgg','8765432109',303.12,'15-02-2021 12:26:13'),('BILL3713','ABC','9089786746',140.00,'12-06-2022 14:55:18'),('BILL3839','ban','1234567890',423.12,'15-02-2021 12:35:19'),('BILL4761','jarif`','8766448446',784.00,''),('BILL4998','pranit','9898989898',924.88,'15-02-2021 12:05:05'),('BILL6255','pragati','4576868868',341.76,'18-02-2021 12:27:20'),('BILL6542','abc','8877998877',100.00,'06-04-2021 19:09:16'),('BILL6700','kailas','7876655645',161.76,'15-02-2021 12:29:22'),('BILL6805','Siya','9876787665',140.00,'29-11-2021 18:15:11'),('BILL7285','asd','6767545645',80.00,'18-06-2022 10:18:30'),('BILL8022','Prati','6565656565',844.00,'15-02-2021 11:50:33'),('BILL909','sneha','8987676767',160.00,'24-03-2023 13:59:03'),('BILL9183','ABC','8765456787',90.68,'15-02-2021 12:07:31'),('BILL932','nitin','7654343434',161.76,'15-02-2021 12:30:25'),('BILL9531','jgcjytck','0987654321',150.68,'15-02-2021 12:27:37'),('BILL9544','sneha','9898989898',804.00,'15-02-2021 11:33:17');
/*!40000 ALTER TABLE `customer_details` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ordereditems`
--

DROP TABLE IF EXISTS `ordereditems`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ordereditems` (
  `id` varchar(20) NOT NULL,
  `name` varchar(45) DEFAULT NULL,
  `quantity` int DEFAULT NULL,
  `price` decimal(10,2) DEFAULT NULL,
  `total` decimal(10,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ordereditems`
--

LOCK TABLES `ordereditems` WRITE;
/*!40000 ALTER TABLE `ordereditems` DISABLE KEYS */;
/*!40000 ALTER TABLE `ordereditems` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `staff_details`
--

DROP TABLE IF EXISTS `staff_details`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `staff_details` (
  `name` varchar(30) NOT NULL,
  `position` varchar(45) DEFAULT NULL,
  `address` varchar(45) DEFAULT NULL,
  `mobile` varchar(45) DEFAULT NULL,
  `joiningdate` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `staff_details`
--

LOCK TABLES `staff_details` WRITE;
/*!40000 ALTER TABLE `staff_details` DISABLE KEYS */;
INSERT INTO `staff_details` VALUES ('ramprasad','Waiter','latur','5645677889','15 February 2021'),('babu','Waiter','pune','5645677889','15 February 2021'),('chintu','Chef','bodhan','9887766554','15 February 2021'),('sneha','Manager','nilanga','7878798667','15 February 2021'),('pratiksha','Reception','nanded','7867567890','15 February 2021'),('jay','Chef','pune','9898989898','18 February 2021'),('demo','Chef','Nagpur','9089897656','20 April 2023');
/*!40000 ALTER TABLE `staff_details` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-04-20 15:30:28
