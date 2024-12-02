# App Verification Package Plan
A .NET client for consuming the Microbilt App Verification Package APIs.

For more about APIs You can see on [Microbilt Developer Portal](https://developer.microbilt.com/)

## APIs in this plan:
[ABAAcctVerification](https://developer.microbilt.com/api/ABAAcctVerification)

[AddressNameVerification](https://developer.microbilt.com/api/AddressNameVerification)

[DeathMasterFileValidation](https://developer.microbilt.com/api/DeathMasterFileValidation)

[DLVerify](https://developer.microbilt.com/api/DLVerify)

[EmailValidation](https://developer.microbilt.com/api/EmailValidation)

[IPAddressInfo](https://developer.microbilt.com/api/IPAddressInfo)

[OFACWatchlistSearch](https://developer.microbilt.com/api/OFACWatchlistSearch)

[PhoneAddressVerification](https://developer.microbilt.com/api/PhoneAddressVerification)

[PhoneNameVerification](https://developer.microbilt.com/api/PhoneNameVerification)

[SSNAddressVerification](https://developer.microbilt.com/api/SSNAddressVerification)

[SSNNameVerification](https://developer.microbilt.com/api/SSNNameVerification)

[SSNPhoneVerification](https://developer.microbilt.com/api/SSNPhoneVerification)

[SSNValidation](https://developer.microbilt.com/api/SSNValidation)

# Installation

`composer require AlexandrAndreev/App_Verification_Package`

# Quick Start

```
AppVerificationPackageClient planClient = new AppVerificationPackageClient("client_id", "client_secret");
```
# Configuration

`client_id` required

`client_secret` required

`EnvironmentType` optional (defaults to Production). Other option is Sandbox. 

# Usage
For usage you need create plan client with you credentials
All APIs implemented like property in ```AppVerificationPackageClient``` class 
```appVerificationPackageClient.AddressNameVerificationClient.GetReport("You request body in JSON format")```

## More usage with test call APIs from plan:

```
using App_Verification_Package;

var appVerificationPackageClient = new AppVerificationPackageClient("you_client_id", "you_client_secret", EnvironmentType.Sandbox);

Console.WriteLine("AddressNameVerification API call:");
Console.WriteLine("GetReport:");
Console.WriteLine(appVerificationPackageClient.AddressNameVerificationClient.GetReport("{\"Name\":{\"FirstName\":\"ALBERT\",\"MiddleName\":\"D\",\"LastName\":\"ALTER\"},\"Address\":{\"Addr1\":\"7442SPRINGVILLAGEDR\",\"City\":\"SPRINGFIELD\",\"State\":\"VA\",\"Zip\":\"22150\"}}").ToString());

Console.WriteLine("DeathMasterFileValidation API call:");
Console.WriteLine("GetReport:");
Console.WriteLine(appVerificationPackageClient.DeathMasterFileValidationClient.GetReport("{\"SSN\":\"001-01-9101\",\"DoB\":\"1902-09-28\"}").ToString());

Console.WriteLine("DLVerify API call:");
Console.WriteLine("GetReport:");
Console.WriteLine(appVerificationPackageClient.DLVerifyClient.GetReport("{\"PersonInfo\":{\"PersonName\":{\"FirstName\":\"John\",\"LastName\":\"Smith\"},\"DriversLicense\":{\"LicenseNum\":\"1299011\",\"StateProv\":\"AK\"}}}").ToString());

Console.WriteLine("EmailValidation API call:");
Console.WriteLine("GetReport:");
Console.WriteLine(appVerificationPackageClient.EmailValidationClient.GetReport("{\"EmailAddr\":\"nakkyaattah@gmail.com\"}").ToString());
Console.WriteLine("GetArchiveReport:");
Console.WriteLine(appVerificationPackageClient.EmailValidationClient.GetArchiveReport("{70A56A61-CC9A-4060-B713-48BCA98E2B8D}").ToString());

Console.WriteLine("IPAddressInfo API call:");
Console.WriteLine("GetReport:");
Console.WriteLine(appVerificationPackageClient.IPAddressInfoClient.GetReport("{\"IP\":\"172.217.11.4\"}").ToString());

Console.WriteLine("OFACWatchlistSearch API call:");
Console.WriteLine("GetReport:");
Console.WriteLine(appVerificationPackageClient.OFACWatchlistSearchClient.GetReport("{\"PersonInfo\":{\"PersonName\":{\"LastName\":\"Miller\",\"FirstName\":\"Jack\"},\"ContactInfo\":[{\"PostAddr\":{\"Addr1\":\"478BrickellAve\",\"City\":\"Miami\",\"StateProv\":\"FL\",\"PostalCode\":\"33131\",\"Country\":\"USA\"}}],\"BirthDt\":\"1968-08-06\"}}").ToString());
Console.WriteLine("GetArchiveReport:");
Console.WriteLine(appVerificationPackageClient.OFACWatchlistSearchClient.GetArchiveReport("{29D095F3-E4CC-4593-A430-0C348A69F0CE}").ToString());

Console.WriteLine("PhoneAddressVerification API call:");
Console.WriteLine("GetReport:");
Console.WriteLine(appVerificationPackageClient.PhoneAddressVerificationClient.GetReport("{\"PhoneNumber\":\"5055068223\",\"Address\":{\"Addr1\":\"55CHURCHST\",\"City\":\"NEWPORT\",\"State\":\"NH\",\"Zip\":\"03773\"}}").ToString());

Console.WriteLine("PhoneNameVerification API call:");
Console.WriteLine("GetReport:");
Console.WriteLine(appVerificationPackageClient.PhoneNameVerificationClient.GetReport("{\"Name\":{\"FirstName\":\"MARGUERITE\",\"MiddleName\":\"\",\"LastName\":\"OUELLETTE\"},\"PhoneNumber\":\"970-846-4831\"}").ToString());

Console.WriteLine("SSNAddressVerification API call:");
Console.WriteLine("GetReport:");
Console.WriteLine(appVerificationPackageClient.SSNAddressVerificationClient.GetReport("{\"SSN\":\"001-16-6048\",\"Address\":{\"Addr1\":\"7442SPRINGVILLAGEDR\",\"City\":\"SPRINGFIELD\",\"State\":\"VA\",\"Zip\":\"22150\"}}").ToString());

Console.WriteLine("SSNNameVerification API call:");
Console.WriteLine("GetReport:");
Console.WriteLine(appVerificationPackageClient.SSNNameVerificationClient.GetReport("{\"SSN\":\"001-16-6050\",\"Name\":{\"FirstName\":\"Albert\",\"MiddleName\":\"Alter\",\"LastName\":\"D\"}}").ToString());

Console.WriteLine("SSNPhoneVerification API call:");
Console.WriteLine("GetReport:");
Console.WriteLine(appVerificationPackageClient.SSNPhoneVerificationClient.GetReport("{\"SSN\":\"001-15-9916\",\"PhoneNumber\":\"918-917-0963\"}").ToString());

Console.WriteLine("SSNValidation API call:");
Console.WriteLine("GetReport:");
Console.WriteLine(appVerificationPackageClient.SSNValidationClient.GetReport("{\"SSN\":\"111-22-1212\"}").ToString());
```
