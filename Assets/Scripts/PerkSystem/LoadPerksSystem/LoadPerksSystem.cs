using System.Collections.Generic;
using UnityEngine;

public static class LoadPerksSystem
{
    public static readonly string PathPerk = "ScriptablePerks/";
    public static readonly AbstractPerk[] AllPerks;

    static LoadPerksSystem()
    {
        AllPerks = Resources.LoadAll<AbstractPerk>(PathPerk);

        Debug.Log("Статический Конструктор: LoadSystem");
    }

    public static AbstractPerk GetOnePerkByName(string name)
    {
        var perk = Resources.Load<AbstractPerk>(PathPerk + name);
        return perk;
    }

    public static AbstractPerk[] GetAllPerk()
    {
        return AllPerks;
    }

    //<< UI
    public static List<AbstractPerk> GetRandomPerkList(int returnCountPerk)
    {
        List<AbstractPerk> perks = new List<AbstractPerk>();

        for (int i = 0; i < returnCountPerk; i++)
        {
            int randomIndex = Random.Range(0, AllPerks.Length - 1);
            var getPerkFromIndex = AllPerks[randomIndex];

            if (!perks.Contains(getPerkFromIndex))
            {
                perks.Add(getPerkFromIndex);
            }
            else
            {
                i--;
            }
        }
        return perks;
    }

    public static List<AbstractPerk> GetRandomPerkList(AbstractPerk[] perks, int returnCountPerk)
    {
        List<AbstractPerk> maxLevelPerksFreez = new List<AbstractPerk>();
        List<AbstractPerk> returnPerks = new List<AbstractPerk>();
        for (int i = 0; i < perks.Length; i++)
        {
            if (perks[i] == null) continue;
            if (perks[i].PerkData.Level >= perks[i].PerkData.MaxLevel)
            {
                maxLevelPerksFreez.Add(perks[i]);
            }
        }

        for (int i = 0; i < returnCountPerk; i++)
        {
            int countLoop = i;
            int randomIndex = Random.Range(0, AllPerks.Length - 1);
            var getPerkFromIndex = AllPerks[randomIndex];

            if (maxLevelPerksFreez.Find(perk => getPerkFromIndex))
            {
                i--;
                if(countLoop >= AllPerks.Length) break;
            }
            else
            {
                returnPerks.Add(getPerkFromIndex);
            }
        }

        return returnPerks;
    }
}