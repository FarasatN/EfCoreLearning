//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Security.Cryptography;
//using Microsoft.EntityFrameworkCore;
//using static EFCoreTraining.Program_old;

//namespace EFCoreTraining
//{
	
	
//	public class Program_old
//	{

//		//ETicaretContext context = new();
//		//Adding
//		// Urun urun = new Urun()
//		//{
//		//    UrunAdi = "A urunu",
//		//    Fiyat = 1000
//		//};
//		//Urun urun2 = new Urun()
//		//{
//		//    UrunAdi = "B urunu",
//		//    Fiyat = 2000
//		//};

//		//await context.Urunler.AddRangeAsync(urun,urun2);
//		//await context.SaveChangesAsync();//transaction edir, problem yaransa rollback olunur
//		//Console.WriteLine(urun.Id);

//		//Updating
//		//var urun = await context.Urunler.FirstOrDefaultAsync(u => u.Id == 6);
//		//urun.UrunAdi = "Smartphone";
//		//urun.Fiyat = 7000;
//		//await context.SaveChangesAsync();
//		//Console.WriteLine(urun.Fiyat+" "+urun.Id);

//		//change tracker - context uzerinden gelen datalarin izlenmesindedn mesuldur
//		//track edilmeyen data nece update olunur?
//		//var urun3 = new Urun()
//		//{
//		//    Id = 3,
//		//    UrunAdi = "Yeni Urun",
//		//    Fiyat = 123
//		//};
//		////Update - izlenmeyen datalari update ucun ist. olunur
//		////Bu zaman mutleq id degeri olmalidir   
//		//context.Urunler.Update(urun3);
//		//await context.SaveChangesAsync();


//		//Entry State - entry obyektinin veziyyetini ifade edir
//		//var urun = new Urun();
//		//Console.WriteLine(context.Entry(urun).State);
//		//urun = await context.Urunler.FirstOrDefaultAsync(u => u.Id == 1);
//		//Console.WriteLine(context.Entry(urun).State);
//		//urun.UrunAdi = "Hilmi";

//		//var urunler  = await context.Urunler.ToListAsync();
//		//Console.WriteLine(urunler.Count);
//		//foreach(var urun in urunler)
//		//{
//		//    urun.Fiyat += 1;
//		//}

//		//await context.SaveChangesAsync();

//		//foreach (var urun in urunler)
//		//{
//		//    Console.WriteLine(urun.Fiyat);
//		//}

//		//deleteing data in ef core
//		//Urun urun = await context.Urunler.FirstOrDefaultAsync(u=>u.Id==1);
//		//context.Urunler.Remove(urun);
//		//await context.SaveChangesAsync();

//		//Urun u = new()
//		//{
//		//    Id = 2
//		//};
//		//context.Urunler.Remove(u);
//		//await context.SaveChangesAsync();

//		//Urun u2 = new()
//		//{
//		//    Id = 3
//		//};
//		//context.Entry(u2).State = EntityState.Deleted;
//		//await context.SaveChangesAsync();

//		//RemoveRange
//		//var urunler = await context.Urunler.Where(u => u.Id >= 7 && u.Id <= 12).ToListAsync();
//		//context.Urunler.RemoveRange(urunler);
//		//await context.SaveChangesAsync();


//		//Method Syntax
//		//var urunler k= await context.Urunler.ToListAsync();
//		//Query Syntax
//		//var urunler2 = await (from urun in context.Urunler select urunler).ToListAsync();

//		//IQueryable/INumerable
//		//IQueryable - sorguya qarsiliq gelir


//		//INumerable - ise sorgunun execute olunub in memory e yuklenmis halidir
//		//var urunler = from urun in context.Urunler select urun;//this is IQueryable 
//		//var urunler2 = await (from urun in context.Urunler select urun).ToListAsync();//this is INumerable 

//		//foreach in query - deferred execution
//		//var urunler = from urun in context.Urunler select urun;
//		//foreach (var urun in urunler)
//		//{
//		//    Console.WriteLine(urun.UrunAdi);
//		//}

//		//int urunId = 5;
//		//var urunler = from urun in context.Urunler where urun.Id > urunId select urun;
//		//urunId = 2;
//		//foreach (var urun in urunler)
//		//{
//		//    Console.WriteLine(urun.UrunAdi);
//		//}

