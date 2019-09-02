# Generikusok és kollekciók laboratórium

## Labor célkitűzése

Megismerkedés a C#-ban használt főbb kollekciókkal és a generikus függvényekkel.

## Feladat

A labor során egy már megvalósított repository osztály fogunk vizsgálni. A repository-t jelenleg User-ek tárolására használják. Feladata, hogy a Usereket letárolja és a user-ek id-ja alapján vissza tudja adni őket. A fejlesztők megvalósították már ezt az osztályt, tesztekkel lefedték a viselkedését. De amikor ténylegesen használni akarták a repository osztály problémákba ütköztek.

### Első feladat

Ha megvizsgáljuk a kódot akkor láthatjuk, hogy az fordul és a teszteken is átmegy.
Azonban ha a tényleges programot szeretnénk elindítani akkor azt látjuk, hogy az hibával elszáll.
Az első feladatban azt kell megkeresnünk, hogy pontosan miért is száll el az alkalmazás és hogy hogyan tudjuk ezt a legáltalánosabban kijavítani.

Hints:
* List 
* Szükséges még a count változó?

### Második feladat

Miután kijavítottuk ezt a hibát. Végre működik az alkalmazás elindul és működnek is a függvények. Elkezdik használni ez a kódrészletet más programokban is.
Ekkor azzal a panasszal fordulnank hozzánk, hogy nem elég gyors az alkalmazás.
A User-ek lekérdezése egyre hosszabb időt vesz igénybe minél nagyobb az adatbázis.
Ekkor a fejlesztő csapatnak az az ötlete támad, hogy a User-eket sorrendbe töltsük fel, mert akkor lehet rajtuk bináris keresést végezni.
Ebben a feladatban átalakítjuk a meglévő kódunkat, a repository osztályban már megtaláljuk a függvényt, ami rendezetten szúrja be az elemeket a User id-ja szerint.
Ahhoz hogy le tudjuk tesztelni, ki kell cserélnünk a fő programban az insertet arra az insert-re, ami sorrend helyesen szúrja be az elemeket.

Miután kicseréltük figyeljük meg hogyan változtak a futási idők. Miért történhetett ez?

Most már hogy megbizonyosodtunk arról hogy a User-ek sorrendben kerülnek a tárolónkba a feladat második részében, írjuk át a Repository GetByIdNumber függvényét, hogy nem menjen végig az összes elemen, hanem bináris keresést használva állapítsa meg a keresett elemet.
Ehhez cseréljük ki a függvény tartalmát a már készen kikommentezett megvalósításra és győződjünk meg róla, hogy működik a tesztek segítségével, majd ismét futtassuk a programot és vizsgáljuk meg hogyan változtak a futási idők.

### Harmadik feladat

Észre vehettük a második feladatban, hogy a beszúrások sokkal több időbe kerültek, mivel a beszúrt elem után minden másik elemet át kell helyeznünk.
A harmadik fealdatban ezt a hibát kell kijavítanunk, hogy a beszúrások ne ilyen lassan történjenek. Ehhez egy olyan adatszerkezetet kell használnunk, ami úgy működik, hogy bármelyik pontjára könnyedén be lehessen szúrni új elemet, anélkül hogy a többit ténylegesen másolni kelljen.

Az átalakítás után gondoskodjunk róla, hogy a tesztesetek még mindig lefutnak. Majd vizsgáljuk meg a futás időket, most mit tapasztalunk?

Hints:
* LinkedList
* `ElementAt`
* `AddLast, AddFirst, AddBefore, AddAfter`


### Negyedik feladat

A harmadik feladat hatására, a bináris keresés lelassult, mivel az elemeket, nem tudjuk közvetlenül címezni. Ezen kívül nem nyertünk túl sokat a Listás megvalósításhoz képest, mert a Lista megvalósítása eléggé jól ki van optimalizálva és ezért úgy foglalja illetve mozgatja az elemeket, hogy hatékony legyen a működés. Ekkor eszünkbe juthat, hogy a jelenlegi használat során egyáltalán nincs szükség az elemek sorrendiségére csak hogy minél gyorsabban el lehessen érni egy kulcs alapján az értékeket.

A negyedik fealdatban egy olyan kollekciót kell használnunk ami ezt lehetővé teszi.

Hints:
* Dictionary
* Szükséges még a sorrendben való beszúrás? Kell még a tesztje?
* `TryGetValue`


### Ötödik feladat

A megrendelő a későbbiekben nem csak Usereket akar így tárolni, hanem egyébb entitásokat is, mint például kutyákat és cicákat.

Alakítsuk át a megoldásunkat úgy, hogy ne csak a User osztályra működjön, hanem generikusan más osztály típust is meg lehessen neki adni, ami tartalmaz id mezőt.

Hints:
* Generikusok
* `(string)user.GetType().GetField("Id").GetValue(user)` <- Id field ertek lekerese reflexio használatával.
