using System;
using System.Collections.Generic;
using System.IO;

class Pedido
{
    private Cliente Cliente;
    private List<Doce> Doces;
    private List<Bebida> Bebidas;
    private List<Salgado> Salgados;
    public decimal Total;
    private string MetodoPagamento;

    // Construtor
    public Pedido(Cliente cliente, List<Doce> doces, List<Bebida> bebidas, List<Salgado> salgados)
    {
        this.Cliente = cliente;
        this.Doces = doces ?? new List<Doce>();
        this.Bebidas = bebidas ?? new List<Bebida>();
        this.Salgados = salgados ?? new List<Salgado>();
    }

    // Métodos get e set para Cliente
    public Cliente GetCliente()
    {
        return Cliente;
    }

    public void SetCliente(Cliente cliente)
    {
        Cliente = cliente;
    }

    // Métodos get e set para Doces
    public List<Doce> GetDoces()
    {
        return Doces;
    }

    public void AddDoce(Doce doce)
    {
        Doces.Add(doce);
    }

    // Métodos get e set para Bebidas
    public List<Bebida> GetBebidas()
    {
        return Bebidas;
    }

    public void AddBebida(Bebida bebida)
    {
        Bebidas.Add(bebida);
    }

    // Métodos get e set para Salgados
    public List<Salgado> GetSalgados()
    {
        return Salgados;
    }

    public void AddSalgado(Salgado salgado)
    {
        Salgados.Add(salgado);
    }

    // Métodos get e set para MetodoPagamento
    public string GetMetodoPagamento()
    {
        return MetodoPagamento;
    }

    public void SetMetodoPagamento(string metodoPagamento)
    {
        MetodoPagamento = metodoPagamento;
    }

    // Método para calcular o total do pedido
    public void CalcularTotal()
    {
        Total = 0;
        foreach (var doce in Doces)
        {
            Total += doce.getPrecoDoce() * doce.getQuantidadeDoce();
        }
        foreach (var bebida in Bebidas)
        {
            Total += bebida.getPrecoBebida() * bebida.getQuantidadeBebida();
        }
        foreach (var salgado in Salgados)
        {
            Total += salgado.getPrecoSalgado() * salgado.getQuantidadeSalgado();
        }
    }
    public static void SalvarPedido(Pedido pedido)
    {
        // Abre o arquivo para gravação
        using (StreamWriter writer = new StreamWriter("pedidos.txt", true))
        {
            // Escreve os dados do cliente
            writer.WriteLine("Cliente: {0}", pedido.Cliente.getNome());

            // Escreve os dados dos doces
            writer.WriteLine("Doces:");
            foreach (var doce in pedido.Doces)
            {
                writer.WriteLine("{0}, R$ {1}, {2}", doce.getNomeDoce(), doce.getPrecoDoce(), doce.getQuantidadeDoce());
            }

            // Escreve os dados das bebidas
            writer.WriteLine("Bebidas:");
            foreach (var bebida in pedido.Bebidas)
            {
                writer.WriteLine("{0}, R$ {1}, {2}", bebida.getNomeBebida(), bebida.getPrecoBebida(), bebida.getQuantidadeBebida());
            }

            // Escreve os dados dos salgados
            writer.WriteLine("Salgados:");
            foreach (var salgado in pedido.Salgados)
            {
                writer.WriteLine("{0}, R$ {1}, {2}", salgado.getNomeSalgado(), salgado.getPrecoSalgado(), salgado.getQuantidadeSalgado());
            }

            // Escreve o total e o método de pagamento
            writer.WriteLine("Total: R$ {0}", pedido.Total);
            writer.WriteLine("Método de Pagamento: {0}", pedido.MetodoPagamento);
            writer.WriteLine("===================================");
        }
    }

