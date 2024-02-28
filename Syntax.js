using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;
using System.Data.Common;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;

// READING THE CSV FILE AND STORING INTO A LIST
using var fileReader = new StreamReader(File.OpenRead("C:/Users/DanPar/techswitch/TechSwitchTraining/SupportBank/Transactions2014.csv"));
List<DateOnly> date = new List<DateOnly>();
List<string> from = new List<string>();
List<string> to = new List<string>();
List<string> narrative = new List<string>();
List<decimal> amount = new List<decimal>();
while (!fileReader.EndOfStream)
{
    var line = fileReader.ReadLine();
    var values = line.Split(',');
    date.Add(DateOnly.Parse(values[0]));
    from.Add(values[1]);
    to.Add(values[2]);
    narrative.Add(values[3]);
    amount.Add(decimal.Parse(values[4]));
}

// TOTAL EACH PERSON HAS TO PAY
HashSet<string> payers = new HashSet<string>(from);
Console.WriteLine($"There are {payers.Count} people to pay."); // 12
foreach (string name in payers)
{
    Console.WriteLine(name);
}

List<decimal> toPay = new List<decimal>();
decimal totalToPay = 0;
for (int i = 0; i < from.Count; i++)
{
    for (int j = 0; j < amount.Count; j++)
    {
        if (i == j)
        {
            if (from[i] == "Jon A")
            {
                toPay.Add(amount[j]);
                totalToPay = toPay.Sum();
                // Console.WriteLine($"{from[i]} paid: £{totalToPay}");
            }
        }
    }
}
Console.WriteLine($"Jon A paid: £{totalToPay}");


// TOTAL EACH PERSON HAS TO RECEIVE
HashSet<string> receivers = new HashSet<string>(to);
Console.WriteLine($"There are {receivers.Count} people to receive."); // 12

List<decimal> toReceive = new List<decimal>();
decimal totalToReceive = 0;
for (int i = 0; i < to.Count; i++)
{
    for (int j = 0; j < amount.Count; j++)
    {
        if (i == j)
        {
            if (to[i] == "Jon A")
            {
                toReceive.Add(amount[j]);
                totalToReceive = toReceive.Sum();
                // Console.WriteLine($"{to[i]} paid: £{totalToReceive}");
            }
        }
    }
}
Console.WriteLine($"Jon A has to receive: £{totalToReceive}");

// BALANCE OF EACH PERSON
decimal balance = 0;
balance = totalToPay - totalToReceive;
if (totalToPay > 0)
{
    Console.WriteLine($"Jon A owes £{balance}.");
}
else
{
    Console.WriteLine($"Jon A has to receive £{balance}.");
}
