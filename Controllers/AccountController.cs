using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoLoguin.Model;
using ProjetoLoguin.Service;
using ProjetoLoguin.Util;
using System;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly AppDatabase _context;

    public AccountController(AppDatabase context)
    {
        _context = context;
    }


    // tres tipos de envio para api
    // o primeiro é o envio na rota onde eu chamo httpGet("{id}") e recebo no parametro do endpoint [FromRoute] int id
    // tenho a segunda opção que é o envio atraves de query parameters api/account?id=1 e no parametro seria só int id
    // e tenho a opção de receber algo no corpo da minha rquisição que ai eu chamo [FromBody] Usuario usuario

    [HttpPost]
    [AllowAnonymous]
    public ActionResult Login([FromBody] Usuario usuario)
    {
        try
        {
            var service = new UserService(_context);
            Usuario user = new Usuario();

            user = service.Authenticate(usuario.Nome, usuario.Senha);

            if (user == null)
                return BadRequest("Usuário ou senha inválidos");

            return Ok(user);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

    }

    // sempre colocar o nome do controller então seria api/account/cadastro
    [HttpPost("cadastro")]
    [AllowAnonymous]
    public ActionResult Cadastro([FromBody] Usuario usuario)
    {
        if (usuario.Nome == "")
            return BadRequest("Nome incorreto");
        else if (usuario.Senha == "")
            return BadRequest("Senha incorreta");
        else if (usuario.Email == "")
            return BadRequest("Email incorreto");

        _context.Usuarios.Add(usuario);
        _context.SaveChanges();
        return Ok();
    }

    // sempre colocar o nome do controller então seria api/account/alterarsenha
    
    //[httpput("alterarsenha")]
    //[allowanonymous]
    //public actionresult alterarsenha([frombody] usuario usuario)
    //{
    //    //if (usuario.id != 0)
    //    //    return badrequest("não foi possivel encontrar usuário");

    //    if (string.isnullorempty(usuario.nome))
    //        return badrequest("digite um nome válido");

    //    if (string.isnullorempty(usuario.email))
    //        return badrequest("digite um e-mail válido");


    //    var usuarioexist = _context.usuarios
    //        .where(c => (c.nome != null && c.nome.toupper() == usuario.nome.toupper())
    //                 && (c.email != null && c.email.toupper() == usuario.email.toupper())).firstordefault();

    //    if (usuarioexist == null)
    //        return badrequest("usuário não existe");

    //    usuarioexist.senha = usuario.senha;
    //    _context.savechanges();

    //    return ok();
    //}
}


