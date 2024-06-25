class Doce
{
    private string NomeDoce;
    private decimal PrecoDoce;
    private int QuantidadeDoce;

    public Doce(string NomeDoce, decimal PrecoDoce)
    {
        this.NomeDoce = NomeDoce;
        this.PrecoDoce = PrecoDoce;
        QuantidadeDoce = 0;
    }

    public Doce(string NomeDoce, decimal PrecoDoce, int Quantidade)
    {
        this.NomeDoce = NomeDoce;
        this.PrecoDoce = PrecoDoce;
        this.QuantidadeDoce = QuantidadeDoce;
    }
    public string getNomeDoce()
    {
        return NomeDoce;
    }
    public void setNomeDoce(string nd)
    {
        NomeDoce = nd;
    }

    public decimal getPrecoDoce()
    {
        return PrecoDoce;
    }
    public void setPrecoDoce(decimal pd)
    {
        PrecoDoce = pd;
    }

    public int getQuantidadeDoce()
    {
        return QuantidadeDoce;
    }
    public void setQuantidadeDoce(int qd)
    {
        QuantidadeDoce = qd;
    }
}
