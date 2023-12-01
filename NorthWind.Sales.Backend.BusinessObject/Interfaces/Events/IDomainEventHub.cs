using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.Backend.BusinessObjects.Interfaces.Events;
public interface IDomainEventHub<Eventype>
    where Eventype : IDomainEvent
{
    ValueTask Raise(Eventype eventTypeInstance);
}
