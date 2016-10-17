#zablo - Personal Application

Offical site see [here](https://dotnet.github.io/), how to started it and documentation API reference.

##Environment
You can test it in Ubuntu14.04 or CentOS7.x two environment. See the detail steps:

####install .net core

######Ubuntu14.04

Set up package
```
sudo sh -c 'echo "deb [arch=amd64] https://apt-mo.trafficmanager.net/repos/dotnet-release/ trusty main" > /etc/apt/sources.list.d/dotnetdev.list'
sudo apt-key adv --keyserver apt-mo.trafficmanager.net --recv-keys 417A0893
sudo apt-get update
```
Install .net core sdk
```
sudo apt-get install dotnet-dev-1.0.0-preview2-003131
```

######CentOS

Install .net core sdk
```
sudo yum install libunwind libicu
curl -sSL -o dotnet.tar.gz https://go.microsoft.com/fwlink/?LinkID=827529
sudo mkdir -p /opt/dotnet && sudo tar zxf dotnet.tar.gz -C /opt/dotnet
sudo ln -s /opt/dotnet/dotnet /usr/local/bin
```

######Docker

The detail installation for docker, see [here](https://github.com/itabas016/TutorialsPoint/tree/master/docker)
```
docker run -it microsoft/dotnet:latest
```

####dotnet restore
`dotnet restore` calls into NuGet to restore the tree of dependencies. 
NuGet analyzes the `project.json` file, downloads the dependencies stated in the file (or grabs them from a cache on your machine), and writes the `project.lock.json` file. The `project.lock.json` file is necessary to be able to compile and run.

####dotnet build
Create debug builds of your app on each of the target platforms by using the dotnet `build command`. 
Unless you specify the runtime identifier you'd like to build, the `dotnet build` command creates a build only for the current system's runtime ID. You can build your app for both target platforms with the commands:
```
dotnet build -r win10-x64
dotnet build -r osx.10.10-x64
```

####dotnet publish

######project json param - dependency
Add references to any third-party libraries to the `dependencies` section of your `project.json` file. The following `dependencies` section uses Json.NET as a third-party library.
```
"dependencies": {
   "Microsoft.NETCore.App": {
     "type": "platform",
     "version": "1.0.0"
   },
   "Newtonsoft.Json": "9.0.1"
 },
```

######project json param - frameworks

> * It indicates that, instead of using the entire netcoreapp1.0 framework, which includes .NET Core CLR, the .NET Core Library, and a number of other system components, our app uses only the .NET Standard Library.

> * By removing the "type": "platform" attribute, it indicates that the framework is provided as a set of components local to our app, rather than as a system-wide platform package.
```
"frameworks": {
   "netstandard1.6": { }
 }
```

######project json param - runtimes
As you did in the Deploying a simple self-contained deployment example, create a `runtimes` section in your `project.json` file that defines the platforms your app targets and specify the runtime identifier of each platform that you target. 
See [Runtime IDentifier catalog](https://docs.microsoft.com/en-us/dotnet/articles/core/rid-catalog) for a list of runtime identifiers. For example, the following `runtimes` section indicates that the app runs on 64-bit Windows 10 operating systems and the 64-bit OS X Version 10.10 operating system.
```
"runtimes": {
       "win10-x64": {},
       "ubuntu.14.04-x64": {},
       "centos.7-x64": {},
       "osx.10.10-x64": {}
     }
```

In the end, run the following command:
```
dotnet publish -c release -r win10-x64
dotnet publish -c release -r osx.10.10-x64
```

######dotnet run
`dotnet run` calls `dotnet build` to ensure that the build targets have been built, and then calls `dotnet <assembly.dll>` to run the target application.
```
$ dotnet run
```

####dotnet test
The `dotnet test` command is used to execute unit tests in a given project. Unit tests are class library projects that have dependencies on the unit test framework (for example, NUnit or xUnit) and the dotnet test runner for that unit testing framework. These are packaged as NuGet packages and are restored as ordinary dependencies for the project.

```
{
  "version": "1.0.0-*",
  "buildOptions": {
    "debugType": "portable"
  },
  "dependencies": {
    "System.Runtime.Serialization.Primitives": "4.1.1",
    "xunit": "2.1.0",
    "dotnet-test-xunit": "1.0.0-rc2-192208-24"
  },
  "testRunner": "xunit",
  "frameworks": {
    "netcoreapp1.0": {
      "dependencies": {
        "Microsoft.NETCore.App": {
          "type": "platform",
          "version": "1.0.0"
        }
      },
      "imports": [
        "dotnet5.4",
        "portable-net451+win8"
      ]
    }
  }
}
```
Runs the tests in the project in the current directory.
```
dotnet test /projects/test1/project.json
```

##Features
* ToDo list
* Reminder