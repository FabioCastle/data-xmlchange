# Data XML-Change
A tool that provides conversion of XML files to other formats. The project is developed based on .NET 8 and is composed of:
- __core:__ Class Library that provides the core functionality and may be extended to support new use cases
- __app:__ Worker Service application that execute the XML conversion periodically

You can use the _app_ as is to have an application that polls XML data from an HTTP server and stores the results in a txt file. You should modify the appsettings.json configuration file to setup the URL to poll, the polling period, the queries to be performed on XML data to provide the final result, and the full path of the output file. Please refer to the _Configuration_ section to have a complete description of the configuration file.

## Features
- Download XML data via HTTP
- JSON configuration file can be edited to add queries on the XML data and to format the output file
- The tool can be run either as a console application or as a Windows Service

## Installation (Windows)
- Install .NET 8 on your pc from the official website
- Download the latest release
- Extract the downloaded .zip file to a proper location on your pc
- You can either launch the file Data XML-Change App.exe or create a Windows Service (next steps)
- (to create a Windows Service) Open Command Prompt with administrator privilegies
- (to create a Windows Service) Type the command `sc create DataXMLChange binPath= "C:\<full-path>\Data XML-Change App.exe"`. __NOTE:__ you should enter the full path to the .exe file on your PC
- (to launch the Windows Service) Open the Services application from Start menu with administrator privilegies
- (to launch the Windows Service) Search for the service named _DataXMLChange_ and start it

## Configuration

## Future developments
The project is not currently in development. Feel free to suggest new use cases and implementations.