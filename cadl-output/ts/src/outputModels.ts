/** Represents an Azure Notification Hubs Installation */
export interface InstallationOutputParent {
  /** The installation ID */
  installationId: string;
  /** The user ID */
  userId?: string;
  /** The installation expiration time */
  expirationTime?: string;
  /** The last updated date */
  lastUpdate?: string;
  /** The itags for the installation */
  tags: string[];
  /** The templates for the installation */
  templates: Record<string, string>;
  platform: "Installation" | "browser" | "gcm";
}

/** Represents an Web Push based Azure Notification Hubs Installation */
export interface BrowserInstallationOutput extends InstallationOutputParent {
  platform: "browser";
  /** The Web API push handle for the installation */
  pushHandle: BrowserPushHandleOutput;
}

/** Represents a Web Push push handle */
export interface BrowserPushHandleOutput {
  /** The Web Push API endpoint */
  endpoint: string;
  /** The Web Push API P256DH key */
  p256dh: string;
  /** The Web Push API auth secret */
  auth: string;
}

/** Represents an FCM Legacy based Azure Notification Hubs Installation */
export interface FcmLegacyInstallationOutput extends InstallationOutputParent {
  platform: "gcm";
}

/** Represents an Azure Notification Hubs registration description */
export interface RegistrationDescriptionOutputParent {
  /** The registration ID */
  registrationId?: string;
  /** The registration tags comma separated list */
  tags?: string;
  /** The registration etag */
  etag?: string;
  /** The registration push variables property bag */
  pushVariables?: Record<string, string>;
  /** The registration expiration time */
  expirationTime?: string;
  platform:
    | "RegistrationDescription"
    | "adm"
    | "admTemplate"
    | "apple"
    | "appleTemplate"
    | "baidu"
    | "baiduTemplate"
    | "browser"
    | "browserTemplate"
    | "gcm"
    | "gcmTemplate"
    | "mpns"
    | "mpnsTemplate"
    | "windows"
    | "windowsTemplate";
}

/** Represents an ADM based Azure Notification Hubs registration description */
export interface AdmRegistrationDescriptionOutput
  extends RegistrationDescriptionOutputParent {
  /** The ADM registration ID */
  admRegistrationId: string;
  platform: "adm";
}

/** Represents an ADM template based Azure Notification Hubs registration description */
export interface AdmTemplateRegistrationDescriptionOutput
  extends RegistrationDescriptionOutputParent {
  /** The ADM registration ID */
  admRegistrationId: string;
  platform: "admTemplate";
  /** The registration body template */
  bodyTemplate: string;
  /** The registration template name */
  templateName?: string;
}

/** Represents an Apple based Azure Notification Hubs registration description */
export interface AppleRegistrationDescriptionOutput
  extends RegistrationDescriptionOutputParent {
  /** The APNs device token */
  deviceToken: string;
  platform: "apple";
}

/** Represents an Apple template based Azure Notification Hubs registration description */
export interface AppleTemplateRegistrationDescriptionOutput
  extends RegistrationDescriptionOutputParent {
  /** The APNs device token */
  deviceToken: string;
  /** The APNs headers for the template */
  apnsHeaders?: Record<string, string>;
  /** The APNs priority for any message */
  priority?: number;
  platform: "appleTemplate";
  /** The registration body template */
  bodyTemplate: string;
  /** The registration template name */
  templateName?: string;
}

/** Represents a Baidu based Azure Notification Hubs registration description */
export interface BaiduRegistrationDescriptionOutput
  extends RegistrationDescriptionOutputParent {
  /** The Baidu channel ID */
  baiduChannelId: string;
  /** The baidu user ID */
  baiduUserId: string;
  platform: "baidu";
}

/** Represents a Baidu template based Azure Notification Hubs registration description */
export interface BaiduTemplateRegistrationDescriptionOutput
  extends RegistrationDescriptionOutputParent {
  /** The Baidu channel ID */
  baiduChannelId: string;
  /** The baidu user ID */
  baiduUserId: string;
  platform: "baiduTemplate";
  /** The registration body template */
  bodyTemplate: string;
  /** The registration template name */
  templateName?: string;
}

/** Represents a Web Push based Azure Notification Hubs registration description */
export interface BrowserRegistrationDescriptionOutput
  extends RegistrationDescriptionOutputParent {
  /** The Web Push endpoint URL */
  endpoint: string;
  /** The Web Push auth secret */
  auth: string;
  /** The Web Push P256DH */
  p256dh: string;
  platform: "browser";
}

/** Represents a Web Push template based Azure Notification Hubs registration description */
export interface BrowserTemplateRegistrationDescriptionOutput
  extends RegistrationDescriptionOutputParent {
  /** The Web Push endpoint URL */
  endpoint: string;
  /** The Web Push auth secret */
  auth: string;
  /** The Web Push P256DH */
  p256dh: string;
  platform: "browserTemplate";
  /** The registration body template */
  bodyTemplate: string;
  /** The registration template name */
  templateName?: string;
}

