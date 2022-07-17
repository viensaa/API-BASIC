// See https://aka.ms/new-console-template for more information
using ConsoleAppDb;
using Microsoft.EntityFrameworkCore;
using SampleWebAPI.Data;
using SampleWebAPI.Domain;


/*
Console.WriteLine("Hello, World!");

Student student1 = new Student();
student1.Nim = "19738912";

student1.Nama = "Afrizal";
Console.WriteLine($"Nim: {student1.Nim}, Nama: {student1.Nama}");

Lecturer lec1 = new Lecturer()
{
    Nik = "12312",
    Nama = "Afrizal",
    Alamat = "Lr Timbangan",
    Telp = "12312"
};
*/

//LecturerDAL lecturerDAL = new LecturerDAL();

/*
//manggil semua data
var data = lecturerDAL.GetAll();
foreach (var item in data)
{
    Console.WriteLine($" Multiple Data NIK: {item.Nik}, Nama: {item.Nama}, Alamat: {item.Alamat}, Telp:{item.Telp}");
}*/

//menampilakn berdasarkan nama
/*
var data = lecturerDAL.GetByNama("zal");
foreach (var item in data)
{
    Console.WriteLine($" data by nama NIK: {item.Nik}, Nama: {item.Nama}, Alamat: {item.Alamat}, Telp:{item.Telp}");
}
*/

//manggil 1 data
/*var SingleData = lecturerDAL.GetbyId("12312");
Console.WriteLine($" Single Data  , NIK: {SingleData.Nik}, Nama: {SingleData.Nama}, Alamat: {SingleData.Alamat}, Telp:{SingleData.Telp}");
*/


//cara insert
/*var newLecturer = new Lecturer
{
    Nik = "131209",
    Nama = "Rizki",
    Alamat = "jl Mangga",
    Telp = "321321"
};
lecturerDAL.Insert(newLecturer);
*/


/*
//cara update 
var updateLecturer = new Lecturer
{
    Nik = "131209",
    Nama = "Afrizal",
    Alamat = "jl Mangguy",
    Telp = "819238"
};
lecturerDAL.Update(updateLecturer);
*/

//cara delete
/*
try
{
    lecturerDAL.Delete("5555");
    Console.WriteLine($"DSata berhasil di hapus");
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}
*/



//Day 3 belajar Entity framework untuk CRUD
//entity framewok

//Console.WriteLine("sebelum tambah data");
//GetSamurai();

//Console.WriteLine("Tambah Data Samurai");
//AddSamurai();
//AddMultipleSamurai("samurai1", "samurai2", "samurai3", "samurai4","samurai5");


SamuraiContext _context = new SamuraiContext();
_context.Database.EnsureCreated();
//GetSamurai();

//UpdateSamurai(1,"Nidai kitesu");

//DeleteSamurai(4);

//DeleteMultiple("nidai");

//GetSamurai();

//var data = GetById(6);
//Console.WriteLine($"get by id - {data.id} - {data.Name}");
//AddMoreThanOneType();

//GetByName("samurai");

//var CariById = _context.Samurais.Find(5);
//Console.WriteLine($"{CariById.id} - {CariById.Name}");

//GetBattle();



//AddQuote();
//GetQuote();
//AddSamuraiWithQuote();
//Console.WriteLine("============ SETELAH PERUBAHAN DATA =========");
//GetSamurai();
//AddQuoteToExistingSamurai(6,"Tidak ada perang tanpa Korban");
//GetQuoteWithSamurai();

//GetQuoteBySamuraiId(19);
//GetSamuraiWithQuote();
//GetQuote();

//projection
//ProjectionSample();
//QouteEverySamurai();

//AddsamuraiToExistingBattle2();
//GetBattlesOfSamuraisInside();
//DeleteSamuraiFromBattle();
//Console.WriteLine("=======PERUBAHAN========");
//GetBattlesOfSamuraisInside();
//AddSamuraiWithHorse();
//AddHorseToExistingSamurai(6,"Black Winter");
//GetSamuraiWithHorse();
//QueryWithSql();
//QueryWithSqlInterpolited();

//DAY 4
//GetSamuraiBattleStats();
QueryUsingSP("e");

Console.ReadKey();

void AddSamurai(){
    var samurai = new Samurai { Name="Tanjiro"};
    _context.Samurais.Add(samurai);
    _context.SaveChanges();
}

