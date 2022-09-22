import { RawHttpHeadersInput } from "@azure/core-rest-pipeline";
import { RequestParameters } from "@azure-rest/core-client";
import {
  Installation,
  RegistrationDescription,
  NotificationHubJob,
} from "./models";

export type InstallationsGetParameters = RequestParameters;
export type InstallationsDeleteParameters = RequestParameters;

export interface InstallationsCreateOrUpdateBodyParam {
  /** The installation object */
  body: Installation;
}

export type InstallationsCreateOrUpdateParameters =
  InstallationsCreateOrUpdateBodyParam & RequestParameters;

export interface InstallationsUpdateBodyParam {
  /** The installation patches */
  body: array;
}

export type InstallationsUpdateParameters = InstallationsUpdateBodyParam &
  RequestParameters;

export interface RegistrationsCreateHeaders {
  /** The HTTP content-type */
  "Content-Type": "application/atom+xml;type=entry;charset=utf-8";
}

export interface RegistrationsCreateBodyParam {
  /** The registration description */
  body: RegistrationDescription;
}

export interface RegistrationsCreateHeaderParam {
  headers: RawHttpHeadersInput & RegistrationsCreateHeaders;
}

export type RegistrationsCreateParameters = RegistrationsCreateHeaderParam &
  RegistrationsCreateBodyParam &
  RequestParameters;

export interface RegistrationsCreateOrUpdateHeaders {
  /** The Content-Type HTTP header */
  "Content-Type": "application/atom+xml;type=entry;charset=utf-8";
  /** The If-Match HTTP header */
  "If-Match"?: string;
}

export interface RegistrationsCreateOrUpdateBodyParam {
  /** The registration description */
  body: RegistrationDescription;
}

export interface RegistrationsCreateOrUpdateHeaderParam {
  headers: RawHttpHeadersInput & RegistrationsCreateOrUpdateHeaders;
}

export type RegistrationsCreateOrUpdateParameters =
  RegistrationsCreateOrUpdateHeaderParam &
    RegistrationsCreateOrUpdateBodyParam &
    RequestParameters;

export interface RegistrationsDeleteHeaders {
  /** The If-Match HTTP header */
  "If-Match"?: string;
}

export interface RegistrationsDeleteHeaderParam {
  headers: RawHttpHeadersInput & RegistrationsDeleteHeaders;
}

export type RegistrationsDeleteParameters = RegistrationsDeleteHeaderParam &
  RequestParameters;
export type RegistrationsGetParameters = RequestParameters;

export interface RegistrationsListQueryParamProperties {
  /** The limit to the number of records to retrieve */
  $top?: string;
  /** The filter query to find registrations */
  $fitler?: string;
  /** The continuation token for more results */
  continuationToken?: string;
}

export interface RegistrationsListQueryParam {
  queryParameters?: RegistrationsListQueryParamProperties;
}

export type RegistrationsListParameters = RegistrationsListQueryParam &
  RequestParameters;

export interface ListRegistrationsByTagListQueryParamProperties {
  /** The limit to the number of records to retrieve */
  $top?: string;
  /** The continuation token for more results */
  continuationToken?: string;
}

export interface ListRegistrationsByTagListQueryParam {
  queryParameters?: ListRegistrationsByTagListQueryParamProperties;
}

export type ListRegistrationsByTagListParameters =
  ListRegistrationsByTagListQueryParam & RequestParameters;

export interface NotificationsSendNotificationHeaders {
  /** The notification target platform */
  "ServiceBusNotification-Format": string;
  /** The notification target device handle */
  "ServiceBusNotification-DeviceHandle"?: string;
  /** The notification target tag expression */
  "ServiceBusNotification-Tags"?: string;
}

export interface NotificationsSendNotificationBodyParam {
  /** The notification to send */
  body: string;
}

export interface NotificationsSendNotificationQueryParamProperties {
  /** Direct send operation */
  direct?: boolean;
  /** Enables test send for debug purposes */
  test: boolean;
}

export interface NotificationsSendNotificationQueryParam {
  queryParameters: NotificationsSendNotificationQueryParamProperties;
}

export interface NotificationsSendNotificationHeaderParam {
  headers: RawHttpHeadersInput & NotificationsSendNotificationHeaders;
}

export type NotificationsSendNotificationParameters =
  NotificationsSendNotificationQueryParam &
    NotificationsSendNotificationHeaderParam &
    NotificationsSendNotificationBodyParam &
    RequestParameters;
export type ScheduledNotificationsCancelNotificationParameters =
  RequestParameters;

export interface ScheduledNotificationsScheduleNotificationHeaders {
  /** The notification scheduled time */
  "ServiceBusNotification-ScheduleTime": string;
  /** The notification target platform */
  "ServiceBusNotification-Format": string;
  /** The notification target tag expression */
  "ServiceBusNotification-Tags"?: string;
}

export interface ScheduledNotificationsScheduleNotificationBodyParam {
  /** The notification to schedule */
  body: string;
}

export interface ScheduledNotificationsScheduleNotificationHeaderParam {
  headers: RawHttpHeadersInput &
    ScheduledNotificationsScheduleNotificationHeaders;
}

export type ScheduledNotificationsScheduleNotificationParameters =
  ScheduledNotificationsScheduleNotificationHeaderParam &
    ScheduledNotificationsScheduleNotificationBodyParam &
    RequestParameters;

export interface NotificationHubJobsCreateHeaders {
  /** The HTTP Content-Type header */
  "Content-Type": "application/atom+xml;type=entry;charset=utf-8";
}

export interface NotificationHubJobsCreateBodyParam {
  /** The Azure Notification Hub import/export job to create */
  body: NotificationHubJob;
}

export interface NotificationHubJobsCreateHeaderParam {
  headers: RawHttpHeadersInput & NotificationHubJobsCreateHeaders;
}

export type NotificationHubJobsCreateParameters =
  NotificationHubJobsCreateHeaderParam &
    NotificationHubJobsCreateBodyParam &
    RequestParameters;
export type NotificationHubJobsGetParameters = RequestParameters;
export type NotificationHubJobsListParameters = RequestParameters;
