using System;
using System.Collections.Generic;
using System.Text;
using Word;
using System.Runtime.InteropServices;

namespace Asus.Office.WordCore
{
    public class WordDoc
    {
        
        public static Object Missing = System.Reflection.Missing.Value;
        public static Object missing = System.Reflection.Missing.Value;
        
        protected object oEndOfDoc = "\\endofdoc"; /* \endofdoc is a predefined bookmark */


        protected Application wApp;
        protected Document wDoc;

        /// <summary>
        /// ���s�ɤ�Word�ɮצW�١A�ݭn����ؿ�
        /// </summary>
        protected string sFile;
        
        /// <summary>
        /// �}�Ҥ�Word�d���A�̦n�O�n���A
        /// �i�H��֫ܦh�{����@���ɶ�
        /// </summary>
        protected string sTemplate;

        /// <summary>
        /// Constructor ���Word�ɮ�
        /// </summary>
        /// <param name="tempalteFile"></param>
        /// <param name="saveFile"></param>
        public WordDoc(string tempalteFile, string saveFile)
        {
            wApp = new ApplicationClass();
            
            wDoc = new Document();

            sFile = saveFile;
            
            sTemplate = tempalteFile;
          
            
        }

        /// <summary>
        /// �}�Ҥ@��Word�ɮ�
        /// </summary>
        /// <param name="openFile"></param>
        public WordDoc(string openFile)
        {

            wApp = new ApplicationClass();

            wDoc = new Document();
                        
            sTemplate = openFile;

        }


        /// <summary>
        /// �}���ɮ�
        /// </summary>
        /// <param name="FileName"></param>
        public void Open()
        {
            
                wApp.Visible = true;
                Boolean visible = true;

                Object x, y;
                x = sTemplate;
                y = visible;
                wApp.Visible = false;
                wDoc = wApp.Documents.Open(ref x, ref Missing, ref  Missing, ref  Missing, ref  Missing,
                    ref Missing, ref  Missing, ref  Missing, ref  Missing, ref  Missing, ref  Missing,
                    ref y, ref Missing, ref Missing, ref Missing, ref Missing);

                
            
        }

        protected void Save()
        {
            Object FileName;
            FileName = sFile;
            wDoc.SaveAs(ref FileName, ref  Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing);
        }

        protected void Close()
        {
            Boolean visible;
            Object y;
            visible = true;
            y = visible;
            wDoc.Close(ref y, ref Missing, ref Missing);

            visible = false;
            y = visible;
            wApp.Quit(ref y, ref Missing, ref Missing);

            Marshal.ReleaseComObject(wApp);

            Marshal.ReleaseComObject(wDoc);

            wDoc = null;

            wApp = null;

            //Let GC Collection
            GC.Collect();
        }

        //public bool InsertPic(int number, string title, string fileName)
        //{
        //    try
        //    {
        //        //��@��Title
        //        Paragraph oPara1;
        //        object oRng = wDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
        //        oPara1 = wDoc.Content.Paragraphs.Add(ref oRng);
        //        oPara1.Range.Text = title;
        //        oPara1.Range.Font.Bold = 1;
        //        oPara1.Format.SpaceAfter = 12;    //24 pt spacing after paragraph.
        //        oPara1.Range.InsertParagraphAfter();

        //        Paragraph oPara2;
        //        Range oRng1 = wDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
        //        oPara2 = wDoc.Content.Paragraphs.Add(ref oRng);
        //        oPara2.Range.Text = "";
        //        oPara2.Format.SpaceAfter = 1;
        //        oPara2.Range.InsertParagraphAfter();



        //        //Insert another paragraph.
        //        Paragraph oPara3;
        //        oRng = wDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
        //        oPara3 = wDoc.Content.Paragraphs.Add(ref oRng);
        //        oPara3.Range.Text = "�y�{�ԭz..����";
        //        oPara3.Range.Font.Bold = 0;
        //        oPara3.Format.SpaceAfter = 12;
        //        oPara3.Range.InsertParagraphAfter();

        //        Paragraph oPara4;
        //        oRng = wDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
        //        oPara4 = wDoc.Content.Paragraphs.Add(ref oRng);
        //        oPara4.Range.Text = "here is a table:";
        //        oPara4.Range.Font.Bold = 0;
        //        oPara4.Format.SpaceAfter = 12;
        //        oPara4.Range.InsertParagraphAfter();



