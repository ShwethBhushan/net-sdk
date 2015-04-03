DialMyCalls.com NET SDK
=======================
A NET library for interacting with the [DialMyCalls.com](http://www.dialmycalls.com/api-docs/) REST API.

Requirements
---------------------
* Microsoft Visual Studio 2012 and later
* .NET Framwork 4.5

Composer Installation
---------------------
The DialMyCalls.com NET SDK can be included as an assembly into your project. 
Get the source code and add NETAPI assembly into your solution. 
Include DialMyCalls namespase.
For calling a service create a Client:
```
var client = new Client(APIKey);
var service = new Service.Call(client);
service.Create(...);
```