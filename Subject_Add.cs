using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeamProjcet
{
    public partial class Subject_Add : Form
    {
        public Subject_Add()
        {
            InitializeComponent();
        }

        static int num = 0;
        static int id;

        public int Passvalue_num
        {
            get { return num; }
            set { num = value; }  // 다른폼(Form1)에서 전달받은 값을 쓰기
        }

        public int Passvalue_id
        {
            get { return id; }
            set { id = value; }  // 다른폼(Form1)에서 전달받은 값을 쓰기
        }

        public string Passvalue_name
        {
            get { return textBox_Subname.ToString(); }
            set { textBox_Subname.Text = value; }  // 다른폼(Form1)에서 전달받은 값을 쓰기
        }

        public int Passvalue_tuition
        {
            get { return Convert.ToInt32(textBox_tuition.Text); }
            set { textBox_tuition.Text = value.ToString(); }  // 다른폼(Form1)에서 전달받은 값을 쓰기
        }

        public int Passvalue_techer
        {
            get { return Convert.ToInt32(textBox_TeacherID.Text); }
            set { textBox_TeacherID.Text = value.ToString(); }  // 다른폼(Form1)에서 전달받은 값을 쓰기
        }

        private string GetDay(DateTime dt)
        {
            string strDay = "";
            switch (dt.DayOfWeek)
            {

                case DayOfWeek.Monday:
                    strDay = "월";
                    break;

                case DayOfWeek.Tuesday:
                    strDay = "화";
                    break;

                case DayOfWeek.Wednesday:
                    strDay = "수";
                    break;

                case DayOfWeek.Thursday:
                    strDay = "목";
                    break;

                case DayOfWeek.Friday:
                    strDay = "금";
                    break;

                case DayOfWeek.Saturday:
                    strDay = "토";
                    break;

                case DayOfWeek.Sunday:
                    strDay = "일";
                    break;
            }
            return strDay;
        }

        //텍스트가 비었는가 검사
        private int textIsFull()
        {
            if ((textBox_End1.Text == "" || textBox_End2.Text == "") || (textBox_Start1.Text == "" || textBox_Start2.Text == ""))
            {
                MessageBox.Show("시간이 다 입력되지 않았습니다. 확인해주세요", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 3;
            }

            if (textBox_Subname.Text == "")
            {
                MessageBox.Show("과목명이 입력되지 않았습니다. 확인해주세요", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 3;
            }

            if (textBox_TeacherID.Text == "")
            {
                MessageBox.Show("강사번호가 입력되지 않았습니다. 확인해주세요", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 3;
            }

            if (textBox_RoomNum.Text == "")
            {
                MessageBox.Show("강의실이 입력되지 않았습니다. 확인해주세요", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 3;
            }

            if (textBox_month.Text == "" || textBox_year.Text == "")
            {
                MessageBox.Show("년도 또는 월이 입력되지 않았습니다. 확인해주세요", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 3;
            }

            if (textBox_tuition.Text == "")
            {
                MessageBox.Show("수강료가 입력되지 않았습니다. 확인해주세요", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 3;
            }

            if (textBox_week1.Text == "" || textBox_week2.Text == "")
            {
                MessageBox.Show("요일이 입력되지 않았습니다. 확인해주세요", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 3;
            }

            return 5;
        }

        //수강료텍스트 박스에 숫자만 입력가능하게 함
        private void textBox_tuition_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }

        //년도_텍스트 박스에 숫자만 입력가능하게 함
        private void textBox_year_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }

        //월_텍스트 박스에 숫자만 입력가능하게 함
        private void textBox_month_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            int y = textIsFull();

            if (y == 3)
            {
                return;
            }

            string query_ex = "SELECT id From teacher";
            OracleDataReader rdr_ex = DBManager.GetInstance().ExecuteReader(query_ex);
            while (rdr_ex.Read())
            {
                if(!textBox_TeacherID.Text.Equals(rdr_ex["id"].ToString()))
                {
                    MessageBox.Show("없는 강사번호입니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            query_ex = "SELECT room From room";
            rdr_ex = DBManager.GetInstance().ExecuteReader(query_ex);
            while (rdr_ex.Read())
            {
                if (!textBox_RoomNum.Text.Equals(rdr_ex["room"].ToString()))
                {
                    MessageBox.Show("없는 강의실입니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            //과목 추가
            int tuition = Convert.ToInt32(textBox_tuition.Text);
            int teacherID = Convert.ToInt32(textBox_TeacherID.Text);
            string year = textBox_year.Text.ToString();
            //if(textBox_month.Text)
            string month = textBox_month.Text.ToString();
            string subjectName = textBox_Subname.Text.ToString();
            string Room = textBox_RoomNum.Text;

            ////강의1 추가
            string week_1 = textBox_week1.Text;
            string week_2 = textBox_week2.Text;

            //시간비교를 위해 입력받은 값을 인트형으로 변환
            string[] temp = textBox_Start1.Text.Split(':');
            int time_StartTime1 = Convert.ToInt32(temp[0] + temp[1]);
            temp = textBox_End1.Text.Split(':');
            int time_EndTime1 = Convert.ToInt32(temp[0] + temp[1]);

            temp = textBox_Start2.Text.Split(':');
            int time_StartTime2 = Convert.ToInt32(temp[0] + temp[1]);
            temp = textBox_End2.Text.Split(':');
            int time_EndTime2 = Convert.ToInt32(temp[0] + temp[1]);

            DateTime dateTime2 = DateTime.ParseExact("" + year + "" + month + "01", "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);

            //강의 시간 입력하기

            int lectureID = 1;
            DateTime a = dateTime2;

            bool update = true; //업데이트 조건 최종 true 일 때 

            if (num == 1)
            {
                query_ex = "SELECT subject_id, to_char(DAY, 'HH24mi') AS DAY_TIME, to_char(END_DAY, 'HH24mi') AS END_DAY_TIME, to_char(DAY, 'dy','NLS_DATE_LANGUAGE=korean') AS DAY_WEEK, to_char(DAY, 'mm') AS DAY_MONTH, to_char(DAY, 'yyyy') AS DAY_YEAR, ROOM_NUM FROM LECTURE where  to_char(DAY, 'yyyy')='"+textBox_year.Text+ "' and  to_char(DAY, 'mm')='"+textBox_month.Text+"'";
                rdr_ex = DBManager.GetInstance().ExecuteReader(query_ex);
                while (rdr_ex.Read())
                {
                    //비교를 위한 변수들
                    string sub_id = rdr_ex["subject_id"].ToString();
                    int time_Day = Convert.ToInt32(rdr_ex["DAY_TIME"]);
                    int time_End_Day = Convert.ToInt32(rdr_ex["END_DAY_TIME"]);
                    string day_week = rdr_ex["DAY_WEEK"].ToString();
                    string Room_num = rdr_ex["ROOM_NUM"].ToString();
                    string day_month = rdr_ex["DAY_MONTH"].ToString();
                    string day_year = rdr_ex["DAY_YEAR"].ToString();

                    a = dateTime2;

                    if ((id == Convert.ToInt32(sub_id)) && ((day_month.Equals(month)) && year.Equals(day_year)))
                    {
                        MessageBox.Show("이미 있는 달을 입력하셧습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    string realmonth="";
                    if (a.Month >= 1 && a.Month <= 9)
                    {
                        realmonth = "0" + a.Month.ToString();
                    }


                    //달이 넘어가면 멈춤
                    while (realmonth.Equals(month))
                    {
                        if(year.Equals(day_year))
                        {
                            //달이 같은지 검사
                            if (month.Equals(day_month))
                            {
                                //요일을 한글로 변환해서 받아옴
                                string week = GetDay(a);

                                //요일이 일치하는지 검사
                                if (week.Equals(week_1))
                                {
                                    //강의실이 같은지 검사
                                    if (Room_num.Equals(Room))
                                    {
                                        //시간 비교
                                        if ((time_Day > time_EndTime1 && time_Day > time_StartTime1) || (time_End_Day < time_EndTime1) && (time_End_Day < time_StartTime1))
                                        {
                                            update = true;
                                        }
                                        else
                                        {
                                            update = false;

                                            MessageBox.Show("이미 " + textBox_week1.Text + "요일의 강의가 있는 시간입니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            break;
                                        }
                                    }
                                }

                                if (week.Equals(week_2))
                                {
                                    if (Room_num.Equals(Room))
                                    {
                                        if ((time_Day > time_EndTime2 && time_Day > time_StartTime2) || (time_End_Day < time_EndTime2) && (time_End_Day < time_StartTime2))
                                        {
                                            update = true;
                                        }
                                        else
                                        {
                                            update = false;

                                            MessageBox.Show("이미 " + textBox_week2.Text + "요일의 강의가 있는 시간입니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            break;
                                        }
                                    }
                                }
                            }
                        }                        
                        //날을 하루 씩 증가
                        a = a.AddDays(1);
                        if (a.Month >= 1 && a.Month <= 9)
                        {
                            realmonth = "0" + a.Month.ToString();
                        }
                    }

                    if (update == false)
                    {
                        break;
                    }
                }

                a = dateTime2;
                string realmonth2 = "";
                if (a.Month >= 1 && a.Month <= 9)
                {
                    realmonth2 = "0" + a.Month.ToString();
                }
                //강의 추가
                while (realmonth2.Equals(month))
                {
                    if (update == true)
                    {
                        string week = GetDay(a);

                        if (week.Equals(week_1))
                        {
                            //강의1 추가
                            string start_time1 = a.ToString("yyyyMMdd");
                            string end_time1 = a.ToString("yyyyMMdd");
                            string start = start_time1 + textBox_Start1.Text;
                            string end = end_time1 + textBox_End1.Text;

                            string query3 = "INSERT INTO LECTURE(SUBJECT_ID, ID, DAY, END_DAY, ROOM_NUM)" + "VALUES(" + id + "," + lectureID + ",to_date('" + start + "', 'yyyy-mm-dd hh24:mi'), to_date('" + end + "', 'yyyy-mm-dd hh24:mi'), '" + textBox_RoomNum.Text + "')";
                            int rdr3 = DBManager.GetInstance().ExecuteNon(query3);
                            lectureID++;
                        }

                        if (week.Equals(week_2))
                        {
                            //강의2 추가
                            string start_time2 = a.ToString("yyyyMMdd");
                            string end_time2 = a.ToString("yyyyMMdd");
                            string start2 = start_time2 + textBox_Start2.Text;
                            string end2 = end_time2 + textBox_End2.Text;

                            string query3 = "INSERT INTO LECTURE(SUBJECT_ID, ID, DAY, END_DAY, ROOM_NUM)" + "VALUES(" + id + "," + lectureID + ",to_date('" + start2 + "', 'yyyy-mm-dd hh24:mi'), to_date('" + end2 + "', 'yyyy-mm-dd hh24:mi'), '" + textBox_RoomNum.Text + "')";
                            int rdr3 = DBManager.GetInstance().ExecuteNon(query3);
                            lectureID++;
                        }
                    }
                    //날을 하루 씩 증가
                    a = a.AddDays(1);
                    if (a.Month >= 1 && a.Month <= 9)
                    {
                        realmonth2 = "0" + a.Month.ToString();
                    }
                }
            }

            if (num == 1)
            {
                return;
            }

            lectureID = 1;
            a = dateTime2;


            string dateTime = DateParse(DateTime.ParseExact("" + year + "" + month + "", "yyyyMM", System.Globalization.CultureInfo.InvariantCulture).ToString());
            string query = "INSERT INTO SUBJECT(ID, NAME, TUITION, TEACHER_ID, DAY)" + "VALUES(SEQ_SUBJECT.nextval,'" + subjectName + "'," + tuition + "," + teacherID + ",to_date('" + dateTime + "', 'yyyy-mm-dd hh24:mi'))";
            OracleDataReader rdr = DBManager.GetInstance().ExecuteReader(query);

            query = "SELECT SEQ_SUBJECT.currval from dual";
            int subject_ID = Convert.ToInt32(DBManager.GetInstance().DBSaclar(query));
            
            //과목 추가

            query = "SELECT to_char(DAY, 'HH24mi') AS DAY_TIME, to_char(END_DAY, 'HH24mi') AS END_DAY_TIME, to_char(DAY, 'dy','NLS_DATE_LANGUAGE=korean') AS DAY_WEEK, to_char(DAY, 'mm') AS DAY_MONTH, ROOM_NUM FROM LECTURE";
            OracleDataReader rdr2 = DBManager.GetInstance().ExecuteReader(query);
            while (rdr2.Read())
            {
                //비교를 위한 변수들
                int time_Day = Convert.ToInt32(rdr2["DAY_TIME"]);
                int time_End_Day = Convert.ToInt32(rdr2["END_DAY_TIME"]);
                string day_week = rdr2["DAY_WEEK"].ToString();
                string Room_num = rdr2["ROOM_NUM"].ToString();
                string day_month = rdr2["DAY_MONTH"].ToString();

                a = dateTime2;
                
                //달이 넘어가면 멈춤
                while (a.Month.ToString().Equals(month))
                {
                    //달이 같은지 검사
                    if (month.Equals(day_month))
                    {
                        //요일을 한글로 변환해서 받아옴
                        string week = GetDay(a);

                        //요일이 일치하는지 검사
                        if (week.Equals(week_1))
                        {
                            //강의실이 같은지 검사
                            if (Room_num.Equals(Room))
                            {
                                //시간 비교
                                if ((time_Day > time_EndTime1 && time_Day > time_StartTime1) || (time_End_Day < time_EndTime1) && (time_End_Day < time_StartTime1))
                                {
                                    update = true;
                                }
                                else
                                {
                                    query = "DELETE FROM SUBJECT WHERE ID = " + subject_ID + "";
                                    int rdr_del = DBManager.GetInstance().ExecuteNon(query);

                                    update = false;

                                    MessageBox.Show("이미 " + textBox_week1.Text + "요일의 강의가 있는 시간입니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    break;
                                }
                            }
                        }

                        if (week.Equals(week_2))
                        {
                            if (Room_num.Equals(Room))
                            {
                                if ((time_Day > time_EndTime2 && time_Day > time_StartTime2) || (time_End_Day < time_EndTime2) && (time_End_Day < time_StartTime2))
                                {
                                    update = true;
                                }
                                else
                                {
                                    query = "DELETE FROM SUBJECT WHERE ID = " + subject_ID + "";
                                    int rdr_del = DBManager.GetInstance().ExecuteNon(query);

                                    update = false;

                                    MessageBox.Show("이미 " + textBox_week2.Text + "요일의 강의가 있는 시간입니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    break;
                                }
                            }
                        }
                    }
                    //날을 하루 씩 증가
                    a = a.AddDays(1);
                }

                if (update == false)
                {
                    break;
                }
            }

            a = dateTime2;

            //강의 추가
            while (a.Month.ToString().Equals(month))
            {
                if (update == true)
                {
                    string week = GetDay(a);

                    if (week.Equals(week_1))
                    {
                        //강의1 추가
                        string start_time1 = a.ToString("yyyyMMdd");
                        string end_time1 = a.ToString("yyyyMMdd");
                        string start = start_time1 + textBox_Start1.Text;
                        string end = end_time1 + textBox_End1.Text;

                        string query3 = "INSERT INTO LECTURE(SUBJECT_ID, ID, DAY, END_DAY, ROOM_NUM)" + "VALUES(" + subject_ID + "," + lectureID + ",to_date('" + start + "', 'yyyy-mm-dd hh24:mi'), to_date('" + end + "', 'yyyy-mm-dd hh24:mi'), '" + textBox_RoomNum.Text + "')";
                        int rdr3 = DBManager.GetInstance().ExecuteNon(query3);
                        lectureID++;
                    }

                    if (week.Equals(week_2))
                    {
                        //강의2 추가
                        string start_time2 = a.ToString("yyyyMMdd");
                        string end_time2 = a.ToString("yyyyMMdd");
                        string start2 = start_time2 + textBox_Start2.Text;
                        string end2 = end_time2 + textBox_End2.Text;

                        string query3 = "INSERT INTO LECTURE(SUBJECT_ID, ID, DAY, END_DAY, ROOM_NUM)" + "VALUES(" + subject_ID + "," + lectureID + ",to_date('" + start2 + "', 'yyyy-mm-dd hh24:mi'), to_date('" + end2 + "', 'yyyy-mm-dd hh24:mi'), '" + textBox_RoomNum.Text + "')";
                        int rdr3 = DBManager.GetInstance().ExecuteNon(query3);
                        lectureID++;
                    }
                }

                //날을 하루 씩 증가
                a = a.AddDays(1);
            }
        }

        string DateParse(string before)//string을 db DATE형에 맞도록 파싱
        {
            string after;
            string[] splitForYear = before.Split(' '); // [yyyy-mm-dd] [오전||오후] [hh:mm:ss]
            string[] splitForTime = splitForYear[2].Split(':'); //[hh] [mm] [ss]

            after = splitForYear[0];
            if (splitForYear[1] == "오후")
            {
                after = after + " " + (int.Parse(splitForTime[0]) + 12).ToString();
            }
            after = after + ":" + splitForTime[1]; // 2018-1-21 13:00
            return after;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