        //        //��@�i�Ϥ�

        //        Object oMissed = wDoc.Paragraphs[number * 4 + 2].Range; //the position you want to insert
        //        Object oLinkToFile = false;  //default
        //        Object oSaveWithDocument = true;//default
        //        wDoc.InlineShapes.AddPicture(fileName, ref  oLinkToFile, ref  oSaveWithDocument, ref  oMissed);

        //        //��Table

        //        if (number == 0)
        //        {

        //        }


        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        //private bool InsertTitle(string name, string version, string systemName, string company)
        //{
        //    try
        //    {
        //        //�]�w�W��

        //        bool isFlag = SetBookMarkValue("DBNameBookMark", name);

        //        if (!isFlag)
        //        {
        //            throw new Exception("�L�k���J�W�ٸ��");
        //        }

        //        if (isFlag)
        //        {

        //            isFlag = SetBookMarkValue("VersionBookMark", version);

        //            if (!isFlag)
        //            {
        //                throw new Exception("�L�k���J�������");
        //            }
        //        }

        //        if (isFlag)
        //        {

        //            isFlag = SetBookMarkValue("SystemNameBookMark", systemName);

        //            if (!isFlag)
        //            {
        //                throw new Exception("�L�k���J�t�ΦW�ٸ��");
        //            }
        //        }

        //        if (isFlag)
        //        {

        //            isFlag = SetBookMarkValue("CompanyBookMark", company);

        //            if (!isFlag)
        //            {
        //                throw new Exception("�L�k���J���q�W�ٸ��");
        //            }
        //        }

        //        return true;
        //    }
        //    catch (Exception err)
        //    {
        //        log.Info("���~��]=" + err.InnerException.ToString());
        //        throw;
        //    }
        //}

        #region ���ͤ��

        ///// <summary>
        ///// ��J�����
        ///// </summary>
        ///// <param name="docType"></param>
        ///// <returns></returns>
        //public bool InsertDomainData(Type docType)
        //{
        //    try
        //    {
        //        CaptureDocUtil logic = new CaptureDocUtil();

        //        log.Info("�}�l���^�Ҧ��n���ͪ����C��");

        //        //���^�Ҧ�����ƭ�
        //        List<CaptureFlowMap> list = logic.GetAllCaptureDocList(docType);

        //        log.Info("���\���^�Ҧ������C��");

        //        foreach (CaptureFlowMap t in list)
        //        {
        //            log.Info("�إ�Title:" + t.ID + t.Name);
        //            Paragraph oPara1;
        //            object oRng = wDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
        //            oPara1 = wDoc.Content.Paragraphs.Add(ref oRng);
        //            oPara1.Range.Text = t.ID + t.Name;
        //            oPara1.Range.Font.Bold = 1;
        //            oPara1.Format.SpaceAfter = 0;    //24 pt spacing after paragraph.
        //            oPara1.Range.InsertParagraphAfter();


        //            Paragraph oPara2;
        //            oRng = wDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
        //            oPara2 = wDoc.Content.Paragraphs.Add(ref oRng);
        //            oPara2.Range.Text = "";
        //            oPara2.Format.SpaceAfter = 1;
        //            oPara2.Range.InsertParagraphAfter();

        //            Object oMissed = oPara2.Range; //the position you want to insert
        //            Object oLinkToFile = false;  //default
        //            Object oSaveWithDocument = true;//default


        //            Table oTable;
        //            //�Ĥ@��table ��Ϥ����
        //            oTable = wDoc.Tables.Add(oPara2.Range, 1, 1, ref Missing, ref Missing);

        //            oTable.Cell(1, 1).Range.InlineShapes.AddPicture(LoginInfo.CaptureSavePath + DateTime.Now.ToString("yyyyMMdd") + "\\" + t.SaveFileName, ref  oLinkToFile, ref  oSaveWithDocument, ref  Missing);

        //            Paragraph oPara3;
        //            oRng = wDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
        //            oPara3 = wDoc.Content.Paragraphs.Add(ref oRng);
        //            oPara3.Range.Text = t.Name + "�y�{";
        //            oPara3.Range.Font.Bold = 0;
        //            oPara3.Format.SpaceAfter = 0;
        //            oPara3.Range.InsertParagraphAfter();

