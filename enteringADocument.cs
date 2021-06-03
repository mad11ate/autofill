using Microsoft.Office.Interop.Excel;
using System; 
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;


namespace autofillDatabase_0._0._1
{
    public partial class enteringADocument : Form
    {
        string InsertQuery = "INSERT INTO dbo.tblPlanAZS(KPI_Key, AZS_Key, PlanPeriod, PlanValue) VALUES(@KK, @AK, CONVERT(date, @DT, 104), @PV)";
        static string conn = @"Data Source=" + Storage.IPAddress + "," + Storage.port + ";Initial Catalog=PlanAZS_DB;User ID=" + Storage.login + ";Password=" + Storage.password;
        SqlConnection myConnection = new SqlConnection(conn);
        DataSet table = new DataSet();

        public enteringADocument()
        {
            InitializeComponent();  
        }

        string filePath;
        int week = 0;
        int _list = 0;

        OpenFileDialog ofd = new OpenFileDialog();

        private void openFileButton_Click(object sender, EventArgs e)
        {
            ofd.Filter = "XLS|*.xls";
            ofd.Filter = "XLSX|*.xlsx";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.safeFileName.Text = ofd.FileName;
                this.fileName.Text = ofd.SafeFileName;
                filePath = this.safeFileName.Text;
            }       
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            DialogResult res = new DialogResult();
            res = MessageBox.Show("Вы действительно хотите выйти?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res.ToString() == "Yes")
            {
                System.Windows.Forms.Application.Exit();
            }
        }

        private void closeButton_MouseEnter(object sender, EventArgs e)
        {
            closeButton.ForeColor = Color.White;
            closeButton.BackColor = Color.Red;
        }

        private void closeButton_MouseLeave(object sender, EventArgs e)
        {
            closeButton.ForeColor = Color.Black;
            closeButton.BackColor = Color.Transparent;
        }

        System.Drawing.Point lastPoint;
        private void enteringADocument_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void enteringADocument_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new System.Drawing.Point(e.X, e.Y);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            connectionForm newForm = new connectionForm();
            newForm.Show();
        }      