//		//ToListAsync() - iqueryabledan inumerable a kecirir




//		//---------------------------------
//		//coxlu sert elave eden funksiyalar

//		//Where - sart elave edir
//		//in method syntax
//		//var urunler = context.Urunler.Where(u => u.UrunAdi.StartsWith("A")).ToListAsync();
//		//in query syntax
//		//var urunler = from urun in context.Urunler
//		//              where urun.Id > 3 && urun.UrunAdi.EndsWith("o")
//		//              select urun;
//		//var data = await urunler.ToListAsync();


//		//OrderBy - siralayir(default ascending)
//		//method syntax
//		//var urunler = context.Urunler.Where(u => u.Id > 4).OrderBy(u => u.UrunAdi);
//		//query syntax
//		//var urunler = from urun in context.Urunler
//		//              where urun.Id > 500 || urun.UrunAdi.StartsWith("A")
//		//              orderby urun.UrunAdi descending
//		//              select urun;

//		//await urunler.ToListAync();

//		//ThenBy - coxlu orderby ucun
//		//var urunler = context.Urunler.Where(u => u.Id > 4).OrderBy(u => u.UrunAdi).ThenBy(u=>u.Fiyat);

//		//OrderByDescending
//		//var urunler = await context.Urunler.OrderByDescending(x => x.Id).ToListAsync();

//		//ThenByDescending - OrderBy ile siralananlari diger columnlarda da tetbiq edir
//		//------------------------------------

//		//-----------------------------------
//		//tekli data getiren funksiyalar
//		//Single, SingleOrDefault funksiyalari ya tek data getirir, ya da xeta atacaq
//		//Single - birden cox deyer gelirse ve ya hec deyer gelmirse, exception atacaq
//		//SingleOrDefault - birden cox deyer gelse exception, hec bir deyer gelmese null atacaq
//		//var urun = await context.Urunler.SingleOrDefaultAsync(u => u.UrunAdi == "A");
//		//Console.WriteLine(urun?.Id.ToString());

//		//First, FirstOrDefault - sorgu neticesinde elde edilen datalardan ilkini getirir

//		//FindAsync funks. primary key uzre data getirir data olmasa null qaytarir
//		//Urun urun = await context.Urunler.FindAsync(4);

//		//Last,LastOrDefault First,FirstOrDefault ile eynidi sadece gelen datalardan sonuncusunu alir,ters olaraq
//		//order by ist. etmek mecburidir


//		//CountAsync - sorgu neticesinde nece eded data gelecekse onu ifade edir
//		//var urunler = (await context.Urunler.ToListAsync()).Count();

//		//AnyAsync - bool qaytarir

//		//Min/Max - columndaki min/max deyeri getirir

//		//Distinct - tekrar deyerleri gizledir
//		//var urunler = await context.Urunler.Distinct().ToListAsync();

//		//All - eger butun deyerler serte uygundursa true, yoxsa false olacaq
//		//Sum
//		//Average
//		//Contains - like dir, ondan once where serti olmalidir
//		//var urunler = await context.Urunler.Where(u => u.UrunAdi.Contains("a")).ToListAsync();
//		//StartsWith/EndsWith - contains kimi isleyir

//		//--------------------------------------

//		//Sorgu neticesinde cevirme funks+i
//		//ToDictionary
//		//var urunler = await context.Urunler.ToDictionaryAsync(u=>u.UrunAdi);

//		//ToList - dictionary ile eynidir, sadece ferqli formatda

//		//ToArrayAsync


//		//Select - generate olunan sorgunun cekilecek columnlarini konf. etmek ucun var,lazimsiz columnlar gelmir
//		//var urunler = await context.Urunler.Select(u => new Urun
//		//{
//		//    Id = u.Id,
//		//    Fiyat = u.Fiyat,
//		//}).ToListAsync();

//		//foreach (var u in urunler)
//		//{
//		//    Console.WriteLine(u.Id+": "+u.Fiyat);
//		//}

//		//Anonym classes
//		//var anonym = new
//		//{
//		//    A = "Ahmet"
//		//};

//		//select many


