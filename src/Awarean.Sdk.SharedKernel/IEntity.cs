using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Awarean.Sdk.SharedKernel;

namespace Awaren.Sdk.SharedKernel
{
    public interface IEntity
    {
    }

    public interface IEntity<out TKey> : IEntity
    {
        TKey Id { get; }

        event EntityUpdated OnUpdate;
    }
}