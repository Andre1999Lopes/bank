using System;
using System.Collections.Generic;

namespace bank
{
	class Program
	{
		static List<Conta> listaContas = new List<Conta>();
		static void Main(string[] args){
			string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario != "X") {
				switch (opcaoUsuario) {
					case "1":
						ListarContas();
						break;
					case "2":
						InserirConta();
						break;
					case "3":
						Transferir();
						break;
					case "4":
						Sacar();
						break;
					case "5":
						Depositar();
						break;
					case "C":
						Console.Clear();
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}
				opcaoUsuario = ObterOpcaoUsuario();
			}
			Console.WriteLine("Obrigado por utilizar os nossos serviços!\n");
		}

		private static string ObterOpcaoUsuario () {
			Console.WriteLine("\nLopesBank: o melhor para você em um só lugar!");
			Console.WriteLine("Indique a opção desejada:");

			Console.WriteLine("1 - Listar contas");
			Console.WriteLine("2 - Inserir nova conta");
			Console.WriteLine("3 - Transferir");
			Console.WriteLine("4 - Sacar");
			Console.WriteLine("5 - Depositar");
			Console.WriteLine("C - Limpar tela");
			Console.WriteLine("X - Sair da aplicação\n");

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}

		private static void ListarContas () {
			if (listaContas.Count == 0) {
				Console.WriteLine("A lista de contas está vazia.");
				return;
			}

			for (int i=0; i<listaContas.Count; i++) {
				Console.Write($"{i} - ");
				Console.WriteLine(listaContas[i]);
			}
		}

		private static void Sacar () {
			Console.Write("Digite o número da conta: ");
			int indiceConta = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor a ser sacado: ");
			double valor = double.Parse(Console.ReadLine());

			listaContas[indiceConta].Sacar(valor);
		}

		private static void Depositar () {
			Console.Write("Digite o número da conta: ");
			int indiceConta = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor a ser depositado: ");
			double valor = double.Parse(Console.ReadLine());

			listaContas[indiceConta].Depositar(valor);
		}

		private static void Transferir () {
			Console.Write("Digite o número da conta de origem: ");
			int contaOrigem = int.Parse(Console.ReadLine());

			Console.Write("Digite o número da conta de destino: ");
			int contaDestino = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor a ser transferido: ");
			double valor = double.Parse(Console.ReadLine());

			listaContas[contaOrigem].Transferir(valor, listaContas[contaDestino]);
		}

		private static void InserirConta () {
			Console.Write("Digite 1 para pessoa física ou 2 para pessoa jurídica: ");
			int entradaTipoConta = int.Parse(Console.ReadLine());
			
			Console.Write("Digite o nome do cliente: ");
			string nome = Console.ReadLine();

			Console.Write("Digite o saldo inicial: ");
			double saldo = double.Parse(Console.ReadLine());

			Console.Write("Digite o crédito inicial: ");
			double credito = double.Parse(Console.ReadLine());

			Conta novaConta = new Conta((TipoConta)entradaTipoConta, saldo, credito, nome);
			listaContas.Add(novaConta);
		}
	}
}
