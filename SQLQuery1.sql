CREATE DATABASE [FUELSTATION]
CONTAINMENT = NONE
ON  PRIMARY
( NAME = N'FUELSTATION', FILENAME = N'C:\Users\makas\Desktop\Projects\SD Project\Fuel-Price-Prediction-System \FUELSTATION.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB ) 
LOG ON
( NAME = N'FUELSTATION_log', FILENAME = N'C:\Users\makas\Desktop\Projects\SD Project\Fuel-Price-Prediction-System \FUELSTATION_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB ) 
GO
