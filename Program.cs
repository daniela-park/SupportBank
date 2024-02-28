using SupportBank.Management;

// C# Packages: https://www.nuget.org/
// http://dotnet-tutorials.net/Article/read-an-excel-file-in-csharp

using System.Globalization;
using CsvHelper;
using System.Runtime.InteropServices;

using var streamReader = new StreamReader("Transactions2014.csv");
using var csvReader = new CsvReader(streamReader, CultureInfo.GetCultureInfo("en-GB"));
var transactions = csvReader.GetRecords<Transaction>();
var bank = new Bank(transactions);

bank.ListAll();
bank.ListAccount("Todd");