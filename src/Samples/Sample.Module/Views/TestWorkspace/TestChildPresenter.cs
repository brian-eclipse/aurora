﻿using System.Diagnostics;
using System.Runtime.CompilerServices;
using Aurora.Core;
using Aurora.Core.Actions;
using Aurora.Core.Activities;
using Aurora.Core.Workspace;

namespace Aurora.Sample.Module.Views.TestWorkspace
{
    public class TestChildPresenter : WorkspaceViewPresenter<TestChildViewModel>
    {
        private readonly IActionService actionService;
        
        public TestChildPresenter(IActionService actionService, IDependencyHandler dependencyHandler) : base(new ViewActivityInfo(null), dependencyHandler)
        {
            Debug.WriteLine("Create TestChildViewPresenter");
            this.actionService = actionService;
        }

        protected override void OnInitialized()
        {
            var action = actionService.GetAction("action1");
            this.RegisterActionHandler(action, new TestChildActionHandler());
        }

        protected override void OnViewModelChanged()
        {
            this.ViewModel.Title = "Child view";
        }
    }
}