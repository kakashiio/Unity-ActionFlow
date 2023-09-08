using UnityEngine;

namespace IO.Unity3D.Source.ActionFlow
{
    //******************************************
    //  
    //
    // @Author: Kakashi
    // @Email: john.cha@qq.com
    // @Date: 2023-09-07 18:14
    //******************************************
    public class PrintAction : IAction
    {
        public enum LogLevel
        {
            Debug,
            Error
        }

        private string _Message;
        private LogLevel _LogLevel;

        public PrintAction(string message, LogLevel logLevel = LogLevel.Debug)
        {
            _Message = message;
            _LogLevel = logLevel;
        }

        public void Start(IActionContext context)
        {
        }

        public void End(IActionContext context)
        {
        }

        public bool Execute(IActionContext context)
        {
            switch (_LogLevel)
            {
                case LogLevel.Debug:
                    Debug.Log(_Message);
                    break;
                case LogLevel.Error:
                    Debug.LogError(_Message);
                    break;
                default:
                    Debug.Log(_Message);
                    break;
            }
            
            return true;
        }
    }
}