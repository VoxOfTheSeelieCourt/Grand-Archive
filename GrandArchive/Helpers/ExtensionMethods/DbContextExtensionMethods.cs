using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GrandArchive.Helpers.ExtensionMethods;

public static class DbContextExtensionMethods
{
    public static void UpdateRangeWithNavigations<T>(this DbContext dbContext, IEnumerable<T> entities) where T : class
    {
        var entityList = entities.ToList();

        var navigationEntities = new Dictionary<(Type Type, object Object), object>();

        foreach (var entity in entityList)
        {
            var entry = dbContext.Entry(entity);
            CollectNavigationEntities(entry, navigationEntities);
        }

        foreach (var navEntity in navigationEntities.Values)
        {
            var navEntry = dbContext.Entry(navEntity);
            if (navEntry.State == EntityState.Detached)
                navEntry.State = EntityState.Unchanged;
        }

        dbContext.UpdateRange(entityList);
    }

    public static void UpdateWithNavigations<T>(this DbContext dbContext, T entity) where T : class
    {
        dbContext.UpdateRangeWithNavigations([entity]);
    }

    private static void CollectNavigationEntities(EntityEntry entry, Dictionary<(Type Type, object Object), object> navigationEntities)
    {
        foreach (var navigation in entry.Navigations)
        {
            if (navigation.CurrentValue == null)
                continue;

            if (navigation.Metadata.IsCollection)
            {
                foreach (var item in (IEnumerable)navigation.CurrentValue)
                {
                    var itemEntry = entry.Context.Entry(item);
                    CollectNavigationEntities(itemEntry, navigationEntities);
                }
            }
            else
            {
                var navEntity = navigation.CurrentValue;
                var navEntry = entry.Context.Entry(navEntity);
                var key = navEntry.Metadata.FindPrimaryKey();
                var keyValues = key.Properties.Select(x => x.PropertyInfo.GetValue(navEntity)).ToArray();
                var keyValue = keyValues.Length == 1 ? keyValues[0] : new CompositeKey(keyValues);

                var dictKey = (navEntity.GetType(), keyValue);

                if (navigationEntities.TryAdd(dictKey, navEntity))
                {
                    CollectNavigationEntities(navEntry, navigationEntities);
                }
            }
        }
    }
}

internal class CompositeKey
{
    private readonly object[] _values;

    public CompositeKey(object[] values) => _values = values;

    public override bool Equals(object obj) =>
        obj is CompositeKey other && _values.SequenceEqual(other._values);

    public override int GetHashCode()
    {
        var hash = new HashCode();
        foreach (var value in _values)
            hash.Add(value);
        return hash.ToHashCode();
    }
}