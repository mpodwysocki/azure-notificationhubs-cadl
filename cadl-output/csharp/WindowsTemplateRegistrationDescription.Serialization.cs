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
    public partial class WindowsTemplateRegistrationDescription : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("channelUri");
            writer.WriteStringValue(ChannelUri);
            writer.WritePropertyName("bodyTemplate");
            writer.WriteStringValue(BodyTemplate);
            if (Optional.IsDefined(TemplateName))
            {
                writer.WritePropertyName("templateName");
                writer.WriteStringValue(TemplateName);
            }
            if (Optional.IsCollectionDefined(WnsHeaders))
            {
                writer.WritePropertyName("wnsHeaders");
                writer.WriteStartObject();
                foreach (var item in WnsHeaders)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteStringValue(item.Value);
                }
                writer.WriteEndObject();
            }
            writer.WriteEndObject();
        }

        internal static WindowsTemplateRegistrationDescription DeserializeWindowsTemplateRegistrationDescription(JsonElement element)
        {
            string channelUri = default;
            string bodyTemplate = default;
            Optional<string> templateName = default;
            Optional<IDictionary<string, string>> wnsHeaders = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("channelUri"))
                {
                    channelUri = property.Value.GetString();
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
                if (property.NameEquals("wnsHeaders"))
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
                    wnsHeaders = dictionary;
                    continue;
                }
            }
            return new WindowsTemplateRegistrationDescription(channelUri, bodyTemplate, templateName, Optional.ToDictionary(wnsHeaders));
        }

        internal RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this);
            return content;
        }

        internal static WindowsTemplateRegistrationDescription FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeWindowsTemplateRegistrationDescription(document.RootElement);
        }
    }
}
