using System.ComponentModel;

namespace IHolder.Domain.Enumerators
{
    [DefaultValue(Medio)]
    public enum ERisco : ushort
    {
        Baixo = 1,
        MedioBaixo = 2,
        Medio = 3,
        MedioAlto = 4, 
        Alto = 5
    }
}
