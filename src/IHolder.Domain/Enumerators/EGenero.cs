using System.ComponentModel;

namespace IHolder.Domain.Enumerators
{
    [DefaultValue(Feminino)]
    public enum EGenero : ushort
    {
        Feminino = 1,
        Masculino = 2,
        Outro = 3
    }
}
