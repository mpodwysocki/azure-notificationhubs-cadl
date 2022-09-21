# coding=utf-8
# --------------------------------------------------------------------------
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for license information.
# Code generated by Microsoft (R) Python Code Generator.
# Changes may cause incorrect behavior and will be lost if the code is regenerated.
# --------------------------------------------------------------------------

from ._operations import InstallationsOperations
from ._operations import RegistrationsOperations
from ._operations import ListRegistrationsByTagOperations
from ._operations import NotificationsOperations
from ._operations import ScheduledNotificationsOperations
from ._operations import NotificationHubJobsOperations

from ._patch import __all__ as _patch_all
from ._patch import *  # type: ignore # pylint: disable=unused-wildcard-import
from ._patch import patch_sdk as _patch_sdk

__all__ = [
    "InstallationsOperations",
    "RegistrationsOperations",
    "ListRegistrationsByTagOperations",
    "NotificationsOperations",
    "ScheduledNotificationsOperations",
    "NotificationHubJobsOperations",
]
__all__.extend([p for p in _patch_all if p not in __all__])
_patch_sdk()
