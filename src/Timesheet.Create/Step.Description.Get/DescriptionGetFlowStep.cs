﻿using GGroupp.Infra.Bot.Builder;

namespace GGroupp.Internal.Timesheet;

internal static class DescriptionGetFlowStep
{
    internal static ChatFlow<TimesheetCreateFlowStateJson> GetDescription(
        this ChatFlow<TimesheetCreateFlowStateJson> chatFlow)
        =>
        chatFlow.GetTextOrSkip(
            static _ => new(
                messageText: "Введите описание. Этот шаг можно пропустить"),
            static (state, description) => state with
            {
                Description = description
            });
}