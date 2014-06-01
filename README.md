CESASP
======
A shadow redo of https://github.com/vosechu/ces_json_api to help in understanding Ruby vs C# Web stack

I will comment the connections between WebAPI and the Ruby project when I have a little more sleep under my belt. A few quick pointers though:

App.rb - A combination of the classes in the Controller folder with /App_Start/RouteConfig

/Lib - In the Models directory (I put them all in one file Samples.CS to make it easier to see)

Mongo - I added the mongo path to web.config. (Under connection strings - MongoConnection) If you want to run it locally change the localhost to be wherever you are running mongo)
