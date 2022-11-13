using System;
using System.Linq;

// Математичне сподівання
var M_old = 0.2 * 80 + 0.7 * 50 + 0.1 * (-20);
var M_new = 0.2 * 300 + 0.5 * 100 + 0.3 * (-100);

// 
var V_old = 0.2 * Math.Pow((80 - M_old), 2) +
    0.7 * Math.Pow((50 - M_old), 2) +
    0.1 * Math.Pow(((-20) - M_old), 2);

var V_new = 0.2 * Math.Pow((300 - M_new), 2) +
    0.5 * Math.Pow((100 - M_new), 2) +
    0.3 * Math.Pow(((-100) - M_new), 2);

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
var SSV_old = Math.Sqrt(Math.Pow(-20 - M_old, 2) * 0.1);
var SSV_new = Math.Sqrt(Math.Pow(-100 - M_new, 2) * 0.3);

// кф семіваріації
var CSV_old = SSV_old / M_old;
var CSV_new = SSV_new / M_new;

Console.WriteLine($"Semivariation coefficient: old: {CSV_old}; new: {CSV_new}");

if (CV_new > CV_old)
    Console.WriteLine("A risk-averse person can leave the old model");
else
    Console.WriteLine("A person prone to risk can introduce a new model into production");

// Сподівані збитки
var Z_old = -20 * 0.1;
var Z_new = -100 * 0.3;

Console.WriteLine($"Expected losses: old: {Z_old}; new: {Z_new}");

if (CV_new < CV_old)
    Console.WriteLine("The least risky is to leave the old model");
else
    Console.WriteLine("The least risky is to implement a new model");