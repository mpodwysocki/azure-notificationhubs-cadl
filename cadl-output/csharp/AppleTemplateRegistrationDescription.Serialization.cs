// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;

namespace NotificationHubs.Models
{
    public partial class AppleTemplateRegistrationDescription : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("deviceToken");
            writer.WriteStringValue(DeviceToken);
            writer.WritePropertyName("bodyTemplate");
            writer.WriteStringValue(BodyTemplate);
            if (Optional.IsDefined(TemplateName))
            {
                writer.WritePropertyName("templateName");
                writer.WriteStringValue(TemplateName);
            }
            if (Optional.IsCollectionDefined(ApnsHeaders))
            {
                writer.WritePropertyName("apnsHeaders");
                writer.WriteStartObject();
                foreach (var item in ApnsHeaders)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteStringValue(item.Value);
                }
                writer.WriteEndObject();
            }
            if (Optional.IsDefined(Priority))
            {
                if (Priority != null)
                {
                    writer.WritePropertyName("priority");
                    writer.WriteNumberValue(Priority.Value);
                }
                else
                {
                    writer.WriteNull("priority");
                }
            }
            writer.WriteEndObject();
        }

        internal static AppleTemplateRegistrationDescription DeserializeAppleTemplateRegistrationDescription(JsonElement element)
        {
            string deviceToken = default;
            string bodyTemplate = default;
            Optional<string> templateName = default;
            Optional<IDictionary<string, string>> apnsHeaders = default;
            Optional<int?> priority = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("deviceToken"))
                {
                    deviceToken = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("bodyTemplate"))
                {
                    bodyTemplate = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("templateName"))
                {
                    templateName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("apnsHeaders"))
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
                    apnsHeaders = dictionary;
                    continue;
                }
                if (property.NameEquals("priority"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        priority = null;
                        continue;
                    }
                    priority = property.Value.GetInt32();
                    continue;
                }
            }
            return new AppleTemplateRegistrationDescription(deviceToken, bodyTemplate, templateName, Optional.ToDictionary(apnsHeaders), Optional.ToNullable(priority));
        }

        internal RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this);
            return content;
        }

        internal static AppleTemplateRegistrationDescription FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeAppleTemplateRegistrationDescription(document.RootElement);
        }
    }
}
