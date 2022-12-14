// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace NotificationHubs.Models
{
    internal static partial class JsonPatchOperationExtensions
    {
        public static string ToSerialString(this JsonPatchOperation value) => value switch
        {
            JsonPatchOperation.Add => "add",
            JsonPatchOperation.Remove => "remove",
            JsonPatchOperation.Replace => "replace",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown JsonPatchOperation value.")
        };

        public static JsonPatchOperation ToJsonPatchOperation(this string value)
        {
            if (string.Equals(value, "add", StringComparison.InvariantCultureIgnoreCase)) return JsonPatchOperation.Add;
            if (string.Equals(value, "remove", StringComparison.InvariantCultureIgnoreCase)) return JsonPatchOperation.Remove;
            if (string.Equals(value, "replace", StringComparison.InvariantCultureIgnoreCase)) return JsonPatchOperation.Replace;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown JsonPatchOperation value.");
        }
    }
}
