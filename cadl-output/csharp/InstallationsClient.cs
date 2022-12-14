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
    // Data plane generated client. Azure Notification Hubs registration installation operations
    /// <summary> Azure Notification Hubs registration installation operations. </summary>
    public partial class InstallationsClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly string _namespaceName;
        private readonly string _hubName;
        private readonly string _apiVersion;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of InstallationsClient for mocking. </summary>
        protected InstallationsClient()
        {
        }

        /// <summary> Initializes a new instance of InstallationsClient. </summary>
        /// <param name="namespaceName"> Notification Hubs Namespace. </param>
        /// <param name="hubName"> Notification Hub Name. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="namespaceName"/> or <paramref name="hubName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="namespaceName"/> or <paramref name="hubName"/> is an empty string, and was expected to be non-empty. </exception>
        public InstallationsClient(string namespaceName, string hubName) : this(namespaceName, hubName, new NotificationhubsClientOptions())
        {
        }

        /// <summary> Initializes a new instance of InstallationsClient. </summary>
        /// <param name="namespaceName"> Notification Hubs Namespace. </param>
        /// <param name="hubName"> Notification Hub Name. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="namespaceName"/> or <paramref name="hubName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="namespaceName"/> or <paramref name="hubName"/> is an empty string, and was expected to be non-empty. </exception>
        public InstallationsClient(string namespaceName, string hubName, NotificationhubsClientOptions options)
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

        /// <summary> Get an Azure Notification Hubs installation. </summary>
        /// <param name="installationId"> The installation ID. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="installationId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="installationId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <example>
        /// This sample shows how to call GetAsync with required parameters and parse the result.
        /// <code><![CDATA[
        /// var client = new InstallationsClient("<namespaceName>", "<hubName>");
        /// 
        /// Response response = await client.GetAsync("<installationId>");
        /// 
        /// JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
        /// Console.WriteLine(result.GetProperty("installationId").ToString());
        /// Console.WriteLine(result.GetProperty("userId").ToString());
        /// Console.WriteLine(result.GetProperty("expirationTime").ToString());
        /// Console.WriteLine(result.GetProperty("lastUpdate").ToString());
        /// Console.WriteLine(result.GetProperty("tags")[0].ToString());
        /// Console.WriteLine(result.GetProperty("templates").GetProperty("<test>").ToString());
        /// ]]></code>
        /// </example>
        /// <remarks>
        /// Below is the JSON schema for the response payload.
        /// 
        /// Response Body:
        /// 
        /// Schema for <c>Installation</c>:
        /// <code>{
        ///   installationId: string, # Required.
        ///   userId: string, # Optional.
        ///   expirationTime: string, # Optional.
        ///   lastUpdate: string, # Optional.
        ///   tags: [string], # Required.
        ///   templates: Dictionary&lt;string, string&gt;, # Required.
        /// }
        /// </code>
        /// 
        /// </remarks>
        public virtual async Task<Response> GetAsync(string installationId, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(installationId, nameof(installationId));

            using var scope = ClientDiagnostics.CreateScope("InstallationsClient.Get");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetRequest(installationId, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get an Azure Notification Hubs installation. </summary>
        /// <param name="installationId"> The installation ID. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="installationId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="installationId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        /// <example>
        /// This sample shows how to call Get with required parameters and parse the result.
        /// <code><![CDATA[
        /// var client = new InstallationsClient("<namespaceName>", "<hubName>");
        /// 
        /// Response response = client.Get("<installationId>");
        /// 
        /// JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
        /// Console.WriteLine(result.GetProperty("installationId").ToString());
        /// Console.WriteLine(result.GetProperty("userId").ToString());
        /// Console.WriteLine(result.GetProperty("expirationTime").ToString());
        /// Console.WriteLine(result.GetProperty("lastUpdate").ToString());
        /// Console.WriteLine(result.GetProperty("tags")[0].ToString());
        /// Console.WriteLine(result.GetProperty("templates").GetProperty("<test>").ToString());
        /// ]]></code>
        /// </example>
        /// <remarks>
        /// Below is the JSON schema for the response payload.
        /// 
        /// Response Body:
        /// 
        /// Schema for <c>Installation</c>:
        /// <code>{
        ///   installationId: string, # Required.
        ///   userId: string, # Optional.
        ///   expirationTime: string, # Optional.
        ///   lastUpdate: string, # Optional.
        ///   tags: [string], # Required.
        ///   templates: Dictionary&lt;string, string&gt;, # Required.
        /// }
        /// </code>
        /// 
        /// </remarks>
        public virtual Response Get(string installationId, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(installationId, nameof(installationId));

            using var scope = ClientDiagnostics.CreateScope("InstallationsClient.Get");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetRequest(installationId, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Delete an Azure Notification Hubs installation. </summary>
        /// <param name="installationId"> The installation ID. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="installationId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="installationId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <example>
        /// This sample shows how to call DeleteAsync with required parameters.
        /// <code><![CDATA[
        /// var client = new InstallationsClient("<namespaceName>", "<hubName>");
        /// 
        /// Response response = await client.DeleteAsync("<installationId>");
        /// Console.WriteLine(response.Status);
        /// ]]></code>
        /// </example>
        public virtual async Task<Response> DeleteAsync(string installationId, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(installationId, nameof(installationId));

            using var scope = ClientDiagnostics.CreateScope("InstallationsClient.Delete");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDeleteRequest(installationId, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Delete an Azure Notification Hubs installation. </summary>
        /// <param name="installationId"> The installation ID. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="installationId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="installationId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <example>
        /// This sample shows how to call Delete with required parameters.
        /// <code><![CDATA[
        /// var client = new InstallationsClient("<namespaceName>", "<hubName>");
        /// 
        /// Response response = client.Delete("<installationId>");
        /// Console.WriteLine(response.Status);
        /// ]]></code>
        /// </example>
        public virtual Response Delete(string installationId, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(installationId, nameof(installationId));

            using var scope = ClientDiagnostics.CreateScope("InstallationsClient.Delete");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDeleteRequest(installationId, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Create or update an Azure Notification Hubs installation. </summary>
        /// <param name="installationId"> The installation ID. </param>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="installationId"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="installationId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <example>
        /// This sample shows how to call CreateOrUpdateAsync with required parameters and request content.
        /// <code><![CDATA[
        /// var client = new InstallationsClient("<namespaceName>", "<hubName>");
        /// 
        /// var data = new {
        ///     installationId = "<installationId>",
        ///     tags = new[] {
        ///         "<String>"
        ///     },
        ///     templates = new {
        ///         key = "<String>",
        ///     },
        /// };
        /// 
        /// Response response = await client.CreateOrUpdateAsync("<installationId>", RequestContent.Create(data));
        /// Console.WriteLine(response.Status);
        /// ]]></code>
        /// This sample shows how to call CreateOrUpdateAsync with all parameters and request content.
        /// <code><![CDATA[
        /// var client = new InstallationsClient("<namespaceName>", "<hubName>");
        /// 
        /// var data = new {
        ///     installationId = "<installationId>",
        ///     userId = "<userId>",
        ///     tags = new[] {
        ///         "<String>"
        ///     },
        ///     templates = new {
        ///         key = "<String>",
        ///     },
        /// };
        /// 
        /// Response response = await client.CreateOrUpdateAsync("<installationId>", RequestContent.Create(data));
        /// Console.WriteLine(response.Status);
        /// ]]></code>
        /// </example>
        /// <remarks>
        /// Below is the JSON schema for the request payload.
        /// 
        /// Request Body:
        /// 
        /// Schema for <c>Installation</c>:
        /// <code>{
        ///   installationId: string, # Required.
        ///   userId: string, # Optional.
        ///   expirationTime: string, # Optional.
        ///   lastUpdate: string, # Optional.
        ///   tags: [string], # Required.
        ///   templates: Dictionary&lt;string, string&gt;, # Required.
        /// }
        /// </code>
        /// 
        /// </remarks>
        public virtual async Task<Response> CreateOrUpdateAsync(string installationId, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(installationId, nameof(installationId));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("InstallationsClient.CreateOrUpdate");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCreateOrUpdateRequest(installationId, content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Create or update an Azure Notification Hubs installation. </summary>
        /// <param name="installationId"> The installation ID. </param>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="installationId"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="installationId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <example>
        /// This sample shows how to call CreateOrUpdate with required parameters and request content.
        /// <code><![CDATA[
        /// var client = new InstallationsClient("<namespaceName>", "<hubName>");
        /// 
        /// var data = new {
        ///     installationId = "<installationId>",
        ///     tags = new[] {
        ///         "<String>"
        ///     },
        ///     templates = new {
        ///         key = "<String>",
        ///     },
        /// };
        /// 
        /// Response response = client.CreateOrUpdate("<installationId>", RequestContent.Create(data));
        /// Console.WriteLine(response.Status);
        /// ]]></code>
        /// This sample shows how to call CreateOrUpdate with all parameters and request content.
        /// <code><![CDATA[
        /// var client = new InstallationsClient("<namespaceName>", "<hubName>");
        /// 
        /// var data = new {
        ///     installationId = "<installationId>",
        ///     userId = "<userId>",
        ///     tags = new[] {
        ///         "<String>"
        ///     },
        ///     templates = new {
        ///         key = "<String>",
        ///     },
        /// };
        /// 
        /// Response response = client.CreateOrUpdate("<installationId>", RequestContent.Create(data));
        /// Console.WriteLine(response.Status);
        /// ]]></code>
        /// </example>
        /// <remarks>
        /// Below is the JSON schema for the request payload.
        /// 
        /// Request Body:
        /// 
        /// Schema for <c>Installation</c>:
        /// <code>{
        ///   installationId: string, # Required.
        ///   userId: string, # Optional.
        ///   expirationTime: string, # Optional.
        ///   lastUpdate: string, # Optional.
        ///   tags: [string], # Required.
        ///   templates: Dictionary&lt;string, string&gt;, # Required.
        /// }
        /// </code>
        /// 
        /// </remarks>
        public virtual Response CreateOrUpdate(string installationId, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(installationId, nameof(installationId));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("InstallationsClient.CreateOrUpdate");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCreateOrUpdateRequest(installationId, content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Update an Azure Notification Hubs installation using JSON Patch semantics. </summary>
        /// <param name="installationId"> The installation ID. </param>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="installationId"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="installationId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <example>
        /// This sample shows how to call UpdateAsync with required parameters and request content.
        /// <code><![CDATA[
        /// var client = new InstallationsClient("<namespaceName>", "<hubName>");
        /// 
        /// var data = new[] {
        ///     new {
        ///         op = "add",
        ///         path = "<path>",
        ///         value = "<value>",
        ///     }
        /// };
        /// 
        /// Response response = await client.UpdateAsync("<installationId>", RequestContent.Create(data));
        /// Console.WriteLine(response.Status);
        /// ]]></code>
        /// </example>
        /// <remarks>
        /// Below is the JSON schema for the request payload.
        /// 
        /// Request Body:
        /// 
        /// Schema for <c>JsonPatch</c>:
        /// <code>{
        ///   op: &quot;add&quot; | &quot;remove&quot; | &quot;replace&quot;, # Required.
        ///   path: string, # Required.
        ///   value: string, # Optional.
        /// }
        /// </code>
        /// 
        /// </remarks>
        public virtual async Task<Response> UpdateAsync(string installationId, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(installationId, nameof(installationId));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("InstallationsClient.Update");
            scope.Start();
            try
            {
                using HttpMessage message = CreateUpdateRequest(installationId, content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Update an Azure Notification Hubs installation using JSON Patch semantics. </summary>
        /// <param name="installationId"> The installation ID. </param>
        /// <param name="content"> The content to send as the body of the request. Details of the request body schema are in the Remarks section below. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="installationId"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="installationId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <example>
        /// This sample shows how to call Update with required parameters and request content.
        /// <code><![CDATA[
        /// var client = new InstallationsClient("<namespaceName>", "<hubName>");
        /// 
        /// var data = new[] {
        ///     new {
        ///         op = "add",
        ///         path = "<path>",
        ///         value = "<value>",
        ///     }
        /// };
        /// 
        /// Response response = client.Update("<installationId>", RequestContent.Create(data));
        /// Console.WriteLine(response.Status);
        /// ]]></code>
        /// </example>
        /// <remarks>
        /// Below is the JSON schema for the request payload.
        /// 
        /// Request Body:
        /// 
        /// Schema for <c>JsonPatch</c>:
        /// <code>{
        ///   op: &quot;add&quot; | &quot;remove&quot; | &quot;replace&quot;, # Required.
        ///   path: string, # Required.
        ///   value: string, # Optional.
        /// }
        /// </code>
        /// 
        /// </remarks>
        public virtual Response Update(string installationId, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(installationId, nameof(installationId));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("InstallationsClient.Update");
            scope.Start();
            try
            {
                using HttpMessage message = CreateUpdateRequest(installationId, content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateGetRequest(string installationId, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw("https://", false);
            uri.AppendRaw(_namespaceName, true);
            uri.AppendRaw(".servicebus.windows.net/", false);
            uri.AppendRaw(_hubName, true);
            uri.AppendPath("/installations/", false);
            uri.AppendPath(installationId, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateDeleteRequest(string installationId, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier204);
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw("https://", false);
            uri.AppendRaw(_namespaceName, true);
            uri.AppendRaw(".servicebus.windows.net/", false);
            uri.AppendRaw(_hubName, true);
            uri.AppendPath("/installations/", false);
            uri.AppendPath(installationId, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateCreateOrUpdateRequest(string installationId, RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw("https://", false);
            uri.AppendRaw(_namespaceName, true);
            uri.AppendRaw(".servicebus.windows.net/", false);
            uri.AppendRaw(_hubName, true);
            uri.AppendPath("/installations/", false);
            uri.AppendPath(installationId, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateUpdateRequest(string installationId, RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Patch;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw("https://", false);
            uri.AppendRaw(_namespaceName, true);
            uri.AppendRaw(".servicebus.windows.net/", false);
            uri.AppendRaw(_hubName, true);
            uri.AppendPath("/installations/", false);
            uri.AppendPath(installationId, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        private static ResponseClassifier _responseClassifier200;
        private static ResponseClassifier ResponseClassifier200 => _responseClassifier200 ??= new StatusCodeClassifier(stackalloc ushort[] { 200 });
        private static ResponseClassifier _responseClassifier204;
        private static ResponseClassifier ResponseClassifier204 => _responseClassifier204 ??= new StatusCodeClassifier(stackalloc ushort[] { 204 });
    }
}
