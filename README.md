# Game Design & Architectuur Script: Immune Guardian (Cellular Defense) - v3

## 1. Overzicht en Biologisch Concept

### 1.1 Uitgangspunt van het Spel
**Immune Guardian: Cellular Defense** is een interactief 2D-platformspel waarin de speler de rol aanneemt van een **Leukocyt (Witte Bloedcel)** die belast is met het verdedigen van het menselijk lichaam tegen een ernstige infectie. Het spel combineert klassieke platformmechanics (rennen, precieze sprongen en interactie met zwevende blokken) met echte biologische concepten en een objectgeoriënteerde architectuur die strikt gefundeerd is op de SOLID-principes en GoF Design Patterns.

### 1.2 Hoofddoel
De speler moet de leukocyt navigeren door drie vitale organen die door pathogenen zijn aangetast, medicijnen verzamelen in blokken verspreid over de omgeving, biologische indringers verslaan en het lymfestelsel bereiken om apoptose (geprogrammeerde celdood) uit te voeren, waardoor de homeostase van het menselijk lichaam wordt hersteld.

---

## 2. Spelersreis: Levelprogressie

Het spel is gestructureerd in drie primaire actieniveaus, gevolgd door een concluderende epiloog. Elk level presenteert specifieke omgevingsuitdagingen en geïnfecteerde gastheercellen die kenmerkend zijn voor elk weefsel.

### 2.1 Level 1: De Hersenen (BrainLevel)
* **Visuele Sfeer**: Bloed-hersenbarrière, fonkelende neurale verbindingen op de achtergrond en synaptische platformen.
* **Gameplay-focus**: Introductieniveau. Presentatie van de basisbewegingen, sprongen en het omgevingsobstakel van allergische reacties.
* **Centrale Uitdaging**: Navigatie tussen neurale elektrische ontladingen, de aanwezigheid van stuifmeeldeeltjes in de lucht en gevechten tegen **Geïnfecteerde Neurale Cellen (`NeuralInfectedCell`)**.

### 2.2 Level 2: De Longen (LungLevel)
* **Visuele Sfeer**: Uitgestrekte alveolaire structuren, tubulaire luchtwegen en pulmonaal meercellig epitheelweefsel.
* **Gameplay-focus**: Navigatie via alveolaire platformen en gevechten tegen geïnfecteerde epitheelcellen.
* **Centrale Uitdaging**: Aanwezigheid van **Geïnfecteerde Respiratoire Cellen (`RespiratoryInfectedCell`)**. De leukocyt moet de infectie identificeren en het bijbehorende vaccin in het inventaris behalen om de pneumocyt/geïnfecteerde epitheelcel te fagocyteteren zonder zelf besmet te raken.

### 2.3 Level 3: Het Hart (HeartLevel)
* **Visuele Sfeer**: Continu pulserend myocardiumweefsel, grote bloedvaten en turbulente bloedstroom.
* **Gameplay-focus**: Hoge-intensiteitsgevechten, eliminatie van geïnfecteerde endotheelcellen en het eindgevecht tegen de Eindbaas.
* **Centrale Uitdaging**: Bacteriën met een hoge mechanische weerstand, **Geïnfecteerde Circulatoire/Cardiale Cellen (`CardiacInfectedCell`)** en de aanwezigheid van de protozoaire parasiet die de ziekte van Chagas veroorzaakt.

### 2.4 Epiloog: De Lymfeklieren (LymphNodeLevel)
* **Visuele Sfeer**: Rustige omgeving, verlicht door lymfevocht en een netwerk van filtrerende lymfevaten.
* **Gameplay-focus**: Narratieve afsluiting en de uiteindelijke toestandstransitie van het personage.
* **Centrale Uitdaging**: Geen vijanden. De leukocyt heeft zijn missie volbracht en beëindigt zijn levensduur via het proces van geprogrammeerde celdesintegratie (Apoptose).

---

## 3. Catalogus van Vijanden, Vallen en Eindbaas

### 3.1 Gewone Vijanden

