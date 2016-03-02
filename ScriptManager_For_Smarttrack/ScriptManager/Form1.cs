using ReadDataFromExcel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScriptManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // cmbRequestedBy.Items.Clear();
            //cmbRelease.Items.Clear();
            //cmbScriptType.Items.Clear();
            txtScriptno.Text = "1";
            Excelread();


            //int releaseCounter = 0;
            //for (releaseCounter = 78; releaseCounter <= 85; releaseCounter++)
            //{
            //    cmbRelease.Items.Add("Release" + releaseCounter);
            //}
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                cmbScriptType.Items.Clear();
               // cmbScriptType.Items.Add("DBScript");
               // cmbScriptType.Items.Add("DataScript");
                cmbScriptType.Text = String.Empty;

                String[] input = { };
                OpenFileDialog dialog = new OpenFileDialog();

                dialog.Multiselect = true;
                dialog.FilterIndex = 2;
                // dialog.Filter = "sql files (*.sql)|*.sql|All files (*.*)|*.*";
                dialog.InitialDirectory = @"D:\Pawandoc\Smarttrack_Doc";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string separator = ", ";
                    input = dialog.FileNames;
                    //txtPath.Text = string.Join(string.Empty, input);
                    // txtPath.AppendText(input.ToString());
                    this.txtPath.Text = string.Join(separator, input);
                    getObjectName();
                    lblpath.Text = "";
                }
                if (this.txtPath.Text == String.Empty)
                {
                    lblpath.Text = "please select script";
                }
            }
            catch (Exception ex)
            {
                //  MessageBox.Show(ex.Message);
            }

        }

        private void btnscriptgenrater_Click(object sender, EventArgs e)
        {
            lblmsgtxt.Text = "";
            if (txtScriptno.Text == "" || txtObject.Text == "" || txtcomment.Text == "" || txtPath.Text == "" || cmbRequestedBy.SelectedItem == null || cmbRequestedBy.Text == String.Empty || cmbScriptType.Text == String.Empty || cmbRelease.SelectedItem == null || cmbRelease.Text == String.Empty)
            {
                Validation();
            }
            else
            {
                ReadText();
                addTextBegain();
                ReadTempWriteText();
                addText();
                RemoveGo();
                savefileName();
            }


        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        public void ReadText()
        {
            try
            {
                string contents = File.ReadAllText(txtPath.Text);
                FileStream fs1 = new FileStream(@"D:\Test1.sql", FileMode.Append, FileAccess.Write);
                StreamWriter writer = new StreamWriter(fs1);
                writer.WriteLine(contents);
                writer.Close();
            }
            catch (Exception e)
            {
                // MessageBox.Show(e.Message);
            }


        }

        public void addTextBegain()
        {
            try
            {
                FileStream fs1 = new FileStream(txtPath.Text, FileMode.Create, FileAccess.Write);
                StreamWriter writer = new StreamWriter(fs1);
                writer.WriteLine("/*");
                writer.WriteLine("WorkItem: ##");
                writer.WriteLine("Created By: Pawan Kumar");
                writer.WriteLine("Requested By: " + cmbRequestedBy.SelectedItem.ToString());
                writer.WriteLine("Description: " + txtcomment.Text + " " + txtObject.Text + ".");
                writer.WriteLine("*/");
                writer.WriteLine("IF NOT EXISTS(SELECT 1 FROM [dbo].[SmarttrackAppSqlScripts] WHERE [ScriptName] = '" + txtScriptno.Text + "." + "SmartTrack" + "_" + cmbScriptType.Text.ToString() + "_" + txtObject.Text.Replace("_", "") + "_" + DateTime.Today.ToString("MMddyyyy") + "')");
                writer.WriteLine("BEGIN");
                writer.Close();
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message);
            }

        }

        public void ReadTempWriteText()
        {
            try
            {
                string contents = File.ReadAllText(@"D:\Test1.sql");
                FileStream fs1 = new FileStream(txtPath.Text, FileMode.Append, FileAccess.Write);
                StreamWriter writer = new StreamWriter(fs1);
                writer.WriteLine(contents);
                File.Delete(@"D:\Test1.sql");
                writer.Close();
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message);
            }

        }

        public void addText()
        {
            try
            {
                FileStream fs1 = new FileStream(txtPath.Text, FileMode.Append, FileAccess.Write);
                StreamWriter writer = new StreamWriter(fs1);
                //writer.BaseStream.Seek(0, SeekOrigin.Begin);
                writer.WriteLine("INSERT [dbo].[SmarttrackAppSqlScripts] ([ScriptName], [ScriptComments], [Release], [ExecutedDate], [ExecutedBy]) VALUES");
                writer.WriteLine("('" + txtScriptno.Text + "." + "SmartTrack" + "_" + cmbScriptType.Text.ToString() + "_" + txtObject.Text.Replace("_", "") + "_" + DateTime.Today.ToString("MMddyyyy") + "', '" + txtcomment.Text + " " + txtObject.Text + ".', '" + cmbRelease.SelectedItem.ToString() + "' " + "," + "GETDATE()," + "SYSTEM_USER)");
                writer.WriteLine("END");
                writer.Close();
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message);
            }

        }

        public void getObjectName()
        {
            //string[] contents = { };
            //contents = File.ReadAllText(txtPath.Text);
            //string str = contents;
            string contents = string.Empty; //File.ReadAllText(txtPath.Text);

            string[] files = txtPath.Text.Split(',');

            foreach (string filePath in files)
            {
                string str = File.ReadAllText(filePath);

                Regex objsys = new Regex(@"(CREATE SYNONYM \[)(.)*(\]\.\[)([\d\w\s]*)(\])", RegexOptions.IgnoreCase);
                Regex objusp1 = new Regex(@"(CREATE PROCEDURE \[)(.)*(\]\.\[)([\d\w\s]*)(\])", RegexOptions.IgnoreCase);
                Regex objusp2 = new Regex(@"(CREATE PROC \[)(.)*(\]\.\[)([\d\w\s]*)(\])", RegexOptions.IgnoreCase);
                Regex objview1 = new Regex(@"(CREATE VIEW \[)(.)*(\]\.\[)([\d\w\s]*)(\])", RegexOptions.IgnoreCase);
                Regex objfun = new Regex(@"(CREATE FUNCTION \[)(.)*(\]\.\[)([\d\w\s]*)(\])", RegexOptions.IgnoreCase);
                Regex objtable = new Regex(@"(CREATE TABLE \[)(.)*(\]\.\[)([\d\w\s]*)(\])", RegexOptions.IgnoreCase);
                Regex objalt = new Regex(@"(ALTER TABLE \[)(.)*(\]\.\[)([\d\w\s]*)(\])", RegexOptions.IgnoreCase);
                Regex objalter = new Regex(@"(ALTER TABLE )([d\w]*)", RegexOptions.IgnoreCase);
                Regex objupdate = new Regex(@"(UPDATE )([d\w]*)", RegexOptions.IgnoreCase);
                Regex objupdate1 = new Regex(@"(UPDATE \[)(.)*(\]\.\[)([\d\w\s]*)(\])", RegexOptions.IgnoreCase);
                Regex objinsert = new Regex(@"(INSERT \[)(.)*(\]\.\[)([\d\w\s]*)(\])", RegexOptions.IgnoreCase);
                Regex objinsert1 = new Regex(@"(INSERT INTO \[)(.)*(\]\.\[)([\d\w\s]*)(\])", RegexOptions.IgnoreCase);
                Regex objinsert3 = new Regex(@"(INSERT \[)(.)*(\]).([\d\w\s]*)", RegexOptions.IgnoreCase);
                //Regex objinsert2 = new Regex(@"(INSERT INTO \[(.)*\])", RegexOptions.IgnoreCase);
                Regex objinsert2 = new Regex(@"(INSERT INTO \[)(.*)(\])", RegexOptions.IgnoreCase);
                Regex objview = new Regex(@"(IF NOT EXISTS \(SELECT \* FROM sys\.views WHERE object_id = OBJECT_ID\(N'\[)(.)*(\]\.\[)([\d\w\s]*)(\])", RegexOptions.IgnoreCase);
                Regex objsp = new Regex(@"(IF NOT EXISTS \(SELECT \* FROM sys\.objects WHERE object_id = OBJECT_ID\(N'\[)(.)*(\]\.\[)(.*)(\])", RegexOptions.IgnoreCase);
                Regex objfkey = new Regex(@"(IF NOT EXISTS \(SELECT \* FROM sys\.foreign_keys WHERE object_id = OBJECT_ID\(N'\[)(.)*(\]\.\[)([\d\w\s]*)(\])", RegexOptions.IgnoreCase);
                Regex objsp1 = new Regex(@"(IF  EXISTS \(SELECT \* FROM sys\.objects WHERE object_id = OBJECT_ID\(N'\[)(.)*(\]\.\[)(.*)(\])", RegexOptions.IgnoreCase);

                if (objsys.Match(str).Success)
                {
                    txtObject.Text = objsys.Match(str).Groups[4].Value;
                    txtcomment.Text = "Create Synonym";
                    cmbScriptType.SelectedIndex = -1;
                    cmbScriptType.SelectedText = "DBScript";

                    //ComboBox comboBox = new ComboBox();
                    //String _filePath = @"Excel\TestBook.xlsx";
                    //IEcelread _rdEx = new ExcelRead();
                    //List<ExcelPoco> lstExcelData = _rdEx.GetDataFromExcel(_filePath);                    
                    //for (int count = 0; count < lstExcelData.Count; count++)
                    //{
                    //    if (lstExcelData[count].Column1 != null)
                    //        comboBox.Items.Add(lstExcelData[count].Column1);
                    //}
                    // pnlScriptType.Controls.Add(comboBox);

                }
                else if (objusp1.Match(str).Success)
                {
                    txtObject.Text = objusp1.Match(str).Groups[4].Value;
                    // string myString = "Create Stored Procedure";
                    //TextWriter tsw = new StreamWriter(@"Create Stored Procedure", true);
                    //txtcomment.Text= tsw.ToString();
                    txtcomment.Text += "Create Stored Procedure";
                    cmbScriptType.SelectedIndex = -1;
                    cmbScriptType.SelectedText = "DBScript";

                    ReadText();
                    addTextBegain();
                    ReadTempWriteText();
                    addText();
                    RemoveGo();
                    savefileName();

                }
                else if (objusp2.Match(str).Success)
                {
                    txtObject.Text = objusp2.Match(str).Groups[4].Value;
                    txtcomment.Text = "Create Stored Procedure";
                    cmbScriptType.SelectedIndex = -1;
                    cmbScriptType.SelectedText = "DBScript";
                }
                else if (objview1.Match(str).Success)
                {
                    txtObject.Text = objview1.Match(str).Groups[4].Value;
                    txtcomment.Text = "Create View";
                    cmbScriptType.SelectedIndex = -1;
                    cmbScriptType.SelectedText = "DBScript";
                }
                else if (objfun.Match(str).Success)
                {
                    txtObject.Text = objfun.Match(str).Groups[4].Value;
                    txtcomment.Text = "Create Function";
                    cmbScriptType.SelectedIndex = -1;
                    cmbScriptType.SelectedText = "DBScript";
                }
                else if (objtable.Match(str).Success)
                {
                    txtObject.Text = objtable.Match(str).Groups[4].Value;
                    txtcomment.Text = "Create Table";
                    cmbScriptType.SelectedIndex = -1;
                    //cmbScriptType.SelectedText = null;
                    cmbScriptType.SelectedText = "DBScript";
                    //cmbScriptType.SelectedValue = "DBScript";

                }
                else if (objalt.Match(str).Success)
                {
                    txtObject.Text = objalt.Match(str).Groups[4].Value;
                    txtcomment.Text = "Alter Table";
                    cmbScriptType.SelectedIndex = -1;
                    cmbScriptType.SelectedText = "DBScript";

                }
                else if (objalter.Match(str).Success)
                {
                    txtObject.Text = objalter.Match(str).Groups[2].Value;
                    txtcomment.Text = "Alter Table";
                    cmbScriptType.SelectedIndex = -1;
                    cmbScriptType.SelectedText = "DBScript";

                }
                else if (objupdate1.Match(str).Success)
                {
                    txtObject.Text = objupdate1.Match(str).Groups[4].Value;
                    txtcomment.Text = "Update Values in Table";
                    cmbScriptType.SelectedIndex = -1;
                    cmbScriptType.SelectedText = "DataScript";
                }
                else if (objupdate.Match(str).Success)
                {
                    txtObject.Text = objupdate.Match(str).Groups[2].Value;
                    txtcomment.Text = "Update Values in Table";
                    cmbScriptType.SelectedIndex = -1;
                    cmbScriptType.SelectedText = "DataScript";
                }

                else if (objinsert.Match(str).Success)
                {
                    txtObject.Text = objinsert.Match(str).Groups[4].Value;
                    txtcomment.Text = "Insert Values in Table";
                    cmbScriptType.SelectedIndex = -1;
                    cmbScriptType.SelectedText = "DataScript";

                }
                else if (objinsert1.Match(str).Success)
                {
                    txtObject.Text = objinsert1.Match(str).Groups[4].Value;
                    txtcomment.Text = "Insert Values in Table";
                    cmbScriptType.SelectedIndex = -1;
                    cmbScriptType.SelectedText = "DataScript";

                }
                else if (objinsert2.Match(str).Success)
                {
                    txtObject.Text = objinsert2.Match(str).Groups[2].Value;
                    txtcomment.Text = "Insert Values in Table";
                    cmbScriptType.SelectedIndex = -1;
                    cmbScriptType.SelectedText = "DataScript";

                }
                else if (objinsert3.Match(str).Success)
                {
                    txtObject.Text = objinsert3.Match(str).Groups[4].Value;
                    txtcomment.Text = "Insert Values in Table";
                    cmbScriptType.SelectedIndex = -1;
                    cmbScriptType.SelectedText = "DataScript";

                }
                else if (objview.Match(str).Success)
                {
                    txtObject.Text = objview.Match(str).Groups[4].Value;
                    txtcomment.Text = "Create View";
                    cmbScriptType.SelectedIndex = -1;
                    cmbScriptType.SelectedText = "DBScript";
                }
                else if (objsp.Match(str).Success)
                {
                    txtObject.Text = objsp.Match(str).Groups[4].Value;
                    txtcomment.Text = "Create Stored Procedure";
                    cmbScriptType.SelectedIndex = -1;
                    cmbScriptType.SelectedText = "DBScript";
                }
                else if (objsp1.Match(str).Success)
                {
                    txtObject.Text = objsp1.Match(str).Groups[4].Value;
                    txtcomment.Text = "Create Stored Procedure";
                    cmbScriptType.SelectedIndex = -1;
                    cmbScriptType.SelectedText = "DBScript";
                }

                else if (objfkey.Match(str).Success)
                {
                    txtObject.Text = objfkey.Match(str).Groups[4].Value;
                    txtcomment.Text = "Alter Table";
                    cmbScriptType.SelectedIndex = -1;
                    cmbScriptType.SelectedText = "DBScript";
                }


                else
                {

                    // MessageBox.Show("Not match any content");
                }
            }





        }

        //public void getObjectName()
        //{
        //    string contents = File.ReadAllText(txtPath.Text);
        //    string str = contents;

        //    //Regex objsys = new Regex(@"(CREATE SYNONYM \[)(.){3}(\]\.\[)([\d\w\s]*)(\])", RegexOptions.IgnoreCase);
        //    //Regex objusp1 = new Regex(@"(CREATE PROCEDURE \[)(.){3}(\]\.\[)([\d\w\s]*)(\])", RegexOptions.IgnoreCase);
        //    // Regex objusp2 = new Regex(@"(CREATE PROCEDURE \[)(.){6}(\]\.\[)([\d\w\s]*)(\])", RegexOptions.IgnoreCase);
        //    //Regex objview1 = new Regex(@"(CREATE VIEW \[)(.){3}(\]\.\[)([\d\w\s]*)(\])", RegexOptions.IgnoreCase);
        //    //Regex objfun = new Regex(@"(CREATE FUNCTION \[)(.){3}(\]\.\[)([\d\w\s]*)(\])", RegexOptions.IgnoreCase);
        //    //Regex objtable = new Regex(@"(CREATE TABLE \[)(.){3}(\]\.\[)([\d\w\s]*)(\])", RegexOptions.IgnoreCase);
        //    //Regex objalt = new Regex(@"(ALTER TABLE \[)(.){3}(\]\.\[)([\d\w\s]*)(\])", RegexOptions.IgnoreCase);
        //    //Regex objalter = new Regex(@"(ALTER TABLE )([d\w]*)", RegexOptions.IgnoreCase);
        //    //Regex objupdate = new Regex(@"(UPDATE )([d\w]*)", RegexOptions.IgnoreCase);
        //    //Regex objinsert = new Regex(@"(INSERT \[)(.){3}(\]\.\[)([\d\w\s]*)(\])", RegexOptions.IgnoreCase);
        //    //Regex objview = new Regex(@"(IF NOT EXISTS \(SELECT \* FROM sys\.views WHERE object_id = OBJECT_ID\(N'\[)(.){3}(\]\.\[)([\d\w\s]*)(\])", RegexOptions.IgnoreCase);
        //    //Regex objsp = new Regex(@"(IF NOT EXISTS \(SELECT \* FROM sys\.objects WHERE object_id = OBJECT_ID\(N'\[)(.){3}(\]\.\[)(.*)(\])", RegexOptions.IgnoreCase);            
        //    //Regex objfkey = new Regex(@"(IF NOT EXISTS \(SELECT \* FROM sys\.foreign_keys WHERE object_id = OBJECT_ID\(N'\[)(.){3}(\]\.\[)([\d\w\s]*)(\])", RegexOptions.IgnoreCase);
        //    Regex objsys = new Regex(@"(CREATE SYNONYM \[)(.)*(\]\.\[)([\d\w\s]*)(\])", RegexOptions.IgnoreCase);
        //    Regex objusp1 = new Regex(@"(CREATE PROCEDURE \[)(.)*(\]\.\[)([\d\w\s]*)(\])", RegexOptions.IgnoreCase);
        //    Regex objusp2 = new Regex(@"(CREATE PROC \[)(.)*(\]\.\[)([\d\w\s]*)(\])", RegexOptions.IgnoreCase);
        //    Regex objview1 = new Regex(@"(CREATE VIEW \[)(.)*(\]\.\[)([\d\w\s]*)(\])", RegexOptions.IgnoreCase);
        //    Regex objfun = new Regex(@"(CREATE FUNCTION \[)(.)*(\]\.\[)([\d\w\s]*)(\])", RegexOptions.IgnoreCase);
        //    Regex objtable = new Regex(@"(CREATE TABLE \[)(.)*(\]\.\[)([\d\w\s]*)(\])", RegexOptions.IgnoreCase);
        //    Regex objalt = new Regex(@"(ALTER TABLE \[)(.)*(\]\.\[)([\d\w\s]*)(\])", RegexOptions.IgnoreCase);
        //    Regex objalter = new Regex(@"(ALTER TABLE )([d\w]*)", RegexOptions.IgnoreCase);
        //    Regex objupdate = new Regex(@"(UPDATE )([d\w]*)", RegexOptions.IgnoreCase);
        //    Regex objupdate1 = new Regex(@"(UPDATE \[)(.)*(\]\.\[)([\d\w\s]*)(\])", RegexOptions.IgnoreCase);
        //    Regex objinsert = new Regex(@"(INSERT \[)(.)*(\]\.\[)([\d\w\s]*)(\])", RegexOptions.IgnoreCase);
        //    Regex objinsert1 = new Regex(@"(INSERT INTO \[)(.)*(\]\.\[)([\d\w\s]*)(\])", RegexOptions.IgnoreCase);
        //    Regex objinsert3 = new Regex(@"(INSERT \[)(.)*(\]).([\d\w\s]*)", RegexOptions.IgnoreCase);
        //    //Regex objinsert2 = new Regex(@"(INSERT INTO \[(.)*\])", RegexOptions.IgnoreCase);
        //    Regex objinsert2 = new Regex(@"(INSERT INTO \[)(.*)(\])", RegexOptions.IgnoreCase);
        //    Regex objview = new Regex(@"(IF NOT EXISTS \(SELECT \* FROM sys\.views WHERE object_id = OBJECT_ID\(N'\[)(.)*(\]\.\[)([\d\w\s]*)(\])", RegexOptions.IgnoreCase);
        //    Regex objsp = new Regex(@"(IF NOT EXISTS \(SELECT \* FROM sys\.objects WHERE object_id = OBJECT_ID\(N'\[)(.)*(\]\.\[)(.*)(\])", RegexOptions.IgnoreCase);
        //    Regex objfkey = new Regex(@"(IF NOT EXISTS \(SELECT \* FROM sys\.foreign_keys WHERE object_id = OBJECT_ID\(N'\[)(.)*(\]\.\[)([\d\w\s]*)(\])", RegexOptions.IgnoreCase);
        //    Regex objsp1 = new Regex(@"(IF  EXISTS \(SELECT \* FROM sys\.objects WHERE object_id = OBJECT_ID\(N'\[)(.)*(\]\.\[)(.*)(\])", RegexOptions.IgnoreCase);
        //    if (objsys.Match(str).Success)
        //    {
        //        txtObject.Text = objsys.Match(str).Groups[4].Value;
        //        txtcomment.Text = "Create Synonym";
        //        cmbScriptType.SelectedIndex = -1;

        //        cmbScriptType.SelectedText = "DBScript";
        //    }
        //    else if (objusp1.Match(str).Success)
        //    {
        //        txtObject.Text = objusp1.Match(str).Groups[4].Value;
        //        txtcomment.Text = "Create Stored Procedure";
        //        cmbScriptType.SelectedIndex = -1;
        //        cmbScriptType.SelectedText = "DBScript";
        //    }
        //    else if (objusp2.Match(str).Success)
        //    {
        //        txtObject.Text = objusp2.Match(str).Groups[4].Value;
        //        txtcomment.Text = "Create Stored Procedure";
        //        cmbScriptType.SelectedIndex = -1;
        //        cmbScriptType.SelectedText = "DBScript";
        //    }
        //    else if (objview1.Match(str).Success)
        //    {
        //        txtObject.Text = objview1.Match(str).Groups[4].Value;
        //        txtcomment.Text = "Create View";
        //        cmbScriptType.SelectedIndex = -1;
        //        cmbScriptType.SelectedText = "DBScript";
        //    }
        //    else if (objfun.Match(str).Success)
        //    {
        //        txtObject.Text = objfun.Match(str).Groups[4].Value;
        //        txtcomment.Text = "Create Function";
        //        cmbScriptType.SelectedIndex = -1;
        //        cmbScriptType.SelectedText = "DBScript";
        //    }
        //    else if (objtable.Match(str).Success)
        //    {
        //        txtObject.Text = objtable.Match(str).Groups[4].Value;
        //        txtcomment.Text = "Create Table";
        //        cmbScriptType.SelectedIndex = -1;
        //        //cmbScriptType.SelectedText = null;
        //        cmbScriptType.SelectedText = "DBScript";
        //        //cmbScriptType.SelectedValue = "DBScript";

        //    }
        //    else if (objalt.Match(str).Success)
        //    {
        //        txtObject.Text = objalt.Match(str).Groups[4].Value;
        //        txtcomment.Text = "Alter Table";
        //        cmbScriptType.SelectedIndex = -1;
        //        cmbScriptType.SelectedText = "DBScript";

        //    }
        //    else if (objalter.Match(str).Success)
        //    {
        //        txtObject.Text = objalter.Match(str).Groups[2].Value;
        //        txtcomment.Text = "Alter Table";
        //        cmbScriptType.SelectedIndex = -1;
        //        cmbScriptType.SelectedText = "DBScript";

        //    }
        //    else if (objupdate1.Match(str).Success)
        //    {
        //        txtObject.Text = objupdate1.Match(str).Groups[4].Value;
        //        txtcomment.Text = "Update Values in Table";
        //        cmbScriptType.SelectedIndex = -1;
        //        cmbScriptType.SelectedText = "DataScript";
        //    }
        //    else if (objupdate.Match(str).Success)
        //    {
        //        txtObject.Text = objupdate.Match(str).Groups[2].Value;
        //        txtcomment.Text = "Update Values in Table";
        //        cmbScriptType.SelectedIndex = -1;
        //        cmbScriptType.SelectedText = "DataScript";
        //    }

        //    else if (objinsert.Match(str).Success)
        //    {
        //        txtObject.Text = objinsert.Match(str).Groups[4].Value;
        //        txtcomment.Text = "Insert Values in Table";
        //        cmbScriptType.SelectedIndex = -1;
        //        cmbScriptType.SelectedText = "DataScript";

        //    }
        //    else if (objinsert1.Match(str).Success)
        //    {
        //        txtObject.Text = objinsert1.Match(str).Groups[4].Value;
        //        txtcomment.Text = "Insert Values in Table";
        //        cmbScriptType.SelectedIndex = -1;
        //        cmbScriptType.SelectedText = "DataScript";

        //    }
        //    else if (objinsert2.Match(str).Success)
        //    {
        //        txtObject.Text = objinsert2.Match(str).Groups[2].Value;
        //        txtcomment.Text = "Insert Values in Table";
        //        cmbScriptType.SelectedIndex = -1;
        //        cmbScriptType.SelectedText = "DataScript";

        //    }
        //    else if (objinsert3.Match(str).Success)
        //    {
        //        txtObject.Text = objinsert3.Match(str).Groups[4].Value;
        //        txtcomment.Text = "Insert Values in Table";
        //        cmbScriptType.SelectedIndex = -1;
        //        cmbScriptType.SelectedText = "DataScript";

        //    }
        //    else if (objview.Match(str).Success)
        //    {
        //        txtObject.Text = objview.Match(str).Groups[4].Value;
        //        txtcomment.Text = "Create View";
        //        cmbScriptType.SelectedIndex = -1;
        //        cmbScriptType.SelectedText = "DBScript";
        //    }
        //    else if (objsp.Match(str).Success)
        //    {
        //        txtObject.Text = objsp.Match(str).Groups[4].Value;
        //        txtcomment.Text = "Create Stored Procedure";
        //        cmbScriptType.SelectedIndex = -1;
        //        cmbScriptType.SelectedText = "DBScript";
        //    }
        //    else if (objsp1.Match(str).Success)
        //    {
        //        txtObject.Text = objsp1.Match(str).Groups[4].Value;
        //        txtcomment.Text = "Create Stored Procedure";
        //        cmbScriptType.SelectedIndex = -1;
        //        cmbScriptType.SelectedText = "DBScript";
        //    }

        //    else if (objfkey.Match(str).Success)
        //    {
        //        txtObject.Text = objfkey.Match(str).Groups[4].Value;
        //        txtcomment.Text = "Alter Table";
        //        cmbScriptType.SelectedIndex = -1;
        //        cmbScriptType.SelectedText = "DBScript";
        //    }
        //    else
        //    {

        //        // MessageBox.Show("Not match any content");
        //    }

        //}
        
        public void savefileName()
        {
            try
            {
                string abc = txtScriptno.Text + "." + "SmartTrack" + "_" + cmbScriptType.Text.ToString() + "_" + txtObject.Text.Replace("_", "") + "_" + DateTime.Today.ToString("MMddyyyy");

                if (File.Exists(abc))
                {
                    System.IO.File.Delete(abc);
                }

                String newPath = Path.GetDirectoryName(txtPath.Text) + "\\" + abc + "." + txtPath.Text.Split('.').Last();
                File.Move(txtPath.Text, newPath);
                lblmsgtxt.Text = "Script Genrate Successfully";
                if (lblmsgtxt.Text == "Script Genrate Successfully")
                {

                    int num = int.Parse(txtScriptno.Text);
                    num++;
                    txtScriptno.Text = num.ToString();

                    // txtScriptno.Text = "";
                    txtObject.Text = "";
                    txtcomment.Text = "";
                    txtPath.Text = "";
                    cmbScriptType.Text = String.Empty;

                    cmbRelease.Text = String.Empty;
                    cmbRequestedBy.Text = String.Empty;
                    cmbRequestedBy.SelectedItem = "";
                    cmbScriptType.SelectedItem = "";

                    cmbRelease.SelectedItem = "";
                    cmbRequestedBy.SelectedItem = "";
                }

                var t = new Timer();
                t.Interval = 3000; // it will Tick in 3 seconds
                t.Tick += (s, e) =>
                {
                    lblmsgtxt.Hide();
                    t.Stop();
                };
                t.Start();
            }
            catch (Exception e)
            {
                //  MessageBox.Show(e.Message);
            }

            //string X = txtPath.Text.Split('\\')[txtPath.Text.Split('\\').Length - 1];
            //File.Move(txtPath.Text.Split('\\')[txtPath.Text.Split('\\').Length - 1],abc);                         
            //System.IO.File.Move(@"txtPath.Text.Split('\\')[txtPath.Text.Split('\\').Length - 1]", @"abc");
            //string NewFilePath = Path.Combine(@"D:\", abc);
            //if (File.Exists(NewFilePath))
            //{
            //    File.Delete(NewFilePath);
            //}
            ////Now copy the file first 
            ////Now Rename the File
            //File.Move(NewFilePath, Path.Combine(@"D\:", abc)); 
        }

        public void RemoveGo()
        {
            try
            {
                var oldLines = System.IO.File.ReadAllLines(txtPath.Text);
                var newLines = oldLines.Where(line => !line.Contains("GO"));
                System.IO.File.WriteAllLines(txtPath.Text, newLines);
            }
            catch (Exception e)
            {
                 
            }

        }

        public void Reset()
        {
            try
            {
                txtScriptno.Text = "";
                txtObject.Text = "";
                txtcomment.Text = "";
                txtPath.Text = "";
                cmbScriptType.Text = String.Empty;

                cmbRelease.Text = String.Empty;
                cmbRequestedBy.Text = String.Empty;
                cmbRequestedBy.SelectedItem = "";
                cmbScriptType.SelectedItem = "";

                cmbRelease.SelectedItem = "";
                cmbRequestedBy.SelectedItem = "";

                lblmsgtxt.Text = "";
                lblscrno.Text = "";
                lblrel.Text = "";
                lblreq.Text = "";

                lblScrtype.Text = "";
                lblcmnt.Text = "";
                lblObj.Text = "";
                lblpath.Text = "";
            }
            catch (Exception e)
            {
                // MessageBox.Show(e.Message);
            }

        }

        public void Excelread()
        {
            //  String filePath = @"D:\TestBook.xlsx";
            //  IEcelread _rdEx = new ExcelRead();
            //  List<ExcelPoco> lstExcelData = _rdEx.GetDataFromExcel(filePath);
            ////  Console.WriteLine("Excel Data:");
            //  for (int count = 0; count < lstExcelData.Count; count++)
            //  {
            //     cmbScriptType.Items.Add(lstExcelData[count].Column2);
            //      //cmbRequestedBy.Items.Add(lstExcelData[count].Column2);
            //      //cmbDBName.Items.Add(lstExcelData[count].Column3);
            //  }

            //  //Console.WriteLine(lstExcelData[count].Column1 + "\t" + lstExcelData[count].Column2 + "\t" + lstExcelData[count].Column3 + "\t" + lstExcelData[count].Column4);
            //  //Console.ReadKey();

            String filePath = @"Excel\TestBook.xlsx";
            IEcelread _rdEx = new ExcelRead();
            List<ExcelPoco> lstExcelData = _rdEx.GetDataFromExcel(filePath);


            for (int count = 0; count < lstExcelData.Count; count++)
            {
                if (lstExcelData[count].Column1 != null)
                    cmbScriptType.Items.Add(lstExcelData[count].Column1);
                    //cmbScriptType.SelectedIndex = 0;

                if (lstExcelData[count].Column2 != null)
                    cmbRequestedBy.Items.Add(lstExcelData[count].Column2);
                    cmbRequestedBy.SelectedIndex = 0;

                if (lstExcelData[count].Column3 != null)
                    cmbRelease.Items.Add(lstExcelData[count].Column3);
                    cmbRelease.SelectedIndex = 0;
            }
          

        }

        public void Validation()
        {
            try
            {
                if (txtScriptno.Text == "")
                {
                    lblscrno.Text = "please fill script number";
                }
                if (txtObject.Text == "")
                {
                    lblObj.Text = "please fill object name";
                }
                if (txtcomment.Text == "")
                {
                    lblcmnt.Text = "please fill discription";
                }
                if (txtPath.Text == "")
                {
                    lblpath.Text = "please select script";
                }

                if (cmbRequestedBy.SelectedItem == null || cmbRequestedBy.Text == String.Empty)
                {
                    lblreq.Text = "please select requested name";
                }
                if (cmbScriptType.Text == String.Empty)
                {
                    lblScrtype.Text = "please select script type";
                }
                if (cmbRelease.SelectedItem == null || cmbRelease.Text == String.Empty)
                {
                    lblrel.Text = "please select release number";
                }
            }
            catch (Exception ex)
            {
            }

        }

        private void txtScriptno_KeyPress(object sender, KeyPressEventArgs e)
        {
            lblscrno.Text = "";

        }

        private void cmbRelease_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblrel.Text = "";

        }

        private void cmbRequestedBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblreq.Text = "";

        }

        private void cmbScriptType_TextChanged(object sender, EventArgs e)
        {
            lblScrtype.Text = "";

        }

        private void txtObject_TextChanged(object sender, EventArgs e)
        {
            lblObj.Text = "";

        }

        private void txtcomment_TextChanged(object sender, EventArgs e)
        {
            lblcmnt.Text = "";

        }

    }
}
