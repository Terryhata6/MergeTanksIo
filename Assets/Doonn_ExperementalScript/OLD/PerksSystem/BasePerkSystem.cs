public class BasePerkSystem : IPerks
{
  protected string _name;
  public string Name => _name;
  protected string _description;
  public string Description => _description;
  public virtual void GetCalculate ()
  {
    
  }
}