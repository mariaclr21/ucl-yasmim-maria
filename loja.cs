
class Loja
{
    private List<Doce> estoqueDoces = new List<Doce>();
    private List<Bebida> estoqueBebidas = new List<Bebida>();
    private List<Salgado> estoqueSalgados = new List<Salgado>();
    public int quantidade;

    public Loja()
    {
        // Inicialize o estoque com alguns doces
        estoqueDoces.Add(new Doce("Croissant 🥐", 8));
        estoqueDoces.Add(new Doce("Donut 🍩", 5));
        estoqueDoces.Add(new Doce("Cupcake 🧁", 5));
        estoqueDoces.Add(new Doce("Bolo (fatia) 🍰", 10));
        estoqueDoces.Add(new Doce("Tortas 🥧", 10));
        estoqueDoces.Add(new Doce("Pudim 🍮", 6));
    
        // Inicialize o estoque com algumas bebidas
        estoqueBebidas.Add(new Bebida("Água Mineral 🫗", 3));
        estoqueBebidas.Add(new Bebida("Refrigerante 🥤", 5));
        estoqueBebidas.Add(new Bebida("Sucos 🧃", 5));
        estoqueBebidas.Add(new Bebida("Café ☕", 3));
        estoqueBebidas.Add(new Bebida("Capuccino 🧋", 7));
        estoqueBebidas.Add(new Bebida("Soda Italiana 🍹", 10));

        // Inicialize o estoque com alguns salgados
        estoqueSalgados.Add(new Salgado("Coxinha 🌰", 6));
        estoqueSalgados.Add(new Salgado("Pão de Queijo 🫓", 4));
        estoqueSalgados.Add(new Salgado("Empada 🥟", 5));

    }

    public void ExibirDoces()
    {
        Console.WriteLine("Doces Disponíveis:");
        for (int i = 0; i < estoqueDoces.Count; i++)
        {
            var doce = estoqueDoces[i];
            Console.WriteLine($"{i + 1}. {doce.getNomeDoce()} - R$ {doce.getPrecoDoce()}");
            // Utilize getNomeDoce() e getPrecoDoce() conforme definido na classe Doce
        }
    }

    public void ExibirBebidas()
    {
        Console.WriteLine("Bebidas Disponíveis:");
        for (int i = 0; i < estoqueBebidas.Count; i++)
        {
            var bebida = estoqueBebidas[i];
            Console.WriteLine($"{i + 1}. {bebida.getNomeBebida()} - R$ {bebida.getPrecoBebida()}");
            // Utilize getNomeBebida() e getPrecoBebida() conforme definido na classe Bebida
        }
    }

    public void ExibirSalgados()
    {
        Console.WriteLine("Salgados Disponíveis:");
        for (int i = 0; i < estoqueSalgados.Count; i++)
        {
            var salgado = estoqueSalgados[i];
            Console.WriteLine($"{i + 1}. {salgado.getNomeSalgado()} - R$ {salgado.getPrecoSalgado()}");
            // Utilize getNomeSalgado() e getPrecoSalgado() conforme definido na classe Salgado
        }
    }

    public Pedido CriarPedido(Cliente cliente)
    {
        var pedido = new Pedido(cliente, doces: null, bebidas: null, salgados: null);
        return pedido;
    }

    public void AdicionarDocePedido(Pedido pedido, int indiceDoce, int quantidade)
    {
        if (indiceDoce >= 0 && indiceDoce < estoqueDoces.Count)
        {
            var doce = new Doce(
                NomeDoce: estoqueDoces[indiceDoce].getNomeDoce(),
                PrecoDoce: estoqueDoces[indiceDoce].getPrecoDoce()
            );
            doce.setQuantidadeDoce(quantidade);
            pedido.AddDoce(doce);
        }
    }


    public void AdicionarBebidaPedido(Pedido pedido, int indiceBebida, int quantidade)
    {
        if (indiceBebida >= 0 && indiceBebida < estoqueBebidas.Count)
        {
            var bebida = new Bebida(
                NomeBebida: estoqueBebidas[indiceBebida].getNomeBebida(),
                PrecoBebida: estoqueBebidas[indiceBebida].getPrecoBebida()
            );
            bebida.setQuantidadeBebida(quantidade);
            pedido.AddBebida(bebida);
        }
    }


    public void AdicionarSalgadoPedido(Pedido pedido, int indiceSalgado, int quantidade)
    {
        if (indiceSalgado >= 0 && indiceSalgado < estoqueSalgados.Count)
        {
            var salgado = new Salgado
            (
                NomeSalgado: estoqueSalgados[indiceSalgado].getNomeSalgado(),
                PrecoSalgado: estoqueSalgados[indiceSalgado].getPrecoSalgado()
            );
            salgado.setQuantidadeSalgado(quantidade);
            pedido.AddSalgado(salgado);
        }
    }
}
