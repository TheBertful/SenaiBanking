-- MySQL Script generated by MySQL Workbench
-- Fri Sep 28 09:30:39 2018
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `mydb` DEFAULT CHARACTER SET utf8 ;
USE `mydb` ;

-- -----------------------------------------------------
-- Table `mydb`.`banco`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`banco` (
  `idBanco` INT(10) UNSIGNED NOT NULL,
  `nome` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`idBanco`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `mydb`.`cliente`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`cliente` (
  `idCliente` INT(11) NOT NULL AUTO_INCREMENT,
  `cpf` VARCHAR(11) NOT NULL,
  `nome` VARCHAR(45) NOT NULL,
  `senha` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`idCliente`),
  UNIQUE INDEX `cpf_UNIQUE` (`cpf` ASC))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `mydb`.`contacontabil`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`contacontabil` (
  `idContaContabil` INT(11) NOT NULL AUTO_INCREMENT,
  `valor` DECIMAL(10,2) NOT NULL DEFAULT '0.00',
  `idBanco` INT(10) UNSIGNED NOT NULL,
  `tipo` VARCHAR(20) NOT NULL,
  PRIMARY KEY (`idContaContabil`),
  INDEX `fk_ContaContabil_Banco1_idx` (`idBanco` ASC),
  CONSTRAINT `fk_ContaContabil_Banco1`
    FOREIGN KEY (`idBanco`)
    REFERENCES `mydb`.`banco` (`idBanco`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `mydb`.`PerfilCliente`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`PerfilCliente` (
  `idPerfilCliente` INT NOT NULL AUTO_INCREMENT,
  `tipo` VARCHAR(45) NOT NULL,
  `taxa` DECIMAL(10,2) NOT NULL DEFAULT 0,
  `limitePessoal` DECIMAL(10,2) NOT NULL DEFAULT 0,
  PRIMARY KEY (`idPerfilCliente`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`contacorrente`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`contacorrente` (
  `idContaCorrente` INT(11) NOT NULL AUTO_INCREMENT,
  `tipo` VARCHAR(15) NOT NULL,
  `saldo` DECIMAL(10,2) NOT NULL DEFAULT '0.00',
  `idCliente` INT(11) NOT NULL,
  `idBanco` INT(10) UNSIGNED NOT NULL,
  `idPerfilCliente` INT NOT NULL,
  PRIMARY KEY (`idContaCorrente`),
  INDEX `fk_ContaCorrente_Cliente1_idx` (`idCliente` ASC),
  INDEX `fk_ContaCorrente_Banco1_idx` (`idBanco` ASC),
  INDEX `fk_contacorrente_PerfilCliente1_idx` (`idPerfilCliente` ASC),
  CONSTRAINT `fk_ContaCorrente_Banco1`
    FOREIGN KEY (`idBanco`)
    REFERENCES `mydb`.`banco` (`idBanco`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_ContaCorrente_Cliente1`
    FOREIGN KEY (`idCliente`)
    REFERENCES `mydb`.`cliente` (`idCliente`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_contacorrente_PerfilCliente1`
    FOREIGN KEY (`idPerfilCliente`)
    REFERENCES `mydb`.`PerfilCliente` (`idPerfilCliente`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `mydb`.`emprestimo`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`emprestimo` (
  `idEmprestimo` INT(11) NOT NULL AUTO_INCREMENT,
  `valorTotal` DECIMAL(10,2) NOT NULL DEFAULT '0.00',
  `qtdParcelas` INT(11) NOT NULL DEFAULT '0',
  `dataCriacao` DATE NOT NULL,
  `idContaCorrente` INT(11) NOT NULL,
  `tipo` VARCHAR(15) NOT NULL,
  PRIMARY KEY (`idEmprestimo`),
  INDEX `fk_Emprestimo_ContaCorrente1_idx` (`idContaCorrente` ASC),
  CONSTRAINT `fk_Emprestimo_ContaCorrente1`
    FOREIGN KEY (`idContaCorrente`)
    REFERENCES `mydb`.`contacorrente` (`idContaCorrente`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `mydb`.`emprestimoparcelas`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`emprestimoparcelas` (
  `idEmprestimoParcelas` INT(11) NOT NULL AUTO_INCREMENT,
  `valor` DECIMAL(10,2) NOT NULL DEFAULT '0.00',
  `prazoVencimento` DATE NOT NULL,
  `idEmprestimo` INT(11) NOT NULL,
  `status` VARCHAR(10) NOT NULL DEFAULT 'Pendente',
  PRIMARY KEY (`idEmprestimoParcelas`),
  INDEX `fk_EmprestimoParcelas_Emprestimo1_idx` (`idEmprestimo` ASC),
  CONSTRAINT `fk_EmprestimoParcelas_Emprestimo1`
    FOREIGN KEY (`idEmprestimo`)
    REFERENCES `mydb`.`emprestimo` (`idEmprestimo`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `mydb`.`tipoinvestimento`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`tipoinvestimento` (
  `idInvestimento` INT(11) NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(20) NOT NULL,
  `rendimento` DECIMAL(10,2) NOT NULL DEFAULT '0.00',
  `taxaAdm` DECIMAL(10,2) NOT NULL DEFAULT '0.00',
  `carencia` INT(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`idInvestimento`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `mydb`.`investimento`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`investimento` (
  `idContaInvestimento` INT(11) NOT NULL AUTO_INCREMENT,
  `saldo` DECIMAL(10,2) NOT NULL DEFAULT '0.00',
  `dataInvestimento` DATE NOT NULL,
  `vencimento` DATE NOT NULL,
  `idInvestimento` INT(11) NOT NULL,
  `idContaCorrente` INT(11) NOT NULL,
  `valorInicial` DECIMAL(10,2) NOT NULL,
  `liquides` VARCHAR(10) NOT NULL,
  PRIMARY KEY (`idContaInvestimento`),
  INDEX `fk_ContaInvestimento_Investimento1_idx` (`idInvestimento` ASC),
  INDEX `fk_ContaInvestimento_ContaCorrente1_idx` (`idContaCorrente` ASC),
  CONSTRAINT `fk_ContaInvestimento_ContaCorrente1`
    FOREIGN KEY (`idContaCorrente`)
    REFERENCES `mydb`.`contacorrente` (`idContaCorrente`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_ContaInvestimento_Investimento1`
    FOREIGN KEY (`idInvestimento`)
    REFERENCES `mydb`.`tipoinvestimento` (`idInvestimento`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `mydb`.`movimentacao`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`movimentacao` (
  `idContaCorrente` INT(11) NOT NULL,
  `idMovimentacao` INT(11) NOT NULL AUTO_INCREMENT,
  `tipo` VARCHAR(10) NOT NULL,
  `data` DATE NOT NULL,
  `valor` DECIMAL(10,2) NOT NULL DEFAULT '0.00',
  `descricao` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`idMovimentacao`),
  INDEX `fk_Movimentacao_ContaCorrente1_idx` (`idContaCorrente` ASC),
  CONSTRAINT `fk_Movimentacao_ContaCorrente1`
    FOREIGN KEY (`idContaCorrente`)
    REFERENCES `mydb`.`contacorrente` (`idContaCorrente`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `mydb`.`Taxas`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Taxas` (
  `idTaxas` INT NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(45) NOT NULL,
  `valor` DECIMAL(10,2) NOT NULL DEFAULT 0,
  `valorizacao` DECIMAL(10,2) NOT NULL DEFAULT 0,
  PRIMARY KEY (`idTaxas`))
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
