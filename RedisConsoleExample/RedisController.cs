using Microsoft.Extensions.DependencyInjection;
using RedisDataRepository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedisConsoleExample
{
    public class RedisController
    {
        private readonly DependencyInjectionManager _manager;
        private readonly IRedisRepository _redisRepo;
        public RedisController(DependencyInjectionManager manager)
        {
            _manager = manager;
            using (var scope = _manager.ServiceProvider.CreateScope())
            {
                _redisRepo = scope.ServiceProvider.GetService<IRedisRepository>();
            }
        }

        public void Menu()
        {
            int option = 0;
            while (option != 4)
            {
                Console.WriteLine("1-Inserir dado \n2-Ler dado \n3-Apagar dado \n4-Fim");

                option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Inserir();
                        break;
                    case 2:
                        Consultar();
                        break;
                    case 3:
                        Excluir();
                        break;
                }
            }
        }


        private string Inserir()
        {
            Console.WriteLine("Digite o cpf");
            string cpf = Console.ReadLine();
            Console.WriteLine("Digite o nome:");
            string name = Console.ReadLine();

            if (cpf != "" && name != "")
            {
                _redisRepo.SetStringValue(cpf, name, 2);
            }
            return cpf;
        }

        private void Excluir()
        {
            string cpf = GetCpf();
            Consultar(cpf);
            Console.WriteLine("Tem certeza <s/n>?");
            var option = Console.ReadLine();
            if (option == "S" || option == "s")
            {
                _redisRepo.DeleteStringValue(cpf);
            }
        }

        private void Consultar(string cpfParam = "")
        {
            string cpf = cpfParam == "" ? GetCpf() : cpfParam;
            var response = _redisRepo.GetStringValue(cpf);
            if (response != null)
            {
                Console.WriteLine("Nome:" + response);

                Console.WriteLine("Aperte qualquer tecla !");
            }
            else
            {
                Console.WriteLine("Not found!");
            }
        }

        private string GetCpf()
        {
            Console.WriteLine("Digite o cpf");
            string cpf = Console.ReadLine();
            return cpf;
        }

    }
}
