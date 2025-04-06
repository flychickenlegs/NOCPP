using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using NOCPP;
using NOCPP.Schemas.v16;

namespace Simulator.Scenarios
{
    internal partial class ScenarioManager
    {
        public async Task Case1()
        {
            Console.WriteLine("**************************************************");
            Console.WriteLine("Case 1: On-site charging.");
            Console.WriteLine("**************************************************");
            string str_message = "";
            MessageType msgType_get = null;
            string str_IdTag = "W1X2Y3Z4";


            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Step 0: Send \"BootNotification\".");
            Console.WriteLine("--------------------------------------------------");
            BootNotificationRequest bootNotificationRequest = new BootNotificationRequest()
            {
                ChargePointModel = "SingleSocketCharger",
                ChargePointVendor = "NOCPP"
            };
            Call call_boot = new Call()
            {
                UniqueId = Guid.NewGuid().ToString(),
                Action = "BootNotification",
                Payload = Utility.CalssToJsonElement(bootNotificationRequest)
            };
            await _chargePoint.SendAsync(Utility.ClassToJsonArray(call_boot));
            msgType_get = await WaitForMessageAsync(call_boot.UniqueId, TimeSpan.FromSeconds(10));
            if (msgType_get is CallResult callRes_boot)
            {
                BootNotificationResponse bootResp = JsonSerializer.Deserialize<BootNotificationResponse>(callRes_boot.Payload);

                CancellationTokenSource cts_heartbeat = new CancellationTokenSource();
                CP_Heartbeat(bootResp.Interval, cts_heartbeat.Token);
            }


            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Step 1: Send \"StatusNotification\".");
            Console.WriteLine("--------------------------------------------------");
            StatusNotificationRequest statusNotificationRequest;
            Call call_StatusNotification;
            statusNotificationRequest = new StatusNotificationRequest()
            {
                ConnectorId = 1,
                ErrorCode = StatusNotificationRequestErrorCode.NoError,
                Status = StatusNotificationRequestStatus.Preparing,
            };
            call_StatusNotification = new Call()
            {
                UniqueId = Guid.NewGuid().ToString(),
                Action = "StatusNotification",
                Payload = Utility.CalssToJsonElement(statusNotificationRequest)
            };
            await _chargePoint.SendAsync(Utility.ClassToJsonArray(call_StatusNotification));
            msgType_get = await WaitForMessageAsync(call_StatusNotification.UniqueId, TimeSpan.FromSeconds(10));


            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Step 2: Send \"Authorize\".");
            Console.WriteLine("--------------------------------------------------");
            AuthorizeRequest authorizeRequest = new AuthorizeRequest() { IdTag = str_IdTag };
            Call call_Authorize = new Call()
            {
                UniqueId = Guid.NewGuid().ToString(),
                Action = "Authorize",
                Payload = Utility.CalssToJsonElement(authorizeRequest)
            };
            await _chargePoint.SendAsync(Utility.ClassToJsonArray(call_Authorize));
            msgType_get = await WaitForMessageAsync(call_Authorize.UniqueId, TimeSpan.FromSeconds(10));
            if (msgType_get is CallResult callRes_auth)
            {
                AuthorizeResponse authResp = JsonSerializer.Deserialize<AuthorizeResponse>(callRes_auth.Payload);
            }


            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Step 3: Send \"StartTransaction\".");
            Console.WriteLine("--------------------------------------------------");
            StartTransactionResponse stTransResp = new();
            StartTransactionRequest startTransactionRequest = new StartTransactionRequest()
            {
                ConnectorId = 1,
                IdTag = str_IdTag,
                //MeterStart = 0,
                //Timestamp = Utility.dtOffset_UTCNow
            };
            Call call_StartTransaction = new Call()
            {
                UniqueId = Guid.NewGuid().ToString(),
                Action = "StartTransaction",
                Payload = Utility.CalssToJsonElement(startTransactionRequest)
            };
            await _chargePoint.SendAsync(Utility.ClassToJsonArray(call_StartTransaction));
            msgType_get = await WaitForMessageAsync(call_StartTransaction.UniqueId, TimeSpan.FromSeconds(10));
            if (msgType_get is CallResult callRes_stTrans)
            {
                stTransResp = JsonSerializer.Deserialize<StartTransactionResponse>(callRes_stTrans.Payload);
            }


            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Step 4: Send \"StatusNotification\".");
            Console.WriteLine("--------------------------------------------------");
            statusNotificationRequest = new StatusNotificationRequest()
            {
                ConnectorId = 1,
                ErrorCode = StatusNotificationRequestErrorCode.NoError,
                Status = StatusNotificationRequestStatus.Charging,
            };
            call_StatusNotification = new Call()
            {
                UniqueId = Guid.NewGuid().ToString(),
                Action = "StatusNotification",
                Payload = Utility.CalssToJsonElement(statusNotificationRequest)
            };
            await _chargePoint.SendAsync(Utility.ClassToJsonArray(call_StatusNotification));

            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Step 5: Send \"MeterValues\".");
            Console.WriteLine("--------------------------------------------------");
            MeterValuesRequest meterValuesRequest = new MeterValuesRequest();
            Call call_meterValues = new Call();
            for (int i = 0; i < 10; i++)
            {

                Console.WriteLine($"MeterValues {i}.");
                meterValuesRequest = new MeterValuesRequest()
                {
                    ConnectorId = 1,
                    MeterValue = new List<MeterValuesRequest_meterValue>
                    {
                        new MeterValuesRequest_meterValue
                        {
                            Timestamp = Utility.dtOffset_UTCNow,
                            SampledValue = new List<MeterValuesRequest_sampledValue>
                            {
                                new MeterValuesRequest_sampledValue
                                {
                                    Value = (i).ToString(),
                                    Context = MeterValuesRequest_sampledValueContext.Sample_Periodic,
                                    Format = MeterValuesRequest_sampledValueFormat.Raw,
                                    Measurand = MeterValuesRequest_sampledValueMeasurand.Energy_Active_Import_Register,
                                    Phase = MeterValuesRequest_sampledValuePhase.L1,
                                    Location = MeterValuesRequest_sampledValueLocation.Outlet,
                                    Unit = MeterValuesRequest_sampledValueUnit.Wh
                                }
                            }
                        }
                    },
                };
                call_meterValues = new Call()
                {
                    UniqueId = Guid.NewGuid().ToString(),
                    Action = "MeterValues",
                    Payload = Utility.CalssToJsonElement(meterValuesRequest)
                };
                await _chargePoint.SendAsync(Utility.ClassToJsonArray(call_meterValues));
                msgType_get = await WaitForMessageAsync(call_meterValues.UniqueId, TimeSpan.FromSeconds(10));
                await Task.Delay(1000);
            }

            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Step 6: Send \"StopTransaction\".");
            Console.WriteLine("--------------------------------------------------");
            StopTransactionRequest stopTransactionRequest = new StopTransactionRequest()
            {
                IdTag = str_IdTag,
                MeterStop = 10,
                Timestamp = Utility.dtOffset_UTCNow,
                TransactionId = stTransResp.TransactionId,
                Reason = StopTransactionRequestReason.EVDisconnected
            };
            Call call_StopTransaction = new Call()
            {
                UniqueId = Guid.NewGuid().ToString(),
                Action = "StopTransaction",
                Payload = Utility.CalssToJsonElement(stopTransactionRequest)
            };
            await _chargePoint.SendAsync(Utility.ClassToJsonArray(call_StopTransaction));
            msgType_get = await WaitForMessageAsync(call_StopTransaction.UniqueId, TimeSpan.FromSeconds(10));

            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Step 7: Send \"StatusNotification\".");
            Console.WriteLine("--------------------------------------------------");
            statusNotificationRequest = new StatusNotificationRequest()
            {
                ConnectorId = 1,
                ErrorCode = StatusNotificationRequestErrorCode.NoError,
                Status = StatusNotificationRequestStatus.Finishing,
            };
            call_StatusNotification = new Call()
            {
                UniqueId = Guid.NewGuid().ToString(),
                Action = "StatusNotification",
                Payload = Utility.CalssToJsonElement(statusNotificationRequest)
            };
            await _chargePoint.SendAsync(Utility.ClassToJsonArray(call_StatusNotification));
            msgType_get = await WaitForMessageAsync(call_StatusNotification.UniqueId, TimeSpan.FromSeconds(10));


            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Step 8: Send \"StatusNotification\".");
            Console.WriteLine("--------------------------------------------------");
            statusNotificationRequest = new StatusNotificationRequest()
            {
                ConnectorId = 1,
                ErrorCode = StatusNotificationRequestErrorCode.NoError,
                Status = StatusNotificationRequestStatus.Available,
            };
            call_StatusNotification = new Call()
            {
                UniqueId = Guid.NewGuid().ToString(),
                Action = "StatusNotification",
                Payload = Utility.CalssToJsonElement(statusNotificationRequest)
            };
            await _chargePoint.SendAsync(Utility.ClassToJsonArray(call_StatusNotification));
            msgType_get = await WaitForMessageAsync(call_StatusNotification.UniqueId, TimeSpan.FromSeconds(10));

            Console.WriteLine("**************************************************");
            Console.WriteLine("Case 1 end.");
            Console.WriteLine("**************************************************\n");
        }

    }
}
