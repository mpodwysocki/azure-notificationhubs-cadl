// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace NotificationHubs.Models
{
    internal static partial class NotificationHubJobStatusExtensions
    {
        public static string ToSerialString(this NotificationHubJobStatus value) => value switch
        {
            NotificationHubJobStatus.Started => "Started",
            NotificationHubJobStatus.Running => "Running",
            NotificationHubJobStatus.Completed => "Completed",
            NotificationHubJobStatus.Failed => "Failed",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown NotificationHubJobStatus value.")
        };

        public static NotificationHubJobStatus ToNotificationHubJobStatus(this string value)
        {
            if (string.Equals(value, "Started", StringComparison.InvariantCultureIgnoreCase)) return NotificationHubJobStatus.Started;
            if (string.Equals(value, "Running", StringComparison.InvariantCultureIgnoreCase)) return NotificationHubJobStatus.Running;
            if (string.Equals(value, "Completed", StringComparison.InvariantCultureIgnoreCase)) return NotificationHubJobStatus.Completed;
            if (string.Equals(value, "Failed", StringComparison.InvariantCultureIgnoreCase)) return NotificationHubJobStatus.Failed;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown NotificationHubJobStatus value.");
        }
    }
}
