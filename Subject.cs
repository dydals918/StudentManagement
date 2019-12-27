using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace TeamProjcet
{
    public partial class Subject : Form
    {
        public Subject()
        {
            InitializeComponent();
            aa = false;
            DBManager.GetInstance().DBConnection(oracleConnection1);

            string query = "SELECT id as 과목번호, name as 과목명, tuition as 수강료, teacher_id as 강사번호  FROM SUBJECT ORDER BY ID ASC";
            OracleDataReader rdr = DBManager.GetInstance().ExecuteReader(query);
            dataGridView1.DataSource = null;

            DataTable dt = new DataTable();
            dt.Load(rdr);
            dataGridView1.DataSource = dt;

            comboBox_Search.Items.Add("과목번호");
            comboBox_Search.Items.Add("과목명");
            comboBox_Search.Items.Add("수강료");
            comboBox_Search.Items.Add("강사번호");
            comboBox_Search.Items.Add("월");

            query = "select DISTINCT to_char(sub1.day, 'yyyy') AS yyyy FROM register rt1, subject sub1 WHERE rt1.subject_id = sub1.id";
            OracleDataReader rdr_year = DBManager.GetInstance().ExecuteReader(query);
            while (rdr_year.Read())
            {
                comboBox_year.Items.Add(rdr_year["yyyy"]);
            }

            chart1.Titles.Add("과목 별 수강생 수 변화");
            chart1.Titles[0].Font = new Font(new FontFamily("휴먼모음T"), 15.75f, FontStyle.Bold);
        }

        private void button_Search_Click(object sender, EventArgs e)
        {
            string x;

            try
            {
                x = comboBox_Search.SelectedItem.ToString();
            }
            catch (Exception exception)
            {
                MessageBox.Show("검색키워드를 선택해주십시오.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            switch (x)
            {
                case "과목번호":
                    string id = textBox_Search.Text.ToString();
                    string query = "SELECT * FROM SUBJECT WHERE id = '" + id + "' ORDER BY ID ASC";
                    OracleDataReader rdr = DBManager.GetInstance().ExecuteReader(query);
                    dataGridView1.DataSource = null;

                    DataTable dt = new DataTable();
                    dt.Load(rdr);
                    dataGridView1.DataSource = dt;
                    break;

                case "과목명":
                    string name = textBox_Search.Text.ToString();
                    query = "SELECT * FROM SUBJECT WHERE name like '" + name + "%' ORDER BY ID ASC";
                    OracleDataReader rdr_name = DBManager.GetInstance().ExecuteReader(query);
                    dataGridView1.DataSource = null;

                    dt = new DataTable();
                    dt.Load(rdr_name);
                    dataGridView1.DataSource = dt;
                    break;

                case "수강료":
                    string tuition = textBox_Search.Text.ToString();
                    query = "SELECT * FROM SUBJECT WHERE tuition = '" + tuition + "' ORDER BY ID ASC";
                    OracleDataReader rdr_tuition = DBManager.GetInstance().ExecuteReader(query);
                    dataGridView1.DataSource = null;

                    dt = new DataTable();
                    dt.Load(rdr_tuition);
                    dataGridView1.DataSource = dt;
                    break;

                case "강사번호":
                    string teacher_id = textBox_Search.Text.ToString();
                    query = "SELECT * FROM SUBJECT WHERE teacher_id = '" + teacher_id + "' ORDER BY ID ASC";
                    OracleDataReader rdr_teacher_id = DBManager.GetInstance().ExecuteReader(query);
                    dataGridView1.DataSource = null;

                    dt = new DataTable();
                    dt.Load(rdr_teacher_id);
                    dataGridView1.DataSource = dt;
                    break;

                case "월":
                    try
                    {
                        foreach (DataGridViewRow item in dataGridView1.SelectedRows)
                        {
                            int sub_id = Convert.ToInt32(item.Cells[0].Value.ToString());
                        }
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show("과목을 선택해주십시오.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string day = textBox_Search.Text.ToString();
                    query = "SELECT * FROM lecture WHERE to_char(day, 'mm') = '" + day + "' ORDER BY subject_id, id ASC";
                    OracleDataReader rdr_day = DBManager.GetInstance().ExecuteReader(query);
                    dataGridView2.DataSource = null;

                    dt = new DataTable();
                    dt.Load(rdr_day);
                    dataGridView2.DataSource = dt;
                    break;

                default:
                    MessageBox.Show("데이터가 없습니다", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            Subject_Add subject_add = new Subject_Add();
            subject_add.ShowDialog();

            string query = "SELECT id as 과목번호, name as 과목명, tuition as 수강료, teacher_id as 강사번호  FROM SUBJECT ORDER BY ID ASC";
            OracleDataReader rdr = DBManager.GetInstance().ExecuteReader(query);
            dataGridView1.DataSource = null;

            DataTable dt = new DataTable();
            dt.Load(rdr);
            dataGridView1.DataSource = dt;
        }

        private void button_Del_Click(object sender, EventArgs e)
        {
            string key;
            DialogResult result = MessageBox.Show("삭제하시겠습니까?", "알림", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                foreach (DataGridViewRow item in dataGridView1.SelectedRows)
                {
                    key = item.Cells[0].Value.ToString();

                    string query = "DELETE FROM attendence WHERE lecture_sub_ID = " + Convert.ToInt32(key) + "";
                    int rdr3 = DBManager.GetInstance().ExecuteNon(query);

                    query = "DELETE FROM register WHERE subject_ID = " + Convert.ToInt32(key) + ""; //삭제
                    rdr3 = DBManager.GetInstance().ExecuteNon(query);

                    string query_lecture_del = "DELETE FROM LECTURE WHERE subject_ID = " + Convert.ToInt32(key) + ""; //삭제
                    rdr3 = DBManager.GetInstance().ExecuteNon(query_lecture_del);

                    query = "DELETE FROM SUBJECT WHERE ID = " + Convert.ToInt32(key) + ""; //삭제
                    rdr3 = DBManager.GetInstance().ExecuteNon(query);

                    string query2 = "SELECT id as 과목번호, name as 과목명, tuition as 수강료, teacher_id as 강사번호  FROM SUBJECT ORDER BY ID ASC"; //데이터 그리드뷰 초기화
                    OracleDataReader rdr2 = DBManager.GetInstance().ExecuteReader(query2);

                    DataTable dt = new DataTable();
                    dt.Load(rdr2);
                    dataGridView1.DataSource = dt;
                }

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string subjectID = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(); // 과목아이디 받아오기

            string query = "SELECT id as 과목번호, name as 과목명, tuition as 수강료, teacher_id as 강사번호  FROM SUBJECT ORDER BY ID ASC";
            OracleDataReader rdr = DBManager.GetInstance().ExecuteReader(query);
            dataGridView1.DataSource = null;

            DataTable dt = new DataTable();
            dt.Load(rdr);
            dataGridView1.DataSource = dt;

            query = "SELECT * FROM LECTURE WHERE SUBJECT_ID = " + Convert.ToInt32(subjectID) + " ORDER BY DAY ASC";
            rdr = DBManager.GetInstance().ExecuteReader(query);

            dt = new DataTable();
            dt.Load(rdr);
            dataGridView2.DataSource = dt;
        }

        static bool update = true; //업데이트 조건 최종 true 일 때 업데이트

        private void button_Save_Click(object sender, EventArgs e)
        {
            string key;
            string name;
            string tuition;
            string teacher_id;
            int start_time;
            int end_time;
            string room_num;

            DialogResult result = MessageBox.Show("수정하시겠습니까?", "알림", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    key = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    name = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    tuition = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    teacher_id = dataGridView1.Rows[i].Cells[3].Value.ToString();

                    string query = "UPDATE SUBJECT set name = '" + name + "' tuition = '" + Convert.ToInt32(tuition) + "', teacher_id = '" + Convert.ToInt32(teacher_id) + "' where id = " + Convert.ToInt32(key) + "";
                    int rdr2 = DBManager.GetInstance().ExecuteNon(query);
                }

                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    //데이터 그리드뷰 모든 데이터
                    int sub_id = Convert.ToInt32(dataGridView2.Rows[i].Cells[0].Value.ToString());
                    int id = Convert.ToInt32(dataGridView2.Rows[i].Cells[1].Value.ToString());
                    start_time = Convert.ToInt32(DateParse_time(dataGridView2.Rows[i].Cells[2].Value.ToString()));
                    end_time = Convert.ToInt32(DateParse_time(dataGridView2.Rows[i].Cells[3].Value.ToString()));
                    room_num = dataGridView2.Rows[i].Cells[4].Value.ToString();
                    string supply = dataGridView2.Rows[i].Cells[5].Value.ToString();

                    //날짜 비교를 위한 변수
                    string week_ = DateParse_day(dataGridView2.Rows[i].Cells[2].Value.ToString());

                    //시작시간, 끝시간, 날짜, 방번호, 과목번호를 받아온다. 단, 수정하려는 데이터의 강의는 제외한다.
                    string query = "SELECT to_char(DAY, 'HH24mi') AS DAY_TIME, to_char(END_DAY, 'HH24mi') AS END_DAY_TIME, to_char(DAY, 'yyyy-MM-dd') AS DAY_WEEK, ROOM_NUM, subject_id FROM LECTURE where subject_id not in (" + sub_id + ")";
                    OracleDataReader rdr2 = DBManager.GetInstance().ExecuteReader(query);
                    while (rdr2.Read())
                    {
                        int time_Day = Convert.ToInt32(rdr2["DAY_TIME"]);
                        int time_End_Day = Convert.ToInt32(rdr2["END_DAY_TIME"]);
                        string day_week = rdr2["DAY_WEEK"].ToString();
                        string Room_num_ = rdr2["ROOM_NUM"].ToString();
                        int date_sub_id = Convert.ToInt32(rdr2["subject_id"]);

                        if (week_.Equals(day_week))
                        {
                            if ((time_Day > end_time && time_Day > start_time) || (time_End_Day < end_time) && (time_End_Day < start_time))
                            {
                                if (Room_num_.Equals(room_num))
                                {
                                    update = true;
                                }
                            }
                            else
                            {
                                update = false;
                                MessageBox.Show("이미 강의가 있는 시간입니다. 시간표를 확인하십시오", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                        }
                    }

                    if (update == true)
                    {
                        query = "update lecture set day = to_date('" + DateParse(dataGridView2.Rows[i].Cells[2].Value.ToString()) + "', 'yyyy-mm-dd hh24:mi'), end_day = to_date('" + DateParse(dataGridView2.Rows[i].Cells[3].Value.ToString()) + "', 'yyyy-mm-dd hh24:mi'), room_num = '" + room_num + "' where subject_id = " + sub_id + " AND id = " + id + "";
                        int rdr3 = DBManager.GetInstance().ExecuteNon(query);
                    }
                }
            }
        }

        string DateParse_time(string before)//string을 db DATE형에 맞도록 파싱
        {
            string after;
            string[] splitForYear = before.Split(' '); // [yyyy-mm-dd] [오전||오후] [hh:mm:ss]
            string[] splitForTime = splitForYear[2].Split(':'); //[hh] [mm] [ss]

            after = splitForTime[0];
            if (splitForYear[1] == "오후" && splitForTime[0] != "12")
            {
                after = (int.Parse(splitForTime[0]) + 12).ToString();
            }
            after = after + splitForTime[1]; // 1300
            return after;
        }

        string DateParse_day(string before)//string을 db DATE형에 맞도록 파싱
        {
            string after;
            string[] splitForYear = before.Split(' '); // [yyyy-mm-dd] [오전||오후] [hh:mm:ss]
            string[] splitForTime = splitForYear[2].Split(':'); //[hh] [mm] [ss]

            after = splitForYear[0];

            return after;
        }

        string DateParse(string before)//string을 db DATE형에 맞도록 파싱
        {
            string after;
            string[] splitForYear = before.Split(' '); // [yyyy-mm-dd] [오전||오후] [hh:mm:ss]
            string[] splitForTime = splitForYear[2].Split(':'); //[hh] [mm] [ss]

            after = splitForYear[0];

            if (splitForYear[1] == "오후" && splitForTime[0] != "12")
            {
                after = after + " " + (int.Parse(splitForTime[0]) + 12).ToString();
                after = after + ":" + splitForTime[1]; // 2018-1-21 13:00
            }
            else
            {
                after = after + " " + splitForTime[0] + ":" + splitForTime[1];
            }

            return after;
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
        bool aa;
        private void comboBox_year_SelectedIndexChanged(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            string year = comboBox_year.SelectedItem.ToString();
            int month = 1;
            string mm;
            for (int i = 1; i < 13; i++)
            {
                if (i >= 1 && i < 10)
                    mm = "0" + i.ToString();
                else
                    mm = i.ToString();

                string query = "select subject.name subname, qq.a, qq.b from subject, (select count(*) a, register.subject_id b from register join subject on subject.id = register.subject_id where to_char(register.day, 'yyyymm')='" + comboBox_year.Text + mm + "' group by register.subject_id) qq where subject.id = qq.b";
                OracleDataReader rdr2 = DBManager.GetInstance().ExecuteReader(query);
                if (rdr2.HasRows) 
                {
                    while (rdr2.Read())
                    {
                        string subname = rdr2["subname"].ToString();
                        if (chart1.Series.IsUniqueName(subname) is false)
                        {
                            chart1.Series.Add(rdr2["subname"].ToString());

                        }
                        else
                            chart1.Series["subname"].Points.AddXY(mm, Convert.ToInt32(rdr2["a"]));
                    }
                }

            }
            
        /*
            while (rdr2.Read())
            {
                int mm = Convert.ToInt32(rdr2["mm"]);
                string name = rdr2["sub_name"].ToString() + "-" + rdr2["id"].ToString();

                while (true)
                {
                    if (chart1.Series.IsUniqueName(name) is false)
                    {
                        for (month = 1; month < 13; month++)
                        {
                            if (mm == month)
                            {
                                chart1.Series[name].Points.AddXY(month, Convert.ToInt32(rdr2["stu_num"]));
                            }
                            else
                            {
                                chart1.Series[name].Points.AddXY(month, 0);
                            }
                        }
                        break;
                    }
                    else
                    {
                        chart1.Series.Add(name);
                        chart1.Series[name].ChartType = SeriesChartType.Line;
                    }
                }
            }*/
        }

        private void Subject_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        static string name;
        static int id;
        static int tuition;
        static int teacher_id;

        private void button_extension_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow item in dataGridView1.SelectedRows)
                {
                    name = item.Cells[1].Value.ToString();
                    id = Convert.ToInt32(item.Cells[0].Value.ToString());
                    tuition = Convert.ToInt32(item.Cells[2].Value.ToString());
                    teacher_id = Convert.ToInt32(item.Cells[3].Value.ToString());
                }

                Subject_Add subject_add = new Subject_Add();
                subject_add.Passvalue_id = id;
                subject_add.Passvalue_name = name;
                subject_add.Passvalue_num = 1;
                subject_add.Passvalue_techer = teacher_id;
                subject_add.Passvalue_tuition = tuition;
                subject_add.ShowDialog();
            }
            catch (Exception exception)
            {
                MessageBox.Show("과목을 선택해주세요", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           

            string query = "SELECT id as 과목번호, name as 과목명, tuition as 수강료, teacher_id as 강사번호  FROM SUBJECT ORDER BY ID ASC";
            OracleDataReader rdr = DBManager.GetInstance().ExecuteReader(query);
            dataGridView1.DataSource = null;

            DataTable dt = new DataTable();
            dt.Load(rdr);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "SELECT id as 과목번호, name as 과목명, tuition as 수강료, teacher_id as 강사번호  FROM SUBJECT ORDER BY ID ASC";
            OracleDataReader rdr = DBManager.GetInstance().ExecuteReader(query);
            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;

            DataTable dt = new DataTable();
            dt.Load(rdr);
            dataGridView1.DataSource = dt;
        }
    }
}