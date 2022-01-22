using System.ComponentModel;

namespace Business.Enums
{
    public enum TipoTransacaoEnum
    {
        [Description("+")]
        Debito = 1,
        [Description("-")]
        Boleto = 2,
        [Description("-")]
        Financiamento = 3,
        [Description("-")]
        Credito = 4,
        [Description("+")]
        RecebimentoEmprestimo = 5,
        [Description("+")]
        Vendas = 6,
        [Description("+")]
        RecebimentoTED = 7,
        [Description("+")]
        RecebimentoDOC = 8,
        [Description("-")]
        Aluguel = 9
    }
}
