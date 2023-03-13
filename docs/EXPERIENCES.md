# CADL Developer Experiences

This is meant to be an overall experiences summary for creating an Azure Notification Hubs client using CADL.

## Getting started

Previously, there was a [CADL Tutorial](https://github.com/microsoft/cadl/blob/main/docs/tutorial.md) which was recently replaced with a full [GitHub Docs for CADL](https://microsoft.github.io/cadl/).  Currently, the docs have an explanation of CADL, but not a reason why you would use this over Swagger or other tools.  Although these are early days, a good differentiator as to why developers should care on the landing is crucial.

### Installation

Installation is straight forward with the new documentation with needing the global install of the `@cadl-lang/compiler` as well as the installation of the VS Code/Insiders Extension.  The new bootstrapper from now creates a `main.cadl` and `cadl-project.yaml` which allows to configure multiple emitters such as `@cadl-lang/openapi3`, `@azure-tools/` amongst others.

### Creating a CADL Definition

CADL has a few guides to getting started including [Writing CADL libraries](https://microsoft.github.io/docs/extending-cadl/basics/).  What is more important is creating a service which seems hidden under the [HTTP and REST](https://cadlwebsite.z1.web.core.windows.net/docs/standard-library/http/) which should be more prominent.

It took a bit of hand holding to create the service definition as there was very little documentation on the service itself.  In order to be a more complete service, more concrete examples are required, such as operations that return a status code, body, and not just a simple model.  I fear that customers may run into this issue if there are not more examples given in terms of a quickstart.

## Language Modeling Confusion

There is some confusion when modeling polymorphic classes, such as the case of a `Notification` model and then a specialization of the `Notification` model per type with a `@kind` discriminator.

For example, one could model such as the following:

```cadl
@discriminator("platform")
model Notification {
  body: string;
  headers?: Record<string>;
}

model AppleNotification extends Notification {
  contentType: "application/json;charset=utf-8";
  platform: "apple";
}
```

Does one also include a [union](https://microsoft.github.io/cadl/docs/language-basics/unions/) for example of all possible types of Notification?  Which provides a better experience for customers?

```cadl
@discriminator("platform")
model NotificationCommon {
  body: string;
  headers?: Record<string>;
}

model AppleNotification extends Notification {
  contentType: "application/json;charset=utf-8";
  platform: "apple";
}

alias Notification =
  AppleNotification |
  AdmNotification |
  BaiduNotification |
  BrowserNotification |
  FcmLegacyNotification |
  WindowsNotification
```

## CADL Language Improvements

CADL could use a few overall language improvements.

### Property Type Refinements

By default, you cannot specify a base property on a model and then specialize it such as the following.  It would be ideal if we could support this.

```cadl
enum Direction {
  North: "north",
  East: "east",
  South: "south",
  West: "west",
}

model BaseModel {
  type: Direction;
}

model ExtendedModel {
  type: Direction.North;
}
```

### Composite Input Parameters

One feature that would be nice is to be able to collapse parameters such as HTTP Headers, HTTP Body and other fields into a single model for consumption.

```cadl
@discriminator("platform")
model Notification {
  @body
  body: string;
  // TODO: Map this to setting to HTTP parameters?
  headers?: Record<string>;
}

model AppleNotification extends Notification {
  @header("Content-Type")
  contentType: "application/json;charset=utf-8";
  @header("ServiceBusNotification-Format")
  platform: "apple";
}
```

Then one could implement this on an operation such as the following where it accept a `Notification` type parameter to encompass those properties.

```cadl
@doc("Azure Notification Hubs message operations")
@route("/messages")
namespace Notifications {
  @doc("Send a notification using Azure Notification Hubs")
  @post
  op sendNotification(
    @doc("Direct send operation")
    @query direct?: boolean,
    @doc("Enables test send for debug purposes")
    @query test: boolean,
    @doc("The notification to send")
    notification: Notification,
    @doc("The notification target device handle")
    @header("ServiceBusNotification-DeviceHandle") deviceHandle?: string;
    @doc("The notification target tag expression")
    @header("ServiceBusNotification-Tags") tags?: string
  ): {
    @doc("Successful status code")
    @statusCode statusCode: 201;
    @header location?: string;
    @doc("The tracking ID header")
    @header trackingId: string;
    @doc("The correlation ID header")
    @header("x-ms-correlation-request-id") correlationId: string;
    @body outcome?: NotificationOutcome;
  };
}
```

### Conditional Input Parameters

In some cases, you want to have some parameters as required and some optional based upon the scenario.  For example, if you look at the case of sending a notification using Azure Notification Hubs.  There are three different scenarios.

1. Broadcast send (no tags and optional test send)
2. Tag based send (tag expression and optional test send)
3. Direct send (device handle and no tags)

This could be modeled as the following where you have two sets of parameter types or undefined if just a general broadcast send with no test send enabled.

```cadl
model SendNotificationParameters {
  @header("ServiceBusNotification-Tags")
  tagExpression?: string;
  @query("test")
  enableTestSend?: boolean;
}

model SendDirectNotificationParameters {
  @header("ServiceBusNotification-DeviceHandle")
  deviceHandle: string;
}

@doc("Azure Notification Hubs message operations")
@route("/messages")
namespace Notifications {
  @doc("Send a notification using Azure Notification Hubs")
  @post
  op sendNotification(
    @doc("The notification to send")
    notification: Notification,
    @doc("The send parameters")
    parameters?: SendNotificationParameters | SendDirectNotificationParameters,
  ): {
    @doc("Successful status code")
    @statusCode statusCode: 201;
    @header location?: string;
    @doc("The tracking ID header")
    @header trackingId: string;
    @doc("The correlation ID header")
    @header("x-ms-correlation-request-id") correlationId: string;
    @body outcome?: NotificationOutcome;
  };
}
```

### XML and Other Format Support

Azure Notification Hubs has many APIs that are Atom+XML based which is not easy to describe using CADL directly.  Instead, I would prefer to model an object directly such as a `RegistrationDescription` as the desired state, and transform into Atom+XML entry and feed format directly.

For example, I could describe a `RegistrationDescription` and `AppleRegistrationDescription` as the following:

```cadl
@discriminator("platform")
@doc("Represents an Azure Notification Hubs registration description")
model RegistrationDescription {
  @doc("The registration ID")
  registrationId?: string;
  @doc("The registration tags comma separated list")
  tags?: string;
  @doc("The registration etag")
  etag?: string;
  @doc("The registration push variables property bag")
  pushVariables?: Record<string>;
  @doc("The registration expiration time")
  expirationTime?: plainDate;
}

@doc("Represents an Apple based Azure Notification Hubs registration description")
model AppleRegistrationDescription extends RegistrationDescription {
  @doc("The APNs device token")
  deviceToken: string;
  @doc("The platform of registration description")
  platform: "apple";
}
```

These models, should have the `platform` property removed, and serialized into a Atom+XML entry with Pascal case properties such as the following.

```xml
<?xml version="1.0" encoding="utf-8"?>
<entry xmlns="http://www.w3.org/2005/Atom">
  <content type="application/xml">
    <AppleRegistrationDescription xmlns:i="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://schemas.microsoft.com/netservices/2010/10/servicebus/connect">
      <Tags>myTag, myOtherTag</Tags>
      <DeviceToken>{DeviceToken}</DeviceToken>
    </AppleRegistrationDescription>
  </content>
</entry>
```

And in the case of `list` methods, should be wrapped in an Atom+XML feed such as the following:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<feed xmlns="http://www.w3.org/2005/Atom">
  <title type="/{NotificationTopic}/channels/{channel hash}" />
  <id> https://{tenant}.windows.net/{NotificationTopic}/channels/{channel hash}</id>
  <updated>2012-08-17T17:32:00Z</updated>
  <entry xmlns:m="http://schemas.microsoft.com/ado/2007/08/dataservices/metadata" m:etag="1">
    <id>https://{tenant}.windows.net/{NotificationTopic}/registrations/{registrationId}</id>
    <title type="text"> /{NotificationTopic}/registrations/{registrationId}</title>
    <updated>2012-08-17T17:32:00Z</updated>
    <content type="application/xml">
      <AppleRegistrationDescription xmlns:i="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://schemas.microsoft.com/netservices/2010/10/servicebus/connect">
        <Tags>myTag, myOtherTag</Tags>
        <DeviceToken>{DeviceToken}</DeviceToken>
      </AppleRegistrationDescription>
    </content>
  </entry>
  <entry>
    <!-- Other entries -->
  </entry>
</feed>
```

This should support CDATA, namespaces, attributes and other pieces such as the following possible annotations:

- `@xmlAttribute("name")`
- `@xmlElement("name")`
- `@xmlCdata("CDataElement")`
- `@xmlNamespace("i", "http://www.w3.org/2001/XMLSchema-instance")`
- `@xmlArrayItem("Results", "Result")`

## Language Emitters

By default, the OpenAPI3 CADL Emitter is the first emitter that most developers will use.  There are, however, language support for the following:

- C#
- Java
- Python
- TypeScript

Each of these can be specified in the `cadl-project.yaml` file to whether they should build or not.  The configuration options, however, are lacking, such as `output-dir` that can be passed along through YAML.  Instead, I have found it more useful to have npm scripts in the package.json to build each language separately.

```json
"scripts": {
  "build": "npm run build:openapi3 && npm run build:python && npm run build:java && npm run build:csharp && npm run build:ts",
  "build:csharp": "cadl compile main.cadl --emit ../autorest.csharp.fork/src/CADL.Extension/Emitter.Csharp/dist/src/index.js --output-path cadl-output/csharp",
  "build:java": "cadl compile main.cadl --emit ../autorest.java/cadl-extension/dist/src/index.js --output-path cadl-output/java",
  "build:openapi3": "cadl compile main.cadl --emit @cadl-lang/openapi3 --output-path cadl-output/openapi3",
  "build:python": "cadl compile main.cadl --emit @azure-tools/cadl-python --output-path cadl-output/python",
  "build:ts": "cadl compile main.cadl --emit ../autorest.typescript/packages/cadl-rlc-emitter/dist/src/index.js --output-path cadl-output/ts"
},
```

The emitters are varying in their maturity, but should be using the `--emit @azure-tools/<language>` once completed instead of direct links to the entry point from the AutoRest repository built CADL emitter.

### OpenAPI3 CADL Emitter

The [OpenAPI3 Emitter](https://microsoft.github.io/cadl/docs/standard-library/openapi/) is included for most operations.  This can be configured via the `cadl-project.yaml` file, however, lacks a direct way of setting the output directory, only including the `output-file` options.  **If I wanted to configure each language, I do not want them by default to put in the same output folder.**

### C# CADL Emitter

The least mature of the Tier 1 languages is the C# CADL emitter.  Currently this requires a `Configuration.json` file which specifies the library name, namespace, and shared library folders.

```json
{
  "OutputFolder": ".",
  "Namespace": "Microsoft.Azure.NotificationHubs",
  "LibraryName": "Microsoft.Azure.NotificationHubs",
  "SharedSourceFolders": [
    "../../../autorest.csharp/artifacts/bin/AutoRest.CSharp/Debug/netcoreapp3.1/Generator.Shared",
    "../../../autorest.csharp/artifacts/bin/AutoRest.CSharp/Debug/netcoreapp3.1/Azure.Core.Shared"
  ]
}
```

**If we could instead have options supported for the `cadl-project.yaml` instead of needing external files, this would be ideal.  If we are going to make use of the project file, then we should have all options available.**

Note that the published npm package `@azure-tools/cadl-csharp` is not up to date and does not work with the Azure Notification Hubs.  Instead, we are using a direct links to the `autorest.csharp` project.  In order to get the CADL Emitter to compile, the solution must be built using dotnet build, and then the CADL emitter must be built using `pnpm install` followed by `pnpm build`, fixing and peer dependency issues along the way.

When compiling, this creates a `cadl.json` file by doing the following:

```bash
cadl compile main.cadl --emit ../autorest.csharp.fork/src/CADL.Extension/Emitter.Csharp/dist/src/index.js --output-path cadl-output/csharp
```

Once the `cadl.json` file has been created, this is then fed into `AutoRest.CSharp` to compile the JSON file into C#:

```bash
~/git/autorest.csharp/artifacts/bin/AutoRest.CSharp/Debug/netcoreapp3.1/AutoRest.CSharp --standalone cadl-output/csharp/
```

Ideally this should be done as a single step instead of requiring two steps here.

### Java CADL Emitter

The Java CADL emitter as of this current post is not currently on npm.  There are currently releases of the CADL emitter on GitHub that can be downloaded and referenced manually here:

- [AutoRest Java CADL Preview Directions](https://github.com/Azure/autorest.java/wiki/Cadl-(preview))
- [AutoRest Java CADL Releases](https://github.com/Azure/autorest.java/releases)

You can also build locally using the `autorest.java` repository as well such as the following:

```bash
mvn package -P local,cadl
```

The CADL emitter must be built using `pnpm install` followed by `pnpm build`, fixing and peer dependency issues along the way just as above with the C# CADL Emitter.

```bash
cadl compile main.cadl --emit ../autorest.java/cadl-extension/dist/src/index.js --output-path cadl-output/java
```

Once this project is packaged with the `.jar` dependency, this should be a straight forward build as long as the customer's Java environment is configured properly.

### Python CADL Emitter

The Python CADL emitter was the first to be built for Azure Notification Hubs.  The Python team regularly publishes to `@azure-tools/cadl-python` and was able to build with assistance from the Python team directly.  There were some issues where `union` types were not being properly processed which caused a design change in the Azure Notification Hubs service to use a base model with discriminator instead of the `union` type.

### TypeScript CADL Emitter

The TypeScript RLC CADL Emitter creates a Rest Level Client (RLC) for your library.  Like C#, this requires an external configuration file `typescript.json` in the `cadl-output/spec` folder.  This includes the following information:

```json
{
  "generateMetadata": true,
  "includeShortcuts": true,
  "packageDetails": {
    "name": "@azure/notification-hubs-rlc",
    "description": "Azure Notification Hubs Rest Level Client",
    "version": "1.0.0-beta.1"
  }
}
```

There are some code generation issues where issues will be filed around discriminators type aliases for strings.  Like with the C# and Java versions, this was pulled down manually and then built using `rush` with `rush update` and `rush build`.  Then it could be referenced in our npm build script.

**Like with C#, if we could have these as options inside the project YAML file, that would be ideal.**

## Conclusion

In wrapping up, CADL is a very promising technology to allow us to describe our services in much better detail than before.  We need to therefore put more emphasis on documentation, exemplars and Quick Starts to allow our customers an easy onboarding.  Many developers will not have the same resources and access to team members as I have in order to create the CADL models, and then in turn, turn them into working code for our Tier 1 languages.

The CADL language itself is a good language to allow for modeling, but there are gaps as I've noted above such as the model inheritance and union types.  Error messages should also be helpful instead of me having to ask the developers what they mean.  In the perfect world, we could not only tell them the error in their CADL, but also a relevant link to our documentation on what is supported and not supported.

The emitters are still in their infancy which require a lot of manual intervention with multiple steps and external configuration files.  Ideally, the external configuration files should be able to turned into the `cadl-project.yaml` options to allow for more customization per language.