void AddMultipleSamurai(params string[] names)
{
    foreach (string name in names)
    {
        _context.Samurais.Add(new Samurai { Name = name });
    }
    _context.SaveChanges();
}

void AddMoreThanOneType()
{
    _context.AddRange( new Samurai { Name = "Aoyama" }, new Samurai { Name = "Tadase"},
        new Samurai { Name ="kikamu"},
        new Battle { Name = "Tokyo"},
        new Battle { Name = "kyoto"}
    );
    _context.SaveChanges();
}

Samurai GetById(int id)
{
    //lambda version
    var result = _context.Samurais.Where(s => s.id == id).FirstOrDefault();
    //linq version
    //var result = (from s in _context.Samurais
    //              where s.id==id select s).FirstOrDefault();
    if (result != null)
        return result;
    else
        throw new Exception($"Data TIdak di temukan");

}

void GetByName(string name)
{
    //lambda version
    //fungsi contains untuk mencari yang mengandung kata(fungsi LIKE di mysql)
    var samurais = _context.Samurais.Where(s => s.Name.Contains(name)).OrderBy(s => s.Name).ToList();
    foreach(var samurai in samurais)
    {
        Console.WriteLine($"{samurai.id} - {samurai.Name}");
    }
}

void GetSamurai()
{
    var samurais = _context.Samurais.ToList();
    Console.WriteLine($"Jumlah samurai : {samurais.Count}");
    foreach(var samurai in samurais)
    {
        Console.WriteLine($"{samurai.id} - {samurai.Name}");
    }
}

void GetBattle()
{
    var battles = _context.Battles.ToList();
    foreach(var battle in battles)
    {
        Console.WriteLine($"battle id : {battle.BattleId} battle name: {battle.Name}");
    }
}

void UpdateSamurai(int id, string name)
{
    var UbahNama = _context.Samurais.Find(id);
    if (UbahNama != null)
    {
        UbahNama.Name = name;
        _context.SaveChanges();
    }
    else
    {
        Console.WriteLine("Data Tidak Di temukan");
    }
}

void DeleteSamurai(int id)
{
    var data = _context.Samurais.Find(id);
    if(data != null)
    {
        _context.Samurais.Remove(data);
        _context.SaveChanges();
    }
    else
    {
        Console.WriteLine("Data tidak Di temukan");
    }
}

void DeleteMultiple(string name)
{
    var data = _context.Samurais.Where(s => s.Name.Contains(name)).OrderBy(s => s.Name).ToList();
    _context.Samurais.RemoveRange(data);
    _context.SaveChanges();
}

void AddQuote()
{
    var newQuote = new Quote
    {
        text = "Pedang Tidak Akan Memakan Tuannya",
        SamuraiId = 6
    };
    _context.Quotes.Add(newQuote);
    _context.SaveChanges();
}

void GetQuote()
{
    var quotes = _context.Quotes.ToList();
    foreach (var quote in quotes)
    {
        Console.WriteLine($"Samurai id : {quote.SamuraiId} - Quotes: {quote.text}");
    }
}

//buat seendiri (ini join harus explisit , jika tidak explisit harus get datanya duilu)
void GetQuoteBySamuraiId(int id)
{
    var Quotes = _context.Quotes.Where(s => s.SamuraiId == id).ToList();
    foreach(var Quote in Quotes)
    {
        Console.WriteLine($" Quotes :{Quote.text} By {Quote.Samurai.Name} ");
    }
    
}

void AddSamuraiWithQuote()
{
    var data = new Samurai
    {
        Name = "Masashi Kishimoto",
        Quotes = new List<Quote>
        {
            new Quote{text="gomo gomo no mi is scamm"},
            new Quote{text="never scam people"},
        }
    };
    _context.Samurais.Add(data);
    _context.SaveChanges();
}

void AddQuoteToExistingSamurai(int id,string quote)
{
    var samurai = _context.Samurais.Find(id);
    if(samurai != null)
    {
        samurai.Quotes.Add(new Quote { text=quote});
        _context.SaveChanges();
    }
    else
    {
        Console.WriteLine("data tidak di temukan");
    }
}

void GetQuoteWithSamurai()
{
    var quotes = _context.Quotes.Include(q => q.Samurai).OrderBy(q=>q.text).ToList();
    foreach(var quote in quotes)
    {
        Console.WriteLine($" Quotes :{quote.text} By {quote.Samurai.Name} ");
    }
}

