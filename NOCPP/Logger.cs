using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOCPP
{
    public class Logger
    {
        // 用 Event 通知 Log 被寫入的事件 (支援外部註冊)
        public static event Action<string> LogCaptured;
        private static Lazy<Logger> _instance;  // 🔹 用 Lazy 管理 Singleton 實例
        private readonly string _logFilePath;
        private readonly bool _writeToFile;

        // 獲取單一實例 (支援自定義參數)
        public static Logger Instance => _instance.Value;

        // 靜態方法設定是否寫檔案 (只會在第一次呼叫時設定)
        public static void Configure(bool writeToFile = false)
        {
            _instance = new Lazy<Logger>(() => new Logger(writeToFile));
        }

        // 建構子: 根據 writeToFile 決定是否建立 logs 資料夾
        private Logger(bool writeToFile)
        {
            _writeToFile = writeToFile;

            if (_writeToFile)
            {
                string logDirectory = Path.Combine(AppContext.BaseDirectory, "logs");
                if (!Directory.Exists(logDirectory))
                {
                    Directory.CreateDirectory(logDirectory);
                }

                string logFileName = $"{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.log";
                _logFilePath = Path.Combine(logDirectory, logFileName);
            }
        }

        // 寫入 log 的方法 (根據 writeToFile 決定是否寫檔案)
        private void _Log(string level, string transaction, string action, string message)
        {
            string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss.ffffff zz} [{level}] [{transaction}] [{action}] {message}";
            Console.WriteLine(logMessage);

            if (_writeToFile && !string.IsNullOrEmpty(_logFilePath))
            {
                File.AppendAllText(_logFilePath, logMessage + Environment.NewLine);
            }
        }

        // 統一用單一 Log 方法 (讓 user 自行填入 level)
        public static void Log(Level level, string transaction, string action, string message) => Instance._Log(level.ToString(), transaction, action, message);

        public enum Level
        {
            INFO,
            WARN,
            ERROR
        }
    }
}
