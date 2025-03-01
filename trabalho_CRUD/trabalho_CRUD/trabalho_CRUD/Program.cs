using System.Reflection.PortableExecutable;
using trabalho_CRUD;

// fazer um if ou um loop para caso coloque chave estrangeira errada, ou tente colocar uma chave estrangeira antes mesmo de dar um valor para chave primaria
class Progam
{
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
            Console.WriteLine("6. sair");
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
                    MenuMutantes(muntateRepo);
                    break;
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
                Console.WriteLine("===== Menu de Cavernas =====");
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
            Console.WriteLine("===== Lista de Cavernas =====");
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

            int linhas = cavernaRepo.AtualizarCaverna(new Caverna { Nome = nome, Tipo = tipo, Caracteristica = caracteristica });

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
                Console.WriteLine("===== Menu de Itens =====");
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

            Console.WriteLine("Digite novo ID do item que deseja atualizar:");
            int id_item = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Digite o novo nome do item:");
            string nome = Console.ReadLine();

            

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

       /* static void ObterItensPorCavernas(ItensRepository itensRepo)
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
        } */



        static void MenuVilas(VilasRepository vilaRepo)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== Menu de Vilas =====");
                Console.WriteLine("1. Listar");
                Console.WriteLine("2. Inserir");
                Console.WriteLine("3. Atualizar");
                Console.WriteLine("4. Remover");
                Console.WriteLine("5. Listar habitantes e seus tipos");
                Console.WriteLine("6. Voltar");
                Console.Write("Escolha uma opção: ");

