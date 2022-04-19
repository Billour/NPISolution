using System;
using System.Collections.Generic;
using System.Text;

using System.Reflection;
using System.IO;


namespace BatchConsole
{
    class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(Program));
        
        static void Main(string[] args)
        {
            string statusMessage = "";

            try
            {
                //Init log4Net Config File And Run
                log4net.Config.XmlConfigurator.Configure();

                WriteLog("批次程式開始:" + args[0] + " 現在開始時間：" + DateTime.Now);

                string path = Environment.CurrentDirectory;

                if (path.Substring(path.Length - 1, 1) == "\\")
                {
                    path = path.Substring(0, path.Length - 1);
                }

                string fullPath = path;

                WriteLog("批次程式開始-目錄" + fullPath);

                string[] dllList = ConvertAllDllListFromDirectoty(fullPath);

                bool isSuccess = false;

                foreach (string s in dllList)
                {
                    WriteLog("目錄檔案=" + s);

                    //寫一份Log至DB,狀態為執行中
                    WriteLog("Load Assembly");

                    //Load Assembly
                    Assembly assembly = Assembly.LoadFile(s);

                    //WriteLog("Load Assembly:" + s);

                    Type[] typeArray = assembly.GetTypes();

                    WriteLog("Load Assembly:GetType");

                    foreach (Type type in typeArray)
                    {

                        // WriteLog("Load Assembly:取得所有的各別的Type=" + type.FullName);

                        if (type.IsClass == true && type.FullName.Equals(args[1]))
                        {
                            WriteLog("Load Assembly:GetClass=" + type.FullName);

                            WriteLog("開始要載入此Class=" + args[1]);

                            object ibaseObject = Activator.CreateInstance(type);

                            WriteLog("Load Assembly:CreateInstance");

                            MethodInfo method = type.GetMethod("DoJob");

                            WriteLog("Load Assembly:Invoke Method");

                            WriteLog("Length=" + args.Length);

                            object[] obj = new object[] { args[0] };

                            int returnValue = (int)method.Invoke(ibaseObject, obj);

                            WriteLog("Load Assembly:GetValue");

                            switch (returnValue)
                            {
                                case 0: //代表批次程式有錯
                                    statusMessage = args[0] + "結果：程式執行有錯，請查明";
                                    break;
                                case 1: //代表批次程式成功
                                    statusMessage = args[0] + "結果：程式執行成功。";
                                    break;
                            }

                            isSuccess = true;

                            WriteLog(statusMessage);

                            break;
                        }

                    }

                    if (isSuccess)
                    {
                        break;
                    }
                }

                WriteLog("批次程式結束:" + args[1] + " 現在完成時間：" + DateTime.Now);
            }
            catch (Exception ex)
            {
                WriteLog("程式發現不可預期之錯誤：");

                WriteLog("Exception=" + DateTime.Now.ToString("yyyy/MM/dd"));

                WriteLog(ex.InnerException + ex.Message + ex.StackTrace);
            }

            //string statusMessage = "";

            //try
            //{
            //    //Init log4Net Config File And Run
            //    log4net.Config.XmlConfigurator.Configure();


            //    WriteLog("批次程式開始:" + args[0] + " 現在開始時間：" + DateTime.Now);

            //    //寫一份Log至DB,狀態為執行中

            //    WriteLog("Load Assembly");
            //    Assembly assembly = Assembly.LoadFrom("NPIBatchLibrary.dll");

            //    WriteLog("Load Assembly:BatchLibrary.dll");

            //    Type[] typeArray = assembly.GetTypes();

            //    WriteLog("Load Assembly:GetType");


            //    foreach (Type type in typeArray)
            //    {

            //        //WriteLog("Load Assembly:typeArray=" + type.FullName + ";參數=" + args[1]);

            //        WriteLog("Load Assembly:取得所有的各別的Type=" + type.FullName);


            //        if (type.IsClass == true && type.FullName.Equals(args[1]))
            //        {
            //            WriteLog("Load Assembly:GetClass=" + type.FullName);

            //            WriteLog("開始要載入此Class=" + args[1]);

            //            object ibaseObject = Activator.CreateInstance(type);



            //            WriteLog("Load Assembly:CreateInstance");

            //            MethodInfo method = type.GetMethod("DoJob");

            //            WriteLog("Load Assembly:Invoke Method");



            //            WriteLog("Length=" + args.Length);


            //            object[] obj = new object[] { args[0] };

            //            int returnValue = (int)method.Invoke(ibaseObject, obj);

            //            WriteLog("Load Assembly:GetValue");

            //            switch (returnValue)
            //            {
            //                case 0: //代表批次程式有錯
            //                    statusMessage = args[0] + "結果：程式執行有錯，請查明";
            //                    break;
            //                case 1: //代表批次程式成功
            //                    statusMessage = args[0] + "結果：程式執行成功。";
            //                    break;
            //            }

            //            WriteLog(statusMessage);

            //            break;
            //        }

            //    }

            //    WriteLog("批次程式結束:" + args[1] + " 現在完成時間：" + DateTime.Now);
            //    //寫一份Log至DB,狀態為完成，以及失敗訊息
            //}
            //catch (Exception ex)
            //{
            //    WriteLog("程式發現不可預期之錯誤：");

            //    WriteLog("Exception=" + DateTime.Now.ToString("yyyy/MM/dd"));

            //    WriteLog(ex.InnerException + ex.Message + ex.StackTrace);
            //}
        }

        public static void WriteLog(string logMessage)
        {

            log.Info(logMessage);
        }

        private static string[] ConvertAllDllListFromDirectoty(string fullPath)
        {

            if (!Directory.Exists(fullPath))
            {
                throw new Exception("Directory Is Not Exist");
            }

            return Directory.GetFiles(fullPath, "*.dll");

        }
    }
}
