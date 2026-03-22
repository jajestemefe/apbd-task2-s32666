using APBD_TASK2.Enum;

namespace APBD_TASK2.Models;

public abstract class Equipment
{
    private static int _nextID = 1;
    
    public int ID { get; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public EquipmentStatus Status { get; set; }
    
    public DateTime AddedDate { get; set; }

    public Equipment(string name, string description = "")
    {
        ID = _nextID++;
        Name = name;
        Description = description;
        Status = EquipmentStatus.Available;
        AddedDate = DateTime.Now;
    }
}