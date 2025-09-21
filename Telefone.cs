namespace AgendaContatos
{
    public class Telefone
    {
        private string tipo;
        private string numero;
        private bool principal;

        public Telefone(string tipo, string numero, bool principal)
        {
            this.tipo = tipo;
            this.numero = numero;
            this.principal = principal;
        }

        public bool IsPrincipal()
        {
            return principal;
        }

        public string GetNumero()
        {
            return numero;
        }

        public override string ToString()
        {
            return $"{tipo}: {numero}" + (principal ? " (Principal)" : "");
        }
    }
}
