using System;
using System.IO;
using System.Collections.Generic;

namespace Ecommerce
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ottieni il percorso del file CSV
            Console.WriteLine("Inserisci il percorso del file CSV:");
            string filePath = Console.ReadLine();

            // Controlla se il file esiste
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Errore: Il file '{filePath}' non è stato trovato.");
                return;
            }

            // Leggi i record dal CSV
            var records = Record.ReadCsv(filePath);

            // Controlla se i record sono vuoti
            if (records.Count == 0)
            {
                Console.WriteLine("Il file CSV è vuoto o non contiene dati validi.");
                return;
            }

            // Stampa il record con l'importo totale più alto
            var recordWithHighestTotal = Record.GetRecordWithHighestTotal(records);
            Record.PrintRecord("Record con l'importo totale più alto:", recordWithHighestTotal);

            // Stampa il record con la quantità più alta
            var recordWithHighestQuantity = Record.GetRecordWithHighestQuantity(records);
            Record.PrintRecord("Record con la quantità più alta:", recordWithHighestQuantity);

            // Stampa il record con la differenza di sconto più alta
            var recordWithMaxDiscountDifference = Record.GetRecordWithHighestDiscountDifference(records);
            Record.PrintRecord("Record con la differenza di sconto più alta:", recordWithMaxDiscountDifference);
        }
    }
}
