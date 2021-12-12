using AnimaPet.Models;
using AutoBogus;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestProjectAnimaPet
{
    public class UnitTest1
    {
        private readonly HttpClient _httpClient;

        public UnitTest1()
        {
            _httpClient = new HttpClient();
        }

        [Fact]
        public async Task addAluno_RetornaStatusCodeSucessoEOAlunoCriado()
        {
            var novoAluno = new AutoFaker<Aluno>();

            StringContent content = new StringContent(JsonConvert.SerializeObject(novoAluno.Generate()), Encoding.UTF8, "application/json");

            var httpRequest = await _httpClient.PostAsync("/api/v1/alunos/addAluno", content);

            Assert.Equal(HttpStatusCode.Created, httpRequest.StatusCode);
        }

        [Fact]
        public async Task getAllAlunos_ObterAlunosRetornaStatusCodeSucesso()
        {

            await addAluno_RetornaStatusCodeSucessoEOAlunoCriado();

            var httpRequest = await _httpClient.GetAsync("/api/v1/alunos/getAllAlunos");

            var alunos = JsonConvert.DeserializeObject<IList<Aluno>>(await httpRequest.Content.ReadAsStringAsync());

            Assert.NotNull(alunos);
            Assert.Equal(HttpStatusCode.OK, httpRequest.StatusCode);
        }
    }
}
