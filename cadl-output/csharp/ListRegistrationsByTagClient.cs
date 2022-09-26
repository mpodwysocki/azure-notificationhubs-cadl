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
    // Data plane generated client. Azure Notification Hubs tags search operations
    /// <summary> Azure Notification Hubs tags search operations. </summary>
    public partial class ListRegistrationsByTagClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly string _namespaceName;
        private readonly string _hubName;
        private readonly string _apiVersion;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of ListRegistrationsByTagClient for mocking. </summary>
        protected ListRegistrationsByTagClient()
        {
        }

        /// <summary> Initializes a new instance of ListRegistrationsByTagClient. </summary>
        /// <param name="namespaceName"> Notification Hubs Namespace. </param>
        /// <param name="hubName"> Notification Hub Name. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="namespaceName"/> or <paramref name="hubName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="namespaceName"/> or <paramref name="hubName"/> is an empty string, and was expected to be non-empty. </exception>
        public ListRegistrationsByTagClient(string namespaceName, string hubName) : this(namespaceName, hubName, new NotificationhubsClientOptions())
        {
        }

        /// <summary> Initializes a new instance of ListRegistrationsByTagClient. </summary>
        /// <param name="namespaceName"> Notification Hubs Namespace. </param>
        /// <param name="hubName"> Notification Hub Name. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="namespaceName"/> or <paramref name="hubName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="namespaceName"/> or <paramref name="hubName"/> is an empty string, and was expected to be non-empty. </exception>
        public ListRegistrationsByTagClient(string namespaceName, string hubName, NotificationhubsClientOptions options)
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

        /// <summary> List all Azure Notification Hubs registrations description matching the given tag. </summary>
        /// <param name="tag"> The tag name to search. </param>
        /// <param name="top"> The limit to the number of records to retrieve. </param>
        /// <param name="continuationToken"> The continuation token for more results. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tag"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="tag"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <example>
        /// This sample shows how to call ListAsync with required parameters and parse the result.
        /// <code><![CDATA[
        /// var client = new ListRegistrationsByTagClient("<namespaceName>", "<hubName>");
        /// 
        /// Response response = await client.ListAsync("<tag>");
        /// 
        /// JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
        /// Console.WriteLine(result[0].ToString());
        /// ]]></code>
        /// This sample shows how to call ListAsync with all parameters, and how to parse the result.
        /// <code><![CDATA[
        /// var client = new ListRegistrationsByTagClient("<namespaceName>", "<hubName>");
        /// 
        /// Response response = await client.ListAsync("<tag>", "<top>", "<continuationToken>");
        /// 
        /// JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
        /// Console.WriteLine(result[0].GetProperty("registrationId").ToString());
        /// Console.WriteLine(result[0].GetProperty("tags").ToString());
        /// Console.WriteLine(result[0].GetProperty("etag").ToString());
        /// Console.WriteLine(result[0].GetProperty("pushVariables").GetProperty("<test>").ToString());
        /// Console.WriteLine(result[0].GetProperty("expirationTime").ToString());
        /// ]]></code>
        /// </example>
        /// <remarks>
        /// Below is the JSON schema for the response payload.
        /// 
        /// Response Body:
        /// 
        /// Schema for <c>RegistrationDescription</c>:
        /// <code>{
        ///   registrationId: string, # Optional.
        ///   tags: string, # Optional.
        ///   etag: string, # Optional.
        ///   pushVariables: Dictionary&lt;string, string&gt;, # Optional.
        ///   expirationTime: string (date &amp; time), # Optional.
        /// }
        /// </code>
        /// 
        /// </remarks>
        public virtual async Task<Response> ListAsync(string tag, string top = null, string continuationToken = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(tag, nameof(tag));

            using var scope = ClientDiagnostics.CreateScope("ListRegistrationsByTagClient.List");
            scope.Start();
            try
            {
                using HttpMessage message = CreateListRequest(tag, top, continuationToken, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> List all Azure Notification Hubs registrations description matching the given tag. </summary>
        /// <param name="tag"> The tag name to search. </param>
        /// <param name="top"> The limit to the number of records to retrieve. </param>
        /// <param name="continuationToken"> The continuation token for more results. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tag"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="tag"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <example>
        /// This sample shows how to call List with required parameters and parse the result.
        /// <code><![CDATA[
        /// var client = new ListRegistrationsByTagClient("<namespaceName>", "<hubName>");
        /// 
        /// Response response = client.List("<tag>");
        /// 
        /// JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
        /// Console.WriteLine(result[0].ToString());
        /// ]]></code>
        /// This sample shows how to call List with all parameters, and how to parse the result.
        /// <code><![CDATA[
        /// var client = new ListRegistrationsByTagClient("<namespaceName>", "<hubName>");
        /// 
        /// Response response = client.List("<tag>", "<top>", "<continuationToken>");
        /// 
        /// JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
        /// Console.WriteLine(result[0].GetProperty("registrationId").ToString());
        /// Console.WriteLine(result[0].GetProperty("tags").ToString());
        /// Console.WriteLine(result[0].GetProperty("etag").ToString());
        /// Console.WriteLine(result[0].GetProperty("pushVariables").GetProperty("<test>").ToString());
        /// Console.WriteLine(result[0].GetProperty("expirationTime").ToString());
        /// ]]></code>
        /// </example>
        /// <remarks>
        /// Below is the JSON schema for the response payload.
        /// 
        /// Response Body:
        /// 
        /// Schema for <c>RegistrationDescription</c>:
        /// <code>{
        ///   registrationId: string, # Optional.
        ///   tags: string, # Optional.
        ///   etag: string, # Optional.
        ///   pushVariables: Dictionary&lt;string, string&gt;, # Optional.
        ///   expirationTime: string (date &amp; time), # Optional.
        /// }
        /// </code>
        /// 
        /// </remarks>
        public virtual Response List(string tag, string top = null, string continuationToken = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(tag, nameof(tag));

            using var scope = ClientDiagnostics.CreateScope("ListRegistrationsByTagClient.List");
            scope.Start();
            try
            {
                using HttpMessage message = CreateListRequest(tag, top, continuationToken, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateListRequest(string tag, string top, string continuationToken, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw("https://", false);
            uri.AppendRaw(_namespaceName, true);
            uri.AppendRaw(".servicebus.windows.net/", false);
            uri.AppendRaw(_hubName, true);
            uri.AppendPath("/tags/", false);
            uri.AppendPath(tag, true);
            uri.AppendPath("/registrations", false);
            if (top != null)
            {
                uri.AppendQuery("$top", top, true);
            }
            if (continuationToken != null)
            {
                uri.AppendQuery("continuationToken", continuationToken, true);
            }
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        private static ResponseClassifier _responseClassifier200;
        private static ResponseClassifier ResponseClassifier200 => _responseClassifier200 ??= new StatusCodeClassifier(stackalloc ushort[] { 200 });
    }
}
