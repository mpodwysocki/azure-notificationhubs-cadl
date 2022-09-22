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

/** Initializes a new instance of the synchronous AzureNotificationHubsServiceClient type. */
@ServiceClient(builder = NotificationHubJobsClientBuilder.class)
public final class NotificationHubJobsClient {
    @Generated private final NotificationHubJobsAsyncClient client;

    /**
     * Initializes an instance of NotificationHubJobsClient class.
     *
     * @param client the async client.
     */
    @Generated
    NotificationHubJobsClient(NotificationHubJobsAsyncClient client) {
        this.client = client;
    }

    /**
     * Create an import/export Azure Notification Hubs job.
     *
     * <p><strong>Request Body Schema</strong>
     *
     * <pre>{@code
     * {
     *     jobId: String (Optional)
     *     outputFileName: String (Optional)
     *     failuresFileName: String (Optional)
     *     progress: Double (Optional)
     *     type: String(ExportRegistrations/ImportCreateRegistrations/ImportUpdateRegistrations/ImportDeleteRegistrations/ImportUpsertRegistrations) (Required)
     *     status: String(Started/Running/Completed/Failed) (Optional)
     *     outputContainerUrl: String (Required)
     *     importFileUrl: String (Optional)
     *     inputProperties (Optional): {
     *         String: String (Optional)
     *     }
     *     failure: String (Optional)
     *     outputProperties (Optional): {
     *         String: String (Optional)
     *     }
     *     createdAt: String (Optional)
     *     updatedAt: String (Optional)
     * }
     * }</pre>
     *
     * <p><strong>Response Body Schema</strong>
     *
     * <pre>{@code
     * {
     *     jobId: String (Optional)
     *     outputFileName: String (Optional)
     *     failuresFileName: String (Optional)
     *     progress: Double (Optional)
     *     type: String(ExportRegistrations/ImportCreateRegistrations/ImportUpdateRegistrations/ImportDeleteRegistrations/ImportUpsertRegistrations) (Required)
     *     status: String(Started/Running/Completed/Failed) (Optional)
     *     outputContainerUrl: String (Required)
     *     importFileUrl: String (Optional)
     *     inputProperties (Optional): {
     *         String: String (Optional)
     *     }
     *     failure: String (Optional)
     *     outputProperties (Optional): {
     *         String: String (Optional)
     *     }
     *     createdAt: String (Optional)
     *     updatedAt: String (Optional)
     * }
     * }</pre>
     *
     * @param notificationHubJob The Azure Notification Hub import/export job to create.
     * @param requestOptions The options to configure the HTTP request before HTTP client sends it.
     * @throws HttpResponseException thrown if the request is rejected by server.
     * @throws ClientAuthenticationException thrown if the request is rejected by server on status code 401.
     * @throws ResourceNotFoundException thrown if the request is rejected by server on status code 404.
     * @throws ResourceModifiedException thrown if the request is rejected by server on status code 409.
     * @return represents the Azure Notification Hubs job along with {@link Response}.
     */
    @Generated
    @ServiceMethod(returns = ReturnType.SINGLE)
    public Response<BinaryData> createWithResponse(BinaryData notificationHubJob, RequestOptions requestOptions) {
        return this.client.createWithResponse(notificationHubJob, requestOptions).block();
    }

    /**
     * Get an import/export Azure Notification Hubs job.
     *
     * <p><strong>Response Body Schema</strong>
     *
     * <pre>{@code
     * {
     *     jobId: String (Optional)
     *     outputFileName: String (Optional)
     *     failuresFileName: String (Optional)
     *     progress: Double (Optional)
     *     type: String(ExportRegistrations/ImportCreateRegistrations/ImportUpdateRegistrations/ImportDeleteRegistrations/ImportUpsertRegistrations) (Required)
     *     status: String(Started/Running/Completed/Failed) (Optional)
     *     outputContainerUrl: String (Required)
     *     importFileUrl: String (Optional)
     *     inputProperties (Optional): {
     *         String: String (Optional)
     *     }
     *     failure: String (Optional)
     *     outputProperties (Optional): {
     *         String: String (Optional)
     *     }
     *     createdAt: String (Optional)
     *     updatedAt: String (Optional)
     * }
     * }</pre>
     *
     * @param jobId The job ID.
     * @param requestOptions The options to configure the HTTP request before HTTP client sends it.
     * @throws HttpResponseException thrown if the request is rejected by server.
     * @throws ClientAuthenticationException thrown if the request is rejected by server on status code 401.
     * @throws ResourceNotFoundException thrown if the request is rejected by server on status code 404.
     * @throws ResourceModifiedException thrown if the request is rejected by server on status code 409.
     * @return an import/export Azure Notification Hubs job along with {@link Response}.
     */
    @Generated
    @ServiceMethod(returns = ReturnType.SINGLE)
    public Response<BinaryData> getWithResponse(String jobId, RequestOptions requestOptions) {
        return this.client.getWithResponse(jobId, requestOptions).block();
    }

    /**
     * List all import/export Azure Notification Hubs jobs.
     *
     * <p><strong>Response Body Schema</strong>
     *
     * <pre>{@code
     * [
     *      (Required){
     *         jobId: String (Optional)
     *         outputFileName: String (Optional)
     *         failuresFileName: String (Optional)
     *         progress: Double (Optional)
     *         type: String(ExportRegistrations/ImportCreateRegistrations/ImportUpdateRegistrations/ImportDeleteRegistrations/ImportUpsertRegistrations) (Required)
     *         status: String(Started/Running/Completed/Failed) (Optional)
     *         outputContainerUrl: String (Required)
     *         importFileUrl: String (Optional)
     *         inputProperties (Optional): {
     *             String: String (Optional)
     *         }
     *         failure: String (Optional)
     *         outputProperties (Optional): {
     *             String: String (Optional)
     *         }
     *         createdAt: String (Optional)
     *         updatedAt: String (Optional)
     *     }
     * ]
     * }</pre>
     *
     * @param requestOptions The options to configure the HTTP request before HTTP client sends it.
     * @throws HttpResponseException thrown if the request is rejected by server.
     * @throws ClientAuthenticationException thrown if the request is rejected by server on status code 401.
     * @throws ResourceNotFoundException thrown if the request is rejected by server on status code 404.
     * @throws ResourceModifiedException thrown if the request is rejected by server on status code 409.
     * @return the response body along with {@link Response}.
     */
    @Generated
    @ServiceMethod(returns = ReturnType.SINGLE)
    public Response<BinaryData> listWithResponse(RequestOptions requestOptions) {
        return this.client.listWithResponse(requestOptions).block();
    }
}
