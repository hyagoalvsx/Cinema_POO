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
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Clear();
    Console.WriteLine("=== SISTEMA DE CADASTRO CINEMA ===");
    Console.WriteLine("");
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
    Console.WriteLine("12. Listar Clientes");
    Console.WriteLine("13. Listar Funcionários");
    Console.WriteLine("14. Listar Gêneros");
    Console.WriteLine("15. Listar Filmes");
    Console.WriteLine("16. Listar Salas");
    Console.WriteLine("17. Listar Sessões");
    Console.WriteLine("18. Listar Produtos");
    Console.WriteLine("19. Listar Assentos");
    Console.WriteLine("20. Listar Vendas");
    Console.WriteLine("21. Listar Ingressos");
    Console.WriteLine("22. Listar Itens de Venda");
    Console.WriteLine("0. Sair do programa");
    Console.WriteLine("");
    Console.Write("Escolha sua opção: ");
    opc = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine();

    // CADASTROS
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
        Console.WriteLine("Gênero cadastrado com sucesso!");
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
        Console.WriteLine("Filme cadastrado com sucesso!");
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
        Console.WriteLine("Sala cadastrada com sucesso!");
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

    // listagem/consultas dos cadastros
    else if (opc == 12)
    {
        var lista = clienteDAO.GetAll();
        Console.WriteLine("=== LISTA DE CLIENTES ===");
        Console.WriteLine("");
        foreach (var c in lista)

            Console.WriteLine($"ID: {c.Id_cliente}, Nome: {c.Nome}, Email: {c.Email}, CPF: {c.Cpf}, Telefone: {c.Telefone}");
            Console.WriteLine("");
    }
    else if (opc == 13)
    {
        var lista = funcionarioDAO.GetAll();
        Console.WriteLine("=== LISTA DE FUNCIONÁRIOS ===");
        Console.WriteLine("");
        foreach (var f in lista)

            Console.WriteLine($"ID: {f.Id_funcionario}, Nome: {f.Nome}, CPF: {f.Cpf}, Cargo: {f.Cargo}, Data Admissão: {f.Data_admissao}, Salário: {f.Salario}");
            
    }
    else if (opc == 14)
    {
        var lista = generoDAO.GetAll();
        Console.WriteLine("=== LISTA DE GÊNEROS ===");
        Console.WriteLine("");
        foreach (var g in lista)

            Console.WriteLine($"ID: {g.Id_genero}, Nome: {g.Nome_genero}");
            
    }
    else if (opc == 15)
    {
        var lista = filmeDAO.GetAll();
        Console.WriteLine("=== LISTA DE FILMES ===");
        Console.WriteLine("");
        foreach (var f in lista)

            Console.WriteLine($"ID: {f.Id_filme}, Título: {f.Titulo}, Classificação: {f.Classificacao_indicativa}, Duração: {f.Duracao_minutos} min, Sinopse: {f.Sinopse}, ID Gênero: {f.Id_genero}");
            
    }
    else if (opc == 16)
    {
        var lista = salaDAO.GetAll();
        Console.WriteLine("=== LISTA DE SALAS ===");
        Console.WriteLine("");
        foreach (var s in lista)

            Console.WriteLine($"ID: {s.Id_sala}, Tipo: {s.Tipo_sala}, Nome: {s.Nome_sala}, Capacidade: {s.Capacidade}");
            
    }
    else if (opc == 17)
    {
        var lista = sessaoDAO.GetAll();
        Console.WriteLine("=== LISTA DE SESSÕES ===");
        Console.WriteLine("");
        foreach (var s in lista)

            Console.WriteLine($"ID: {s.Id_sessao}, Valor Ingresso: {s.Valor_ingresso}, Data/Hora: {s.Data_horario_inicio}, ID Filme: {s.Id_filme}, ID Sala: {s.Id_sala}");
            
    }
    else if (opc == 18)
    {
        var lista = produtoDAO.GetAll();
        Console.WriteLine("=== LISTA DE PRODUTOS ===");
        Console.WriteLine("");
        foreach (var p in lista)

            Console.WriteLine($"ID: {p.Id_produto}, Nome: {p.Nome}, Categoria: {p.Categoria}, Estoque: {p.Quant_estoque}, Preço Unitário: {p.Preco_unitario}");
            
    }
    else if (opc == 19)
    {
        var lista = assentoDAO.GetAll();
        Console.WriteLine("=== LISTA DE ASSENTOS ===");
        Console.WriteLine("");
        foreach (var a in lista)

            Console.WriteLine($"ID: {a.Id_assento}, Poltrona: {a.Poltrona}, Status: {a.Status_poltrona}, ID Sala: {a.Id_sala}");
            
    }
    else if (opc == 20)
    {
        var lista = vendaDAO.GetAll();
        Console.WriteLine("=== LISTA DE VENDAS ===");
        Console.WriteLine("");
        foreach (var v in lista)

            Console.WriteLine($"ID: {v.Id_venda}, Forma Pagamento: {v.Forma_pagamento}, Valor Total: {v.Valor_total}, Data/Hora: {v.Data_hora_venda}, ID Cliente: {v.Id_cliente}, ID Funcionario: {v.Id_funcionario}");
            
    }
    else if (opc == 21)
    {
        var lista = ingressoDAO.GetAll();
        Console.WriteLine("=== LISTA DE INGRESSOS ===");
        Console.WriteLine("");
        foreach (var i in lista)

            Console.WriteLine($"ID: {i.Id_ingresso}, Tipo: {i.Tipo_ingresso}, Valor Pago: {i.Valor_pago}, ID Venda: {i.Id_venda}, ID Sessão: {i.Id_sessao}");
           
    }
    else if (opc == 22)
    {
        var lista = itemVendaDAO.GetAll();
        Console.WriteLine("=== LISTA DE ITENS DE VENDA ===");
        Console.WriteLine("");
        foreach (var iv in lista)

            Console.WriteLine($"ID: {iv.Id_item}, Quantidade: {iv.Quantidade}, Preço Unitário: {iv.Preco_unitario}, Subtotal: {iv.Subtotal}, ID Produto: {iv.Id_produto}, ID Venda: {iv.Id_venda}");
            
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


