

using Microsoft.EntityFrameworkCore;

namespace WebAPI;

public class FuncionarioService : IFuncionarioInterface
{
    private readonly ApplicationDbContext _context;
    public FuncionarioService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ServiceResponse<List<FuncionarioModel>>> CreateFuncionario(FuncionarioModel novoFuncionario)
    {
        ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();
        try
        {
            if (novoFuncionario == null)
            {
                serviceResponse.Dados = null;
                serviceResponse.Mensagem = "Informar dados";
                serviceResponse.Sucesso = false;
                return serviceResponse;
            }
            _context.Add(novoFuncionario);
            await _context.SaveChangesAsync();
            serviceResponse.Dados = _context.apiDatabase.ToList();

        }
        catch (Exception ex)
        {
            serviceResponse.Mensagem = ex.Message;
            serviceResponse.Sucesso = false;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<FuncionarioModel>>> DeleteFuncionario(int id)
    {
        ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

        try
        {
            FuncionarioModel funcionario = _context.apiDatabase.FirstOrDefault(x => x.Id == id);

            if (funcionario == null)
            {
                serviceResponse.Dados = null;
                serviceResponse.Mensagem = "Usuário não localizado!";
                serviceResponse.Sucesso = false;

                return serviceResponse;
            }

            _context.apiDatabase.Remove(funcionario);
            await _context.SaveChangesAsync();

            serviceResponse.Dados = _context.apiDatabase.ToList();

        }
        catch (Exception ex)
        {
            serviceResponse.Mensagem = ex.Message;
            serviceResponse.Sucesso = false;
        }
        return serviceResponse;

    }

    public async Task<ServiceResponse<FuncionarioModel>> GetFuncionarioById(int id)
    {
        ServiceResponse<FuncionarioModel> serviceResponse = new ServiceResponse<FuncionarioModel>();
        try
        {
            FuncionarioModel funcionario = _context.apiDatabase.FirstOrDefault(x => x.Id == id);
            serviceResponse.Dados = funcionario;
            if (funcionario == null)
            {
                serviceResponse.Dados = null;
                serviceResponse.Mensagem = "Usuário não localizado!";
                serviceResponse.Sucesso = false;
            }
        }
        catch (Exception ex)
        {
            serviceResponse.Mensagem = ex.Message;
            serviceResponse.Sucesso = false;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<FuncionarioModel>>> GetFuncionarios()
    {
        ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

        try
        {
            serviceResponse.Dados = _context.apiDatabase.ToList();
            if (serviceResponse.Dados.Count == 0)
            {
                serviceResponse.Mensagem = "Nenhum dado encontrado!";
            }

        }
        catch (Exception ex)
        {
            serviceResponse.Mensagem = ex.Message;
            serviceResponse.Sucesso = false;
        }

        return serviceResponse;

    }

    public async Task<ServiceResponse<List<FuncionarioModel>>> InativaFuncionario(int id)
    {
        ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();
        try
        {
            FuncionarioModel funcionario = _context.apiDatabase.FirstOrDefault(x => x.Id == id);
            if (funcionario == null)
            {
                serviceResponse.Dados = null;
                serviceResponse.Mensagem = "Usuário não localizado!";
                serviceResponse.Sucesso = false;
            }
            funcionario.Ativo = false;
            funcionario.DataDeAlteracao = DateTime.Now.ToLocalTime();
            _context.apiDatabase.Update(funcionario);
            await _context.SaveChangesAsync();
            serviceResponse.Dados = _context.apiDatabase.ToList();
        }
        catch (Exception ex)
        {
            serviceResponse.Mensagem = ex.Message;
            serviceResponse.Sucesso = false;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<FuncionarioModel>>> UpdateFuncionario(FuncionarioModel editadoFuncionario)
    {
        ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();
        try
        {
            FuncionarioModel funcionario = _context.apiDatabase.AsNoTracking().FirstOrDefault(x => x.Id == editadoFuncionario.Id);
            if (funcionario == null)
            {
                serviceResponse.Dados = null;
                serviceResponse.Mensagem = "Usuário não localizado!";
                serviceResponse.Sucesso = false;
            }

            funcionario.DataDeAlteracao = DateTime.Now.ToLocalTime();
            _context.apiDatabase.Update(editadoFuncionario);
            await _context.SaveChangesAsync();
            serviceResponse.Dados = _context.apiDatabase.ToList();

        }
        catch (Exception ex)
        {
            serviceResponse.Mensagem = ex.Message;
            serviceResponse.Sucesso = false;
        }
        return serviceResponse;
    }

}
