# CompanyCam .NET SDK

This library allows users to easily access the CompanyCam API inside their .NET projects.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See deployment for notes on how to deploy the project on a live system.

### Prerequisites

What things you need to install the software and how to install them

```
Microsoft.AspNet.WebApi.Client (5.2.3 or newer)
Newtonsoft.Json (10.0.3 or newer)
System.Net.Http (4.3.3 or newer)
```


## General Use

Before making any call, you must set your API key and user email. 

Use the following code before any calls are made.

```
CompanyCam.Config.SetApiKey("ApiKeyHere");
CompanyCam.Config.SetUserEmail("UserEmailHere");
```

Your API key can be found on CompanyCam's website under Your Company > Account > Access Tokens.
Your email is the one you used to sign up your company on CompanyCam.

To make the calls, use:

```
CompanyCam."ItemNameHere"."CommandHere"("ParametersHere");
```


## Example

To get the second page of all of the groups created by the user email you are currently using and display 30 groups per page, do the following:

```
var filter = new GroupFilter(){
	page = 2,
	per_page = 30,
};

var groups = CompanyCam.Group.GetAll(filter);
```

If a filter is not used, then the default page of 1 and per_page of 25 is used instead.


## Testing

In order to use to use the included tests, you must use your own API key and user email.
Do this by creating a static class within the test project with the following code:

```
public static class TestConfiguration
{
    public const string Apikey = "KEY-HERE";
    public const string UserEmail = "USER-EMAIL-HERE";
}
```


## Built With

.NET Standard 2.0


## Authors


## License

