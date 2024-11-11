using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P5_4_714230070
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            JenisKelamin.Items.Clear(); // Bersihkan item sebelumnya jika ada
            JenisKelamin.Items.Add("Laki-laki");
            JenisKelamin.Items.Add("Perempuan");
            JenisKelamin.Text = "--Pilih Jenis Kelamin--";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nama = Nama.Text;
            string jenisKelamin = JenisKelamin.SelectedItem?.ToString() ?? "";
            DateTime tanggalLahir = TanggalLahir.Value;

            // Mengambil pilihan kelas
            List<string> pilihanKelas = new List<string>();
            if (SepakBola.Checked) pilihanKelas.Add("Sepak Bola");
            if (Renang.Checked) pilihanKelas.Add("Renang");
            if (Tenis.Checked) pilihanKelas.Add("Tenis");
            if (Yoga.Checked) pilihanKelas.Add("Yoga");
            if (Basket.Checked) pilihanKelas.Add("Basket");
            if (BuluTangkis.Checked) pilihanKelas.Add("Bulu Tangkis");
            if (Voli.Checked) pilihanKelas.Add("Voli");
            if (Panahan.Checked) pilihanKelas.Add("Panahan");

            // Mengambil pilihan jadwal
            string pilihanJadwal = "";
            if (SeninRabu.Checked) pilihanJadwal = "Senin s/d Rabu, 14.00 - 16.00";
            else if (SelasaKamis.Checked) pilihanJadwal = "Selasa s/d Kamis, 14.00 - 16.00";
            else if (SabtuMinggu.Checked) pilihanJadwal = "Sabtu s/d Minggu, 09.00 - 11.00";
            else if (Minggu.Checked) pilihanJadwal = "Minggu, 13.00 - 20.00";

            // Validasi pilihan kelas dan jadwal
            if (pilihanKelas.Count == 0)
            {
                MessageBox.Show("Harus memilih salah satu dari kelas", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(pilihanJadwal))
            {
                MessageBox.Show("Harus memilih salah satu jadwal", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(Nama.Text))
            {
                MessageBox.Show("Nama tidak boleh kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Nama.Focus(); // Fokus pada TextBox Nama
                return; // Menghentikan eksekusi lebih lanjut
            }
            if (JenisKelamin.SelectedIndex == -1)
            {
                MessageBox.Show("Pilih Jenis Kelamin!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                JenisKelamin.Focus(); // Fokus pada ComboBox Jenis Kelamin
                return;
            }
            if (TanggalLahir.Value == DateTime.MinValue || TanggalLahir.Value == DateTime.Now)
            {
                MessageBox.Show("Pilih Tanggal Lahir!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TanggalLahir.Focus(); // Fokus pada DateTimePicker Tanggal Lahir
                return;
            }

            // Menampilkan hasil input
            string hasil = $"Nama: {nama}\nJenis Kelamin: {jenisKelamin}\nTanggal Lahir: {tanggalLahir.ToShortDateString()}\n" +
                           $"Pilihan Kelas: {string.Join(", ", pilihanKelas)}\nPilihan Jadwal: {pilihanJadwal}";

            MessageBox.Show(hasil, "Hasil Pendaftaran", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
