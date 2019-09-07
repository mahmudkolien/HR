import { IEntity } from '../../shared/entity.model';
import { IAuditable } from '../../shared/auditable.model';

export interface IUserRolePermission extends IEntity {
    permission: string;
}

export interface ISaveUserRolePermission {
    permissionName: string;
    permissionCategory: string;
    isChecked: boolean;
}