//		//GroupBy
//		//method
//		//var datas = await context.Urunler.GroupBy(u => u.Fiyat).Select(group => new
//		//{
//		//    Count = group.Count(),
//		//    Fiyat = group.Key,
//		//}).ToListAsync();
//		//Console.WriteLine();
//		//query

//		//var datas = await (from urun in context.Urunler
//		//            group urun by urun.Fiyat
//		//            into g
//		//            select new
//		//            {
//		//                Fiyat = g.Key,
//		//                Count = g.Count(),
//		//            }).ToListAsync();
//		//Console.WriteLine();


//		//ForEach - bir sorgulama funks. deyildir
//		//var datas = await context.urunler.groupby(u => u.fiyat).select(group => new
//		//{
//		//    count = group.count(),
//		//    fiyat = group.key,
//		//}).tolistasync();
//		//datas.foreach (x =>
//		//{
//		//    console.writeline(x.fiyat);
//		//}) ;


//		//------------------------
//		//Change Tracking - obyektler uzerindeki deyisiklikler izlenilir bunun vasitesile
//		//DbContextin bir uzvudur

//		//var urunler = await context.Urunler.ToListAsync();
//		//urunler[0].Fiyat = 123;
//		//context.Urunler.Remove(urunler[1]);
//		//urunler[2].UrunAdi = "afsfag";
//		//var datas = context.ChangeTracker.Entries();
//		//await context.SaveChangesAsync();
//		//Console.WriteLine();

//		//DetectChanges - SaveChangese guvenmesek, bunu cagira bilerik
//		//var urun = await context.Urunler.FirstOrDefaultAsync(u => u.Id == 3);
//		//urun.Fiyat = 123;
//		//context.ChangeTracker.DetectChanges();//her zaman luzumsuz yere lazim olmur 
//		//await context.SaveChangesAsync();

//		//AutoDetectChangesEnable true - her defe savechanges sonulu olacaq avtomatik, manuel idare etmelisen, performans ucun yazxsidir

//		//Entries methodu detect changesi tetikleyir


//		//ChangeTracker - tekrarlayan datalari tek bir instance uzerinden getirir, 

//		//AsNoTracking - ChangeTrackerin eksini edecek, izlenmeni engelleyecek
//		//var users = await context.Urunler.AsNoTracking().ToListAsync();
//		//sadece listelediyimiz ucun as no tracking edirik ve artiq gelen datanin uzerinde hec bir deyisiklik ede bilmeyeceyik
//		//ancaq manuel olaraq update etmek olur, hansi ki bu zaman change tracker gerekmirdi onsuz
//		//asnotracking bir terefden maliyyeti salarken bir terefden artira bilir, bele ki, eger sorguladigimiz cedveller foreign key ile elaqelidirse, her obyekt ucun bir instamce yaranacaq, ona gore de bele meqamlarda istifade etmemek daha meslehetlidi
//		//ya da bunun evezine AsNoTrackingWithIdentityResolution ist etmeliyik

//		//AsNoTrackingWithIdentityResolution - AsNoTrackinge gore yavasdir, CgangeTrackere gore ise daha suretlidi

//		//yeni tekrarlayan deyerlere gore deyisir

//		//AsTracking - default olan trackingi iradeli olaraq aktiv edir
//		//var users2 = await context.Urunler.AsTracking().ToListAsync();

//		//UseQueryTrackingBehavior - Tracking EF de hansinin default aktiv oldugunu gosterir
//		//       optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

//		//Console.WriteLine();



//		//public class ETicaretContext: DbContext
//		//{
//		//    public DbSet<Urun> Urunler { get; set; }

//		//	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//		//    {
//		//        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ETrade;Trusted_Connection=True");
//		//        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
//		//    }
//		//}


//		//public class Urun
//		//{
//		//    public int Id { get; set; }
//		//    public string UrunAdi { get; set; }
//		//    public float Fiyat { get; set; }
//		//}



//		//Principal Entity(Esas Entity) - Oz basina var ola bilen, asili olmadan var olan tabledir
//		//Dependant Entity(Asili Entity) - Oz basina var ola bilmeyen, asili olmadan var olmayan table dir
//		//Foreign Key - Principal Entity ile Dependant Entity arasinda elaqeni yaradan keydir
//		//Navigation Property - Table larin bir biri ile hansi formada(n-e n, 1-e n) elaqeli oldugunu gosterir

