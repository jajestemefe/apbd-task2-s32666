using APBD_TASK2.Models;
using System.Collections.Generic;

namespace APBD_TASK2.Interfaces;

public interface IRentalServices
{
    void AddEquipment(Equipment equipment);
    void AddUser(User user);
    List<Equipment> GetAllEquipments();
    
    bool RentEquipment(User user, Equipment equipment, int days);
    
    double ReturnEquipment(Equipment equipment, int daysLate = 0);
}