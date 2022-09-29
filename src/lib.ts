import { createCadlLibrary } from "@cadl-lang/compiler";

export const notificationHubsLibrary = createCadlLibrary({
  name: "@azure/notification-hubs-cadl",
  diagnostics: {},
});

// optional but convenient
export const { reportDiagnostic, createDiagnostic, createStateSymbol } = notificationHubsLibrary;
