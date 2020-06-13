using System.ComponentModel;

namespace IHolder.Domain.Enumerators
{
    [DefaultValue(Regular)]
    public enum ESituacao : ushort
    {
        Regular = 1,
        Oportunidade = 2,
        Quarentena = 3
    }
}