        //            log.Info("�}�l�b�ؤ�󻡩�");

        //            foreach (ContentDescriptionMap e2 in t.DescriptionList)
        //            {
        //                Table oTable1;
        //                oTable1 = wDoc.Tables.Add(oPara3.Range, 1, 1, ref Missing, ref Missing);

        //                log.Info("��󤺮e�p�U");
        //                log.Info(e2.Content);
        //                oTable1.Cell(1, 1).Range.Text = e2.Content;
        //            }

        //            Paragraph oPara4;
        //            oRng = wDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
        //            oPara4 = wDoc.Content.Paragraphs.Add(ref oRng);
        //            oPara4.Range.Text = t.Name + "����";
        //            oPara4.Format.SpaceAfter = 1;
        //            oPara4.Range.InsertParagraphAfter();

        //            ////�ĤG��Table
        //            log.Info("�إ�Entity Table" + "��Ƶ���=" + t.EntityList.Count);
        //            //int number=1;
        //            foreach (EntityProtoTypeMap e1 in t.EntityList)
        //            {
        //                //Table oTable1;
        //                //oTable1 = wDoc.Tables.Add(oPara4.Range, 2, 1, ref Missing, ref Missing);
        //                //oTable1.Rows[1].Height=200; 

        //                //////////��@��Title
        //                ////log.Info("Create Table2 ");

        //                log.Info("Table=" + e1.EntityId + e1.EntityName + "��Ƥ��=" + e1.EntityList.Count);
        //                Table oTable2;

        //                oTable2 = wDoc.Tables.Add(oPara4.Range, 1, 1, ref Missing, ref Missing);
        //                oTable2.Cell(1, 1).Range.Text = e1.EntityId + e1.EntityName;

        //                Paragraph oPara6;
        //                oRng = wDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
        //                oPara6 = wDoc.Content.Paragraphs.Add(ref oRng);
        //                oPara6.Format.SpaceAfter = 0;
        //                oPara6.Range.InsertParagraphAfter();

        //                log.Info("Table2 Entity Row=" + e1.EntityList.Count);
        //                Table oTable3;
        //                oTable3 = wDoc.Tables.Add(oPara6.Range, e1.EntityList.Count + 1, 5, ref Missing, ref Missing);

        //                //oTable3.Select();

        //                //log.Info("Table2 Entity Title");
        //                ////Set Title
        //                oTable3.Cell(2, 1).Range.Text = "No";
        //                oTable3.Cell(2, 2).Range.Text = "Id";
        //                oTable3.Cell(2, 3).Range.Text = "Name";
        //                oTable3.Cell(2, 4).Range.Text = "Control";
        //                oTable3.Cell(2, 5).Range.Text = "Remark";


        //                log.Info(e1.EntityId + e1.EntityName + "�ѼƦp�U");

        //                for (int i = 0; i < e1.EntityList.Count; i++)
        //                {
        //                    log.Info("Row=" + (i + 1) + ";Name=" + docType.Name);
        //                    EntityTable doc = (EntityTable)e1.EntityList[i];

        //                    oTable3.Cell(i + 3, 1).Range.Text = doc.No;

        //                    oTable3.Cell(i + 3, 2).Range.Text = doc.EntityId;
        //                    oTable3.Cell(i + 3, 3).Range.Text = doc.Name;
        //                    oTable3.Cell(i + 3, 4).Range.Text = doc.Control;
        //                    oTable3.Cell(i + 3, 5).Range.Text = doc.ReMark;

        //                }

        //            }

        //        }

        //        return true;
        //    }
        //    catch (Exception err)
        //    {
        //        CloseWord();
        //        throw new Exception(err.InnerException.ToString());
        //        return false;
        //    }
        //}
        #endregion

        //public bool SetBookMarkValue(string bookMarkTagName, string bookMarkValue)
        //{
        //    Object oBookMarkName = bookMarkTagName;
        //    try
        //    {
        //        wDoc.Bookmarks.get_Item(ref oBookMarkName).Range.Select();
        //        wDoc.Bookmarks.get_Item(ref oBookMarkName).Range.Text = bookMarkValue;

