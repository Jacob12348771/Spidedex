public class Spider
{
    public enum Tempereament
    {
        Docile, Neutral, Aggressive, Skittsh, Calm
    }
    public int Id { get; set; }
    public DateOnly DateObtained { get; set; }
    public string Name { get; set; }
    public string Species { get; set; }
    public string Description { get; set; }
    public string Size { get; set; }
    public string Diet { get; set; }
    public string UserInfo { get; set; }
    public Tempereament Temperament { get; set; }
}