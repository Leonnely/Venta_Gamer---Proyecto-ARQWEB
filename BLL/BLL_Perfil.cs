using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class BLL_Perfil
    {
        private DAL_Perfil dalPerfil = new DAL_Perfil();
        public List<Role> GetRoles()
        {
            return dalPerfil.GetRoles();
        }

        public List<Permission> GetPermissions()
        {
            return dalPerfil.GetPermissions();
        }

        public void CreateRole(Role role, List<int> selectedPermissions, int? parentRoleId)
        {
            dalPerfil.CreateRole(role);

            foreach (int permissionId in selectedPermissions)
            {
                dalPerfil.AddPermissionToRole(role.ID, permissionId);
            }

            if (parentRoleId.HasValue)
            {
                dalPerfil.AddRoleHierarchy(parentRoleId.Value, role.ID);
            }
        }
        public void DeleteRole(int roleId)
        {
            DAL_Perfil dalPerfil = new DAL_Perfil();
            DeleteRoleRecursively(roleId, dalPerfil);
        }

        private void DeleteRoleRecursively(int roleId, DAL_Perfil dalPerfil)
        {
            // Obtener los roles hijos
            List<int> childRoleIds = dalPerfil.GetChildRoles(roleId);

            // Eliminar recursivamente los roles hijos
            foreach (int childRoleId in childRoleIds)
            {
                DeleteRoleRecursively(childRoleId, dalPerfil);
            }

            // Eliminar el rol actual
            dalPerfil.DeleteRole(roleId);
        }
        public List<Permission> GetPermissionsByRoleId(int roleId)
        {
            DAL_Perfil dalPerfil = new DAL_Perfil();
            return dalPerfil.GetPermissionsByRoleId(roleId);
        }
        public void AddPermissionsToRole(int roleId, List<int> permissionIds)
        {
            DAL_Perfil dalPerfil = new DAL_Perfil();
            dalPerfil.AddPermissionsToRole(roleId, permissionIds);
        }
        public void RemovePermissionsFromRole(int roleId, List<int> permissionIds)
        {
            DAL_Perfil dalPerfil = new DAL_Perfil();
            dalPerfil.RemovePermissionsFromRole(roleId, permissionIds);
        }
    }
}
