using System;
using System.Collections.Generic;

namespace AgendaContatos
{
    public class Contatos
    {
        private List<Contato> agenda;

        public Contatos()
        {
            agenda = new List<Contato>();
        }

        public bool adicionar(Contato c)
        {
            if (!agenda.Contains(c))
            {
                agenda.Add(c);
                return true;
            }
            return false;
        }

        public Contato pesquisar(Contato c)
        {
            foreach (var contato in agenda)
            {
                if (contato.Equals(c))
                    return contato;
            }
            return null;
        }

        public bool alterar(Contato c)
        {
            for (int i = 0; i < agenda.Count; i++)
            {
                if (agenda[i].Equals(c))
                {
                    agenda[i] = c;
                    return true;
                }
            }
            return false;
        }

        public bool remover(Contato c)
        {
            return agenda.Remove(c);
        }

        public void listar()
        {
            foreach (var contato in agenda)
            {
                Console.WriteLine("--------------------------");
                Console.WriteLine(contato);
            }
        }
    }
}
