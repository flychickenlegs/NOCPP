using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOCPP.Interfaces
{
    public interface IActionHandler_v201 : IActionHandler
    {
        Task<MessageType?> CertificateSigned(Call call) { return null; }
        Task<MessageType?> ClearDisplayMessage(Call call) { return null; }
        Task<MessageType?> ClearedChargingLimit(Call call) { return null; }
        Task<MessageType?> ClearVariableMonitoring(Call call) { return null; }
        Task<MessageType?> CostUpdated(Call call) { return null; }
        Task<MessageType?> CustomerInformation(Call call) { return null; }
        Task<MessageType?> DeleteCertificate(Call call) { return null; }
        Task<MessageType?> Get15118EVCertificate(Call call) { return null; }
        Task<MessageType?> GetBaseReport(Call call) { return null; }
        Task<MessageType?> GetCertificateStatus(Call call) { return null; }
        Task<MessageType?> GetChargingProfiles(Call call) { return null; }
        Task<MessageType?> GetDisplayMessages(Call call) { return null; }
        Task<MessageType?> GetInstalledCertificateIds(Call call) { return null; }
        Task<MessageType?> GetLog(Call call) { return null; }
        Task<MessageType?> GetMonitoringReport(Call call) { return null; }
        Task<MessageType?> GetReport(Call call) { return null; }
        Task<MessageType?> GetTransactionStatus(Call call) { return null; }
        Task<MessageType?> GetVariables(Call call) { return null; }
        Task<MessageType?> InstallCertificate(Call call) { return null; }
        Task<MessageType?> LogStatusNotification(Call call) { return null; }
        Task<MessageType?> NotifyChargingLimit(Call call) { return null; }
        Task<MessageType?> NotifyCustomerInformation(Call call) { return null; }
        Task<MessageType?> NotifyDisplayMessages(Call call) { return null; }
        Task<MessageType?> NotifyEVChargingNeeds(Call call) { return null; }
        Task<MessageType?> NotifyEVChargingSchedule(Call call) { return null; }
        Task<MessageType?> NotifyEvent(Call call) { return null; }
        Task<MessageType?> NotifyMonitoringReport(Call call) { return null; }
        Task<MessageType?> NotifyReport(Call call) { return null; }
        Task<MessageType?> PublishFirmware(Call call) { return null; }
        Task<MessageType?> PublishFirmwareStatusNotification(Call call) { return null; }
        Task<MessageType?> ReportChargingProfiles(Call call) { return null; }
        Task<MessageType?> ResponseStartTransaction(Call call) { return null; }
        Task<MessageType?> ResponseStopTransaction(Call call) { return null; }
        Task<MessageType?> ReservationStatusUpdate(Call call) { return null; }
        Task<MessageType?> SecurityEventNotification(Call call) { return null; }
        Task<MessageType?> SetDisplayMessage(Call call) { return null; }
        Task<MessageType?> SetMonitoringBase(Call call) { return null; }
        Task<MessageType?> SetMonitoringLevel(Call call) { return null; }
        Task<MessageType?> SetNetworkProfile(Call call) { return null; }
        Task<MessageType?> SetVariableMonitoring(Call call) { return null; }
        Task<MessageType?> SetVariables(Call call) { return null; }
        Task<MessageType?> SignCertificate(Call call) { return null; }
        Task<MessageType?> TransactionEvent(Call call) { return null; }
        Task<MessageType?> UnpublishFirmware(Call call) { return null; }
    }
}
