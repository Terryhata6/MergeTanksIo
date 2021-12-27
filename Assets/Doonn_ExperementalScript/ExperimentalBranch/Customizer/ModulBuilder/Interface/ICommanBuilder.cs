using UnityEngine;
public interface ICommandBuilder : ICommand
{
   
}

public interface ICommand
{
   public void CommandExecute();
   public void CommandExecuteDoOnce(int index);
   public void CommandExecuteDoOnce(ModulTankSO modulTank);
}