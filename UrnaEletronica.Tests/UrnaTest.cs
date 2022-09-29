using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrnaEletronica.Tests
{
    public class UrnaTest
    {
        // Unidade_Contexto_ResultadoEsperado

        /// <summary>
        /// Validar se o construtor está inserindo os dados iniciais corretamente
        /// </summary>
        [Fact]
        public void ValidarConstrutor_NovaEleicao_RetornaUrnaVazia()
        {
            //arrange
            var urna = new Urna();

            //act
            var urnaEsperada = new Urna()
            {
                VencedorEleicao = "",
                VotosVencedor = 0,
                Candidatos = new List<Candidato>(),
                EleicaoAtiva = false,
            };

            //assert
            urnaEsperada.Should().BeEquivalentTo(urna);
        }


        /// <summary>
        /// Validar se a eleição está sendo iniciada corretamente
        /// </summary>
        [Fact]
        public void IniciarEncerrarEleicao_IniciaUrna_EleicaoAtivaTrue()
        {
            //arrange
            var eleicao = new Urna();

            //act
            eleicao.IniciarEncerrarEleicao();

            //assert
            Assert.True(eleicao.EleicaoAtiva);
        }


        /// <summary>
        /// Validar se a eleição está sendo encerrada corretamente
        /// </summary>
        [Fact]
        public void IniciarEncerrarEleicao_EncerraUrna_EleicaoAtivaFalse()
        {
            //arrange
            var eleicao = new Urna();

            //act
            eleicao.IniciarEncerrarEleicao();
            eleicao.IniciarEncerrarEleicao();

            //assert
            Assert.False(eleicao.EleicaoAtiva);
        }


        /// <summary>
        /// Validar se, ao cadastrar um candidato, o último candidato na lista é o mesmo que foi cadastrado
        /// </summary>
        [Fact]
        public void CadastrarCandidato_NovoCandidato_RetornaUltimoCadastrado()
        {
            //arrange
            var urna = new Urna();

            //act
            urna.CadastrarCandidato("Fulano da Silva");
            urna.CadastrarCandidato("Beltrano Aparecido");
            urna.CadastrarCandidato("Cicrano de Sousa");

            //assert
            Assert.Equal("Cicrano de Sousa", urna.Candidatos.LastOrDefault().Nome);
        }


        /// <summary>
        /// Validar o método de votação quando é informado um candidato não cadastrado
        /// </summary>
        [Fact]
        public void Votar_CandidatoNaoCadastrado_RetornaFalse()
        {
            //arrange
            var urna = new Urna();
            urna.CadastrarCandidato("Fulano da Silva");
            urna.CadastrarCandidato("Beltrano Aparecido");
            urna.CadastrarCandidato("Cicrano de Sousa");

            //act
            var votoComputado = urna.Votar("Candidato Não Cadastrado");

            //assert
            Assert.False(votoComputado);
        }


        /// <summary>
        /// Validar o método de votação quando é informado um candidato cadastrado
        /// </summary>
        [Fact]
        public void Votar_CandidatoCadastrado_RetornaTrue()
        {
            //arrange
            var urna = new Urna();
            urna.CadastrarCandidato("Fulano da Silva");
            urna.CadastrarCandidato("Beltrano Aparecido");
            urna.CadastrarCandidato("Cicrano de Sousa");

            //act
            var votoComputado = urna.Votar("Beltrano Aparecido");

            //assert
            Assert.True(votoComputado);
        }


        /// <summary>
        /// Validar o resultado da eleição
        /// </summary>
        [Fact]
        public void ValidaMostrarResultadoEleicao()
        {
            //arrange
            var urna = new Urna();
            urna.CadastrarCandidato("Fulano da Silva");
            urna.CadastrarCandidato("Beltrano Aparecido");
            urna.CadastrarCandidato("Cicrano de Sousa");

            //act
            urna.Votar("Beltrano Aparecido");
            urna.Votar("Beltrano Aparecido");
            urna.Votar("Fulano da Silva");

            var vencedor = "Nome vencedor: Beltrano Aparecido. Votos: 2";

            //assert
            Assert.Equal(vencedor, urna.MostrarResultadoEleicao());
        }
    }
}
