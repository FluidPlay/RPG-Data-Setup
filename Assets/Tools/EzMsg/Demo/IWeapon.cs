﻿namespace EzMsgDemo
{
    using System.Collections;
    using UnityEngine.EventSystems;

    public interface IWeapon : IEventSystemHandler
    {
        IEnumerable Reload();
        IEnumerable Fire();
    }
}