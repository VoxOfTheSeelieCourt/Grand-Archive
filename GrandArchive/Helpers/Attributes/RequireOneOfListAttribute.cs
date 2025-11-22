using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace GrandArchive.Helpers.Attributes;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
public class RequireOneOfListAttribute : ValidationAttribute
{
    public string GroupName { get; }
    public string[] PropertyNames  { get; }

    public RequireOneOfListAttribute(string groupName, params string[] propertyNames)
    {
        if (propertyNames == null || propertyNames.Length == 0)
            throw new ArgumentException($"At least one property must be specified.", nameof(propertyNames));

        GroupName = groupName;
        PropertyNames = propertyNames;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var instance = validationContext.ObjectInstance;
        var instanceType = instance.GetType();

        bool anyHasValue = false;

        foreach (var propertyName in PropertyNames)
        {
            var property = instanceType.GetProperty(propertyName);

            if (property == null)
                return new ValidationResult($"Unknown property {propertyName}.");

            var propertyValue = property.GetValue(instance);

            if (HasValue(propertyValue))
            {
                anyHasValue = true;
                break;
            }
        }

        if (!anyHasValue)
        {
            var propertyList = string.Join(", ", PropertyNames);
            return new ValidationResult(ErrorMessage ?? $"At least one of the following properties must be set: {propertyList}.",
                PropertyNames);
        }

        return ValidationResult.Success;
    }

    private bool HasValue(object value)
    {
        return value switch
        {
            null => false,
            string str => !string.IsNullOrWhiteSpace(str),
            IEnumerable enumerable => enumerable.Cast<object>().Any(),
            _ => true
        };
    }
}