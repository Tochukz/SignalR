# Pro ASP.NET SignalR (2014)
__By Keyvan Nayyeri and Darren White__   
[Example Code](https://github.com/apress/pro-asp.net-signalr)  
## Chapter 1: Introduction to Real-Time Web and ASP.NET SignalR  
SignalR is a set of libraries for the .NET Framework, JavaScript/jQuery, iOS, and other platforms.  It provides server and client implementations for building real-time web applications.  

__Transport Options__  
1. Long Polling (and interval polling)
2. Forever Frame  
3. Server-Sent Event
4. WebSockets    

## Chapter 2: Overview Of SignalR  
__Message Backplanes__  
A message backplane is a specialized application that is built specifically to transport messages between systems using a defined API interface. The message backplane provides a few characteristics that help applications excel in scaling out such as a central routing channel and asynchronicity of message sending.  

__Important SignalR NuGet Packages__  
Server and client package for hosting with IIS and ASP.NET and JavaScript client  
```
PM > Install-Package Microsoft.AspNet.SignalR
```
Server package for hosting SignalR endpoints
```
PM > Install-Package Microsoft.AspNet.SignalR.Core
```
Client package for .NET SignalR applications
```
PM > Install-Package Microsoft.AspNet.SignalR.Client
```
Client package for JavaScript SignalR applications  
```
PM > Install-Package Microsoft.AspNet.SignalR.JS  
```    

__When Not to Use SignalR__   
In general, if the content us updated very infrequently or the client connection is unreliable, SignalR should not be used. Remember that there is an overhead for creating a persistent connection, therefore they should not be created if they are not used.    

__SQL Server__   
The SQL Server implementation of message backplane performance is much better with Service Broker enabled. Service Broker is the database's internal queuing mechanism. This NuGet package can be installed with the `Install-Package Microsoft.AspNet.SignalR.SqlServer` command in the Package Manager Console.   

## Chapter 3: Developing SignalR Applications Using Hubs.  
