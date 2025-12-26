using Inventario.Models;

namespace Inventario.IRepositories
{
    public interface IUsuarioRep
    {
        Task<List<Usuarios>> ConsultarUsuarios();
        Task<Usuarios?> ObtenerUsuarioPorId(int IdUsuario);
    }
}