        private void downloadButton_Click(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            DayOfWeek d = time.DayOfWeek;
            switch (d)
            {
                case DayOfWeek.Sunday:
                    TimeSpan t6 = new TimeSpan(6, 0, 0, 0);
                    time -= t6;
                    break;

                case DayOfWeek.Monday:
                    TimeSpan t0 = new TimeSpan(0, 0, 0, 0);
                    time -= t0;
                    break;

                case DayOfWeek.Tuesday:
                    TimeSpan t1 = new TimeSpan(1, 0, 0, 0);
                    time -= t1;
                    break;

                case DayOfWeek.Wednesday:
                    TimeSpan t2 = new TimeSpan(2, 0, 0, 0);
                    time -= t2;
                    break;

                case DayOfWeek.Thursday:
                    TimeSpan t3 = new TimeSpan(3, 0, 0, 0);
                    time -= t3;
                    break;

                case DayOfWeek.Friday:
                    TimeSpan t4 = new TimeSpan(4, 0, 0, 0);
                    time -= t4;
                    break;

                case DayOfWeek.Saturday:
                    TimeSpan t5 = new TimeSpan(6, 0, 0, 0);
                    time -= t5;
                    break;
            }

            string AZS_Key ="";

            try
            {
                _list = Convert.ToInt16(AZSComboBox.Text.Trim(new char[] { 'А', 'З', 'С', ' ' }));
                week = Convert.ToInt16(weekComboBox.Text);
            }

            catch(Exception ex) { MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            try
            {
                switch (_list)
                {
                    case 1: AZS_Key = "50006EAB-0256-C376-11E9-755C4A74F271"; break;
                    case 3: _list = _list - 1; AZS_Key = "50006EAB-0256-C376-11E9-755C4A74F273"; break;
                    case 4: _list = _list - 1; AZS_Key = "50006EAB-0256-C376-11E9-755C4A74F274"; break;
                    case 5: _list = _list - 1; AZS_Key = "50006EAB-0256-C376-11E9-755C4A74F275"; break;
                    case 6: _list = _list - 1; AZS_Key = "50006EAB-0256-C376-11E9-755C4A74F276"; break;
                    case 7: _list = _list - 1; AZS_Key = "50006EAB-0256-C376-11E9-755C4A74F277"; break;
                    case 8: _list = _list - 1; AZS_Key = "50006EAB-0256-C376-11E9-755C4A74F278"; break;
                    case 9: _list = _list - 1; AZS_Key = "50006EAB-0256-C376-11E9-755C4A74F279"; break;
                    case 10: _list = _list - 1; AZS_Key = "50006EAB-0256-C376-11E9-755C4A74F210"; break;
                    case 13: _list = _list - 3; AZS_Key = "50006EAB-0256-C376-11E9-755C4A74F213"; break;
                    case 14: _list = _list - 3; AZS_Key = "50006EAB-0256-C376-11E9-755C4A74F214"; break;
                    case 15: _list = _list - 3; AZS_Key = "50006EAB-0256-C376-11E9-755C4A74F215"; break;
                    case 16: _list = _list - 3; AZS_Key = "50006EAB-0256-C376-11E9-755C4A74F216"; break;
                    case 17: _list = _list - 3; AZS_Key = "50006EAB-0256-C376-11E9-755C4A74F217"; break;
                    case 18: _list = _list - 3; AZS_Key = "50006EAB-0256-C376-11E9-755C4A74F218"; break;
                    case 19: _list = _list - 3; AZS_Key = "50006EAB-0256-C376-11E9-755C4A74F219"; break;
                    case 20: _list = _list - 3; AZS_Key = "50006EAB-0256-C376-11E9-755C4A74F220"; break;
                    case 21: _list = _list - 3; AZS_Key = "50006EAB-0256-C376-11E9-755C4A74F221"; break;
                    case 23: _list = _list - 4; AZS_Key = "50006EAB-0256-C376-11E9-755C4A74F223"; break;
                    case 24: _list = _list - 4; AZS_Key = "50006EAB-0256-C376-11E9-755C4A74F224"; break;
                    case 25: _list = _list - 4; AZS_Key = "50006EAB-0256-C376-11E9-755C4A74F225"; break;
                }
            

                Excel.Application ObjWorkExcel = new Excel.Application(); 
                Workbook ObjWorkBook = ObjWorkExcel.Workbooks.Open(safeFileName.Text, 
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, 
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, 
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, 
                    Type.Missing, Type.Missing); 
                Worksheet ObjWorkSheet = (Worksheet)ObjWorkBook.Sheets[_list + 24];
              
                string arra;
                float KPI_Key = 0f;

                myConnection.Open();

                for (int i = 0; i < 35 ; i++)
                {
                    arra = ObjWorkSheet.Cells[i + 10, week + 3].Text.ToString();
                    KPI_Key = i + 3.0f;                   

                    if (arra != "")
                    {
                        loadingInSQL(KPI_Key, AZS_Key, arra);
                        arra = "";
                    }

                    if (((i == 4) || (i == 30) || (i == 34)) && (arra != ""))
                    {
                        KPI_Key = KPI_Key + 0.1f;
                        loadingInSQL(KPI_Key, AZS_Key, arra);
                        arra = "";
                        KPI_Key = KPI_Key - 0.1f;
                    }

                        if (i == 5) i = i + 24;                  

                }

                arra = ObjWorkSheet.Cells[137, week + 3].Text.ToString();
                KPI_Key = 47.0f;

                if (arra != "") loadingInSQL(KPI_Key, AZS_Key, arra);

                for (int i = 51; i < 57; i++)
                {
                    arra = ObjWorkSheet.Cells[i + 10, week + 3].Text.ToString();
                    KPI_Key = i + 2.0f;

                    if (arra != "")
                    {
                        loadingInSQL(KPI_Key, AZS_Key, arra);
                        arra = "";                      
                    }

                    if (i == 53) i++;
                }

                for (int i = 71; i < 72; i++)
                {
                    arra = ObjWorkSheet.Cells[i + 10, week + 3].Text.ToString();
                    KPI_Key = i + 2.0f;

                    if (arra != "")
                    {
                        loadingInSQL(KPI_Key, AZS_Key, arra);
                        arra = "";
                    }
                }

                myConnection.Close();

                ObjWorkBook.Close(false, Type.Missing, Type.Missing); 
                ObjWorkExcel.Quit(); 

                GC.Collect();
  
                week = _list = 0;
            }

            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }

        public void loadingInSQL(float KPI_Key, string AZS_Key, string arra)
        {
            Guid _AZS_Key = Guid.NewGuid();
            Guid.TryParse(AZS_Key, out _AZS_Key);
            float _arra = float.Parse(arra.ToString());
            SqlCommand command = new SqlCommand(InsertQuery, myConnection);
            command.Parameters.Add("@KK", SqlDbType.Float).Value = KPI_Key;
            command.Parameters.Add("@AK", SqlDbType.UniqueIdentifier).Value = _AZS_Key;
            command.Parameters.Add("@PV", SqlDbType.Float).Value = _arra;
            command.Parameters.Add("@DT", SqlDbType.Float).Value = _arra;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(table);
        }

        private void weekTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == 8) { }
            else e.Handled = true;
        }

        private void listNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == 8) { }
            else e.Handled = true;
        }
    }
}   
