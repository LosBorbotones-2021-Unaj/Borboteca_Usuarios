using Borboteca_Usuarios.API.Controllers;
using Borboteca_Usuarios.Application.Sengrid;
using Borboteca_Usuarios.Application.Services;
using Borboteca_Usuarios.Application.Utilities;
using Borboteca_Usuarios.Domain.Commands;
using Borboteca_Usuarios.Domain.DTO;
using Borboteca_Usuarios.Domain.Queries;
using Moq;
using NUnit.Framework;
using System;

namespace Borboteca_Usuarios.Test
{
    public class Test_Borboteca
    {
        Mock<IGenericsRepository> _repoGenerico;
        Mock<IUsuarioQuery> _queryUsuario;
        Mock<IMailService> _mailService;
        Mock<IFavoritoQuery> _queryFavorito;
        Mock<IUsuarioService> _usuarioService;
        [SetUp]
        public void Setup()
        {
            _repoGenerico = new Mock<IGenericsRepository>();
            _queryUsuario = new Mock<IUsuarioQuery>();
            _mailService = new Mock<IMailService>();
            _queryFavorito = new Mock<IFavoritoQuery>();
            _usuarioService = new Mock<IUsuarioService>();
        }
        [Test]
        public void UsuarioService_GetUsuarioId_Null()
        {
            // Arrange
            int id = 1;
            var usuarioService = new UsuarioService(_repoGenerico.Object,_queryUsuario.Object,_mailService.Object);
            // Act
            var testear = usuarioService.GetUsuarioById(id);
            // Assert
            Assert.AreEqual(null, testear);
        }
        [Test]
        public void UsuarioService_GetUsuarioEmail_Null()
        {
            // Arrange
            string email = "carlossuarez235@gmail.com";
            var usuarioService = new UsuarioService(_repoGenerico.Object, _queryUsuario.Object, _mailService.Object);
            // Act
            var testear = usuarioService.GetUsuarioByEmail(email);
            // Assert
            Assert.AreEqual(null, testear);
        }
        [Test]
        public void FavoritoService_DeleteFavorito_Success()
        {
            // Arrange
            FavoritoDTO favoritoDTO = new FavoritoDTO()
            {
                idUsuario = 1,
                Libro = Guid.NewGuid()
            };
            var favoritoService = new ServiceFavorito(_repoGenerico.Object, _queryFavorito.Object);
            // Act
            var testear = favoritoService.DeleteFavorito(favoritoDTO);
            // Assert
            Assert.AreEqual(true, testear);
        }
        [Test]
        public void FavoritoService_ExisteFavorito_Bad()
        {
            // Arrange
            FavoritoDTO favoritoDTO = new FavoritoDTO()
            {
                idUsuario = 1,
                Libro = Guid.NewGuid()
            };
            var favoritoService = new ServiceFavorito(_repoGenerico.Object, _queryFavorito.Object);
            // Act
            var testear = favoritoService.ExisteFavorito(favoritoDTO);
            // Assert
            Assert.AreEqual(false, testear);
        }
        [Test]
        public void UsuarioController_VerificarExistente_Bad()
        {
            // Arrange
            string email = "carlossuarez235@gmail.com";
            var esperado = false;
            var controlador = new UsuarioController(_usuarioService.Object);
            // Act
            var verificar = controlador.verificarSiExisteUsuario(email);
            // Assert
            Assert.IsFalse(verificar);
        }
        [Test]
        public void UsuarioController_VerificarToken_Success()
        {
            // Arrange
            string password = "1122334455";
            // Act
            var token = Encrypt.GetSHA256(password);
            // Assert
            Assert.IsNotNull(token);
        }
        [Test]
        public void UsuarioController_VerificarToken_Bad()
        {
            // Arrange Act Assert
            Assert.Throws<ArgumentNullException>(() => Encrypt.GetSHA256(null));
        }
    }
}