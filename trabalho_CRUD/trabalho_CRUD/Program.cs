using trabalho_CRUD;

static void Main()
{
    string connectionString = "Server=localhost;Database=sonsoftheforest;User=root;Password=;";

    CavernaRepository cavernaRepo = new CavernaRepository(connectionString);
    ItensRepository itensRepo = new ItensRepository(connectionString);
    VilasRepository vilaRepo = new VilasRepository(connectionString);
    CanibaisRepository canibalRepo = new CanibaisRepository(connectionString);
    MutantesRepository muntateRepo = new MutantesRepository(connectionString);

    while (true)
    {
        Console.Clear();
        Console.WriteLine("===== Menu Principal =====");
        Console.WriteLine("1. Cavernas");
        Console.WriteLine("2. Itens");
        Console.WriteLine("3. Vilas");
        Console.WriteLine("4. Canibais");
        Console.WriteLine("5. Mutantes");
        Console.WriteLine("6. Mutantes");
        Console.Write("Escolha uma opção: ");

        string opcaoPrincipal = Console.ReadLine();
        switch (opcaoPrincipal)
        {
            case "1":
                MenuCavernas(cavernaRepo);
                break;
            case "2":
                MenuItens(itensRepo);
                break;
            case "3":
                MenuVilas(vilaRepo);
                break;
            case "4":
                MenuCanibais(canibalRepo);
                break;
            case "5":
                Mutante(muntateRepo);
            case "6":
                Console.WriteLine("Saindo...");
                return;
            default:
                Console.WriteLine("Opção inválida! Pressione Enter para continuar...");
                Console.ReadLine();
                break;
        }
    }

    // ==============================
    //        MENU CAVERNAS
    // ==============================
    static void MenuCavernas(CavernaRepository cavernaRepo)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("===== Menu de Professores =====");
            Console.WriteLine("1. Listar");
            Console.WriteLine("2. Inserir");
            Console.WriteLine("3. Atualizar");
            Console.WriteLine("4. Remover");
            Console.WriteLine("5. Voltar");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine();
            switch (opcao)
            {
                case "1":
                    ObterTodasCavernas(cavernaRepo);
                    break;
                case "2":
                    InserirCaverna(cavernaRepo);
                    break;
                case "3":
                    AtualizarCaverna(cavernaRepo);
                    break;
                case "4":
                    RemoverCaverna(cavernaRepo);
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Opção inválida! Pressione Enter para continuar...");
                    Console.ReadLine();
                    break;
            }
        }
    }

    static void ObterTodasCavernas(CavernaRepository cavernaRepo)
    {
        Console.Clear();
        Console.WriteLine("===== Lista de Professores =====");
        List<Caverna> cavernas = cavernaRepo.ObterTodasCavernas();
        foreach (var caverna in cavernas)
        {
            Console.WriteLine($" Nome: {caverna.Nome} , Tipo: {caverna.Tipo}, caracteríticas: {caverna.Caracteristica}");
        }
        Console.WriteLine("\nPressione Enter para voltar...");
        Console.ReadLine();
    }

    static void InserirCaverna(CavernaRepository cavernaRepo)
    {

        Console.Clear();
        Console.WriteLine("==== Inserir caverna ====");

        Console.WriteLine("Digite o Nome da caverna:");
        string nome = Console.ReadLine();
        Console.WriteLine("Digite o tipo da caverna:");
        string tipo = Console.ReadLine();

        Console.WriteLine("Digite as características da caverna:");
        string caracteristica = Console.ReadLine();




        int linhas = cavernaRepo.InserirCaverna(new Caverna { Nome = nome, Tipo = tipo, Caracteristica = caracteristica });

        if (linhas > 0)

            Console.WriteLine("caverna inserida com sucesso! Pressione Enter para voltar...");

        else Console.WriteLine("Não houve inserção...");

        Console.ReadLine();
    }

    static void AtualizarCaverna(CavernaRepository cavernaRepo)
    {
        Console.Clear();
        Console.WriteLine("==== Atualizar caverna ====");

        Console.WriteLine("Digite o nome da caverna que deseja atualizar:");
        string nome = Console.ReadLine();
        Console.WriteLine("Digite novo tipo da caverna:");
        string tipo = Console.ReadLine();
        Console.WriteLine("Digite a nova característica da caverna:");
        string caracteristica = Console.ReadLine();

        int linhas = cavernaRepo.AtualizarCaverna(new Caverna { Tipo = tipo, Caracteristica = caracteristica});

        if (linhas > 0)
            Console.WriteLine("caverna atualizado com sucesso! Pressione Enter para voltar...");

        else Console.WriteLine("Não houve atualização...");

        Console.ReadLine();
    }

    static void RemoverCaverna(CavernaRepository cavernaRepo)
    {
        Console.Clear();
        Console.WriteLine("==== Remover aluno ====");

        Console.WriteLine("Digite nome da caverna que deseja Remover:");
        string nome = Console.ReadLine();

        int linhas = cavernaRepo.RemoverCaverna(nome);

        if (linhas > 0)
            Console.WriteLine("caverna removido com sucesso! Pressione Enter para voltar...");

        else Console.WriteLine("Não houve remoção...");

        Console.ReadLine();
    }

    //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    // ==============================
    //        MENU Itens
    // ==============================
    static void MenuItens(ItensRepository itensRepo)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("===== Menu de Professores =====");
            Console.WriteLine("1. Listar");
            Console.WriteLine("2. Inserir");
            Console.WriteLine("3. Atualizar");
            Console.WriteLine("4. Remover");
            Console.WriteLine("5. Listar por cavernas");
            Console.WriteLine("6. Voltar");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine();
            switch (opcao)
            {
                case "1":
                    ObterTodasItens(itensRepo);
                    break;
                case "2":
                    InserirItem(itensRepo);
                    break;
                case "3":
                    AtualizarItens(itensRepo);
                    break;
                case "4":
                    RemoverItem(itensRepo);
                    break;
                case "5":
                    ObterItensPorCavernas(itensRepo);
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Opção inválida! Pressione Enter para continuar...");
                    Console.ReadLine();
                    break;
            }
        }
    }

    static void ObterTodasItens(ItensRepository itensRepo)
    {
        Console.Clear();
        Console.WriteLine("===== Lista de Itens =====");
        List<Itens> itens = itensRepo.ObterTodosItens();
        foreach (var item in itens)
        {
            Console.WriteLine($" Nome: {item.Nome} , Id: {item.IdItens}, Localizacao: {item.Localizacao}, TipoItem: {item.TipoItem}");
        }
        Console.WriteLine("\nPressione Enter para voltar...");
        Console.ReadLine();
    }

    static void InserirItem(ItensRepository itensRepo)
    {

        Console.Clear();
        Console.WriteLine("==== Inserir item ====");

        Console.WriteLine("Digite o Nome do item:");
        string nome = Console.ReadLine();

        Console.WriteLine("Digite o Id do item:");
        int id_item = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Digite o Localização do item:");
        string localizacao = Console.ReadLine();

        Console.WriteLine("Digite o tipo do item:");
        string tipo_item = Console.ReadLine();

        Console.WriteLine("Digite as características da caverna:");
        string caracteristica = Console.ReadLine();




        int linhas = itensRepo.InserirItem(new Itens { Nome = nome, IdItens = id_item, Localizacao = localizacao, TipoItem = tipo_item });

        if (linhas > 0)

            Console.WriteLine("Item inserida com sucesso! Pressione Enter para voltar...");

        else Console.WriteLine("Não houve inserção...");

        Console.ReadLine();
    }

    static void AtualizarItens(ItensRepository itensRepo)
    {
        Console.Clear();
        Console.WriteLine("==== Atualizar item ====");

        Console.WriteLine("Digite o nome do item que deseja atualizar:");
        string nome = Console.ReadLine();

        Console.WriteLine("Digite novo ID do item:");
        int id_item = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Digite a nova localização do Item:");
        string localizacao = Console.ReadLine();

        Console.WriteLine("Digite o novo tipo de Item:");
        string tipo_item = Console.ReadLine();

        int linhas = itensRepo.AtualizarItens(new Itens { Nome = nome, IdItens = id_item, Localizacao = localizacao, TipoItem = tipo_item });

        if (linhas > 0)
            Console.WriteLine("Item atualizado com sucesso! Pressione Enter para voltar...");

        else Console.WriteLine("Não houve atualização...");

        Console.ReadLine();
    }

    static void RemoverItem(ItensRepository itensRepo)
    {
        Console.Clear();
        Console.WriteLine("==== Remover Item ====");

        Console.WriteLine("Digite ID do item que deseja Remover:");
        string id_item = Console.ReadLine();

        int linhas = itensRepo.RemoverItem(id_item);

        if (linhas > 0)
            Console.WriteLine("Item removido com sucesso! Pressione Enter para voltar...");

        else Console.WriteLine("Não houve remoção...");

        Console.ReadLine();
    }

    static void ObterItensPorCavernas(ItensRepository itensRepo)
    {
        Console.Clear();
        Console.WriteLine("===== Lista de Itens =====");

        Console.WriteLine("Digite o nome da caverna:");
        string nome = Console.ReadLine();


        List<Itens> itens = itensRepo.ObterItensPorCavernas(nome);
        foreach (var item in itens)
        {
            Console.WriteLine($" Nome: {item.Nome} , Id: {item.IdItens}, Localizacao: {item.Localizacao}, TipoItem: {item.TipoItem}");
        }
        Console.WriteLine("\nPressione Enter para voltar...");
        Console.ReadLine();
    }

}

