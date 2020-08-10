# Threax.ConsoleApp
This provides a simple app structure to make console apps with dependency injection. It is lighter weight than the ms app host.

## Supply a Controller Type
A controller type must be supplied. It is defined in the client app. A simple one would look like the following:
```
interface IController
{
    Task Run();
}
```

## Create a Default Controller
Create a controller to run when a match isn't found.
```
class HelpController : IController
{
    private ILogger logger;

    public HelpController(ILogger<HelpController> logger)
    {
        this.logger = logger;
    }

    public Task Run()
    {
        logger.LogInformation("Help");

        return Task.CompletedTask;
    }
}
```

## Setup and Run the App Host
In the main function setup and run the app host.
```
return AppHost
    .Setup<IController, HelpController>(command, services =>
    {
        services.AddSingleton<IArgsProvider>(s => new ArgsProvider(args));

        ...
    })
    .Run(c => c.Run());
```

## Implement Controllers
Implement the remaining controllers. They must implement the controller interface and end with the word Controller. The command to run a controller is its class name with the Controller part removed.

## Run App
Run your app by running
```
dotnet App.dll command
```

That would run a controller called CommandController. It would also be valid to send Command or cOmmand, the case does not matter.