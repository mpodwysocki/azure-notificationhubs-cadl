import { RawHttpHeaders } from "@azure/core-rest-pipeline";
import { HttpResponse } from "@azure-rest/core-client";
import {
  InstallationOutput,
  RegistrationDescriptionOutput,
  NotificationOutcomeOutput,
  NotificationHubJobOutput,
} from "./outputModels";

/** The request has succeeded. */
export interface InstallationsGet200Response extends HttpResponse {
  status: "200";
  body: InstallationOutput;
}

export interface InstallationsDelete204Headers {
  /** The tracking ID header */
  "tracking-id": string;
  /** The correlation ID header */
  "x-ms-correlation-request-id": string;
}

/** There is no content to send for this request, but the headers may be useful. */
export interface InstallationsDelete204Response extends HttpResponse {
  status: "204";
  headers: RawHttpHeaders & InstallationsDelete204Headers;
}

export interface InstallationsCreateOrUpdate200Headers {
  /** The tracking ID header */
  "tracking-id": string;
  /** The correlation ID header */
  "x-ms-correlation-request-id": string;
}

/** The request has succeeded. */
export interface InstallationsCreateOrUpdate200Response extends HttpResponse {
  status: "200";
  headers: RawHttpHeaders & InstallationsCreateOrUpdate200Headers;
}

export interface InstallationsUpdate200Headers {
  /** The tracking ID header */
  "tracking-id": string;
  /** The correlation ID header */
  "x-ms-correlation-request-id": string;
}

/** The request has succeeded. */
export interface InstallationsUpdate200Response extends HttpResponse {
  status: "200";
  headers: RawHttpHeaders & InstallationsUpdate200Headers;
}

/** The request has succeeded and a new resource has been created as a result. */
export interface RegistrationsCreate201Response extends HttpResponse {
  status: "201";
  body: RegistrationDescriptionOutput;
}

/** The request has succeeded and a new resource has been created as a result. */
export interface RegistrationsCreateOrUpdate201Response extends HttpResponse {
  status: "201";
  body: RegistrationDescriptionOutput;
}

export interface RegistrationsDelete200Headers {
  /** The tracking ID header */
  "tracking-id": string;
  /** The correlation ID header */
  "x-ms-correlation-request-id": string;
}

/** The request has succeeded. */
export interface RegistrationsDelete200Response extends HttpResponse {
  status: "200";
  headers: RawHttpHeaders & RegistrationsDelete200Headers;
}

/** The request has succeeded. */
export interface RegistrationsGet200Response extends HttpResponse {
  status: "200";
  body: RegistrationDescriptionOutput;
}

export interface RegistrationsList200Headers {
  /** The continuation token for more results */
  "x-ms-continuationtoken"?: string;
}

/** The request has succeeded. */
export interface RegistrationsList200Response extends HttpResponse {
  status: "200";
  body: Array<RegistrationDescriptionOutput>;
  headers: RawHttpHeaders & RegistrationsList200Headers;
}

export interface ListRegistrationsByTagList200Headers {
  /** The continuation token for more results */
  "x-ms-continuationtoken"?: string;
}

/** The request has succeeded. */
export interface ListRegistrationsByTagList200Response extends HttpResponse {
  status: "200";
  body: Array<RegistrationDescriptionOutput>;
  headers: RawHttpHeaders & ListRegistrationsByTagList200Headers;
}

export interface NotificationsSendNotification201Headers {
  location?: string;
  /** The tracking ID header */
  "tracking-id": string;
  /** The correlation ID header */
  "x-ms-correlation-request-id": string;
}

/** The request has succeeded and a new resource has been created as a result. */
export interface NotificationsSendNotification201Response extends HttpResponse {
  status: "201";
  body: NotificationOutcomeOutput;
  headers: RawHttpHeaders & NotificationsSendNotification201Headers;
}

export interface ScheduledNotificationsCancelNotification200Headers {
  /** The tracking ID header */
  "tracking-id": string;
  /** The correlation ID header */
  "x-ms-correlation-request-id": string;
}

/** The request has succeeded. */
export interface ScheduledNotificationsCancelNotification200Response
  extends HttpResponse {
  status: "200";
  headers: RawHttpHeaders & ScheduledNotificationsCancelNotification200Headers;
}

export interface ScheduledNotificationsScheduleNotification201Headers {
  /** The HTTP location header */
  location: string;
  /** The tracking ID header */
  "tracking-id": string;
  /** The correlation ID header */
  "x-ms-correlation-request-id": string;
}

/** The request has succeeded and a new resource has been created as a result. */
export interface ScheduledNotificationsScheduleNotification201Response
  extends HttpResponse {
  status: "201";
  headers: RawHttpHeaders &
    ScheduledNotificationsScheduleNotification201Headers;
}

/** The request has succeeded and a new resource has been created as a result. */
export interface NotificationHubJobsCreate201Response extends HttpResponse {
  status: "201";
  body: NotificationHubJobOutput;
}

/** The request has succeeded. */
export interface NotificationHubJobsGet200Response extends HttpResponse {
  status: "200";
  body: NotificationHubJobOutput;
}

/** The request has succeeded. */
export interface NotificationHubJobsList200Response extends HttpResponse {
  status: "200";
  body: Array<NotificationHubJobOutput>;
}
