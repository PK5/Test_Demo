namespace ScriptManager
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtScriptno = new System.Windows.Forms.TextBox();
            this.Scriptnolebel = new System.Windows.Forms.Label();
            this.Releasenolebel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbRelease = new System.Windows.Forms.ComboBox();
            this.cmbRequestedBy = new System.Windows.Forms.ComboBox();
            this.cmbScriptType = new System.Windows.Forms.ComboBox();
            this.txtObject = new System.Windows.Forms.TextBox();
            this.txtcomment = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnscriptgenrater = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnreset = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblmsgtxt = new System.Windows.Forms.Label();
            this.ScriptManager = new System.Windows.Forms.Label();
            this.lblscrno = new System.Windows.Forms.Label();
            this.lblrel = new System.Windows.Forms.Label();
            this.lblreq = new System.Windows.Forms.Label();
            this.lblScrtype = new System.Windows.Forms.Label();
            this.lblObj = new System.Windows.Forms.Label();
            this.lblcmnt = new System.Windows.Forms.Label();
            this.lblpath = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtScriptno
            // 
            this.txtScriptno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScriptno.Location = new System.Drawing.Point(215, 58);
            this.txtScriptno.Name = "txtScriptno";
            this.txtScriptno.Size = new System.Drawing.Size(220, 21);
            this.txtScriptno.TabIndex = 0;
            this.txtScriptno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtScriptno_KeyPress);
            // 
            // Scriptnolebel
            // 
            this.Scriptnolebel.AutoSize = true;
            this.Scriptnolebel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Scriptnolebel.Location = new System.Drawing.Point(88, 61);
            this.Scriptnolebel.Name = "Scriptnolebel";
            this.Scriptnolebel.Size = new System.Drawing.Size(66, 17);
            this.Scriptnolebel.TabIndex = 2;
            this.Scriptnolebel.Text = "Script No";
            // 
            // Releasenolebel
            // 
            this.Releasenolebel.AutoSize = true;
            this.Releasenolebel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Releasenolebel.Location = new System.Drawing.Point(87, 96);
            this.Releasenolebel.Name = "Releasenolebel";
            this.Releasenolebel.Size = new System.Drawing.Size(82, 17);
            this.Releasenolebel.TabIndex = 3;
            this.Releasenolebel.Text = "Release No";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(87, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Requested By";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(88, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Script type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(88, 217);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Object";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(88, 262);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Comment";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(88, 301);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 17);
            this.label6.TabIndex = 8;
            this.label6.Text = "Script Folder";
            // 
            // cmbRelease
            // 
            this.cmbRelease.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRelease.FormattingEnabled = true;
            this.cmbRelease.Location = new System.Drawing.Point(215, 93);
            this.cmbRelease.Name = "cmbRelease";
            this.cmbRelease.Size = new System.Drawing.Size(220, 23);
            this.cmbRelease.TabIndex = 14;
            this.cmbRelease.SelectedIndexChanged += new System.EventHandler(this.cmbRelease_SelectedIndexChanged);
            // 
            // cmbRequestedBy
            // 
            this.cmbRequestedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRequestedBy.FormattingEnabled = true;
            this.cmbRequestedBy.Location = new System.Drawing.Point(215, 133);
            this.cmbRequestedBy.Name = "cmbRequestedBy";
            this.cmbRequestedBy.Size = new System.Drawing.Size(220, 23);
            this.cmbRequestedBy.TabIndex = 15;
            this.cmbRequestedBy.SelectedIndexChanged += new System.EventHandler(this.cmbRequestedBy_SelectedIndexChanged);
            // 
            // cmbScriptType
            // 
            this.cmbScriptType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbScriptType.FormattingEnabled = true;
            this.cmbScriptType.Location = new System.Drawing.Point(215, 173);
            this.cmbScriptType.Name = "cmbScriptType";
            this.cmbScriptType.Size = new System.Drawing.Size(220, 23);
            this.cmbScriptType.TabIndex = 16;
            this.cmbScriptType.TextChanged += new System.EventHandler(this.cmbScriptType_TextChanged);
            // 
            // txtObject
            // 
            this.txtObject.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObject.Location = new System.Drawing.Point(215, 217);
            this.txtObject.Multiline = true;
            this.txtObject.Name = "txtObject";
            this.txtObject.Size = new System.Drawing.Size(220, 20);
            this.txtObject.TabIndex = 17;
            this.txtObject.TextChanged += new System.EventHandler(this.txtObject_TextChanged);
            // 
            // txtcomment
            // 
            this.txtcomment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcomment.Location = new System.Drawing.Point(215, 262);
            this.txtcomment.Multiline = true;
            this.txtcomment.Name = "txtcomment";
            this.txtcomment.Size = new System.Drawing.Size(220, 20);
            this.txtcomment.TabIndex = 18;
            this.txtcomment.TextChanged += new System.EventHandler(this.txtcomment_TextChanged);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Location = new System.Drawing.Point(550, 323);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(83, 27);
            this.btnBrowse.TabIndex = 20;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(215, 300);
            this.txtPath.Multiline = true;
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(329, 50);
            this.txtPath.TabIndex = 21;
            // 
            // btnscriptgenrater
            // 
            this.btnscriptgenrater.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnscriptgenrater.Location = new System.Drawing.Point(215, 414);
            this.btnscriptgenrater.Name = "btnscriptgenrater";
            this.btnscriptgenrater.Size = new System.Drawing.Size(143, 33);
            this.btnscriptgenrater.TabIndex = 22;
            this.btnscriptgenrater.Text = "Script Genrate";
            this.btnscriptgenrater.UseVisualStyleBackColor = true;
            this.btnscriptgenrater.Click += new System.EventHandler(this.btnscriptgenrater_Click);
            // 
            // btnreset
            // 
            this.btnreset.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnreset.Location = new System.Drawing.Point(413, 414);
            this.btnreset.Name = "btnreset";
            this.btnreset.Size = new System.Drawing.Size(131, 33);
            this.btnreset.TabIndex = 25;
            this.btnreset.Text = "Reset";
            this.btnreset.UseVisualStyleBackColor = true;
            this.btnreset.Click += new System.EventHandler(this.btnreset_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel1.Controls.Add(this.lblmsgtxt);
            this.panel1.Controls.Add(this.ScriptManager);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(680, 44);
            this.panel1.TabIndex = 26;
            // 
            // lblmsgtxt
            // 
            this.lblmsgtxt.AutoSize = true;
            this.lblmsgtxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmsgtxt.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblmsgtxt.Location = new System.Drawing.Point(469, 25);
            this.lblmsgtxt.Name = "lblmsgtxt";
            this.lblmsgtxt.Size = new System.Drawing.Size(12, 17);
            this.lblmsgtxt.TabIndex = 27;
            this.lblmsgtxt.Text = " ";
            // 
            // ScriptManager
            // 
            this.ScriptManager.AutoSize = true;
            this.ScriptManager.Font = new System.Drawing.Font("Mistral", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScriptManager.Location = new System.Drawing.Point(12, 9);
            this.ScriptManager.Name = "ScriptManager";
            this.ScriptManager.Size = new System.Drawing.Size(137, 33);
            this.ScriptManager.TabIndex = 27;
            this.ScriptManager.Text = "ScriptManager";
            // 
            // lblscrno
            // 
            this.lblscrno.AutoSize = true;
            this.lblscrno.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblscrno.Location = new System.Drawing.Point(441, 66);
            this.lblscrno.Name = "lblscrno";
            this.lblscrno.Size = new System.Drawing.Size(10, 13);
            this.lblscrno.TabIndex = 27;
            this.lblscrno.Text = " ";
            // 
            // lblrel
            // 
            this.lblrel.AutoSize = true;
            this.lblrel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblrel.Location = new System.Drawing.Point(441, 103);
            this.lblrel.Name = "lblrel";
            this.lblrel.Size = new System.Drawing.Size(10, 13);
            this.lblrel.TabIndex = 28;
            this.lblrel.Text = " ";
            // 
            // lblreq
            // 
            this.lblreq.AutoSize = true;
            this.lblreq.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblreq.Location = new System.Drawing.Point(441, 143);
            this.lblreq.Name = "lblreq";
            this.lblreq.Size = new System.Drawing.Size(10, 13);
            this.lblreq.TabIndex = 29;
            this.lblreq.Text = " ";
            // 
            // lblScrtype
            // 
            this.lblScrtype.AutoSize = true;
            this.lblScrtype.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblScrtype.Location = new System.Drawing.Point(441, 180);
            this.lblScrtype.Name = "lblScrtype";
            this.lblScrtype.Size = new System.Drawing.Size(10, 13);
            this.lblScrtype.TabIndex = 31;
            this.lblScrtype.Text = " ";
            // 
            // lblObj
            // 
            this.lblObj.AutoSize = true;
            this.lblObj.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblObj.Location = new System.Drawing.Point(441, 224);
            this.lblObj.Name = "lblObj";
            this.lblObj.Size = new System.Drawing.Size(10, 13);
            this.lblObj.TabIndex = 32;
            this.lblObj.Text = " ";
            // 
            // lblcmnt
            // 
            this.lblcmnt.AutoSize = true;
            this.lblcmnt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblcmnt.Location = new System.Drawing.Point(441, 269);
            this.lblcmnt.Name = "lblcmnt";
            this.lblcmnt.Size = new System.Drawing.Size(10, 13);
            this.lblcmnt.TabIndex = 33;
            this.lblcmnt.Text = " ";
            // 
            // lblpath
            // 
            this.lblpath.AutoSize = true;
            this.lblpath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblpath.Location = new System.Drawing.Point(221, 363);
            this.lblpath.Name = "lblpath";
            this.lblpath.Size = new System.Drawing.Size(10, 13);
            this.lblpath.TabIndex = 34;
            this.lblpath.Text = " ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(681, 491);
            this.Controls.Add(this.lblpath);
            this.Controls.Add(this.lblcmnt);
            this.Controls.Add(this.lblObj);
            this.Controls.Add(this.lblScrtype);
            this.Controls.Add(this.lblreq);
            this.Controls.Add(this.lblrel);
            this.Controls.Add(this.lblscrno);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnreset);
            this.Controls.Add(this.btnscriptgenrater);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtcomment);
            this.Controls.Add(this.txtObject);
            this.Controls.Add(this.cmbScriptType);
            this.Controls.Add(this.cmbRequestedBy);
            this.Controls.Add(this.cmbRelease);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Releasenolebel);
            this.Controls.Add(this.Scriptnolebel);
            this.Controls.Add(this.txtScriptno);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtScriptno;
        private System.Windows.Forms.Label Scriptnolebel;
        private System.Windows.Forms.Label Releasenolebel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbRelease;
        private System.Windows.Forms.ComboBox cmbRequestedBy;
        private System.Windows.Forms.ComboBox cmbScriptType;
        private System.Windows.Forms.TextBox txtObject;
        private System.Windows.Forms.TextBox txtcomment;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnscriptgenrater;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnreset;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label ScriptManager;
        private System.Windows.Forms.Label lblmsgtxt;
        private System.Windows.Forms.Label lblscrno;
        private System.Windows.Forms.Label lblrel;
        private System.Windows.Forms.Label lblreq;
        private System.Windows.Forms.Label lblScrtype;
        private System.Windows.Forms.Label lblObj;
        private System.Windows.Forms.Label lblcmnt;
        private System.Windows.Forms.Label lblpath;
    }
}