        //    }
        //    catch (Exception err)
        //    {
        //        log.Info("����BookMarkValue Error Message=" + err.Message + err.StackTrace);
        //        throw;
        //    }

        //    return true;

        //}

        /// <summary>
        /// ���ͷs�����R�����
        /// </summary>
        /// <param name="docType">Type type</param>
        /// <returns>bool</returns>
        //public bool GenerateDoc(Type docType, string title, string version, string systemName, string company)
        //{
        //    try
        //    {
        //        //ParagraphBookMark
        //        log.Info("�W��=" + title);
        //        log.Info("����=" + version);
        //        log.Info("�t�ΦW��=" + systemName);
        //        log.Info("���q=" + company);

        //        if (!InsertTitle(title, version, systemName, company))
        //        {
        //            log.Info("��Ʀ���");
        //        }

        //        CaptureDocUtil logic = new CaptureDocUtil();

        //        log.Info("�}�l���^�Ҧ��n���ͪ����C��");

        //        //���^�Ҧ�����ƭ�
        //        List<CaptureFlowMap> list = logic.GetAllCaptureDocList(docType);

        //        log.Info("���\���^�Ҧ������C��");

        //        object obreak = WdBreakType.wdSectionBreakNextPage;
        //        object style = WdBuiltinStyle.wdStyleHeading1;

        //        foreach (CaptureFlowMap t in list)
        //        {
        //            log.Info("�إ�Title:" + t.ID + t.Name);
        //            object oRng = wDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
        //            Paragraph oPara2 = wDoc.Content.Paragraphs.Add(ref oRng);
        //            oPara2.Range.Text = t.ID + t.Name;
        //            oPara2.OutlineLevel = WdOutlineLevel.wdOutlineLevel1;
        //            oPara2.Format.SpaceAfter = 1;
        //            oPara2.set_Style(ref style);
        //            oPara2.Range.InsertBreak(ref obreak);
        //            oPara2.Range.InsertParagraphAfter();
        //            oPara2.Range.Select();

        //            //�[�@�i��
        //            log.Info("�[�Ϥ� ����");
        //            Table oTable;
        //            oTable = wDoc.Tables.Add(oPara2.Range, 1, 1, ref Missing, ref Missing);
        //            Object oLinkToFile = false;  //default
        //            Object oSaveWithDocument = true;//default
        //            oTable.Cell(1, 1).Range.InlineShapes.AddPicture(LoginInfo.CaptureSavePath + DateTime.Now.ToString("yyyyMMdd") + "\\" + t.SaveFileName, ref  oLinkToFile, ref  oSaveWithDocument, ref  Missing);

        //            //�[��󻡩�
        //            log.Info("�[��󻡩�");
        //            Paragraph oPara3 = null;

        //            log.Info("�}�l�b�ؤ�󻡩�");
        //            foreach (ContentDescriptionMap e2 in t.DescriptionList)
        //            {



        //                oRng = wDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
        //                oPara3 = wDoc.Content.Paragraphs.Add(ref oRng);

        //                oPara3.Range.Font.Bold = 0;
        //                oPara3.Range.Font.NameFarEast = "�з���";
        //                oPara3.Range.Font.NameAscii = "Times New Roman";
        //                oPara3.Range.Font.NameOther = "Times New Roman";
        //                oPara3.Range.Font.Name = "Times New Roman";

        //                oPara3.Range.ParagraphFormat.LeftIndent = wApp.CentimetersToPoints((float)0.18);
        //                oPara3.Range.ParagraphFormat.FirstLineIndent = wApp.CentimetersToPoints((float)-0.18);
        //                oPara3.Range.ParagraphFormat.CharacterUnitFirstLineIndent = -1;

        //                oPara3.Format.SpaceAfter = 5;
        //                oPara3.Range.InsertParagraphAfter();

        //                oPara3.Range.Text = e2.Content;


        //                //object i=1; 

        //                //object listFormat=WdDefaultListBehavior.wdWord10ListBehavior;
        //                //ListTemplate listTemp=wApp.ListGalleries[WdListGalleryType.wdNumberGallery].ListTemplates.get_Item(ref i);
        //                //object bContinuousPrev=true; 

        //                //object applyTo=Missing;

        //                //object defaultListBehaviour=Missing;

        //                //ListFormat format=oPara3.Range.ListFormat;



