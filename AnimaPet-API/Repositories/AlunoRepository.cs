using AnimaPet.Models;
using System.Collections.Generic;

namespace AnimaPet.Repositories
{


    public class AlunoRepository
    {

        private readonly List<Aluno> listaAlunos;

        public AlunoRepository()
        {
            listaAlunos = new List<Aluno>();
            listaAlunos.Add(new Aluno()
            {
                Nome = "Aluno 1",
                Matricula = "0001",
                Fone = "(51)90000-0001"
            });

            listaAlunos.Add(new Aluno()
            {
                Nome = "Aluno 2",
                Matricula = "0002",
                Fone = "(51)90000-0002"
            });

            listaAlunos.Add(new Aluno()
            {
                Nome = "Aluno 3",
                Matricula = "0003",
                Fone = "(51)90000-0003"
            });
        }

        public bool saveAluno(Aluno aluno)
        {
            this.listaAlunos.Add(aluno);
            return true;
        }

        public void deleteAluno(Aluno aluno)
        {
            this.listaAlunos.Remove(aluno);
        }

        public Aluno getAluno(Aluno aluno)
        {
            return this.listaAlunos.Find(x => x.Nome == aluno.Nome);
        }

        public List<Aluno> alunos()
        {
            return listaAlunos;
        }
    }
}
