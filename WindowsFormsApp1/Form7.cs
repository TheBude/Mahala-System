using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label6.Text = DateTime.Now.ToString("hh:mm:ss");
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            timer1.Start();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-RJJLU7JV\\SQLEXPRESS;Initial Catalog=Mahala-System;Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from nafaqa", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-RJJLU7JV\\SQLEXPRESS;Initial Catalog=Mahala-System;Integrated Security=True;Encrypt=False");
            con.Open();
            DataTable dt = new DataTable();


            if (!String.IsNullOrEmpty(textBox1.Text) && textBox1.Text.Length >= 1)
            {
                string searchPattern = textBox1.Text.Substring(0, 1) + "%";
                SqlCommand cmd = new SqlCommand("Select * from ishchi_reja where yonalish LIKE @yonalishPattern", con);
                cmd.Parameters.AddWithValue("@yonalishPattern", searchPattern);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            else
            {
                MessageBox.Show("Iltimos, Qidirish uchun So'z Kiriting.", "Incomplete Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Bunaqa Ma'lumot Topilmadi.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            con.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            this.Hide();
            form3.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=LAPTOP-RJJLU7JV\\SQLEXPRESS;Initial Catalog=Mahala-System;Integrated Security=True;Encrypt=False"))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO nafaqa (id_nafaqa, uy_raqami, nomer, ism, familiya, yosh) VALUES (@id_nafaqa, @uy_raqami, @nomer, @ism, @familiya, @yosh )", con);

                    cmd.Parameters.AddWithValue("@id_nafaqa", int.Parse(textBox1.Text));
                    cmd.Parameters.AddWithValue("@uy_raqami", textBox2.Text);
                    cmd.Parameters.AddWithValue("@ism", textBox3.Text);
                    cmd.Parameters.AddWithValue("@familiya", textBox4.Text);
                    cmd.Parameters.AddWithValue("@nomer", textBox5.Text);
                    cmd.Parameters.AddWithValue("@yosh", textBox6.Text);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Muvoffaqiyatli qo'shildi!", "Yaxshi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xatolik: " + ex.ToString(), "Xatolik", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-RJJLU7JV\\SQLEXPRESS;Initial Catalog=Mahala-System;Integrated Security=True;Encrypt=False");
                con.Open();
                SqlCommand cmd = new SqlCommand("Update nafaqa set uy_raqami=@uy_raqami, nomer=@nomer, ism= @ism, familiya=@familiya, yosh=@yosh where id_nafaqa=@id_nafaqa", con);

                cmd.Parameters.AddWithValue("@id_nafaqa", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@uy_raqami", textBox2.Text);
                cmd.Parameters.AddWithValue("@ism", textBox3.Text);
                cmd.Parameters.AddWithValue("@familiya", textBox4.Text);
                cmd.Parameters.AddWithValue("@nomer", textBox5.Text);
                cmd.Parameters.AddWithValue("@yosh", textBox6.Text);
                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Muvfoqiyatli Yangilandi!", "Yaxshi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
            }
            catch
            {
                MessageBox.Show("Notug'ri Kiritildi!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-RJJLU7JV\\SQLEXPRESS;Initial Catalog=Mahala-System;Integrated Security=True;Encrypt=False");
                con.Open();
                SqlCommand cmd = new SqlCommand("Delete nafaqa where id_nafaqa=@id_nafaqa", con);
                cmd.Parameters.AddWithValue("@id_nafaqa", int.Parse(textBox1.Text));
                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Muvfoqiyatli O'chirildi!", "Yaxshi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
            }
            catch
            {
                MessageBox.Show("Notug'ri Kiritildi!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-RJJLU7JV\\SQLEXPRESS;Initial Catalog=Mahala-System;Integrated Security=True;Encrypt=False");
            con.Open();
            DataTable dt = new DataTable();

            if (!String.IsNullOrEmpty(textBox1.Text))
            {
                int idValue;
                if (int.TryParse(textBox1.Text, out idValue))
                {
                    SqlCommand cmd = new SqlCommand("Select * from nafaqa where id_nafaqa=@id_nafaqa", con);
                    cmd.Parameters.AddWithValue("@id_nafaqa", idValue);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
                else
                {
                    MessageBox.Show("Please enter a valid numeric ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (!String.IsNullOrEmpty(textBox3.Text) && textBox3.Text.Length >= 1)
            {
                string searchPattern = textBox3.Text.Substring(0, 1) + "%";
                SqlCommand cmd = new SqlCommand("Select * from nafaqa where ism LIKE @ismPattern", con);
                cmd.Parameters.AddWithValue("@ismPattern", searchPattern);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            else
            {
                MessageBox.Show("Iltimos, Qidirish uchun So'z Kiriting.", "Incomplete Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Bunaqa Ma'lumot Topilmadi.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["id_nafaqa"].FormattedValue.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["ism"].FormattedValue.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["uy_raqami"].FormattedValue.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["familiya"].FormattedValue.ToString();
                textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells["yosh"].FormattedValue.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["nomer"].FormattedValue.ToString();
            }
            else
            {
                MessageBox.Show("Olib Bo'lmadi!", "Xatolik", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
