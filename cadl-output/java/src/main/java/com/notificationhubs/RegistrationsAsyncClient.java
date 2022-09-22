// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// Code generated by Microsoft (R) AutoRest Code Generator.

package com.notificationhubs;

import com.azure.core.annotation.Generated;
import com.azure.core.annotation.ReturnType;
import com.azure.core.annotation.ServiceClient;
import com.azure.core.annotation.ServiceMethod;
import com.azure.core.exception.ClientAuthenticationException;
import com.azure.core.exception.HttpResponseException;
import com.azure.core.exception.ResourceModifiedException;
import com.azure.core.exception.ResourceNotFoundException;
import com.azure.core.http.rest.RequestOptions;
import com.azure.core.http.rest.Response;
import com.azure.core.util.BinaryData;
import com.notificationhubs.implementation.RegistrationsImpl;
import reactor.core.publisher.Mono;

/** Initializes a new instance of the asynchronous AzureNotificationHubsServiceClient type. */
@ServiceClient(builder = RegistrationsClientBuilder.class, isAsync = true)
public final class RegistrationsAsyncClient {
    @Generated private final RegistrationsImpl serviceClient;

    /**
     * Initializes an instance of RegistrationsAsyncClient class.
     *
     * @param serviceClient the service client implementation.
     */
    @Generated
    RegistrationsAsyncClient(RegistrationsImpl serviceClient) {
        this.serviceClient = serviceClient;
    }

    /**
     * Create an Azure Notification Hubs registration description.
     *
     * <p><strong>Request Body Schema</strong>
     *
     * <pre>{@code
     * {
     *     registrationId: String (Optional)
     *     tags: String (Optional)
     *     etag: String (Optional)
     *     pushVariables (Optional): {
     *         String: String (Optional)
     *     }
     *     expirationTime: String (Optional)
     * }
     * }</pre>
     *
     * <p><strong>Response Body Schema</strong>
     *
     * <pre>{@code
     * {
     *     registrationId: String (Optional)
     *     tags: String (Optional)
     *     etag: String (Optional)
     *     pushVariables (Optional): {
     *         String: String (Optional)
     *     }
     *     expirationTime: String (Optional)
     * }
     * }</pre>
     *
     * @param body The registration description.
     * @param requestOptions The options to configure the HTTP request before HTTP client sends it.
     * @throws HttpResponseException thrown if the request is rejected by server.
     * @throws ClientAuthenticationException thrown if the request is rejected by server on status code 401.
     * @throws ResourceNotFoundException thrown if the request is rejected by server on status code 404.
     * @throws ResourceModifiedException thrown if the request is rejected by server on status code 409.
     * @return represents an Azure Notification Hubs registration description along with {@link Response} on successful
     *     completion of {@link Mono}.
     */
    @Generated
    @ServiceMethod(returns = ReturnType.SINGLE)
    public Mono<Response<BinaryData>> createWithResponse(BinaryData body, RequestOptions requestOptions) {
        return this.serviceClient.createWithResponseAsync(body, requestOptions);
    }

    /**
     * Create or update an Azure Notification Hubs registration description.
     *
     * <p><strong>Header Parameters</strong>
     *
     * <table border="1">
     *     <caption>Header Parameters</caption>
     *     <tr><th>Name</th><th>Type</th><th>Required</th><th>Description</th></tr>
     *     <tr><td>If-Match</td><td>String</td><td>No</td><td>The If-Match HTTP header</td></tr>
     * </table>
     *
     * You can add these to a request with {@link RequestOptions#addHeader}
     *
     * <p><strong>Request Body Schema</strong>
     *
     * <pre>{@code
     * {
     *     registrationId: String (Optional)
     *     tags: String (Optional)
     *     etag: String (Optional)
     *     pushVariables (Optional): {
     *         String: String (Optional)
     *     }
     *     expirationTime: String (Optional)
     * }
     * }</pre>
     *
     * <p><strong>Response Body Schema</strong>
     *
     * <pre>{@code
     * {
     *     registrationId: String (Optional)
     *     tags: String (Optional)
     *     etag: String (Optional)
     *     pushVariables (Optional): {
     *         String: String (Optional)
     *     }
     *     expirationTime: String (Optional)
     * }
     * }</pre>
     *
     * @param registrationId The registration ID.
     * @param body The registration description.
     * @param requestOptions The options to configure the HTTP request before HTTP client sends it.
     * @throws HttpResponseException thrown if the request is rejected by server.
     * @throws ClientAuthenticationException thrown if the request is rejected by server on status code 401.
     * @throws ResourceNotFoundException thrown if the request is rejected by server on status code 404.
     * @throws ResourceModifiedException thrown if the request is rejected by server on status code 409.
     * @return represents an Azure Notification Hubs registration description along with {@link Response} on successful
     *     completion of {@link Mono}.
     */
    @Generated
    @ServiceMethod(returns = ReturnType.SINGLE)
    public Mono<Response<BinaryData>> createOrUpdateWithResponse(
            String registrationId, BinaryData body, RequestOptions requestOptions) {
        return this.serviceClient.createOrUpdateWithResponseAsync(registrationId, body, requestOptions);
    }

