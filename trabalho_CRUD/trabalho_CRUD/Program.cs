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
                MenuItens();
                break;
            case "3":
                MenuCasas(casaRepo);
                break;
            case "4":
                MenuDisciplinas(disciplinaRepo);
                break;
            case "5":
                Mutante(repo);
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
    //        MENU PROFESSORES
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
                    InserirProfessor(professorRepo);
                    break;
                case "3":
                    AtualizarProfessor(professorRepo);
                    break;
                case "4":
                    RemoverProfessor(professorRepo);
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


}

