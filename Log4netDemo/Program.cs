using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;
using System.IO;

namespace Log4netDemo
{
    class Program
    {

        static void Main(string[] args)
        {
            // LogHelper.InitLogConfigure();

            //var errorloger = log4net.LogManager.GetLogger("ErrorLog");
            //var infoLoger = log4net.LogManager.GetLogger("InfoLog");
            //infoLoger.Info("This Info Log");
            //errorloger.Error("This Error Log111");

            Test t = new Test();
            t.TestLog();
	   

            Console.Read();
        }
    }

    public class Test
    {
        public void TestLog()
        {
            try
            {

                int i = 0;
                int j = 1;
                var k = j / i;
            }
            catch (Exception ex)
            {
                LogHelper.WriteErrorLog(ex, "");
                
            }

        }
    }


    public class LogHelper
    {
        static ILog ErrorLog
        {
            get
            {
                return log4net.LogManager.GetLogger("ErrorLog");
            }
        }
        static ILog InfoLog
        {
            get
            {
                return log4net.LogManager.GetLogger("InfoLog");
            }
        }
        public static void WriteErrorLog(Exception ex, string message)
        {
            ErrorLog.Error(string.Format("异常消息：{0} \r\n堆栈信息：{1} \r\n", ex.Message, ex.StackTrace));
        }

        public static void WriteInfoLog(string message)
        {
            InfoLog.Info(message);
        }


    }

}