        //                //oPara3.Range.ListFormat.ApplyListTemplate( 

        //                //                   listTemp,ref bContinuousPrev, 

        //                //                   ref applyTo, 

        //                //                   ref defaultListBehaviour 

        //                //                   );





        //            }


        //            ////�Ҧ�������Entity
        //            // foreach(EntityProtoTypeMap e1 in t.EntityList)
        //            // {
        //            //    Table oTable1= wDoc.Tables.Add(oPara3.Range, 1, 1, ref Missing, ref Missing);
        //            //    oTable1.Cell(1,1).Range.Font.NameFarEast="�з���";
        //            //    oTable1.Cell(1,1).Range.Font.NameAscii="Times New Roman";
        //            //    oTable1.Cell(1,1).Range.Font.NameOther="Times New Roman";
        //            //    oTable1.Cell(1,1).Range.Font.Name="Times New Roman";
        //            //    oTable1.Cell(1,1).Range.Text=e1.EntityId+e1.EntityName;


        //            //   Paragraph oPara6;
        //            //   oRng = wDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
        //            //   oPara6 = wDoc.Content.Paragraphs.Add (ref oRng);
        //            //   oPara6.Format.SpaceAfter = 0;
        //            //   oPara6.Range.InsertParagraphAfter();

        //            //    log.Info("Table2 Entity Row="+e1.EntityList.Count);
        //            //    Table oTable3;
        //            //    oTable3 = wDoc.Tables.Add(oPara6.Range,e1.EntityList.Count+1,5, ref Missing, ref Missing);
        //            //    oTable3.Cell(2,1).Range.Text="No";
        //            //    oTable3.Cell(2,2).Range.Text="Id";
        //            //    oTable3.Cell(2,3).Range.Text="Name";
        //            //    oTable3.Cell(2,4).Range.Text="Control";
        //            //    oTable3.Cell(2,5).Range.Text="Remark";

        //            //        for(int i=0;i<e1.EntityList.Count;i++)
        //            //        {
        //            //            log.Info("Row="+(i+1)+";Name="+docType.Name);
        //            //            EntityTable doc=(EntityTable)e1.EntityList[i];

        //            //            oTable3.Cell(i+3,1).Range.Text=doc.No;

        //            //            oTable3.Cell(i+3,2).Range.Text=doc.EntityId;
        //            //            oTable3.Cell(i+3,3).Range.Text=doc.Name;
        //            //            oTable3.Cell(i+3,4).Range.Text=doc.Control;
        //            //            oTable3.Cell(i+3,5).Range.Text=doc.ReMark;



        //            //        }
        //            // }

        //            Paragraph oPara4;
        //            oRng = wDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
        //            oPara4 = wDoc.Content.Paragraphs.Add(ref oRng);
        //            oPara4.Range.Text = t.Name + "����";
        //            oPara4.Range.Font.Bold = 0;
        //            oPara4.Range.Font.NameFarEast = "�з���";
        //            oPara4.Range.Font.NameAscii = "Times New Roman";
        //            oPara4.Range.Font.NameOther = "Times New Roman";
        //            oPara4.Range.Font.Name = "Times New Roman";
        //            oPara4.Range.Font.Size = 14;

        //            oPara4.Format.SpaceAfter = 1;
        //            oPara4.Range.InsertParagraphAfter();

        //            foreach (EntityProtoTypeMap e1 in t.EntityList)
        //            {


        //                ////log.Info("Create Table2 ");

        //                log.Info("Table=" + e1.EntityId + e1.EntityName + "��Ƥ��=" + e1.EntityList.Count);
        //                Table oTable2;

        //                oTable2 = wDoc.Tables.Add(oPara4.Range, 1, 1, ref Missing, ref Missing);
        //                oTable2.Cell(1, 1).Range.Text = e1.EntityId + e1.EntityName;

        //                Paragraph oPara6;
        //                oRng = wDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
        //                oPara6 = wDoc.Content.Paragraphs.Add(ref oRng);
        //                oPara6.Format.SpaceAfter = 0;
        //                oPara6.Range.InsertParagraphAfter();

        //                log.Info("Table2 Entity Row=" + e1.EntityList.Count);
        //                Table oTable3;
        //                oTable3 = wDoc.Tables.Add(oPara6.Range, e1.EntityList.Count + 1, 5, ref Missing, ref Missing);