//		//1-e 1 - misal, her erin yalniz bir arvadi ola biler, her arvadin da yalniz bir eri
//		//Asagidaki numunede her iscinin bir adresi ola biler

//		//1-e n - her ovladin bir anasi ola biler, ananin coxlu ovladi ola biler, asagida da isci ve department elaqesi

//		//n-e n - bura da 3 qardas uzerinden numune cekek, her qardasin birden cox qardasi ola biler, asgidaki numunede is isci ve proyekt arasinda elaqe

//		//Default Conventions - default olaraq entityler arasinda elaqe yaratma qaydalarini ist eden metotdur - navigation propertyleri ist. edir

//		//Data Annotations Attributes - Custom sekilde elaqe qurmaq istesek, default conventionsa uygun olmayan bundan ist edirik, attribute vasitesile - [Key], [ForeignKey]


//		//Fluent API  - daha detalli elaqe yaratmaq ucun ist. olunur, bunlar 4 eded metoddur:

//		//HasOne - Entityde digerlerine elaqesinin 1-e n, 1-e 1 ve s. oldugunu gosterir
//		//HasMany - Entityde digerlerine elaqesinin n-e n oldugunu gosterir
//		//WithOne - Diger entity de x-e 1 oldugunu gosterir
//		//WithMany - Diger entity de x-e n oldugunu gosterir


//		//public class Employee
//		//{
//		//	public int Id { get; set; }//Principal Key
//		//	public string EmployeeName { get; set; }

//		//	public Email Email { get; set; }
//		//	public Department Department { get; set; }//Navigation property - Her iscinin yalniz bir departmenti ola biler
//		//	//public ICollection<Project> Projects { get; set; }

//		//}

//		//public class Email
//		//{
//		//	//[Key, ForeignKey(nameof(Employee))]//Foreign keyi primary key ile eyni isarelemek en yaxsi yoldur
//		//	public int Id { get; set; }

//		//	//[ForeignKey(nameof(Employee))]//1-e 1 elaqe data annotations ile ve istediyimiz adi foreign key kimi vere bilerik bunun komeyi ile, amma en yaxsisi primary keyi foreign kimi ist. etmekdir
//		//	//public int EmployeeId { get; set; }//1-e 1 elaqede entitynin yanina id yazilanda onu foreign key kimi gorur
//		//	public string EmailAddress { get; set; }

//		//	public Employee Employee { get; set; }
//		//}

//		//public class Department
//		//{
//		//	public int Id { get; set; }//Principal Key
//		//	public string DepartmentName { get; set; }

//		//	public ICollection<Employee> Employees { get; set; }//Navigation property - Her departmentin coxlu iscisi ola biler
//		//}

//		//class Project
//		//{
//		//	public int Id { get; set; }
//		//	public string ProjectName { get; set; }

//		//	public ICollection<Employee> Employees { get; set; }
//		//}



//		//Many to Many relationship in EFCore
//		//Default Convention

//		//DC - da cross table i biz yaratmaq mecburiyyetinde deyilik. EF Core ozu avtomatik generate edecek
//		//ve yaranacaq cross table icindeki composite primary keyi de avtomatik yaradacaq
//		//public class Book
//		//{
//		//	public int Id { get; set; }
//		//	public string BookName { get; set; }
//		//	public ICollection<Author> Authors { get; set; }
//		//}

//		//public class Author
//		//{
//		//	public int Id { get; set; }
//		//	public string AuthorName { get; set; }
//		//	public ICollection<Book> Books { get; set; }
//		//}


//		//Data Annotations method - cross table manue olaraq yaradilmalidir
//		//Entity leri yaratdigimiz cross table entity si ile bire cox elaqe yaratmali
//		//Cross Table composite priary keyi data annotationslar ile manuel qura bilmirik
//		//bunun ucun de Fluent Api  ist. edirik. Cross Table i DbSet kimi yamaga ehtiyyac yoxdur

//		//public class Book
//		//{
//		//	public int Id { get; set; }
//		//	public string BookName { get; set; }
//		//	public ICollection<BookAuthor> Authors { get; set; }
//		//}

//		//public class BookAuthor
//		//{
//		//	public int BookId { get; set; }
//		//	public int AuthorId { get; set; }
//		//	public Book Book { get; set; }
//		//	public Author Author { get; set; }
//		//}

