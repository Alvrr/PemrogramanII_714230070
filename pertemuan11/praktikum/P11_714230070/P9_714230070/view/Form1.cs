using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using P11_714230070.controller;
using P11_714230070.model;

namespace P11_714230070
{
    public partial class Form1 : Form
    {
        Koneksi koneksi = new Koneksi();
        M_mahasiswa m_mhs = new M_mahasiswa();


        public void Tampil()
        {
           
            DataMahasiswa.DataSource = koneksi.ShowData("SELECT * FROM t_mahasiswa");
            DataMahasiswa.Columns[0].HeaderText = "NPM";
            DataMahasiswa.Columns[1].HeaderText = "Nama";
            DataMahasiswa.Columns[2].HeaderText = "Angkatan";
            DataMahasiswa.Columns[3].HeaderText = "Alamat";
            DataMahasiswa.Columns[4].HeaderText = "Email";
            DataMahasiswa.Columns[5].HeaderText = "No Hp";

        }

        public void ResetForm()
        {
            textBoxNPM.Text = "";
            textBoxNama.Text = "";
            comboBoxAngkatan.SelectedIndex = -1;
            textBoxAlamat.Text = "";
            textBoxEmail.Text = "";
            textBoxNohp.Text = "";
            textBoxCariData.Text = "";
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Tampil();
        }

        private void textBoxNPM_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (textBoxNPM.Text == "" || textBoxNama.Text == "" || comboBoxAngkatan.SelectedIndex == -1 || textBoxAlamat.Text == "" || textBoxEmail.Text == "" || textBoxNohp.Text == "")
            {
                MessageBox.Show("Data tidak boleh kosong", "Peringatan",
               MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Mahasiswa mhs = new Mahasiswa();
                m_mhs.Npm = textBoxNPM.Text;
                m_mhs.Nama = textBoxNama.Text;
                m_mhs.Angkatan = comboBoxAngkatan.Text;
                m_mhs.Alamat = textBoxAlamat.Text;
                m_mhs.Email = textBoxEmail.Text;
                m_mhs.Nohp = textBoxNohp.Text;

                mhs.Insert(m_mhs);

                ResetForm();
                Tampil();
            }
        }

        private void DataMahasiswa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxNPM.Text = DataMahasiswa.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBoxNama.Text = DataMahasiswa.Rows[e.RowIndex].Cells[1].Value.ToString();
            comboBoxAngkatan.Text = DataMahasiswa.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBoxAlamat.Text = DataMahasiswa.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBoxEmail.Text = DataMahasiswa.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBoxNohp.Text = DataMahasiswa.Rows[e.RowIndex].Cells[5].Value.ToString();
        }

        private void btnUbah_Click(object sender, EventArgs e)
        {
            if (textBoxNPM.Text == "" || textBoxNama.Text == "" || comboBoxAngkatan.SelectedIndex == -1 || textBoxAlamat.Text == "" || textBoxEmail.Text == "" || textBoxNohp.Text == "")
            {
                MessageBox.Show("Data tidak boleh kosong", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Mahasiswa mhs = new Mahasiswa();
                M_mahasiswa m_mhs = new M_mahasiswa();

                // Isi properti model M_mahasiswa dengan data dari form
                m_mhs.Npm = textBoxNPM.Text;
                m_mhs.Nama = textBoxNama.Text;
                m_mhs.Angkatan = comboBoxAngkatan.Text;
                m_mhs.Alamat = textBoxAlamat.Text;
                m_mhs.Email = textBoxEmail.Text;
                m_mhs.Nohp = textBoxNohp.Text;

                // Panggil metode Update dengan parameter yang benar
                bool result = mhs.Update(m_mhs, textBoxNPM.Text);

                if (result)
                {
                    MessageBox.Show("Data berhasil diubah!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                ResetForm(); // Bersihkan form
                Tampil();    // Refresh tampilan data
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            DialogResult pesan = MessageBox.Show(
                "Apakah yakin akan menghapus data ini?",
                "Perhatian",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question );

            if (pesan == DialogResult.Yes )
            {
                Mahasiswa mhs = new Mahasiswa();
                mhs.Delete(textBoxNPM.Text);
                ResetForm();
                Tampil();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void textBoxCariData_TextChanged(object sender, EventArgs e)
        {
            DataMahasiswa.DataSource = koneksi.ShowData("SELECT * FROM t_mahasiswa WHERE npm LIKE '%' '" + textBoxCariData.Text + "' '%' OR nama LIKE '%' '" + textBoxCariData.Text + "' '%'");
        }
    }
}
