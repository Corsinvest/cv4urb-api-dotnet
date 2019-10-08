# Corsinvest.UrBackup.Api

[![License](https://img.shields.io/github/license/Corsinvest/cv4urb-api-dotnet.svg)](https://www.gnu.org/licenses/gpl-3.0.en.html)
![Nuget](https://img.shields.io/nuget/v/Corsinvest.UrBackup.Api.svg?label=Nuget%20%20Api) [![AppVeyor branch](https://img.shields.io/appveyor/ci/franklupo/cv4urb-api-dotnet/master.svg)](https://ci.appveyor.com/project/franklupo/cv4urb-api-dotnet) [![Donate to this project using Paypal](https://img.shields.io/badge/paypal-donate-yellow.svg)](https://www.paypal.com/cgi-bin/webscr?cmd=_donations&business=PPM9JHLQLRV2S&item_name=Open+Source+Project&currency_code=EUR&source=url)

UrBackup Client API .Net

[Nuget Api](https://www.nuget.org/packages/Corsinvest.UrBackup.Api)

# **Donations**

If you like my work and want to support it, then please consider to deposit a donation through **Paypal** by clicking on the next button:

[![paypal](https://www.paypalobjects.com/en_US/IT/i/btn/btn_donateCC_LG.gif)](https://www.paypal.com/cgi-bin/webscr?cmd=_donations&business=PPM9JHLQLRV2S&item_name=Open+Source+Project&currency_code=EUR&source=url)

```text
   ______                _                      __
  / ____/___  __________(_)___ _   _____  _____/ /_
 / /   / __ \/ ___/ ___/ / __ \ | / / _ \/ ___/ __/
/ /___/ /_/ / /  (__  ) / / / / |/ /  __(__  ) /_
\____/\____/_/  /____/_/_/ /_/|___/\___/____/\__/

Corsinvest for UrBackup Api Client  (Made in Italy)
```

## Main features

* Easy to learn
* Method named
* Return result
  * Request
  * Response
  * Status
* Method direct access
  * Get
  * DownloadFile
* Login return bool if access
* Return Result class more information

## Result

The result is class **Result** and contain properties:

* **Response** returned from UrBackup (data,errors,...) Class or dynamic [ExpandoObject](https://msdn.microsoft.com/en-US/library/system.dynamic.expandoobject(v=vs.110).aspx)
* **StatusCode** (System.Net.HttpStatusCode): Status code of the HTTP response.
* **ReasonPhrase** (string): The reason phrase which typically is sent by servers together with the status code.
* **IsSuccessStatusCode** (bool) : Gets a value that indicates if the HTTP response was successful.

## Usage

```C#
var client = new UrBackupClient(false, "10.92.90.96", 55414);
if (client.Login("test", "test"))
{
    //list client last backup
    foreach (var item in client.Backups.Get().Response.Clients)
    {
        Console.Out.WriteLine(item.Name);
    }
}
```
