# Altkom-dotnet-core-adv-201905
Przykłady ze szkolenia Tworzenie aplikacji .NET Core 2.2 - poziom zaawansowany

# NET Core

## Przydatne komendy CLI
- ``` dotnet --list-sdks ``` - wyświetlenie listy zainstalowanych SDK
- ``` dotnet new globaljson ``` - utworzenie pliku global.json
- ``` dotnet new globaljson --sdk-version {version} ``` - utworzenie pliku global.json i ustawienie wersji SDK
- ``` dotnet new {template} ``` - utworzenie nowego projektu na podstawie wybranego szablonu
- ``` dotnet new {template} -o {output} ``` - utworzenie nowego projektu w podanym katalogu
- ``` dotnet restore ``` - pobranie bibliotek nuget na podstawie pliku projektu
- ``` dotnet build ``` - kompilacja projektu
- ``` dotnet run ``` - uruchomienie projektu
- ``` dotnet run {app.dll}``` - uruchomienie aplikacji
- ``` dotnet test ``` - uruchomienie testów jednostkowych
- ``` dotnet run watch``` - uruchomienie projektu w trybie śledzenia zmian
- ``` dotnet test ``` - uruchomienie testów jednostkowych w trybie śledzenia zmian
- ``` dotnet add {project.csproj} reference {library.csproj} ``` - dodanie odwołania do biblioteki
- ``` dotnet remove {project.csproj} reference {library.csproj} ``` - usunięcie odwołania do biblioteki
- ``` dotnet new sln ``` - utworzenie nowego rozwiązania
- ``` dotnet sln {solution.sln} add {project.csproj}``` - dodanie projektu do rozwiązania
- ``` dotnet sln {solution.sln} remove {project.csproj}``` - usunięcie projektu z rozwiązania
- ``` dotnet publish -c Release -r {platform}``` - publikacja aplikacji
- ``` dotnet publish -c Release -r win10-x64``` - publikacja aplikacji dla Windows
- ``` dotnet publish -c Release -r linux-x64``` - publikacja aplikacji dla Linux
- ``` dotnet publish -c Release -r osx-x64``` - publikacja aplikacji dla MacOS
- ``` dotnet add package {package-name} ``` - dodanie pakietu nuget do projektu
- ``` dotnet remove package {package-name} ``` - usunięcie pakietu nuget do projektu


# EF Core

## Przydatne komendy CLI
- ``` dotnet ef ``` - weryfikacja instalacji
- ``` dotnet ef migrations add {migration} ``` - utworzenie migracji
- ``` dotnet ef migrations remove ``` - usunięcie ostatniej migracji
- ``` dotnet ef migrations list ``` - wyświetlenie listy wszystkich migracji
- ``` dotnet ef migrations script ``` - wygenerowanie skryptu do aktualizacji bazy danych do najnowszej wersji
- ``` dotnet ef database update ``` - aktualizacja bazy danych do najnowszej wersji
- ``` dotnet ef database update -verbose ``` - aktualizacja bazy danych do najnowszej wersji + wyświetlanie logu
- ``` dotnet ef database update {migration} ``` - aktualizacja bazy danych do podanej migracji
- ``` dotnet ef database drop ``` - usunięcie bazy danych
- ``` dotnet ef dbcontext info ``` - wyświetlenie informacji o DbContext (provider, nazwa bazy danych, źródło)
- ``` dotnet ef dbcontext list ``` - wyświetlenie listy DbContextów
- ``` dotnet ef dbcontext scaffold {connectionstring} Microsoft.EntityFrameworkCore.SqlServer -o Models ``` - wygenerowanie modelu na podstawie bazy danych

