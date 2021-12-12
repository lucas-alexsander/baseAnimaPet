using AnimaPet.Models;
using AnimaPet.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimaPet.Controllers
{
    [Route("/api/v1/Aluno")]
    [ApiController]
    public class AlunoController : Controller
    {

        private readonly AlunoRepository _alunoRepository;

        public AlunoController()
        {
            _alunoRepository = new AlunoRepository();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("getAllAlunos")]
        public async Task<IActionResult> getAllAlunos()
        {
            return Ok(_alunoRepository.alunos());
        }

        [HttpGet]
        [Route("getAluno")]
        public async Task<IActionResult> getAluno(Aluno aluno)
        {
            return Ok(_alunoRepository.getAluno(aluno));
        }

        [HttpPost]
        [Route("addAluno")]
        public async Task<IActionResult> addAluno(Aluno aluno)
        {
            _alunoRepository.saveAluno(aluno);
            return Created("", aluno);
        }
    }
}
