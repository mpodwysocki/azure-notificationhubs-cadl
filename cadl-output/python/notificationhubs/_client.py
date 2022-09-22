# coding=utf-8
# --------------------------------------------------------------------------
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for license information.
# Code generated by Microsoft (R) Python Code Generator.
# Changes may cause incorrect behavior and will be lost if the code is regenerated.
# --------------------------------------------------------------------------

from copy import deepcopy
from typing import Any, Optional

from azure.core import PipelineClient
from azure.core.rest import HttpRequest, HttpResponse

from ._configuration import AzureNotificationHubsServiceConfiguration
from ._serialization import Deserializer, Serializer
from .operations import (
    InstallationsOperations,
    ListRegistrationsByTagOperations,
    NotificationHubJobsOperations,
    NotificationsOperations,
    RegistrationsOperations,
    ScheduledNotificationsOperations,
)


class AzureNotificationHubsService:  # pylint: disable=client-accepts-api-version-keyword
    """Service client.

    :ivar installations: InstallationsOperations operations
    :vartype installations: notificationhubs.operations.InstallationsOperations
    :ivar registrations: RegistrationsOperations operations
    :vartype registrations: notificationhubs.operations.RegistrationsOperations
    :ivar list_registrations_by_tag: ListRegistrationsByTagOperations operations
    :vartype list_registrations_by_tag:
     notificationhubs.operations.ListRegistrationsByTagOperations
    :ivar notifications: NotificationsOperations operations
    :vartype notifications: notificationhubs.operations.NotificationsOperations
    :ivar scheduled_notifications: ScheduledNotificationsOperations operations
    :vartype scheduled_notifications: notificationhubs.operations.ScheduledNotificationsOperations
    :ivar notification_hub_jobs: NotificationHubJobsOperations operations
    :vartype notification_hub_jobs: notificationhubs.operations.NotificationHubJobsOperations
    :param namespace_name: Notification Hubs Namespace. Default value is None.
    :type namespace_name: str
    :param hub_name: Notification Hub Name. Default value is None.
    :type hub_name: str
    """

    def __init__(  # pylint: disable=missing-client-constructor-parameter-credential
        self, namespace_name: Optional[str] = None, hub_name: Optional[str] = None, **kwargs: Any
    ) -> None:
        _endpoint = "https://{namespaceName}.servicebus.windows.net/{hubName}"
        self._config = AzureNotificationHubsServiceConfiguration(
            namespace_name=namespace_name, hub_name=hub_name, **kwargs
        )
        self._client = PipelineClient(base_url=_endpoint, config=self._config, **kwargs)

        self._serialize = Serializer()
        self._deserialize = Deserializer()
        self._serialize.client_side_validation = False
        self.installations = InstallationsOperations(self._client, self._config, self._serialize, self._deserialize)
        self.registrations = RegistrationsOperations(self._client, self._config, self._serialize, self._deserialize)
        self.list_registrations_by_tag = ListRegistrationsByTagOperations(
            self._client, self._config, self._serialize, self._deserialize
        )
        self.notifications = NotificationsOperations(self._client, self._config, self._serialize, self._deserialize)
        self.scheduled_notifications = ScheduledNotificationsOperations(
            self._client, self._config, self._serialize, self._deserialize
        )
        self.notification_hub_jobs = NotificationHubJobsOperations(
            self._client, self._config, self._serialize, self._deserialize
        )

    def send_request(self, request: HttpRequest, **kwargs: Any) -> HttpResponse:
        """Runs the network request through the client's chained policies.

        >>> from azure.core.rest import HttpRequest
        >>> request = HttpRequest("GET", "https://www.example.org/")
        <HttpRequest [GET], url: 'https://www.example.org/'>
        >>> response = client.send_request(request)
        <HttpResponse: 200 OK>

        For more information on this code flow, see https://aka.ms/azsdk/dpcodegen/python/send_request

        :param request: The network request you want to make. Required.
        :type request: ~azure.core.rest.HttpRequest
        :keyword bool stream: Whether the response payload will be streamed. Defaults to False.
        :return: The response of your network call. Does not do error handling on your response.
        :rtype: ~azure.core.rest.HttpResponse
        """

        request_copy = deepcopy(request)
        path_format_arguments = {
            "namespaceName": self._serialize.url("self._config.namespace_name", self._config.namespace_name, "str"),
            "hubName": self._serialize.url("self._config.hub_name", self._config.hub_name, "str"),
        }

        request_copy.url = self._client.format_url(request_copy.url, **path_format_arguments)
        return self._client.send_request(request_copy, **kwargs)

    def close(self):
        # type: () -> None
        self._client.close()

    def __enter__(self):
        # type: () -> AzureNotificationHubsService
        self._client.__enter__()
        return self

    def __exit__(self, *exc_details):
        # type: (Any) -> None
        self._client.__exit__(*exc_details)