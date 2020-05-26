using System.ComponentModel;

namespace IHolder.Domain.Enumerators
{
    [DefaultValue(Normal)]
    public enum ESituacao : ushort
    {
        Normal = 1,
        Oportunidade = 2,
        Quarentena = 3
    }
}
