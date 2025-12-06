using ConexaoBancoDados.Utilitarios;
using Cinema_POO.Models;
using ConexaoBancoDados.DAO;

ClienteDAO clienteDAO = new ClienteDAO();
FuncionarioDAO funcionarioDAO = new FuncionarioDAO();
GeneroDAO generoDAO = new GeneroDAO();
FilmeDAO filmeDAO = new FilmeDAO();
SalaDAO salaDAO = new SalaDAO();
SessaoDAO sessaoDAO = new SessaoDAO();
ProdutoDAO produtoDAO = new ProdutoDAO();
AssentoDAO assentoDAO = new AssentoDAO();
VendaDAO vendaDAO = new VendaDAO();
IngressoDAO ingressoDAO = new IngressoDAO();
ItemVendaDAO itemVendaDAO = new ItemVendaDAO();

int opc;

do
{
    Console.Clear();
    Console.WriteLine("=== SISTEMA DE CADASTRO CINEMA ===");
    Console.WriteLine("1. Cadastrar Cliente");
    Console.WriteLine("2. Cadastrar Funcionário");
    Console.WriteLine("3. Cadastrar Gênero");
    Console.WriteLine("4. Cadastrar Filme");
    Console.WriteLine("5. Cadastrar Sala");
    Console.WriteLine("6. Cadastrar Sessão");
    Console.WriteLine("7. Cadastrar Produto");
    Console.WriteLine("8. Cadastrar Assento");
    Console.WriteLine("9. Cadastrar Venda");
    Console.WriteLine("10. Cadastrar Ingresso");
    Console.WriteLine("11. Cadastrar Item_Venda");
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
        Console.WriteLine("");

        clienteDAO.Create(c);
        Console.WriteLine("Cliente cadastrado com sucesso!");
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
        Console.Write("Data Admissão (yyyy-mm-dd): ");
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
        Console.WriteLine("Sessão cadastrada com sucesso!");
    }
    else if (opc == 7)
    {
        Produto p = new Produto();
        Console.Write("Nome do Produto: ");
        p.Nome = Console.ReadLine();
        Console.Write("Categoria: ");
        p.Categoria = Console.ReadLine();
        Console.Write("Quantidade em estoque: ");
        p.Quant_estoque = int.Parse(Console.ReadLine());
        Console.Write("Preço unitário: ");
        p.Preco_unitario = decimal.Parse(Console.ReadLine());
        Console.WriteLine("");

        produtoDAO.Create(p);
        Console.WriteLine("Produto cadastrado com sucesso!");
    }
    else if (opc == 8)
    {
        Assento a = new Assento();
        Console.Write("Poltrona: ");
        a.Poltrona = Console.ReadLine();
        Console.Write("Status da Poltrona: ");
        a.Status_poltrona = Console.ReadLine();
        Console.Write("ID da Sala: ");
        a.Id_sala = int.Parse(Console.ReadLine());
        Console.WriteLine("");

        assentoDAO.Create(a);
        Console.WriteLine("Assento cadastrado com sucesso!");
    }
    else if (opc == 9)
    {
        Venda v = new Venda();
        Console.Write("Forma de pagamento: ");
        v.Forma_pagamento = Console.ReadLine();
        Console.Write("Valor total: ");
        v.Valor_total = decimal.Parse(Console.ReadLine());
        Console.Write("Data e hora da venda (yyyy-mm-dd hh:mm): ");
        v.Data_hora_venda = DateTime.Parse(Console.ReadLine());
        Console.Write("ID do Cliente: ");
        v.Id_cliente = int.Parse(Console.ReadLine());
        Console.Write("ID do Funcionário: ");
        v.Id_funcionario = int.Parse(Console.ReadLine());
        Console.WriteLine("");

        vendaDAO.Create(v);
        Console.WriteLine("Venda cadastrada com sucesso!");
    }
    else if (opc == 10)
    {
        Ingresso i = new Ingresso();
        Console.Write("Tipo de ingresso: ");
        i.Tipo_ingresso = Console.ReadLine();
        Console.Write("Valor pago: ");
        i.Valor_pago = decimal.Parse(Console.ReadLine());
        Console.Write("ID da Venda: ");
        i.Id_venda = int.Parse(Console.ReadLine());
        Console.Write("ID da Sessão: ");
        i.Id_sessao = int.Parse(Console.ReadLine());
        Console.WriteLine("");

        ingressoDAO.Create(i);
        Console.WriteLine("Ingresso cadastrado com sucesso!");
    }
    else if (opc == 11)
    {
        Item_Venda iv = new Item_Venda();
        Console.Write("Quantidade: ");
        iv.Quantidade = int.Parse(Console.ReadLine());
        Console.Write("Preço unitário: ");
        iv.Preco_unitario = decimal.Parse(Console.ReadLine());
        Console.Write("Subtotal: ");
        iv.Subtotal = decimal.Parse(Console.ReadLine());
        Console.Write("ID do Produto: ");
        iv.Id_produto = int.Parse(Console.ReadLine());
        Console.Write("ID da Venda: ");
        iv.Id_venda = int.Parse(Console.ReadLine());
        Console.WriteLine("");

        itemVendaDAO.Create(iv);
        Console.WriteLine("Item_Venda cadastrado com sucesso!");
    }
    else if (opc == 0)
    {
        Console.WriteLine("");
        Console.WriteLine("Saindo do programa...");
    }
    else
    {
        Console.WriteLine("");
        Console.WriteLine("Opção inválida! Tente novamente.");
    }

    if (opc != 0)
    {
        Console.WriteLine("");
        Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
        Console.ReadKey();
    }

} while (opc != 0);

//falta fazer a listagem dos cadastros realizados