        //                oTable3.Range.Font.NameFarEast = "�з���";
        //                oTable3.Range.Font.NameAscii = "Times New Roman";
        //                oTable3.Range.Font.NameOther = "Times New Roman";
        //                oTable3.Range.Font.Name = "Times New Roman";
        //                oTable3.Range.Font.Size = 12;

        //                //log.Info("Table2 Entity Title");
        //                ////Set Title
        //                oTable3.Cell(2, 1).Range.Text = "No";
        //                oTable3.Cell(2, 2).Range.Text = "Id";
        //                oTable3.Cell(2, 3).Range.Text = "Name";
        //                oTable3.Cell(2, 4).Range.Text = "Control";
        //                oTable3.Cell(2, 5).Range.Text = "Remark";


        //                log.Info(e1.EntityId + e1.EntityName + "�ѼƦp�U");

        //                for (int i = 0; i < e1.EntityList.Count; i++)
        //                {
        //                    log.Info("Row=" + (i + 1) + ";Name=" + docType.Name);
        //                    EntityTable doc = (EntityTable)e1.EntityList[i];

        //                    oTable3.Cell(i + 3, 1).Range.Text = doc.No;

        //                    oTable3.Cell(i + 3, 2).Range.Text = doc.EntityId;
        //                    oTable3.Cell(i + 3, 3).Range.Text = doc.Name;
        //                    oTable3.Cell(i + 3, 4).Range.Text = doc.Control;
        //                    oTable3.Cell(i + 3, 5).Range.Text = doc.ReMark;

        //                }

        //            }

        //        }

        //        //Do Directiory
        //        Object oDirBookMarkName = "DirBookMark";
        //        Range oRngDir = wDoc.Bookmarks.get_Item(ref oDirBookMarkName).Range;
        //        object HeadingLevel = 1;
        //        object useLink = true;
        //        wDoc.TablesOfContents.Add(oRngDir,
        //        ref missing, ref HeadingLevel, ref HeadingLevel,
        //        ref missing, ref missing, ref missing, ref missing,
        //        ref missing, ref useLink, ref missing, ref missing);


        //        return true;
        //    }
        //    catch (Exception err)
        //    {
        //        CloseWord();
        //        throw new Exception(err.InnerException.ToString());
        //        return false;
        //    }
        //}

        ///// <summary>
        ///// �s������覡
        ///// </summary>
        ///// <param name="docType"></param>
        ///// <param name="title"></param>
        ///// <param name="version"></param>
        ///// <param name="systemName"></param>
        ///// <param name="company"></param>
        ///// <returns></returns>
        //public bool GenerateDoc(string groupId, string webDll, string title, string version, string systemName, string company)
        //{
        //    try
        //    {
        //        //ParagraphBookMark
        //        log.Info("�W��=" + title);
        //        log.Info("����=" + version);
        //        log.Info("�t�ΦW��=" + systemName);
        //        log.Info("���q=" + company);

        //        if (!InsertTitle(title, version, systemName, company))
        //        {
        //            log.Info("��Ʀ���");
        //        }

        //        CaptureDocUtil logic = new CaptureDocUtil();

        //        log.Info("�}�l���^�Ҧ��n���ͪ����C��");

        //        //���^�Ҧ�����ƭ�
        //        SortedList<string, CaptureFlowMap> list = logic.GetAllCaptureDocList(groupId, webDll, LoginInfo.EntityExportPath);

        //        log.Info("���\���^�Ҧ������C��");

        //        object obreak = WdBreakType.wdSectionBreakNextPage;
        //        object style = WdBuiltinStyle.wdStyleHeading1;

        //        foreach (CaptureFlowMap t in list.Values)
        //        {
        //            log.Info("�إ�Title:" + t.ID + t.Name);
        //            object oRng = wDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
        //            Paragraph oPara2 = wDoc.Content.Paragraphs.Add(ref oRng);
        //            oPara2.Range.Text = t.ID + t.Name;
        //            oPara2.OutlineLevel = WdOutlineLevel.wdOutlineLevel1;
        //            oPara2.Format.SpaceAfter = 1;
        //            oPara2.set_Style(ref style);
        //            oPara2.Range.InsertBreak(ref obreak);
        //            oPara2.Range.InsertParagraphAfter();
        //            oPara2.Range.Select();

