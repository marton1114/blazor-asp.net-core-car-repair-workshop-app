# Alapkövetelmények
**Bármely alapkövetelmény hiánya esetén a feladat értékelhetetlennek minősül! (Elégtelen érdemjegy)**

- A projektnek van saját Git repository-ja GitHub-on
	- A fejlesztés során rendszeres commit-ok történtek
- Egy solution használata
- A solution-ben minden projekt legalább .NET 7-es verziót használ
- Legalább két külön projekt megléte a solution-ben a feladat követelményei alapján (ha szükséges lehet több is):
    - ASP.NET Core Web API projekt
	- Blazor WebAssembly projekt
- A solution build-elhető

# Feladat leírás
A feladat egy autószerelő műhelyben működő webes alkalmazás elkészítése, amely az egyes munkák nyilvántartására szolgál. 

## Követelmények
- Az egyes munkák kezeléséhez legyen leimplementálva minden CRUD művelet, valamint legyen hozzájuk a frontenden lista nézet
- Az egyes ügyfelek kezeléséhez legyen minden CRUD művelet leimplementálva, valamint lehessen a frontenden kilistázni az ügyfeleket
- Az egyes ügyfelekhez köthető munkákat lehessen külön listázni
- Az egyes munkákra legyen megjelenítve munkaóra esztimáció

### Munkaóra esztimáció
**Képlet:** kategória \* kor \* hiba súlyosság

Átlagos munkaóra kategóriákra lebontva

- Karosszéria: 3 óra
- Motor: 8 óra
- Futómű: 6 óra
- Fékberendezés: 4 óra

Az autó életkorából származó munkaóra súlyozás

- 0-5 év: 0.5
- 5-10 év: 1
- 10-20 év: 1.5
- 20- év: 2

Hiba súlyosságából származó munkaóra súlyozás

- 1-2: 0.2
- 3-4: 0.4
- 5-7: 0.6
- 8-9: 0.8
- 10: 1

## Kezelendő adatok
### Ügyfél
- Ügyfélszám (EF által automatikusan generált)
- Ügyfél neve
- Lakcím
- Email cím
	- **Validációs kikötés:** ez a mező legyen email formátumú
 
### Munka
- Munka azonosító (EF által automatikusan generált)
- Ügyfélszám
- Gépjármű rendszáma
	- **Validációs kikötés:** Megfelelő rendszám formátummal legyen ellátva: XXX-YYY (X: nagy betűk, Y: számok)
- Gépjármű gyártási éve
	- **Validációs kikötés:** A gyártási év ne lehessen 1900-nál kisebb
- Munka kategóriája
	- Itt megengedett értékek: Karosszéria, motor, futómű, fékberendezés
- Gépjármű hibáinak rövid leírása
- A hiba súlyossága
	- A megengedett érték 1-10 intervallumba eshet
- Munka állapota
	- Megengedett értékek: Felvett Munka -> Elvégzés alatt -> Befejezett
	- **Az értékeket csak a nyílnak megfelelő irányba lehessen változtatni!**

## Technikai Követelmények
- UNIT tesztek a WebApi service-ekre
	- Munkaóra esztimáció is legyen letesztelve!
- Adatbázis kezelés EF használatával (Használt DB maga szabadon választható)
- Model validáció
	- Front- és Backend oldalon egyaránt!
	- Minden mezőre érvényes validáció: az adott mezők nem lehetnek üresek valamint nem tartalmazhatnak csak whitespace karaktereket
	- A külön mező specifikus validációk a *Kezelendő adatok* szekció alatt találhatóak meg
 
# Egyéb megjegyzések
- Az alapkövetelményeken felül bármely extra hozzáadott feature plusz pont elérését eredményezheti
