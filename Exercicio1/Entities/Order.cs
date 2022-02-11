using System;
using Exercicio1.Entities.Enums;

namespace Exercicio1.Entities
{
    class Order
    {
        public int ID { get; set; }
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }

        public override string ToString()
        {
            return $"{ID}, {Moment}, {Status}";
        }
    }
}
