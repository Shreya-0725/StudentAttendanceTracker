using System;
using System.Data;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    string connStr = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=StudentDB;Integrated Security=True";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadStudents();
            LoadAttendance();
        }
    }

    void LoadStudents()
    {
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT ID, Name FROM Students", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            ddlStudents.DataSource = dr;
            ddlStudents.DataTextField = "Name";
            ddlStudents.DataValueField = "ID";
            ddlStudents.DataBind();
        }
    }

    void LoadAttendance()
    {
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT A.ID, S.Name, A.AttendanceDate, A.Status FROM Attendance A JOIN Students S ON A.StudentID = S.ID", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gvAttendance.DataSource = dt;
            gvAttendance.DataBind();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int studentId = Convert.ToInt32(ddlStudents.SelectedValue);
        string date = txtDate.Text.Trim();
        string status = chkPresent.Checked ? "Present" : "Absent";

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Attendance (StudentID, AttendanceDate, Status) VALUES (@sid, @date, @status)", conn);
            cmd.Parameters.AddWithValue("@sid", studentId);
            cmd.Parameters.AddWithValue("@date", DateTime.Parse(date));
            cmd.Parameters.AddWithValue("@status", status);
            cmd.ExecuteNonQuery();
        }

        LoadAttendance(); // Refresh grid
    }
}
