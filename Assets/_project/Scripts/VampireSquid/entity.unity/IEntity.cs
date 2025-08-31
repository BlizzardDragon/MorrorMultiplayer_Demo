using System;
using Entity.Core;
using UnityEngine;
using VampireSquid.Common.Connections;

public interface IEntity
{
    int Id { get; }
    NetworkedPresence Presence { get; }
    bool IsInitialized { get; }

    bool        ContainsModule<TDependency>();
    bool        TryGetModule<TDependency>(out TDependency dependency);
    TDependency AddModule<TDependency>(TDependency        dependency);
    TDependency GetModule<TDependency>();


}
