using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOCPP.Interfaces
{
    public interface IActionHandler
    {
        Task<MessageType?> Authorize(Call call) { return null; }
        Task<MessageType> BootNotification(Call call) { return null; }
        Task<MessageType?> CancelReservation(Call call) { return null; }
        Task<MessageType?> ChangeAvailability(Call call) { return null; }
        Task<MessageType?> ClearCache(Call call) { return null; }
        Task<MessageType?> ClearChargingProfile(Call call) { return null; }
        Task<MessageType?> DataTransfer(Call call) { return null; }
        Task<MessageType?> FirmwareStatusNotification(Call call) { return null; }
        Task<MessageType?> GetCompositeSchedule(Call call) { return null; }
        Task<MessageType?> GetLocalListVersion(Call call) { return null; }
        Task<MessageType?> Heartbeat(Call call) { return null; }
        Task<MessageType?> MeterValues(Call call) { return null; }
        Task<MessageType?> ReserveNow(Call call) { return null; }
        Task<MessageType?> Reset(Call call) { return null; }
        Task<MessageType?> SendLocalList(Call call) { return null; }
        Task<MessageType?> SetChargingProfile(Call call) { return null; }
        Task<MessageType?> StatusNotification(Call call) { return null; }
        Task<MessageType?> TriggerMessage(Call call) { return null; }
        Task<MessageType?> UnlockConnector(Call call) { return null; }
        Task<MessageType?> UpdateFirmware(Call call) { return null; }

    }
}
