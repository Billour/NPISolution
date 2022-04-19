using System;
using System.Collections.Generic;
using System.Text;

using Asus.Office.ExcelCore;
using AsusLibrary.Entity;
using System.Data;
using log4net;

namespace AsusLibrary.Logic
{
    /// <summary>
    /// ���oExcel ��ƪ�
    /// </summary>
    public class ExcelLogic:ExcelCore
    {
        /// <summary>
        /// Initial File
        /// </summary>
        /// <param name="sTemplate"></param>
        /// <param name="saveFile"></param>
        public ExcelLogic(string sTemplate, string saveFile)
            : base(sTemplate, saveFile)
        { }

        public ExcelLogic(string openFile)
            : base(openFile)
        { }

        private ILog  log = LogManager.GetLogger(typeof(ExcelLogic));

        /// <summary>
        /// �W��BOM���
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool GenerateBomFile(FormResponseEntity entity)
        {
            try
            {
                Open();

                RunData(entity);

                Save();
 
                return true;
            }
            catch(Exception ex)
            {
                log.Info("Upload BOM Fail="+ex.Message+ex.StackTrace);
                throw ex;
            }
            finally
            {
                Close();
            }

            return true;
        }

        public bool GenerateMainBomFile(FormResponseEntity entity)
        {
            try
            {
                Open();

                RunData(entity,true);

                Save();

                return true;
            }
            catch (Exception ex)
            {
                log.Info("Upload BOM Fail=" + ex.Message + ex.StackTrace);
                throw ex;
            }
            finally
            {
                Close();
            }

            return true;
        }

        public bool GeneratePriceFile(SortedList<string,PNPriceEntity> list)
        {
            try
            {
                Open();

                GenNotPriceFile(list);

                Save();

                return true;
            }
            catch (Exception ex)
            {
                log.Info("Upload BOM Fail=" + ex.Message + ex.StackTrace);
                throw ex;
            }
            finally
            {
                Close();
            }

            return true;
        }

        public bool GeneratePrice2File(SortedList<string, PNPrice2Entity> list)
        {
            try
            {
                Open();

                GenNotPrice2File(list);

                Save();

                return true;
            }
            catch (Exception ex)
            {
                log.Info("Upload BOM Fail=" + ex.Message + ex.StackTrace);
                throw ex;
            }
            finally
            {
                Close();
            }

            return true;
        }

        public bool GeneratePNFile(List<SourcerPNMapEntity> list)
        {
            try
            {
                Open();

                GenNotPNFile(list);

                Save();

                return true;
            }
            catch (Exception ex)
            {
                log.Info("Upload BOM Fail=" + ex.Message + ex.StackTrace);
                throw ex;
            }
            finally
            {
                Close();
            }

            return true;
        }

        private void GenNotPriceFile(SortedList<string,PNPriceEntity> list)
        {
            if (list.Count > 0)
            {
                stdSheet = (Excel.Worksheet)xlSheets.get_Item(1);

                xlCells = stdSheet.Cells;

                int rowIndex = 2;

                foreach (PNPriceEntity t in list.Values)
                {
                    xlCells[rowIndex, 3] = t.Site;
                    xlCells[rowIndex, 5] = t.PN;
                    xlCells[rowIndex, 6] = t.PNDesc;

                    rowIndex++;
                }

                xlCells.EntireColumn.AutoFit();
            }
        }

        private void GenNotPrice2File(SortedList<string, PNPrice2Entity> list)
        {
            if (list.Count > 0)
            {
                stdSheet = (Excel.Worksheet)xlSheets.get_Item(1);

                xlCells = stdSheet.Cells;

                int rowIndex = 2;

                foreach (PNPrice2Entity t in list.Values)
                {
                    xlCells[rowIndex, 2] = t.YearQ;
                    xlCells[rowIndex, 3] = t.Site;
                    xlCells[rowIndex, 5] = t.PN;
                    xlCells[rowIndex, 6] = t.PNDesc;

                    rowIndex++;
                }

                xlCells.EntireColumn.AutoFit();
            }
        }