## Przydatne polecenia PMC
- ``` Add-Migration {migration} ``` - utworzenie migracji o podanej nazwie
- ``` Remove-Migration ``` - usunięcie ostatniej migracji
- ``` Script-Migration ``` - wygenerowanie skryptu aktualizacji bazy danych do najnowszej wersji
- ``` Script-Migration ``` - wygenerowanie skryptu aktualizacji bazy danych do najnowszej wersji
- ``` Script-Migration {migration} ``` - wygenerowanie skryptu aktualizacji bazy danych od podanej migracji
- ``` Script-Migration 0 {migration} ``` - wygenerowanie skryptu aktualizacji bazy danych od początku do podanej migracji
- ``` Script-Migration {migration} 0 ``` - wygenerowanie skryptu wstecznego aktualizacji bazy danych od podanej migracji do początku
- ``` Update-Database ``` - aktualizacja bazy danych do najnowszej wersji
- ``` Update-Database -verbose ``` - aktualizacja bazy danych do najnowszej wersji + wyświetlanie logu
- ``` Update-Database {migration} ``` - aktualizacja bazy danych do podanej 
- ``` Scaffold-DbContext {connectionstring} Microsoft. Models ``` - wygenerowanie modelu na podstawie bazy danych


## Instalacja SQL Server

### Jako obraz Docker

~~~ bash
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=yourStrong(!)Password' -p 1433:1433 -d mcr.microsoft.com/mssql/server:2017-latest
~~~

Uruchomienie w trybie interaktywnym
~~~
docker exec -it <container_id|container_name> /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P <your_password>
~~~



## Instalacja EF Core

~~~ bash
dotnet add package Microsoft.EntityFrameworkCore
~~~

## Instalacja dostawcy bazy danych SQL Server
~~~ bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
~~~

### Dostawcy baz danych

| Database | NuGet Package  |
|---|---|
| SQL Server | Microsoft.EntityFrameworkCore.SqlServer |
| SQLite | Microsoft.EntityFrameworkCore.SQLite |
| MySQL | MySql.Data.EntityFrameworkCore |
| PostgreSQL | Npgsql.EntityFrameworkCore.PostgreSQL |
| SQL Compact | EntityFrameworkCore.SqlServerCompact40 |
| In-memory | 	Microsoft.EntityFrameworkCore.InMemory |


## DbContext
Klasa **DbContext** jest główną częścią Entity Framework. Instacja DbContext reprezentuje sesję z bazą danych.

### Funkcje DbContext
 1. Zarządzanie połączeniem z bazą danych
 2. Konfiguracja modelu i relacji
 3. Odpytywanie bazy danych
 4. Zapisywanie danych do bazy danych
 5. Śledzenie zmian
 6. Cache'owanie
 7. Zarządzanie transakcjami

### Właściwości DbContext
| Metoda | Użycie |
|---|---|
| ChangeTracker | Dostarcza informacje i operacje do śledzenie obiektów  |
| Database | Dostarcza informacje i operacje bazy danych |
| Model | Zwraca metadane o encjach, ich relacjach i w jaki sposób mapowane są do bazy danych |



## Utworzenie kontekstu

~~~ csharp
public class MyContext : DbContext
{
    public MyContext(DbContextOptions<MyContext> options)
      :base(options)
    { }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Orders> Orders { get; set; }
}
~~~


## Utworzenie instancji DbContext

~~~ csharp

    string connectionString = "Server=127.0.0.1,1433;Database=mydb;User Id=sa;Password=P@ssw0rd";

    var options = new DbContextOptionsBuilder<MyContext>()
        .UseSqlServer(connectionString)
        .Options;

    using (var context = new MyContext(options))
    {
        bool created = context.Database.EnsureCreated();      
    }
~~~


## Wstrzykiwanie DbContext

### Bezpośrednie

~~~ csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<MyContext>(options => options.UseSqlite("Data Source=blog.db"));
}
~~~

W tym przypadku za kazdym razem gdy przyjdzie zadanie bedzie tworzona nowa instancja kontekstu i zwalniania po zakończeniu pracy.


### Pula


~~~ csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddDbContextPool<MyContext>(options => options.UseSqlServer(connectionString));
}
~~~

Zamiast tworzyc za kazdym razę nową instancję kod będze sprawdzac czy jest dostępna instancja w puli.


Opis i porównanie wydajności:
https://neelbhatt.com/2018/02/27/use-dbcontextpooling-to-improve-the-performance-net-core-2-1-feature/


## Konwencje


### Klucz podstawowy

Nazwa właściwości kończy się na Id.


### Konwencja relacji Jeden-do-wielu

#### Konwencja 1 - navigation property
Encja zawiera navigation property.

