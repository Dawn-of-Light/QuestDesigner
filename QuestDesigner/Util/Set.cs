using System;
using System.Collections.Generic;
using System.Text;

namespace DOL.Tools.QuestDesigner.QuestDesigner.Util
{
    public class Set<T> : List<T>
    {

        public Set() : base()
        {
        }

        public Set(int capacity)
            : base(capacity)
        {
        }

        public Set(IEnumerable<T> enumeration)
            : base(enumeration)
        {
        }

        public new void Insert(int index, T item)
        {
            if (!base.Contains(item))
                base.Insert(index, item);
        }

        public new void Add(T item)
        {
            if (!base.Contains(item))
                base.Add( item);
        }

        public new void AddRange(IEnumerable<T> enumeration)
        {
            List<T> newItems = new List<T>();

            foreach (T item in enumeration)
            {
                if (!base.Contains(item))
                    newItems.Add(item);
            }

            base.AddRange(newItems);
        }

        public new void InsertRange(int index, IEnumerable<T> enumeration)
        {
            List<T> newItems = new List<T>();

            foreach (T item in enumeration)
            {
                if (!base.Contains(item))
                    newItems.Add(item);
            }

            base.InsertRange(index, newItems);
        }

    }
}
