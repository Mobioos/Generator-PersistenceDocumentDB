using Microsoft.Extensions.DependencyInjection;
using Mobioos.Foundation.Jade;
using Mobioos.Scaffold.BaseInfrastructure.Contexts;
using Mobioos.Scaffold.BaseInfrastructure.Notifiers;
using Mobioos.Scaffold.BaseInfrastructure.Services.GeneratorsServices;
using System;
using System.Dynamic;
using System.IO;
using System.Threading;
using Unity;
using WorkflowCore.Interface;
using WorkflowCore.Models;
using WorkflowCore.Unity;

namespace GeneratorProject.Tests
{
    public class BaseGeneratorTest
    {
        protected IServiceCollection _services;
        protected IServiceProvider _serviceProvider;
        protected IUnityServiceProvider _unityServiceProvider;
        protected IUnityContainer _container;
        protected IPersistenceProvider _persistenceProvider;
        protected IWorkflowHost _workflowHost;
        protected SessionContext _context;

        public BaseGeneratorTest()
        {
            _services = new ServiceCollection();
            _services.AddLogging();
            _services.AddWorkflow();
            _services.AddSingleton<IUnityServiceProvider, UnityServiceProvider>();
            _services.AddSingleton<IUnityContainer, UnityContainer>();
            _serviceProvider = _services.BuildServiceProvider();

            _unityServiceProvider = _serviceProvider.GetService<IUnityServiceProvider>();
            _container = _serviceProvider.GetService<IUnityContainer>();
            _container.AddExtension(new UnityFallbackProviderExtension(_serviceProvider));
            _workflowHost = _unityServiceProvider.GetService<IWorkflowHost>();
            _persistenceProvider = _unityServiceProvider.GetService<IPersistenceProvider>();

            _context = new SessionContext();
            _context.DynamicContext = new ExpandoObject();

            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            _context.BasePath = Path.Combine(basePath, "GeneratedCode");

            var manifestPath = Path.Combine(basePath, "Manifest");
            _context.Manifest = JadeEngine.Parse(manifestPath);

            _context.GeneratorPath = basePath;

            var writingService = new WritingService();
            var workflowNotifier = new WorkflowNotifier();
            var workflowEndService = new WorkflowEndService();

            _container.RegisterInstance<IWorkflowEnd>(workflowEndService);
            _container.RegisterInstance<IWorkflowNotifier>(workflowNotifier);
            _container.RegisterInstance<IWriting>(writingService);
            _container.RegisterInstance<ISessionContext>(_context);
        }

        protected WorkflowStatus GetStatus(string workflowId)
        {
            var instance = _persistenceProvider.GetWorkflowInstance(workflowId).Result;
            return instance.Status;
        }

        protected void WaitForWorkflowToComplete(string workflowId, TimeSpan timeOut)
        {
            var status = GetStatus(workflowId);
            var counter = 0;
            while ((status == WorkflowStatus.Runnable) && (counter < (timeOut.TotalMilliseconds / 100)))
            {
                Thread.Sleep(100);
                counter++;
                status = GetStatus(workflowId);
            }
        }

        protected void Clear()
        {
            if (_workflowHost != null)
            {
                _workflowHost.Stop();
            }
        }
    }
}
