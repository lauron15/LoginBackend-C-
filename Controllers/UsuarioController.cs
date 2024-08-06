using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoLoguin.Model;
using ProjetoLoguin.Util;
using System;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly AppDatabase _context;

    public UsuarioController(AppDatabase context)
    {
        _context = context;
    }

    // GET: api/Employees
    [HttpGet] 
    [AllowAnonymous] //permite o acesso sem verificação
    public async Task<ActionResult<IEnumerable<Usuario>>> GetEmployees() 
    {
    
        var listaUsuarios = _context.Usuarios.ToList();

        return listaUsuarios;

    }

    // GET: api/Employees/5
    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<ActionResult<Usuario>> GetEmployee(int id) // é só o nome do método
    {
        var Usuarios =  _context.Usuarios.Find(id);
        // posso usar também o .Where para buscar algo do meu proprio objeto
        //var employee = await _context.Employees.Where(c=> c.id == id).FirstOrDefault;
        // se eu quiser pegar por exemplo todos os employees que tem idade igual eu faria
        //var employee = await _context.Employees.Where(c=> c.age == 10).ToList();

        if (Usuarios == null)
        {
            return NotFound();
        }

        return Usuarios;
    }

    // POST: api/Employees
    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult<Funcionario>> PostEmployee(Funcionario employee)
    {
        // toda consulta que eu altero ou adiciono alguma coisa no banco de dados eu preciso chamar o metodo _context.SaveChanges() para salvar as mudanças
        _context.Funcionarios.Add(employee);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
    }

    // PUT: api/Employees/5
    [HttpPut("{id}")] //vai procurar o usuario pelo id e somente assim vai poder adicionar. 
    [AllowAnonymous]
    public async Task<IActionResult> PutEmployee(Funcionario employee)
    {
        var funcionarioAntigo = _context.Funcionarios.Find(employee.Id);

        if (funcionarioAntigo == null)
        {
            return NotFound();
        }


        _context.Entry(funcionarioAntigo).CurrentValues.SetValues(employee);
        _context.SaveChanges();

        return NoContent();
    }

    // DELETE: api/Employees/5
    [HttpDelete("{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> DeleteEmployee(int id)
    {
        var employee = await _context.Funcionarios.FindAsync(id);
        if (employee == null)
        {
            return NotFound();
        }

        _context.Funcionarios.Remove(employee);
        await _context.SaveChangesAsync();

        return NoContent();
    }

}
