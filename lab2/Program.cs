using System;
using System.Linq;

Dictionary<string, double[]> _old = new Dictionary<string, double[]>();
Dictionary<string, double[]> _new = new Dictionary<string, double[]>();

Console.WriteLine("Enter data for old model");
AddToDict("High", ref _old);
AddToDict("Average", ref _old);
AddToDict("Low", ref _old);
Console.WriteLine("Enter data for new model");
AddToDict("High", ref _new);
AddToDict("Average", ref _new);
AddToDict("Low", ref _new);


// Математичне сподівання
var M_old = _old["high"][0] * _old["high"][1] 
    + _old["average"][0] * _old["average"][1] 
    + _old["low"][0] * _old["low"][1];
var M_new = _new["high"][0] * _new["high"][1]
    + _new["average"][0] * _new["average"][1]
    + _new["low"][0] * _new["low"][1];

// 
var V_old = _old["high"][0] * Math.Pow((_old["high"][1] - M_old), 2) +
    _old["average"][0] * Math.Pow((_old["average"][1] - M_old), 2) +
    _old["low"][0] * Math.Pow((_old["low"][1] - M_old), 2);
var V_new = _new["high"][0] * Math.Pow((_new["high"][1] - M_new), 2) +
    _new["average"][0] * Math.Pow((_new["average"][1] - M_new), 2) +
    _new["low"][0] * Math.Pow((_new["low"][1] - M_new), 2);
Console.WriteLine(V_old + " " + V_new);
// Середньоквадратичне відхилення
var kvvid_old = Math.Sqrt(V_old);
var kvvid_new = Math.Sqrt(V_new);

Console.WriteLine($"Standard deviation: old: {kvvid_old}; new: {kvvid_new}");

if (kvvid_new > kvvid_old) 
    Console.WriteLine("A risk-averse person can leave the old model");
else
    Console.WriteLine("A person prone to risk can introduce a new model into production");

// кф варіації
var CV_old = kvvid_old / M_old;
var CV_new = kvvid_new / M_new;

Console.WriteLine($"Coefficient of variation: old: {CV_old}; new: {CV_new}");

if (CV_new > CV_old)
    Console.WriteLine("A risk-averse person can leave the old model");
else
    Console.WriteLine("A person prone to risk can introduce a new model into production");

// Семіквадратичне відхилення
double SSV_old = 0, SSV_new = 0;
foreach (var item in _old)
{
    if (item.Value[1] < 0)
    {
        SSV_old += Math.Pow(item.Value[1] - M_old, 2) * item.Value[0];
    }
   
}
SSV_old = Math.Sqrt(SSV_old);

foreach (var item in _new)
{
    if (item.Value[1] < 0)
    {
        SSV_new += Math.Pow(item.Value[1] - M_new, 2) * item.Value[0];
    }

}
SSV_new = Math.Sqrt(SSV_new);

// кф семіваріації
var CSV_old = SSV_old / M_old;
var CSV_new = SSV_new / M_new;

Console.WriteLine($"Semivariation coefficient: old: {CSV_old}; new: {CSV_new}");

if (CV_new > CV_old)
    Console.WriteLine("A risk-averse person can leave the old model");
else
    Console.WriteLine("A person prone to risk can introduce a new model into production");

// Сподівані збитки
double Z_old = 0, Z_new = 0;
foreach (var item in _old)
{
    if (item.Value[1] < 0)
    {
        Z_old += item.Value[1] * item.Value[0];
    }
}

foreach (var item in _new)
{
    if (item.Value[1] < 0)
    {
        Z_new += item.Value[1] * item.Value[0];
    }
}

Console.WriteLine($"Expected losses: old: {Z_old}; new: {Z_new}");

if (CV_new < CV_old)
    Console.WriteLine("The least risky is to leave the old model");
else
    Console.WriteLine("The least risky is to implement a new model");

Console.WriteLine("Therefore, to avoid the risk of losses, it is worth leaving the old model");

void AddToDict(string str, ref Dictionary<string, double[]> data)
{
    Console.WriteLine($"{str}:");
    Console.Write("probability ");
    double pr = Convert.ToDouble(Console.ReadLine());
    Console.Write("profit ");
    double pr1 = Convert.ToDouble(Console.ReadLine());
    data.Add(str.ToLower(), new double[] { pr, pr1 });
}