﻿// Copyright (c) MASA Stack All rights reserved.
// Licensed under the Apache License. See LICENSE.txt in the project root for license information.

global using FluentValidation;
global using FluentValidation.AspNetCore;
global using Masa.BuildingBlocks.Data.UoW;
global using Masa.BuildingBlocks.Ddd.Domain.Events;
global using Masa.BuildingBlocks.Ddd.Domain.Repositories;
global using Masa.BuildingBlocks.Dispatcher.Events;
global using Masa.Contrib.Ddd.Domain;
global using Masa.Contrib.Ddd.Domain.Repository.EFCore;
global using Masa.Contrib.Dispatcher.Events;
global using Masa.Contrib.Dispatcher.IntegrationEvents.Dapr;
global using Masa.Contrib.Dispatcher.IntegrationEvents.EventLogs.EFCore;
global using Masa.Scheduler.Services.Server.Application.Jobs.Commands;
global using Masa.Scheduler.Services.Server.Application.Jobs.Queries;
global using Masa.Scheduler.Services.Server.Domain.Aggregates.Jobs;
global using Masa.Scheduler.Services.Server.Domain.Repositories;
global using Masa.Scheduler.Services.Server.Domain.Services;
global using Masa.Scheduler.Services.Server.Infrastructure;
global using Masa.Scheduler.Services.Server.Infrastructure.Middleware;
global using Masa.BuildingBlocks.Dispatcher.IntegrationEvents;
global using Masa.Contrib.Isolation.MultiEnvironment;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.OpenApi.Models;
global using Masa.Scheduler.Contracts.Server.Infrastructure.Enums;
global using Masa.Scheduler.Services.Server.Domain.Aggregates.Tasks;
global using Masa.Scheduler.Services.Server.Domain.Aggregates.Resources;
global using System.Reflection;
global using Masa.Scheduler.Services.Server.Application.Projects.Queries;
global using Masa.BuildingBlocks.StackSdks.Pm;
global using HttpMethods = Masa.Scheduler.Contracts.Server.Infrastructure.Enums.HttpMethods;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using System.Text.Json;
global using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
global using Masa.Scheduler.Services.Server.Infrastructure.EntityConfigurations.ValueConverts;
global using Masa.Scheduler.Services.Server.Domain.Aggregates.Jobs.Configs;
global using Masa.Scheduler.Contracts.Server.Dtos;
global using Microsoft.AspNetCore.Mvc;
global using Masa.Scheduler.Contracts.Server.Requests.SchedulerJobs;
global using Masa.Scheduler.Contracts.Server.Validator;
global using System.Linq.Expressions;
global using Masa.BuildingBlocks.Data.Mapping;
global using Masa.Scheduler.Contracts.Server.Requests.SchedulerTasks;
global using Masa.Scheduler.Services.Server.Application.Tasks.Commands;
global using Masa.Scheduler.Services.Server.Application.Tasks.Queries;
global using Masa.Scheduler.Services.Server.Domain.Events;
global using Masa.Scheduler.Contracts.Server.Model;
global using Masa.Scheduler.Services.Server.Domain.Managers.Servers;
global using Masa.Scheduler.Services.Server.Infrastructure.Common;
global using Masa.Scheduler.Contracts.Server.Responses;
global using Masa.Contrib.Data.Contracts;
global using Masa.BuildingBlocks.Ddd.Domain.Entities.Full;
global using Dapr;
global using Masa.Scheduler.Contracts.Server.Infrastructure.IntegrationEvents;
global using Masa.Scheduler.Contracts.Server.Infrastructure.Consts;
global using Masa.BuildingBlocks.Ddd.Domain.Values;
global using System.Text.Json.Serialization;
global using Masa.Scheduler.Services.Server.Domain.Managers.Servers.Data;
global using Masa.Scheduler.Contracts.Server.Infrastructure.Managers;
global using System.Collections.Concurrent;
global using Microsoft.AspNetCore.SignalR;
global using Masa.Scheduler.Services.Server.Infrastructure.SignalR.Hubs;
global using Masa.Scheduler.Services.Server.Infrastructure.SignalR;
global using Masa.Scheduler.Contracts.Server.Requests.SchedulerResources;
global using Masa.Scheduler.Services.Server.Application.Resources.Commands;
global using Masa.Scheduler.Services.Server.Application.Resources.Queries;
global using Dapr.Client;
global using Masa.BuildingBlocks.Storage.ObjectStorage;
global using Masa.Contrib.Storage.ObjectStorage.Aliyun.Options;
global using Quartz;
global using Masa.Scheduler.Services.Server.Infrastructure.Quartz;
global using Masa.Scheduler.Services.Server.Domain.QuartzJob;
global using Masa.Scheduler.Services.Server.Application.Auths.Queries;
global using Masa.BuildingBlocks.ReadWriteSplitting.Cqrs.Queries;
global using Masa.BuildingBlocks.ReadWriteSplitting.Cqrs.Commands;
global using Masa.Contrib.Dispatcher.IntegrationEvents;
global using Masa.BuildingBlocks.Configuration;
global using Masa.Contrib.Configuration.ConfigurationApi.Dcc;
global using Masa.Contrib.Caching.MultilevelCache;
global using Masa.Contrib.Caching.Distributed.StackExchangeRedis;
global using Masa.BuildingBlocks.Authentication.Identity;
global using Microsoft.Extensions.Diagnostics.HealthChecks;
global using Masa.BuildingBlocks.StackSdks.Auth;
global using Masa.BuildingBlocks.StackSdks.Pm.Enum;
global using Masa.Utils.Security.Cryptography;
global using Masa.BuildingBlocks.Caching;
global using Microsoft.Extensions.Caching.Distributed;
global using Microsoft.Extensions.Caching.Memory;
global using Masa.Scheduler.Contracts.Server.Infrastructure.Logger;
global using System.Runtime.CompilerServices;
global using System.Text;
global using HealthChecks.UI.Client;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Diagnostics.HealthChecks;
global using System.Net.Http.Headers;
global using Microsoft.Extensions.Options;
global using Masa.BuildingBlocks.Isolation;
global using Masa.BuildingBlocks.Ddd.Domain.Services;
global using Masa.Contrib.StackSdks.Tsc;
global using Masa.Contrib.Storage.ObjectStorage.Aliyun;
global using Masa.Scheduler.Services.Server.Infrastructure.Extensions;
global using Masa.BuildingBlocks.StackSdks.Auth.Contracts;
global using Masa.BuildingBlocks.StackSdks.Config;
global using Masa.BuildingBlocks.StackSdks.Auth.Contracts.Consts;
global using Masa.Contrib.Configuration.ConfigurationApi.Dcc.Options;
global using Masa.Contrib.StackSdks.Config;
global using Masa.Utils.Configuration.Json;
global using System.Text.RegularExpressions;
global using Masa.Contrib.StackSdks.Middleware;
global using Microsoft.EntityFrameworkCore.Design;
global using Masa.Contrib.StackSdks.Caller;
global using FluentValidation.Resources;
global using Masa.BuildingBlocks.StackSdks.Alert;
global using Microsoft.EntityFrameworkCore.Diagnostics;
global using System.Data.Common;
global using System.Data;
global using Masa.Contrib.StackSdks.Isolation;