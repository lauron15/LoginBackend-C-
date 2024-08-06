using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProjetoLoguin.Model;
using ProjetoLoguin.Util;
using System;

[Route("api/[controller]")]
[ApiController]
public class FuncionariosController : ControllerBase
{
    private readonly AppDatabase _context;

    public FuncionariosController(AppDatabase context)
    {
        _context = context;
    }

    // GET: api/Employees
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<IEnumerable<Funcionario>>> GetEmployees()
    {

        var listaEmployee = _context.Funcionarios.ToList();

        return listaEmployee;

    }

    // GET: api/Employees/5
    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<ActionResult<Funcionario>> GetEmployee(int id)
    {
        var employee = await _context.Funcionarios.FindAsync(id);
        // posso usar também o .Where para buscar algo do meu proprio objeto
        //var employee = await _context.Employees.Where(c=> c.id == id).FirstOrDefault;
        // se eu quiser pegar por exemplo todos os employees que tem idade igual eu faria
        //var employee = await _context.Employees.Where(c=> c.age == 10).ToList();

        if (employee == null)
        {
            return NotFound();
        }

        return employee;
    }

    // POST: api/Employees
    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult<Funcionario>> PostEmployee(Funcionario funcionario)
    {
        

        if (String.IsNullOrEmpty(funcionario.Name))
        {
            return BadRequest("O nome não pode ser vazio");    
        }


        // toda consulta que eu altero ou adiciono alguma coisa no banco de dados eu preciso chamar o metodo _context.SaveChanges() para salvar as mudanças
        _context.Funcionarios.Add(funcionario);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetEmployee", new { id = funcionario.Id }, funcionario);
    }

    // PUT: api/Employees/5
    [HttpPut("{id}")]
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

    private bool EmployeeExists(int id)
    {
        return _context.Funcionarios.Any(e => e.Id == id);
    }
}