        //            //�[�@�i��
        //            log.Info("�[�Ϥ� ����");
        //            Table oTable;
        //            oTable = wDoc.Tables.Add(oPara2.Range, 1, 1, ref Missing, ref Missing);
        //            Object oLinkToFile = false;  //default
        //            Object oSaveWithDocument = true;//default
        //            oTable.Cell(1, 1).Range.InlineShapes.AddPicture(LoginInfo.CaptureSavePath + DateTime.Now.ToString("yyyyMMdd") + "\\" + t.SaveFileName, ref  oLinkToFile, ref  oSaveWithDocument, ref  Missing);

        //            //�[��󻡩�
        //            log.Info("�[��󻡩�");
        //            Paragraph oPara3 = null;

        //            log.Info("�}�l�b�ؤ�󻡩�");
        //            foreach (ContentDescriptionMap e2 in t.DescriptionList)
        //            {

        //                oRng = wDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
        //                oPara3 = wDoc.Content.Paragraphs.Add(ref oRng);

        //                oPara3.Range.ParagraphFormat.LeftIndent = wApp.CentimetersToPoints((float)0.18);
        //                oPara3.Range.ParagraphFormat.FirstLineIndent = wApp.CentimetersToPoints((float)-0.18);
        //                oPara3.Range.ParagraphFormat.CharacterUnitFirstLineIndent = -1;


        //                oPara3.Range.Font.Bold = 0;
        //                oPara3.Range.Font.NameFarEast = "�з���";
        //                oPara3.Range.Font.NameAscii = "Times New Roman";
        //                oPara3.Range.Font.NameOther = "Times New Roman";
        //                oPara3.Range.Font.Name = "Times New Roman";
        //                oPara3.Range.Font.Size = 12;
        //                oPara3.Format.SpaceAfter = 0;
        //                oPara3.Range.InsertParagraphAfter();

        //                oPara3.Range.Text = e2.Content;

        //            }

        //            Paragraph oPara4;
        //            oRng = wDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
        //            oPara4 = wDoc.Content.Paragraphs.Add(ref oRng);

        //            if (t.EntityList.Count > 0)
        //            {
        //                oPara4.Range.Text = t.Name + "���󻡩�";
        //            }


        //            oPara4.Range.Font.Bold = 1;
        //            oPara4.Range.Font.NameFarEast = "�з���";
        //            oPara4.Range.Font.NameAscii = "Times New Roman";
        //            oPara4.Range.Font.NameOther = "Times New Roman";
        //            oPara4.Range.Font.Name = "Times New Roman";
        //            oPara4.Range.Font.Size = 14;

        //            oPara4.Format.SpaceAfter = 1;
        //            oPara4.Range.InsertParagraphAfter();

        //            foreach (EntityProtoTypeMap e1 in t.EntityList)
        //            {


        //                ////log.Info("Create Table2 ");

        //                log.Info("Table=" + e1.EntityId + e1.EntityName + "��Ƥ��=" + e1.EntityList.Count);
        //                Table oTable2;


        //                oTable2 = wDoc.Tables.Add(oPara4.Range, 1, 1, ref Missing, ref Missing);

        //                oTable2.Borders[WdBorderType.wdBorderTop].LineStyle = WdLineStyle.wdLineStyleSingle;

        //                oTable2.Borders[WdBorderType.wdBorderLeft].LineStyle = WdLineStyle.wdLineStyleSingle;

        //                oTable2.Borders[WdBorderType.wdBorderRight].LineStyle = WdLineStyle.wdLineStyleSingle;

        //                oTable2.Borders[WdBorderType.wdBorderBottom].LineStyle = WdLineStyle.wdLineStyleSingle;

        //                oTable2.Borders[WdBorderType.wdBorderHorizontal].LineStyle = WdLineStyle.wdLineStyleSingle;

        //                oTable2.Borders[WdBorderType.wdBorderVertical].LineStyle = WdLineStyle.wdLineStyleSingle;


        //                oTable2.Cell(1, 1).Range.Text = e1.EntityId + "�V" + e1.EntityName;


