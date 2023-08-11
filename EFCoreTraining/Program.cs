using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("EFTraining");


ETicaretContext context = new();


//Adding
// Urun urun = new Urun()
//{
//    UrunAdi = "A urunu",
//    Fiyat = 1000
//};
//Urun urun2 = new Urun()
//{
//    UrunAdi = "B urunu",
//    Fiyat = 2000
//};

//await context.Urunler.AddRangeAsync(urun,urun2);
//await context.SaveChangesAsync();//transaction edir, problem yaransa rollback olunur
//Console.WriteLine(urun.Id);

//Updating
//var urun = await context.Urunler.FirstOrDefaultAsync(u => u.Id == 6);
//urun.UrunAdi = "Smartphone";
//urun.Fiyat = 7000;
//await context.SaveChangesAsync();
//Console.WriteLine(urun.Fiyat+" "+urun.Id);

//change tracker - context uzerinden gelen datalarin izlenmesindedn mesuldur
//track edilmeyen data nece update olunur?
//var urun3 = new Urun()
//{
//    Id = 3,
//    UrunAdi = "Yeni Urun",
//    Fiyat = 123
//};
////Update - izlenmeyen datalari update ucun ist. olunur
////Bu zaman mutleq id degeri olmalidir   
//context.Urunler.Update(urun3);
//await context.SaveChangesAsync();


//Entry State - entry obyektinin veziyyetini ifade edir
//var urun = new Urun();
//Console.WriteLine(context.Entry(urun).State);
//urun = await context.Urunler.FirstOrDefaultAsync(u => u.Id == 1);
//Console.WriteLine(context.Entry(urun).State);
//urun.UrunAdi = "Hilmi";

//var urunler  = await context.Urunler.ToListAsync();
//Console.WriteLine(urunler.Count);
//foreach(var urun in urunler)
//{
//    urun.Fiyat += 1;
//}

//await context.SaveChangesAsync();

//foreach (var urun in urunler)
//{
//    Console.WriteLine(urun.Fiyat);
//}

//deleteing data in ef core
//Urun urun = await context.Urunler.FirstOrDefaultAsync(u=>u.Id==1);
//context.Urunler.Remove(urun);
//await context.SaveChangesAsync();

//Urun u = new()
//{
//    Id = 2
//};
//context.Urunler.Remove(u);
//await context.SaveChangesAsync();

//Urun u2 = new()
//{
//    Id = 3
//};
//context.Entry(u2).State = EntityState.Deleted;
//await context.SaveChangesAsync();

//RemoveRange
//var urunler = await context.Urunler.Where(u => u.Id >= 7 && u.Id <= 12).ToListAsync();
//context.Urunler.RemoveRange(urunler);
//await context.SaveChangesAsync();


//Method Syntax
//var urunler k= await context.Urunler.ToListAsync();
//Query Syntax
//var urunler2 = await (from urun in context.Urunler select urunler).ToListAsync();

//IQueryable/INumerable
//IQueryable - sorguya qarsiliq gelir


//INumerable - ise sorgunun execute olunub in memory e yuklenmis halidir
//var urunler = from urun in context.Urunler select urun;//this is IQueryable 
//var urunler2 = await (from urun in context.Urunler select urun).ToListAsync();//this is INumerable 

//foreach in query - deferred execution
//var urunler = from urun in context.Urunler select urun;
//foreach (var urun in urunler)
//{
//    Console.WriteLine(urun.UrunAdi);
//}

//int urunId = 5;
//var urunler = from urun in context.Urunler where urun.Id > urunId select urun;
//urunId = 2;
//foreach (var urun in urunler)
//{
//    Console.WriteLine(urun.UrunAdi);
//}

//ToListAsync() - iqueryabledan inumerable a kecirir




//---------------------------------
//coxlu sert elave eden funksiyalar

//Where - sart elave edir
//in method syntax
//var urunler = context.Urunler.Where(u => u.UrunAdi.StartsWith("A")).ToListAsync();
//in query syntax
//var urunler = from urun in context.Urunler
//              where urun.Id > 3 && urun.UrunAdi.EndsWith("o")
//              select urun;
//var data = await urunler.ToListAsync();


//OrderBy - siralayir(default ascending)
//method syntax
//var urunler = context.Urunler.Where(u => u.Id > 4).OrderBy(u => u.UrunAdi);
//query syntax
//var urunler = from urun in context.Urunler
//              where urun.Id > 500 || urun.UrunAdi.StartsWith("A")
//              orderby urun.UrunAdi descending
//              select urun;

//await urunler.ToListAync();

//ThenBy - coxlu orderby ucun
//var urunler = context.Urunler.Where(u => u.Id > 4).OrderBy(u => u.UrunAdi).ThenBy(u=>u.Fiyat);

