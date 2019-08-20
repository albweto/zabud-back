-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- Servidor: localhost
-- Tiempo de generación: 20-08-2019 a las 04:29:34
-- Versión del servidor: 10.3.17-MariaDB
-- Versión de PHP: 7.3.8

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `PruebaZabud`
--

DELIMITER $$
--
-- Procedimientos
--
CREATE DEFINER=`root`@`localhost` PROCEDURE `delete_client` (IN `c_id` INT(10))  NO SQL
BEGIN
 delete from Client where id = c_id;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `insert_client` (IN `c_document` INT(11), IN `c_name` VARCHAR(40), IN `c_lastname` VARCHAR(40), IN `c_username` VARCHAR(40), IN `c_password` VARCHAR(40), IN `c_email` VARCHAR(100))  READS SQL DATA
BEGIN
INSERT INTO Client(docuemnt,client_name,client_lastName,username,password,email)
VALUES(c_document,c_name,c_lastName,c_username,c_password,c_email);
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `select_allClient` ()  NO SQL
BEGIN
SELECT  id, 
            docuemnt,
            client_name,
            client_lastName,
            username,
            password,
            email 
            from Client;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `select_clientByDocumnet` (IN `c_document` INT)  NO SQL
BEGIN
SELECT  
            client_name,
            client_lastName,
            username,
            email 
            from Client
            where  docuemnt =c_document;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `select_clientById` (IN `c_id` INT(10))  NO SQL
BEGIN
SELECT       id,
			 docuemnt,
             client_name, 
             client_lastName,
             username,
             password,
             email
            from Client
            where  id =c_id;

END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_client_auth` (IN `c_username` VARCHAR(40), IN `c_password` VARCHAR(40))  NO SQL
BEGIN
SELECT docuemnt, client_name,client_lastName,email FROM Client WHERE username = c_username AND password = c_password;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_delet_sale` (IN `s_id` INT)  NO SQL
BEGIN
DELETE FROM sale where id = s_id;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_insert_product` (IN `p_price` FLOAT(10), IN `p_name` VARCHAR(40), IN `p_stock` INT(100))  BEGIN
INSERT INTO Product (price,product_name,stock) values (p_price,p_name,p_stock);
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_insert_sale` (IN `s_client` INT, IN `s_date` DATE, IN `s_total` INT)  NO SQL
BEGIN
INSERT INTO sale (client_id,date_sale,total_price)
VALUES (s_client,s_date,s_total);
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_insert_saleDetail` (IN `sd_product` INT, IN `sd_sale` INT)  NO SQL
BEGIN
	INSERT INTO sale_detail (product_id,sale_id)
    VALUES (sd_product,sd_sale);
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_product_delete` (IN `p_id` INT)  NO SQL
BEGIN 
DELETE FROM Product where id = p_id;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_select_allProduct` ()  NO SQL
BEGIN

SELECT id, price,product_name,stock FROM Product;

END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_select_productById` (IN `p_id` INT)  NO SQL
BEGIN
select id,price,product_name,stock FROM Product WHERE id = p_id;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_select_sale` ()  NO SQL
BEGIN
SELECT * FROM sale;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_select_saleClient` ()  NO SQL
BEGIN

SELECT c.client_name as clienName, s.date_sale as DateSale, s.total_price as Total
FROM sale s INNER JOIN Client c  ON s.client_id = c.id;