    public static List<Pedido> LerPedidos()
    {
        var pedidos = new List<Pedido>();

        using (StreamReader reader = new StreamReader("pedidos.txt"))
        {
            Pedido pedidoAtual = null;
            Cliente clienteAtual = null;
            List<Doce> doces = null;
            List<Bebida> bebidas = null;
            List<Salgado> salgados = null;

            bool lendoDoces = false;
            bool lendoBebidas = false;
            bool lendoSalgados = false;

            string linha;
            while ((linha = reader.ReadLine()) != null)
            {
                if (linha.StartsWith("Cliente: "))
                {
                    if (pedidoAtual != null)
                    {
                        // Adicionar o pedido atual à lista de pedidos
                        pedidos.Add(pedidoAtual);
                    }

                    // Criar novo cliente e pedido
                    string nomeCliente = linha.Substring(9);
                    clienteAtual = new Cliente(nomeCliente);
                    doces = new List<Doce>();
                    bebidas = new List<Bebida>();
                    salgados = new List<Salgado>();
                    pedidoAtual = new Pedido(clienteAtual, doces, bebidas, salgados);

                    // Resetar as flags de leitura ao iniciar um novo cliente
                    lendoDoces = false;
                    lendoBebidas = false;
                    lendoSalgados = false;
                }
                else if (linha.StartsWith("Doces:"))
                {
                    lendoDoces = true;
                    lendoBebidas = false;
                    lendoSalgados = false;
                }
                else if (linha.StartsWith("Bebidas:"))
                {
                    lendoDoces = false;
                    lendoBebidas = true;
                    lendoSalgados = false;
                }
                else if (linha.StartsWith("Salgados:"))
                {
                    lendoDoces = false;
                    lendoBebidas = false;
                    lendoSalgados = true;
                }
                else if (linha.StartsWith("Total: "))
                {
                    pedidoAtual.Total = decimal.Parse(linha.Substring(7).Replace("R$ ", ""));
                }
                else if (linha.StartsWith("Método de Pagamento: "))
                {
                    pedidoAtual.SetMetodoPagamento(linha.Substring(21));
                }
                else
                {
                    // Processar itens dependendo do contexto (Doces, Bebidas, Salgados)
                    if (lendoDoces)
                    {
                        // Exemplo: "Cupcake 🧁, R$ 5, 4"
                        string[] partes = linha.Split(',');
                        if (partes.Length >= 3)
                        {
                            string nomeDoce = partes[0].Trim();
                            decimal precoDoce = decimal.Parse(partes[1].Substring(4).Trim());
                            int quantidade = int.Parse(partes[2].Trim());
                            Doce doce = new Doce(nomeDoce, precoDoce);
                            for (int i = 0; i < quantidade; i++)
                            {
                                doces.Add(doce);
                            }
                        }
                    }
                    else if (lendoBebidas)
                    {
                        // Exemplo: "Capuccino 🧋, R$ 7, 2"
                        string[] partes = linha.Split(',');
                        if (partes.Length >= 3)
                        {
                            string nomeBebida = partes[0].Trim();
                            decimal precoBebida = decimal.Parse(partes[1].Substring(4).Trim());
                            int quantidade = int.Parse(partes[2].Trim());
                            Bebida bebida = new Bebida(nomeBebida, precoBebida);
                            for (int i = 0; i < quantidade; i++)
                            {
                                bebidas.Add(bebida);
                            }
                        }
                    }
                    else if (lendoSalgados)
                    {
                        // Exemplo: "Coxinha, R$ 3, 5"
                        string[] partes = linha.Split(',');
                        if (partes.Length >= 3)
                        {
                            string nomeSalgado = partes[0].Trim();
                            decimal precoSalgado = decimal.Parse(partes[1].Substring(4).Trim());
                            int quantidade = int.Parse(partes[2].Trim());
                            Salgado salgado = new Salgado(nomeSalgado, precoSalgado);
                            for (int i = 0; i < quantidade; i++)
                            {
                                salgados.Add(salgado);
                            }
                        }
                    }
                }
            }

            // Adicionar o último pedido após o término do arquivo
            if (pedidoAtual != null)
            {
                pedidos.Add(pedidoAtual);
            }
        }

        return pedidos; // Retornar a lista de pedidos lidos do arquivo
    }

}