``` csharp
public class Order
{
    public int Id { get; set; }   
    public string OrderNumber { get; set; }  

    public Customer Customer { get; set; } // Navigation property
}

public class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

```
Zamówienie zawiera referencje do navigation property typu klient. EF utworzy shadow property CustomerId w modelu koncepcyjnym, które będzie mapowane do kolumny CustomerId w tabeli Orders.

#### Konwencja 2 - kolekcja
Encja zawiera kolekcję.

``` csharp
public class Order
{
    public int Id { get; set; }       
    public string OrderNumber { get; set; } 
}

public class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public List<Order> Orders { get; set; } // Kolekcja
}

```

W bazie danych będzie taki sam rezultat jak w przypadku konwencji 1.

#### Konwencja 3 - navigation property i kolekcja

Relacja zawiera navigation property po obu stronach. W rezultacie otrzymujemy połączenie konwencji 1 i 2.


``` csharp
public class Order
{
    public int Id { get; set; }       
    public string OrderNumber { get; set; } 

    public Customer Customer { get; set; } // Navigation property
}

public class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public List<Order> Orders { get; set; } // Kolekcja
}

```

#### Konwencja 4 - navigation property i klucz obcy
Konwencja z uzyciem wlasciwosci foreign key


``` csharp
public class Order
{
    public int Id { get; set; }       
    public string OrderNumber { get; set; } 

    public int CustomerId { get; set; }  // Foreign key property
    public Customer Customer { get; set; } // Navigation property
}

public class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public List<Order> Orders { get; set; }
}

```

### Konwencja relacji Jeden-do-jeden

``` csharp
public class Order
{
    public int OrderId { get; set; }       
    public string OrderNumber { get; set; } 

    public Payment Payment { get; set; } // Navigation property
}

public class Payment
{
    public int PaymentId { get; set; }
    public decimal Amount { get; set; }

    public int OrderId { get; set; }
    public Order Order { get; set; }
}

```

### Konwencja relacji wiele-do-wielu

Obecnie w EF Core nie ma domyslnej konwencji, która konfiguruje relację wiele-do-wielu.



## Konfiguracja relacji


## Konfiguracja relacji jeden-do-jeden 

``` csharp
 modelBuilder.Entity<Order>()
                .HasOne<Payment>()
                .WithOne(p=>p.Order)
                .HasForeignKey<Payment>(p=>p.PaymentId);
```

## Konfiguracja relacji jeden-do-wielu

``` csharp
   protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasOne<Customer>()
                .WithMany(c=>c.Orders)
                .HasForeignKey(p=>p.CustomerId);
``` 


Alternatywnie mozna wyjsc od drugiej strony
``` csharp
            modelBuilder.Entity<Customer>()
                .HasMany(c=>c.Orders)
                .WithOne(o=>o.Customer)
                .HasForeignKey(o=>o.CustomerId);


        }
```


## Konfiguracja kaskadowego usuwania

``` csharp
modelBuilder.Entity<Customer>()
                .HasMany(c=>c.Orders)
                .WithOne(o=>o.Customer)
                .HasForeignKey(o=>o.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);
```

Rodzaje:
- Cascade - usuwa wszystkie encje wraz z encją nadrzędną
- ClientSetNull - klucze obce w encjach zaleznych będą ustawione na null
- Restrict - blokuje kaskadowe usuwanie
- SetNull - klucze obce w encjach zaleznych będą ustawione na null

## Dziedziczenie

Relacyjne bazy danych nie posiadają mechanizmu dziedziczenia, dlatego musi być to w jakiś sposób mapowane.

Models.cs
~~~ csharp
public abstract class Item : BaseEntity
{
    public string Name { get; set; }
    public decimal UnitPrice { get; set; }
}

public class Product : Item
{
    public string SerialNumber { get; set; }
    public string Color { get; set; }
}

public class Service : Item
{
    public TimeSpan Duration { get; set; }
}
~~~


### TPH (Table Per Hierarchy)

#### Dwie lub więcej encji umieszczonych jest w modelu:
ShopContext.cs

~~~ csharp
public class ShopContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Service> Services { get; set; }
}
~~~

#### W przypadku gdy nie chcemy publikować wszystkich encji

~~~ csharp
public class ShopContext : DbContext
{
    public DbSet<Item> Items { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
         modelBuilder.Entity<Product>().HasBaseType<Item>();
         modelBuilder.Entity<Service>().HasBaseType<Item>();
    }
}      
~~~

