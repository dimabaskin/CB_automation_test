#CB automation Test API

Descriprion:
Solution is a small framework for API Testing Examples on website - https://reqres.in/

This project was created on VS 2022 Community .
Based on Nunit test framework.

To Compile Project:
Get repository to local machine.
Open solution in VS 2022 .
Build the Project. 
In Test Explorer run Test. 

Solution Devided to two projects :
ReqresAPI_Test - For Test code. 
ServiceAPI - For API requst / respons and DataModel.


ReqresAPI_Test contains :

BaseTest class.

Tests class with 4 tests code .

TestData.json - Test configuration Data . 

ConfigurationHelper class. 

App.conf

ServiceAPI contains:

DataModel Classes.

reqresAPI class for sending requests.

Response class for parsing response message .
