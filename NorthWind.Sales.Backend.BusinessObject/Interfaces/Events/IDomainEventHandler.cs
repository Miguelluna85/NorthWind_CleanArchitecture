using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.Backend.BusinessObjects.Interfaces.Events;
public interface IDomainEventHandler<EventType>
    where EventType : IDomainEvent
{
    ValueTask Handle(EventType eventTypeInstance);
    
}
