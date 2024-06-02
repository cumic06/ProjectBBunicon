using System;
using UnityEngine;

public enum ExpType
{
    LowExp,
    MiddleExp,
    HighExp
}

public class LevelStat
{

}


public class LevelSystem : MonoSingleton<LevelSystem>
{
    #region veriable
    private const float levelUpValue = 1.4f;
    [SerializeField] private float maxExp;
    [SerializeField] private float currentExp;
    [SerializeField] private int level;
    [SerializeField] private GameObject[] expPrefab;
    public Action<float, float> OnChangeExp;
    public Action OnChangeLevel;

    [SerializeField] private LevelUpStatData levelUpStatData;
    public LevelUpStatData UmJunSik => levelUpStatData;
    #endregion

    public void AddExp(int value)
    {
        currentExp += value;
        OnChangeExp?.Invoke(GetCurrentExp(), GetMaxExp());
        int levelUpCount = (int)(currentExp / maxExp);
        for (int i = 0; i < levelUpCount; i++)
        {
            if (currentExp >= maxExp)
            {
                currentExp -= maxExp;
                LevelUp(1);
            }
        }
    }

    private void LevelUp(int value)
    {
        level += value;
        maxExp *= levelUpValue;
        OnChangeExp?.Invoke(GetCurrentExp(), GetMaxExp());
        OnChangeLevel?.Invoke();
    }

    public float GetCurrentExp()
    {
        return currentExp;
    }

    public float GetMaxExp()
    {
        return maxExp;
    }

    public void SpawnExp(Vector2 pos, ExpType expType)
    {
        Vector2 spawnPos = pos * UnityEngine.Random.insideUnitCircle;
#if UNITY_EDITOR
        Debug.Log("SpawnExp");
#endif
        switch (expType)
        {
            case ExpType.LowExp:
                Instantiate(expPrefab[0], spawnPos, Quaternion.identity);
                break;
            case ExpType.MiddleExp:
                Instantiate(expPrefab[1], spawnPos, Quaternion.identity);
                break;
            case ExpType.HighExp:
                Instantiate(expPrefab[2], spawnPos, Quaternion.identity);
                break;
        }
    }
}