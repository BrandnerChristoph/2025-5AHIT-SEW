using FireFighterOperations.Data;
using FireFighterOperations.Models;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EinsatzContext>(x => x.UseInMemoryDatabase("Operations"));
builder.Services.AddTransient<TestDataSeeder>();


var app = builder.Build();

//////////////////////////////////////////////////////////////////////////////////////////
/// INSERTS - START
//////////////////////////////////////////////////////////////////////////////////////////
    
    bool useClass = true;

    if (useClass)
    {
        // Anweisung 
        // builder.Services.AddTransient<TestDataSeeder>();
        // ist nach em AddDbContext nötig, damit nahstehende Anweisung (Aufruf der Seed Methode) mögich ist

        using (var scope = app.Services.CreateScope())
        {
            var seeder = scope.ServiceProvider.GetRequiredService<TestDataSeeder>();
            seeder.Seed();
        }
    } else
    {
        using (var scope = app.Services.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<EinsatzContext>();

            context.Einsatz.RemoveRange(context.Einsatz);
            context.SaveChanges();

            context.Einsatz.AddRange(
            new Einsatz
            {
                Typ = "B2",
                Einsatzleiter = "BI Max Muster",
                Adresse = "Hauptstraße 12, 4910 Ried im Innkreis",
                Beginn = DateTime.Now.AddMinutes(-180),
                Ende = DateTime.Now,
                SonstigeInformationen = "Zimmerbrand, keine Verletzten",
                Fahrzeuge = new List<EingesetztesFahrzeug>
                {
                new EingesetztesFahrzeug { Fahrzeug = new Fahrzeug { Bezeichnung = "HLF2", Sitzplätze=9 }, Manschaftsstand = 8, Gruppenkommandant = "BI Max Muster", AnzahlAtemtraeger = 4, AusgeruecktAm = DateTime.Now.AddMinutes(-180), EinsatzortAngekommenAm = DateTime.Now.AddMinutes(-165), EinsatzbereitschaftwiederHergestelltAm = DateTime.Now.AddMinutes(-10) },
                new EingesetztesFahrzeug { Fahrzeug = new Fahrzeug { Bezeichnung = "HLF1", Sitzplätze=9 }, Manschaftsstand = 7, Gruppenkommandant = "OFM Mayr Josef", AnzahlAtemtraeger = 5, AusgeruecktAm = DateTime.Now.AddMinutes(-170), EinsatzortAngekommenAm = DateTime.Now.AddMinutes(-160), EinsatzbereitschaftwiederHergestelltAm = DateTime.Now.AddMinutes(-40) }
                }
            },
            new Einsatz
            {
                Typ = "T2",
                Einsatzleiter = "BI Gruber Peter",
                Adresse = "Bahnhofstraße 5, 4910 Ried im Innkreis",
                Beginn = DateTime.Now.AddMinutes(-120),
                Ende = DateTime.Now,
                SonstigeInformationen = "Verkehrsunfall, 2 Personen befreit",
                Fahrzeuge = new List<EingesetztesFahrzeug>
                {
                new EingesetztesFahrzeug { Fahrzeug = new Fahrzeug { Bezeichnung = "RÜST", Sitzplätze=9 }, Manschaftsstand = 5, Gruppenkommandant = "BI Gruber Peter", AnzahlAtemtraeger = null, AusgeruecktAm = DateTime.Now.AddMinutes(-120), EinsatzortAngekommenAm = DateTime.Now.AddMinutes(-110), EinsatzbereitschaftwiederHergestelltAm = DateTime.Now.AddMinutes(-40) }
                }
            },
            new Einsatz
            {
                Typ = "B1",
                Einsatzleiter = "OBI Berger Klaus",
                Adresse = "Feldweg 3, 4911 Tumeltsham",
                Beginn = DateTime.Now.AddMinutes(-90),
                Ende = DateTime.Now,
                SonstigeInformationen = "Mistkübelbrand, rasche Eindämmung",
                Fahrzeuge = new List<EingesetztesFahrzeug>
                {
                new EingesetztesFahrzeug { Fahrzeug = new Fahrzeug { Bezeichnung = "TLF2000", Sitzplätze=9 }, Manschaftsstand = 4, Gruppenkommandant = "OBI Berger Klaus", AnzahlAtemtraeger = null, AusgeruecktAm = DateTime.Now.AddMinutes(-90), EinsatzortAngekommenAm = DateTime.Now.AddMinutes(-80), EinsatzbereitschaftwiederHergestelltAm = DateTime.Now.AddMinutes(-20) }
                }
            }
        );
            context.SaveChanges();
        }
    }
//////////////////////////////////////////////////////////////////////////////////////////
/// INSERTS - END
//////////////////////////////////////////////////////////////////////////////////////////


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
