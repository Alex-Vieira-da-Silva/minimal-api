using MinimalApi.Dominio.Entidades;

namespace Test.Dominio.Entidades;

[TestClass]
public class AdministradorTest
{
    [TestMethod]
    public void TestarGetSetPropriedades()
    {
        // Arrange
        var adm = new Administrador();

        // Act
        adm.Id = 1;
        adm.Email = "admin@teste.com";
        adm.Senha = "senha123";
        adm.Perfil = "Adm";


        // Assert
        Assert.AreEqual(1, adm.Id);
        Assert.AreEqual("admin@teste.com", adm.Email);
        Assert.AreEqual("senha123", adm.Senha);
        Assert.AreEqual("Adm", adm.Perfil);
     
    }
}
