namespace EcommerceCheckout.App;

/// <summary>
/// Regras de negócio do checkout da loja online: código de rastreio,
/// pontos de fidelidade e elegibilidade a frete grátis.
/// </summary>
public class PedidoService
{
    private const int ValorParaGanharPontos = 10;
    private const int PontosPorFaixa = 2;
    private const int ValorMinimoFreteGratis = 200;

    /// <summary>
    /// Gera o código de rastreio: região em maiúsculas + número do pedido
    /// com 4 dígitos (zeros à esquerda). Ex.: ("sudeste", 42) => "SUDESTE-0042".
    /// </summary>
    public string GerarCodigoRastreio(string regiao, int numeroPedido)
    {
        return $"{regiao.ToUpperInvariant()}-{numeroPedido:D4}";
    }

    /// <summary>
    /// A cada R$ 10 em compras o cliente ganha 2 pontos.
    /// Ex.: 150 => (150 / 10) * 2 = 30.
    /// </summary>
    public int CalcularPontosFidelidade(int valorTotal)
    {
        return (valorTotal / ValorParaGanharPontos) * PontosPorFaixa;
    }

    /// <summary>
    /// Frete grátis se o valor total for maior ou igual a R$ 200 OU se o
    /// comprador for cliente VIP.
    /// </summary>
    public bool TemDireitoAFreteGratis(int valorTotal, bool eClienteVIP)
    {
        return valorTotal >= ValorMinimoFreteGratis || eClienteVIP;
    }
}
