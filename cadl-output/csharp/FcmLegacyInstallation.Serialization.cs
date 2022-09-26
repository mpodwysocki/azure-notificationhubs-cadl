// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure;
using Azure.Core;

namespace NotificationHubs.Models
{
    public partial class FcmLegacyInstallation : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WriteEndObject();
        }

        internal static FcmLegacyInstallation DeserializeFcmLegacyInstallation(JsonElement element)
        {
            foreach (var property in element.EnumerateObject())
            {
            }
            return new FcmLegacyInstallation();
        }

        internal RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this);
            return content;
        }

        internal static FcmLegacyInstallation FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeFcmLegacyInstallation(document.RootElement);
        }
    }
}
