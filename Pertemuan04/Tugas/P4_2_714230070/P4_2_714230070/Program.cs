using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4_2_714230070
{
    internal class Program
    {
        // List untuk menyimpan aktivitas kebugaran
        static List<FitnessActivity> activities = new List<FitnessActivity>();
        static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("Aplikasi Kebugaran Harian");
                Console.WriteLine("1. Tambah Aktivitas");
                Console.WriteLine("2. Lihat Aktivitas");
                Console.WriteLine("3. Keluar");
                Console.Write("Pilih opsi: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddActivity();
                        break;
                    case "2":
                        ViewActivities();
                        break;
                    case "3":
                        running = false;
                        Console.WriteLine("Keluar dari aplikasi. Terima kasih!");
                        break;
                    default:
                        Console.WriteLine("Opsi tidak valid. Silakan pilih lagi.");
                        break;
                }

                Console.WriteLine(); // Spasi tambahan untuk tampilan yang rapi
            }
        }

        // Fungsi untuk menambahkan aktivitas
        static void AddActivity()
        {
            Console.Write("Masukkan nama aktivitas: ");
            string name = Console.ReadLine();

            Console.Write("Masukkan durasi (dalam menit): ");
            if (int.TryParse(Console.ReadLine(), out int duration))
            {
                // Membuat objek FitnessActivity baru dan menambahkannya ke daftar
                FitnessActivity activity = new FitnessActivity(name, duration);
                activities.Add(activity);
                Console.WriteLine("Aktivitas berhasil ditambahkan!");
            }
            else
            {
                Console.WriteLine("Durasi harus berupa angka.");
            }
        }

        // Fungsi untuk melihat daftar aktivitas
        static void ViewActivities()
        {
            if (activities.Count == 0)
            {
                Console.WriteLine("Belum ada aktivitas yang tercatat.");
            }
            else
            {
                Console.WriteLine("Daftar Aktivitas Kebugaran Harian:");
                foreach (var activity in activities)
                {
                    Console.WriteLine(activity.GetDescription());
                }
            }
        }
    }
}
