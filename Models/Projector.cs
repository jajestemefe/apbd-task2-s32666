namespace APBD_TASK2.Models;

public class Projector : Equipment
{
    public int Resolution { get; set; }

    public string Brand { get; set; }

    public Projector(string name,  string brand, int resolution)
        : base(name)
    {
        Brand = brand;
        Resolution = resolution;
    }
}