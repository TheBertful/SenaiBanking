-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: localhost    Database: mydb
-- ------------------------------------------------------
-- Server version	5.7.18-log

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
-- Table structure for table `banco`
--

DROP TABLE IF EXISTS `banco`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `banco` (
  `idBanco` int(10) unsigned NOT NULL,
  `nome` varchar(45) NOT NULL,
  PRIMARY KEY (`idBanco`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `banco`
--

LOCK TABLES `banco` WRITE;
/*!40000 ALTER TABLE `banco` DISABLE KEYS */;
/*!40000 ALTER TABLE `banco` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cliente`
--

DROP TABLE IF EXISTS `cliente`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cliente` (
  `idCliente` int(11) NOT NULL AUTO_INCREMENT,
  `cpf` varchar(11) NOT NULL,
  `nome` varchar(45) NOT NULL,
  `senha` varchar(45) NOT NULL,
  PRIMARY KEY (`idCliente`),
  UNIQUE KEY `cpf_UNIQUE` (`cpf`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cliente`
--

LOCK TABLES `cliente` WRITE;
/*!40000 ALTER TABLE `cliente` DISABLE KEYS */;
/*!40000 ALTER TABLE `cliente` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `contacontabil`
--

DROP TABLE IF EXISTS `contacontabil`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `contacontabil` (
  `idContaContabil` int(11) NOT NULL AUTO_INCREMENT,
  `valor` decimal(10,2) NOT NULL DEFAULT '0.00',
  `idBanco` int(10) unsigned NOT NULL,
  `tipo` varchar(20) NOT NULL,
  PRIMARY KEY (`idContaContabil`),
  KEY `fk_ContaContabil_Banco1_idx` (`idBanco`),
  CONSTRAINT `fk_ContaContabil_Banco1` FOREIGN KEY (`idBanco`) REFERENCES `banco` (`idBanco`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `contacontabil`
--

LOCK TABLES `contacontabil` WRITE;
/*!40000 ALTER TABLE `contacontabil` DISABLE KEYS */;
/*!40000 ALTER TABLE `contacontabil` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `contacorrente`
--

DROP TABLE IF EXISTS `contacorrente`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `contacorrente` (
  `idContaCorrente` int(11) NOT NULL AUTO_INCREMENT,
  `tipo` varchar(15) NOT NULL,
  `saldo` decimal(10,2) NOT NULL DEFAULT '0.00',
  `idCliente` int(11) NOT NULL,
  `idBanco` int(10) unsigned NOT NULL,
  PRIMARY KEY (`idContaCorrente`),
  KEY `fk_ContaCorrente_Cliente1_idx` (`idCliente`),
  KEY `fk_ContaCorrente_Banco1_idx` (`idBanco`),
  CONSTRAINT `fk_ContaCorrente_Banco1` FOREIGN KEY (`idBanco`) REFERENCES `banco` (`idBanco`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_ContaCorrente_Cliente1` FOREIGN KEY (`idCliente`) REFERENCES `cliente` (`idCliente`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `contacorrente`
--

LOCK TABLES `contacorrente` WRITE;
/*!40000 ALTER TABLE `contacorrente` DISABLE KEYS */;
/*!40000 ALTER TABLE `contacorrente` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `emprestimo`
--

DROP TABLE IF EXISTS `emprestimo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `emprestimo` (
  `idEmprestimo` int(11) NOT NULL AUTO_INCREMENT,
  `valorTotal` decimal(10,2) NOT NULL DEFAULT '0.00',
  `qtdParcelas` int(11) NOT NULL DEFAULT '0',
  `dataCriacao` date NOT NULL,
  `idContaCorrente` int(11) NOT NULL,
  `tipo` varchar(15) NOT NULL,
  PRIMARY KEY (`idEmprestimo`),
  KEY `fk_Emprestimo_ContaCorrente1_idx` (`idContaCorrente`),
  CONSTRAINT `fk_Emprestimo_ContaCorrente1` FOREIGN KEY (`idContaCorrente`) REFERENCES `contacorrente` (`idContaCorrente`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `emprestimo`
--

LOCK TABLES `emprestimo` WRITE;
/*!40000 ALTER TABLE `emprestimo` DISABLE KEYS */;
/*!40000 ALTER TABLE `emprestimo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `emprestimoparcelas`
--

DROP TABLE IF EXISTS `emprestimoparcelas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `emprestimoparcelas` (
  `idEmprestimoParcelas` int(11) NOT NULL AUTO_INCREMENT,
  `valor` decimal(10,2) NOT NULL DEFAULT '0.00',
  `prazoVencimento` date NOT NULL,
  `idEmprestimo` int(11) NOT NULL,
  `status` varchar(10) NOT NULL DEFAULT 'Pendente',
  PRIMARY KEY (`idEmprestimoParcelas`),
  KEY `fk_EmprestimoParcelas_Emprestimo1_idx` (`idEmprestimo`),
  CONSTRAINT `fk_EmprestimoParcelas_Emprestimo1` FOREIGN KEY (`idEmprestimo`) REFERENCES `emprestimo` (`idEmprestimo`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `emprestimoparcelas`
--

LOCK TABLES `emprestimoparcelas` WRITE;
/*!40000 ALTER TABLE `emprestimoparcelas` DISABLE KEYS */;
/*!40000 ALTER TABLE `emprestimoparcelas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `investimento`
--

DROP TABLE IF EXISTS `investimento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `investimento` (
  `idContaInvestimento` int(11) NOT NULL AUTO_INCREMENT,
  `saldo` decimal(10,2) NOT NULL DEFAULT '0.00',
  `dataInvestimento` date NOT NULL,
  `vencimento` date NOT NULL,
  `idInvestimento` int(11) NOT NULL,
  `idContaCorrente` int(11) NOT NULL,
  `valorInicial` decimal(10,2) NOT NULL,
  `liquides` varchar(10) NOT NULL,
  PRIMARY KEY (`idContaInvestimento`),
  KEY `fk_ContaInvestimento_Investimento1_idx` (`idInvestimento`),
  KEY `fk_ContaInvestimento_ContaCorrente1_idx` (`idContaCorrente`),
  CONSTRAINT `fk_ContaInvestimento_ContaCorrente1` FOREIGN KEY (`idContaCorrente`) REFERENCES `contacorrente` (`idContaCorrente`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_ContaInvestimento_Investimento1` FOREIGN KEY (`idInvestimento`) REFERENCES `tipoinvestimento` (`idInvestimento`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `investimento`
--

LOCK TABLES `investimento` WRITE;
/*!40000 ALTER TABLE `investimento` DISABLE KEYS */;
/*!40000 ALTER TABLE `investimento` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `movimentacao`
--

DROP TABLE IF EXISTS `movimentacao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `movimentacao` (
  `idContaCorrente` int(11) NOT NULL,
  `idMovimentacao` int(11) NOT NULL AUTO_INCREMENT,
  `tipo` varchar(10) NOT NULL,
  `data` date NOT NULL,
  `valor` decimal(10,2) NOT NULL DEFAULT '0.00',
  `descricao` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idMovimentacao`),
  KEY `fk_Movimentacao_ContaCorrente1_idx` (`idContaCorrente`),
  CONSTRAINT `fk_Movimentacao_ContaCorrente1` FOREIGN KEY (`idContaCorrente`) REFERENCES `contacorrente` (`idContaCorrente`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `movimentacao`
--

LOCK TABLES `movimentacao` WRITE;
/*!40000 ALTER TABLE `movimentacao` DISABLE KEYS */;
/*!40000 ALTER TABLE `movimentacao` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipoinvestimento`
--

DROP TABLE IF EXISTS `tipoinvestimento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tipoinvestimento` (
  `idInvestimento` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(20) NOT NULL,
  `rendimento` decimal(10,2) NOT NULL DEFAULT '0.00',
  `taxaAdm` decimal(10,2) NOT NULL DEFAULT '0.00',
  `carencia` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`idInvestimento`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipoinvestimento`
--

LOCK TABLES `tipoinvestimento` WRITE;
/*!40000 ALTER TABLE `tipoinvestimento` DISABLE KEYS */;
/*!40000 ALTER TABLE `tipoinvestimento` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-09-27 11:20:54
