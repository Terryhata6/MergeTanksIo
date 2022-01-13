using UnityEngine;
public interface ICommandBuilder : ICommand
{
   
}

public interface ICommand
{
   public void CommandInit();
   public void CommandExecute(ModulTankSO modulTank);
}