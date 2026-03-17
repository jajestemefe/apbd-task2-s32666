namespace APBD_TASK2.Models;

public class Camera : Equipment
{
    public int LensWidth { get; set; }
    
    public int BatteryCapacity { get; set; }
    
    public Camera(string name, int LensWidth, int BatteryCapacity)
        : base(name)
    {
        LensWidth = LensWidth;
        BatteryCapacity = BatteryCapacity;
    }
}