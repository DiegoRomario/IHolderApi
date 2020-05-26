using System.ComponentModel;

namespace IHolder.Domain.Enumerators
{
    [DefaultValue(Hold)]
    public enum EOrientacao : ushort
    {
        Hold = 1,
        Buy = 2,
        Sell = 3
    }
}
