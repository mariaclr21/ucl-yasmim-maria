class Cliente
{
    private string Nome;

    public Cliente(string Nome)
    {
        this.Nome = Nome;
    }

    public string getNome()
    {
        return Nome;
    }
    public void setnome(string n)
    {
        Nome = n.ToUpper();
    }

}
