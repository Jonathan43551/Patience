using UnityEngine;
using System.Collections;
using Zenject;

public class enemySpawner : ITickable {
     
    readonly enemy.Factory _enemyFactory;

    public enemySpawner(enemy.Factory enemyFactory)
    {
        _enemyFactory = enemyFactory;
    }

    public void Tick()
    {
        var enemy = _enemyFactory.Create();
    }
}