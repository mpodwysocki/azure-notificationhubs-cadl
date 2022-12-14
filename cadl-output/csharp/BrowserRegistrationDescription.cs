// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core;

namespace NotificationHubs.Models
{
    /// <summary> Represents a Web Push based Azure Notification Hubs registration description. </summary>
    public partial class BrowserRegistrationDescription
    {
        /// <summary> Initializes a new instance of BrowserRegistrationDescription. </summary>
        /// <param name="endpoint"></param>
        /// <param name="auth"></param>
        /// <param name="p256dh"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/>, <paramref name="auth"/> or <paramref name="p256dh"/> is null. </exception>
        public BrowserRegistrationDescription(string endpoint, string auth, string p256dh)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(auth, nameof(auth));
            Argument.AssertNotNull(p256dh, nameof(p256dh));

            Endpoint = endpoint;
            Auth = auth;
            P256dh = p256dh;
        }

        public string Endpoint { get; set; }

        public string Auth { get; set; }

        public string P256dh { get; set; }
    }
}
