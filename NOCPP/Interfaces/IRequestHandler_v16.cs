using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOCPP.Interfaces
{
    public interface IRequestHandler_v16 : IRequestHandler
    {
        Task<MessageType?> ChangeConfiguration(Call call) { return null; }
        Task<MessageType?> DiagnosticsStatusNotification(Call call) { return null; }
        Task<MessageType?> GetConfiguration(Call call) { return null; }
        Task<MessageType?> GetDiagnostics(Call call) { return null; }
        Task<MessageType?> RemoteStartTransaction(Call call) { return null; }
        Task<MessageType?> RemoteStopTransaction(Call call) { return null; }
        Task<MessageType?> StartTransaction(Call call) { return null; }
        Task<MessageType?> StopTransaction(Call call) { return null; }
    }
}
