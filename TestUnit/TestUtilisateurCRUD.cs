using Metier;

namespace TestUnit
{
    public class TestUtilisateurCRUD
    {
        Utilisateur toto = new Utilisateur(-1, "Dupont", "Toto", new DateTime(2008, 05, 15), "toto.dupont@gmail.com", "f2d81a260dea8a100dd517984e53c56a7523d96942a834b9cdc249bd4e8c7aa9");

        [Fact]
        public void TestAddDelete()
        {
            Assert.False(UtilisateurManager.UtilisateurExists(toto.IdUtilisateur));
            UtilisateurManager.Create(toto);
            Assert.True(UtilisateurManager.UtilisateurExists(toto.IdUtilisateur));
            UtilisateurManager.Delete(toto.IdUtilisateur);
            Assert.False(UtilisateurManager.UtilisateurExists(toto.IdUtilisateur));
        }

        [Fact]
        public void TestGetById()
        {
            UtilisateurManager.Create(toto);
            Utilisateur totoBDD = UtilisateurManager.GetById(toto.IdUtilisateur);
            Assert.Equal(toto.Nom, totoBDD.Nom);
            Assert.Equal(toto.Prenom, totoBDD.Prenom);
            Assert.Equal(toto.DateNaissance, totoBDD.DateNaissance);
            Assert.Equal(toto.Mail, totoBDD.Mail);
            Assert.Equal(toto.Hash, totoBDD.Hash);
            UtilisateurManager.Delete(toto.IdUtilisateur);
        }

        [Fact]
        public void TestUpdate()
        {
            UtilisateurManager.Create(toto);
            Utilisateur totoBDD = UtilisateurManager.GetById(toto.IdUtilisateur);
            Assert.Equal(toto.Prenom, totoBDD.Prenom);

            toto.Prenom = "Polo";
            UtilisateurManager.Update(toto);
            totoBDD = UtilisateurManager.GetById(toto.IdUtilisateur);
            Assert.Equal(toto.Prenom, totoBDD.Prenom);

            UtilisateurManager.Delete(toto.IdUtilisateur);
        }
    }
}