// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core;

namespace NotificationHubs.Models
{
    /// <summary> Represents a Firebase Legacy based Azure Notification Hubs registration description. </summary>
    public partial class GcmRegistrationDescription
    {
        /// <summary> Initializes a new instance of GcmRegistrationDescription. </summary>
        /// <param name="gcmRegistrationId"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="gcmRegistrationId"/> is null. </exception>
        public GcmRegistrationDescription(string gcmRegistrationId)
        {
            Argument.AssertNotNull(gcmRegistrationId, nameof(gcmRegistrationId));

            GcmRegistrationId = gcmRegistrationId;
        }

        public string GcmRegistrationId { get; set; }
    }
}