1. **Pathogene Bacterie (PathogenicBacterium)**
   * **Gedrag**: Grondvijand in de vorm van een staafje (vriendelijke bacil) die horizontale platformen patrouilleert en van richting veranderd wanneer hij randen of obstakels raakt.
   * **Gevechtsregel**: Beschikt over een gemiddeld krachtsniveau. Kan alleen worden gefagocyteerd als de leukocyt versterkt is door een Antibioticum. Anders fagocyteert de bacterie de leukocyt, wat leidt tot een onmiddellijke nederlaag.

2. **Geïnfecteerde Gastheercel (VirusInfectedCell - Orgaanspecifiek)**
   * **Biologisch Concept**: Het virus zweeft niet vrij rond in de omgeving; het heeft een cel van het weefsel zelf geïnfecteerd. De leukocyt moet de **volledige geïnfecteerde cel** fagocyteteren om de virale haard te neutraliseren.
   * **Weefselvariaties per Level**:
     * 🧠 **Geïnfecteerde Neurale Cel (`NeuralInfectedCell`)**: Aanwezig in de hersenenfase (bv. Neuron/Glialcel met virale lading).
     * 🫁 **Geïnfecteerde Respiratoire Cel (`RespiratoryInfectedCell`)**: Aanwezig in de longenfase (bv. Geïnfecteerde Pneumocyt/Pulmonale Epitheelcel).
     * 🫀 **Geïnfecteerde Circulatoire/Cardiale Cel (`CardiacInfectedCell`)**: Aanwezig in de hartfase (bv. Geïnfecteerde Cardiomyocyt/Endotheelcel).
   * **Gevechtsregel**: Als de leukocyt de geïnfecteerde cel opslokt zonder het **Vaccin** in het inventaris te hebben geactiveerd, doorbreekt het aanwezige virus de immuniteitsdefensie en infecteert het de leukocyt, wat resulteert in een onmiddellijke dood. Als de leukocyt gevaccineerd is, biedt de immuniteit de mogelijkheid om de geïnfecteerde cel veilig te fagocyteteren en te vernietigen.

### 3.2 Omgevingsval
* **Pollenkorrel (Pollen)**
  * **Gedrag**: Statisch of zwevend omgevingsobstakel dat niet door de speler kan worden aangevallen of vernietigd.
  * **Effect bij Contact**: Bij aanraking met het pollen krijgt de leukocyt een onmiddellijke allergie-uitbraak die 10 seconden duurt. Tijdens de uitbraak raakt de cel in een auto-immuuncollaps, waarbij het eigen lichaam wordt aangevallen en de bewegingspatronen tijdelijk veranderen.
  * **Genezing**: Het allergische effect kan onmiddellijk worden gestopt als de speler een Anti-allergiepil consumeert of wacht tot de timer van 10 seconden afloopt.

### 3.3 Eindbaas: Chagas-Parasiet (Trypanosoma cruzi)
Gevestigd in het hartlevel treedt de parasiet op als de hoofdvijand van het spel en beschikt hij over twee afzonderlijke gevechtsfasen:

1. **Fase 1: Trypomastigote Vorm (Geflagelleerde Navigatie)**
   * De parasiet beweegt zich snel door de arena in directe aanvallen op de leukocyt, waarbij hij zijn flagel gebruikt om grote mechanische schade toe te brengen.
2. **Fase 2: Amastigote Cluster (Woede-modus - Leven onder 50%)**
   * De parasiet zet zich vast in het hartweefsel en begint kleine giftige replica's en celtoxines door de hele arena af te vuren, wat vereist dat de speler het medicijn Benznidazol gebruikt om de genadeslag toe te brengen.

---

## 4. Gameplay-mechanics, Besturing en Itemblokken

### 4.1 Beweging en Fysica
* **Rennen en Springen**: De leukocyt heeft een vloeiende bewegingsfysica met horizontale versnelling, wrijvingsontkoppeling en sprongen waarvan de hoogte proportioneel is aan de tijd dat de springknop ingedrukt wordt gehouden.
* **Ontwijken via Sprong**: Springen is de primaire defensieve manoeuvre om grondbacteriën, door virussen geïnfecteerde cellen en pollenstekels te ontwijken.

