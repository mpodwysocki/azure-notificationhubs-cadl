import {
  InstallationsGetParameters,
  InstallationsDeleteParameters,
  InstallationsCreateOrUpdateParameters,
  InstallationsUpdateParameters,
  RegistrationsCreateParameters,
  RegistrationsListParameters,
  RegistrationsCreateOrUpdateParameters,
  RegistrationsDeleteParameters,
  RegistrationsGetParameters,
  ListRegistrationsByTagListParameters,
  NotificationsSendNotificationParameters,
  ScheduledNotificationsCancelNotificationParameters,
  ScheduledNotificationsScheduleNotificationParameters,
  NotificationHubJobsCreateParameters,
  NotificationHubJobsListParameters,
  NotificationHubJobsGetParameters,
} from "./parameters";
import {
  InstallationsGet200Response,
  InstallationsDelete204Response,
  InstallationsCreateOrUpdate200Response,
  InstallationsUpdate200Response,
  RegistrationsCreate201Response,
  RegistrationsList200Response,
  RegistrationsCreateOrUpdate201Response,
  RegistrationsDelete200Response,
  RegistrationsGet200Response,
  ListRegistrationsByTagList200Response,
  NotificationsSendNotification201Response,
  ScheduledNotificationsCancelNotification200Response,
  ScheduledNotificationsScheduleNotification201Response,
  NotificationHubJobsCreate201Response,
  NotificationHubJobsList200Response,
  NotificationHubJobsGet200Response,
} from "./responses";
import { Client, StreamableMethod } from "@azure-rest/core-client";

/** Contains operations for Installations operations */
export interface InstallationsOperations {
  /** Get an Azure Notification Hubs installation */
  get(
    installationId: string,
    options?: InstallationsGetParameters
  ): StreamableMethod<InstallationsGet200Response>;
  /** Delete an Azure Notification Hubs installation */
  delete(
    installationId: string,
    options?: InstallationsDeleteParameters
  ): StreamableMethod<InstallationsDelete204Response>;
  /** Create or update an Azure Notification Hubs installation */
  createOrUpdate(
    installationId: string,
    options: InstallationsCreateOrUpdateParameters
  ): StreamableMethod<InstallationsCreateOrUpdate200Response>;
  /** Update an Azure Notification Hubs installation using JSON Patch semantics */
  update(
    installationId: string,
    options: InstallationsUpdateParameters
  ): StreamableMethod<InstallationsUpdate200Response>;
}

/** Contains operations for Registrations operations */
export interface RegistrationsOperations {
  /** Create an Azure Notification Hubs registration description */
  create(
    options: RegistrationsCreateParameters
  ): StreamableMethod<RegistrationsCreate201Response>;
  /** List Azure Notification Hubs registration descriptions */
  list(
    options?: RegistrationsListParameters
  ): StreamableMethod<RegistrationsList200Response>;
  /** Create or update an Azure Notification Hubs registration description */
  createOrUpdate(
    registrationId: string,
    options: RegistrationsCreateOrUpdateParameters
  ): StreamableMethod<RegistrationsCreateOrUpdate201Response>;
  /** Delete an Azure Notification Hubs registration description */
  delete(
    registrationId: string,
    options?: RegistrationsDeleteParameters
  ): StreamableMethod<RegistrationsDelete200Response>;
  /** Get an Azure Notification Hubs registration description */
  get(
    registrationId: string,
    options?: RegistrationsGetParameters
  ): StreamableMethod<RegistrationsGet200Response>;
}

/** Contains operations for ListRegistrationsByTag operations */
export interface ListRegistrationsByTagOperations {
  /** List all Azure Notification Hubs registrations description matching the given tag */
  list(
    tag: string,
    options?: ListRegistrationsByTagListParameters
  ): StreamableMethod<ListRegistrationsByTagList200Response>;
}

/** Contains operations for Notifications operations */
export interface NotificationsOperations {
  /** Send a notification using Azure Notification Hubs */
  sendNotification(
    options: NotificationsSendNotificationParameters
  ): StreamableMethod<NotificationsSendNotification201Response>;
}

/** Contains operations for ScheduledNotifications operations */
export interface ScheduledNotificationsOperations {
  /** Cancel a scheduled notification */
  cancelNotification(
    notificationId: string,
    options?: ScheduledNotificationsCancelNotificationParameters
  ): StreamableMethod<ScheduledNotificationsCancelNotification200Response>;
  /** Schedule a notification */
  scheduleNotification(
    options: ScheduledNotificationsScheduleNotificationParameters
  ): StreamableMethod<ScheduledNotificationsScheduleNotification201Response>;
}

/** Contains operations for NotificationHubJobs operations */
export interface NotificationHubJobsOperations {
  /** Create an import/export Azure Notification Hubs job */
  create(
    options: NotificationHubJobsCreateParameters
  ): StreamableMethod<NotificationHubJobsCreate201Response>;
  /** List all import/export Azure Notification Hubs jobs */
  list(
    options?: NotificationHubJobsListParameters
  ): StreamableMethod<NotificationHubJobsList200Response>;
  /** Get an import/export Azure Notification Hubs job */
  get(
    jobId: string,
    options?: NotificationHubJobsGetParameters
  ): StreamableMethod<NotificationHubJobsGet200Response>;
}