## Typy złozone (Complex Type)

Models.cs

~~~ csharp 

public class Address
 {
     public string City { get; set; }
     public string Street { get; set; }
     public string Country { get; set; }
     public string PostCode { get; set; }
 }
    
public class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Address InvoiceAddress { get; set; }
    public Address ShippingAddress { get; set; }
}

~~~

### Umieszczenie w tej samej tabeli

ShopContext.cs

~~~ csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
{

        modelBuilder.Entity<Customer>()
            .OwnsOne(s => s.InvoiceAddress);

        modelBuilder.Entity<Customer>()
            .OwnsOne(s => s.ShippingAddress);
}

~~~


### Przeniesienie do osobnej tabeli

~~~ csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
        modelBuilder.Entity<Customer>()
            .OwnsOne(s => s.InvoiceAddress)
            .ToTable("InvoiceAddress");
            
        modelBuilder.Entity<Customer>()
            .OwnsOne(s => s.ShippingAddress)
            .ToTable("ShippingAddress");
}

~~~

## Wypełnianie danych

~~~ csharp
public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
             builder.HasData(
                new Product { Id = 1, Name = "Product 1", Color = "Red", UnitPrice = 1.99m },
                new Product { Id = 2, Name = "Product 2", Color = "Blue", UnitPrice = 1.99m },
                new Product { Id = 3, Name = "Product 3", Color = "Green", UnitPrice = 1.99m }
            );
        }
    }
~~~


## Migracje


~~~ bash
dotnet add package Microsoft.EntityFrameworkCore.Design
~~~

W przypadku gdy DbContext posiada parametr i nie uzywamy DI nalezy utworzyc fabrykę:

~~~ csharp
public class MyContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
             string connectionString = "Server=127.0.0.1,1433;Database=mydb;User Id=sa;Password=P@ssw0rd";

            var options = new DbContextOptionsBuilder<MyContext>()
                .UseSqlServer(connectionString)
                .Options;
            
            return new MyContext(options);
        }
    }
~~~




## Change Tracker

EF Core posiada mechanizm, który umożliwia automatyczne wykrywanie zmian właściwości obiektów.


### Odczytanie stanu encji

~~~ csharp

Trace.WriteLine(context.Entry(customer).State);
foreach (var property in context.Entry(customer).Properties)
{
    Trace.WriteLine($"{property.Metadata.Name} {property.IsModified} {property.OriginalValue} -> {property.CurrentValue}");
}

~~~



### AutoDetectChanges

Domyślnie właściwośc _ChangeTracker.AutoDetectChanges_ jest ustawiona na true.
W celu zwiększenia wydajności, zwłaszcza przy dodawaniu dużej ilości encji, ustaw na false.  
Pamiętaj o wywołaniu metody _DetectChanges()_ przed _SaveChanges()_


### Lokalne wyłączenie śledzenia

~~~ csharp
using (var context = new MyContext())
{
    var blogs = context.Customers
        .AsNoTracking()
        .ToList();
}
~~~

### Globalne wyłączenie śledzenia 

~~~ csharp
using (var context = new MyContext())
{
    context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

    var blogs = context.Blogs.ToList();
}
~~~

### Pobranie informacji o encjach

~~~ csharp
foreach (var entry in context.ChangeTracker.Entries())
{
    Console.WriteLine($"Entity: {entry.Entity.GetType().Name}, State: {entry.State} ");
}

~~~

### Śledzenie i projekcja

~~~ csharp
using (var context = new MyContext())
{
    var blog = context.Customers
        .Select(c =>
            new
            {
                Customer = c,
                Orders = b.Orders.Count()
            });
}

~~~

### TrackGraph

TrackGraph umożliwia przejście po wszystkich powiązanych obiektach i ustawienie ich stanu według określonej reguły.
Dzięki temu można zdefiniować właśną strategię.

~~~ csharp
context.ChangeTracker.TrackGraph(order, e => e.Entry.State = EntityState.Added);
~~~


~~~ csharp
context.ChangeTracker.TrackGraph(order, e => {
            if (e.Entry.IsKeySet)
            {
                e.Entry.State = EntityState.Unchanged;
            }
            else
            {
                e.Entry.State = EntityState.Added;
            }
        });