### 4.2 Itemblokken (Super Mario-stijl)
* **Botsingsmechanic**: Verspreid over de levels bevinden zich zwevende blokken (Medicijndozen).
* **Activering**: Wanneer de leukocyt omhoog springt en tegen de onderkant van het blok botst, verandert het blok zijn toestand naar "geopend" en werpt het een farmaceutisch item rechtstreeks in het inventaris van de speler.

### 4.3 Inventaris- en Opslagsysteem
* De leukocyt heeft een opslagtas (Inventaris) waarin de uit de blokken verzamelde items worden bewaard.
* De speler kan de opgeslagen medicijnen bekijken en ze handmatig activeren op het meest strategische moment tijdens verkenning of gevecht.

---

## 5. Consumptie-items en Boosts

| Item | Herkomst | Effect op Leukocyt | Actiemechanisme |
| :--- | :--- | :--- | :--- |
| **Antibioticum** | Itemblokken | Verhoogt de fagocytosekracht tegen Pathogene Bacteriën drastisch. | Verleent een tijdelijke krachtboost die exclusief is tegen bacteriële vijanden. |
| **Vaccin** | Itemblokken | Garandeert het vermogen om door Virussen Geïnfecteerde Cellen te fagocyteteren zonder besmet te raken. | Voegt een specifieke immuniteitslaag toe die dodelijke infectie van de leukocyt voorkomt bij het inslikken van de geïnfecteerde cel. |
| **Anti-allergisch** | Itemblokken | Geneest de allergie-uitbraak veroorzaakt door Pollen onmiddellijk. | Onderbreekt de auto-immuuntoestand en herstelt de normale celbesturing. |
| **Benznidazol** | Hartblokken | Verleent de verwoestende kracht die nodig is om *Trypanosoma cruzi* te verslaan. | Versterkt de chemische aanval van de leukocyt, waardoor het membraan van de parasiet vernietigd kan worden. |

---

## 6. Celtoestanden en Levensloop

Het gedrag van de Leukocyt wordt beheerd door een strikte cyclus van functionele toestanden:

```
[ Normale Toestand ] ──( Contact met Pollen )──> [ Allergische Toestand (10s) ]
       │                                                      │
       │                                        (Gebruik Anti-allergisch of Einde Timer)
       │                                                      │
       ├──────────────────────────────────────────────────────┘
       │
       ├──( Totaal Levensverlies / Gefagocyteerd door Bacterie of Geïnfecteerd door Virale Cel )──> [ Doodstoestand (Game Over) ]
       │
       └──( Aankomst bij Lymfeklieren )──────────────────────────────────────────────────────────> [ Apoptosetoestand (Overwinning) ]
```

1. **Normale Toestand (NormalState)**: Standaardbesturing voor beweging, sprong en fagocytose gebaseerd op de huidige kracht van het personage.
2. **Allergische Toestand (AllergicState)**: Geactiveerd bij het aanraken van pollen. Maximale duur van 10 seconden. De speler verliest fijne controle, loopt continue schade aan het lichaam op en de besturing verandert totdat een anti-allergisch middel wordt geconsumeerd of de tijd verstrijkt.
3. **Doodstoestand (DeadState)**: Geactiveerd wanneer het leven nul bereikt, wanneer de leukocyt wordt gefagocyteerd door een sterkere bacterie of wanneer een door een virus geïnfecteerde cel wordt ingeslikt zonder gevaccineerd te zijn. Schakelt besturingscommando's uit en meldt het systeem om het Game Over-scherm te tonen.
4. **Apoptosetoestand (ApoptosisState)**: Geactiveerd bij het bereiken van de eindzone van de Lymfeklieren. De leukocyt schakelt zijn besturing uit, voert een goedaardige celdesintegratie-animatie uit en meldt de succesvolle voltooiing van het spel.

---

## 7. Architecturale Mapping: SOLID en Design Patterns

Dit hoofdstuk licht toe hoe elk spelelement wordt ondersteund door de concepten die vereist zijn in het vak Software Engineering aan AP Hogeschool, en dient als directe leidraad voor het mondeling examen.

### 7.1 Toegepaste SOLID-principes
* **Single Responsibility Principle (SRP)**:
  * De spelerklasse (`Leukocyte`) beheert uitsluitend positie, fysica en gezondheid.
  * De klasse `Inventory` is als enige verantwoordelijk voor de opslag en telling van items.
  * De klasse `LevelManager` reageert uitsluitend op de overgang tussen Hersenen, Longen, Hart en Lymfeklieren.
