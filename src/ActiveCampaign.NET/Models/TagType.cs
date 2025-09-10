using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace ActiveCampaign
{
    [JsonConverter(typeof(TagTypeJsonConverter))]
    public readonly struct TagType : IEquatable<TagType>, IEquatable<string>
    {
        private readonly string _value;

        public static readonly TagType Contact = new("contact");

        public static readonly TagType Template = new("template");

        private TagType(string value)
        {
            _value = value;
        }

        public bool Equals(string? other)
        {
            return _value.Equals(other);
        }

        public bool Equals(TagType other)
        {
            return Equals(other._value);
        }

        public override bool Equals(object? obj)
        {
            if (obj is TagType other)
            {
                return Equals(other);
            }
            else if (obj is string stringValue)
            {
                return Equals(stringValue);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static bool operator ==(TagType left, TagType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(TagType left, TagType right)
        {
            return !(left == right);
        }

        public static implicit operator string(TagType instance)
        {
            return instance._value;
        }

        public static TagType Parse([NotNull] string? value)
        {
            return value switch
            {
                "contact" => Contact,
                "template" => Template,
                _ => throw new ArgumentException($"Invalid value for TagType: {value}")
            };
        }
    }
}