~~~


## Odłączone encje


### Attach()
Metoda *Attach()* przyłącza odłączony graf encji i zaczyna go śledzić.

``` csharp
context.Attach(entityGraph);
```

Metoda *Attach()* ustawia główną encję na stan Added niezależnie od tego, czy posiada wartość klucza. Jeśli encje dzieci posiadają wartość klucza wówczas zaznaczane są jako *Unchanged*, a w przeciwnym razie jako *Added*.


| Attach()  | Root entity with Key value  | Root Entity with Empty or CLR default value  | Child Entity with Key value  |  Child Entity with empty or CLR default value |
|---|---|---|---|---|
| EntityState.Added  | Added  | Added  | Unchanged  | Added  |
| EntityState.Modified  | Modified  | Exception  | Unchanged  | Added  |
| EntityState.Deleted  | Deleted  | Exception  | Unchanged  | Added  |

### Zmiana stanu

``` csharp
context.Entry(order).State = EntityState.Modified
```

Wyrażenie przyłącza encję do kontekstu i ustawia stan na **Modified**. Ignoruje wszystkie pozostałe encje.

### Add()
Metody *DbContext.Add()* i *DbSet.Add()* przyłączają graf encji do kontekstu i ustawiają stan encji na **Added** niezależnie od tego czy posiadają wartość klucza czy też nie.

| Method | Root entity with/out Key value  | 	Root entity with/out Key |
|---|---|---|
| DbContext.Add  | Added  | Added  | 


### Update()

Metoda *Update()* przyłącza graf encji do kontekstu i ustawia stan poszczególnych encji zależnie od tego czy jest ustawiona wartość klucza.

| Update()  | Root entity with Key value  | Root Entity with Empty or CLR default value  | Child Entity with Key value  |  Child Entity with empty or CLR default value |
|---|---|---|---|---|
| DbContext.Update  | Modified  | Added  | Modified  | Added  |



### Delete()

Metoda *Delete()* ustawia stan głównej encji na **Deleted**.

| Delete()  | Root entity with Key value  | Root Entity with Empty or CLR default value  | Child Entity with Key value  |  Child Entity with empty or CLR default value |
|---|---|---|---|---|
| DbContext.Delete  | Deleted  | Exception  | Unchanged  | Added  |

## Filtry globalne

### Konfiguracja filtra globalnego
~~~ csharp
 internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
 {
     public void Configure(EntityTypeBuilder<Customer> builder)
     {
        builder.HasQueryFilter(p => !p.IsDeleted);
      }
   }
~~~

### Lokalne wyłączenie filtra globalnego

~~~ csharp
using(var context = new MyContext())
{
    var customers = context.Customers.IgnoreQueryFilters().ToList();
}
~~~
       

## Konwertery

Czasami sposób zapisu wartości jakiejś właściwości w bazie danych różni się od tej zdefiniowanej w klasie. 
Na przykład w modelu posiadamy np. płeć jako enum a w bazie danych chcemy zapisać jako "M" lub "F". 
Albo bardziej złożony przykład - po stronie modelu posiadamy obiekt z adresem lub parametrami urządzenia, a w bazie danych chcemy zapisać go w jednej kolumnie jako xml lub json. 

Niestety w poprzedniej wersji EF 6 nie było gotowego mechanizmu i trzeba było stosować obejścia. 
Najczęściej obejście polegało na tym, że trzeba było utworzyć w klasie dodatkowe ukryte prywatne pole (tzw. backfield) odpowiadające typowi w bazie danych, a docelowa właściwość była oznaczona jako ignorowana przez EF. Następnie w metodach get i set była realizowana konwersja. Nie było to optymalne rozwiązanie i kod nie był przenośny.

W EF Core wprowadzono nową funkcję, tzw. konwertery (ValueConverters), które rozwiązują ten problem w bardzo elegancki sposób. 
Nie trzeba już tworzyć dodatkowych pól, ale przede wszystkim można wielokrotnie używać tej samej konwersji. 
Konwerter można użyć w konfiguracji oraz w konwencji.


### Konwersja za pomocą wyrażeń lambda