        /// <summary>
        /// ���^�|��PN�C����
        /// �ت��O�b��MPN�PSourcer����� Map
        /// </summary>
        /// <param name="list"></param>
        private void GenNotPNFile(List<SourcerPNMapEntity> list)
        {
            if (list.Count > 0)
            {
                stdSheet = (Excel.Worksheet)xlSheets.get_Item(1);

                xlCells = stdSheet.Cells;

                int rowIndex = 2;

                foreach (SourcerPNMapEntity t in list)
                {

                    xlCells[rowIndex, 5] = t.PN;
                   

                    rowIndex++;
                }

                xlCells.EntireColumn.AutoFit();
            }
        }

        /// <summary>
        /// ���ͤU��BOM�d��
        /// </summary>
        /// <returns></returns>
        public bool GenerateTemplateBomUploadFile()
        {
            try
            {
                Open();

                RunBomDownloadTemplateFile();

                Save();
 
                return true;
            }
            catch(Exception ex)
            {
                log.Info("Upload BOM Fail="+ex.Message+ex.StackTrace);
                throw ex;
            }
            finally
            {
                Close();
            }
            
           

            return true;
        }

        public bool GenerateAdminBomFile(List<BOMBookingEntity> list)
        {
            try
            {
                Open();

                RunBomListFile(list);

                Save();

                return true;
            }
            catch (Exception ex)
            {
                log.Info("Upload BOM Fail=" + ex.Message + ex.StackTrace);
                throw ex;
            }
            finally
            {
                Close();
            }



            return true;
        }

        /// <summary>
        /// ���o�Ҧ���BOM�C��
        /// </summary>
        /// <param name="list"></param>
        private void RunBomListFile(List<BOMBookingEntity> list)
        {
            stdSheet = (Excel.Worksheet)xlSheets.get_Item(1);

            //���@��BOM
            rescSheet = (Excel.Worksheet)xlSheets.get_Item(1);

            rescSheet.Name = "BomList";

            xlCells = rescSheet.Cells;

            Excel.Range range2 = rescSheet.get_Range("A9", "J9");

            //Copy Format
            for (int i = 1; i < list.Count; i++)
            {
                int rowIndex = i + 9;

                range2.Copy(rescSheet.get_Range("A" + rowIndex, "J" + rowIndex));

            }

            int count=9;

            foreach(BOMBookingEntity t in list)
            {
                xlCells[count, 1] = t.EmpFullName;
                xlCells[count, 2]=t.BOMId ;
                xlCells[count, 3]=t.BOMStatus;
                xlCells[count, 4]=t.BOMDesc;

                xlCells[count, 5]=t.Revision;

                xlCells[count, 6]=t.RDAccount+t.RDName+t.RDPhoneNo;

                                
                xlCells[count, 8]=t.PVTTime;
                xlCells[count, 9]=t.PVTQty;
                xlCells[count, 10]=t.PVTLocation;
                xlCells[count, 10]=t.PVTLocationName;

                count++;
            }
            // �NBOM ���X��
        }


        /// <summary>
        /// ���oTemplate DownLoad File
        /// �w�]��50�����
        /// </summary>
        private void RunBomDownloadTemplateFile()
        {
            stdSheet = (Excel.Worksheet)xlSheets.get_Item(1);

            //���@��BOM
            rescSheet = (Excel.Worksheet)xlSheets.get_Item(1);

            rescSheet.Name = "BomList";

            xlCells = rescSheet.Cells;

            Excel.Range range2 = rescSheet.get_Range("B9", "J9");

            //Copy Format
            for (int i = 1; i < 50; i++)
            {
                int rowIndex = i + 9;

                range2.Copy(rescSheet.get_Range("B" + rowIndex, "J" + rowIndex));

            }

            AsusBomLogic logic = new AsusBomLogic();

            DataTable dt = logic.GetEMSDataTable();

            string strFormula = "";

            int emsRowIndex = 9;

            foreach (DataRow row in dt.Rows)
            {
                //strFormula += String.Format("{0}/{1},", row["ems_code"].ToString(), row["ems_name"].ToString());

                strFormula += String.Format("{0},",row["ems_code"].ToString());

                xlCells[emsRowIndex, 12] = String.Format("{0}/{1}", row["ems_code"].ToString(), row["ems_name"].ToString());

                emsRowIndex++;
            }

            if (strFormula.Length > 0)
            {
                strFormula = strFormula.Substring(0, strFormula.Length - 1);

                for (int i = 0; i < 50; i++)
                {
                    int rowIndex = i + 9;

                    ((Excel.Range)xlCells[rowIndex, 10]).Validation.Add(Excel.XlDVType.xlValidateList, Excel.XlDVAlertStyle.xlValidAlertStop, missing,strFormula, missing);

                }

            }
            else
            {
                throw new Exception("�L�k���oEMS����ơA�Ьd��");
            }

           

           

            

        }

