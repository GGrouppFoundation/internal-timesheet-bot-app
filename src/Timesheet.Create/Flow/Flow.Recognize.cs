using System;
using System.Threading;
using System.Threading.Tasks;
using GGroupp.Infra.Bot.Builder;

namespace GGroupp.Internal.Timesheet;

partial class TimesheetCreateChatFlow
{
    internal static async ValueTask<Result<ChatFlow, Unit>> InternalRecoginzeFlowAsync(
        this IBotContext context, string commandName, CancellationToken cancellationToken)
    {
        var turnContext = context.TurnContext;
        if (turnContext.IsNotMessageType())
        {
            return default;
        }

        var chatFlow = context.CreateChatFlow("TimesheetCreate");
        if (await chatFlow.IsStartedAsync(cancellationToken).ConfigureAwait(false))
        {
            return chatFlow;
        }

        return turnContext.RecognizeCommandOrAbsent(commandName).Fold(_ => chatFlow, Result.Absent<ChatFlow>);
    }
}