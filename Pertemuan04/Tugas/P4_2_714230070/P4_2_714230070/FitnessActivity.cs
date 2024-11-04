using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4_2_714230070
{
    internal class FitnessActivity
    {
        private string name;          // Nama aktivitas
        private int duration;          // Durasi dalam menit
        private double caloriesBurned; // Kalori yang terbakar

        // Constructor untuk inisialisasi aktivitas
        public FitnessActivity(string name, int duration)
        {
            this.name = name;
            this.duration = duration;
            this.caloriesBurned = CalculateCalories();
        }

        // Metode untuk menghitung kalori yang terbakar
        private double CalculateCalories()
        {
            const double calorieRate = 5.0; // Kalori per menit sebagai contoh
            return duration * calorieRate;
        }

        // Metode untuk mendapatkan deskripsi aktivitas
        public string GetDescription()
        {
            return $"{name} - {duration} menit, {caloriesBurned} kalori terbakar";
        }
    }
}