        /// <summary>
        /// ���o PN Excel����T
        /// </summary>
        /// <param name="openFileName"></param>
        /// <returns></returns>
        public FormResponseEntity GetResponseData()
        {
            
            try
            {
                Open();

                FormResponseEntity entity = GetData();
 
                return entity;
            }
            catch(Exception ex)
            {
                log.Info("Upload PN Fail="+ex.Message+ex.StackTrace);
                throw ex;
            }
            finally
            {
                Close();
            }

            
        }

        /// <summary>
        /// ���oBOM��ƪ��B�z�M��
        /// </summary>
        /// <returns></returns>
        public List<BOMBookingEntity> GetBOMResponseDataList()
        {
            try
            {
                Open();

                List<BOMBookingEntity> list = GetBOMExcelDataList();

                

                return list;
            }
            catch(Exception ex)
            {
                log.Info("Get BOM Fail="+ex.Message+ex.StackTrace);
                throw ex;
            }
            finally
            {
                Close();
            }

            
        }

        private void RunData(FormResponseEntity entity)
        { 
            RunData(entity,false);
        }

        /// <summary>
        /// �Ҧ���Excel�U����ƳB�z�b��
        /// BOM���Y
        /// </summary>
        /// <param name="entity"></param>
        private void RunData(FormResponseEntity entity,bool isForMain)
        {
            stdSheet = (Excel.Worksheet) xlSheets.get_Item(1);

            stdSheet.Name = String.Format("BOM-List-{0}",DateTime.Now.ToString("yyyyMMdd"));

            xlCells = stdSheet.Cells;

            xlCells[1, 1] = entity.FormId; //(A,1)
            xlCells[1, 2] = entity.BOMList.Count.ToString(); // BOM ���ƶq

            //int count = 2;

            //xlCells[count, 2] = "PM���u�b��";
            //xlCells[count, 3] = "BOM�N��";;
            //xlCells[count, 4] = "�Ƹ�";
            //xlCells[count, 5] = "BOM Status";
            //xlCells[count, 6] = "Description";
            //xlCells[count, 7] = "Revision";
            //xlCells[count, 8] = "PVT Time";
            //xlCells[count, 9] = "PVT �ƶq";
            //xlCells[count, 10] = "PVT ���a";
            //xlCells[count, 11] = "MP Time";
            //xlCells[count, 12] = "MP Q1 Qty";
            //xlCells[count, 13] = "MP Q2 Qty";

            //Copy Format

            Excel.Range range1 = stdSheet.get_Range("B9","M9");
            int formatCount = 9;
            for (int i = 1; i < entity.BOMList.Count;i++)
            {
                int cellCount=formatCount+i;
                range1.Copy(stdSheet.get_Range("B"+cellCount, "M"+cellCount));

                
            }

            //Run BOM DATA
            int count = 9;
            foreach (BOMBookingEntity t in entity.BOMList)
            {
                //xlCells[count, 2] = t.EmpId;
                xlCells[count,2] =t.BOMId;
                              
                //xlCells[count, 4] =t.BOMName;
                xlCells[count, 3] =t.BOMStatus;
                xlCells[count, 4] =t.BOMDesc;
                xlCells[count, 5] =t.Revision;
                xlCells[count, 6] = t.RDOwner;
                xlCells[count, 8] =t.PVTTime;
                xlCells[count, 9] =t.PVTQty;
                xlCells[count, 10] =t.PVTLocationName;
                xlCells[count, 11] =t.MPTime;
                xlCells[count, 12] =t.MPQ1Qty;
                xlCells[count, 13] =t.MPQ2Qty;

                count++;
            }


            //Sheet2

            rescSheet = (Excel.Worksheet)xlSheets.get_Item(2);
            
            rescSheet.Name = entity.FormId;

            xlCells = rescSheet.Cells;

            int bomCount = entity.BOMList.Count;

            int bomStartIndex = 7;

            Excel.Range bomRng = (Excel.Range)xlCells[5, bomStartIndex]; //���oExcel ���զX�ƥ���
           
            //Insert Bom Column
            for (int i = 1; i < bomCount; i++)
            {

                Excel.Range column = bomRng.EntireColumn;

                column.Insert(Excel.XlInsertShiftDirection.xlShiftToRight, true);
                
                
            }


            //count = 2;
            //xlCells[count, 1] = "����";
            //xlCells[count, 2] = "����Ƹ�";
            //xlCells[count, 3] = "�~�W";
            //xlCells[count, 4] = "�W��";
            //xlCells[count, 5] = "�ե�";
            //xlCells[count, 6] = "�D/��";

            //Copy Header For Excel
            int columnIndex = bomStartIndex;
            for (int i = 0; i < bomCount; i++)
            {
                BOMBookingEntity booking = (BOMBookingEntity)entity.BOMList[i];

                //xlCells[1, columnIndex + i] =GetSubStr(booking.BOMId,9);
                //xlCells[2, columnIndex + i] = GetSubStr(booking.BOMName, 9);
                //xlCells[3, columnIndex + i] = GetSubStr(booking.BOMStatus, 9);
                //xlCells[4, columnIndex + i] = GetSubStr(booking.BOMDesc, 9);

                xlCells[1, columnIndex + i] = booking.BOMId;
                xlCells[2, columnIndex + i] = booking.BOMName;
                xlCells[3, columnIndex + i] = booking.BOMStatus;
                xlCells[4, columnIndex + i] = booking.BOMDesc;


                xlCells[5, columnIndex + i] = "�զX�ζq";
            }


            //xlCells[count, 7 + bomCount] = "Risky Buy";
            //xlCells[count, 8 + bomCount] = "long L/T(weeks)";
            //xlCells[count, 9 + bomCount] = "�Ƹ��ݩ�";
            //xlCells[count, 9 + bomCount] = "�Ƹ��ݩʦW��";
            //xlCells[count, 10 + bomCount] = "�[�J�ĤG�ӷ�";
            //xlCells[count, 10 + bomCount] = "�[�J�ĤG�ӷ��W��";
            //xlCells[count, 11 + bomCount] = "�[�J�ĤG�ӷ��Ƶ�";
            //xlCells[count, 12 + bomCount] = "EOL";
            //xlCells[count, 12 + bomCount] = "��s�H��";
            //xlCells[count, 13 + bomCount] = "��s�ɶ�";

            //Copy Format To Row
            count = 6; //�N��q�Ĥ�����ƶ}�l�p��

            Excel.Range range2 = rescSheet.get_Range("A6", "Z6");

            for (int i = 1; i < entity.PNList.Count;i++ )
            {
                int rowIndex = i + count;

                range2.Copy(rescSheet.get_Range("A" + rowIndex, "Z" + rowIndex));


            }

            //�[�J�M��ﶵ
            

            for (int i = 0; i < entity.PNList.Count; i++)
            {
                int rowIndex = i + count;

                //�[�J���� �O�_����
                ((Excel.Range)xlCells[rowIndex, 1]).Validation.Add(Excel.XlDVType.xlValidateList, Excel.XlDVAlertStyle.xlValidAlertStop, missing, "Y,N", missing);

                int start = 6 + bomCount;

                //�[�JRisky Buy +1
                ((Excel.Range)xlCells[rowIndex, start+1]).Validation.Add(Excel.XlDVType.xlValidateList, Excel.XlDVAlertStyle.xlValidAlertStop, missing, "Y,N", missing);

                //LT +2 


                //���o�Ƹ��ݩ� +3
                
                List<KeyValuePair<string, string>> propertyList = new BOMLogic().GetComponentPropertyList();

                string formula = ConvertString(propertyList);

                ((Excel.Range)xlCells[rowIndex, start+3]).Validation.Add(Excel.XlDVType.xlValidateList, Excel.XlDVAlertStyle.xlValidAlertStop, missing, formula, missing);

                //�[�J�ĤG�ӷ� ���M�� +4
                

                List<KeyValuePair<string, string>> addSourceList = new BOMLogic().GetAddSourceList();

                string sourceFormula = ConvertString(addSourceList);

                ((Excel.Range)xlCells[rowIndex, start+4]).Validation.Add(Excel.XlDVType.xlValidateList, Excel.XlDVAlertStyle.xlValidAlertStop, missing, sourceFormula, missing);

            }



            //�N��ƭ˶i�h
            foreach (FormPNEntity t in entity.PNList)
            {

                xlCells[count, 1] = t.Alert;

                xlCells[count, 2] = t.PN;

                if (t.Alert == "Y")
                {
                    ((Excel.Range)xlCells[count, 2]).Interior.ColorIndex = 44;
                }

                               
                

                xlCells[count, 3] = t.PNName;
                xlCells[count, 4] = t.PNDesc;
                xlCells[count, 5] = t.AssemblyNo;
                xlCells[count, 6] = t.IsSub;

                for (int i = 0; i < bomCount; i++)
                {
                    BOMBookingEntity booking = (BOMBookingEntity)entity.BOMList[i];

                    if (isForMain)
                    {
                        if (entity.BOMPNQtyList.ContainsKey(booking.BOMId+t.PN))
                        {
                            xlCells[count, 7 + i] = entity.BOMPNQtyList[booking.BOMId  + t.PN];
                        }
                    }
                    else
                    {
                        if (entity.BOMPNQtyList.ContainsKey(booking.BOMId + entity.FormId + t.PN))
                        {
                            xlCells[count, 7 + i] = entity.BOMPNQtyList[booking.BOMId + entity.FormId + t.PN];
                        }
                    }

                    

                }


                xlCells[count, 7 + bomCount] = t.RiskBuy;
                xlCells[count, 8 + bomCount] = t.LTWeeks;
                xlCells[count, 9 + bomCount] = t.PNProperty +"."+ t.PNPropertyName;
                xlCells[count, 10 + bomCount] = t.AddSource+"."+t.AddSourceName;
                
                xlCells[count, 11 + bomCount] = t.AddSourceComment;
                xlCells[count, 12+ bomCount] = t.EOL;
               

                count++;
            }

            
        }

