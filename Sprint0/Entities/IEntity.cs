using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Entities
{
    public interface IEntity
    {
        IEntity GetParent();
        void SetParent(IEntity entity);
        string GetName();
        void SetName(string value);
    }
}
