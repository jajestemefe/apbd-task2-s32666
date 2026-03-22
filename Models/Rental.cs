using System;

namespace APBD_TASK2.Models;

public class Rental
{
    private static int _nextId = 1;
    
    public int Id { get; }
    public User RentedBy { get; set; }
    public Equipment RentedEquipment { get; set; }
    public DateTime RentalDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? ReturnDate { get; set; } 

    public Rental(User user, Equipment equipment, int durationInDays)
    {
        Id = _nextId++;
        RentedBy = user;
        RentedEquipment = equipment;
        RentalDate = DateTime.Now;
        DueDate = RentalDate.AddDays(durationInDays);
    }
}