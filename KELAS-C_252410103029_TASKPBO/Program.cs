using System;
using System.Collections.Generic;

// 1. Kelas Induk: Karyawan
public class Karyawan
{
    public string Nama { get; set; }
    public double Gaji { get; set; }

    public Karyawan(string nama, double gaji)
    {
        Nama = nama;
        Gaji = gaji;
    }

    public virtual void Kerja()
    {
        Console.WriteLine($"{Nama} sedang bekerja.");
    }

    public virtual void InfoKaryawan()
    {
        Console.WriteLine($"Nama: {Nama}, Gaji: {Gaji}");
    }
}

// 2. Kelas Turunan: Tetap (Mewarisi Karyawan)
public class Tetap : Karyawan
{
    public double Tunjangan { get; set; }

    public Tetap(string nama, double gaji, double tunjangan) : base(nama, gaji)
    {
        Tunjangan = tunjangan;
    }

    public double HitungGajiTotal()
    {
        return Gaji + Tunjangan;
    }

    public override void InfoKaryawan()
    {
        Console.WriteLine($"Nama: {Nama}, Gaji Pokok: {Gaji}, Tunjangan: {Tunjangan}, Gaji Total: {HitungGajiTotal()}");
    }
}

// 3. Kelas Turunan: Kontrak (Mewarisi Karyawan)
public class Kontrak : Karyawan
{
    public int Durasi { get; set; } // dalam bulan

    public Kontrak(string nama, double gaji, int durasi) : base(nama, gaji)
    {
        Durasi = durasi;
    }

    public void CekKontrak()
    {
        Console.WriteLine($"Kontrak {Nama} berdurasi {Durasi} bulan.");
    }

    public override void InfoKaryawan()
    {
        Console.WriteLine($"Nama: {Nama}, Gaji: {Gaji}, Durasi Kontrak: {Durasi} bulan");
    }
}

// 4. Kelas Turunan dari Tetap: Manager & Staff
public class Manager : Tetap
{
    public Manager(string nama, double gaji, double tunjangan) : base(nama, gaji, tunjangan) { }

    public override void Kerja()
    {
        Console.WriteLine($"{Nama} (Manager) sedang memimpin rapat dan mengelola strategi perusahaan.");
    }

    public void Memimpin()
    {
        Console.WriteLine($"{Nama} sedang memimpin tim dalam proyek baru.");
    }
}

public class Staff : Tetap
{
    public Staff(string nama, double gaji, double tunjangan) : base(nama, gaji, tunjangan) { }

    public override void Kerja()
    {
        Console.WriteLine($"{Nama} (Staff) sedang mengerjakan tugas administratif.");
    }

    public void KerjakanTugas()
    {
        Console.WriteLine($"{Nama} sedang menyelesaikan tugas operasional harian.");
    }
}

// 5. Kelas Turunan dari Kontrak: Magang & Freelancer
public class Magang : Kontrak
{
    public Magang(string nama, double gaji, int durasi) : base(nama, gaji, durasi) { }

    public override void Kerja()
    {
        Console.WriteLine($"{Nama} (Magang) sedang belajar sambil membantu tugas tim.");
    }

    public void Belajar()
    {
        Console.WriteLine($"{Nama} sedang mempelajari teknologi dan alur kerja baru di perusahaan.");
    }
}

public class Freelancer : Kontrak
{
    public Freelancer(string nama, double gaji, int durasi) : base(nama, gaji, durasi) { }

    public override void Kerja()
    {
        Console.WriteLine($"{Nama} (Freelancer) sedang mengerjakan proyek lepasan.");
    }

    public void AmbilProyek()
    {
        Console.WriteLine($"{Nama} mengambil proyek pengembangan fitur baru.");
    }
}

// 6. Kelas Perusahaan
public class Perusahaan
{
    private List<Karyawan> daftarKaryawan = new List<Karyawan>();

    public void TambahKaryawan(Karyawan karyawan)
    {
        daftarKaryawan.Add(karyawan);
        Console.WriteLine($"Karyawan {karyawan.Nama} berhasil ditambahkan ke perusahaan.");
    }

    public void DaftarKaryawan()
    {
        Console.WriteLine("\n--- Daftar Seluruh Karyawan Perusahaan ---");
        foreach (var k in daftarKaryawan)
        {
            k.InfoKaryawan();
        }
    }
}

// Program Utama (Main)
class Program
{
    static void Main(string[] args)
    {
        // Membuat objek perusahaan
        Perusahaan ptMajuMundur = new Perusahaan();

        // Membuat beberapa objek karyawan
        Manager mgr = new Manager("Budi", 10000000, 3000000);
        Staff stf = new Staff("Siti", 5000000, 1000000);
        Magang mgc = new Magang("Andi", 2000000, 6);
        Freelancer frc = new Freelancer("Joko", 7000000, 3);

        // Menambahkan ke perusahaan
        ptMajuMundur.TambahKaryawan(mgr);
        ptMajuMundur.TambahKaryawan(stf);
        ptMajuMundur.TambahKaryawan(mgc);
        ptMajuMundur.TambahKaryawan(frc);

        // Menampilkan semua data
        ptMajuMundur.DaftarKaryawan();

        Console.WriteLine("\n--- Demonstrasi Kasus Soal ---");

        // 1. Jalankan method Kerja() pada objek Manager dan Freelancer
        mgr.Kerja();
        frc.Kerja();

        // 2. Jalankan method Memimpin() pada objek Manager
        mgr.Memimpin();

        // 3. Tampilkan informasi lengkap (nama, gaji, tunjangan) dari objek Manager
        mgr.InfoKaryawan();

        // 4. Jalankan method Belajar() pada objek Magang
        mgc.Belajar();

        // 5. Variabel bertipe Karyawan diisi objek Staff, lalu jalankan method Kerja()
        Karyawan kStaff = new Staff("Rina", 5500000, 1200000);
        kStaff.Kerja();
    }
}
