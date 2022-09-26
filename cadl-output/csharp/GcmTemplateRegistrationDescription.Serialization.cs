// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure;
using Azure.Core;

namespace NotificationHubs.Models
{
    public partial class GcmTemplateRegistrationDescription : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("gcmRegistrationId");
            writer.WriteStringValue(GcmRegistrationId);
            writer.WritePropertyName("bodyTemplate");
            writer.WriteStringValue(BodyTemplate);
            if (Optional.IsDefined(TemplateName))
            {
                writer.WritePropertyName("templateName");
                writer.WriteStringValue(TemplateName);
            }
            writer.WriteEndObject();
        }

        internal static GcmTemplateRegistrationDescription DeserializeGcmTemplateRegistrationDescription(JsonElement element)
        {
            string gcmRegistrationId = default;
            string bodyTemplate = default;
            Optional<string> templateName = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("gcmRegistrationId"))
                {
                    gcmRegistrationId = property.Value.GetString();
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
            }
            return new GcmTemplateRegistrationDescription(gcmRegistrationId, bodyTemplate, templateName);
        }

        internal RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this);
            return content;
        }

        internal static GcmTemplateRegistrationDescription FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeGcmTemplateRegistrationDescription(document.RootElement);
        }
    }
}