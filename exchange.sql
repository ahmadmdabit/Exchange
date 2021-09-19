-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Sep 18, 2021 at 03:39 PM
-- Server version: 10.4.21-MariaDB
-- PHP Version: 8.0.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `exchange`
--

-- --------------------------------------------------------

--
-- Table structure for table `exchange_infos`
--

CREATE TABLE `exchange_infos` (
  `ID` bigint(20) NOT NULL,
  `Symbol` varchar(191) COLLATE utf8mb4_unicode_ci NOT NULL,
  `PurchasePrice` decimal(10,4) NOT NULL,
  `SalePrice` decimal(10,4) NOT NULL,
  `StepSize` decimal(10,4) NOT NULL,
  `CreatedAt` datetime NOT NULL DEFAULT current_timestamp(),
  `UpdatedAt` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `exchange_infos`
--

INSERT INTO `exchange_infos` (`ID`, `Symbol`, `PurchasePrice`, `SalePrice`, `StepSize`, `CreatedAt`, `UpdatedAt`) VALUES
(1, 'EUR/USD', '1.2110', '1.2115', '0.0001', '2021-09-18 14:14:54', NULL),
(2, 'GBP/USD', '1.3210', '1.3215', '0.0001', '2021-09-18 14:16:06', NULL),
(3, 'USD/TRY', '8.3200', '8.3210', '0.0010', '2021-09-18 14:16:36', NULL),
(4, 'XAU/USD', '1821.1500', '1822.4500', '0.0500', '2021-09-18 14:17:07', NULL),
(5, 'EUR/TRY', '10.2000', '10.2110', '0.0010', '2021-09-18 14:17:38', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `ID` bigint(20) NOT NULL,
  `Username` varchar(191) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Password` varchar(191) COLLATE utf8mb4_unicode_ci NOT NULL,
  `CreatedAt` datetime NOT NULL DEFAULT current_timestamp(),
  `UpdatedAt` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`ID`, `Username`, `Password`, `CreatedAt`, `UpdatedAt`) VALUES
(1, 'test', 'test', '2021-09-18 12:50:44', '2021-09-18 11:50:33');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `exchange_infos`
--
ALTER TABLE `exchange_infos`
  ADD PRIMARY KEY (`ID`),
  ADD UNIQUE KEY `Symbol` (`Symbol`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`ID`),
  ADD UNIQUE KEY `Username` (`Username`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `exchange_infos`
--
ALTER TABLE `exchange_infos`
  MODIFY `ID` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `ID` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
