# HelloShiftLeft-DotNet
This repository will contain an evolving set of .NET applications that can be used for testing.

## Current Status
Applications are being created for internal developer-only testing of the .NET pipeline. As the pipeline matures, the status of applications for use in internal and/or customer demonstrations will be shown here.

| Application Name |Technology, architecture | Packages, API, components | Framework/Version | Role
|------------------|-------------------------|-----------------|-------------------|------|
| netcoreConsole | Console | TODO | .NET Core 2.0 | Internal testing
| netcoreWebapi | WebAPI, REST | TODO | .NET Core 2.0 | Internal testing
| netfwWebapi | WebAPI, REST | TODO | .NET Framework 4.6.1 | Internal testing
| netfwWCFwithASP | WCF, plain ASP, SOAP | Logging, ADO/EF | .NET Framework 4.6.1 | Internal testing   
| netfwWCFwithMVC | WCF, MVC, SOAP  | Logging, ADO/EF  | .NET Framework 4.6.1  | Internal testing
| vulnerable_asp_net_core | MVC  | Entity Framework, SQLite | .NET Core 2.1 | Internal testing
| vulnerable_asp_net_framework | MVC  | Entity Framework, SQLite | .NET Framework 4.6.1 | Internal testing

## Build
Each application has its own folder. You can build using either `Visual Studio 2017` or from the command-line using the commands below.
In order to build the .NET Framework applications (currently only one, `netfwWebapi`) you have to have installed `Visual Studio 2017` or at least the [Visual Studio Build Tools](http://landinghub.visualstudio.com/visual-cpp-build-tools).

#### Get Source
`$ git clone https://github.com/ShiftLeftSecurity/HelloShiftLeft-DotNet-Internal.git`
    
#### Build All Applications (OUTDATED: will update it soon)

Note: Only the .NET Core applications are buildable and runnable on non-Windows machines.

In a Linux or OS X shell, or a Windows bash shell, you can build the .NET Core applications from a shell:

`  $ ./buildAll.sh`

In a Windows command shell:

` > buildAll.cmd`

#### Build Application Individually
```
    $ cd <application folder>
    $ dotnet build
```

## Run
You can either run an application from within `Visual Studio 2017` or directly from the command-line as follows:

#### .NET Core Console app
```
   $ cd netcoreConsole/netcoreConsole
   $ dotnet run
```
The application just prints out a number right now. This may change as we add more functionality.

#### .NET Core Web API app
```
   $ cd netcoreWebapi
   $ dotnet run
```

You will see output to the shell, the last two lines of which are something like this:

```
Now listening on: http://localhost:8942
Application started. Press Ctrl+C to shut down.
```

#### .NET Framework Web API app
Install `Internet Information Services (IIS)` via Control Panel -> Windows Features if it isn't already installed.

In a browser you can see the app at http://localhost/netfwWebapi
 

## Sensitive Data Leaks in netcoreWebapi

| URL | Purpose |
| --- | ------- |
| http://localhost:8942/api/customers/4343 | Returns JSON representation of Customer resource based on Id (4343) specified in URL |
| http://localhost:8942/api/customers   | Returns JSON representation of all available Customer resources |