~~~ csharp
builder.Property(p=>p.Gender)
  .HasConversion(
      v => v.ToString(),
      v => (Gender)Enum.Parse(typeof(Gender), v)
);
~~~

### Konwersja za pomocą obiektu konwertera
~~~ csharp            
var converter = new ValueConverter<Gender, string>(
v => v.ToString(),
v => (Gender)Enum.Parse(typeof(Gender), v));
~~~

### Użycie wbudowanego konwertera
   
~~~ csharp              
            var converter = new EnumToStringConverter<Gender>();
            builder.Property(p=>p.Gender)
              .HasConversion(converter);
~~~

Niektóre z konwerterów posiadają dodatkowe parametry:
~~~ csharp              
            builder.Property(p=>p.IsDeleted)
                .HasConversion(new BoolToStringConverter("Y", "N"));
~~~

Lista wbudowanych konwerterów [https://docs.microsoft.com/en-us/ef/core/modeling/value-conversions]

                

### Predefiniowane konwersje
W większości przypadków nie trzeba tworzyć konwerterów, bo wystarczy skorzystać z predefiniowanych konwersji:
~~~ csharp 
builder.Property(p=>p.Gender)
                .HasConversion<string>();
~~~                

            
### Własny konwerter

#### Własny konwerter za pomocą wyrażenia lambda

~~~ csharp 
  builder.Property(p => p.ShippingAddress).HasConversion(
    v => JsonConvert.SerializeObject(v),
    v => JsonConvert.DeserializeObject<Address>(v));
~~~
   
#### Utworzenie własnego konwertera

Utworzenie klasy własnego konwertera
~~~ csharp 
public class JsonValueConverter<T> : ValueConverter<T, string>
    {
        public JsonValueConverter(ConverterMappingHints mappingHints = null)
        : base(v => JsonConvert.SerializeObject(v), 
               v => JsonConvert.DeserializeObject<T>(v), 
               mappingHints)
        {
        }      
    }
~~~

Użycie własnego konwertera
~~~ csharp 
builder.Property(p => p.ShippingAddress).HasConversion(new JsonValueConverter<Address>());
~~~

W celu ułatwienia korzystania z konwertera można utworzyć metodę rozszerzającą

~~~ csharp 
public static class PropertyBuilderExtensions
    {
        public static PropertyBuilder<T> HasJsonValueConversion<T>(this PropertyBuilder<T> propertyBuilder) where T : class
        {
            propertyBuilder
              .HasConversion(new JsonValueConverter<T>());

            return propertyBuilder;
        }
    }
    
~~~

A następnie użyć jej podczas konfiguracji
~~~ csharp 
            builder.Property(p => p.ShippingAddress)
                .HasJsonValueConversion();
~~~


## Surowy SQL

### Uruchomienie komendy SQL



### Uruchomienie zapytania SQL i pobranie wyników

~~~ csharp
public IEnumerable<Customer> Get(string lastname)
{
    string sql = $"select * from dbo.customers where LastName = '{lastname}'";
    return context.Customers.FromSql(sql);
}
~~~

~~~ csharp
var orderHeaders = db.OrderHeaders.FromSql(
                    @"select c.Name as CustomerName, o.DateCreated, sum(oi.Price) as TotalPrice, 
                    count(oi.Price) as TotalItems
                    from  OrderItems  oi 
                    inner join Orders o on oi.OrderId = o.OrderId
                    inner join Customers c on o.CustomerId = c.CustomerId
                    group by oi.OrderId, c.Name, o.DateCreated");
~~~

### Uruchomienie procedury składowanej
~~~ csharp
using (var context = new SampleContext())
{
    var books = context.Customers
        .FromSql("EXEC GetAllCustomers")
        .ToList();
}
~~~

### Uruchomienie sparametryzowanej procedury składowanej
~~~ csharp
using (var context = new SampleContext())
{
    var city = new SqlParameter("@City", "Warsaw");
    var customers = context.Books
        .FromSql("EXEC GetCustomersByCity @City" , city)
        .ToList();
}
~~~


## DbQuery
Typ **DbQuery** został wprowadzony w .NET Core 2.1. Umozliwia mapowanie tabel i widoków.
Przypomina typ **DbSet** ale nie posiada operacji do zapisu, np. Add(). 

~~~ sql
create view OrderHeaders as
    select      c.Name as CustomerName, 
                o.DateCreated, 
                sum(oi.Price) as TotalPrice, 
                count(oi.Price) as TotalItems
    from        OrderItems  oi 
                inner join Orders o on oi.OrderId = o.OrderId
                inner join Customers c on o.CustomerId = c.CustomerId
    group by oi.OrderId, c.Name, o.DateCreated
~~~ 

Models.cs
~~~ csharp
public class OrderHeader
{
    public string CustomerName { get; set; }
    public DateTime DateCreated { get; set; }
    public int TotalItems { get; set; }
    public decimal TotalPrice { get; set; }
}
~~~

MyContext.cs
~~~ csharp
public class MyContext : DbContext
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbQuery<OrderHeader> OrderHeaders { get; set; }
    ...
}
~~~

### Konfiguracja
Właściwości typu DbSet i DbQuery mozna rozdzielic na osobne pliki za pomocą klas częściowych

MyContext.cs
~~~ csharp
public partial class MyContext : DbContext
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<Customer> Customers { get; set; }
    ...
}

