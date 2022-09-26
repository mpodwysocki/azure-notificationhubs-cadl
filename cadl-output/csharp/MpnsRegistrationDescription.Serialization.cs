// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure;
using Azure.Core;

namespace NotificationHubs.Models
{
    public partial class MpnsRegistrationDescription : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("channelUri");
            writer.WriteStringValue(ChannelUri);
            writer.WriteEndObject();
        }

        internal static MpnsRegistrationDescription DeserializeMpnsRegistrationDescription(JsonElement element)
        {
            string channelUri = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("channelUri"))
                {
                    channelUri = property.Value.GetString();
                    continue;
                }
            }
            return new MpnsRegistrationDescription(channelUri);
        }

        internal RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this);
            return content;
        }

        internal static MpnsRegistrationDescription FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeMpnsRegistrationDescription(document.RootElement);
        }
    }
}
