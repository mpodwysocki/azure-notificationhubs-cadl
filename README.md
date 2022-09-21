# Azure Notification Hubs CADL Generator

This is the repository to create a [CADL](https://github.com/microsoft/cadl/) representation of [Azure Notification Hubs](https://aka.ms/nh-rest-api).  To generate the CADL output, run the following command:

```bash
npx cadl compile main.cadl --emit @cadl-lang/openapi3
```

This then generates the OpenAPI version of Azure Notification Hubs.

## LICENSE

MIT
