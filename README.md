# NOCPP - C# OCPP Toolkit

**NOCPP** is a modular C# toolkit designed for developing and testing custom communication protocols. It includes a JSON Schema-to-C# class generator, a core protocol class library, and a device simulator to streamline your development and testing workflow.

---

##  Project Structure
    NOCPP/ 
    ├── ClassGenerator  # Convert JSON Schema to C# classes 
    ├── NOCPP           # Core communication protocol logic 
    ├── Simulator       # Simulate communication for testing
    ├── LICENSE
    └── README.md
  
### ClassGenerator

- Converts JSON Schema into strongly-typed C# classes
- Supports attributes, nullable types, and naming conventions

### NOCPP

- Defines the protocol packet structure and logic
- Serialization and deserialization utilities
- Checksum validation, command routing, and error handling

### Simulator

- Simulates sending and receiving protocol packets
- Useful for testing device interactions or server behavior

---

## Requirements

- .NET 8 or later
- Visual Studio 2022

---

## NOCPP – Core Components

The ProtocolLib project provides the core logic for handling OCPP-style messages over WebSocket connections. It is designed to be modular, extensible, and simulator-friendly.

### Main Classes:
#### `Message`

- Represents a generic OCPP message structure.
- Allows users to register custom **action handlers** to process specific message types dynamically.

**Key Features:**
- Parse incoming JSON messages
- Register and invoke custom handlers based on message actions

```csharp
Message message = new Message();
HandleResult handleRes;
string message_received = "[2,\"ffebbfae-138c-446e-8d87-c2d6b3ae3f66\",\"BootNotification\",{\"chargePointVendor\":\"NOCPP\",\"chargePointModel\":\"SingleSocketCharger\",\"chargePointSerialNumber\":null,\"chargeBoxSerialNumber\":null,\"firmwareVersion\":null,\"iccid\":null,\"imsi\":null,\"meterType\":null,\"meterSerialNumber\":null}]";
handleRes = await message.Handler(message_received);
```

#### `MessageType`

- A class that defines the structure of the three OCPP message types.
- Provides static methods or constants to generate/validate specific message formats.

```csharp
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
```

#### `CentralSystem` & `ChargePoint`

- Lightweight WebSocket server and client implementations based on System.Net.WebSockets.
- Intended for testing and simulating OCPP communication flows.

```csharp
CancellationTokenSource ctsCS = new CancellationTokenSource();
CentralSystem cs = new CentralSystem("http://localhost:54321/", "1.6", ctsCS.Token);
cs.StartAsync();
cs.OnMessageReceived = async message => { await CS_AutoRun(message, cs); };
```

---

### ☕ Final Note

This project is still in its early stage — I basically just thought of it and started building it. There's no code review, no unit tests, and no stability tests... but hey, it works! 🤩

It's also my **first time writing a C# class library** and publishing a project on GitHub. I'm not a professional C# developer, so the library might not be super stable.

If you find any issues or have suggestions, feel free to **open an issue** or contact me via **email** at `peter2758047@gmail.com`.

That said, this is just a side project, so I may not be able to respond immediately — thanks for your understanding!

And finally, if you find this project useful, go ahead and use it under the license. Hope you enjoy it!