//		//public class Author
//		//{
//		//	public int Id { get; set; }
//		//	public string AuthorName { get; set; }
//		//	public ICollection<BookAuthor> Books { get; set; }

//		//}



//		//Fluent API
//		//DbSet gerekli deyil, Composite PK Haskey metodu ile qurulmlaidir

//		//public class Book
//		//{
//		//	public int Id { get; set; }
//		//	public string BookName { get; set; }
//		//	public ICollection<BookAuthor> Authors { get; set; }
//		//}

//		//public class BookAuthor
//		//{
//		//	public int BookId { get; set; }
//		//	public int AuthorId { get; set; }
//		//	public Book Book { get; set; }
//		//	public Author Author { get; set; }
//		//}

//		//public class Author
//		//{
//		//	public int Id { get; set; }
//		//	public string AuthorName { get; set; }
//		//	public ICollection<BookAuthor> Books { get; set; }
//		//}



//		//public class EfCoreTrainingContext : DbContext
//		//{
//		//	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//		//	{
//		//		optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=EfCoreTraining;Trusted_Connection=True");
//		//		//optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
//		//	}


//		//public DbSet<Employee> Employees { get; set; }
//		//public DbSet<Email> Emails { get; set; }

//		//Fluent API de elaqeler buradan yaradilir
//		//protected override void OnModelCreating(ModelBuilder modelBuilder)
//		//{
//		//	modelBuilder.Entity<Email>()
//		//		.HasKey(e=>e.Id);

//		//	modelBuilder.Entity<Employee>()
//		//		.HasOne(e => e.Email)
//		//		.WithOne(e => e.Employee)
//		//		.HasForeignKey<Email>(e=>e.Id);

//		//	modelBuilder.Entity<Employee>()
//		//		.HasOne(e => e.Department)
//		//		.WithMany(d => d.Employees);
//		//}


//		////n to n - default convention
//		//public DbSet<Book> Books { get; set; }
//		//public DbSet<Author> Authors { get; set; }

//		////n to n - data annotations
//		//protected override void OnModelCreating(ModelBuilder modelBuilder)
//		//{
//		//	modelBuilder.Entity<BookAuthor>()
//		//		.HasKey(ky => new { ky.BookId, ky.AuthorId });
//		//}


//		//fluent api - many to many
//		//public DbSet<Book> Books { get; set; }
//		//public DbSet<Author> Authors { get; set; }

//		//protected override void OnModelCreating(ModelBuilder modelBuilder)
//		//{
//		//	modelBuilder.Entity<BookAuthor>()
//		//		.HasKey(ky => new { ky.BookId, ky.AuthorId});

//		//	modelBuilder.Entity<BookAuthor>()
//		//		.HasOne(ky => ky.Book)
//		//		.WithMany(k => k.Authors)
//		//		.HasForeignKey(ky => ky.BookId);

//		//	modelBuilder.Entity<BookAuthor>()
//		//		.HasOne(ky => ky.Author)
//		//		.WithMany(k => k.Books)
//		//		.HasForeignKey(k => k.AuthorId);
//		//}

//		//}


//		//-------------------------------------------------------------------------------------
//		//Realitional Databaselerde data elave etme davranislari(Fluent API)
//		//1 to 1

//		public class Person
//		{
//			public int Id { get; set; }
//			public string Name { get; set; }
//			public Address Address { get; set; }
//		}
//		public class Address
//		{
//			public int Id { get; set; }
//			public string PersonAddress { get; set; }
//			public Person Person { get; set; }
//		}

//		public class EfCoreTrainingContext : DbContext
//		{
//			protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//			{
//				optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=EfCoreTraining;Trusted_Connection=True");
//				//optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
//			}

//			public DbSet<Person> Persons { get; set; }
//			public DbSet<Address> Address { get; set; }

//			protected override void OnModelCreating(ModelBuilder modelBuilder)
//			{
//				modelBuilder.Entity<Address>()
//					.HasOne(a => a.Person)
//					.WithOne(a => a.Address)
//					.HasForeignKey<Address>(a => a.Id);
//			}
//		}

//		EfCoreTrainingContext context = new();

//		Person person = new();
		
//	}

	
//}

