﻿// Copyright (c) MASA Stack All rights reserved.
// Licensed under the Apache License. See LICENSE.txt in the project root for license information.

namespace Masa.Scheduler.Web.Admin.Pages.SchedulerResources;

public partial class SchedulerResourceFiles
{
    private const string PROJECT_PREFIX = "Project_";

    private const string APP_PREFIX = "App_";

    private StringNumber _selectedProjectId = null!;

    public StringNumber SelectedProjectId
    {
        get
        {
            return _selectedProjectId;
        }
        set
        {
            if (_selectedProjectId != value)
            {
                _selectedProjectId = value;
            }
        }
    }

    private StringNumber? _selectedId;
    private int _lastSelectedAppId;

    public StringNumber? SelectedId
    {
        get
        {
            return _selectedId;
        }
        set
        {
            if (_selectedId != value)
            {
                _selectedId = value;

                if (_selectedId != null && _selectedId.IsT0 && _selectedId.AsT0.StartsWith(APP_PREFIX))
                {
                    LastSelectedAppId = int.Parse(_selectedId.AsT0.Replace(APP_PREFIX, ""));

                    SelectedResourceId = Guid.Empty.ToString();

                    _isAdd = false;
                }
            }
        }
    }

    private StringNumber _selectedResourceId = default!;

    private SchedulerResourceDto? _selectedResourceDto;

    public StringNumber SelectedResourceId
    {
        get => _selectedResourceId;
        set
        {
            if (_selectedResourceId != value)
            {
                _selectedResourceId = value;

                _selectedResourceDto = _resources.FirstOrDefault(r => r.Id.ToString() == SelectedResourceId.AsT0);

                _isAdd = false;
            }
        }
    }

    private List<SideBarItem> _allProjects = new();

    private List<SideBarItem> _projects = new();

    private List<SchedulerResourceDto> _resources = new();

    private string Color { get; set; } = "#4318FF";

    private string _searchName = string.Empty;

    private bool _showForm = false;

    private bool _isAdd = false;

    private SchedulerResourceDto Model { get; set; } = new();

    private MForm? _form;

    public int LastSelectedAppId
    {
        get => _lastSelectedAppId;
        set
        {
            if (_lastSelectedAppId != value)
            {
                _lastSelectedAppId = value;
                OnSelectedAppIdChanged();
            }
        }
    }

    public string SearchName
    {
        get => _searchName;
        set
        {
            if(_searchName != value)
            {
                _searchName = value;
                OnSearchNameChanged();
            }
        }
    }

    protected override async Task OnInitializedAsync()
    {
        await GetProjects();

        await base.OnInitializedAsync();
    }

    private async Task GetProjects()
    {
        try
        {
            var response = await SchedulerServerCaller.PmService.GetProjectListAsync(null);

            foreach (var project in response.Data)
            {
                _projects.Add(new SideBarItem()
                {
                    Id = PROJECT_PREFIX + Id,
                    Title = project.Name,
                    IsProject = true,
                    Children = project.ProjectApps.Select(app => new SideBarItem() { Id = APP_PREFIX + app.Id, Title = app.Name, IsProject = false }).ToList()
                });
            }

            _allProjects = _projects;
        }
        catch (Exception ex)
        {
            await PopupService.ToastAsync(ex.Message, AlertTypes.Error);
        }
    }

    private async Task GetResourceList()
    {
        if (_lastSelectedAppId == 0)
        {
            return;
        }

        var request = new SchedulerResourceListRequest() { JobAppId = _lastSelectedAppId };

        var response = await SchedulerServerCaller.SchedulerResourceService.GetListAsync(request);

        _resources = response.Data;

        StateHasChanged();
    }

    private Task OnSelectedAppIdChanged()
    {
        return GetResourceList();
    }

    private StringNumber GetKey(SideBarItem item)
    {
        StringNumber key;

        if (item.IsProject)
        {
            key = PROJECT_PREFIX + item.Id;
        }
        else
        {
            key = APP_PREFIX + item.Id;
        }

        return key;
    }

    private Task OnSearchNameChanged()
    {
        if (string.IsNullOrEmpty(SearchName))
        {
            _projects = _allProjects;
            return Task.CompletedTask;
        }

        var parentList = new List<SideBarItem>();

        foreach (var item in _allProjects)
        {
            foreach (var child in item.Children)
            {
                if (child.Title.Contains(SearchName))
                {
                    var parent = parentList.FirstOrDefault(p => p.Id == item.Id);

                    if(parent == null)
                    {
                        parent = new SideBarItem()
                        {
                            Title = item.Title,
                            Id = item.Id,
                            Expanded = item.Expanded,
                            IsProject = item.IsProject
                        };

                        parentList.Add(parent);
                    }

                    parent.Children.Add(child);
                }
            }
        }

        _projects = parentList;

        return Task.CompletedTask;
    }

    private async Task AddResourceFile()
    {
        Model = new();
        Model.JobAppId = LastSelectedAppId;
        Model.Version = await GetDefaultVersion();
        _isAdd = true;
    }

    private Task<string> GetDefaultVersion()
    {
        if (!_resources.Any())
        {
            return Task.FromResult("1.0.0");
        }
        else
        {
            var lastResource = _resources.FirstOrDefault()!;
          
            var lastVersionArr = lastResource.Version.Split(".");

            if (int.TryParse(lastVersionArr.Last(), out var lastVersionNumber))
            {
                lastVersionNumber += 1;
                lastVersionArr[lastVersionArr.Count() - 1] = lastVersionNumber.ToString();

                return Task.FromResult(string.Join(".", lastVersionArr));
            }
        }
        return Task.FromResult(string.Empty);
    }

    private async Task DeleteResourceFiles(Guid id)
    {
        await SchedulerServerCaller.SchedulerResourceService.DeleteAsync(id);

        await PopupService.ToastAsync("Delete success", AlertTypes.Success);

        await GetResourceList();
    }

    private async Task AfterSubmit()
    {
        _isAdd = false;
        await GetResourceList();

        if (_resources.Any())
        {
            SelectedResourceId = _resources.FirstOrDefault()!.Id.ToString();
        }
    }
}
