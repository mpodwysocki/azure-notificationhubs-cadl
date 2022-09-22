// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// Code generated by Microsoft (R) AutoRest Code Generator.

package com.notificationhubs.implementation;

import com.azure.core.annotation.BodyParam;
import com.azure.core.annotation.ExpectedResponses;
import com.azure.core.annotation.Get;
import com.azure.core.annotation.HeaderParam;
import com.azure.core.annotation.Host;
import com.azure.core.annotation.HostParam;
import com.azure.core.annotation.PathParam;
import com.azure.core.annotation.Post;
import com.azure.core.annotation.ReturnType;
import com.azure.core.annotation.ServiceInterface;
import com.azure.core.annotation.ServiceMethod;
import com.azure.core.annotation.UnexpectedResponseExceptionType;
import com.azure.core.exception.ClientAuthenticationException;
import com.azure.core.exception.HttpResponseException;
import com.azure.core.exception.ResourceModifiedException;
import com.azure.core.exception.ResourceNotFoundException;
import com.azure.core.http.rest.RequestOptions;
import com.azure.core.http.rest.Response;
import com.azure.core.http.rest.RestProxy;
import com.azure.core.util.BinaryData;
import com.azure.core.util.Context;
import com.azure.core.util.FluxUtil;
import reactor.core.publisher.Mono;

/** An instance of this class provides access to all the operations defined in NotificationHubJobs. */
public final class NotificationHubJobsImpl {
    /** The proxy service used to perform REST calls. */
    private final NotificationHubJobsService service;

    /** The service client containing this operation class. */
    private final AzureNotificationHubsServiceClientImpl client;

    /**
     * Initializes an instance of NotificationHubJobsImpl.
     *
     * @param client the instance of the service client containing this operation class.
     */
    NotificationHubJobsImpl(AzureNotificationHubsServiceClientImpl client) {
        this.service =
                RestProxy.create(
                        NotificationHubJobsService.class, client.getHttpPipeline(), client.getSerializerAdapter());
        this.client = client;
    }

    /**
     * The interface defining all the services for AzureNotificationHubsServiceNotificationHubJobs to be used by the
     * proxy service to perform REST calls.
     */
    @Host("https://{namespaceName}.servicebus.windows.net/{hubName}")
    @ServiceInterface(name = "AzureNotificationHub")
    private interface NotificationHubJobsService {
        @Post("/jobs")
        @ExpectedResponses({201})
        @UnexpectedResponseExceptionType(
                value = ClientAuthenticationException.class,
                code = {401})
        @UnexpectedResponseExceptionType(
                value = ResourceNotFoundException.class,
                code = {404})
        @UnexpectedResponseExceptionType(
                value = ResourceModifiedException.class,
                code = {409})
        @UnexpectedResponseExceptionType(HttpResponseException.class)
        Mono<Response<BinaryData>> create(
                @HostParam("namespaceName") String namespaceName,
                @HostParam("hubName") String hubName,
                @HeaderParam("Content-Type") String contentType,
                @HeaderParam("accept") String accept,
                @BodyParam("application/atom+xml;type=entry;charset=utf-8") BinaryData notificationHubJob,
                RequestOptions requestOptions,
                Context context);

        @Get("/jobs/{jobId}")
        @ExpectedResponses({200})
        @UnexpectedResponseExceptionType(
                value = ClientAuthenticationException.class,
                code = {401})
        @UnexpectedResponseExceptionType(
                value = ResourceNotFoundException.class,
                code = {404})
        @UnexpectedResponseExceptionType(
                value = ResourceModifiedException.class,
                code = {409})
        @UnexpectedResponseExceptionType(HttpResponseException.class)
        Mono<Response<BinaryData>> get(
                @HostParam("namespaceName") String namespaceName,
                @HostParam("hubName") String hubName,
                @PathParam("jobId") String jobId,
                @HeaderParam("accept") String accept,
                RequestOptions requestOptions,
                Context context);

        @Get("/jobs")
        @ExpectedResponses({200})
        @UnexpectedResponseExceptionType(
                value = ClientAuthenticationException.class,
                code = {401})
        @UnexpectedResponseExceptionType(
                value = ResourceNotFoundException.class,
                code = {404})
        @UnexpectedResponseExceptionType(
                value = ResourceModifiedException.class,
                code = {409})
        @UnexpectedResponseExceptionType(HttpResponseException.class)
        Mono<Response<BinaryData>> list(
                @HostParam("namespaceName") String namespaceName,
                @HostParam("hubName") String hubName,
                @HeaderParam("accept") String accept,
                RequestOptions requestOptions,
                Context context);
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
     * @return represents the Azure Notification Hubs job along with {@link Response} on successful completion of {@link
     *     Mono}.
     */
    @ServiceMethod(returns = ReturnType.SINGLE)
    public Mono<Response<BinaryData>> createWithResponseAsync(
            BinaryData notificationHubJob, RequestOptions requestOptions) {
        final String contentType = "application/atom+xml;type=entry;charset=utf-8";
        final String accept = "application/json";
        return FluxUtil.withContext(
                context ->
                        service.create(
                                this.client.getNamespaceName(),
                                this.client.getHubName(),
                                contentType,
                                accept,
                                notificationHubJob,
                                requestOptions,
                                context));
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
    @ServiceMethod(returns = ReturnType.SINGLE)
    public Response<BinaryData> createWithResponse(BinaryData notificationHubJob, RequestOptions requestOptions) {
        return createWithResponseAsync(notificationHubJob, requestOptions).block();
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
     * @return an import/export Azure Notification Hubs job along with {@link Response} on successful completion of
     *     {@link Mono}.
     */
    @ServiceMethod(returns = ReturnType.SINGLE)
    public Mono<Response<BinaryData>> getWithResponseAsync(String jobId, RequestOptions requestOptions) {
        final String accept = "application/json";
        return FluxUtil.withContext(
                context ->
                        service.get(
                                this.client.getNamespaceName(),
                                this.client.getHubName(),
                                jobId,
                                accept,
                                requestOptions,
                                context));
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
    @ServiceMethod(returns = ReturnType.SINGLE)
    public Response<BinaryData> getWithResponse(String jobId, RequestOptions requestOptions) {
        return getWithResponseAsync(jobId, requestOptions).block();
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
     * @return the response body along with {@link Response} on successful completion of {@link Mono}.
     */
    @ServiceMethod(returns = ReturnType.SINGLE)
    public Mono<Response<BinaryData>> listWithResponseAsync(RequestOptions requestOptions) {
        final String accept = "application/json";
        return FluxUtil.withContext(
                context ->
                        service.list(
                                this.client.getNamespaceName(),
                                this.client.getHubName(),
                                accept,
                                requestOptions,
                                context));
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
    @ServiceMethod(returns = ReturnType.SINGLE)
    public Response<BinaryData> listWithResponse(RequestOptions requestOptions) {
        return listWithResponseAsync(requestOptions).block();
    }
}