                string opcao = Console.ReadLine();
                switch (opcao)
                {
                    case "1":
                        ObterTodasVilas(vilaRepo);
                        break;
                    case "2":
                        InserirVila(vilaRepo);
                        break;
                    case "3":
                        AtualizarVilas(vilaRepo);
                        break;
                    case "4":
                        RemoverVila(vilaRepo);
                        break;
                        //provavelmente irei apagar isso:
                    /*case "5":
                        VerificarSeTipoCanibalExiste(vilaRepo);
                        break;*/
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Opção inválida! Pressione Enter para continuar...");
                        Console.ReadLine();
                        break;
                }
            }
        }
        static void ObterTodasVilas(VilasRepository vilaRepo)
        {
            Console.Clear();
            Console.WriteLine("===== Lista de Vilas =====");
            List<Vilas> vilas = vilaRepo.ObterTodasVilas();
            foreach (var vila in vilas)
            {
                Console.WriteLine($" Nome: {vila.Nome} , Tipo de habitantes: {vila.TipoHabitantes}, Tipo de Habitat: {vila.TipoHabitat}, Localização: {vila.localizacao}");
            }
            Console.WriteLine("\nPressione Enter para voltar...");
            Console.ReadLine();
        }
        static void InserirVila(VilasRepository vilaRepo)
        {

            Console.Clear();
            Console.WriteLine("==== Inserir Vila ====");

            Console.WriteLine("Digite o Nome da Vila:");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite o tipo de habitantes da Vila:");
            string tipo_habitante = Console.ReadLine();

            Console.WriteLine("Digite o tipo de habitat da Vila:");
            string tipo_habitat = Console.ReadLine();

            Console.WriteLine("Digite as localização da vila:");
            string Localização = Console.ReadLine();




            int linhas = vilaRepo.InserirVila(new Vilas { Nome = nome, TipoHabitantes = tipo_habitante, TipoHabitat = tipo_habitat, localizacao = Localização });

            if (linhas > 0)

                Console.WriteLine("Vila inserida com sucesso! Pressione Enter para voltar...");

            else Console.WriteLine("Não houve inserção...");

            Console.ReadLine();
        }

        static void AtualizarVilas(VilasRepository vilaRepo)
        {
            Console.Clear();
            Console.WriteLine("==== Atualizar vila ====");

            Console.WriteLine("Digite a nome da vila que deseja atualizar:");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite a localização da vila:");
            string localizacao = Console.ReadLine();

            Console.WriteLine("Digite novo tipo de habitantes da vila:");
            string tipo_habitantes = Console.ReadLine();

            Console.WriteLine("Digite o novo tipo de habitat da vila:");
            string tipo_habitat = Console.ReadLine();

           
            int linhas = vilaRepo.AtualizarVilas(new Vilas { TipoHabitantes = tipo_habitantes, TipoHabitat = tipo_habitat, Nome = nome, localizacao = localizacao });

            if (linhas > 0)
                Console.WriteLine("Vila atualizado com sucesso! Pressione Enter para voltar...");

            else Console.WriteLine("Não houve atualização...");

            Console.ReadLine();
        }

        static void RemoverVila(VilasRepository vilaRepo)
        {
            Console.Clear();
            Console.WriteLine("==== Remover vila ====");

            Console.WriteLine("Digite o nome da vila que deseja Remover:");
            string nome = Console.ReadLine();

            int linhas = vilaRepo.RemoverVila(nome);

            if (linhas > 0)
                Console.WriteLine("Vila removido com sucesso! Pressione Enter para voltar...");

            else Console.WriteLine("Não houve remoção...");

            Console.ReadLine();
        }

        //provavelmente irei apagar isso:
       /* static void VerificarSeTipoCanibalExiste(VilasRepository vilaRepo)
        {
            Console.Clear();
            Console.WriteLine("==== Verificar se tipo de canibal existe na Vila ====");

            Console.WriteLine("Digite a localização que deseja verificar se o tipo de canibal existe::");
            string Localizacao = Console.ReadLine();

            Console.WriteLine("Digite o tipo de canibal que deseja saber se habita na vila:");
            string tipo = Console.ReadLine();

            List<Canibais> canibais = vilaRepo.VerificarSeTipoCanibalExiste(Localizacao, tipo);
            foreach (var canibal in canibais)
            {
                Console.WriteLine($" Especialidade: {canibal.Especialidade} , Caracteristicas: {canibal.Caracteristicas}, IdCanibal: {canibal.IdCanibal}");
            }
            Console.WriteLine("\nPressione Enter para voltar...");
            Console.ReadLine();

        } */

        // ==============================
        //        MENU Canibais
        // ==============================
        static void MenuCanibais(CanibaisRepository canibalRepo)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== Menu de Canibais =====");
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
                        ObterTodosCanibais(canibalRepo);
                        break;
                    case "2":
                        InserirCanibal(canibalRepo);
                        break;
                    case "3":
                        AtualizarCanibais(canibalRepo);
                        break;
                    case "4":
                        RemoverCanibal(canibalRepo);
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

        static void ObterTodosCanibais(CanibaisRepository canibalRepo)
        {
            Console.Clear();
            Console.WriteLine("===== Lista de Canibais =====");
            List<Canibais> canibais = canibalRepo.ObterTodosCanibais();
            foreach (var canibal in canibais)
            {
                Console.WriteLine($" Tipo: {canibal.Tipo}, Localizacao: {canibal.Localizacao}, Especialidade: {canibal.Especialidade}, Caracteristicas = {canibal.Caracteristicas}, Id Canibal: {canibal.IdCanibal}");
            }
            Console.WriteLine("\nPressione Enter para voltar...");
            Console.ReadLine();
        }

        static void InserirCanibal(CanibaisRepository canibalRepo)
        {

            Console.Clear();
            Console.WriteLine("==== Inserir caverna ====");

            Console.WriteLine("Digite o tipo do canibal:");
            string tipo = Console.ReadLine();
            Console.WriteLine("Digite a localização do canibal:");
            string localizacao = Console.ReadLine();

            Console.WriteLine("Digite a especialidade do canibal:");
            string especialidade = Console.ReadLine();

            Console.WriteLine("Digite as características do canibal:");
            string caracteristica = Console.ReadLine();

            Console.WriteLine("Digite o ID do canibal:");
            int id_canibal = Convert.ToInt32(Console.ReadLine());





            int linhas = canibalRepo.InserirCanibal(new Canibais { Tipo = tipo, Localizacao = localizacao, Especialidade = especialidade, Caracteristicas = caracteristica, IdCanibal = id_canibal });

            if (linhas > 0)

                Console.WriteLine("Canibal inserida com sucesso! Pressione Enter para voltar...");

            else Console.WriteLine("Não houve inserção...");

            Console.ReadLine();
        }

        static void AtualizarCanibais(CanibaisRepository canibalRepo)
        {
            Console.Clear();
            Console.WriteLine("==== Atualizar Canibal ====");


            Console.WriteLine("Digite o ID do canibal que deseja atualizar:");
            int id_canibal = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Digite o novo tipo do canibal:");
            string tipo = Console.ReadLine();

            Console.WriteLine("Digite a nova localização do canibal:");
            string localizacao = Console.ReadLine();


            Console.WriteLine("Digite a nova especialidade do canibal:");
            string especialidade = Console.ReadLine();

            Console.WriteLine("Digite as novas características do canibal:");
            string caracteristica = Console.ReadLine();


            int linhas = canibalRepo.AtualizarCanibais(new Canibais { IdCanibal = id_canibal, Tipo = tipo, Localizacao = localizacao, Especialidade = especialidade, Caracteristicas = caracteristica });

            if (linhas > 0)
                Console.WriteLine("Canibal atualizado com sucesso! Pressione Enter para voltar...");

            else Console.WriteLine("Não houve atualização...");

            Console.ReadLine();
        }

        static void RemoverCanibal(CanibaisRepository canibalRepo)
        {
            Console.Clear();
            Console.WriteLine("==== Remover Canibal ====");

            Console.WriteLine("Digite o ID do canibal que deseja Remover:");
            int id_canibal = Convert.ToInt32(Console.ReadLine());

            int linhas = canibalRepo.RemoverCanibal(id_canibal);

            if (linhas > 0)
                Console.WriteLine("Canibal removido com sucesso! Pressione Enter para voltar...");

            else Console.WriteLine("Não houve remoção...");

            Console.ReadLine();
        }

        // ==============================
        //        MENU Mutantes
        // ==============================
        static void MenuMutantes(MutantesRepository mutanteRepo)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== Menu de Mutante =====");
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
                        ObterTodosMutantes(mutanteRepo);
                        break;
                    case "2":
                        InserirMutante(mutanteRepo);
                        break;
                    case "3":
                        AtualizarMutantes(mutanteRepo);
                        break;
                    case "4":
                        RemoverMutante(mutanteRepo);
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

        static void ObterTodosMutantes(MutantesRepository mutanteRepo)
        {
            Console.Clear();
            Console.WriteLine("===== Lista de Mutantes =====");
            List<Mutantes> mutantes = mutanteRepo.ObterTodosMutantes();
            foreach (var mutante in mutantes)
            {
                Console.WriteLine($" Caracteristicas = {mutante.Caracteristicas}, Especialidade: {mutante.Especialidades}, Localização:{mutante.Localizacao} Id Mutante: {mutante.IdMutante}");
            }
            Console.WriteLine("\nPressione Enter para voltar...");
            Console.ReadLine();
        }

        static void InserirMutante(MutantesRepository mutanteRepo)
        {

            Console.Clear();
            Console.WriteLine("==== Inserir Mutante ====");

            Console.WriteLine("Digite a localização do Mutante:");
            string localizacao = Console.ReadLine();

            Console.WriteLine("Digite a especialidade do Mutante:");
            string especialidade = Console.ReadLine();

            Console.WriteLine("Digite as características do Mutante:");
            string caracteristica = Console.ReadLine();

            Console.WriteLine("Digite o ID do Mutante:");
            int id_mutante = Convert.ToInt32(Console.ReadLine());





            int linhas = mutanteRepo.InserirMutante(new Mutantes { Localizacao = localizacao, Especialidades = especialidade, Caracteristicas = caracteristica, IdMutante = id_mutante });

            if (linhas > 0)

                Console.WriteLine("Mutante inserida com sucesso! Pressione Enter para voltar...");

            else Console.WriteLine("Não houve inserção...");

            Console.ReadLine();
        }

        static void AtualizarMutantes(MutantesRepository mutanteRepo)
        {
            Console.Clear();
            Console.WriteLine("==== Atualizar Mutante ====");

            Console.WriteLine("Digite o ID do mutante que deseja atualizar:");
            int id_mutante = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Digite a nova localização do canibal:");
            string localizacao = Console.ReadLine();

            Console.WriteLine("Digite a nova especialidade do canibal:");
            string especialidade = Console.ReadLine();

            Console.WriteLine("Digite as novas características do canibal:");
            string caracteristica = Console.ReadLine();


            int linhas = mutanteRepo.AtualizarMutantes(new Mutantes { IdMutante = id_mutante, Localizacao = localizacao, Especialidades = especialidade, Caracteristicas = caracteristica });

            if (linhas > 0)
                Console.WriteLine("Mutante atualizado com sucesso! Pressione Enter para voltar...");

            else Console.WriteLine("Não houve atualização...");

            Console.ReadLine();
        }

        static void RemoverMutante(MutantesRepository mutanteRepo)
        {
            Console.Clear();
            Console.WriteLine("==== Remover Mutante ====");

            Console.WriteLine("Digite o ID do mutante que deseja Remover:");
            int id_mutante = Convert.ToInt32(Console.ReadLine());

            int linhas = mutanteRepo.RemoverMutante(id_mutante);

            if (linhas > 0)
                Console.WriteLine("Mutante removido com sucesso! Pressione Enter para voltar...");

            else Console.WriteLine("Não houve remoção...");

            Console.ReadLine();
        }

    }
}

