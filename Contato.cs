using System;
using System.Collections.Generic;

namespace AgendaContatos
{
    public class Contato
    {
        private string email;
        private string nome;
        private Data dtNasc;
        private List<Telefone> telefones;

        public Contato(string nome, string email, Data dtNasc)
        {
            this.nome = nome;
            this.email = email;
            this.dtNasc = dtNasc;
            telefones = new List<Telefone>();
        }

        public void adicionarTelefone(Telefone t)
        {
            telefones.Add(t);
        }

        public string getTelefonePrincipal()
        {
            foreach (var tel in telefones)
            {
                if (tel.IsPrincipal()) return tel.GetNumero();
            }
            return "Nenhum telefone principal cadastrado.";
        }

        public int getIdade()
        {
            int anoAtual = DateTime.Now.Year;
            return anoAtual - dtNasc.getAno();
        }

        public override string ToString()
        {
            string infoTel = "";
            foreach (var tel in telefones)
            {
                infoTel += "\n   " + tel.ToString();
            }

            return $"Nome: {nome}\nEmail: {email}\nNascimento: {dtNasc}\nIdade: {getIdade()} anos\nTelefones:{infoTel}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Contato c)
            {
                return this.email == c.email;
            }
            return false;
        }
    }
}
