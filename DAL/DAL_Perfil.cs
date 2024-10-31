using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Perfil
    {
        private Acceso acceso = new Acceso();

        public List<Role> GetRoles()
        {
            List<Role> roles = new List<Role>();
            DataTable dtRoles = acceso.Read("SELECT ID, Descripcion FROM Roles", null);

            foreach (DataRow row in dtRoles.Rows)
            {
                Role role = new Role
                {
                    ID = Convert.ToInt32(row["ID"]),
                    Descripcion = Convert.ToString(row["Descripcion"])
                };

                roles.Add(role);
            }

            return roles;
        }

        public List<Permission> GetPermissions()
        {
            List<Permission> permissions = new List<Permission>();
            DataTable dtPermissions = acceso.Read("SELECT ID, Descripcion FROM Permisos", null);

            foreach (DataRow row in dtPermissions.Rows)
            {
                Permission permission = new Permission
                {
                    ID = Convert.ToInt32(row["ID"]),
                    Descripcion = Convert.ToString(row["Descripcion"])
                };

                permissions.Add(permission);
            }

            return permissions;
        }

        public void CreateRole(Role role)
        {
            string query = "INSERT INTO Roles (Descripcion) " +
                   "VALUES (@Descripcion); " +
                   "SELECT SCOPE_IDENTITY();"; // Obtener el ID generado

            SqlParameter[] parametros = new SqlParameter[]
            {
        new SqlParameter("@Descripcion", role.Descripcion)
            };

            // Ejecutar la consulta y obtener el ID generado
            object result = acceso.ExecuteScalar(query, parametros);
            if (result != null)
            {
                role.ID = Convert.ToInt32(result);
            }
        }

        public void AddPermissionToRole(int roleId, int permissionId)
        {
            string query = "INSERT INTO RolesPermisos (IDRol, IDPermiso) VALUES (@IDRol, @IDPermiso)";

            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@IDRol", roleId),
            new SqlParameter("@IDPermiso", permissionId)
            };

            acceso.Write(query, parameters);
        }

        public void AddRoleHierarchy(int parentRoleId, int childRoleId)
        {
            string query = "INSERT INTO RolesJerarquia (ID_RolPadre, ID_RolHijo) VALUES (@ID_RolPadre, @ID_RolHijo)";

            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@ID_RolPadre", parentRoleId),
            new SqlParameter("@ID_RolHijo", childRoleId)
            };

            acceso.Write(query, parameters);
        }
        public List<int> GetChildRoles(int parentRoleId)
        {
            List<int> childRoleIds = new List<int>();
            string query = "SELECT ID_RolHijo FROM RolesJerarquia WHERE ID_RolPadre = @ParentRoleId";
            SqlParameter[] parametros = {
        new SqlParameter("@ParentRoleId", SqlDbType.Int) { Value = parentRoleId }
    };
            DataTable dt = acceso.Read(query, parametros);

            foreach (DataRow row in dt.Rows)
            {
                childRoleIds.Add(Convert.ToInt32(row["ID_RolHijo"]));
            }

            return childRoleIds;
        }

        public void DeleteRole(int roleId)
        {
            // Eliminar las relaciones de jerarquía
            string queryJerarquia = "DELETE FROM RolesJerarquia WHERE ID_RolPadre = @RoleId OR ID_RolHijo = @RoleId";
            SqlParameter[] parametrosJerarquia = {
        new SqlParameter("@RoleId", SqlDbType.Int) { Value = roleId }
    };
            acceso.Write(queryJerarquia, parametrosJerarquia);

            // Eliminar las relaciones de permisos
            string queryPermisos = "DELETE FROM RolesPermisos WHERE IDRol = @RoleId";
            SqlParameter[] parametrosPermisos = {
        new SqlParameter("@RoleId", SqlDbType.Int) { Value = roleId }
    };
            acceso.Write(queryPermisos, parametrosPermisos);

            // Eliminar el rol
            string queryRole = "DELETE FROM Roles WHERE ID = @RoleId";
            SqlParameter[] parametrosRole = {
        new SqlParameter("@RoleId", SqlDbType.Int) { Value = roleId }
    };
            acceso.Write(queryRole, parametrosRole);
        }
        public List<Permission> GetPermissionsByRoleId(int roleId)
        {
            List<Permission> permissions = new List<Permission>();
            string query = @"
        SELECT P.ID, P.Descripcion 
        FROM RolesPermisos RP
        INNER JOIN Permisos P ON RP.IDPermiso = P.ID
        WHERE RP.IDRol = @RoleId";

            SqlParameter[] parametros = {
        new SqlParameter("@RoleId", SqlDbType.Int) { Value = roleId }
    };

            DataTable dt = acceso.Read(query, parametros);

            foreach (DataRow row in dt.Rows)
            {
                Permission permission = new Permission
                {
                    ID = Convert.ToInt32(row["ID"]),
                    Descripcion = Convert.ToString(row["Descripcion"])
                };

                permissions.Add(permission);
            }

            return permissions;
        }
        public void AddPermissionsToRole(int roleId, List<int> permissionIds)
        {
            foreach (int permissionId in permissionIds)
            {
                string query = "INSERT INTO RolesPermisos (IDRol, IDPermiso) VALUES (@IDRol, @IDPermiso)";

                SqlParameter[] parametros = new SqlParameter[]
                {
            new SqlParameter("@IDRol", SqlDbType.Int) { Value = roleId },
            new SqlParameter("@IDPermiso", SqlDbType.Int) { Value = permissionId }
                };

                acceso.Write(query, parametros);
            }
        }
        public void RemovePermissionsFromRole(int roleId, List<int> permissionIds)
        {
            foreach (int permissionId in permissionIds)
            {
                string query = "DELETE FROM RolesPermisos WHERE IDRol = @IDRol AND IDPermiso = @IDPermiso";

                SqlParameter[] parametros = new SqlParameter[]
                {
            new SqlParameter("@IDRol", SqlDbType.Int) { Value = roleId },
            new SqlParameter("@IDPermiso", SqlDbType.Int) { Value = permissionId }
                };

                acceso.Write(query, parametros);
            }
        }
    }
}
