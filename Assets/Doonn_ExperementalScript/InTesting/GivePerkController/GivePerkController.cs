using System.Collections.Generic;
using UnityEngine;
public class GivePerkController : BaseController
{
    private static readonly int _giveCountPerk = 3;

    public override void Initialize()
    {
        base.Initialize();
        GameEvents.Current.OnLevelUp += WhoWantsToGetPerk; //<< Нету Отписки << Незабыть Проверить
    }

    private void WhoWantsToGetPerk(GameObject ownObject)
    {
        if (ownObject.TryGetComponent(out PlayerView playerView))
        {
            Debug.Log("Player: Хочет Получить Перк");
            for (int i = 0; i < 2; i++)
            {
                CheckPlayerPerk(playerView.PerkManager);
            }
        }
        else if (ownObject.TryGetComponent(out EnemyView enemyView))
        {
            Debug.Log("Enemy: Хочет Получить Перк, Убить Всех Человеков");
            CheckEnemyPerk(enemyView.PerkManager, enemyView);
        }
    }

    private void CheckPlayerPerk(PerkManager perks)
    {
        int perksCount = perks.OwnPlayerPerkList.Count +
            perks.OwnProjectileModList.Count +
            perks.OwnShooterPerkList.Count;
        Debug.Log("Pergk Count: " + perksCount);

        if (perksCount <= 0)
        {
            GameEvents.Current.SetSelectPerks(LoadPerksSystem.GetRandomPerkList(_giveCountPerk));
        }
        else
        {
            List<List<AbstractPerk>> concatList = new List<List<AbstractPerk>>();

            concatList.Add(perks.OwnPlayerPerkList); // Хард Код >> Потом Допилить << Костыли
            concatList.Add(perks.OwnProjectileModList); // Хард Код >> Потом Допилить << Костыли
            concatList.Add(perks.OwnShooterPerkList); // Хард Код >> Потом Допилить << Костыли

            AbstractPerk[] checkPerks = new AbstractPerk[perksCount];
            for (int i = 0; i < concatList.Count; i++)
            {
                var ls = concatList[i];
                for (int t = 0; t < ls.Count; t++)
                {
                    if (ls[t] == null) continue;

                    checkPerks[t] = ls[t];
                }
            }
            var getPerks = LoadPerksSystem.GetRandomPerkList(_giveCountPerk);
            if (getPerks.Count <= 0) return;
            GameEvents.Current.SetSelectPerks(getPerks);
        }
    }

    // Копипаст CheckPlayerPerk минимальные отличия << // TODO Унифицировать
    private void CheckEnemyPerk(PerkManager perks, EnemyView enemy)
    {
        int perksCount = perks.OwnPlayerPerkList.Count +
            perks.OwnProjectileModList.Count +
            perks.OwnShooterPerkList.Count;
        Debug.Log("Pergk Count: " + perksCount);

        if (perksCount <= 0)
        {
            var getEnemyPerk = LoadPerksSystem.GetRandomPerkList(1);
            enemy.GivePerk(getEnemyPerk[0]);
        }
        else
        {
            List<List<AbstractPerk>> concatList = new List<List<AbstractPerk>>();

            concatList.Add(perks.OwnPlayerPerkList); // Хард Код >> Потом Допилить << Костыли
            concatList.Add(perks.OwnProjectileModList); // Хард Код >> Потом Допилить << Костыли
            concatList.Add(perks.OwnShooterPerkList); // Хард Код >> Потом Допилить << Костыли

            AbstractPerk[] checkPerks = new AbstractPerk[perksCount];
            for (int i = 0; i < concatList.Count; i++)
            {
                var ls = concatList[i];
                for (int t = 0; t < ls.Count; t++)
                {
                    if (ls[t] == null) continue;

                    checkPerks[t] = ls[t];
                }
            }
            var getEnemyPerk = LoadPerksSystem.GetRandomPerkList(_giveCountPerk);
            if (getEnemyPerk.Count <= 0) return;
            enemy.GivePerk(getEnemyPerk[0]);
        }
    }
}