        private string GetSubStr(string strValue, int length)
        {
            string returnValue = "";

            if (strValue == "")
            {
                returnValue = strValue;
            }
            else
            {
                if (strValue.Length < length)
                {
                    returnValue = strValue;
                }
                else
                {
                    returnValue = strValue.Substring(0, length);
                }
            }

            

            return returnValue;


        }

        private string ConvertString(List<KeyValuePair<string, string>> propertyList)
        {
            string returnStrValue = "";

            foreach(KeyValuePair<string, string> t in propertyList)
            {
                returnStrValue+= String.Format("{0},",t.Value);    
            }

            return returnStrValue;
        }

        /// <summary>
        /// ���o�Ҧ������
        /// </summary>
        /// <returns></returns>
        private FormResponseEntity GetData()
        {
            FormResponseEntity entity = new FormResponseEntity();

            stdSheet = (Excel.Worksheet)xlSheets.get_Item(1);

            xlCells = stdSheet.Cells;

            //���oFormId
            entity.FormId =((Excel.Range) xlCells[1, 1]).Text.ToString();

            int count = 9;

            List<BOMBookingEntity> bomList = new List<BOMBookingEntity>();

            while (((Excel.Range)xlCells[count, 2]).Text.ToString() != "")
            {
                BOMBookingEntity t = new BOMBookingEntity();

                //t.EmpId = ((Excel.Range)xlCells[count, 2]).Text.ToString(); //xlCells[count, 2].ToString();
                
                t.BOMId = ((Excel.Range)xlCells[count, 2]).Text.ToString(); //xlCells[count, 3].ToString();
                t.BOMStatus = ((Excel.Range)xlCells[count, 3]).Text.ToString(); //xlCells[count, 5].ToString();
                //t.BOMName = ((Excel.Range)xlCells[count, 4]).Text.ToString(); //xlCells[count, 4].ToString();
               
                t.BOMDesc = ((Excel.Range)xlCells[count, 4]).Text.ToString(); //xlCells[count, 6].ToString();
                t.Revision = ((Excel.Range)xlCells[count, 5]).Text.ToString(); //xlCells[count, 7].ToString();
                t.RDOwner = ((Excel.Range)xlCells[count, 6]).Text.ToString();
                t.PVTTime = ((Excel.Range)xlCells[count, 8]).Text.ToString(); //xlCells[count, 8].ToString();
                t.PVTQty = ((Excel.Range)xlCells[count, 9]).Text.ToString(); //xlCells[count, 9].ToString();
                t.PVTLocationName = ((Excel.Range)xlCells[count, 10]).Text.ToString(); //xlCells[count, 10].ToString();
                t.MPTime = ((Excel.Range)xlCells[count, 11]).Text.ToString(); //xlCells[count, 11].ToString();
                t.MPQ1Qty = ((Excel.Range)xlCells[count, 12]).Text.ToString(); //xlCells[count, 12].ToString();
                t.MPQ2Qty = ((Excel.Range)xlCells[count, 13]).Text.ToString(); //xlCells[count, 13].ToString();

                bomList.Add(t);

                count++;

            }

            entity.BOMList = bomList;

            //PN List

            //Sheet2 Sourcer�^�и��

            rescSheet = (Excel.Worksheet)xlSheets.get_Item(2);

            xlCells = rescSheet.Cells;

            int bomCount = entity.BOMList.Count;

            count = 6;

            List<FormPNEntity> pnList = new List<FormPNEntity>();



            while (((Excel.Range)xlCells[count, 1]).Text.ToString() != "")
            {
                if (((Excel.Range)xlCells[count, 1]).Text.ToString() == "Y")
                {
                    FormPNEntity pn = new FormPNEntity();

                    pn.Alert = ((Excel.Range)xlCells[count, 1]).Text.ToString();// xlCells[count, 1].ToString();

                    pn.PN = ((Excel.Range)xlCells[count, 2]).Text.ToString();//xlCells[count, 2].ToString();


                    pn.PNName = ((Excel.Range)xlCells[count, 3]).Text.ToString();//xlCells[count, 3].ToString();
                    pn.PNDesc = ((Excel.Range)xlCells[count, 4]).Text.ToString();//xlCells[count, 4].ToString();
                    pn.AssemblyNo = ((Excel.Range)xlCells[count, 5]).Text.ToString();
                    pn.IsSub = ((Excel.Range)xlCells[count, 6]).Text.ToString();

                    pn.RiskBuy = ((Excel.Range)xlCells[count, 7 + bomCount]).Text.ToString();
                    pn.LTWeeks = ((Excel.Range)xlCells[count, 8 + bomCount]).Text.ToString();//xlCells[count, 5 + bomCount].ToString();
                    
                    //Check Property
                    if (((Excel.Range)xlCells[count, 9 + bomCount]).Text.ToString() != "")
                    {
                        pn.PNProperty = ((Excel.Range)xlCells[count, 9 + bomCount]).Text.ToString().Substring(0, 1);//xlCells[count, 6 + bomCount].ToString();
                        pn.PNPropertyName = ((Excel.Range)xlCells[count, 9 + bomCount]).Text.ToString();//xlCells[count, 7 + bomCount].ToString();
                    }
                    else
                    {
                        pn.PNProperty = "0";
                        pn.PNPropertyName = "";
                    }

                    if (((Excel.Range)xlCells[count, 10 + bomCount]).Text.ToString() != "")
                    {
                        pn.AddSource = ((Excel.Range)xlCells[count, 10 + bomCount]).Text.ToString().Substring(0, 1);//xlCells[count, 8 + bomCount].ToString();
                        pn.AddSourceName = ((Excel.Range)xlCells[count, 10 + bomCount]).Text.ToString();//xlCells[count, 9 + bomCount].ToString();
                    }
                    else
                    {
                        pn.AddSource = "0";
                        pn.AddSourceName = "";
                        
                    }
                    
                   
                    
                    pn.AddSourceComment = ((Excel.Range)xlCells[count, 11 + bomCount]).Text.ToString();//xlCells[count, 10 + bomCount].ToString();
                    pn.EOL = ((Excel.Range)xlCells[count, 12 + bomCount]).Text.ToString();//xlCells[count, 11 + bomCount].ToString();
                    //pn.UpdateUser = ((Excel.Range)xlCells[count, 12 + bomCount]).Text.ToString();//xlCells[count, 12 + bomCount].ToString();
                    //pn.UpdateTime = ((Excel.Range)xlCells[count, 13 + bomCount]).Text.ToString();//xlCells[count, 13 + bomCount].ToString();

                    

                    pnList.Add(pn);
                }

                    count++;
                
            }

           

            entity.PNList = pnList;

            return entity;
        }

