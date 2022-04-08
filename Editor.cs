using System;
using System.Text;
using System.IO;

namespace EditorHtml
{
	public static class Editor
    {
        public static void Show()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            Console.WriteLine("MODO EDITOR");
            Console.WriteLine("Digite o seu texto aqui! (ESC para sair)");
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            Start();
        }

        public static void Start()
        {
            StringBuilder file = new StringBuilder();

            do
            {
                file.Append(Console.ReadLine());
                file.Append(Environment.NewLine);

            } while (Console.ReadKey().Key != ConsoleKey.Escape);


            Console.WriteLine("-------------");
            Console.WriteLine("Deseja salvar o arquivo?");
            Console.WriteLine("Sim => s ou Não => n");
            Console.Write("Resposta: ");
            string resposta = Console.ReadLine().ToLower();

            switch (resposta)
            {
                case "s": Salvar(file); break;
                case "n": System.Environment.Exit(0); break;
                    
                default: Viewer.Show(file.ToString()); break;
            }

        }

        public static void Salvar(StringBuilder file)
        {
            Console.Clear();
            Console.WriteLine(" Deseja salvar onde?");
            Console.WriteLine(@" Caminho:\Pasta\NomedoArquivo.txt");
            var path = Console.ReadLine();

            using (var document = new StreamWriter(path))
            {
                document.Write(file);
            }

            Console.WriteLine($" Arquivo salvo em {path} com sucesso!");
            Console.ReadLine();
            Viewer.Show(file.ToString());

        }



    }

}