void GetSamuraiWithQuote()
{
    var samurais = _context.Samurais.Include(s => s.Quotes).ToList();
    foreach( var samurai in samurais)
    {
        Console.WriteLine($"{samurai.Name}");
        foreach( var quote in samurai.Quotes)
        {
            Console.WriteLine($"==========>{quote.text}");
        }
    }
}

//projection
void ProjectionSample()
{
    var results = _context.Samurais.Select(s =>  new { s.Name }).ToList();

    foreach( var result in results)
    {
        Console.WriteLine($"{result.Name}");
    }
}

//join ke qoues untuk menghitung quotees 
void QouteEverySamurai()
{
    var results = _context.Samurais.Include(s=> s.Quotes).Select(s => new { 
        s.Name,
        JumlahQuotes = s.Quotes.Count}).ToList();

    foreach (var result in results)
    {
        Console.WriteLine($"{result.Name} - {result.JumlahQuotes}");
        
    }
}

void AddsamuraiToExistingBattle()
{
    var battle = _context.Battles.FirstOrDefault(b=> b.BattleId==1);
    var samurai = _context.Samurais.FirstOrDefault(s=> s.id==6);
    battle.Samurais.Add(samurai);
    _context.SaveChanges();
}

//pakai fungsi find
void AddsamuraiToExistingBattle2()
{
   // var battle = _context.Battles.FirstOrDefault(b => b.BattleId == 1);
  //  var samurai = _context.Samurais.FirstOrDefault(s => s.id == 18);

    var battle2 = _context.Battles.Find(2);
    var samurai2 = _context.Samurais.Find(10);

    //samurai.Battles.Add(battle);
    samurai2.Battles.Add(battle2);
   // battle2.Samurais.Add(samurai2);
    _context.SaveChanges();
}

//cara GET untuk relasi many to many
void GetBattlesOfSamuraisInside()
{
    var datas = _context.Battles.Include(b => b.Samurais).ToList();
    foreach(var data in datas)
    {
        Console.WriteLine($"{data.BattleId} - {data.Name}");
        foreach(var samurai in data.Samurais)
        {
            Console.WriteLine($"=====>  {samurai.Name}");
        }
    }
}

//cara delete untuk relasi many to many
void DeleteSamuraiFromBattle()
{
    var battles = _context.Battles.Include(b => b.Samurais.Where(s => s.id == 19))
        .FirstOrDefault(b=> b.BattleId==2);
    // Console.WriteLine(samurai);
    var samurai = battles.Samurais[0];
    _context.Samurais.Remove(samurai);
    _context.SaveChanges();
}

void AddSamuraiWithHorse()
{
    var samurai = new Samurai { Name = "Kenshin Himura", Horse = new Horse { Name = "Arabian White" } };
    _context.Samurais.Add(samurai);
    _context.SaveChanges();
}

void AddHorseToExistingSamurai(int id,string horse)
{
    var samurai = _context.Samurais.Find(id);
    samurai.Horse=(new Horse { Name = horse });
    _context.SaveChanges();
}

void GetSamuraiWithHorse()
{
    var samurais = _context.Samurais.Include(s => s.Horse).ToList();
    foreach(var samurai in samurais)
    {
        if(samurai.Horse!=null)
            Console.WriteLine($"{samurai.Name} - {samurai.Horse.Name}");
    }
}

//tidak perlu di lakukan kecuali akamu kamu jago hahaha
void QueryWithSql()
{
    var samurais = _context.Samurais.FromSqlRaw("select * from Samurais").ToList();
    foreach(var samurai in samurais)
    {
        Console.WriteLine($"{samurai.Name}");
    }
}

void QueryWithSqlInterpolited()
{
    var nama = "tadase";
    var samurais = _context.Samurais.FromSqlInterpolated($"select * from Samurais where Name={nama}").ToList();
    foreach (var samurai in samurais)
    {
        Console.WriteLine($"{samurai.Name}");
    }
}

//DAY  4
void GetSamuraiBattleStats()
{
    var stats = _context.SamuraiBattleStats.ToList();
    foreach(var stat in stats)
    {
        Console.WriteLine($"{stat.Name} - {stat.NumberOfBattles} - {stat.EarliestBattle}");
    }
}

void QueryUsingSP(string text)
{
    var quotes = _context.Samurais.FromSqlInterpolated($"exec dbo.SamuraisWhoSaidAWord {text}").ToList();
    foreach(var quote in quotes)
    {
        Console.WriteLine($"{quote.id} - {quote.Name}");
    }
}