END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_update_product` (IN `p_id` INT, IN `p_name` VARCHAR(40), IN `p_price` FLOAT, IN `p_stock` INT)  NO SQL
BEGIN
UPDATE Product 
SET
 product_name = p_name,
 stock = p_stock,
 price = p_price
 where id = p_id;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `update_client` (IN `c_id` INT(11), IN `c_document` INT(11), IN `c_name` VARCHAR(40), IN `c_lastname` VARCHAR(40), IN `c_username` VARCHAR(40), IN `c_password` VARCHAR(40), IN `c_email` VARCHAR(40))  NO SQL
BEGIN
 update Client
    SET
    docuemnt = c_document,
    client_name = c_name,
    client_lastName = c_lastName,
    username = c_username,
    password = c_password,
    email = c_email
    where id = c_id;
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `Client`
--

CREATE TABLE `Client` (
  `id` int(11) NOT NULL,
  `docuemnt` int(11) NOT NULL,
  `client_name` varchar(50) CHARACTER SET latin1 NOT NULL,
  `client_lastName` varchar(50) CHARACTER SET latin1 NOT NULL,
  `username` varchar(40) CHARACTER SET latin1 NOT NULL,
  `password` varchar(40) CHARACTER SET latin1 NOT NULL,
  `email` varchar(100) CHARACTER SET latin1 NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Volcado de datos para la tabla `Client`
--

INSERT INTO `Client` (`id`, `docuemnt`, `client_name`, `client_lastName`, `username`, `password`, `email`) VALUES
(1, 123456, 'samuel', 'hernto', 'usuario', 'hola', 'ser@der.com'),
(2, 34567, 'albert', 'erfty', 'mjyy', 'eert4', 'jefaime@ser.com'),
(3, 1100034, 'maria josefa', 'morales', 'mariales', 'Shenrty', 'mariaqmaria.com'),
(5, 1298776, 'jaime', 'alberto', 'jaimito', 'jaraba', 'jaime@ser.com'),
(6, 877766, 'samuel as', 'albertoert', 'jaimitofrt', 'jarabadfrt', 'jaimerfte@ser.com'),
(7, 1111, 'asder', 'asdfg', 'qwet', 'ascfrt', 'jefeaime@ser.com'),
(9, 12987763, 'jaime', 'alberto', 'jaimito', 'jaraba', 'jaime4@ser.com'),
(11, 12987765, 'jaime', 'alberto', 'jaimito', 'jaraba', 'jaibme@ser.com'),
(12, 13987765, 'jaimer', 'albertof', 'jaimito', 'jaraba', 'jawibme@ser.com'),
(13, 986, 'amu', 'asdr', 'werty', 'asty', 'jairme@ser.com');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `Product`
--

CREATE TABLE `Product` (
  `id` int(11) NOT NULL,
  `product_name` varchar(30) CHARACTER SET latin1 NOT NULL,
  `stock` int(5) NOT NULL,
  `price` float DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Volcado de datos para la tabla `Product`
--

INSERT INTO `Product` (`id`, `product_name`, `stock`, `price`) VALUES
(1, 'samuel', 14, 120000),
(3, 'nikes', 20, 350000),
(4, 'samuel', 14, 120000);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sale`
--

CREATE TABLE `sale` (
  `id` int(11) NOT NULL,
  `date_sale` datetime NOT NULL,
  `total_price` float NOT NULL,
  `client_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Volcado de datos para la tabla `sale`
--

INSERT INTO `sale` (`id`, `date_sale`, `total_price`, `client_id`) VALUES
(1, '2019-08-19 00:00:00', 3000000, 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sale_detail`
--

CREATE TABLE `sale_detail` (
  `id` int(11) NOT NULL,
  `sale_id` int(11) NOT NULL,
  `product_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `Client`
--
ALTER TABLE `Client`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `docuemnt` (`docuemnt`),
  ADD UNIQUE KEY `email` (`email`);

--
-- Indices de la tabla `Product`
--
ALTER TABLE `Product`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `sale`
--
ALTER TABLE `sale`
  ADD PRIMARY KEY (`id`),
  ADD KEY `pk_client_sale` (`client_id`);

--
-- Indices de la tabla `sale_detail`
--
ALTER TABLE `sale_detail`
  ADD PRIMARY KEY (`id`),
  ADD KEY `pk_sale_saleDetail` (`sale_id`),
  ADD KEY `pk_product_saleDestail` (`product_id`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `Client`
--
ALTER TABLE `Client`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT de la tabla `Product`
--
ALTER TABLE `Product`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT de la tabla `sale`
--
ALTER TABLE `sale`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de la tabla `sale_detail`
--
ALTER TABLE `sale_detail`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `sale`
--
ALTER TABLE `sale`
  ADD CONSTRAINT `pk_client_sale` FOREIGN KEY (`client_id`) REFERENCES `Client` (`id`);

--
-- Filtros para la tabla `sale_detail`
--
ALTER TABLE `sale_detail`
  ADD CONSTRAINT `pk_product_saleDestail` FOREIGN KEY (`product_id`) REFERENCES `Product` (`id`),
  ADD CONSTRAINT `pk_sale_saleDetail` FOREIGN KEY (`sale_id`) REFERENCES `sale` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;