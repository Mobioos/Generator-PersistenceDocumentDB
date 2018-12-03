using System.Threading.Tasks;
using Mobioos.Foundation.Prompt.Infrastructure;
using Mobioos.Scaffold.BaseInfrastructure.Notifiers;

namespace GeneratorProject.Tests
{
    public class WorkflowNotifier : IWorkflowNotifier
    {
        public Task Notify(string stepName, NotificationType type, string message)
        {
            return null;
        }

        public Task OnCompletedAnswersNotify(string stepName)
        {
            return null;
        }
    }
}
