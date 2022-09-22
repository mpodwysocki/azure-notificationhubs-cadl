# Azure Notification Hubs CADL Generator

This is the repository to create a [CADL](https://github.com/microsoft/cadl/) representation of [Azure Notification Hubs](https://aka.ms/nh-rest-api).

This builds for the following emitters:

- C#
- Java
- OpenAPI3
- Python

## C# Support

To build the C# library, run the following command:

```bash
npm run build:csharp
```

This will build the `cadl-output/csharp/cadl.json` file, which used with the `Configuration.json`, will build the C# SDK.

**NOTE** This uses the [autorest.csharp](https://github.com/Azure/autorest.csharp/) CADL extension directly instead from npm.  See instructions in the [C# CADL Extension](https://github.com/Azure/autorest.csharp/tree/feature/v3/src/CADL.Extension) project.

## Java Support

To build the Java library, run the following command:

```bash
npm run build:java
```

This will build the Java project in the `cadl-output/java` directory

**NOTE** This uses the [autorest.java](https://github.com/Azure/autorest.java/) CADL extension directly instead from npm.  See instructions in the [cadl-extension](https://github.com/Azure/autorest.java/tree/main/cadl-extension) project.

## OpenAPI3 Support

To build the OpenAPI version 3 JSON file, run the following command:

```bash
npm run build:openapi3
```

This will build the `cadl-output/openapi3/openapi.json` file.

## Python Support

To build the Python library, run the following command:

```bash
npm run build:python
```

This will build the notificationhubs project in the `cadl-output/python` directory.

## LICENSE

MIT
