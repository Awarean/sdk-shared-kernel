using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Awaren.Sdk.SharedKernel
{
    public interface IEntity
    {
    }

    public interface IEntity<out TKey> : IEntity
    {
        TKey Id { get; }
    }
}