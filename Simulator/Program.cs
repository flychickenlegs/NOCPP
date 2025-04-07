using NOCPP;
using NOCPP.Interfaces;
using NOCPP.Schemas.v16;
using Simulator.HandleRequest.v16;
using Simulator.Scenarios;
using System.Text.Json;
using System.Transactions;
using System.Security.Cryptography.X509Certificates;

namespace Simulator
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, NOCPP!");
            Message message_cs = new Message();
            Message message_cp = new Message();
            RequestHandler requestHandler = new RequestHandler();
            message_cs.CreateRequestHandler(requestHandler);
            message_cp.CreateRequestHandler(requestHandler);

            string str_device = "";

            while (true)
            {
                Console.WriteLine("Please enter the device name (CS or CP): ");
                string str_input = Console.ReadLine();

                if (str_input == "CS" || str_input == "CP")
                {
                    str_device = str_input;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid entry, re-enter CS or CP.");
                }
            }
            Console.WriteLine($"You have selected {str_device}.");

            switch (str_device)
            {
                case "CS":
                    CancellationTokenSource ctsCS = new CancellationTokenSource();
                    CentralSystem cs = new CentralSystem("http://localhost:54321/", "1.6", ctsCS.Token);
                    cs.StartAsync();
                    cs.OnMessageReceived = async message => { await CS_AutoRun(message, cs); };
                    //CS_Send(cs); // Case2() will be used.

                    break;

                case "CP":
                    CancellationTokenSource ctsCP = new CancellationTokenSource();
                    ChargePoint cp = new ChargePoint("ws://localhost:54321/", "1.6", ctsCP.Token);
                    ScenarioManager scenarioManager = new ScenarioManager(cp);
                    cp.OnMessageReceived = async message => {
                        scenarioManager.FeedMessage(message);
                        //Console.WriteLine(message);
                    };

                    cp.StartAsync();
                    await Task.Delay(3000);

                    scenarioManager.Case1();
                    //scenarioManager.Case2();

                    break;
            }
            Console.ReadLine();
        }
        private static async Task CS_AutoRun(string message_received, CentralSystem cs)
        {

            Message message_cs = new Message();
            RequestHandler requestHandler = new RequestHandler();
            message_cs.CreateRequestHandler(requestHandler);

            HandleResult handleRes;
            MessageType msgType_receive;
            Call call_boot = new();
            Call call_receive = new();
            MessageType? callResp;
            bool bool_getRequest = false;
            handleRes = await message_cs.Handler(message_received);
            if (handleRes != null)
            {
                if (handleRes.IsCall)
                {
                    if (handleRes.Message is CallResult callResult)
                    {
                        await cs.SendAsync(Utility.ClassToJsonArray(callResult));
                        bool_getRequest = true;
                    }
                }
            }

        }

        private static async Task CS_Send(CentralSystem cs)
        {
            while (true)
            {
                Console.WriteLine("Please input number (1(RemoteStartTransaction) or 2(RemoteStopTransaction)):");
                string str_input = Console.ReadLine();

                if (int.TryParse(str_input, out int int_input))
                {
                    Console.WriteLine($"The integer you entered is:{int_input}.");
                }
                else
                {
                    Console.WriteLine("The input is not a valid integer!");
                }

                switch (int_input)
                {
                    case 1:
                        RemoteStartTransactionRequest remoteStartTransReq = new RemoteStartTransactionRequest()
                        { 
                            ConnectorId = 1,
                            IdTag = "W9X8Y7Z6"
                        };
                        Call call_remoteStartTrans = new Call()
                        {
                            UniqueId = Guid.NewGuid().ToString(),
                            Action = "RemoteStartTransaction",
                            Payload = Utility.CalssToJsonElement(remoteStartTransReq)
                        };
                        cs.SendAsync(Utility.ClassToJsonArray(call_remoteStartTrans));
                        break;
                    case 2:
                        RemoteStopTransactionRequest remoteStopTransReq = new RemoteStopTransactionRequest()
                        {
                            TransactionId = 12345
                        };
                        Call call_remoteStopTrans = new Call()
                        {
                            UniqueId = Guid.NewGuid().ToString(),
                            Action = "RemoteStopTransaction",
                            Payload = Utility.CalssToJsonElement(remoteStopTransReq)
                        };
                        cs.SendAsync(Utility.ClassToJsonArray(call_remoteStopTrans));
                        break;

                }

            }

        }
    }
}
