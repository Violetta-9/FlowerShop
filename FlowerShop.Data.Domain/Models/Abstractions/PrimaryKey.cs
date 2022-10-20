using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.Data.Domain.Models.Abstractions
{
    public interface IIdentifiable<TIdentifierType>
        where TIdentifierType : IComparable
    {
        public TIdentifierType Id { get; set; }
    }
    public abstract class PrimaryKey:IIdentifiable<long>
    {
        public long Id { get; set; }
    }
}
