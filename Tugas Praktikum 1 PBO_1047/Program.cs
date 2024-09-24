using System.Buffers;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;

class Program
{
    static void Main(string[] args)
    {
        //Objek kebun binatang
        KebunBinatang Bonbin = new KebunBinatang();

        //Membuat beberapa objek hewan
        Console.WriteLine("== Hewan baru yang telah ditambahkan ke kebun binatang ==");
        Singa SingaHutan = new Singa("Mia", 4, 4);
        Singa SingaKandang = new Singa("Narnia", 8, 4);
        Gajah GajahThailand = new Gajah("Bobo", 12, 4);
        Gajah GajahSumatera = new Gajah("Titi", 14, 4);
        Ular Cobra = new Ular("Besti", 20, "1 meter");
        Buaya BuayaMuara = new Buaya("Kancil", 30, "2 meter");

        //Menambahkan hewan ke kebun binatang
        Bonbin.TambahHewan(SingaHutan);
        Bonbin.TambahHewan(GajahThailand);
        Bonbin.TambahHewan(GajahSumatera);
        Bonbin.TambahHewan(Cobra);
        Bonbin.TambahHewan(BuayaMuara);

        //Menampilkan daftar hewan
        Bonbin.DaftarHewan();

        //Demonstrasi polimorphism dengan memanggil method Suara()
        Console.WriteLine("\n== Demonstrasi Polimorphism ==");
        Console.WriteLine("Ini adalah suara singa");
        Console.WriteLine(SingaHutan.Suara());
        Console.WriteLine("Ini adalah suara buaya");
        Console.WriteLine(BuayaMuara.Suara());

        //Memanggil method kuhusus untuk singa
        SingaKandang.Mengaum();

        //SOAL 1
        Console.WriteLine("\n// Soal 1 //");
        Console.WriteLine(GajahThailand.Suara());
        Console.WriteLine(Cobra.Suara());

        //SOAL 2
        Console.WriteLine("\n// Soal 2 //");
        SingaHutan.Mengaum();

        //SOAL 3
        Console.WriteLine("\n// Soal 3 //");
        Console.WriteLine("Informasi lengkap hewan : ");
        SingaHutan.InfoHewan();

        //SOAL 4
        Console.WriteLine("\n// Soal 4 //");
        Cobra.Merayap("sore");

        //SOAL 5
        Console.WriteLine("\n// Soal 4 //");
        Reptil reptil = new Buaya("Luna", 11, "2 meter");
        Console.WriteLine(reptil.Suara());
    }
}

public class Hewan
{
    //Atribut//
    public string Nama;
    public int Umur;

    //Constructor//
    public Hewan(string Nama, int Umur)
    {
        this.Nama = Nama;
        this.Umur = Umur;
    }
    //Method//
    public virtual string Suara()
    {
        return $"Hewan ini bersuara: ";
    }
    public virtual void InfoHewan()
    {
        Console.WriteLine($"Nama : {Nama}\nUmur : {Umur}");
    }
}

public class Mamalia : Hewan
{
    //Atribut//
    public int jumlahKaki;

    //Constructor//
    public Mamalia(string Nama, int Umur, int jumlahKaki) : base(Nama, Umur)
    {
        this.jumlahKaki = jumlahKaki;
    }
    public override void InfoHewan()
    {
        Console.WriteLine($"Nama : {Nama}\nUmur : {Umur}\nJumlah Kaki : {jumlahKaki}");
    }
    public override string Suara()
    {
        return "Suara mamalia adalah: ";
    }

}

public class Reptil : Hewan
{
    public string panjangTubuh;

    public Reptil(string Nama, int Umur, string panjangTubuh) : base(Nama, Umur)
    {
        this.panjangTubuh = panjangTubuh;
    }

    public override string Suara()
    {
        return "Suara reptil adalah: ";
    }
}

public class Gajah : Mamalia
{
    public Gajah(string Nama, int Umur, int jumlahKaki) : base(Nama, Umur, jumlahKaki)
    {
        Console.WriteLine($"{Nama} adalah seekor gajah telah ditambahkan kedalam kebun binatang");
    }
    public override string Suara()
    {
        return "Gajah bersuara : Ngiiik";
    }
}

public class Singa : Mamalia
{
    public Singa(string Nama, int Umur, int jumlahKaki) : base(Nama, Umur, jumlahKaki)
    {
        Console.WriteLine($"{Nama} adalah seekor singa telah ditambahkan kedalam kebun binatang");
    }
    public override string Suara()
    {
        return "Singa bersuara : Auuumm";
    }

    public void Mengaum()
    {
        Console.WriteLine($"\nSinga bernama {Nama} yang berumur {Umur} tahun suka mengaum ketika dia lapar");
    }
}

public class Ular : Reptil
{
    public Ular(string Nama, int Umur, string panjangTubuh) : base(Nama, Umur, panjangTubuh)
    {
        Console.WriteLine($"{Nama} adalah seekor ular telah ditambahkan kedalam kebun binatang");
    }
    public override string Suara()
    {
        return "Ular bersuara : Szzh Szzh";
    }
    public void Merayap(string waktu)
    {
        if (waktu.ToLower() == "malam")
        {
            Console.WriteLine($"Ular dengan tenang tidur nyenak di malam hari dengan perut yang sudah kenyang.");
        }
        else if (waktu.ToLower() == "siang")
        {
            Console.WriteLine($"Ular bergerak perlahan di ranting pohon, mencari tempat untuk bertelur.");
        }
        else
        {
            Console.WriteLine($"Ular lagi mager pada {waktu}, jadi dia hanya chill.");
        }
    }
}

public class Buaya : Reptil
{
    public Buaya(string Nama, int Umur, string panjangTubuh) : base(Nama, Umur, panjangTubuh)
    {
        //Console.WriteLine($"{Nama} adalah seekor buaya telah ditambahkan kedalam kebun binatang");
    }
    public override string Suara()
    {
        return "Buaya bersuara : Hi maniez";
    }
}

public class KebunBinatang
{
    public List<Hewan> koleksiHewan = new List<Hewan>();

    public void TambahHewan(Hewan hewan)
    {
        koleksiHewan.Add(hewan);
    }
    public void DaftarHewan()
    {
        Console.WriteLine("\n== Berikut ini adalah daftar hewan yang terdapat di kebun binatang ==");
        foreach (Hewan hewan in koleksiHewan)
        {
            Console.WriteLine($"\n|| {hewan} ||");
            hewan.InfoHewan();
            Console.WriteLine(hewan.Suara());
        }
    }
}