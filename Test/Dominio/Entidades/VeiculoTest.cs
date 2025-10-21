using MinimalApi.Dominio.Entidades;

namespace Test.Dominio.Entidades;

[TestClass]
public class VeiculoTest
{
    [TestMethod]
    public void TestarGetSetPropriedades()
    {
        // Arrange
        var veiculo = new Veiculo();

        // Act
        veiculo.Id = 1;
        veiculo.Nome = "Toro Ultra";
        veiculo.Marca = "Fiat";
        veiculo.Ano = 2025; ;


        // Assert
        Assert.AreEqual(1, veiculo.Id);
        Assert.AreEqual("Toro Ultra", veiculo.Nome);
        Assert.AreEqual("Fiat", veiculo.Marca);
        Assert.AreEqual(2025, veiculo.Ano);

    }

}
