using ConexaoBancoDados.Utilitarios;
using Cinema_POO.Models;
using ConexaoBancoDados.DAO;

ClienteDAO clienteDAO = new ClienteDAO();
FuncionarioDAO funcionarioDAO = new FuncionarioDAO();
GeneroDAO generoDAO = new GeneroDAO();
FilmeDAO filmeDAO = new FilmeDAO();
SalaDAO salaDAO = new SalaDAO();
SessaoDAO sessaoDAO = new SessaoDAO();

int opc;

do
{
    Console.Clear();
    Console.WriteLine("=== SISTEMA DE CADASTRO CINEMA ===\n");
    Console.WriteLine("1. Cadastrar Cliente");
    Console.WriteLine("2. Cadastrar Funcionário");
    Console.WriteLine("3. Cadastrar Gênero");
    Console.WriteLine("4. Cadastrar Filme");
    Console.WriteLine("5. Cadastrar Sala");
    Console.WriteLine("6. Cadastrar Sessão");
    Console.WriteLine("0. Sair do programa");
    Console.WriteLine("");
    Console.Write("Escolha sua opção: ");
    opc = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine();

    if (opc == 1)
    {
        Cliente c = new Cliente();
        Console.Write("Nome: ");
        c.Nome = Console.ReadLine();
        Console.Write("Email: ");
        c.Email = Console.ReadLine();
        Console.Write("CPF: "); 
        c.Cpf = Console.ReadLine();
        Console.Write("Telefone: ");
        c.Telefone = Console.ReadLine();

        
        Console.WriteLine("\nCliente cadastrado com sucesso!\n");
        clienteDAO.Create(c);
    }
    else if (opc == 2)
    {
        Funcionario f = new Funcionario();
        Console.Write("Nome: ");
        f.Nome = Console.ReadLine();
        Console.Write("CPF: "); 
        f.Cpf = Console.ReadLine();
        Console.Write("Cargo: "); 
        f.Cargo = Console.ReadLine();
        Console.Write("Data Admissão (yyyy-dd-mm): ");
        f.Data_admissao = DateTime.Parse(Console.ReadLine());
        Console.Write("Salario do funcionario: ");
        f.Salario = decimal.Parse(Console.ReadLine());
        Console.WriteLine("");

        funcionarioDAO.Create(f);
        Console.WriteLine("Funcionário cadastrado com sucesso!");
    }
    else if (opc == 3)
    {
        Genero g = new Genero();
        Console.Write("Nome do Gênero: ");
        g.Nome_genero = Console.ReadLine();
        Console.WriteLine("");

        generoDAO.Create(g);
        Console.WriteLine("\nGênero cadastrado com sucesso!\n");
    }
    else if (opc == 4)
    {
        Filme f = new Filme();
        Console.Write("Título: ");
        f.Titulo = Console.ReadLine();
        Console.Write("Classificação indicativa: ");
        f.Classificacao_indicativa = Console.ReadLine();
        Console.Write("Duração minutos: "); 
        f.Duracao_minutos = int.Parse(Console.ReadLine());
        Console.Write("Sinopse: ");
        f.Sinopse = Console.ReadLine();
        Console.Write("ID do Gênero: ");
        f.Id_genero = int.Parse(Console.ReadLine());
        Console.WriteLine("");

        filmeDAO.Create(f);
        Console.WriteLine("\nFilme cadastrado com sucesso!\n");
    }
    else if (opc == 5)
    {
        Sala s = new Sala();
        Console.Write("Tipo da Sala: "); 
        s.Tipo_sala = Console.ReadLine();
        Console.Write("Nome da Sala: ");
        s.Nome_sala = Console.ReadLine();
        Console.Write("Capacidade: ");
        s.Capacidade = int.Parse(Console.ReadLine());
        Console.WriteLine("");

        salaDAO.Create(s);
        Console.WriteLine("\nSala cadastrada com sucesso!\n");
    }
    else if (opc == 6)
    {
        Sessao s = new Sessao();
        Console.Write("Valor do ingresso: ");
        s.Valor_ingresso = decimal.Parse(Console.ReadLine());
        Console.Write("Data e hora (yyyy-mm-dd hh:mm): ");
        s.Data_horario_inicio = DateTime.Parse(Console.ReadLine());
        Console.Write("ID do Filme: ");
        s.Id_filme = int.Parse(Console.ReadLine());
        Console.Write("ID da Sala: "); 
        s.Id_sala = int.Parse(Console.ReadLine());
        Console.WriteLine("");

        sessaoDAO.Create(s);
        Console.WriteLine("\nSessão cadastrada com sucesso!\n");
    }
    else if (opc == 0)
    {
        Console.WriteLine("Saindo do programa...\n");
    }
    else
    {
        Console.WriteLine("Opção inválida! Tente novamente.\n");
    }

    if (opc != 0)
    {
        Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
        Console.ReadKey();
    }

} while (opc != 0);

//falta fazer a listagem dos cadastros realizados