//OrderByDescending
//var urunler = await context.Urunler.OrderByDescending(x => x.Id).ToListAsync();

//ThenByDescending - OrderBy ile siralananlari diger columnlarda da tetbiq edir
//------------------------------------

//-----------------------------------
//tekli data getiren funksiyalar
//Single, SingleOrDefault funksiyalari ya tek data getirir, ya da xeta atacaq
//Single - birden cox deyer gelirse ve ya hec deyer gelmirse, exception atacaq
//SingleOrDefault - birden cox deyer gelse exception, hec bir deyer gelmese null atacaq
//var urun = await context.Urunler.SingleOrDefaultAsync(u => u.UrunAdi == "A");
//Console.WriteLine(urun?.Id.ToString());

//First, FirstOrDefault - sorgu neticesinde elde edilen datalardan ilkini getirir

//FindAsync funks. primary key uzre data getirir data olmasa null qaytarir
//Urun urun = await context.Urunler.FindAsync(4);

//Last,LastOrDefault First,FirstOrDefault ile eynidi sadece gelen datalardan sonuncusunu alir,ters olaraq
//order by ist. etmek mecburidir


//CountAsync - sorgu neticesinde nece eded data gelecekse onu ifade edir
//var urunler = (await context.Urunler.ToListAsync()).Count();

//AnyAsync - bool qaytarir

//Min/Max - columndaki min/max deyeri getirir

//Distinct - tekrar deyerleri gizledir
//var urunler = await context.Urunler.Distinct().ToListAsync();

//All - eger butun deyerler serte uygundursa true, yoxsa false olacaq
//Sum
//Average
//Contains - like dir, ondan once where serti olmalidir
//var urunler = await context.Urunler.Where(u => u.UrunAdi.Contains("a")).ToListAsync();
//StartsWith/EndsWith - contains kimi isleyir

//--------------------------------------

//Sorgu neticesinde cevirme funks+i
//ToDictionary
//var urunler = await context.Urunler.ToDictionaryAsync(u=>u.UrunAdi);

//ToList - dictionary ile eynidir, sadece ferqli formatda

//ToArrayAsync


//Select - generate olunan sorgunun cekilecek columnlarini konf. etmek ucun var,lazimsiz columnlar gelmir
//var urunler = await context.Urunler.Select(u => new Urun
//{
//    Id = u.Id,
//    Fiyat = u.Fiyat,
//}).ToListAsync();

//foreach (var u in urunler)
//{
//    Console.WriteLine(u.Id+": "+u.Fiyat);
//}

//Anonym classes
//var anonym = new
//{
//    A = "Ahmet"
//};

//select many


//GroupBy
//method
//var datas = await context.Urunler.GroupBy(u => u.Fiyat).Select(group => new
//{
//    Count = group.Count(),
//    Fiyat = group.Key,
//}).ToListAsync();
//Console.WriteLine();
//query

//var datas = await (from urun in context.Urunler
//            group urun by urun.Fiyat
//            into g
//            select new
//            {
//                Fiyat = g.Key,
//                Count = g.Count(),
//            }).ToListAsync();
//Console.WriteLine();


//ForEach - bir sorgulama funks. deyildir
//var datas = await context.urunler.groupby(u => u.fiyat).select(group => new
//{
//    count = group.count(),
//    fiyat = group.key,
//}).tolistasync();
//datas.foreach (x =>
//{
//    console.writeline(x.fiyat);
//}) ;


//------------------------
//Change Tracking - obyektler uzerindeki deyisiklikler izlenilir bunun vasitesile
//DbContextin bir uzvudur

//var urunler = await context.Urunler.ToListAsync();
//urunler[0].Fiyat = 123;
//context.Urunler.Remove(urunler[1]);
//urunler[2].UrunAdi = "afsfag";
//var datas = context.ChangeTracker.Entries();
//await context.SaveChangesAsync();
//Console.WriteLine();

//DetectChanges - SaveChangese guvenmesek, bunu cagira bilerik
//var urun = await context.Urunler.FirstOrDefaultAsync(u => u.Id == 3);
//urun.Fiyat = 123;
//context.ChangeTracker.DetectChanges();//her zaman luzumsuz yere lazim olmur 
//await context.SaveChangesAsync();

//AutoDetectChangesEnable true - her defe savechanges sonulu olacaq avtomatik, manuel idare etmelisen, performans ucun yazxsidir

//Entries methodu detect changesi tetikleyir











public class ETicaretContext: DbContext
{
    public DbSet<Urun> Urunler { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ETrade;Trusted_Connection=True");
    }
}



public class Urun
{
    public int Id { get; set; }
    public string UrunAdi { get; set; }
    public float Fiyat { get; set; }
}
