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

        // Calculate total price without discount
        public decimal TotalWithoutDiscount()
        {
            return Quantity * UnitPrice;
        }

        // Calculate total price with discount
        public decimal TotalWithDiscount()
        {
            var totalWithoutDiscount = TotalWithoutDiscount();
            return totalWithoutDiscount * (1 - (PercentageDiscount / 100));
        }

        // Calculate discount difference
        public decimal DiscountDifference()
        {
            var totalWithoutDiscount = TotalWithoutDiscount();
            var totalWithDiscount = TotalWithDiscount();
            return totalWithoutDiscount - totalWithDiscount;
        }

        //csv reading
        public class CsvReader
        {
            public List<Record> ReadCsv(string filePath)
            {
                var records = new List<Record>();
                var lines = File.ReadAllLines(filePath);

                foreach (var line in lines.Skip(1))
                {
                    var fields = line.Split(',');

                    if (fields.Length < 6) // Check if the column is valid
                    {
                        Console.WriteLine($"Line ignored: {line}");
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
                        Console.WriteLine($"Error parsing line: {line}. Details: {ex.Message}");
                    }
                }

                return records;
            }
        }

        // Report classes
        public class HighestTotal
        {
            public Record GetRecord(List<Record> records)
            {
                return records.OrderByDescending(r => r.TotalWithoutDiscount()).FirstOrDefault();
            }
        }

        public class HighestQuantity
        {
            public Record GetRecord(List<Record> records)
            {
                return records.OrderByDescending(r => r.Quantity).FirstOrDefault();
            }
        }

        public class HighestDifference
        {
            public Record GetRecord(List<Record> records)
            {
                return records.OrderByDescending(r => r.DiscountDifference()).FirstOrDefault();
            }
        }

        // Console output printing class
        public class ConsolePrinter
        {
            public void PrintRecord(string title, Record record)
            {
                Console.WriteLine($"\n{title}");
                if (record != null)
                {
                    Console.WriteLine($"Id: {record.Id}, Article Name: {record.ArticleName}, Quantity: {record.Quantity}, " +
                                  $"Unit Price: {record.UnitPrice}, Percentage Discount: {record.PercentageDiscount}, " +
                                  $"Buyer: {record.Buyer}, Total Without Discount: {record.TotalWithoutDiscount()}, " +
                                  $"Total With Discount: {record.TotalWithDiscount()}, Discount Difference: {record.DiscountDifference()}");
                }
                else
                {
                    Console.WriteLine("No record found.");
                }
            }
        }
    }
}
