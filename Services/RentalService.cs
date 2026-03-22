using System;
using System.Collections.Generic;
using APBD_TASK2.Database;
using APBD_TASK2.Enum;
using APBD_TASK2.Interfaces;
using APBD_TASK2.Models;

namespace APBD_TASK2.Services;

public class RentalService : IRentalServices
{
    private readonly Singleton _db = Singleton.Instance;

    public void AddEquipment(Equipment equipment)
    {
        _db.Equipments.Add(equipment);
    }

    public void AddUser(User user)
    {
        _db.Users.Add(user);
    }

    public List<Equipment> GetAllEquipments()
    {
        return _db.Equipments;
    }

    public bool RentEquipment(User user, Equipment equipment, int days)
    {
        if (equipment.Status != EquipmentStatus.Available)
        {
            Console.WriteLine($"[BLOCKED] Cannot rent {equipment.Name}. It is {equipment.Status}.");
            return false;
        }

        int activeRentals = 0;
        foreach (Rental r in _db.Rentals)
        {
            if (r.RentedBy.Id == user.Id && r.ReturnDate == null)
            {
                activeRentals++;
            }
        }

        if (activeRentals >= user.MaxActiveRentals)
        {
            Console.WriteLine($"[BLOCKED] {user.Name} has reached the limit of {user.MaxActiveRentals} rentals.");
            return false; // Stop here, rental failed
        }

        var rental = new Rental(user, equipment, days);
        _db.Rentals.Add(rental);
        equipment.Status = EquipmentStatus.Rented;
        
        Console.WriteLine($"[SUCCESS] {user.Name} rented {equipment.Name}.");
        return true; 
    }

    public double ReturnEquipment(Equipment equipment, int daysLate = 0)
    {
        Rental activeRental = null;
        foreach (Rental r in _db.Rentals)
        {
            if (r.RentedEquipment.ID == equipment.ID && r.ReturnDate == null)
            {
                activeRental = r;
                break;
            }
        }

        if (activeRental == null)
        {
            Console.WriteLine($"[ERROR] {equipment.Name} is not currently rented out.");
            return 0;
        }

        activeRental.ReturnDate = DateTime.Now.AddDays(daysLate);
        equipment.Status = EquipmentStatus.Available;

        double penalty = 0;
        if (daysLate > 0)
        {
            double penaltyPerDay = 10.0;
            penalty = daysLate * penaltyPerDay;
        }

        return penalty;
    }
}