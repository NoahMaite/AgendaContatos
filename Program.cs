using System;

namespace AgendaContatos
{
    class Program
    {
        static void Main(string[] args)
        {
            Contatos agenda = new Contatos();
            int opcao;

            do
            {
                Console.WriteLine("\n--- MENU ---");
                Console.WriteLine("0 - Sair");
                Console.WriteLine("1 - Adicionar contato");
                Console.WriteLine("2 - Pesquisar contato");
                Console.WriteLine("3 - Alterar contato");
                Console.WriteLine("4 - Remover contato");
                Console.WriteLine("5 - Listar contatos");
                Console.Write("Escolha: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.Write("Nome: ");
                        string nome = Console.ReadLine();
                        Console.Write("Email: ");
                        string email = Console.ReadLine();
                        Console.Write("Data de nascimento (dia mes ano): ");
                        string[] partes = Console.ReadLine().Split(' ');
                        Data d = new Data(int.Parse(partes[0]), int.Parse(partes[1]), int.Parse(partes[2]));

                        Contato c = new Contato(nome, email, d);

                        Console.Write("Quantos telefones deseja adicionar? ");
                        int qtd = int.Parse(Console.ReadLine());
                        for (int i = 0; i < qtd; i++)
                        {
                            Console.Write("Tipo: ");
                            string tipo = Console.ReadLine();
                            Console.Write("Número: ");
                            string numero = Console.ReadLine();
                            Console.Write("É principal? (s/n): ");
                            bool principal = Console.ReadLine().ToLower() == "s";
                            c.adicionarTelefone(new Telefone(tipo, numero, principal));
                        }

                        agenda.adicionar(c);
                        break;

                    case 2:
                        Console.Write("Digite o email para pesquisar: ");
                        string emailPesq = Console.ReadLine();
                        Contato pesq = agenda.pesquisar(new Contato("", emailPesq, new Data(1, 1, 2000)));
                        if (pesq != null) Console.WriteLine(pesq);
                        else Console.WriteLine("Contato não encontrado.");
                        break;

                    case 3:
                        Console.Write("Digite o email do contato a alterar: ");
                        string emailAlt = Console.ReadLine();
                        Contato alt = agenda.pesquisar(new Contato("", emailAlt, new Data(1, 1, 2000)));
                        if (alt != null)
                        {
                            Console.Write("Novo nome: ");
                            string novoNome = Console.ReadLine();
                            Console.Write("Nova data de nascimento (dia mes ano): ");
                            string[] p = Console.ReadLine().Split(' ');
                            Data novaData = new Data(int.Parse(p[0]), int.Parse(p[1]), int.Parse(p[2]));
                            Contato novo = new Contato(novoNome, emailAlt, novaData);
                            agenda.alterar(novo);
                            Console.WriteLine("Contato alterado.");
                        }
                        else Console.WriteLine("Contato não encontrado.");
                        break;

                    case 4:
                        Console.Write("Digite o email do contato a remover: ");
                        string emailRem = Console.ReadLine();
                        if (agenda.remover(new Contato("", emailRem, new Data(1, 1, 2000))))
                            Console.WriteLine("Removido com sucesso.");
                        else
                            Console.WriteLine("Contato não encontrado.");
                        break;

                    case 5:
                        agenda.listar();
                        break;
                }
            } while (opcao != 0);
        }
    }
}
