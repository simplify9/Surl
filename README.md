
| **Package** |**Version** |**Downloads** |
| ------- | ----- | ----- |
| `SimplyWorks.Surl.Sdk` | [![NuGet](https://img.shields.io/nuget/v/SimplyWorks.Surl.Sdk.svg)](https://nuget.org/packages/SimplyWorks.Surl.Sdk) | [![Nuget](https://img.shields.io/nuget/dt/SimplyWorks.Surl.Sdk.svg)](https://nuget.org/packages/SimplyWorks.Surl.Sdk)

# Surl

Surl is a simple library that handles Short URL handling, utilizing a simple API to create and get 
the short URLs, with a middleware to handle redirection.

## Middleware

The middleware calls the GET API that retrieves a URL based on a key, and redirects the user.

## API

* GET ShortUrls/key: Retrieves a URL entry.
* POST ShortUrls: Creates a URL entry.
Model:
```
{
  fullUrl: string
}
```