~~~

MyContextDbQuery.cs
~~~ csharp
public partial class MyContext : DbContext
{
    public DbQuery<OrderHeader> OrderHeaders { get; set; }
    public DbQuery<OrderTotal> OrderTotals { get; set; }
    ...
}
~~~


### bez deklaracji DbQuery

Istnieje równiez mozliwośc pobierania danych z widoków bez uzycia DbQuery

~~~ csharp

protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Query<OrderHeader>().ToView("OrderHeaders");
}

~~~

~~~ csharp

var orderHeaders = db.Query<OrderHeader>().ToList();
~~~


## Shadow Properties

**Shadow Properties** są właściwościami, które nie są widoczne w klasach encji, ale są zawarte w modelu i są mapowane na kolumny w bazie danych. 

Shadow Properties są przydatne w wielu scenariuszach:
- brak dostępu do kodu źródłowego klas encji
- jeśli nie chcesz umieszczac w klasach encji kluczy obcych lub metadanych (DateCreated, LastUpdated lub rovwersion).

### Konfiguracja

~~~ csharp
public class MyContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>()
            .Property<DateTime>("LastUpdated");
    }
}
~~~

### Ustawianie wartości Shadow Properties 

~~~ csharp
    context.Add(customer);
    context.Entry(customer).Property("LastUpdated").CurrentValue = DateTime.UtcNow();
    context.SaveChanges();
~~~

~~~ csharp
public overrride int SaveChanges()
{
    var addedEntities = ChangeTracker.Entries().Where(p=>p.State == EntityState.Added);

    foreach(var entry in addedEntities)
    {
        entry.Property("CreatedDate").CurrentValue = DateTime.UtcNow();
    }

    return base.SaveChanges();
}
~~~

### Zapytania z Shadow Properties 

~~~ csharp
var customers = context.Customers.OrderBy(c=>EF.Property<DateTime>(c, "LastUpdated"));
~~~

lub od C# 6.0 z uzyciem _using static_


~~~ csharp
using static Microsoft.EntityFrameworkCore.EF;
var customers = context.Customers.OrderBy(c=>Property<DateTime>(c, "LastUpdated"));
~~~



## Indeksy

~~~ csharp
x.Entity<Token>()
    .HasIndex(d => new { d.ServiceKey, d.ExternalId })
    .HasName("IX_ServiceKey_ExternalId")
    .HasFilter(null)
    .IsUnique(true);
~~~


## Domyślne wartości

~~~ csharp

protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Employee>()
        .Property(b => b.CreatedDate)
        .HasDefaultValueSql("CONVERT(date, GETDATE())");
}

~~~

## Transakcje

### Transakcje bazy danych

~~~ csharp

private void Save(Order order)
{
    using (var context = new MyContext())
    using (var transaction = context.Database.BeginTransaction())
    {
        try
        {
            context.Orders.Add(order);
            context.SaveChanges();
            
            context.Customers.Add(order.Customer);
            context.SaveChanges();
            
            transaction.Commit();
        }
        catch(Exception)
        {
            transaction.Rollback();
        }
    }
}

~~~



