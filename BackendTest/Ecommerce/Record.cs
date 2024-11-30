using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Ecommerce
{
    internal class Record
    {
        public int Id { get; set; }
        public string ArticleName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal PercentageDiscount { get; set; }
        public string Buyer { get; set; }

        // Calcola il prezzo totale senza sconto
        public decimal TotalWithoutDiscount()
        {
            return Quantity * UnitPrice;
        }

        // Calcola il prezzo totale con sconto
        public decimal TotalWithDiscount()
        {
            var totalWithoutDiscount = TotalWithoutDiscount();
            return totalWithoutDiscount * (1 - (PercentageDiscount / 100));
        }

        // Calcola la differenza di sconto
        public decimal DiscountDifference()
        {
            var totalWithoutDiscount = TotalWithoutDiscount();
            var totalWithDiscount = TotalWithDiscount();
            return totalWithoutDiscount - totalWithDiscount;
        }

        // Metodo per leggere il CSV e restituire i record
        public static List<Record> ReadCsv(string filePath)
        {
            var records = new List<Record>();
            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines.Skip(1))
            {
                var fields = line.Split(',');

                if (fields.Length < 6) // Controlla se la colonna è valida
                {
                    Console.WriteLine($"Linea ignorata: {line}");
                    continue;
                }

                try
                {
                    records.Add(new Record
                    {
                        Id = int.Parse(fields[0]),
                        ArticleName = fields[1],
                        Quantity = int.Parse(fields[2]),
                        UnitPrice = decimal.Parse(fields[3]),
                        PercentageDiscount = decimal.Parse(fields[4]),
                        Buyer = fields[5]
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Errore durante l'analisi della linea: {line}. Dettagli: {ex.Message}");
                }
            }

            return records;
        }

        // Metodo per ottenere il record con il totale più alto senza sconto
        public static Record GetRecordWithHighestTotal(List<Record> records)
        {
            return records.OrderByDescending(r => r.TotalWithoutDiscount()).FirstOrDefault();
        }

        // Metodo per ottenere il record con la quantità più alta
        public static Record GetRecordWithHighestQuantity(List<Record> records)
        {
            return records.OrderByDescending(r => r.Quantity).FirstOrDefault();
        }

        // Metodo per ottenere il record con la differenza di sconto più alta
        public static Record GetRecordWithHighestDiscountDifference(List<Record> records)
        {
            return records.OrderByDescending(r => r.DiscountDifference()).FirstOrDefault();
        }

        // Metodo per stampare i dettagli del record nella console
        public static void PrintRecord(string title, Record record)
        {
            Console.WriteLine($"\n{title}");
            if (record != null)
            {
                Console.WriteLine($"Id: {record.Id}, Nome Articolo: {record.ArticleName}, Quantità: {record.Quantity}, " +
                                  $"Prezzo Unità: {record.UnitPrice}, Sconto Percentuale: {record.PercentageDiscount}, " +
                                  $"Acquirente: {record.Buyer}, Totale Senza Sconto: {record.TotalWithoutDiscount()}, " +
                                  $"Totale Con Sconto: {record.TotalWithDiscount()}, Differenza Sconto: {record.DiscountDifference()}");
            }
            else
            {
                Console.WriteLine("Nessun record trovato.");
            }
        }
    }
}
