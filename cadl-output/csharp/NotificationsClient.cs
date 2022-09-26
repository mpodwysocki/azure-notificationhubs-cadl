// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Microsoft.Azure.NotificationHubs
{
    // Data plane generated client. Azure Notification Hubs message operations
    /// <summary> Azure Notification Hubs message operations. </summary>
    public partial class NotificationsClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly string _namespaceName;
        private readonly string _hubName;
        private readonly string _apiVersion;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of NotificationsClient for mocking. </summary>
        protected NotificationsClient()
        {
        }

        /// <summary> Initializes a new instance of NotificationsClient. </summary>
        /// <param name="namespaceName"> Notification Hubs Namespace. </param>
        /// <param name="hubName"> Notification Hub Name. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="namespaceName"/> or <paramref name="hubName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="namespaceName"/> or <paramref name="hubName"/> is an empty string, and was expected to be non-empty. </exception>
        public NotificationsClient(string namespaceName, string hubName) : this(namespaceName, hubName, new NotificationhubsClientOptions())
        {
        }

        /// <summary> Initializes a new instance of NotificationsClient. </summary>
        /// <param name="namespaceName"> Notification Hubs Namespace. </param>
        /// <param name="hubName"> Notification Hub Name. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="namespaceName"/> or <paramref name="hubName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="namespaceName"/> or <paramref name="hubName"/> is an empty string, and was expected to be non-empty. </exception>
        public NotificationsClient(string namespaceName, string hubName, NotificationhubsClientOptions options)
        {
            Argument.AssertNotNullOrEmpty(namespaceName, nameof(namespaceName));
            Argument.AssertNotNullOrEmpty(hubName, nameof(hubName));
            options ??= new NotificationhubsClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
            _namespaceName = namespaceName;
            _hubName = hubName;
            _apiVersion = options.Version;
        }

        /// <summary> Send a notification using Azure Notification Hubs. </summary>
        /// <param name="test"> Enables test send for debug purposes. </param>
        /// <param name="platform"> The notification target platform. </param>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="direct"> Direct send operation. </param>
        /// <param name="deviceHandle"> The notification target device handle. </param>
        /// <param name="tags"> The notification target tag expression. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="platform"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <example>
        /// This sample shows how to call SendNotificationAsync with required parameters and request content, and how to parse the result.
        /// <code><![CDATA[
        /// var client = new NotificationsClient("<namespaceName>", "<hubName>");
        /// 
        /// var data = "<String>";
        /// 
        /// Response response = await client.SendNotificationAsync(true, "<platform>", RequestContent.Create(data));
        /// 
        /// JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
        /// Console.WriteLine(result.GetProperty("success").ToString());
        /// Console.WriteLine(result.GetProperty("failure").ToString());
        /// Console.WriteLine(result.GetProperty("results")[0].GetProperty("applicationPlatform").ToString());
        /// Console.WriteLine(result.GetProperty("results")[0].GetProperty("pnsHandle").ToString());
        /// Console.WriteLine(result.GetProperty("results")[0].GetProperty("registrationId").ToString());
        /// Console.WriteLine(result.GetProperty("results")[0].GetProperty("outcome").ToString());
        /// ]]></code>
        /// This sample shows how to call SendNotificationAsync with all parameters and request content, and how to parse the result.
        /// <code><![CDATA[
        /// var client = new NotificationsClient("<namespaceName>", "<hubName>");
        /// 
        /// var data = "<String>";
        /// 
        /// Response response = await client.SendNotificationAsync(true, "<platform>", RequestContent.Create(data), true, "<deviceHandle>", "<tags>");
        /// 
        /// JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
        /// Console.WriteLine(result.GetProperty("success").ToString());
        /// Console.WriteLine(result.GetProperty("failure").ToString());
        /// Console.WriteLine(result.GetProperty("results")[0].GetProperty("applicationPlatform").ToString());
        /// Console.WriteLine(result.GetProperty("results")[0].GetProperty("pnsHandle").ToString());
        /// Console.WriteLine(result.GetProperty("results")[0].GetProperty("registrationId").ToString());
        /// Console.WriteLine(result.GetProperty("results")[0].GetProperty("outcome").ToString());
        /// ]]></code>
        /// </example>
        /// <remarks>
        /// Below is the JSON schema for the response payload.
        /// 
        /// Response Body:
        /// 
        /// Schema for <c>NotificationOutcome</c>:
        /// <code>{
        ///   success: number, # Required.
        ///   failure: number, # Required.
        ///   results: [
        ///     {
        ///       applicationPlatform: string, # Required.
        ///       pnsHandle: string, # Required.
        ///       registrationId: string, # Required.
        ///       outcome: string, # Required.
        ///     }
        ///   ], # Required.
        /// }
        /// </code>
        /// 
        /// </remarks>
        public virtual async Task<Response> SendNotificationAsync(bool test, string platform, RequestContent content, bool? direct = null, string deviceHandle = null, string tags = null, RequestContext context = null)
        {
            Argument.AssertNotNull(platform, nameof(platform));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("NotificationsClient.SendNotification");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSendNotificationRequest(test, platform, content, direct, deviceHandle, tags, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Send a notification using Azure Notification Hubs. </summary>
        /// <param name="test"> Enables test send for debug purposes. </param>
        /// <param name="platform"> The notification target platform. </param>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="direct"> Direct send operation. </param>
        /// <param name="deviceHandle"> The notification target device handle. </param>
        /// <param name="tags"> The notification target tag expression. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="platform"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <example>
        /// This sample shows how to call SendNotification with required parameters and request content, and how to parse the result.
        /// <code><![CDATA[
        /// var client = new NotificationsClient("<namespaceName>", "<hubName>");
        /// 
        /// var data = "<String>";
        /// 
        /// Response response = client.SendNotification(true, "<platform>", RequestContent.Create(data));
        /// 
        /// JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
        /// Console.WriteLine(result.GetProperty("success").ToString());
        /// Console.WriteLine(result.GetProperty("failure").ToString());
        /// Console.WriteLine(result.GetProperty("results")[0].GetProperty("applicationPlatform").ToString());
        /// Console.WriteLine(result.GetProperty("results")[0].GetProperty("pnsHandle").ToString());
        /// Console.WriteLine(result.GetProperty("results")[0].GetProperty("registrationId").ToString());
        /// Console.WriteLine(result.GetProperty("results")[0].GetProperty("outcome").ToString());
        /// ]]></code>
        /// This sample shows how to call SendNotification with all parameters and request content, and how to parse the result.
        /// <code><![CDATA[
        /// var client = new NotificationsClient("<namespaceName>", "<hubName>");
        /// 
        /// var data = "<String>";
        /// 
        /// Response response = client.SendNotification(true, "<platform>", RequestContent.Create(data), true, "<deviceHandle>", "<tags>");
        /// 
        /// JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
        /// Console.WriteLine(result.GetProperty("success").ToString());
        /// Console.WriteLine(result.GetProperty("failure").ToString());
        /// Console.WriteLine(result.GetProperty("results")[0].GetProperty("applicationPlatform").ToString());
        /// Console.WriteLine(result.GetProperty("results")[0].GetProperty("pnsHandle").ToString());
        /// Console.WriteLine(result.GetProperty("results")[0].GetProperty("registrationId").ToString());
        /// Console.WriteLine(result.GetProperty("results")[0].GetProperty("outcome").ToString());
        /// ]]></code>
        /// </example>
        /// <remarks>
        /// Below is the JSON schema for the response payload.
        /// 
        /// Response Body:
        /// 
        /// Schema for <c>NotificationOutcome</c>:
        /// <code>{
        ///   success: number, # Required.
        ///   failure: number, # Required.
        ///   results: [
        ///     {
        ///       applicationPlatform: string, # Required.
        ///       pnsHandle: string, # Required.
        ///       registrationId: string, # Required.
        ///       outcome: string, # Required.
        ///     }
        ///   ], # Required.
        /// }
        /// </code>
        /// 
        /// </remarks>
        public virtual Response SendNotification(bool test, string platform, RequestContent content, bool? direct = null, string deviceHandle = null, string tags = null, RequestContext context = null)
        {
            Argument.AssertNotNull(platform, nameof(platform));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("NotificationsClient.SendNotification");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSendNotificationRequest(test, platform, content, direct, deviceHandle, tags, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateSendNotificationRequest(bool test, string platform, RequestContent content, bool? direct, string deviceHandle, string tags, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier201);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw("https://", false);
            uri.AppendRaw(_namespaceName, true);
            uri.AppendRaw(".servicebus.windows.net/", false);
            uri.AppendRaw(_hubName, true);
            uri.AppendPath("/messages", false);
            uri.AppendQuery("test", test, true);
            if (direct != null)
            {
                uri.AppendQuery("direct", direct.Value, true);
            }
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("ServiceBusNotification-Format", platform);
            if (deviceHandle != null)
            {
                request.Headers.Add("ServiceBusNotification-DeviceHandle", deviceHandle);
            }
            if (tags != null)
            {
                request.Headers.Add("ServiceBusNotification-Tags", tags);
            }
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        private static ResponseClassifier _responseClassifier201;
        private static ResponseClassifier ResponseClassifier201 => _responseClassifier201 ??= new StatusCodeClassifier(stackalloc ushort[] { 201 });
    }
}