global using System;
using revisao;

revisao.Aluno[] alunos = new revisao.Aluno[5];
var indiceAluno = 0;
string opcaoUsuario = ObteropcaoUsuario();


while(opcaoUsuario.ToUpper() != "X")
{
    switch(opcaoUsuario)
    {
        case "1":
        System.Console.WriteLine("Informe o nome do Aluno:");
        revisao.Aluno aluno = new revisao.Aluno();
        aluno.Nome= Console.ReadLine();

        System.Console.WriteLine("Informe a nota do Aluno:");
        
       if(decimal.TryParse(Console.ReadLine(), out decimal nota))
       {
           aluno.Nota  = nota;  
       }
       else
       {
            throw new ArgumentException("Valor da nota deve ser decimal!");   
       }
        alunos[indiceAluno] = aluno;
        indiceAluno++;
             
        break;

        case "2":
        foreach(var a in alunos)
        {
                if(!string.IsNullOrEmpty(a.Nome))

                System.Console.WriteLine($"Aluno: {a.Nome} - Nota: {a.Nota}");
        }
        break;

        case "3":
            decimal notaTotal = 0;
            var nrAlunos = 0;
            for(int i=0; i<alunos.Length; i++)
            {
                if(!string.IsNullOrEmpty(alunos[i].Nome))
                {
                    notaTotal = notaTotal + alunos[i].Nota;
                    nrAlunos++;
                }

            }
            var mediaGeral = notaTotal / nrAlunos;
            conceito conceitoGeral;

            if(mediaGeral <= 2)
            {
                conceitoGeral = conceito.E;
            }else if(mediaGeral <= 4)
            {
                conceitoGeral = conceito.D;
            }else if(mediaGeral <= 6)
            {
                conceitoGeral = conceito.C;
            }else if(mediaGeral <= 8)
            {
                conceitoGeral = conceito.B;
            }else{
                conceitoGeral = conceito.A;
            }

            System.Console.WriteLine($"Media Geral: {mediaGeral} - Conceito Geral: {conceitoGeral} ");
        break;
        default:
        throw new ArgumentOutOfRangeException();

        
    }
        opcaoUsuario = ObteropcaoUsuario();

       
}
    static string ObteropcaoUsuario()
{
       Console.WriteLine("Informe a opção desejada");
       Console.WriteLine("1 - Inserir novo aluno");
       Console.WriteLine("2 - Listar aluno");
       Console.WriteLine("3 - Calcular média geral");
       Console.WriteLine("X - sair");
       Console.WriteLine();


        string opcaoUsuario = Console.ReadLine();
        Console.WriteLine();
        return opcaoUsuario;
}
