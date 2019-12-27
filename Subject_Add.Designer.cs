namespace TeamProjcet
{
    partial class Subject_Add
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
            this.textBox_Subname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_tuition = new System.Windows.Forms.TextBox();
            this.button_Add = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_TeacherID = new System.Windows.Forms.TextBox();
            this.oracleConnection1 = new Oracle.ManagedDataAccess.Client.OracleConnection();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_week1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_week2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_Start1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_End1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_year = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_month = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox_End2 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox_Start2 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox_RoomNum = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_Subname
            // 
            this.textBox_Subname.Location = new System.Drawing.Point(82, 27);
            this.textBox_Subname.Name = "textBox_Subname";
            this.textBox_Subname.Size = new System.Drawing.Size(163, 25);
            this.textBox_Subname.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "과목명";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(255, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "수강료";
            // 
            // textBox_tuition
            // 
            this.textBox_tuition.Location = new System.Drawing.Point(310, 27);
            this.textBox_tuition.Name = "textBox_tuition";
            this.textBox_tuition.Size = new System.Drawing.Size(163, 25);
            this.textBox_tuition.TabIndex = 2;
            this.textBox_tuition.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_tuition_KeyPress);
            // 
            // button_Add
            // 
            this.button_Add.Location = new System.Drawing.Point(342, 137);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(410, 47);
            this.button_Add.TabIndex = 4;
            this.button_Add.Text = "확인";
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(495, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "강사번호";
            // 
            // textBox_TeacherID
            // 
            this.textBox_TeacherID.Location = new System.Drawing.Point(567, 27);
            this.textBox_TeacherID.Name = "textBox_TeacherID";
            this.textBox_TeacherID.Size = new System.Drawing.Size(163, 25);
            this.textBox_TeacherID.TabIndex = 5;
            // 
            // oracleConnection1
            // 
            this.oracleConnection1.Credential = null;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(324, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "요일1";
            // 
            // textBox_week1
            // 
            this.textBox_week1.Location = new System.Drawing.Point(375, 61);
            this.textBox_week1.Name = "textBox_week1";
            this.textBox_week1.Size = new System.Drawing.Size(98, 25);
            this.textBox_week1.TabIndex = 9;
            this.textBox_week1.Text = "월";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(324, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "요일2";
            // 
            // textBox_week2
            // 
            this.textBox_week2.Location = new System.Drawing.Point(375, 92);
            this.textBox_week2.Name = "textBox_week2";
            this.textBox_week2.Size = new System.Drawing.Size(98, 25);
            this.textBox_week2.TabIndex = 11;
            this.textBox_week2.Text = "수";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(489, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 15);
            this.label7.TabIndex = 14;
            this.label7.Text = "시작 시간";
            // 
            // textBox_Start1
            // 
            this.textBox_Start1.Location = new System.Drawing.Point(567, 61);
            this.textBox_Start1.Name = "textBox_Start1";
            this.textBox_Start1.Size = new System.Drawing.Size(98, 25);
            this.textBox_Start1.TabIndex = 13;
            this.textBox_Start1.Text = "15:00";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(680, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 15);
            this.label8.TabIndex = 16;
            this.label8.Text = "종료 시간";
            // 
            // textBox_End1
            // 
            this.textBox_End1.Location = new System.Drawing.Point(758, 61);
            this.textBox_End1.Name = "textBox_End1";
            this.textBox_End1.Size = new System.Drawing.Size(98, 25);
            this.textBox_End1.TabIndex = 15;
            this.textBox_End1.Text = "17:00";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.textBox_year);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox_month);
            this.groupBox1.Location = new System.Drawing.Point(23, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(294, 119);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "강의 시작 월";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(44, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 15);
            this.label9.TabIndex = 22;
            this.label9.Text = "년도";
            // 
            // textBox_year
            // 
            this.textBox_year.Location = new System.Drawing.Point(87, 53);
            this.textBox_year.Name = "textBox_year";
            this.textBox_year.Size = new System.Drawing.Size(84, 25);
            this.textBox_year.TabIndex = 21;
            this.textBox_year.Text = "2019";
            this.textBox_year.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_year_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(178, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 15);
            this.label4.TabIndex = 20;
            this.label4.Text = "월";
            // 
            // textBox_month
            // 
            this.textBox_month.Location = new System.Drawing.Point(206, 53);
            this.textBox_month.Name = "textBox_month";
            this.textBox_month.Size = new System.Drawing.Size(44, 25);
            this.textBox_month.TabIndex = 19;
            this.textBox_month.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_month_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(680, 95);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 15);
            this.label10.TabIndex = 23;
            this.label10.Text = "종료 시간";
            // 
            // textBox_End2
            // 
            this.textBox_End2.Location = new System.Drawing.Point(758, 92);
            this.textBox_End2.Name = "textBox_End2";
            this.textBox_End2.Size = new System.Drawing.Size(98, 25);
            this.textBox_End2.TabIndex = 22;
            this.textBox_End2.Text = "17:00";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(489, 95);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 15);
            this.label11.TabIndex = 21;
            this.label11.Text = "시작 시간";
            // 
            // textBox_Start2
            // 
            this.textBox_Start2.Location = new System.Drawing.Point(567, 92);
            this.textBox_Start2.Name = "textBox_Start2";
            this.textBox_Start2.Size = new System.Drawing.Size(98, 25);
            this.textBox_Start2.TabIndex = 20;
            this.textBox_Start2.Text = "15:00";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(809, 30);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 15);
            this.label12.TabIndex = 25;
            this.label12.Text = "강의실";
            // 
            // textBox_RoomNum
            // 
            this.textBox_RoomNum.Location = new System.Drawing.Point(867, 27);
            this.textBox_RoomNum.Name = "textBox_RoomNum";
            this.textBox_RoomNum.Size = new System.Drawing.Size(71, 25);
            this.textBox_RoomNum.TabIndex = 24;
            this.textBox_RoomNum.Text = "컴-1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(758, 137);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(180, 47);
            this.button1.TabIndex = 26;
            this.button1.Text = "취소";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Subject_Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 220);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.textBox_RoomNum);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBox_End2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBox_Start2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox_End1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox_Start1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_week2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_week1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_TeacherID);
            this.Controls.Add(this.button_Add);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_tuition);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_Subname);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Subject_Add";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Subject_Add";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Subname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_tuition;
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_TeacherID;
        private Oracle.ManagedDataAccess.Client.OracleConnection oracleConnection1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_week1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_week2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_Start1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_End1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox_year;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_month;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox_End2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox_Start2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox_RoomNum;
        private System.Windows.Forms.Button button1;
    }
}