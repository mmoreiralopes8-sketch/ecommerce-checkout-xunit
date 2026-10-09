# EcommerceCheckout

Solução .NET 10 que implementa regras de checkout de uma loja online (código de rastreio, pontos de fidelidade e frete grátis), cobertas por testes unitários com xUnit.

Atividade da disciplina **Garantia da Qualidade de Software** (Lista 22).

## Estrutura

```
EcommerceCheckout.slnx
├── EcommerceCheckout.App/      # código de produção (PedidoService)
└── EcommerceCheckout.Tests/    # testes unitários xUnit (PedidoServiceTests)
```

## Métodos criados (`PedidoService`)

| Método | Retorno | Regra |
|--------|---------|-------|
| `GerarCodigoRastreio(string regiao, int numeroPedido)` | `string` | Região em maiúsculas + número do pedido com 4 dígitos. `("sudeste", 42)` → `"SUDESTE-0042"` |
| `CalcularPontosFidelidade(int valorTotal)` | `int` | A cada R$ 10, 2 pontos. `150` → `30` |
| `TemDireitoAFreteGratis(int valorTotal, bool eClienteVIP)` | `bool` | Frete grátis se valor ≥ R$ 200 **ou** cliente VIP |

## Cobertura dos testes (`PedidoServiceTests`)

| Teste | Asserção | Cenário |
|-------|----------|---------|
| `GerarCodigoRastreio_DeveGerarMascaraExata` | `Assert.Equal` | `"sudeste"`, 42 → `"SUDESTE-0042"` |
| `CalcularPontosFidelidade_DeveCalcularPontosCorretamente` | `Assert.Equal` | 150 → 30 pontos |
| `TemDireitoAFreteGratis_ClienteVipAbaixoDe200_DeveRetornarTrue` | `Assert.True` | VIP com R$ 150 |
| `TemDireitoAFreteGratis_ClienteNaoVipAbaixoDe200_DeveRetornarFalse` | `Assert.False` | Não VIP com R$ 150 |

## Como executar

Pré-requisito: [.NET SDK 10](https://dotnet.microsoft.com/download).

```bash
git clone https://github.com/mmoreiralopes8-sketch/ecommerce-checkout-xunit.git
cd ecommerce-checkout-xunit
dotnet test
```

## Licença

Distribuído sob a licença MIT. Veja o arquivo [LICENSE](LICENSE).
