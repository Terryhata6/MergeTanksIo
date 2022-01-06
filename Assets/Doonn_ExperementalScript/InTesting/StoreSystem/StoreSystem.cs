using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StoreSystem
{
  private static readonly int _price = 20;
  public static int Price => _price;
  private static readonly int _productCount = 3;
  private static Transaction _transaction;
  static StoreSystem()
  {
    GameEvents.Current.OnSelectPerk += GivePerk;
    Debug.Log("STORE STATIC CONSTRUCTOR");
  }

  public static void SetBuy(Transaction transaction)
  {
    _transaction = transaction;
    if(transaction.WhoBuy == null) return;
    Buy();
  }

  private static void Buy()
  {
    if (_transaction.WhoBuy.TryGetComponent(out PlayerView player))
    {
      Debug.Log("ХОЧЕТ КУПИТЬ ИГРОК ЧЕЛОВЕК РАЗУМНОЕ СУЩЕСТВО УБИТЬ ВСЕХ ЧЕЛОВЕКОВ");
      PlayerBuy();
    }
    else if (_transaction.WhoBuy.TryGetComponent(out EnemyView enemy))
    {
      EnemyBuy();
      Debug.Log("ХОЧЕТ КУПИТЬ БОТТТТТТТТТТТТТТТТТТТТТТТТТ");
    }
  }


  private static void PlayerBuy()
  {
    if (CheckPrice(ref _transaction))
    {
      GameEvents.Current.SetSelectPerks(LoadPerksSystem.GetRandomPerkList(_productCount));
      SubstractCoins(ref _transaction);
      GivePerk(_transaction.Perk);
    }
  }

  private static bool CheckPrice(ref Transaction transaction)
  {
    if (transaction.Value >= _price) return true;
    Debug.Log("НЕХВАТАЕТ БАБОК УЕБОК ВАЛИ ОТСЮДА");
    return false;
  }

  private static void SubstractCoins(ref Transaction transaction)
  {
    transaction.Value -= _price;
  }

  private static void GivePerk(AbstractPerk perk)
  {
    if (perk == null) return;
    _transaction.Perk = perk;
    Debug.Log(perk);
    FinishTransaction();
  }

  private static void EnemyBuy()
  {
    if (CheckPrice(ref _transaction))
    {
      var perk = LoadPerksSystem.GetRandomPerkList(1);
      SubstractCoins(ref _transaction);
      _transaction.Perk = perk[0];
      FinishTransaction();
    }
  }

  public static void FinishTransaction()
  {
    if (_transaction.WhoBuy.TryGetComponent(out ITransaction ownTransaction))
    {
      Debug.Log("КУПИЛ: " + _transaction.WhoBuy);
      ownTransaction.CompleteTransaction(_transaction);
    }
  }
}