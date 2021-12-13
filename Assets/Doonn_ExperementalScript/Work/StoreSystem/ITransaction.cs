using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITransaction 
{
   public void CompleteTransaction(Transaction transaction);
}
