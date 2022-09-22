import { getClient, ClientOptions } from "@azure-rest/core-client";
import { AzureNotificationHubsServiceClient } from "./clientDefinitions";

/**
 * Initialize a new instance of the class AzureNotificationHubsServiceClient class.
 * @param namespaceName type: string
 * @param hubName type: string
 */
export default function createClient(
  namespaceName: string,
  hubName: string,
  options: ClientOptions = {}
): AzureNotificationHubsServiceClient {
  const baseUrl =
    options.baseUrl ??
    `https://${namespaceName}.servicebus.windows.net/${hubName}`;
  options.apiVersion = options.apiVersion ?? "2020-06";
  const userAgentInfo = `azsdk-js-notification-hubs-rlc-rest/1.0.0-beta.1`;
  const userAgentPrefix =
    options.userAgentOptions && options.userAgentOptions.userAgentPrefix
      ? `${options.userAgentOptions.userAgentPrefix} ${userAgentInfo}`
      : `${userAgentInfo}`;
  options = {
    ...options,
    userAgentOptions: {
      userAgentPrefix,
    },
  };

  const client = getClient(
    baseUrl,
    options
  ) as AzureNotificationHubsServiceClient;

  return {
    ...client,
    installations: {
      get: (installationId, options) => {
        return client
          .path("/installations/{installationId}", installationId)
          .get(options);
      },
      delete: (installationId, options) => {
        return client
          .path("/installations/{installationId}", installationId)
          .delete(options);
      },
      createOrUpdate: (installationId, options) => {
        return client
          .path("/installations/{installationId}", installationId)
          .put(options);
      },
      update: (installationId, options) => {
        return client
          .path("/installations/{installationId}", installationId)
          .patch(options);
      },
    },
    registrations: {
      create: (options) => {
        return client.path("/registrations").post(options);
      },
      list: (options) => {
        return client.path("/registrations").get(options);
      },
      createOrUpdate: (registrationId, options) => {
        return client
          .path("/registrations/{registrationId}", registrationId)
          .put(options);
      },
      delete: (registrationId, options) => {
        return client
          .path("/registrations/{registrationId}", registrationId)
          .delete(options);
      },
      get: (registrationId, options) => {
        return client
          .path("/registrations/{registrationId}", registrationId)
          .get(options);
      },
    },
    listRegistrationsByTag: {
      list: (tag, options) => {
        return client.path("/tags/{tag}/registrations", tag).get(options);
      },
    },
    notifications: {
      sendNotification: (options) => {
        return client.path("/messages").post(options);
      },
    },
    scheduledNotifications: {
      cancelNotification: (notificationId, options) => {
        return client
          .path("/schedulednotifications/{notificationId}", notificationId)
          .delete(options);
      },
      scheduleNotification: (options) => {
        return client.path("/schedulednotifications").post(options);
      },
    },
    notificationHubJobs: {
      create: (options) => {
        return client.path("/jobs").post(options);
      },
      list: (options) => {
        return client.path("/jobs").get(options);
      },
      get: (jobId, options) => {
        return client.path("/jobs/{jobId}", jobId).get(options);
      },
    },
  };
}
