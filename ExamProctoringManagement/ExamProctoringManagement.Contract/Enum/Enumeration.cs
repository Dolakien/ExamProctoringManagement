using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Contract.Enum;

public class Enumeration<TEnum> : IEquatable<Enumeration<TEnum>>
    where TEnum : Enumeration<TEnum>
{
    private static readonly Dictionary<int, TEnum> Enumerations = GenerateEnumerations();

    public int Value { get; protected init; }
    public string Name { get; protected init; }

    protected Enumeration(int value, string name)
    {
        Value = value;
        Name = name;
    }
    public static TEnum FromValue(int value)
    {
        return Enumerations
            .TryGetValue(value, out TEnum enumeration)
            ? enumeration
            : default;
    }
    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public override string ToString()
    {
        return Name;
    }
    public static TEnum FromName(string name)
    {
        return Enumerations.Values.SingleOrDefault(x => x.Name == name);
    }

    public bool Equals(Enumeration<TEnum> other)
    {
        if (other is null)
        {
            return false;
        }

        return GetType() == other.GetType() && Value == other.Value;
    }

    public override bool Equals(object obj)
    {
        return obj is Enumeration<TEnum> other && Equals(other);
    }

    private static Dictionary<int, TEnum> GenerateEnumerations()
    {
        var enumerationType = typeof(TEnum);
        var fieldsForType = enumerationType
            .GetFields(
                BindingFlags.Public |
                BindingFlags.Static |
                BindingFlags.FlattenHierarchy)
            .Where(fieldInfo => enumerationType.IsAssignableFrom(fieldInfo.FieldType))
            .Select(x => (TEnum)x.GetValue(default)!);
        return fieldsForType.ToDictionary(x => x.Value);
    }
}