/** Represents a Firebase Legacy based Azure Notification Hubs registration description */
export interface GcmRegistrationDescriptionOutput
  extends RegistrationDescriptionOutputParent {
  /** The Firebase Legacy registration ID */
  gcmRegistrationId: string;
  platform: "gcm";
}

/** Represents a Firebase Legacy template based Azure Notification Hubs registration description */
export interface GcmTemplateRegistrationDescriptionOutput
  extends RegistrationDescriptionOutputParent {
  /** The Firebase Legacy registration ID */
  gcmRegistrationId: string;
  platform: "gcmTemplate";
  /** The registration body template */
  bodyTemplate: string;
  /** The registration template name */
  templateName?: string;
}

/** Represents a Windows Phone based Azure Notification Hubs registration description */
export interface MpnsRegistrationDescriptionOutput
  extends RegistrationDescriptionOutputParent {
  /** The Windows Phone channel URL */
  channelUri: string;
  platform: "mpns";
}

/** Represents a Windows Phone template based Azure Notification Hubs registration description */
export interface MpnsTemplateRegistrationDescriptionOutput
  extends RegistrationDescriptionOutputParent {
  /** The Windows Phone channel URL */
  channelUri: string;
  /** The Windows Phone template headers */
  mpnsHeaders?: Record<string, string>;
  platform: "mpnsTemplate";
  /** The registration body template */
  bodyTemplate: string;
  /** The registration template name */
  templateName?: string;
}

/** Represents a Windows based Azure Notification Hubs registration description */
export interface WindowsRegistrationDescriptionOutput
  extends RegistrationDescriptionOutputParent {
  /** The Windows channel URL */
  channelUri: string;
  platform: "windows";
}

/** Represents a Windows template based Azure Notification Hubs registration description */
export interface WindowsTemplateRegistrationDescriptionOutput
  extends RegistrationDescriptionOutputParent {
  /** The Windows channel URL */
  channelUri: string;
  /** The Windows template headers */
  wnsHeaders?: Record<string, string>;
  platform: "windowsTemplate";
  /** The registration body template */
  bodyTemplate: string;
  /** The registration template name */
  templateName?: string;
}

/** Represents the notification outcome */
export interface NotificationOutcomeOutput {
  /** Successfully delivered notifications outcome count */
  success: number;
  /** Failed delivery notifications outcome count */
  failure: number;
  /** The notification outcome results per device */
  results: Array<RegistrationResultOutput>;
}

/** Represents the registration results for the notification outcome */
export interface RegistrationResultOutput {
  /** The application platform */
  applicationPlatform: string;
  /** The registration push handle */
  pnsHandle: string;
  /** The registration ID */
  registrationId: string;
  /** The outcome result message */
  outcome: string;
}

/** Represents the Azure Notification Hubs job */
export interface NotificationHubJobOutput {
  /** Job ID */
  jobId?: string;
  /** Job output file name */
  outputFileName?: string;
  /** Job failures file name */
  failuresFileName?: string;
  /** Job progress percentage */
  progress?: number;
  /** Job type */
  type:
    | "ExportRegistrations"
    | "ImportCreateRegistrations"
    | "ImportUpdateRegistrations"
    | "ImportDeleteRegistrations"
    | "ImportUpsertRegistrations";
  /** Job status */
  status?: "Started" | "Running" | "Completed" | "Failed";
  /** Job output container URL */
  outputContainerUrl: string;
  /** Job import file URL */
  importFileUrl?: string;
  /** Job input property bag */
  inputProperties?: Record<string, string>;
  /** Job failure reason */
  failure?: string;
  /** Job output property bag */
  outputProperties?: Record<string, string>;
  /** Job created time */
  createdAt?: string;
  /** Job updated time */
  updatedAt?: string;
}

/** Represents an Azure Notification Hubs Installation */
export type InstallationOutput =
  | BrowserInstallationOutput
  | FcmLegacyInstallationOutput;
/** Represents an Azure Notification Hubs registration description */
export type RegistrationDescriptionOutput =
  | AdmRegistrationDescriptionOutput
  | AdmTemplateRegistrationDescriptionOutput
  | AppleRegistrationDescriptionOutput
  | AppleTemplateRegistrationDescriptionOutput
  | BaiduRegistrationDescriptionOutput
  | BaiduTemplateRegistrationDescriptionOutput
  | BrowserRegistrationDescriptionOutput
  | BrowserTemplateRegistrationDescriptionOutput
  | GcmRegistrationDescriptionOutput
  | GcmTemplateRegistrationDescriptionOutput
  | MpnsRegistrationDescriptionOutput
  | MpnsTemplateRegistrationDescriptionOutput
  | WindowsRegistrationDescriptionOutput
  | WindowsTemplateRegistrationDescriptionOutput;
