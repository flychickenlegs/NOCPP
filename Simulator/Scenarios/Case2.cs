﻿using System;
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
        public async Task Case2()
        {
            Console.WriteLine("**************************************************");
            Console.WriteLine("Case 2: Remote charging.");
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
            Console.WriteLine("The user initiates a charging request through the backend/App.");
            Console.WriteLine("--------------------------------------------------");

            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Step 1: Wait \"RemoteStartTransaction\".");
            Console.WriteLine("--------------------------------------------------");
            msgType_get = await WaitForMessageAsync("", TimeSpan.FromSeconds(10));
            if (msgType_get is CallResult callRes_remoteStartTrans)
            {
                RemoteStartTransactionRequest remoteStartTransReq = JsonSerializer.Deserialize<RemoteStartTransactionRequest>(callRes_remoteStartTrans.Payload);

            }

            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Step 2: Send \"StatusNotification\".");
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
            _chargePoint.SendAsync(Utility.ClassToJsonArray(call_StatusNotification));

            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Step 3: Send \"Authorize\".");
            Console.WriteLine("--------------------------------------------------");
            AuthorizeRequest authorizeRequest = new AuthorizeRequest() { IdTag = str_IdTag };
            Call call_Authorize = new Call()
            {
                UniqueId = Guid.NewGuid().ToString(),
                Action = "Authorize",
                Payload = Utility.CalssToJsonElement(authorizeRequest)
            };
            _chargePoint.SendAsync(Utility.ClassToJsonArray(call_Authorize));
            if (msgType_get is CallResult callRes_auth)
            {
                AuthorizeResponse authResp = JsonSerializer.Deserialize<AuthorizeResponse>(callRes_auth.Payload);
            }

            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Step 4: Send \"StartTransaction\".");
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
            _chargePoint.SendAsync(Utility.ClassToJsonArray(call_StartTransaction));
            if (msgType_get is CallResult callRes_stTrans)
            {
                stTransResp = JsonSerializer.Deserialize<StartTransactionResponse>(callRes_stTrans.Payload);
            }

            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Step 5: Send \"StatusNotification\".");
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
            _chargePoint.SendAsync(Utility.ClassToJsonArray(call_StatusNotification));

            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Step 6: Send \"MeterValues\".");
            Console.WriteLine("--------------------------------------------------");
            MeterValuesRequest meterValuesRequest = new MeterValuesRequest();
            Call call_meterValues = new Call();
            for (int i = 0; i < 10; i++)
            {
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
                _chargePoint.SendAsync(Utility.ClassToJsonArray(call_meterValues));
                await Task.Delay(100);
            }


            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("The user initiates a stop request through the backend/app.");
            Console.WriteLine("--------------------------------------------------");

            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Step 7: Wait \"RemoteStopTransaction\".");
            Console.WriteLine("--------------------------------------------------");
            msgType_get = await WaitForMessageAsync("", TimeSpan.FromSeconds(10));
            if (msgType_get is CallResult callRes_remoteStopTrans)
            {
                RemoteStopTransactionRequest remoteStartTransReq = JsonSerializer.Deserialize<RemoteStopTransactionRequest>(callRes_remoteStopTrans.Payload);
            }


            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Step 8: Send \"StopTransaction\".");
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
            _chargePoint.SendAsync(Utility.ClassToJsonArray(call_StopTransaction));

            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Step 9: Send \"StatusNotification\".");
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
            _chargePoint.SendAsync(Utility.ClassToJsonArray(call_StatusNotification));


            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Step 10: Send \"StatusNotification\".");
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

            //cts_heartbeat
            Console.WriteLine("**************************************************");
            Console.WriteLine("Case 2 end.");
            Console.WriteLine("**************************************************\n");
        }
    }
}
