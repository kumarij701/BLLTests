using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLTest
{
    internal class TestDbSet<T> : DbSet<T>, IQueryable, IEnumerable<T>
        where T : class
    {
        ObservableCollection<T> _data;
        IQueryable _query;

        public TestDbSet()
        {
            _data = new ObservableCollection<T>();
            _query = _data.AsQueryable();
        }

         public override EntityEntry<T> Add(T item)
       {
         _data.Add(item);
         //var entity = base.Add(item);
            // return entity;
            return null;
       }

     public override EntityEntry<T> Remove(T item)
     {
         _data.Remove(item);
            // var entity = base.Remove(item);
            //return entity;
            return null;
     }

     public override EntityEntry<T> Attach(T item)
     {
         _data.Add(item);
            //var entity = base.Attach(item);
            //return entity;
            return null;
     }

     

   //  public override ObservableCollection<T> Local
     //{
       //  get { return new ObservableCollection<T>(_data); }
     //}

     Type IQueryable.ElementType
     {
         get { return _query.ElementType; }
     }

     System.Linq.Expressions.Expression IQueryable.Expression
     {
         get { return _query.Expression; }
     }

     IQueryProvider IQueryable.Provider
     {
         get { return _query.Provider; }
     }

     public override IEntityType EntityType => throw new NotImplementedException();

     System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
     {
         return _data.GetEnumerator();
     }

     IEnumerator<T> IEnumerable<T>.GetEnumerator()
     {
         return _data.GetEnumerator();
     }
   
}
}