* **Open/Closed Principle (OCP)**:
  * Het gevechtssysteem en nieuwe items kunnen worden toegevoegd door nieuwe boostklassen (`BoostDecorator`) te maken zonder bestaande code van de speler te wijzigen.
* **Liskov Substitution Principle (LSP)**:
  * De specifieke geïnfecteerde cellen (`NeuralInfectedCell`, `RespiratoryInfectedCell`, `CardiacInfectedCell`) erven van `VirusInfectedCell`, die op haar beurt `IEnemy` implementeert. Elk systeem dat vijanden verwerkt, behandelt deze polymorf en transparant zonder runtime-fouten te veroorzaken.
* **Interface Segregation Principle (ISP)**:
  * Beknopte en gefocuste interfaces: afzonderlijke interfaces voor bewegende elementen, aanvalbare elementen, verzamelbare items en event-listeners.
* **Dependency Inversion Principle (DIP)**:
  * De klassen op hoog niveau (zoals de speler en het itemblok) zijn strikt afhankelijk van interfaces (zoals `IEnemy`, `ICollectibleItem`, `IAttackPower`), nooit van concrete implementaties die rechtstreeks met `new` zijn geïnstantieerd.

### 7.2 Toegepaste GoF Design Patterns
* **Strategy Pattern**:
  * Gebruikt om de aanvalsmodi van de leukocyt dynamisch tijdens runtime af te wisselen (bv. afscheiding van enzymen voor korte afstand vs. afvuren van cytokinen voor lange afstand).
* **State Pattern**:
  * Gebruikt in de Leukocyt om de transparante overgang tussen `NormalState`, `AllergicState`, `DeadState` en `ApoptosisState` te besturen.
  * Gebruikt bij de Eindbaas `Trypanosoma cruzi` om de overgang van Fase 1 (Trypomastigote) naar Fase 2 (Amastigota) te beheren.
* **Decorator Pattern**:
  * Gebruikt om de tijdelijke effecten van medicijnen (`AntibioticBoostDecorator`, `VaccineBoostDecorator`, `BenznidazolDecorator`) toe te passen op de aanvalskracht van de leukocyt, waarbij de basis-schadeberekening wordt omwikkeld zonder de spelerklasse te vervuilen.
* **Observer Pattern**:
  * Gebruikt voor losgekoppelde communicatie tussen de Leukocyt (Subject) en de Gebruikersinterface / Game Manager (Observers). Events zoals `OnPlayerDied` en `OnMissionCompleted` melden de manager automatisch om Game Over of Overwinning weer te geven.
* **Factory Method Pattern**:
  * Gebruikt door de factories van elk level (`BrainLevelFactory`, `LungLevelFactory`, `HeartLevelFactory`) om de geïnfecteerde cel te instantiëren die hoort bij het weefsel (`NeuralInfectedCell`, `RespiratoryInfectedCell`, `CardiacInfectedCell`) en door de Itemblokken om medicijnen te produceren.

---

## 8. Conformiteitschecklist AP Hogeschool

- [x] **Speltype**: Speelbaar 2D-platformspel met springfysica en botsingen.
- [x] **Levels**: 3 actieve niveaus (Hersenen, Longen, Hart) + Epiloog in de Lymfeklieren.
- [x] **Vijanden**: 2 actieve pathogenen/gastheren (Bacterie en per orgaan gecontextualiseerde door Virus Geïnfecteerde Cel) + 1 statische val (Pollen) + 1 Eindbaas met fasen (*Trypanosoma cruzi*).
- [x] **Extra Mechanics**: 
  1. Item- en muntenblokken met botsing aan de onderkant (Super Mario-stijl).
  2. Inventarissysteem en doseringopslag.
  3. Conditioneel fagocytosesysteem van per orgaan Geïnfecteerde Cellen en Bacteriën met Kracht-/Vaccinboosts.
  4. Helper/Assistent (*HelperAntibody* die vijanden markeert).
- [x] **Architectuur**: Volledige mapping van de 5 SOLID-principes en de Design Patterns (Strategy, State, Decorator, Observer en Factory Method).
