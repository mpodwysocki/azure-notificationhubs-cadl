// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;

namespace NotificationHubs.Models
{
    public partial class RegistrationDescription : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(RegistrationId))
            {
                writer.WritePropertyName("registrationId");
                writer.WriteStringValue(RegistrationId);
            }
            if (Optional.IsDefined(Tags))
            {
                writer.WritePropertyName("tags");
                writer.WriteStringValue(Tags);
            }
            if (Optional.IsDefined(Etag))
            {
                writer.WritePropertyName("etag");
                writer.WriteStringValue(Etag);
            }
            if (Optional.IsCollectionDefined(PushVariables))
            {
                writer.WritePropertyName("pushVariables");
                writer.WriteStartObject();
                foreach (var item in PushVariables)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteStringValue(item.Value);
                }
                writer.WriteEndObject();
            }
            if (Optional.IsDefined(ExpirationTime))
            {
                if (ExpirationTime != null)
                {
                    writer.WritePropertyName("expirationTime");
                    writer.WriteStringValue(ExpirationTime.Value, "O");
                }
                else
                {
                    writer.WriteNull("expirationTime");
                }
            }
            writer.WriteEndObject();
        }

        internal static RegistrationDescription DeserializeRegistrationDescription(JsonElement element)
        {
            Optional<string> registrationId = default;
            Optional<string> tags = default;
            Optional<string> etag = default;
            Optional<IDictionary<string, string>> pushVariables = default;
            Optional<DateTimeOffset?> expirationTime = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("registrationId"))
                {
                    registrationId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("tags"))
                {
                    tags = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("etag"))
                {
                    etag = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("pushVariables"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, property0.Value.GetString());
                    }
                    pushVariables = dictionary;
                    continue;
                }
                if (property.NameEquals("expirationTime"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        expirationTime = null;
                        continue;
                    }
                    expirationTime = property.Value.GetDateTimeOffset("O");
                    continue;
                }
            }
            return new RegistrationDescription(registrationId, tags, etag, Optional.ToDictionary(pushVariables), Optional.ToNullable(expirationTime));
        }

        internal RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this);
            return content;
        }

        internal static RegistrationDescription FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeRegistrationDescription(document.RootElement);
        }
    }
}
