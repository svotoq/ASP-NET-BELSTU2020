using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactLibSQL
{
    public interface IContactContext<T> where T : class
    {
        List<T> GetConList();
        T GetContact(int? id);
        void Add(T item);
        void Update(T item);
        void Delete(int? id);
    }
}