        //                Paragraph oPara6;
        //                oRng = wDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
        //                oPara6 = wDoc.Content.Paragraphs.Add(ref oRng);
        //                oPara6.Format.SpaceAfter = 0;
        //                oPara6.Range.InsertParagraphAfter();

        //                log.Info("Table2 Entity Row=" + e1.EntityList.Count);
        //                Table oTable3;
        //                oTable3 = wDoc.Tables.Add(oPara6.Range, e1.EntityList.Count + 1, 5, ref Missing, ref Missing);

        //                oTable3.Borders[WdBorderType.wdBorderTop].LineStyle = WdLineStyle.wdLineStyleSingle;

        //                oTable3.Borders[WdBorderType.wdBorderLeft].LineStyle = WdLineStyle.wdLineStyleSingle;

        //                oTable3.Borders[WdBorderType.wdBorderRight].LineStyle = WdLineStyle.wdLineStyleSingle;

        //                oTable3.Borders[WdBorderType.wdBorderBottom].LineStyle = WdLineStyle.wdLineStyleSingle;

        //                oTable3.Borders[WdBorderType.wdBorderHorizontal].LineStyle = WdLineStyle.wdLineStyleSingle;

        //                oTable3.Borders[WdBorderType.wdBorderVertical].LineStyle = WdLineStyle.wdLineStyleSingle;


        //                oTable3.Range.Font.NameFarEast = "�з���";
        //                oTable3.Range.Font.NameAscii = "Times New Roman";
        //                oTable3.Range.Font.NameOther = "Times New Roman";
        //                oTable3.Range.Font.Name = "Times New Roman";
        //                oTable3.Range.Font.Size = 12;

        //                //log.Info("Table2 Entity Title");
        //                ////Set Title
        //                oTable3.Cell(2, 1).Range.Text = "No";
        //                oTable3.Cell(2, 2).Range.Text = "Id";
        //                oTable3.Cell(2, 3).Range.Text = "Name";
        //                oTable3.Cell(2, 4).Range.Text = "Control";
        //                oTable3.Cell(2, 5).Range.Text = "Remark";


        //                log.Info(e1.EntityId + e1.EntityName + "�ѼƦp�U");

        //                for (int i = 0; i < e1.EntityList.Count; i++)
        //                {
        //                    log.Info("Row=" + (i + 1) + ";Name=");
        //                    EntityTable doc = (EntityTable)e1.EntityList[i];

        //                    oTable3.Cell(i + 3, 1).Range.Text = doc.No;

        //                    oTable3.Cell(i + 3, 2).Range.Text = doc.EntityId;
        //                    oTable3.Cell(i + 3, 3).Range.Text = doc.Name;
        //                    oTable3.Cell(i + 3, 4).Range.Text = doc.Control;
        //                    oTable3.Cell(i + 3, 5).Range.Text = doc.ReMark;

        //                }

        //            }

        //        }

        //        //Do Directiory
        //        Object oDirBookMarkName = "DirBookMark";
        //        Range oRngDir = wDoc.Bookmarks.get_Item(ref oDirBookMarkName).Range;
        //        object HeadingLevel = 1;
        //        object useLink = true;
        //        wDoc.TablesOfContents.Add(oRngDir,
        //        ref missing, ref HeadingLevel, ref HeadingLevel,
        //        ref missing, ref missing, ref missing, ref missing,
        //        ref missing, ref useLink, ref missing, ref missing);


        //        return true;
        //    }
        //    catch (Exception err)
        //    {
        //        CloseWord();
        //        throw new Exception(err.InnerException.ToString());
        //        return false;
        //    }
        //}

        //public Boolean CloseWord()
        //{
        //    try
        //    {
        //        Boolean visible;
        //        Object y;
        //        visible = true;
        //        y = visible;
        //        wDoc.Close(ref y, ref Missing, ref Missing);

        //        visible = false;
        //        y = visible;
        //        wApp.Quit(ref y, ref Missing, ref Missing);

        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        ///// <summary>
        ///// �s��
        ///// </summary>
        ///// <param name="SavePath"></param>
        ///// <returns></returns>
        //public Boolean Save(String SavePath)
        //{
        //    try
        //    {
        //        Object FileName;
        //        FileName = SavePath;
        //        wDoc.SaveAs(ref FileName, ref  Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing);
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
    }
}
