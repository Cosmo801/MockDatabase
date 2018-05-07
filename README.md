# MockDatabase
This project is a mocker for creating test data for your project during the development stage.
The goal of the project is to have as little burden on the client as possible, they need to merely define a MockContext concrete class and define their entities as MockCollection<TClass> on that 

See the wiki for more a more detailed usage guide.

# Quickstart

Main

`using MockDatabase.API`

`SeedingConfigurationBuilder<TContext> builder = new SeedingConfigurationBuilder<TContext>();`

 `TContext data = builder.Build();`
 
 
 DependencyInjection
 
 `IServiceCollection.AddMockDatabaseDb();`
 
 

# Nuget Packages

[Cosmo.MockDatabase](https://www.nuget.org/packages/Cosmo.MockDatabase/)
