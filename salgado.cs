class Salgado
{
    private string NomeSalgado;
    private decimal PrecoSalgado;
    private int QuantidadeSalgado;

    public Salgado(string NomeSalgado, decimal PrecoSalgado)
    {
        this.NomeSalgado = NomeSalgado;
        this.PrecoSalgado = PrecoSalgado;
        QuantidadeSalgado = 0;
    }

    public Salgado(string NomeSalgado, decimal PrecoSalgado, int QuantidadeSalgado)
    {
        this.NomeSalgado = NomeSalgado;
        this.PrecoSalgado = PrecoSalgado;
        this.QuantidadeSalgado = QuantidadeSalgado;
    }
    public string getNomeSalgado()
    {
        return NomeSalgado;
    }
    public void setNomeSalgado(string ns)
    {
        NomeSalgado = ns;
    }

    public decimal getPrecoSalgado()
    {
        return PrecoSalgado;
    }
    public void setPrecoSalgado(decimal ps)
    {
        PrecoSalgado = ps;
    }

    public int getQuantidadeSalgado()
    {
        return QuantidadeSalgado;
    }
    public void setQuantidadeSalgado(int qs)
    {
        QuantidadeSalgado = qs;
    }

}
