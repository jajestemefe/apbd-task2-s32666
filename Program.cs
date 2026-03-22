using System;
using APBD_TASK2.Enum;
using APBD_TASK2.Models;
using APBD_TASK2.Services;

var rentalService = new RentalService();

Console.WriteLine("=== UNIVERSITY EQUIPMENT RENTAL SYSTEM ===\n");

var laptop1 = new Laptop("Dell XPS 15", 16, 15);
var laptop2 = new Laptop("MacBook Air", 8, 13);
var projector = new Projector("Epson 1080p", "Epson", 1080);
var camera = new Camera("Sony A7III", 35, 2200);

rentalService.AddEquipment(laptop1);
rentalService.AddEquipment(laptop2);
rentalService.AddEquipment(projector);
rentalService.AddEquipment(camera);

var student = new User("John", "Doe", UserType.Student);
var teacher = new User("Jane", "Smith", UserType.Teacher);

rentalService.AddUser(student);
rentalService.AddUser(teacher);

Console.WriteLine("--- Testing Rentals ---");
rentalService.RentEquipment(student, laptop1, 3);

rentalService.RentEquipment(teacher, laptop1, 2);

rentalService.RentEquipment(student, laptop2, 5);
rentalService.RentEquipment(student, projector, 1);

Console.WriteLine("\n--- Testing Returns ---");
double penalty1 = rentalService.ReturnEquipment(laptop1, 0);
Console.WriteLine($"Returned '{laptop1.Name}' on time. Penalty: {penalty1} PLN");

double penalty2 = rentalService.ReturnEquipment(laptop2, 5);
Console.WriteLine($"Returned '{laptop2.Name}' late! Penalty: {penalty2} PLN\n");

Console.WriteLine("=== FINAL SYSTEM STATE ===");
foreach (var eq in rentalService.GetAllEquipments())
{
    Console.WriteLine($"- {eq.Name} | Status: {eq.Status}");
}