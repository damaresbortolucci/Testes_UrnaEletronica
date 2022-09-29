namespace UrnaEletronica.Tests
{
    public class CandidatoTest
    {
        /// <summary>
        /// Valida se a quantidade de votos está correta após o cadastro do candidato
        /// </summary>
        [Fact]
        public void ValidaVotos_NovoCandidato_RetornaZeroVotos()
        {
            //arrange/act
            var novoCandidato = new Candidato("Fulano Cicrano da Silva");

            //assert
            Assert.Equal(0, novoCandidato.RetornarVotos());
        }


        /// <summary>
        /// Valida se a quantidade de votos está correta após a inserção de um novo voto
        /// </summary>
        [Fact]
        public void ValidaVotos_NovaVotacao_RetornaUmVoto()
        {
            //arrange
            var candidato = new Candidato("Fulano Cicrano da Silva");

            //act
            candidato.AdicionarVoto();

            //assert
            Assert.Equal(1, candidato.RetornarVotos());
        }


        /// <summary>
        /// Valida se o nome do candidato está correto após o cadastro do candidato
        /// </summary>
        [Fact]
        public void ValidaNome_NovoCandidato_RetornaNomeCadastrado()
        {
            //arrange/act
            var nome = "Fulano Cicrano da Silva";
            var novoCandidato = new Candidato(nome);

            //assert
            Assert.Equal(nome, novoCandidato.Nome);
        }
    }
}