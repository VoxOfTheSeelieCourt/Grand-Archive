using System;
using System.ComponentModel.DataAnnotations;

namespace GrandArchive.Helpers.Attributes;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
public class ConditionalRequiredAttribute : ValidationAttribute
{
    public string DependentProperty { get; }
    public object DependentValue { get; }
    public bool RequiredWhenEqual { get; }

    public ConditionalRequiredAttribute(string dependentProperty, object dependentValue, bool requiredWhenEqual = true)
    {
        DependentProperty = dependentProperty;
        DependentValue = dependentValue;
        RequiredWhenEqual = requiredWhenEqual;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var instance = validationContext.ObjectInstance;
        var dependantPropertyInfo = instance.GetType().GetProperty(DependentProperty);

        if (dependantPropertyInfo == null)
            return new ValidationResult($"Unknown property {DependentProperty}.");

        var dependantValue = dependantPropertyInfo.GetValue(instance);

        var isConditionMet = DependentValue == null
            ? dependantValue == null
            : dependantValue?.Equals(DependentValue) ?? false;

        var shouldBeRequired = RequiredWhenEqual ? isConditionMet : !isConditionMet;

        if (shouldBeRequired)
        {
            if (value == null || (value is string str && string.IsNullOrWhiteSpace(str)))
                return new ValidationResult(ErrorMessage ?? $"{validationContext.DisplayName} is required.",
                    [validationContext.MemberName]);
        }
        else
        {
            if (value != null && !(value is string str && string.IsNullOrWhiteSpace(str)))
                return new ValidationResult(ErrorMessage ?? $"{validationContext.DisplayName} must be empty.",
                    [validationContext.MemberName]);
        }

        return ValidationResult.Success;
    }
}