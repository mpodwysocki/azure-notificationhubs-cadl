// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core;

namespace NotificationHubs.Models
{
    /// <summary> Represents a Firebase Legacy template based Azure Notification Hubs registration description. </summary>
    public partial class GcmTemplateRegistrationDescription
    {
        /// <summary> Initializes a new instance of GcmTemplateRegistrationDescription. </summary>
        /// <param name="gcmRegistrationId"></param>
        /// <param name="bodyTemplate"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="gcmRegistrationId"/> or <paramref name="bodyTemplate"/> is null. </exception>
        public GcmTemplateRegistrationDescription(string gcmRegistrationId, string bodyTemplate)
        {
            Argument.AssertNotNull(gcmRegistrationId, nameof(gcmRegistrationId));
            Argument.AssertNotNull(bodyTemplate, nameof(bodyTemplate));

            GcmRegistrationId = gcmRegistrationId;
            BodyTemplate = bodyTemplate;
        }
        /// <summary> Initializes a new instance of GcmTemplateRegistrationDescription. </summary>
        /// <param name="gcmRegistrationId"></param>
        /// <param name="bodyTemplate"></param>
        /// <param name="templateName"></param>
        internal GcmTemplateRegistrationDescription(string gcmRegistrationId, string bodyTemplate, string templateName)
        {
            GcmRegistrationId = gcmRegistrationId;
            BodyTemplate = bodyTemplate;
            TemplateName = templateName;
        }

        public string GcmRegistrationId { get; set; }

        public string BodyTemplate { get; set; }

        public string TemplateName { get; set; }
    }
}