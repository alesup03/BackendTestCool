using System;
using System.IO;
using System.Collections.Generic;
using static Ecommerce.Record;

namespace Ecommerce
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //csv path
            Console.WriteLine("Enter the path of the CSV file:");
            string filePath = Console.ReadLine();

            //csv existence
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Error: The file '{filePath}' was not found.");
                return;
            }

            //csv reading
            var csvReader = new CsvReader();
            var records = csvReader.ReadCsv(filePath);

            //records check
            if (records.Count == 0)
            {
                Console.WriteLine("The CSV file is empty or does not contain valid data.");
                return;
            }

            //report generation
            var highestTotalReport = new HighestTotal();
            var highestQuantityReport = new HighestQuantity();
            var highestDifferenceReport = new HighestDifference();
            var consolePrinter = new ConsolePrinter();

            //record highest total amount
            var recordWithHighestTotal = highestTotalReport.GetRecord(records);
            consolePrinter.PrintRecord("Record with the highest total amount:", recordWithHighestTotal);

            //record highest quantity
            var recordWithHighestQuantity = highestQuantityReport.GetRecord(records);
            consolePrinter.PrintRecord("Record with the highest quantity:", recordWithHighestQuantity);

            //record highest discount difference
            var recordWithMaxDiscountDifference = highestDifferenceReport.GetRecord(records);
            consolePrinter.PrintRecord("Record with the highest discount difference:", recordWithMaxDiscountDifference);
        }
    }
}
