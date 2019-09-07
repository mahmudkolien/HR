import { RolePermission } from './../../../shared/user-role-permission';
import { ISaveUserRolePermission } from './user-role-permission.model';

export class UserRolePermissionData {
    items: ISaveUserRolePermission[] = [
        // User
        { permissionName: RolePermission.UserCreate, permissionCategory: 'User_Configuration' },
        { permissionName: RolePermission.UserEdit, permissionCategory: 'User_Configuration' },
        { permissionName: RolePermission.UserDelete, permissionCategory: 'User_Configuration' },
        { permissionName: RolePermission.UserView, permissionCategory: 'User_Configuration' },

        // User Role
        // tslint:disable-next-line: max-line-length
        { permissionName: RolePermission.UserRoleCreate, permissionCategory: 'User_Role_Configuration' },
        { permissionName: RolePermission.UserRoleEdit, permissionCategory: 'User_Role_Configuration' },
        // tslint:disable-next-line: max-line-length
        { permissionName: RolePermission.UserRoleDelete, permissionCategory: 'User_Role_Configuration' },
        // tslint:disable-next-line: max-line-length
        { permissionName: RolePermission.UserRoleView, permissionCategory: 'User_Role_Configuration' },
    ];
}