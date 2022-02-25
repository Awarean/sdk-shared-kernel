using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Awarean.Sdk.SharedKernel.Delegates;

public delegate bool GetWhereSelector<T>(T entity) where T : IEntity;