export interface InstallationsGet {
  /** Get an Azure Notification Hubs installation */
  get(
    options?: InstallationsGetParameters
  ): StreamableMethod<InstallationsGet200Response>;
  /** Delete an Azure Notification Hubs installation */
  delete(
    options?: InstallationsDeleteParameters
  ): StreamableMethod<InstallationsDelete204Response>;
  /** Create or update an Azure Notification Hubs installation */
  put(
    options: InstallationsCreateOrUpdateParameters
  ): StreamableMethod<InstallationsCreateOrUpdate200Response>;
  /** Update an Azure Notification Hubs installation using JSON Patch semantics */
  patch(
    options: InstallationsUpdateParameters
  ): StreamableMethod<InstallationsUpdate200Response>;
}

export interface RegistrationsCreate {
  /** Create an Azure Notification Hubs registration description */
  post(
    options: RegistrationsCreateParameters
  ): StreamableMethod<RegistrationsCreate201Response>;
  /** List Azure Notification Hubs registration descriptions */
  get(
    options?: RegistrationsListParameters
  ): StreamableMethod<RegistrationsList200Response>;
}

export interface RegistrationsCreateOrUpdate {
  /** Create or update an Azure Notification Hubs registration description */
  put(
    options: RegistrationsCreateOrUpdateParameters
  ): StreamableMethod<RegistrationsCreateOrUpdate201Response>;
  /** Delete an Azure Notification Hubs registration description */
  delete(
    options?: RegistrationsDeleteParameters
  ): StreamableMethod<RegistrationsDelete200Response>;
  /** Get an Azure Notification Hubs registration description */
  get(
    options?: RegistrationsGetParameters
  ): StreamableMethod<RegistrationsGet200Response>;
}

export interface ListRegistrationsByTagList {
  /** List all Azure Notification Hubs registrations description matching the given tag */
  get(
    options?: ListRegistrationsByTagListParameters
  ): StreamableMethod<ListRegistrationsByTagList200Response>;
}

export interface NotificationsSendNotification {
  /** Send a notification using Azure Notification Hubs */
  post(
    options: NotificationsSendNotificationParameters
  ): StreamableMethod<NotificationsSendNotification201Response>;
}

export interface ScheduledNotificationsCancelNotification {
  /** Cancel a scheduled notification */
  delete(
    options?: ScheduledNotificationsCancelNotificationParameters
  ): StreamableMethod<ScheduledNotificationsCancelNotification200Response>;
}

export interface ScheduledNotificationsScheduleNotification {
  /** Schedule a notification */
  post(
    options: ScheduledNotificationsScheduleNotificationParameters
  ): StreamableMethod<ScheduledNotificationsScheduleNotification201Response>;
}

export interface NotificationHubJobsCreate {
  /** Create an import/export Azure Notification Hubs job */
  post(
    options: NotificationHubJobsCreateParameters
  ): StreamableMethod<NotificationHubJobsCreate201Response>;
  /** List all import/export Azure Notification Hubs jobs */
  get(
    options?: NotificationHubJobsListParameters
  ): StreamableMethod<NotificationHubJobsList200Response>;
}

export interface NotificationHubJobsGet {
  /** Get an import/export Azure Notification Hubs job */
  get(
    options?: NotificationHubJobsGetParameters
  ): StreamableMethod<NotificationHubJobsGet200Response>;
}

export interface Routes {
  /** Resource for '/installations/\{installationId\}' has methods for the following verbs: get, delete, put, patch */
  (
    path: "/installations/{installationId}",
    installationId: string
  ): InstallationsGet;
  /** Resource for '/registrations' has methods for the following verbs: post, get */
  (path: "/registrations"): RegistrationsCreate;
  /** Resource for '/registrations/\{registrationId\}' has methods for the following verbs: put, delete, get */
  (
    path: "/registrations/{registrationId}",
    registrationId: string
  ): RegistrationsCreateOrUpdate;
  /** Resource for '/tags/\{tag\}/registrations' has methods for the following verbs: get */
  (path: "/tags/{tag}/registrations", tag: string): ListRegistrationsByTagList;
  /** Resource for '/messages' has methods for the following verbs: post */
  (path: "/messages"): NotificationsSendNotification;
  /** Resource for '/schedulednotifications/\{notificationId\}' has methods for the following verbs: delete */
  (
    path: "/schedulednotifications/{notificationId}",
    notificationId: string
  ): ScheduledNotificationsCancelNotification;
  /** Resource for '/schedulednotifications' has methods for the following verbs: post */
  (path: "/schedulednotifications"): ScheduledNotificationsScheduleNotification;
  /** Resource for '/jobs' has methods for the following verbs: post, get */
  (path: "/jobs"): NotificationHubJobsCreate;
  /** Resource for '/jobs/\{jobId\}' has methods for the following verbs: get */
  (path: "/jobs/{jobId}", jobId: string): NotificationHubJobsGet;
}

export type AzureNotificationHubsServiceClient = Client & {
  path: Routes;
  installations: InstallationsOperations;
  registrations: RegistrationsOperations;
  listRegistrationsByTag: ListRegistrationsByTagOperations;
  notifications: NotificationsOperations;
  scheduledNotifications: ScheduledNotificationsOperations;
  notificationHubJobs: NotificationHubJobsOperations;
};
