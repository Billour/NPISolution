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

                WriteLog("�妸�{���}�l:" + args[0] + " �{�b�}�l�ɶ��G" + DateTime.Now);

                string path = Environment.CurrentDirectory;

                if (path.Substring(path.Length - 1, 1) == "\\")
                {
                    path = path.Substring(0, path.Length - 1);
                }

                string fullPath = path;

                WriteLog("�妸�{���}�l-�ؿ�" + fullPath);

                string[] dllList = ConvertAllDllListFromDirectoty(fullPath);

                bool isSuccess = false;

                foreach (string s in dllList)
                {
                    WriteLog("�ؿ��ɮ�=" + s);

                    //�g�@��Log��DB,���A�����椤
                    WriteLog("Load Assembly");

                    //Load Assembly
                    Assembly assembly = Assembly.LoadFile(s);

                    //WriteLog("Load Assembly:" + s);

                    Type[] typeArray = assembly.GetTypes();

                    WriteLog("Load Assembly:GetType");

                    foreach (Type type in typeArray)
                    {

                        // WriteLog("Load Assembly:���o�Ҧ����U�O��Type=" + type.FullName);

                        if (type.IsClass == true && type.FullName.Equals(args[1]))
                        {
                            WriteLog("Load Assembly:GetClass=" + type.FullName);

                            WriteLog("�}�l�n���J��Class=" + args[1]);

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
                                case 0: //�N��妸�{������
                                    statusMessage = args[0] + "���G�G�{�����榳���A�Ьd��";
                                    break;
                                case 1: //�N��妸�{�����\
                                    statusMessage = args[0] + "���G�G�{�����榨�\�C";
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

                WriteLog("�妸�{������:" + args[1] + " �{�b�����ɶ��G" + DateTime.Now);
            }
            catch (Exception ex)
            {
                WriteLog("�{���o�{���i�w�������~�G");

                WriteLog("Exception=" + DateTime.Now.ToString("yyyy/MM/dd"));

                WriteLog(ex.InnerException + ex.Message + ex.StackTrace);
            }

            //string statusMessage = "";

            //try
            //{
            //    //Init log4Net Config File And Run
            //    log4net.Config.XmlConfigurator.Configure();


            //    WriteLog("�妸�{���}�l:" + args[0] + " �{�b�}�l�ɶ��G" + DateTime.Now);

            //    //�g�@��Log��DB,���A�����椤

            //    WriteLog("Load Assembly");
            //    Assembly assembly = Assembly.LoadFrom("NPIBatchLibrary.dll");

            //    WriteLog("Load Assembly:BatchLibrary.dll");

            //    Type[] typeArray = assembly.GetTypes();

            //    WriteLog("Load Assembly:GetType");


            //    foreach (Type type in typeArray)
            //    {

            //        //WriteLog("Load Assembly:typeArray=" + type.FullName + ";�Ѽ�=" + args[1]);

            //        WriteLog("Load Assembly:���o�Ҧ����U�O��Type=" + type.FullName);


            //        if (type.IsClass == true && type.FullName.Equals(args[1]))
            //        {
            //            WriteLog("Load Assembly:GetClass=" + type.FullName);

            //            WriteLog("�}�l�n���J��Class=" + args[1]);

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
            //                case 0: //�N��妸�{������
            //                    statusMessage = args[0] + "���G�G�{�����榳���A�Ьd��";
            //                    break;
            //                case 1: //�N��妸�{�����\
            //                    statusMessage = args[0] + "���G�G�{�����榨�\�C";
            //                    break;
            //            }

            //            WriteLog(statusMessage);

            //            break;
            //        }

            //    }

            //    WriteLog("�妸�{������:" + args[1] + " �{�b�����ɶ��G" + DateTime.Now);
            //    //�g�@��Log��DB,���A�������A�H�Υ��ѰT��
            //}
            //catch (Exception ex)
            //{
            //    WriteLog("�{���o�{���i�w�������~�G");

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
