using UnityEngine;
using System.Collections;
using Zenject;

public class enemy {

    readonly player _player;

    public enemy(player player)
    {
        _player = player;
    }

    public class Factory : Factory<enemy>
    {
    }
}
