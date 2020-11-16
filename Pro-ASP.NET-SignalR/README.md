# Pro ASP.NET SignalR (2014)
__By Keyvan Nayyeri and Darren White__   
[Example Code](https://github.com/apress/pro-asp.net-signalr)    
[MS Guide](https://docs.microsoft.com/en-us/aspnet/signalr/)   
[Server Guide](https://docs.microsoft.com/en-us/aspnet/signalr/overview/guide-to-the-api/hubs-api-guide-server)  
[Client Side JavaScript](https://docs.microsoft.com/en-us/aspnet/signalr/overview/guide-to-the-api/hubs-api-guide-javascript-client)  
[Client Side .NET](https://docs.microsoft.com/en-us/aspnet/signalr/overview/guide-to-the-api/hubs-api-guide-net-client)
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
Hubs are an abstraction on top of persistent connection that enable ease of access to a set of APIs for the .NET Framework, jQuery, or other client types that allow web developers to build real-time web applications.    

__Overview of Hubs__  
Hub proxies are a set of JavaScript libraries automatically generated on the fly by the ASP.NET SignalR server based on the code implemented on the server to simplify the process of remote procedure call to server or client method.  

To enable CORS add the element to the `Web.config` file.
```
<system.webServer>
  <httpProtocol>
    <customHeaders>
      <add name="Access-Control-Allow-Origin" value="http://localhost" />
      <add name="Access-Control-Allow-Headers" value="X-AspNet-Version,X-Powered-By,Date,Server,Accept,Accept-Encoding,Accept-Language,Cache-Control,Connection,Content-Length,Content-Type,Host,Origin,Pragma,Referer,User-Agent" />
      <add name="Access-Control-Allow-Methods" value="GET, PUT, POST, DELETE, OPTIONS" />
      <add name="Access-Control-Max-Age" value="1000" />
    </customHeaders>
  </httpProtocol>
</system.webServer>
```

__Defining Overloads__   
Overload methods defined in a Hub must have different number of parameter not just type difference alone.

__State Management__   
The data passed between client and server, in SignalR must be small, otherwise it might have a huge impact on the performance of your application.   

## Chapter 4: Developing SignalR Applications Using Persistent Connections    