        /// <summary>
        /// ���o��Excel �ɮת�BOM����
        /// </summary>
        /// <returns></returns>
        private List<BOMBookingEntity> GetBOMExcelDataList()
        {
            stdSheet = (Excel.Worksheet)xlSheets.get_Item(1);

            xlCells = stdSheet.Cells;

            int count = 9;

            List<BOMBookingEntity> bomList = new List<BOMBookingEntity>();

            while (((Excel.Range)xlCells[count, 2]).Text.ToString() != "")
            {
                BOMBookingEntity t = new BOMBookingEntity();
                                
                t.BOMId = ((Excel.Range)xlCells[count, 2]).Text.ToString(); //xlCells[count, 3].ToString();
                t.BOMStatus = ((Excel.Range)xlCells[count, 3]).Text.ToString(); //xlCells[count, 5].ToString();
                t.BOMDesc = ((Excel.Range)xlCells[count, 4]).Text.ToString(); //xlCells[count, 4].ToString();

                t.Revision = ((Excel.Range)xlCells[count, 5]).Text.ToString(); //xlCells[count, 7].ToString();

                string owner = ((Excel.Range)xlCells[count, 6]).Text.ToString();

                if (owner.IndexOf("#") > -1)
                {
                    char[] delimiterChars = { '#' };

                    string[] words = owner.Split(delimiterChars);

                    t.RDName = words[0];
                    t.RDPhoneNo = words[1];
                }
                else
                {
                    t.RDName = owner;
                }

                
                t.PVTTime = ((Excel.Range)xlCells[count, 8]).Text.ToString(); //xlCells[count, 8].ToString();
                t.PVTQty = ((Excel.Range)xlCells[count, 9]).Text.ToString(); //xlCells[count, 9].ToString();
                t.PVTLocation = ((Excel.Range)xlCells[count, 10]).Text.ToString(); //xlCells[count, 10].ToString();
                t.PVTLocationName = ((Excel.Range)xlCells[count, 10]).Text.ToString(); //xlCells[count, 10].ToString();
                

                bomList.Add(t);

                count++;

            }

            rescSheet = (Excel.Worksheet)xlSheets.get_Item(2);

            return bomList;
        }

    }
}
