using System.Diagnostics.CodeAnalysis;

namespace ActiveCampaign
{
    public readonly struct CustomObjectRecordSource : IEquatable<CustomObjectRecordSource>, IEquatable<string>
    {
        private readonly string _value;

        public static readonly CustomObjectRecordSource Historical = new("HISTORICAL");

        public static readonly CustomObjectRecordSource RealTime = new("REAL_TIME");

        private CustomObjectRecordSource(string value)
        {
            _value = value;
        }

        public readonly bool Equals(string? other)
        {
            return _value == other;
        }

        public readonly bool Equals(CustomObjectRecordSource other)
        {
            return Equals(other._value);
        }

        public override readonly bool Equals([NotNullWhen(true)] object? obj)
        {
            if (obj is CustomObjectRecordSource other)
            {
                return Equals(other);
            }
            else if (obj is string stringValue)
            {
                return Equals(stringValue);
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public override string ToString()
        {
            return _value;
        }

        public static bool operator ==(CustomObjectRecordSource left, CustomObjectRecordSource right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(CustomObjectRecordSource left, CustomObjectRecordSource right)
        {
            return !(left == right);
        }

        public static implicit operator string(CustomObjectRecordSource source)
        {
            return source._value;
        }
    }
}
