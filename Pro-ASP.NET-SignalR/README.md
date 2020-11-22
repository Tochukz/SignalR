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
__What Is a Persistent Connection?__   
A _persistent connection_ is a communication channel between a server and a client that is kept open to facilitate secure, robust, low-latency, and full-duplex communication.    

__Properties of a Persistent Connection__  
* Robust connection  
* Full-duplex communication
* Low latency  
* Secure communication (optional)   

__How Persistent Connection Works__  
1. The client sends a negotiation request.  
2. The server responds to the negotiation request with a  payload of negotiation properties.  
3. The client uses the payload to negotiate the best transport option.  
4. The client sends a connect request with the negotiated transport.  
5. Once the server has accepted the connect request, the persistent connection is made.  
After the connection is made, the following steps are taken simultaneously to keep maintaining the connection:  
* Retrieve any data that is on the server
* Send any data that is pending to be sent to the server    
* Retrieve and acknowledge keep-alive packets or reconnect after polling timeout.  

__Global Timeout and Keep-Alive Configurations__   
__Connection Timeout__ is only applicable to long polling transport. It is the amount of time that a connection remains open without receiving data. After this timeout, the connection is closed, and another connection is opened. The default Connection Timeout is 110 seconds.   
__Disconnect Timeout__ is the amount of time to wait after a connection goes away before raising the disconnect event. The default _DisconnectTimeout_ is 30 seconds.   
__KeepAlive__ is the amount of time between the sending of keep-alive messages. It is set to 1/3 of the value of the _DisconnectTimeout_ by default, except for the long polling transport for which it is set to null which disables it.  
It's minimum value is 2 seconds, and maximum value is 1/3 of the _DisconnectTimeout_.   

__Relation Table of Key to Property of PersistentResponse JSON object__  

Key | Property
----|-----------
C   | Cusors
D   | Disconnect  
T   | TimedOut  
G   | GroupsToken
L   | LongPollDelay  
M   | Messages  

Example of the Persistent Response Received on a Poll  
```
{"C":"d-C16EF02C-B,1|C,1|D,0","M":["User A: Hello"]}
```

__Group Persistence__  
Persisting a group can be done either in-memory or to a long-term storage medium such as a database or a caching tier. The persistence mediums have trade-offs such as speed, durability, and scalability.  

## Chapter 5: Troubleshooting ASP.NET SignalR Applications  
[Chrome Dev Tool](https://developers.google.com/web/tools/chrome-devtools)     
__Using Fiddler for Client-to-Server Communication Debugging__   
_[Telerik Fiddler](https://www.telerik.com/fiddler)_, which has been a very handy tool for developers for many years, enables you to easily test and trace communication requests on different protocols on your machine.  
_[Charles](https://www.charlesproxy.com/)_ is a good example of a similar tool for the Apple community.   

__Tracing Features__     
To enable Tracing add the following to you `Web.config` file:  
```
<system.diagnostics>
  <trace autoflush="true" indentsize="4">
    <listeners>
      <add name="default_traces" type="System.Diagnostics.TextWriterTraceListener" initializeData="default_traces.txt" />
    </listeners>
  </trace>
  <switches>
    <add name="SignalRSwitch" value="All" />
  </switches>
  <sources>
    <source name="Application" switchValue="All">
      <listeners>
        <add name="traces" />
      </listeners>
    </source>
    <source name="Microsoft.Owin.Host.SystemWeb" switchValue="All">
      <listeners>
        <add name="traces" />
      </listeners>
    </source>
    <source name="SignalR.Connection">
      <listeners>
        <add name="traces" />
      </listeners>
    </source>
    <source name="SignalR.PersistentConnection">
      <listeners>
        <add name="traces" />  
      </listeners>
    </source>
    <source name="SignalR.HubDispatcher">
      <listeners>
        <add name="traces" />
      </listeners>
    </source>
    <source name="SignalR.Transports.WebSocketTransport">
      <listeners>
        <add name="traces" />
      </listeners>
    </source>
    <source name="SignalR.Transports.ServerSentEventsTransport">
      <listeners>
        <add name="traces" />
      </listeners>
    </source>
    <source name="SignalR.Transports.ForeverFrameTransport">
      <listeners>
        <add name="traces" />
      </listeners>
    </source>
    <source name="SignalR.Transports.LongPollingTransport">
      <listeners>
        <add name="traces" />
      </listeners>
    </source>
  </sources>
  <sharedListeners>
    <add name="traces" type="System.Diagnostics.TextWriterTraceListener" initializeData="server_traces.txt" />
  </sharedListeners>
</system.diagnostics>
```  
You do not need to use all the sources shown here.    

## Chapter 6: An Overview of the Clients that Support SignalR   
