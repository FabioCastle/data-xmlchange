# Data XML-Change
A tool that provides conversion of XML files to other formats. The project is developed based on .NET 8 and is composed of:
- __core:__ Class Library that provides the core functionality and may be extended to support new use cases
- __app:__ Worker Service application that execute the XML conversion periodically

You can use the _app_ as is to have an application that polls XML data from an HTTP server and stores the results in a txt file. You should modify the appsettings.json configuration file to setup the URL to poll, the polling period, the queries to be performed on XML data to provide the final result, and the full path of the output file. Please refer to the _Configuration_ section to have a complete description of the configuration file.

## Features
- Download XML data via HTTP
- JSON configuration file can be edited to add queries on the XML data and to format the output file
- Support for .txt, .csv, and other textual-based file format output
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
The /app/appsettings.json file should be edited for your specific needs:
- __Service:__
    - __PollingPeriodInMilliseconds:__ Time interval between two consecutive executions of the data conversion in milliseconds (ms)
    - __LogFile:__ Specify a relative or absolute path to a logging file. This follows the [Serilog](https://serilog.net/) name template for the file.
- __DataXmlChange:__
    - __DataRetrieval__: Configures the XML data retrieval from an HTTP server
        - __Url__: The URL to be polled to download XML data
    - __DataExtraction:__ Configures the data extraction process from the downloaded XML data
        - __Queries:__ An array of queries to extract data. Each element of such array follows this format:
        ```
        {
          "Id": "string",           // identify the query result and is used in the output configuration
          "ElementType": 0 | 1,     // 0 = Tag: the query should search a tag in the XML data with name "FilterByName";
                                    // 1 = Attribute: the query should search any tag that has an attribute with name "FilterByName" and value "FilterByValue"
          "FilterByName": "string",
          "FilterByValue": "string" | null,
          "ValueLocation": 0 | 1,   // once the tag is found, where the value should be retrieved
                                    // 0 = Text content of the tag;
                                    // 1 = Attribute of the tag with name "ValueLocationName"
          "ValueLocationName": "string" | null
        }
        ```
    - __DataStorage:__ Configures how output data are produced or stored
        - __OutputFile:__ Specify a relative or absolute path to the output file to produce
        - __Lines:__ An array of lines to be written in the output file. Each element of such array follows this format:
        ```
        {
          "FormatString": "string", // format string with optional numbered placeholders ({0}, {1}, ...)
          "ResultIds": [ "string" ] // ID of the query results to be put in the format string. This array should contain the same number of numbered placeholders in the format string
        }
        ```
    __NOTE:__ In order to support csv file you should set _OutputFile_ to have .csv extension and include a first line in the _Lines_ array containing the csv header with proper separator character. You should also use the same separator character in all other lines configured this way.

## Use cases
I initially developed this project to have a system able to perform data collection from an MTConnect server. MTConnect is a standard communication protocol to manage industrial equipments and you can use this protocol to collect data in form of XML files. You need to have deep knowledge of the protocol in order to read the produced XML files, and there are few MES systems that are able to integrate XML data. Thus, Data XML-Change could be used to convert such data in an easy-to-integrate textual file containing requested data from a customer. 

## Extending the functionalities
If you clone the repository you will be able to include the _core_ class library in your projects to integrate Data XML-Change functionalities, so you don't have to stick with the provided _app_ implementation. The _core_ class library can be extended in many ways. At its core, there are three main interfaces that must be implemented:
- _IXmlDataRetriever:_ to download XML data from any source
- _IXmlDataExtractor:_ to extract data from the downloaded XML data
- _IResultStorer:_ to store the query results found
The library provides my implementations, but you may add your own to expand the capabilities of the project. For example, you may retrieve XML data from any other data source and store the query results in a database. If you plan on providing your implementations, you should also change _CoreExtensions.cs_ class to inject them into DI container.

## Future developments
The project is not currently in development. Feel free to suggest new use cases and implementations.