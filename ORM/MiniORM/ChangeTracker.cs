using System;
using System.Collections.Generic;
using System.Linq;

namespace MiniORM
{
    // TODO: Create your ChangeTracker class here.

    internal class ChangeTracker<T>
        where T : class, new()
    {

        public ChangeTracker(IEnumerable<T> entities)
        {
            allEntities = CloneEntities(entities);
            added = new List<T>();
            removed = new List<T>();
        }


        private readonly List<T> allEntities;

        private readonly List<T> added;

        private readonly List<T> removed;

        public IReadOnlyCollection<T> Allentities => this.allEntities;
        public IReadOnlyCollection<T> Added => this.added;
        public  IReadOnlyCollection<T> Removed => this.removed;


        private static List<T> CloneEntities(IEnumerable<T> entities)
        {
            var clonedEntity = new List<T>();

            var clonedProperty = typeof(T).GetProperties()
                .Where(pi => DbContext.AllowedSqlTypes.Contains(pi.PropertyType)).ToArray();

            foreach (var entity in entities)
            {
                var clonedEntiti = Activator.CreateInstance<T>();

                foreach (var clonepro in clonedProperty)
                {
                    var value = clonepro.GetValue(entity);
                    clonepro.SetValue(clonedEntity, value);
                }
                clonedEntity.Add(clonedEntiti);
            }
            return clonedEntity;
        }

    }
}