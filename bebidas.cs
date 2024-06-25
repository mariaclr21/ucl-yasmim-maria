class Bebida
{
    private string NomeBebida;
    private decimal PrecoBebida;
    private int QuantidadeBebida;

    public Bebida(string NomeBebida, decimal PrecoBebida)
    {
        this.NomeBebida = NomeBebida;
        this.PrecoBebida = PrecoBebida;
        QuantidadeBebida = 0;
    }

    public Bebida(string NomeBebida, decimal PrecoBebida, int QuantidadeBebida)
    {
        this.NomeBebida = NomeBebida;
        this.PrecoBebida = PrecoBebida;
        this.QuantidadeBebida = QuantidadeBebida;
    }
    public string getNomeBebida()
    {
        return NomeBebida;
    }
    public void setNomeBebida(string nb)
    {
        NomeBebida = nb;
    }

    public decimal getPrecoBebida()
    {
        return PrecoBebida;
    }
    public void setPrecoBebida(decimal pb)
    {
        PrecoBebida = pb;
    }

    public int getQuantidadeBebida()
    {
        return QuantidadeBebida;
    }
    public void setQuantidadeBebida(int qb)
    {
        QuantidadeBebida = qb;
    }

}
