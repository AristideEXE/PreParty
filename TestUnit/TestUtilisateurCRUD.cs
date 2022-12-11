using Metier;

namespace TestUnit
{
    public class TestUtilisateurCRUD
    {
        Utilisateur toto = new Utilisateur(-1, "Dupont", "Toto", new DateTime(2008, 05, 15), "toto.dupont@gmail.com", "f2d81a260dea8a100dd517984e53c56a7523d96942a834b9cdc249bd4e8c7aa9");

        [Fact]
        public void TestAddDelete()
        {
            Assert.False(UtilisateurCRUD.UtilisateurExists(toto.IdUtilisateur));
            UtilisateurCRUD.Create(toto);
            Assert.True(UtilisateurCRUD.UtilisateurExists(toto.IdUtilisateur));
            UtilisateurCRUD.Delete(toto.IdUtilisateur);
            Assert.False(UtilisateurCRUD.UtilisateurExists(toto.IdUtilisateur));
        }

        [Fact]
        public void TestGetById()
        {
            UtilisateurCRUD.Create(toto);
            Utilisateur totoBDD = UtilisateurCRUD.GetById(toto.IdUtilisateur);
            Assert.Equal(toto.Nom, totoBDD.Nom);
            Assert.Equal(toto.Prenom, totoBDD.Prenom);
            Assert.Equal(toto.DateNaissance, totoBDD.DateNaissance);
            Assert.Equal(toto.Mail, totoBDD.Mail);
            Assert.Equal(toto.Hash, totoBDD.Hash);
            UtilisateurCRUD.Delete(toto.IdUtilisateur);
        }

        [Fact]
        public void TestUpdate()
        {
            UtilisateurCRUD.Create(toto);
            Utilisateur totoBDD = UtilisateurCRUD.GetById(toto.IdUtilisateur);
            Assert.Equal(toto.Prenom, totoBDD.Prenom);

            toto.Prenom = "Polo";
            UtilisateurCRUD.Update(toto);
            totoBDD = UtilisateurCRUD.GetById(toto.IdUtilisateur);
            Assert.Equal(toto.Prenom, totoBDD.Prenom);

            UtilisateurCRUD.Delete(toto.IdUtilisateur);
        }
    }
}