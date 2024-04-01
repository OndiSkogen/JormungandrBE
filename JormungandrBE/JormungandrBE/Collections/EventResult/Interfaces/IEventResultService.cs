using System.Reflection;

namespace JormungandrBE.Collections.EventResult.Interfaces
{
    public interface IEventResultService
    {
        Models.EventResult GetEventResult(string name);
        List<Models.EventResult> GetEventResults();
        Models.EventResult CreateEventResult(Models.EventResult eventResult);
        bool DeleteEventResult(string name);
        bool UpdateEventResult(string name, Models.EventResult eventResultIn);
        List<Models.EventResult> GetEventResultsForEvent(string eventId);
    }
}
