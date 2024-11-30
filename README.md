# Backend Test(Coolshop)

**Ecommerce** è un'applicazione in C# che analizza i dati di un file CSV e genera i seguenti report:
- La transazione con il totale più alto senza sconto.  
- La transazione con la quantità di articoli più alta.  
- La transazione con la differenza di sconto più alta.  

## Funzionalità
1. **Lettura di file CSV**: L'applicazione legge un file CSV contenente i dati delle varie transazioni
2. **Elaborazione dei dati**: I dati vengono elaborati per calcolare totali, sconti e differenze tra prezzo unitario e prezzo scontato.  
3. **Report automatici**: Viene identificata la transazione rilevante per ciascun criterio:  
   - Totale senza sconto più alto.  
   - Quantità più alta.  
   - Differenza di sconto più alta.  
4. **Stampa dei risultati**: I risultati vengono visualizzati in console in modo leggibile.  

---

## Struttura del File CSV
Il file CSV deve avere questa struttura:  
```csv
Id,Article Name,Quantity,Unit price,Percentage discount,Buyer
1,Coke,10,1,0,Mario Rossi
2,Coke,15,2,0,Luca Neri
3,Fanta,5,3,2,Luca Neri
4,Water,20,1,10,Mario Rossi
5,Fanta,1,4,15,Andrea Bianchi
```
---

## Come Utilizzare il Programma

### 1. Compilazione e Esecuzione
- Clona il progetto o scarica il codice.  
- Compila ed esegui il programma usando un ambiente di sviluppo come **Visual Studio**.  

### 2. Esecuzione del Programma
1. Scarica il CSV di prova (file.csv) .  
2. Avvia il programma.  
3. Inserisci il **percorso completo** del file CSV quando richiesto.  
   - Per trovare il percorso, fai clic con il **tasto destro** sul file CSV, seleziona **Proprietà**, quindi copia il valore del campo **Percorso**.  

### 3. Risultati
Il programma analizzerà i dati del file CSV e visualizzerà i seguenti report:  
- **Record con il totale più alto.**  
- **Record con la quantità più alta.**  
- **Record con la differenza di sconto più alta.**  

---

## Dettagli Tecnici

### Classi Principali

- Program: Main dell'applicazione. Gestisce l'avvio del programma, inclusa la lettura del file CSV, la gestione degli errori e la visualizzazione dei report.

- Record: La classe contenente la logica del programma, con i seguenti metodi:
   -TotalWithoutDiscount(): Calcola il totale senza sconto (quantità * prezzo unitario).
   -TotalWithDiscount(): Calcola il totale applicando lo sconto.
   -DiscountDifference(): Calcola la differenza tra il totale senza sconto e quello con sconto.
   -ReadCsv(string filePath): Legge il file CSV, valida le righe e restituisce una lista di oggetti Record.
   -GetRecordWithHighestTotal(List<Record> records): Restituisce il record con il totale senza sconto più alto.
   -GetRecordWithHighestQuantity(List<Record> records): Restituisce il record con la quantità più alta.
   -GetRecordWithHighestDiscountDifference(List<Record> records): Restituisce il record con la differenza di sconto più alta.
   -PrintRecord(string title, Record record): Stampa i dettagli di un record specificato in console.

### Gestione degli Errori
- Verifica che il file CSV esista prima di tentare di leggerlo.
- Ignora le righe non valide o incomplete e segnala gli errori di parsing.
- Se non ci sono record nel file CSV o se i dati non sono validi, viene mostrato un messaggio appropriato all'utente.