    /**
     * Delete an Azure Notification Hubs registration description.
     *
     * <p><strong>Header Parameters</strong>
     *
     * <table border="1">
     *     <caption>Header Parameters</caption>
     *     <tr><th>Name</th><th>Type</th><th>Required</th><th>Description</th></tr>
     *     <tr><td>If-Match</td><td>String</td><td>No</td><td>The If-Match HTTP header</td></tr>
     * </table>
     *
     * You can add these to a request with {@link RequestOptions#addHeader}
     *
     * @param registrationId The registration ID.
     * @param requestOptions The options to configure the HTTP request before HTTP client sends it.
     * @throws HttpResponseException thrown if the request is rejected by server.
     * @throws ClientAuthenticationException thrown if the request is rejected by server on status code 401.
     * @throws ResourceNotFoundException thrown if the request is rejected by server on status code 404.
     * @throws ResourceModifiedException thrown if the request is rejected by server on status code 409.
     * @return the {@link Response} on successful completion of {@link Mono}.
     */
    @Generated
    @ServiceMethod(returns = ReturnType.SINGLE)
    public Mono<Response<Void>> deleteWithResponse(String registrationId, RequestOptions requestOptions) {
        return this.serviceClient.deleteWithResponseAsync(registrationId, requestOptions);
    }

    /**
     * Get an Azure Notification Hubs registration description.
     *
     * <p><strong>Response Body Schema</strong>
     *
     * <pre>{@code
     * {
     *     registrationId: String (Optional)
     *     tags: String (Optional)
     *     etag: String (Optional)
     *     pushVariables (Optional): {
     *         String: String (Optional)
     *     }
     *     expirationTime: String (Optional)
     * }
     * }</pre>
     *
     * @param registrationId The registration ID.
     * @param requestOptions The options to configure the HTTP request before HTTP client sends it.
     * @throws HttpResponseException thrown if the request is rejected by server.
     * @throws ClientAuthenticationException thrown if the request is rejected by server on status code 401.
     * @throws ResourceNotFoundException thrown if the request is rejected by server on status code 404.
     * @throws ResourceModifiedException thrown if the request is rejected by server on status code 409.
     * @return an Azure Notification Hubs registration description along with {@link Response} on successful completion
     *     of {@link Mono}.
     */
    @Generated
    @ServiceMethod(returns = ReturnType.SINGLE)
    public Mono<Response<BinaryData>> getWithResponse(String registrationId, RequestOptions requestOptions) {
        return this.serviceClient.getWithResponseAsync(registrationId, requestOptions);
    }

    /**
     * List Azure Notification Hubs registration descriptions.
     *
     * <p><strong>Query Parameters</strong>
     *
     * <table border="1">
     *     <caption>Query Parameters</caption>
     *     <tr><th>Name</th><th>Type</th><th>Required</th><th>Description</th></tr>
     *     <tr><td>$top</td><td>String</td><td>No</td><td>The limit to the number of records to retrieve</td></tr>
     *     <tr><td>$fitler</td><td>String</td><td>No</td><td>The filter query to find registrations</td></tr>
     *     <tr><td>continuationToken</td><td>String</td><td>No</td><td>The continuation token for more results</td></tr>
     * </table>
     *
     * You can add these to a request with {@link RequestOptions#addQueryParam}
     *
     * <p><strong>Response Body Schema</strong>
     *
     * <pre>{@code
     * [
     *      (Required){
     *         registrationId: String (Optional)
     *         tags: String (Optional)
     *         etag: String (Optional)
     *         pushVariables (Optional): {
     *             String: String (Optional)
     *         }
     *         expirationTime: String (Optional)
     *     }
     * ]
     * }</pre>
     *
     * @param requestOptions The options to configure the HTTP request before HTTP client sends it.
     * @throws HttpResponseException thrown if the request is rejected by server.
     * @throws ClientAuthenticationException thrown if the request is rejected by server on status code 401.
     * @throws ResourceNotFoundException thrown if the request is rejected by server on status code 404.
     * @throws ResourceModifiedException thrown if the request is rejected by server on status code 409.
     * @return the response body along with {@link Response} on successful completion of {@link Mono}.
     */
    @Generated
    @ServiceMethod(returns = ReturnType.SINGLE)
    public Mono<Response<BinaryData>> listWithResponse(RequestOptions requestOptions) {
        return this.serviceClient.listWithResponseAsync(requestOptions);
    }
}
